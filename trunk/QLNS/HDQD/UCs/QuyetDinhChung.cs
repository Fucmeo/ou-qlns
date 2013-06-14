using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;

namespace HDQD.UCs
{
    public partial class QuyetDinhChung : UserControl
    {
        Business.HDQD.QuyetDinhChung oQDChung;
        Business.HDQD.LoaiQuyetDinh oLoaiQD;
        Business.HDQD.LoaiPhuCap oLoaiPhuCap;

        public static string strMaNVOld, strHoOld, strTenOld; // gia tri ho ten luc moi tim, dung de so sanh khi nhap phong TH ng dung sua thong tin sau khi tim duoc cnvc
        // se duoc gan khi double click nv o gridview ds

        public QuyetDinhChung()
        {
            InitializeComponent();
            oQDChung = new Business.HDQD.QuyetDinhChung();
            oLoaiQD = new Business.HDQD.LoaiQuyetDinh();
            oLoaiPhuCap = new Business.HDQD.LoaiPhuCap();
        }

        private void QuyetDinhChung_Load(object sender, EventArgs e)
        {
            SetupDTGV();
            PrepareSourceLoaiQuyetDinh();
            PrepareSourceLoaiPhuCapCombo();
            //comB_HeSoTienMat.SelectedIndex = 0;
        }

