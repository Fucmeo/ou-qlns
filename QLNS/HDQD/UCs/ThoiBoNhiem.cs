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
    public partial class ThoiBoNhiem : UserControl
    {
        DonVi oDonVi;
        ChucVu oChucVu;
        Business.HDQD.ThoiNhiem oThoiNhiem;
        public static string strMaNVOld, strHoOld, strTenOld; // gia tri ho ten luc moi tim, dung de so sanh khi nhap phong TH ng dung sua thong tin sau khi tim duoc cnvc
        // se duoc gan khi double click nv o gridview ds
        public ThoiBoNhiem()
        {
            InitializeComponent();
            oDonVi = new DonVi();
            oChucVu = new ChucVu();
            oThoiNhiem = new Business.HDQD.ThoiNhiem();
        }

        private void PrepareSourceLoaiQuyetDinh()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("loai_quyet_dinh_id", typeof(int));
            dt.Columns.Add("ten_loai_quyet_dinh", typeof(string));

            dt.Rows.Add(new object[2] { 1, "Thôi bổ nhiệm" });
            dt.Rows.Add(new object[2] { 2, "Thôi kiêm nhiệm" });

            thongTinQuyetDinh1.comB_Loai.DataSource = dt;
            thongTinQuyetDinh1.comB_Loai.DisplayMember = "ten_loai_quyet_dinh";
            thongTinQuyetDinh1.comB_Loai.ValueMember = "loai_quyet_dinh_id";

            thongTinQuyetDinh1.comB_Loai.SelectedIndex = 0;
        }

        private void thongTinQuyetDinh1_Load(object sender, EventArgs e)
        {
            thongTinCNVC1.comB_ChucVu.Enabled = thongTinCNVC1.comB_DonVi.Enabled = true;
            PrepareSourceLoaiQuyetDinh();
            SetupDTGV();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(thongTinCNVC1.txt_MaNV.Text) && CompareCNVCInfo())
            {

                    int new_index = dtgv_DS.Rows.Add(1);

                    dtgv_DS.Rows[new_index].Cells["ma_nv"].Value = thongTinCNVC1.txt_MaNV.Text.Trim();
                    dtgv_DS.Rows[new_index].Cells["ho"].Value = thongTinCNVC1.txt_Ho.Text.Trim();
                    dtgv_DS.Rows[new_index].Cells["ten"].Value = thongTinCNVC1.txt_Ten.Text.Trim();
                    dtgv_DS.Rows[new_index].Cells["ten_don_vi"].Value = thongTinCNVC1.comB_DonVi.Text;
                    dtgv_DS.Rows[new_index].Cells["ten_chuc_vu"].Value = thongTinCNVC1.comB_ChucVu.Text;
                    dtgv_DS.Rows[new_index].Cells["don_vi_id"].Value = thongTinCNVC1.comB_DonVi.SelectedValue;
                    dtgv_DS.Rows[new_index].Cells["chuc_vu_id"].Value = thongTinCNVC1.comB_ChucVu.SelectedValue;
            }
            else
            {
                MessageBox.Show("Thông tin chưa đầy đủ hoặc không đúng so với kết quả tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool CompareCNVCInfo()
        {
            return (!(strMaNVOld != thongTinCNVC1.txt_MaNV.Text || strHoOld != thongTinCNVC1.txt_Ho.Text || strTenOld != thongTinCNVC1.txt_Ten.Text));
        }

        private void SetupDTGV()
        {
            dtgv_DS.Columns.Add("ma_nv", "Mã nhân viên");
            dtgv_DS.Columns.Add("ho", "Họ");
            dtgv_DS.Columns.Add("ten", "Tên");
            dtgv_DS.Columns.Add("don_vi_id", "");
            dtgv_DS.Columns.Add("chuc_vu_id", "");
            dtgv_DS.Columns.Add("ten_don_vi", "Đơn vị");
            dtgv_DS.Columns.Add("ten_chuc_vu", "Chức vụ");
           
            dtgv_DS.Columns["don_vi_id"].Visible = dtgv_DS.Columns["chuc_vu_id"].Visible = false; 

            dtgv_DS.Columns["ma_nv"].Width = 150;
            dtgv_DS.Columns["ho"].Width = 250;
            dtgv_DS.Columns["ten"].Width = 120;
            dtgv_DS.Columns["ten_don_vi"].Width = 300;
            dtgv_DS.Columns["ten_chuc_vu"].Width = 200;
        }

        private void btn_Nhap_Click(object sender, EventArgs e)
        {
            if (dtgv_DS.Rows.Count > 0
                && !string.IsNullOrWhiteSpace(thongTinQuyetDinh1.txt_MaQD.Text)
                && !string.IsNullOrWhiteSpace(thongTinQuyetDinh1.txt_TenQD.Text))
            {

                GetThoiNhiemContent();
                // danh sach nhan vien
                GetGridViewContent(dtgv_DS);
                try
                {

                    oThoiNhiem.AddThoiNhiem();
                    
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

                oThoiNhiem.MaNV = new string[RowsCount];
                oThoiNhiem.ChucVu = new int[RowsCount];
                oThoiNhiem.DonVi = new int[RowsCount];

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    oThoiNhiem.MaNV[i] = Convert.ToString(dgv.Rows[i].Cells["ma_nv"].Value);
                    oThoiNhiem.DonVi[i] = Convert.ToInt32(dgv.Rows[i].Cells["don_vi_id"].Value);
                    oThoiNhiem.ChucVu[i] = Convert.ToInt32(dgv.Rows[i].Cells["chuc_vu_id"].Value);
                }
            }
            catch { throw new Exception("Danh sách nhân viên có dữ liệu không hợp lệ hoặc loại quyết định không phù hợp với thông tin cung cấp."); }
        }

        /// <summary>
        /// lay thong tin cua quyet dinh thoi bo nhiem tren giao dien
        /// </summary>
        private void GetThoiNhiemContent()
        {
            oThoiNhiem.MaQuyetDinh = thongTinQuyetDinh1.txt_MaQD.Text.Trim();
            oThoiNhiem.Ten = thongTinQuyetDinh1.txt_TenQD.Text.Trim();
            oThoiNhiem.LoaiQuyetDinh = Convert.ToInt16(thongTinQuyetDinh1.comB_Loai.SelectedValue);
            oThoiNhiem.NgayHieuLucQD = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;

            oThoiNhiem.NgayTaoQD = thongTinQuyetDinh1.dTP_NgayKy.Value;
            oThoiNhiem.MoTa = thongTinQuyetDinh1.rTB_MoTa.Text;
        }

        private void ResetInterface()
        {
            thongTinCNVC1.txt_Ten.Text = thongTinCNVC1.txt_MaNV.Text = thongTinCNVC1.txt_Ho.Text = "";

            thongTinQuyetDinh1.txt_MaQD.Text
                = thongTinQuyetDinh1.txt_TenQD.Text = thongTinQuyetDinh1.rTB_MoTa.Text = "";

            dtgv_DS.Rows.Clear();
        }
    }
}
