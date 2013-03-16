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
        DataTable dtTTTuyenDung;

        Business.CNVC.CNVC_HopDong oHopDong;
        DataTable dtHopDong;

        string m_ma_nv = null;

        public QLNS_HopDongTuyenDung()
        {
            InitializeComponent();
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
            LoadHopDongTuyenDung();
            LoadCNVC_HopDong();
        }

        #region Thông tin tuyển dụng
        private void LoadHopDongTuyenDung()
        {
            oTTTuyenDung.MaNV = m_ma_nv;
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
            dtgv_HopDong.DataSource = null;
        }
        #endregion

        #region Hợp đồng
        private void LoadCNVC_HopDong()
        {
            oHopDong.MaNV = m_ma_nv;
            dtHopDong = oHopDong.GetData();

            if ((dtTTTuyenDung) != null && dtTTTuyenDung.Rows.Count > 0)
            {
                PrepareDataSource();
                EditDtgInterface();
            }
        }

        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtHopDong;
            dtgv_HopDong.DataSource = bs;
            //lbl_SoLoaiHD.Text = dtgv_DSLoaiHD.Rows.Count.ToString();
            if (dtHopDong != null)
            {
                //lbl_Sua.Visible = lbl_Xoa.Visible = true;
            }
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

    }
}
