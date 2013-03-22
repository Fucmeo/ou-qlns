using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;

namespace QLNS.UCs.DanhMucThongTin
{
    public partial class QLNS_HopDongTuyenDung : UserControl
    {
        Business.CNVC.CNVC_ThongTinTuyenDung oTTTuyenDung;
        public DataTable dtTTTuyenDung;

        Business.CNVC.CNVC_HopDong oHopDong;
        public DataTable dtHopDong;

        string m_ma_nv = null;

        public QLNS_HopDongTuyenDung()
        {
            InitializeComponent();
            oTTTuyenDung = new Business.CNVC.CNVC_ThongTinTuyenDung();
            oHopDong = new Business.CNVC.CNVC_HopDong();
            dtTTTuyenDung = new DataTable();
            dtHopDong = new DataTable();
        }

        public QLNS_HopDongTuyenDung(string p_ma_nv)
        {
            InitializeComponent();
            oTTTuyenDung = new Business.CNVC.CNVC_ThongTinTuyenDung();
            oHopDong = new Business.CNVC.CNVC_HopDong();
            m_ma_nv = p_ma_nv;

        }

        private void QLNS_HopDongTuyenDung_Load(object sender, EventArgs e)
        {
            //LoadHopDongTuyenDung();
            //LoadCNVC_HopDong();
        }

        #region Thông tin tuyển dụng
        public void LoadHopDongTuyenDung(string p_ma_nv)
        {
            oTTTuyenDung.MaNV = p_ma_nv;
            dtTTTuyenDung = oTTTuyenDung.GetData();
            if ((dtTTTuyenDung) != null && dtTTTuyenDung.Rows.Count > 0)
            {
                txt_NgheNghiep.Text = dtTTTuyenDung.Rows[0]["nghe_nghiep_trc_day"].ToString();
                txt_CoQuan.Text = dtTTTuyenDung.Rows[0]["co_quan_tuyen_dung"].ToString();
                string dt = dtTTTuyenDung.Rows[0]["ngay_tuyen_dung"].ToString();
                if (!string.IsNullOrWhiteSpace(dt))
                    dTP_NgayTuyenDung.Value = Convert.ToDateTime(dt);
                else
                    dTP_NgayTuyenDung.Checked = false;
            }
            else
            {
                EmptyHopDongTTContent();
            }
        }

        public void EmptyHopDongTTContent()
        {

            dTP_NgayTuyenDung.Checked = false;
            txt_NgheNghiep.Text = "";
            txt_CoQuan.Text = "";
            //dtgv_HopDong.DataSource = null;
        }
        #endregion

        #region Hợp đồng
        public void LoadCNVC_HopDong(string p_ma_nv)
        {
            oHopDong.MaNV = p_ma_nv;
            dtHopDong = oHopDong.GetData();

            if ((dtHopDong) != null && dtHopDong.Rows.Count > 0)
            {
                PrepareDataSource();
                EditDtgInterface();
            }
        }

        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            DataTable dt = dtHopDong.Copy();
            bs.DataSource = dt;
            dtgv_HopDong.DataSource = bs;
            //lbl_SoLoaiHD.Text = dtgv_DSLoaiHD.Rows.Count.ToString();

        }

        private void EditDtgInterface()
        {
            dtgv_HopDong.Columns["ma_hop_dong"].HeaderText = "Mã hợp đồng";
            dtgv_HopDong.Columns["loai_hop_dong"].HeaderText = "Loại hợp đồng";
            dtgv_HopDong.Columns["thuviec_chinhthuc_txt"].HeaderText = "Thử việc/Chính thức";
            dtgv_HopDong.Columns["ngay_ky"].HeaderText = "Ngày ký";
            dtgv_HopDong.Columns["ngay_hieu_luc"].HeaderText = "Ngày hiệu lực";
            dtgv_HopDong.Columns["ngay_het_han"].HeaderText = "Ngày hết hạn";
            dtgv_HopDong.Columns["ten_chuc_vu"].HeaderText = "Tên chức vụ";
            dtgv_HopDong.Columns["ten_chuc_danh"].HeaderText = "Tên chức danh";
            dtgv_HopDong.Columns["ten_don_vi"].HeaderText = "Tên đơn vị";
            dtgv_HopDong.Columns["tinh_trang_txt"].HeaderText = "Tình trạng";
            dtgv_HopDong.Columns["ghi_chu"].HeaderText = "Ghi chú";

            dtgv_HopDong.Columns["id"].Visible = false;
            dtgv_HopDong.Columns["ma_nv"].Visible = false;
            dtgv_HopDong.Columns["ma_loai_hd"].Visible = false;
            dtgv_HopDong.Columns["chuc_vu_chinh_id"].Visible = false;
            dtgv_HopDong.Columns["chuc_danh_chinh_id"].Visible = false;
            dtgv_HopDong.Columns["don_vi_chinh_id"].Visible = false;
            dtgv_HopDong.Columns["thuviec_chinhthuc"].Visible = false;
            dtgv_HopDong.Columns["tinh_trang"].Visible = false;
        }
        
