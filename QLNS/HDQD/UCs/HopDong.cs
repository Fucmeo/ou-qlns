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
    public partial class HopDong : UserControl
    {
        Business.HDQD.CNVC_HopDong oHopdong;
        Business.HDQD.LoaiHopDong oLoaihopdong;
        Business.ChucDanh oChucdanh;
        Business.ChucVu oChucvu;
        Business.DonVi oDonvi;
        Business.CNVC.CNVC cnvc;

        public HopDong()
        {
            InitializeComponent();
            oHopdong = new Business.HDQD.CNVC_HopDong();
            oLoaihopdong = new Business.HDQD.LoaiHopDong();
            oChucdanh = new ChucDanh();
            oChucvu = new ChucVu();
            oDonvi = new DonVi();
        }

        public HopDong(Business.HDQD.CNVC_HopDong p_HopDong)
        {
            InitializeComponent();
            oHopdong = new Business.HDQD.CNVC_HopDong();
            oLoaihopdong = new Business.HDQD.LoaiHopDong();
            oChucdanh = new ChucDanh();
            oChucvu = new ChucVu();
            oDonvi = new DonVi();

            oHopdong = p_HopDong;
            DisplayInfo();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (CheckInputData())
            {
                oHopdong.Ma_NV = thongTinCNVC1.txt_MaNV.Text;

                oHopdong.Ma_Hop_Dong = txt_MaHD.Text;
                oHopdong.Ma_Loai_HD = Convert.ToInt16(comB_LoaiHD.SelectedValue);
                if (comB_ThuViecChinhThuc.Text == "Thử việc")
                    oHopdong.ThuViec_ChinhThuc = false;
                else if (comB_ThuViecChinhThuc.Text == "Chính thức")
                    oHopdong.ThuViec_ChinhThuc = true;

                if (dTP_NgayKy.Checked == true)
                    oHopdong.Ngay_Ky = dTP_NgayKy.Value;
                else
                    oHopdong.Ngay_Ky = null;

                if (dtp_TuNgay.Checked == true)
                    oHopdong.Ngay_Hieu_Luc = dtp_TuNgay.Value;
                else
                    oHopdong.Ngay_Hieu_Luc = null;

                if (dtp_DenNgay.Checked == true)
                    oHopdong.Ngay_Het_Han = dtp_DenNgay.Value;
                else
                    oHopdong.Ngay_Het_Han = null;

                oHopdong.Don_Vi_ID = Convert.ToInt16(comB_DonVi.SelectedValue);
                oHopdong.Chuc_Danh_ID = Convert.ToInt16(comB_ChucDanh.SelectedValue);
                oHopdong.Chuc_Vu_ID = Convert.ToInt16(comB_ChucVu.SelectedValue);
                oHopdong.Ghi_Chu = rTB_GhiChu.Text;

                try
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm hợp đồng cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (oHopdong.Add())
                        {
                            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetInterface();
                        }
                        else
                            MessageBox.Show("Thao tác thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thao tác thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void HopDong_Load(object sender, EventArgs e)
        {
            PreapreDataSource();
        }

        #region Private Methods
        
        private bool CheckInputData()
        {
            if (thongTinCNVC1.txt_MaNV.Text != "" && txt_MaHD.Text != "" && dtp_TuNgay.Checked == true)
                return true;
            else
                return false;
        }
        private void ResetInterface()
        {
            thongTinCNVC1.txt_MaNV.Text = "";
            thongTinCNVC1.txt_Ho.Text = thongTinCNVC1.txt_Ten.Text = thongTinCNVC1.comB_ChucVu.Text = thongTinCNVC1.comB_DonVi.Text = "";
            
            txt_MaHD.Text = txt_NgachBac.Text = txt_HeSoLuong.Text = txt_PhanTram.Text = rTB_GhiChu.Text = "";
            dtp_DenNgay.Checked = dTP_NgayKy.Checked = dtp_TuNgay.Checked = false;
        }

        private void PreapreDataSource()
        {
            comB_LoaiHD.DataSource = oLoaihopdong.GetList_Compact();
            comB_LoaiHD.DisplayMember = "loai_hop_dong";
            comB_LoaiHD.ValueMember = "id";

            comB_ChucDanh.DataSource = oChucdanh.GetList();
            comB_ChucDanh.DisplayMember = "ten_chuc_danh";
            comB_ChucDanh.ValueMember = "id";

            comB_ChucVu.DataSource = oChucvu.GetList();
            comB_ChucVu.DisplayMember = "ten_chuc_vu";
            comB_ChucVu.ValueMember = "id";

            comB_DonVi.DataSource = oDonvi.GetDonViList();
            comB_DonVi.DisplayMember = "ten_don_vi";
            comB_DonVi.ValueMember = "id";
        }

        private void DisplayInfo()
        {
            thongTinCNVC1.txt_MaNV.Text = oHopdong.Ma_NV;
            // thông tin Họ tên NV.
            cnvc = new Business.CNVC.CNVC();
            cnvc.MaNV = oHopdong.Ma_NV;
            DataTable dtHoTenNV = cnvc.Search_Ho_Ten();
            thongTinCNVC1.txt_Ho.Text = dtHoTenNV.Rows[0]["ho"].ToString();
            thongTinCNVC1.txt_Ten.Text = dtHoTenNV.Rows[0]["ten"].ToString();

            txt_MaHD.Text = oHopdong.Ma_Hop_Dong;
            rTB_GhiChu.Text = oHopdong.Ghi_Chu;

            if (oHopdong.Ngay_Ky != null)
            {
                dTP_NgayKy.Checked = true;
                dTP_NgayKy.Value = oHopdong.Ngay_Ky.Value;
            }
            if (oHopdong.Ngay_Hieu_Luc != null)
            {
                dtp_TuNgay.Checked = true;
                dtp_TuNgay.Value = oHopdong.Ngay_Hieu_Luc.Value;
            }
            if (oHopdong.Ngay_Het_Han != null)
            {
                dtp_DenNgay.Checked = true;
                dtp_DenNgay.Value = oHopdong.Ngay_Het_Han.Value;
            }

            //Xử lý combo box
        }
        #endregion

        private void txt_MaHD_TextChanged(object sender, EventArgs e)
        {
            if (txt_MaHD.TextLength > 0)
                btn_Them.Enabled = true;
            else
                btn_Them.Enabled = false;
        }

        private void comB_LoaiHD_DropDownClosed(object sender, EventArgs e)
        {
            //if (!comB_LoaiHD.Items.Contains(oHopdong.Loai_Hop_Dong))
            //{
            //    comB_LoaiHD.Items.Remove(oHopdong.Loai_Hop_Dong);
            //}
        }
    }
}
