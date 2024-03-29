﻿using System;
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

        Business.HDQD.CNVC_HopDong oHopDong;
        public DataTable dtHopDong;

        //string m_ma_nv = null;

        public QLNS_HopDongTuyenDung()
        {
            InitializeComponent();
            oTTTuyenDung = new Business.CNVC.CNVC_ThongTinTuyenDung();
            oHopDong = new Business.HDQD.CNVC_HopDong();
            dtTTTuyenDung = new DataTable();
            dtHopDong = new DataTable();
        }

        //public QLNS_HopDongTuyenDung(string p_ma_nv)
        //{
        //    InitializeComponent();
        //    oTTTuyenDung = new Business.CNVC.CNVC_ThongTinTuyenDung();
        //    oHopDong = new Business.CNVC.CNVC_HopDong();
        //    m_ma_nv = p_ma_nv;

        //}

        private void QLNS_HopDongTuyenDung_Load(object sender, EventArgs e)
        {
            //LoadHopDongTuyenDung();
            //LoadCNVC_HopDong();
        }

        #region Thông tin tuyển dụng
        public void LoadHopDongTuyenDung(string p_ma_nv)
        {
            GetHopDongTuyenDung(p_ma_nv);
            if ((dtTTTuyenDung) != null && dtTTTuyenDung.Rows.Count > 0)
            {
                FillTTTuyenDung();
            }
            else
            {
                EmptyHopDongTTContent();
            }
        }

        private void GetHopDongTuyenDung(string p_ma_nv)
        {
            oTTTuyenDung.MaNV = p_ma_nv;
            dtTTTuyenDung = oTTTuyenDung.GetData();
        }

        private void FillTTTuyenDung()
        {
            if (dtTTTuyenDung.Rows.Count > 0)
            {
                txt_NgheNghiep.Text = dtTTTuyenDung.Rows[0]["nghe_nghiep_trc_day"].ToString();
                txt_CoQuan.Text = dtTTTuyenDung.Rows[0]["co_quan_tuyen_dung"].ToString();
                string dt = dtTTTuyenDung.Rows[0]["ngay_tuyen_dung"].ToString();
                if (!string.IsNullOrWhiteSpace(dt))
                    dTP_NgayTuyenDung.Value = Convert.ToDateTime(dt);
                else
                    dTP_NgayTuyenDung.Checked = false;
            
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
            //oHopDong.MaNV = p_ma_nv;
            dtHopDong = oHopDong.Search_HD(p_ma_nv, null, null, null, null, null, null, null);

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
            #region Old
            //dtgv_HopDong.Columns["ma_hop_dong"].HeaderText = "Mã hợp đồng";
            //dtgv_HopDong.Columns["loai_hop_dong"].HeaderText = "Loại hợp đồng";
            //dtgv_HopDong.Columns["co_thoi_han"].HeaderText = "Có thời hạn";
            //dtgv_HopDong.Columns["ngay_ky"].HeaderText = "Ngày ký";
            //dtgv_HopDong.Columns["ngay_hieu_luc"].HeaderText = "Ngày hiệu lực";
            //dtgv_HopDong.Columns["ngay_het_han"].HeaderText = "Ngày hết hạn";
            //dtgv_HopDong.Columns["ten_chuc_vu"].HeaderText = "Tên chức vụ";
            //dtgv_HopDong.Columns["ten_chuc_danh"].HeaderText = "Tên chức danh";
            //dtgv_HopDong.Columns["ten_don_vi"].HeaderText = "Tên đơn vị";
            //dtgv_HopDong.Columns["tinh_trang_txt"].HeaderText = "Tình trạng";
            //dtgv_HopDong.Columns["ghi_chu"].HeaderText = "Ghi chú";

            //dtgv_HopDong.Columns["id"].Visible = false;
            //dtgv_HopDong.Columns["ma_nv"].Visible = false;
            //dtgv_HopDong.Columns["ma_loai_hd"].Visible = false;
            //dtgv_HopDong.Columns["chuc_vu_chinh_id"].Visible = false;
            //dtgv_HopDong.Columns["chuc_danh_chinh_id"].Visible = false;
            //dtgv_HopDong.Columns["don_vi_chinh_id"].Visible = false;
            ////dtgv_HopDong.Columns["thuviec_chinhthuc"].Visible = false;
            //dtgv_HopDong.Columns["tinh_trang"].Visible = false;
            #endregion

            // Dat ten cho cac cot
            dtgv_HopDong.Columns["id"].HeaderText = "ID";
            dtgv_HopDong.Columns["ma_nv"].HeaderText = "Mã nhân viên";
            //dtgv_DSHD.Columns["ma_nv"].Width = 200;
            dtgv_HopDong.Columns["ho"].HeaderText = "Họ nhân viên";
            dtgv_HopDong.Columns["ho"].Width = 200;
            dtgv_HopDong.Columns["ten"].HeaderText = "Tên nhân viên";
            dtgv_HopDong.Columns["ma_hd_display"].HeaderText = "Mã hợp đồng";
            dtgv_HopDong.Columns["ma_hd_display"].Width = 200;
            dtgv_HopDong.Columns["ma_loai_hd"].HeaderText = "Mã loại Hợp đồng";
            dtgv_HopDong.Columns["loai_hop_dong"].HeaderText = "Loại hợp đồng";
            dtgv_HopDong.Columns["loai_hop_dong"].Width = 200;
            dtgv_HopDong.Columns["co_thoi_han"].HeaderText = "Có thời hạn";
            dtgv_HopDong.Columns["co_thoi_han"].Width = 100;
            dtgv_HopDong.Columns["ngay_ky"].HeaderText = "Ngày ký";
            dtgv_HopDong.Columns["ngay_ky"].Width = 100;
            dtgv_HopDong.Columns["ngay_hieu_luc"].HeaderText = "Ngày hiệu lực";
            dtgv_HopDong.Columns["ngay_hieu_luc"].Width = 100;
            dtgv_HopDong.Columns["ngay_het_han"].HeaderText = "Ngày hết hạn";
            dtgv_HopDong.Columns["ngay_het_han"].Width = 100;
            dtgv_HopDong.Columns["chuc_vu_chinh_id"].HeaderText = "Chức vụ ID";
            dtgv_HopDong.Columns["ten_chuc_vu"].HeaderText = "Tên chức vụ";
            dtgv_HopDong.Columns["ten_chuc_vu"].Width = 100;
            dtgv_HopDong.Columns["chuc_danh_chinh_id"].HeaderText = "Chức danh ID";
            dtgv_HopDong.Columns["ten_chuc_danh"].HeaderText = "Tên chức danh";
            dtgv_HopDong.Columns["ten_chuc_danh"].Width = 100;
            dtgv_HopDong.Columns["don_vi_chinh_id"].HeaderText = "Đơn vị ID";
            dtgv_HopDong.Columns["ten_don_vi"].HeaderText = "Tên đơn vị";
            dtgv_HopDong.Columns["ten_don_vi"].Width = 100;
            dtgv_HopDong.Columns["tinh_trang"].HeaderText = "Tình trạng";
            dtgv_HopDong.Columns["tinh_trang"].Width = 100;
            dtgv_HopDong.Columns["ghi_chu"].HeaderText = "Ghi chú";
            //dtgv_DSHD.Columns[17].HeaderText = "Ngày hết hạn ADJ";
            // An cot ID
            dtgv_HopDong.Columns["id"].Visible = false;
            dtgv_HopDong.Columns["ma_loai_hd"].Visible = false;
            dtgv_HopDong.Columns["chuc_vu_chinh_id"].Visible = false;
            dtgv_HopDong.Columns["chuc_danh_chinh_id"].Visible = false;
            dtgv_HopDong.Columns["don_vi_chinh_id"].Visible = false;
            dtgv_HopDong.Columns["ghi_chu"].Visible = false;
            //dtgv_DSHD.Columns[17].Visible = false;
            dtgv_HopDong.Columns["khoan_or_heso"].Visible = false;
            dtgv_HopDong.Columns["luong_khoan"].Visible = false;
            dtgv_HopDong.Columns["ngach_bac_heso_id"].Visible = false;
            dtgv_HopDong.Columns["phan_tram_huong"].Visible = false;
            dtgv_HopDong.Columns["tham_nien_nang_bac"].Visible = false;
            dtgv_HopDong.Columns["tham_nien_gd"].Visible = false;
            dtgv_HopDong.Columns["co_phu_cap"].Visible = false;
            dtgv_HopDong.Columns["ma_hop_dong"].Visible = false;
            dtgv_HopDong.Columns["dong_bao_hiem"].Visible = false;
        }
        
        #endregion

        private void dtgv_HopDong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_HopDong.CurrentRow != null)
            {
                #region Old
                /*
                DataGridViewRow row = dtgv_HopDong.CurrentRow;
                Business.HDQD.CNVC_HopDong m_oHopDong = new Business.HDQD.CNVC_HopDong();
                m_oHopDong.ID = Convert.ToInt16(row.Cells["id"].Value.ToString());
                m_oHopDong.Ma_NV = row.Cells["ma_nv"].Value.ToString();
                m_oHopDong.Ma_Hop_Dong = row.Cells["ma_hop_dong"].Value.ToString();
                m_oHopDong.Ma_Loai_HD = Convert.ToInt16(row.Cells["ma_loai_hd"].Value.ToString());
                m_oHopDong.Loai_Hop_Dong = row.Cells["loai_hop_dong"].Value.ToString();
                m_oHopDong.Co_Thoi_Han = Convert.ToBoolean(row.Cells["co_thoi_han"].Value.ToString());
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
                popup.Show();*/
                #endregion
               

                DataGridViewRow row = dtgv_HopDong.CurrentRow;
                oHopDong = new Business.HDQD.CNVC_HopDong();
                oHopDong.ID = Convert.ToInt16(row.Cells["id"].Value.ToString());
                oHopDong.Ma_NV = row.Cells["ma_nv"].Value.ToString();
                oHopDong.Ma_Tuyen_Dung = row.Cells["ma_hop_dong"].Value.ToString();
                oHopDong.La_QD_Tiep_Nhan = false;
                oHopDong.Ma_Loai_HD = Convert.ToInt16(row.Cells["ma_loai_hd"].Value.ToString());
                oHopDong.Loai_Hop_Dong = row.Cells["loai_hop_dong"].Value.ToString();
                oHopDong.Co_Thoi_Han = Convert.ToBoolean(row.Cells["co_thoi_han"].Value.ToString());
                if (row.Cells["ngay_ky"].Value.ToString() != "")
                    oHopDong.Ngay_Ky = Convert.ToDateTime(row.Cells["ngay_ky"].Value.ToString());
                if (row.Cells["ngay_hieu_luc"].Value.ToString() != "")
                    oHopDong.Ngay_Hieu_Luc = Convert.ToDateTime(row.Cells["ngay_hieu_luc"].Value.ToString());
                if (row.Cells["ngay_het_han"].Value.ToString() != "")
                    oHopDong.Ngay_Het_Han = Convert.ToDateTime(row.Cells["ngay_het_han"].Value.ToString());
                if (row.Cells["chuc_vu_chinh_id"].Value.ToString() != "")
                    oHopDong.Chuc_Vu_ID = Convert.ToInt16(row.Cells["chuc_vu_chinh_id"].Value.ToString());
                oHopDong.Chuc_Vu = row.Cells["ten_chuc_vu"].Value.ToString();

                if (row.Cells["chuc_danh_chinh_id"].Value.ToString() != "")
                    oHopDong.Chuc_Danh_ID = Convert.ToInt16(row.Cells["chuc_danh_chinh_id"].Value.ToString());
                oHopDong.Chuc_Danh = row.Cells["ten_chuc_danh"].Value.ToString();

                if (row.Cells["don_vi_chinh_id"].Value.ToString() != "")
                    oHopDong.Don_Vi_ID = Convert.ToInt16(row.Cells["don_vi_chinh_id"].Value.ToString());
                oHopDong.Don_Vi = row.Cells["ten_don_vi"].Value.ToString();
                oHopDong.Tinh_Trang = Convert.ToBoolean(row.Cells["tinh_trang"].Value.ToString());
                oHopDong.Ghi_Chu = row.Cells["ghi_chu"].Value.ToString();

                if (row.Cells["tham_nien_nang_bac"].Value.ToString() != "")
                    oHopDong.Tham_nien_nang_bac = Convert.ToBoolean(row.Cells["tham_nien_nang_bac"].Value.ToString());
                else
                    oHopDong.Tham_nien_nang_bac = false;
                if (row.Cells["tham_nien_gd"].Value.ToString() != "")
                    oHopDong.Tham_nien_nha_giao = Convert.ToBoolean(row.Cells["tham_nien_gd"].Value.ToString());
                else
                    oHopDong.Tham_nien_nha_giao = false;

                if (row.Cells["dong_bao_hiem"].Value.ToString() != "")
                    oHopDong.Dong_bao_hiem = Convert.ToBoolean(row.Cells["dong_bao_hiem"].Value.ToString());
                else
                    oHopDong.Dong_bao_hiem = false;

                #region Luong Info
                oHopDong.Khoan_or_HeSo = Convert.ToBoolean(row.Cells["tinh_trang"].Value.ToString());
                if (row.Cells["luong_khoan"].Value.ToString() != "")
                    oHopDong.Luong_Khoan = Convert.ToDouble(row.Cells["luong_khoan"].Value.ToString());
                if (row.Cells["ngach_bac_heso_id"].Value.ToString() != "")
                    oHopDong.BacHeSo_ID = Convert.ToInt16(row.Cells["ngach_bac_heso_id"].Value.ToString());
                if (row.Cells["phan_tram_huong"].Value.ToString() != "")
                    oHopDong.PhanTramHuong = Convert.ToDouble(row.Cells["phan_tram_huong"].Value.ToString());
                #endregion

                oHopDong.Co_Phu_Cap = Convert.ToBoolean(row.Cells["co_phu_cap"].Value.ToString());

                HDQD.UCs.HopDong hopdong = new HDQD.UCs.HopDong(oHopDong); 
                Forms.Popup popup = new Forms.Popup("QUẢN LÝ NHÂN SỰ - HỢP ĐỒNG", hopdong);
                popup.Show();
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (btn_Luu.ImageKey == "Edit Data.png")
            {
                EnableControls(true);
            }
            else
            {
                if (Program.selected_ma_nv != "")
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
                                EnableControls(false);
                                GetHopDongTuyenDung(Program.selected_ma_nv);
                            }
                            else
                                MessageBox.Show("Thao tác lưu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thao tác lưu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            
        }

        private void EnableControls(bool bEnable)
        {
            txt_CoQuan.Enabled = txt_NgheNghiep.Enabled = dTP_NgayTuyenDung.Enabled = bEnable;
            btn_Huy.Visible = bEnable;
            if (bEnable)
            {
                btn_Luu.ImageKey = "Save.png";
            }
            else
            {
                btn_Luu.ImageKey = "Edit Data.png";
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            FillTTTuyenDung();
        }

    }
}
