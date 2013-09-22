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
    public partial class QDDungHopDong : UserControl
    {
        public static string strMaNV, strHo, strTen = "";
        public static string strMaHD_Display, strMaHD = "";
        public static string strLoaiHD, strNgayKy, strNgayHieuLuc, strNgayHetHan = "";
        public static string strDonVi, strChucDanh, strChucVu = "";

        Business.HDQD.QuyetDinh oQuyetDinh;
        Business.HDQD.CNVC_HopDong oHopDong;
        DataTable dtDSHopDong;
        
        public QDDungHopDong()
        {
            InitializeComponent();
            oHopDong = new Business.HDQD.CNVC_HopDong();
            oQuyetDinh = new Business.HDQD.QuyetDinh();
            dtDSHopDong = new DataTable();

            thongTinQuyetDinh1.dTP_NgayHetHan.Visible = false;
            thongTinQuyetDinh1.label7.Visible = false;

            #region Xử lý dữ liệu cho cbo Loại Quyết Định
            DataTable dt = new DataTable();
            dt.Columns.Add("loai_quyet_dinh_id", typeof(int));
            dt.Columns.Add("ten_loai_quyet_dinh", typeof(string));

            dt.Rows.Add(new object[2] { 14, "Thôi việc" });

            thongTinQuyetDinh1.comB_Loai.DataSource = dt;
            thongTinQuyetDinh1.comB_Loai.DisplayMember = "ten_loai_quyet_dinh";
            thongTinQuyetDinh1.comB_Loai.ValueMember = "loai_quyet_dinh_id";
            #endregion
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string ma_nv = txt_MaNV.Text == "" ? null : txt_MaNV.Text;
            string ma_hd = txt_MaHD.Text == "" ? null : txt_MaHD.Text;
            string ho_nv = txt_Ho.Text == "" ? null : txt_Ho.Text;
            string ten_nv = txt_Ten.Text == "" ? null : txt_Ten.Text;

            try
            {
                dtDSHopDong = oHopDong.Search_Dung_HD(ma_hd, ma_nv, ho_nv, ten_nv);
                if (dtDSHopDong != null)
                {
                    UCs.DSCNVC.eParentUC = DSCNVC.ParentUC.DungHopDong;
                    Forms.Popup frPopup = new Forms.Popup(new UCs.DSCNVC(dtDSHopDong), "QUẢN LÝ NHÂN SỰ - DANH SÁCH CNVC");
                    frPopup.ShowDialog();

                    if (strMaNV != null || strMaNV != "")
                    {
                        txt_MaHD.Text = txt_MaHD_2.Text = strMaHD_Display;
                        txt_MaNV.Text = txt_MaNV_2.Text = strMaNV;
                        txt_Ho.Text = strHo;
                        txt_Ten.Text = strTen;
                        txt_LoaiHD.Text = strLoaiHD;
                        txt_NgayKy.Text = strNgayKy;
                        txt_TuNgay.Text = strNgayHieuLuc;
                        txt_DenNgay.Text = strNgayHetHan;
                        txt_HoTenNV.Text = (strHo + " " + strTen).Trim();
                        txt_DonVi.Text = strDonVi;
                        txt_ChucDanh.Text = strChucDanh;
                        txt_ChucVu.Text = strChucVu;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên/hợp đồng phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (CheckInputData())
            {
                #region Quyet Dinh Info
                oQuyetDinh.Ma_Quyet_Dinh = thongTinQuyetDinh1.txt_MaQD.Text;
                oQuyetDinh.Ten_Quyet_Dinh = thongTinQuyetDinh1.txt_TenQD.Text;
                try
                {
                    oQuyetDinh.Loai_QuyetDinh_ID = Convert.ToInt32(thongTinQuyetDinh1.comB_Loai.SelectedValue.ToString());
                }
                catch
                {
                    oQuyetDinh.Loai_QuyetDinh_ID = null;
                }

                //oQuyetDinh.Loai_QuyetDinh_ID = 7;
                oQuyetDinh.Ngay_Ky = thongTinQuyetDinh1.dTP_NgayKy.Value;
                oQuyetDinh.Ngay_Hieu_Luc = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;
                oQuyetDinh.Ngay_Het_Han = null;
                oQuyetDinh.MoTa = thongTinQuyetDinh1.rTB_MoTa.Text;
                #endregion

                try
                {
                    if (MessageBox.Show("Bạn thực sự muốn nhập quyết định thôi việc cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (oQuyetDinh.Update_CNVC_DungHopDong(strMaNV, strMaHD))
                        {
                            MessageBox.Show("Nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Thao tác nhập thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Thao tác nhập thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #region Private Methods
        private bool CheckInputData()
        {
            if (thongTinQuyetDinh1.txt_MaQD.Text != "" && strMaHD != "" && strMaNV != "")
                return true;
            else
                return false;
        }
        #endregion
    }
}