        #endregion

        private void dtgv_HopDong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_HopDong.CurrentRow != null)
            {
                DataGridViewRow row = dtgv_HopDong.CurrentRow;
                Business.HDQD.CNVC_HopDong m_oHopDong = new Business.HDQD.CNVC_HopDong();
                m_oHopDong.ID = Convert.ToInt16(row.Cells["id"].Value.ToString());
                m_oHopDong.Ma_NV = row.Cells["ma_nv"].Value.ToString();
                m_oHopDong.Ma_Hop_Dong = row.Cells["ma_hop_dong"].Value.ToString();
                m_oHopDong.Ma_Loai_HD = Convert.ToInt16(row.Cells["ma_loai_hd"].Value.ToString());
                m_oHopDong.Loai_Hop_Dong = row.Cells["loai_hop_dong"].Value.ToString();
                m_oHopDong.ThuViec_ChinhThuc = Convert.ToBoolean(row.Cells["thuviec_chinhthuc"].Value.ToString());
                if (row.Cells["ngay_ky"].Value.ToString() != "")
                    m_oHopDong.Ngay_Ky = Convert.ToDateTime(row.Cells["ngay_ky"].Value.ToString());
                if (row.Cells["ngay_hieu_luc"].Value.ToString() != "")
                    m_oHopDong.Ngay_Hieu_Luc = Convert.ToDateTime(row.Cells["ngay_hieu_luc"].Value.ToString());
                if (row.Cells["ngay_het_han"].Value.ToString() != "")
                    m_oHopDong.Ngay_Het_Han = Convert.ToDateTime(row.Cells["ngay_het_han"].Value.ToString());
                if (row.Cells["chuc_vu_chinh_id"].Value.ToString() != "")
                    m_oHopDong.Chuc_Vu_ID = Convert.ToInt16(row.Cells["chuc_vu_chinh_id"].Value.ToString());
                m_oHopDong.Chuc_Vu = row.Cells["ten_chuc_vu"].Value.ToString();
                if (row.Cells["chuc_danh_chinh_id"].Value.ToString() != "")
                    m_oHopDong.Chuc_Danh_ID = Convert.ToInt16(row.Cells["chuc_danh_chinh_id"].Value.ToString());
                m_oHopDong.Chuc_Danh = row.Cells["ten_chuc_danh"].Value.ToString();
                if (row.Cells["don_vi_chinh_id"].Value.ToString() != "")
                    m_oHopDong.Don_Vi_ID = Convert.ToInt16(row.Cells["don_vi_chinh_id"].Value.ToString());
                m_oHopDong.Don_Vi = row.Cells["ten_don_vi"].Value.ToString();
                m_oHopDong.Tinh_Trang = Convert.ToBoolean(row.Cells["tinh_trang"].Value.ToString());
                m_oHopDong.Ghi_Chu = row.Cells["ghi_chu"].Value.ToString();

                HDQD.UCs.HopDong hopdong = new HDQD.UCs.HopDong(m_oHopDong);
                //UCs.HopDong hopdong = new HopDong(oHopDong);
                Forms.Popup popup = new Forms.Popup("QUẢN LÝ NHÂN SỰ - HỢP ĐỒNG", hopdong);
                popup.Show();
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            oTTTuyenDung.MaNV = Program.selected_ma_nv;
            oTTTuyenDung.NgheNghiepTruocDay = txt_NgheNghiep.Text;
            oTTTuyenDung.CoQuanTuyenDung = txt_CoQuan.Text;
            if (dTP_NgayTuyenDung.Checked == true)
                oTTTuyenDung.NgayTuyenDung = dTP_NgayTuyenDung.Value;

            try
            {
                if (MessageBox.Show("Bạn thực sự muốn lưu thông tin tuyển dụng cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oTTTuyenDung.Update())
                    {
                        MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Thao tác lưu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Thao tác lưu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