        private void cb_CoPhuCap_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_CoPhuCap.Checked)
            {
                //comB_HeSoTienMat.Enabled = 
                    comB_LoaiPhuCap.Enabled = 
                   // txt_PhuCap.Enabled = 
                    dTP_NgayBatDau.Enabled = dTP_NgayHetHan.Enabled
                    = rTB_GhiChu.Enabled = false;
            }
            else
            {
                //comB_HeSoTienMat.Enabled = 
                    comB_LoaiPhuCap.Enabled = 
                    //txt_PhuCap.Enabled = 
                    dTP_NgayBatDau.Enabled = dTP_NgayHetHan.Enabled
                    = rTB_GhiChu.Enabled = true;
            }
        }

        private void PrepareSourceLoaiQuyetDinh()
        {
            DataTable dt = new DataTable();
            dt = oLoaiQD.GetList();

            // chi load nhung loai quyet dinh do ng dung them vao

                var vdt = dt.AsEnumerable().Where(a => a.Field<int>("id") >= 8);

            if(vdt.Count() > 0)
                dt = vdt.CopyToDataTable();

            thongTinQuyetDinh1.comB_Loai.DataSource = dt;
            thongTinQuyetDinh1.comB_Loai.DisplayMember = "ten_loai";
            thongTinQuyetDinh1.comB_Loai.ValueMember = "id";
        }

        private bool CompareCNVCInfo()
        {
            return (!(strMaNVOld != thongTinCNVC1.txt_MaNV.Text || strHoOld != thongTinCNVC1.txt_Ho.Text || strTenOld != thongTinCNVC1.txt_Ten.Text));
        }

        private void ResetInterface()
        {
            thongTinCNVC1.txt_Ten.Text = thongTinCNVC1.txt_MaNV.Text = thongTinCNVC1.txt_Ho.Text = "";
            //txt_PhuCap.Text = 
                rTB_GhiChu.Text = "";
            cb_CoPhuCap.Checked = false;
            thongTinQuyetDinh1.txt_MaQD.Text
                = thongTinQuyetDinh1.txt_TenQD.Text = thongTinQuyetDinh1.rTB_MoTa.Text = "";

            dtgv_DSCNVC.Rows.Clear();
        }

        private void PrepareSourceLoaiPhuCapCombo()
        {
            DataTable dtLoaiPhuCap = oLoaiPhuCap.GetList();
            if (dtLoaiPhuCap.Rows.Count > 0)
            {
                DataRow dr = dtLoaiPhuCap.NewRow();
                dr["ten_loai"] = "";
                dr["id"] = -1;
                dtLoaiPhuCap.Rows.InsertAt(dr, 0);

                comB_LoaiPhuCap.DataSource = dtLoaiPhuCap;
                comB_LoaiPhuCap.DisplayMember = "ten_loai";
                comB_LoaiPhuCap.ValueMember = "id";
            }
            else
            {
                MessageBox.Show("Không có loại phụ cấp nào tồn tại trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        /// lay thong tin cua cac cnvc trong gridview
        /// </summary>
        /// <param name="dgv"></param>
        private void GetGridViewContent(DataGridView dgv)
        {
            try
            {
                int RowsCount = dgv.Rows.Count;
                if (RowsCount == 0) return;

                oQDChung.MaNV = new string[RowsCount];                
                oQDChung.LoaiPhuCap = new int[RowsCount];
                oQDChung.PhuCap = new string[RowsCount];
                oQDChung.NgayTaoPC = new DateTime[RowsCount];
                oQDChung.NgayHetHanPC = new DateTime[RowsCount];
                oQDChung.NgayBatDau = new DateTime[RowsCount];
                oQDChung.HeSo_TienMat = new bool[RowsCount];
                oQDChung.GhiChu = new string[RowsCount];

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    oQDChung.MaNV[i] = Convert.ToString(dgv.Rows[i].Cells["ma_nv"].Value);


                    if (dgv.Rows[i].Cells["loai_phu_cap_id"].Value == null) // khi truyen loai phu cap = -1 
                    // => sto se khong insert phu cap vao db
                    // => cac field khac truyen whatever
                    {
                        oQDChung.LoaiPhuCap[i] = -1;
                        oQDChung.PhuCap[i] = null;
                        oQDChung.NgayTaoPC[i] = oQDChung.NgayBatDau[i] = oQDChung.NgayHetHanPC[i] = DateTime.MinValue;
                        oQDChung.HeSo_TienMat[i] = true;
                        oQDChung.GhiChu[i] = null;
                    }
                    else
                    {
                        oQDChung.LoaiPhuCap[i] = Convert.ToInt32(dgv.Rows[i].Cells["loai_phu_cap_id"].Value);
                        oQDChung.PhuCap[i] = Convert.ToString(dgv.Rows[i].Cells["phu_cap"].Value);
                        oQDChung.NgayBatDau[i] = Convert.ToDateTime(dgv.Rows[i].Cells["ngay_bat_dau"].Value);
                        oQDChung.NgayTaoPC[i] = DateTime.Now;
                        string s = dgv.Rows[i].Cells["ngay_het_han"].Value.ToString();
                        if (s == "KHÔNG")
                            oQDChung.NgayHetHanPC[i] = DateTime.MinValue; // 1/1/0001 12:00:00 AM 
                        else
                            oQDChung.NgayHetHanPC[i] = Convert.ToDateTime(dgv.Rows[i].Cells["ngay_het_han"].Value);

                        oQDChung.HeSo_TienMat[i] = Convert.ToString(dgv.Rows[i].Cells["heso_tienmat"].Value) == "Hệ số" ? true : false;
                        oQDChung.GhiChu[i] = Convert.ToString(dgv.Rows[i].Cells["ghi_chu"].Value);
                    }
                }
            }
            catch { throw new Exception("Danh sách nhân viên có dữ liệu không hợp lệ hoặc loại quyết định không phù hợp với thông tin cung cấp."); }
        }

        /// <summary>
        /// lay thong tin cua quyet dinh bo nhiem tren giao dien
        /// </summary>
        private void GetQuyetDinhContent()
        {
            oQDChung.MaQuyetDinh = thongTinQuyetDinh1.txt_MaQD.Text.Trim();
            oQDChung.Ten = thongTinQuyetDinh1.txt_TenQD.Text.Trim();
            oQDChung.LoaiQuyetDinh = Convert.ToInt16(thongTinQuyetDinh1.comB_Loai.SelectedValue);
            oQDChung.NgayHieuLucQD = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;
            if (thongTinQuyetDinh1.dTP_NgayHetHan.Checked)
                oQDChung.NgayHetHanQD = thongTinQuyetDinh1.dTP_NgayHetHan.Value;
            else
                oQDChung.NgayHetHanQD = null;

            oQDChung.NgayTaoQD = thongTinQuyetDinh1.dTP_NgayKy.Value;
            oQDChung.MoTa = thongTinQuyetDinh1.rTB_MoTa.Text;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(thongTinCNVC1.txt_MaNV.Text) && CompareCNVCInfo())
            {
                UInt32 a;
                //if (cb_CoPhuCap.Checked || (comB_HeSoTienMat.Text == "Tiền mặt" && UInt32.TryParse(txt_PhuCap.Text.Trim(), out a))
                //        || (comB_HeSoTienMat.Text == "Hệ số"))
                //{
                //    int new_index = dtgv_DSCNVC.Rows.Add(1);

                //    dtgv_DSCNVC.Rows[new_index].Cells["ma_nv"].Value = thongTinCNVC1.txt_MaNV.Text.Trim();
                //    dtgv_DSCNVC.Rows[new_index].Cells["ho"].Value = thongTinCNVC1.txt_Ho.Text.Trim();
                //    dtgv_DSCNVC.Rows[new_index].Cells["ten"].Value = thongTinCNVC1.txt_Ten.Text.Trim();

                //    if (cb_CoPhuCap.Checked)
                //    {
                //        dtgv_DSCNVC.Rows[new_index].Cells["phu_cap"].Value = "KHÔNG";
                //        dtgv_DSCNVC.Rows[new_index].Cells["ten_loai_phu_cap"].Value = "KHÔNG";
                //        dtgv_DSCNVC.Rows[new_index].Cells["loai_phu_cap_id"].Value = null;
                //        dtgv_DSCNVC.Rows[new_index].Cells["ngay_bat_dau"].Value = "KHÔNG";
                //        dtgv_DSCNVC.Rows[new_index].Cells["ngay_het_han"].Value = "KHÔNG";
                //        dtgv_DSCNVC.Rows[new_index].Cells["ghi_chu"].Value = "KHÔNG";
                //        dtgv_DSCNVC.Rows[new_index].Cells["heso_tienmat"].Value = "KHÔNG";
                //    }
                //    else
                //    {
                //        //dtgv_DSCNVC.Rows[new_index].Cells["phu_cap"].Value = txt_PhuCap.Text.Trim();
                //        dtgv_DSCNVC.Rows[new_index].Cells["ten_loai_phu_cap"].Value = comB_LoaiPhuCap.Text;
                //        dtgv_DSCNVC.Rows[new_index].Cells["loai_phu_cap_id"].Value = comB_LoaiPhuCap.SelectedValue;
                //        dtgv_DSCNVC.Rows[new_index].Cells["ngay_bat_dau"].Value = dTP_NgayBatDau.Value.Date;
                //        if (dTP_NgayHetHan.Checked)
                //            dtgv_DSCNVC.Rows[new_index].Cells["ngay_het_han"].Value = dTP_NgayHetHan.Value.Date;
                //        else
                //            dtgv_DSCNVC.Rows[new_index].Cells["ngay_het_han"].Value = "KHÔNG";
                //        dtgv_DSCNVC.Rows[new_index].Cells["ghi_chu"].Value = rTB_GhiChu.Text;
                //       // dtgv_DSCNVC.Rows[new_index].Cells["heso_tienmat"].Value = comB_HeSoTienMat.Text;
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("Phụ cấp có giá trị không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

            }
            else
            {
                MessageBox.Show("Thông tin chưa đầy đủ hoặc không đúng so với kết quả tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_NhapFile_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Nhap_Click(object sender, EventArgs e)
        {
            if (dtgv_DSCNVC.Rows.Count > 0
                && !string.IsNullOrWhiteSpace(thongTinQuyetDinh1.txt_MaQD.Text)
                && !string.IsNullOrWhiteSpace(thongTinQuyetDinh1.txt_TenQD.Text))
            {


                try
                {
                    GetQuyetDinhContent();
                    // danh sach nhan vien
                    GetGridViewContent(dtgv_DSCNVC);
                    oQDChung.Add();


                    MessageBox.Show("Thao tác nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ResetInterface();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thao tác nhập không thành công.\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Xin vui lòng điền thông tin quyết định và thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetupDTGV()
        {
            dtgv_DSCNVC.Columns.Add("ma_nv", "Mã nhân viên");
            dtgv_DSCNVC.Columns.Add("ho", "Họ");
            dtgv_DSCNVC.Columns.Add("ten", "Tên");
            dtgv_DSCNVC.Columns.Add("phu_cap", "Phụ cấp");
            dtgv_DSCNVC.Columns.Add("loai_phu_cap_id", "");
            dtgv_DSCNVC.Columns.Add("ten_loai_phu_cap", "Loại phụ cấp");
            dtgv_DSCNVC.Columns.Add("heso_tienmat", "Hệ số / tiền mặt");
            dtgv_DSCNVC.Columns.Add("ngay_bat_dau", "Ngày bắt đầu");
            dtgv_DSCNVC.Columns.Add("ngay_het_han", "Ngày hết hạn");
            dtgv_DSCNVC.Columns.Add("ghi_chu", "Ghi chú");

            dtgv_DSCNVC.Columns["loai_phu_cap_id"].Visible = false;   // ban dau se la bo nhiem > o hien thi tu don vi ...

            dtgv_DSCNVC.Columns["ma_nv"].Width = 150;
            dtgv_DSCNVC.Columns["ho"].Width = 250;
            dtgv_DSCNVC.Columns["ten"].Width = 120;
            dtgv_DSCNVC.Columns["phu_cap"].Width = 120;
            dtgv_DSCNVC.Columns["ten_loai_phu_cap"].Width = 120;
            dtgv_DSCNVC.Columns["ngay_bat_dau"].Width = 150;
            dtgv_DSCNVC.Columns["ngay_het_han"].Width = 150;
            dtgv_DSCNVC.Columns["ghi_chu"].Width = 300;
        }

        private void comB_LoaiPhuCap_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TLP_HienThiLoaiPC.Visible = true;
            TLP_HienThiLoaiPC.RowStyles[0].SizeType = TLP_HienThiLoaiPC.RowStyles[1].SizeType =
                TLP_HienThiLoaiPC.RowStyles[2].SizeType = SizeType.Percent;

            textBox1.Visible = textBox2.Visible = comboBox1.Visible = false;

            TLP_HienThiLoaiPC.RowStyles[0].Height = TLP_HienThiLoaiPC.RowStyles[1].Height = 1;
            TLP_HienThiLoaiPC.RowStyles[2].Height = 98;
        }
    }
}
