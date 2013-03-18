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
    public partial class QLNS_ChinhTri : UserControl
    {
        Business.CNVC.CNVC_ChinhTri oChinhTri;
        DataTable dtChinhTri;

        string m_ma_nv;

        public QLNS_ChinhTri()
        {
            InitializeComponent();
        }

        public QLNS_ChinhTri(string p_ma_nv)
        {
            InitializeComponent();

            oChinhTri = new Business.CNVC.CNVC_ChinhTri();

            m_ma_nv = p_ma_nv;
        }

        private void QLNS_ChinhTri_Load(object sender, EventArgs e)
        {
            Load_Chinh_Tri();
        }

        #region Private Methods
        private void Load_Chinh_Tri()
        {
            oChinhTri.Ma_NV = m_ma_nv;
            dtChinhTri = oChinhTri.GetData();

            if (dtChinhTri != null && dtChinhTri.Rows.Count > 0)
            {
                txt_QuanHam.Text = dtChinhTri.Rows[0]["quan_ham_cao_nhat"].ToString();
                txt_DanhHieu.Text = dtChinhTri.Rows[0]["danh_hieu_cao_nhat"].ToString();
                txt_ThuongBinh.Text = dtChinhTri.Rows[0]["thuong_binh_hang"].ToString();
                txt_GiaDinh.Text = dtChinhTri.Rows[0]["gia_dinh_chinh_sach"].ToString();
                txt_LyLuanChinhTri.Text = dtChinhTri.Rows[0]["ly_luan_chinh_tri"].ToString();
                txt_QuanLyNhaNuoc.Text = dtChinhTri.Rows[0]["quan_ly_nha_nuoc"].ToString();
                rtb_KhenThuong.Text = dtChinhTri.Rows[0]["khen_thuong"].ToString();
                rTB_KyLuat.Text = dtChinhTri.Rows[0]["ky_luat"].ToString();

                if (dtChinhTri.Rows[0]["ngay_nhap_ngu"].ToString() != "")
                {
                    dtp_NgayNhapNgu.Checked = true;
                    dtp_NgayNhapNgu.Value = Convert.ToDateTime(dtChinhTri.Rows[0]["ngay_nhap_ngu"].ToString());
                }
                else
                    dtp_NgayNhapNgu.Checked = false;

                if (dtChinhTri.Rows[0]["ngay_xuat_ngu"].ToString() != "")
                {
                    dtp_NgayXuatNgu.Checked = true;
                    dtp_NgayXuatNgu.Value = Convert.ToDateTime(dtChinhTri.Rows[0]["ngay_xuat_ngu"].ToString());
                }
                else
                    dtp_NgayXuatNgu.Checked = false;

            }
        
        }
        #endregion

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            oChinhTri = new Business.CNVC.CNVC_ChinhTri();
            oChinhTri.Ma_NV = m_ma_nv;
            oChinhTri.Quan_Ham_Cao_Nhat = txt_QuanHam.Text;
            oChinhTri.Danh_Hieu_Cao_Nhat = txt_DanhHieu.Text;
            oChinhTri.Thuong_Binh_Hang = txt_ThuongBinh.Text;
            oChinhTri.Gia_Dinh_Chinh_Sach = txt_GiaDinh.Text;
            oChinhTri.Ly_Luan_Chinh_Tri = txt_LyLuanChinhTri.Text;
            oChinhTri.Quan_Ly_Nha_Nuoc = txt_QuanLyNhaNuoc.Text;
            oChinhTri.Khen_Thuong = rtb_KhenThuong.Text;
            oChinhTri.Ky_Luat = rTB_KyLuat.Text;
            if (dtp_NgayNhapNgu.Checked == true)
                oChinhTri.Ngay_Nhap_Ngu = dtp_NgayNhapNgu.Value;
            if (dtp_NgayXuatNgu.Checked == true)
                oChinhTri.Ngay_Xuat_Ngu = dtp_NgayXuatNgu.Value;

            try
            {
                if (MessageBox.Show("Bạn thực sự muốn lưu thông tin chính trị chung cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oChinhTri.Save())
                    {
                        MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Thao tác lưu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác lưu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
