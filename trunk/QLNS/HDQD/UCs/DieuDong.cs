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
    public partial class DieuDong : UserControl
    {
        Business.FTP oFTP;
        DonVi oDonVi;
        ChucVu oChucVu;
        ChucDanh oChucDanh;
        Business.HDQD.KiemNhiem oKiemNhiem;
        Business.CNVC.CNVC_QTr_CongTac_OU oQtrCTacOU;
        string strLoaiQD = "Bổ nhiệm";  // moi lan thay doi combo loai QD se set value cho bien nay, default la Bo nhiem
        public static string strMaNVOld, strHoOld, strTenOld; // gia tri ho ten luc moi tim, dung de so sanh khi nhap phong TH ng dung sua thong tin sau khi tim duoc cnvc
                                                                // se duoc gan khi double click nv o gridview ds
        DataTable dtDSDieuDong;
        int row_count_dd = 0;

        public DieuDong()
        {
            InitializeComponent();
            oDonVi = new DonVi();
            oChucVu = new ChucVu();
            oChucDanh = new ChucDanh();
            //oKiemNhiem = new Business.HDQD.KiemNhiem();
            oFTP = new Business.FTP();
            InitObjects();
        }

        private void InitObjects()
        {
            oQtrCTacOU = new Business.CNVC.CNVC_QTr_CongTac_OU();
            thongTinCNVC1.Set_IsSearchQtrCtac(true, this);
            PrepareSourceLoaiQuyetDinh();
            PrepareDataTableDSDieuDong();
            PreapreDataSource();
        }

        public void Fill_QtrCtacGridview(DataTable p_DSQtrCtac)
        {
            try
            {
                if (p_DSQtrCtac.Rows.Count > 0)
                {
                    dtg_DSQtrCtac.DataSource = p_DSQtrCtac;
                    
                    EditDtgInterface();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy quá trình công tác cho nhân viên được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtg_DSQtrCtac.DataSource = null;
                    dtg_DSQtrCtac.Rows.Clear();
                    //dtg_DSQtrCtac.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btn_Nhap_Click(object sender, EventArgs e)
        {
            if (CheckInputData())
            {
                try
                {
                    oKiemNhiem = new Business.HDQD.KiemNhiem();
                    oKiemNhiem.MaQuyetDinh = thongTinQuyetDinh1.txt_MaQD.Text.Trim();
                    oKiemNhiem.Ten = thongTinQuyetDinh1.txt_TenQD.Text.Trim();
                    oKiemNhiem.LoaiQuyetDinh = Convert.ToInt32(thongTinQuyetDinh1.comB_Loai.SelectedValue.ToString());
                    oKiemNhiem.NgayKy = thongTinQuyetDinh1.dTP_NgayKy.Value;
                    oKiemNhiem.NgayHieuLucQD = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;
                    if (thongTinQuyetDinh1.dTP_NgayHetHan.Checked)
                        oKiemNhiem.NgayHetHanQD = thongTinQuyetDinh1.dTP_NgayHetHan.Value;
                    else
                        oKiemNhiem.NgayHetHanQD = null;
                    oKiemNhiem.MoTa = thongTinQuyetDinh1.rTB_MoTa.Text.Trim();
                    oKiemNhiem.Path = null;

                    #region Dieu Dong Cong Tac
                    List<int> qtr_ctac_id = new List<int>();
                    List<string> ma_nv = new List<string>();
                    List<int> don_vi_id = new List<int>();
                    List<int> chuc_vu_id = new List<int>();
                    List<int> chuc_danh_id = new List<int>();
                    List<DateTime> tu_ngay = new List<DateTime>();
                    List<DateTime> den_ngay = new List<DateTime>();

                    foreach (DataRow dr in dtDSDieuDong.Rows)
                    {
                        qtr_ctac_id.Add(Convert.ToInt32(dr["qtr_ctac_id"].ToString()));
                        ma_nv.Add(dr["ma_nv"].ToString());
                        don_vi_id.Add(Convert.ToInt32(dr["don_vi_id"].ToString()));
                        chuc_vu_id.Add(Convert.ToInt32(dr["chuc_vu_id"].ToString()));
                        chuc_danh_id.Add(Convert.ToInt32(dr["chuc_danh_id"].ToString()));

                        tu_ngay.Add(Convert.ToDateTime(dr["tu_ngay"].ToString()).Date);

                        if (dr["den_ngay"].ToString() == "")
                            den_ngay.Add(Convert.ToDateTime("01/01/1901").Date);
                        else
                            den_ngay.Add(Convert.ToDateTime(dr["den_ngay"].ToString()).Date);
                    }

                    #endregion

                    if (MessageBox.Show("Bạn thực sự muốn thêm quyết định điều động cho (các) nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (oKiemNhiem.AddDieuDong(qtr_ctac_id.ToArray(), ma_nv.ToArray(), don_vi_id.ToArray(), chuc_vu_id.ToArray(), chuc_danh_id.ToArray(), tu_ngay.ToArray(), den_ngay.ToArray()))
                        {
                            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //ResetInterface();
                        }
                        else
                            MessageBox.Show("Thao tác thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #region Private methods
        private bool CheckInputData()
        {
            if (!String.IsNullOrEmpty(thongTinQuyetDinh1.txt_MaQD.Text))
                return true;
            else
                return false;
        }
        private void PrepareSourceLoaiQuyetDinh()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("loai_quyet_dinh_id", typeof(int));
            dt.Columns.Add("ten_loai_quyet_dinh", typeof(string));

            //dt.Rows.Add(new object[2] { 1, "Bổ nhiệm" });
            //dt.Rows.Add(new object[2] { 2, "Kiêm nhiệm" });
            dt.Rows.Add(new object[2] { 3, "Điều động" });

            thongTinQuyetDinh1.comB_Loai.DataSource = dt;
            thongTinQuyetDinh1.comB_Loai.DisplayMember = "ten_loai_quyet_dinh";
            thongTinQuyetDinh1.comB_Loai.ValueMember = "loai_quyet_dinh_id";
        }

        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtg_DSQtrCtac.Columns["ma_hd_display"].HeaderText = "Mã hợp đồng";
            dtg_DSQtrCtac.Columns["ma_qd_display"].HeaderText = "Mã quyết định";
            dtg_DSQtrCtac.Columns["don_vi"].HeaderText = "Đơn vị";
            dtg_DSQtrCtac.Columns["don_vi"].Width = 200;
            dtg_DSQtrCtac.Columns["chuc_danh"].HeaderText = "Chức danh";
            dtg_DSQtrCtac.Columns["chuc_vu"].HeaderText = "Chức vụ";
            dtg_DSQtrCtac.Columns["tu_thoi_gian"].HeaderText = "Từ ngày";
            dtg_DSQtrCtac.Columns["den_thoi_gian"].HeaderText = "Đến ngày";
            dtg_DSQtrCtac.Columns["tinh_trang"].HeaderText = "Tình trạng";

            // An dtgv_DSLoaiQD ID
            dtg_DSQtrCtac.Columns["id"].Visible = false;
            dtg_DSQtrCtac.Columns["ma_hop_dong"].Visible = false;
            dtg_DSQtrCtac.Columns["ma_quyet_dinh"].Visible = false;
            dtg_DSQtrCtac.Columns["ma_nv"].Visible = false;
            dtg_DSQtrCtac.Columns["don_vi_id"].Visible = false;
            dtg_DSQtrCtac.Columns["chuc_danh_id"].Visible = false;
            dtg_DSQtrCtac.Columns["chuc_vu_id"].Visible = false;
        }

        private void PrepareDataTableDSDieuDong()
        {
            dtDSDieuDong = new DataTable();
            row_count_dd = 0;
            dtDSDieuDong.Columns.Add("qtr_ctac_id", typeof(int));
            dtDSDieuDong.Columns.Add("ma_nv", typeof(string));
            dtDSDieuDong.Columns.Add("ho_ten", typeof(string));
            dtDSDieuDong.Columns.Add("don_vi_id", typeof(int));
            dtDSDieuDong.Columns.Add("don_vi", typeof(string));
            dtDSDieuDong.Columns.Add("chuc_vu_id", typeof(int));
            dtDSDieuDong.Columns.Add("chuc_vu", typeof(string));
            dtDSDieuDong.Columns.Add("chuc_danh_id", typeof(int));
            dtDSDieuDong.Columns.Add("chuc_danh", typeof(string));
            dtDSDieuDong.Columns.Add("tu_ngay", typeof(DateTime));
            dtDSDieuDong.Columns.Add("den_ngay", typeof(DateTime));
        }

        private void PrepareDTGVSource(DataTable dt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dtgv_DS.DataSource = bs;
            EditDtgInterface_DSDieuDong();
        }

        private void EditDtgInterface_DSDieuDong()
        {
            // Dat ten cho cac cot
            dtgv_DS.Columns["ma_nv"].HeaderText = "Mã nhân viên";
            dtgv_DS.Columns["ho_ten"].HeaderText = "Họ tên";
            dtgv_DS.Columns["don_vi"].HeaderText = "Đơn vị";
            dtgv_DS.Columns["chuc_danh"].HeaderText = "Chức danh";
            dtgv_DS.Columns["chuc_vu"].HeaderText = "Chức vụ";
            dtgv_DS.Columns["tu_ngay"].HeaderText = "Từ ngày";
            dtgv_DS.Columns["den_ngay"].HeaderText = "Đến ngày";

            // An cac cot ID
            dtgv_DS.Columns["qtr_ctac_id"].Visible = false;
            dtgv_DS.Columns["don_vi_id"].Visible = false;
            dtgv_DS.Columns["chuc_danh_id"].Visible = false;
            dtgv_DS.Columns["chuc_vu_id"].Visible = false;
        }

        private void PreapreDataSource()
        {
            try
            {
                comB_ChucDanh.DataSource = oChucDanh.GetList();
                comB_ChucDanh.DisplayMember = "ten_chuc_danh";
                comB_ChucDanh.ValueMember = "id";

                comB_ChucVu.DataSource = oChucVu.GetList();
                comB_ChucVu.DisplayMember = "ten_chuc_vu";
                comB_ChucVu.ValueMember = "id";

                comB_DonVi.DataSource = oDonVi.GetActiveDonVi();
                comB_DonVi.DisplayMember = "ten_don_vi";
                comB_DonVi.ValueMember = "id";

            }
            catch (Exception)
            {

            }

        }

        #endregion

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                //string tmp = dtg_DSQtrCtac.SelectedRows[0].Cells["id"].ToString();

                oQtrCTacOU.ID = Convert.ToInt32(dtg_DSQtrCtac.SelectedRows[0].Cells["id"].Value.ToString());
                if (oQtrCTacOU.CheckLatestQtrCtac() == true)
                {
                    DataRow dr = dtDSDieuDong.NewRow();
                    dr["qtr_ctac_id"] = Convert.ToInt32(dtg_DSQtrCtac.SelectedRows[0].Cells["id"].Value.ToString());
                    dr["ma_nv"] = dtg_DSQtrCtac.CurrentRow.Cells["ma_nv"].Value.ToString();
                    dr["ho_ten"] = thongTinCNVC1.txt_Ho.Text.Trim() + " " + thongTinCNVC1.txt_Ten.Text.Trim();
                    dr["don_vi_id"] = Convert.ToInt32(comB_DonVi.SelectedValue.ToString());
                    dr["don_vi"] = comB_DonVi.Text;
                    if (comB_ChucDanh.Text != "")
                    {
                        dr["chuc_danh_id"] = Convert.ToInt16(comB_ChucDanh.SelectedValue);
                        dr["chuc_danh"] = comB_ChucDanh.Text;
                    }
                    else
                    {
                        dr["chuc_danh_id"] = -1;
                        dr["chuc_danh"] = "";
                    }

                    if (comB_ChucVu.Text != "")
                    {
                        dr["chuc_vu_id"] = Convert.ToInt16(comB_ChucVu.SelectedValue);
                        dr["chuc_vu"] = comB_ChucVu.Text;
                    }
                    else
                    {
                        dr["chuc_vu_id"] = -1;
                        dr["chuc_vu"] = "";
                    }

                    dr["tu_ngay"] = dtp_TuNgayDD.Value;
                    if (dtp_DenNgayDD.Checked == true)
                        dr["den_ngay"] = dtp_DenNgayDD.Value;
                    else
                        dr["den_ngay"] = DBNull.Value;

                    dtDSDieuDong.Rows.Add(dr);
                    row_count_dd++;

                    PrepareDTGVSource(dtDSDieuDong);
                }
                else
                    MessageBox.Show("Không thể thực hiện quyết định điều động trên quá trình công tác này của nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            try
            {
                int select_row = Convert.ToInt16(dtgv_DS.CurrentRow.Cells["qtr_ctac_id"].Value.ToString());
                DataRow[] drr = dtDSDieuDong.Select("qtr_ctac_id=" + select_row);
                foreach (DataRow row in drr)
                    row.Delete();

                dtDSDieuDong.AcceptChanges();
                PrepareDTGVSource(dtDSDieuDong);
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn dòng dữ liệu cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region Code cũ
        /*
        private bool CompareCNVCInfo()
        {
            
            if (strLoaiQD != "Bổ nhiệm" && (thongTinCNVC1.comB_ChucVu.SelectedValue.ToString() == thongTinBoNhiem1.comB_ChucVu.SelectedValue.ToString())
                    && (thongTinCNVC1.comB_DonVi.SelectedValue.ToString() == thongTinBoNhiem1.comB_DonVi.SelectedValue.ToString()))
            {
                return false;
            }
            return (!(strMaNVOld != thongTinCNVC1.txt_MaNV.Text));
             
            return true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(thongTinCNVC1.txt_MaNV.Text) && CompareCNVCInfo())
            {
                UInt32 a;
                if (thongTinBoNhiem1.cb_CoPhuCap.Checked ||
                    (!string.IsNullOrWhiteSpace(thongTinBoNhiem1.txt_PhuCap.Text) && (thongTinBoNhiem1.comB_HeSoTienMat.Text == "Tiền mặt" && UInt32.TryParse(thongTinBoNhiem1.txt_PhuCap.Text.Trim(), out a))
                        || (thongTinBoNhiem1.comB_HeSoTienMat.Text == "Hệ số")))
                {
                    int new_index = dtgv_DS.Rows.Add(1);

                    dtgv_DS.Rows[new_index].Cells["ma_nv"].Value = thongTinCNVC1.txt_MaNV.Text.Trim();
                    dtgv_DS.Rows[new_index].Cells["ho"].Value = thongTinCNVC1.txt_Ho.Text.Trim();
                    dtgv_DS.Rows[new_index].Cells["ten"].Value = thongTinCNVC1.txt_Ten.Text.Trim();
                    dtgv_DS.Rows[new_index].Cells["ten_don_vi"].Value = thongTinBoNhiem1.comB_DonVi.Text;
                    dtgv_DS.Rows[new_index].Cells["ten_chuc_vu"].Value = thongTinBoNhiem1.comB_ChucVu.Text;
                    dtgv_DS.Rows[new_index].Cells["don_vi_id"].Value = thongTinBoNhiem1.comB_DonVi.SelectedValue;
                    dtgv_DS.Rows[new_index].Cells["chuc_vu_id"].Value = thongTinBoNhiem1.comB_ChucVu.SelectedValue;
                    dtgv_DS.Rows[new_index].Cells["chuc_danh_id"].Value = thongTinBoNhiem1.comB_ChucDanh.SelectedValue;




                    if (strLoaiQD == "Điều động")
                    {
                        dtgv_DS.Rows[new_index].Cells["tu_chuc_vu_id"].Value = thongTinCNVC1.comB_ChucVu.SelectedValue;
                        dtgv_DS.Rows[new_index].Cells["tu_don_vi_id"].Value = thongTinCNVC1.comB_DonVi.SelectedValue;
                        dtgv_DS.Rows[new_index].Cells["tu_ten_don_vi"].Value = thongTinCNVC1.comB_DonVi.Text;
                        dtgv_DS.Rows[new_index].Cells["tu_ten_chuc_vu"].Value = thongTinCNVC1.comB_ChucVu.Text;
                    }

                    if (thongTinBoNhiem1.cb_CoPhuCap.Checked)
                    {
                        dtgv_DS.Rows[new_index].Cells["phu_cap"].Value = "KHÔNG";
                        dtgv_DS.Rows[new_index].Cells["ten_loai_phu_cap"].Value = "KHÔNG";
                        dtgv_DS.Rows[new_index].Cells["loai_phu_cap_id"].Value = null;
                        dtgv_DS.Rows[new_index].Cells["ngay_bat_dau"].Value = "KHÔNG";
                        dtgv_DS.Rows[new_index].Cells["ngay_het_han"].Value = "KHÔNG";
                        dtgv_DS.Rows[new_index].Cells["ghi_chu"].Value = "KHÔNG";
                        dtgv_DS.Rows[new_index].Cells["heso_tienmat"].Value = "KHÔNG";
                    }
                    else
                    {
                        dtgv_DS.Rows[new_index].Cells["phu_cap"].Value = thongTinBoNhiem1.txt_PhuCap.Text.Trim();
                        dtgv_DS.Rows[new_index].Cells["ten_loai_phu_cap"].Value = thongTinBoNhiem1.comB_LoaiPhuCap.Text;
                        dtgv_DS.Rows[new_index].Cells["loai_phu_cap_id"].Value = thongTinBoNhiem1.comB_LoaiPhuCap.SelectedValue;
                        dtgv_DS.Rows[new_index].Cells["ngay_bat_dau"].Value = thongTinBoNhiem1.dTP_NgayBatDau.Value.Date;
                        if (thongTinBoNhiem1.dTP_NgayHetHan.Checked)
                            dtgv_DS.Rows[new_index].Cells["ngay_het_han"].Value = thongTinBoNhiem1.dTP_NgayHetHan.Value.Date;
                        else
                            dtgv_DS.Rows[new_index].Cells["ngay_het_han"].Value = "KHÔNG";
                        dtgv_DS.Rows[new_index].Cells["ghi_chu"].Value = thongTinBoNhiem1.rTB_GhiChu.Text;
                        dtgv_DS.Rows[new_index].Cells["heso_tienmat"].Value = thongTinBoNhiem1.comB_HeSoTienMat.Text;
                    }
                }
                else
                {
                    MessageBox.Show("Phụ cấp có giá trị không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Thông tin chưa đầy đủ hoặc không đúng so với kết quả tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {

        }

        private void BoNhiem_Load(object sender, EventArgs e)
        {
            SetupDTGV();
            PrepareSourceLoaiQuyetDinh();
            thongTinBoNhiem1.comB_HeSoTienMat.SelectedIndex = 0;
            thongTinQuyetDinh1.comB_Loai.SelectionChangeCommitted += new EventHandler(comB_Loai_SelectionChangeCommitted);
        }

        void comB_Loai_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (thongTinQuyetDinh1.comB_Loai.Text == "Điều động")
            {
                thongTinCNVC1.comB_ChucVu.Enabled = thongTinCNVC1.comB_DonVi.Enabled = true;
                dtgv_DS.Columns["tu_ten_don_vi"].Visible = dtgv_DS.Columns["tu_ten_chuc_vu"].Visible = true;
                strLoaiQD = "Điều động";

            }
            else
            {
                thongTinCNVC1.comB_ChucVu.Enabled = thongTinCNVC1.comB_DonVi.Enabled = false;
                dtgv_DS.Columns["tu_ten_don_vi"].Visible = dtgv_DS.Columns["tu_ten_chuc_vu"].Visible = false;
                strLoaiQD = "Bổ nhiệm";
                //thongTinCNVC1.comB_ChucVu.Text = thongTinCNVC1.comB_DonVi.Text = "";
            }
        }

        private void SetupDTGV()
        {
            dtgv_DS.Columns.Add("ma_nv", "Mã nhân viên");
            dtgv_DS.Columns.Add("ho", "Họ");
            dtgv_DS.Columns.Add("ten", "Tên");
            dtgv_DS.Columns.Add("don_vi_id", "");
            dtgv_DS.Columns.Add("chuc_vu_id", "");
            dtgv_DS.Columns.Add("chuc_danh_id", "");
            dtgv_DS.Columns.Add("ten_don_vi", "Đơn vị mới");
            dtgv_DS.Columns.Add("ten_chuc_vu", "Chức vụ mới");
            dtgv_DS.Columns.Add("ten_chuc_danh", "Chức danh mới");
            dtgv_DS.Columns.Add("tu_don_vi_id", "");
            dtgv_DS.Columns.Add("tu_chuc_vu_id", "");
            dtgv_DS.Columns.Add("tu_ten_don_vi", "Từ đơn vị");
            dtgv_DS.Columns.Add("tu_ten_chuc_vu", "Từ chức vụ");
            dtgv_DS.Columns.Add("phu_cap", "Phụ cấp");
            dtgv_DS.Columns.Add("loai_phu_cap_id", "");
            dtgv_DS.Columns.Add("ten_loai_phu_cap", "Loại phụ cấp");
            dtgv_DS.Columns.Add("heso_tienmat", "Hệ số / tiền mặt");
            dtgv_DS.Columns.Add("ngay_bat_dau", "Ngày bắt đầu");
            dtgv_DS.Columns.Add("ngay_het_han", "Ngày hết hạn");
            dtgv_DS.Columns.Add("ghi_chu", "Ghi chú");

            dtgv_DS.Columns["don_vi_id"].Visible = dtgv_DS.Columns["chuc_vu_id"].Visible = dtgv_DS.Columns["loai_phu_cap_id"].Visible =
                dtgv_DS.Columns["tu_chuc_vu_id"].Visible = dtgv_DS.Columns["tu_don_vi_id"].Visible =
                dtgv_DS.Columns["tu_ten_don_vi"].Visible = dtgv_DS.Columns["tu_ten_chuc_vu"].Visible = false;   // ban dau se la bo nhiem > o hien thi tu don vi ...

            dtgv_DS.Columns["ma_nv"].Width = 150;
            dtgv_DS.Columns["ho"].Width = 250;
            dtgv_DS.Columns["ten"].Width = 120;
            dtgv_DS.Columns["ten_don_vi"].Width = 300;
            dtgv_DS.Columns["ten_chuc_vu"].Width = 200;
            dtgv_DS.Columns["tu_ten_don_vi"].Width = 300;
            dtgv_DS.Columns["tu_ten_chuc_vu"].Width = 200;
            dtgv_DS.Columns["phu_cap"].Width = 120;
            dtgv_DS.Columns["ten_loai_phu_cap"].Width = 120;
            dtgv_DS.Columns["ngay_bat_dau"].Width = 150;
            dtgv_DS.Columns["ngay_het_han"].Width = 150;
            dtgv_DS.Columns["ghi_chu"].Width = 300;
        }

        private void PrepareSourceLoaiQuyetDinh()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("loai_quyet_dinh_id", typeof(int));
            dt.Columns.Add("ten_loai_quyet_dinh", typeof(string));

            dt.Rows.Add(new object[2] { 1, "Bổ nhiệm" });
            dt.Rows.Add(new object[2] { 2, "Kiêm nhiệm" });
            dt.Rows.Add(new object[2] { 3, "Điều động" });

            thongTinQuyetDinh1.comB_Loai.DataSource = dt;
            thongTinQuyetDinh1.comB_Loai.DisplayMember = "ten_loai_quyet_dinh";
            thongTinQuyetDinh1.comB_Loai.ValueMember = "loai_quyet_dinh_id";
        }

        private void btn_Nhap_Click(object sender, EventArgs e)
        {
            if (dtgv_DS.Rows.Count > 0
                && !string.IsNullOrWhiteSpace(thongTinQuyetDinh1.txt_MaQD.Text)
                && !string.IsNullOrWhiteSpace(thongTinQuyetDinh1.txt_TenQD.Text)
                && ((dtgv_DS.Columns["tu_ten_don_vi"].Visible && strLoaiQD == "Điều động") || (!dtgv_DS.Columns["tu_ten_don_vi"].Visible && strLoaiQD != "Điều động")))
            {

                GetBoNhiemContent();
                bool bUploadInfoSuccess = true;
                try
                {
                    // danh sach nhan vien
                    GetGridViewContent(dtgv_DS);

                    if (strLoaiQD == "Điều động")
                    {
                        GetDieuDongContent();
                        oKiemNhiem.AddDieuDong();
                    }
                    else
                    {
                        oKiemNhiem.AddKiemNhiem();
                    }

                    MessageBox.Show("Thao tác nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ResetInterface();
                    bUploadInfoSuccess = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thao tác nhập không thành công.\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (bUploadInfoSuccess && ThongTinQuyetDinh.Paths != null && ThongTinQuyetDinh.Paths.Count() > 0)
                {
                    UploadFile();
                }

                bUploadInfoSuccess = false;
            }
            else
            {
                MessageBox.Show("Xin vui lòng điền thông tin quyết định và thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UploadFile()
        {

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

                oKiemNhiem.MaNV = new string[RowsCount];
                oKiemNhiem.DenChucVu = new int[RowsCount];
                oKiemNhiem.DenChucDanh = new int[RowsCount];
                oKiemNhiem.DenDonVi = new int[RowsCount];
                oKiemNhiem.LoaiPhuCap = new int[RowsCount];
                oKiemNhiem.PhuCap = new string[RowsCount];
                oKiemNhiem.NgayTaoPC = new DateTime[RowsCount];
                oKiemNhiem.NgayHetHanPC = new DateTime[RowsCount];
                oKiemNhiem.NgayBatDau = new DateTime[RowsCount];
                oKiemNhiem.HeSo_TienMat = new bool[RowsCount];
                oKiemNhiem.GhiChu = new string[RowsCount];

                if (strLoaiQD == "Điều động")
                {
                    oKiemNhiem.TuChucVu = new int[RowsCount];
                    oKiemNhiem.TuDonVi = new int[RowsCount];
                }

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    oKiemNhiem.MaNV[i] = Convert.ToString(dgv.Rows[i].Cells["ma_nv"].Value);
                    oKiemNhiem.DenDonVi[i] = Convert.ToInt32(dgv.Rows[i].Cells["don_vi_id"].Value);
                    oKiemNhiem.DenChucVu[i] = Convert.ToInt32(dgv.Rows[i].Cells["chuc_vu_id"].Value);
                    oKiemNhiem.DenChucDanh[i] = Convert.ToInt32(dgv.Rows[i].Cells["chuc_danh_id"].Value);

                    if (strLoaiQD == "Điều động")
                    {
                        int id = Convert.ToInt32(dgv.Rows[i].Cells["tu_don_vi_id"].Value);
                        if (id != 0)
                        {
                            oKiemNhiem.TuDonVi[i] = id;
                            oKiemNhiem.TuChucVu[i] = Convert.ToInt32(dgv.Rows[i].Cells["tu_chuc_vu_id"].Value);
                        }
                        else        // convert null to int >> 0 => vua dieu dong vua bo nhiem
                        {
                            //throw new Exception();
                        }

                    }

                    if (dgv.Rows[i].Cells["loai_phu_cap_id"].Value == null) // khi truyen loai phu cap = -1 
                    // => sto se khong insert phu cap vao db
                    // => cac field khac truyen whatever
                    {
                        oKiemNhiem.LoaiPhuCap[i] = -1;
                        oKiemNhiem.PhuCap[i] = null;
                        oKiemNhiem.NgayTaoPC[i] = oKiemNhiem.NgayBatDau[i] = oKiemNhiem.NgayHetHanPC[i] = DateTime.MinValue;
                        oKiemNhiem.HeSo_TienMat[i] = true;
                        oKiemNhiem.GhiChu[i] = null;
                    }
                    else
                    {
                        oKiemNhiem.LoaiPhuCap[i] = Convert.ToInt32(dgv.Rows[i].Cells["loai_phu_cap_id"].Value);
                        oKiemNhiem.PhuCap[i] = Convert.ToString(dgv.Rows[i].Cells["phu_cap"].Value);
                        oKiemNhiem.NgayBatDau[i] = Convert.ToDateTime(dgv.Rows[i].Cells["ngay_bat_dau"].Value);
                        oKiemNhiem.NgayTaoPC[i] = DateTime.Now;
                        string s = dgv.Rows[i].Cells["ngay_het_han"].Value.ToString();
                        if (s == "KHÔNG")
                            oKiemNhiem.NgayHetHanPC[i] = DateTime.MinValue; // 1/1/0001 12:00:00 AM 
                        else
                            oKiemNhiem.NgayHetHanPC[i] = Convert.ToDateTime(dgv.Rows[i].Cells["ngay_het_han"].Value);

                        oKiemNhiem.HeSo_TienMat[i] = Convert.ToString(dgv.Rows[i].Cells["heso_tienmat"].Value) == "Hệ số" ? true : false;
                        oKiemNhiem.GhiChu[i] = Convert.ToString(dgv.Rows[i].Cells["ghi_chu"].Value);
                    }
                }
            }
            catch { throw new Exception("Danh sách nhân viên có dữ liệu không hợp lệ hoặc loại quyết định không phù hợp với thông tin cung cấp."); }
        }

        /// <summary>
        /// lay thong tin cua quyet dinh bo nhiem tren giao dien
        /// </summary>
        private void GetBoNhiemContent()
        {
            oKiemNhiem.MaQuyetDinh = thongTinQuyetDinh1.txt_MaQD.Text.Trim();
            oKiemNhiem.Ten = thongTinQuyetDinh1.txt_TenQD.Text.Trim();
            oKiemNhiem.LoaiQuyetDinh = Convert.ToInt16(thongTinQuyetDinh1.comB_Loai.SelectedValue);
            oKiemNhiem.NgayHieuLucQD = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;
            if (thongTinQuyetDinh1.dTP_NgayHetHan.Checked)
                oKiemNhiem.NgayHetHanQD = thongTinQuyetDinh1.dTP_NgayHetHan.Value;
            else
                oKiemNhiem.NgayHetHanQD = null;

            oKiemNhiem.NgayTaoQD = thongTinQuyetDinh1.dTP_NgayKy.Value;
            oKiemNhiem.MoTa = thongTinQuyetDinh1.rTB_MoTa.Text;
        }

        private void GetDieuDongContent()
        {
            //oKiemNhiem.TuChucVu = 
        }

        private void ResetInterface()
        {
            thongTinCNVC1.txt_Ten.Text = thongTinCNVC1.txt_MaNV.Text = thongTinCNVC1.txt_Ho.Text = "";
            thongTinBoNhiem1.txt_PhuCap.Text = thongTinBoNhiem1.rTB_GhiChu.Text = "";
            thongTinBoNhiem1.cb_CoPhuCap.Checked = false;
            thongTinQuyetDinh1.txt_MaQD.Text
                = thongTinQuyetDinh1.txt_TenQD.Text = thongTinQuyetDinh1.rTB_MoTa.Text = "";

            dtgv_DS.Rows.Clear();
        }
        */
        #endregion

    }
}
