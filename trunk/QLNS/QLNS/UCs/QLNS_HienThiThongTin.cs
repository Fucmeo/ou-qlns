using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace QLNS.UCs
{
    public partial class QLNS_HienThiThongTin : UserControl
    {
        #region global variables

        public static bool bAddFlag = false;

        QLNS_DanhMucThongTin qlnS_DanhMucThongTin1;
        QLNS_DonVi_CNVC qlnS_DonVi_CNVC1;
        public static string ma_nv_old ="";   // giu lai ma_nv cu khi nguoi dung sua ma_nv, se duoc gan moi khi load 1 nv ( o UC_DanhMucThongTin)

        const string strImagePath = "D:\\avatar\\";  // noi chua hinh

        #endregion

        public QLNS_HienThiThongTin()
        {
            InitializeComponent();
        }

        private void QLNS_HienThiThongTin_Load(object sender, EventArgs e)
        {
            qlnS_DanhMucThongTin1 = new QLNS_DanhMucThongTin();
            qlnS_DanhMucThongTin1.Dock = DockStyle.Fill;
            qlnS_DonVi_CNVC1 = new QLNS_DonVi_CNVC(ref qlnS_DanhMucThongTin1);
            qlnS_DonVi_CNVC1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(qlnS_DonVi_CNVC1, 0,0);
            this.tableLayoutPanel1.Controls.Add(qlnS_DanhMucThongTin1,1, 1);
            this.tableLayoutPanel1.SetRowSpan(qlnS_DonVi_CNVC1, 2);
        }

        #region xu ly buttons

        private void btn_Them_Click(object sender, EventArgs e)
        {
            //if (qlnS_DonVi_CNVC1.nSelectedDVID != 0)
            //{
                ResetInterface(false);
                bAddFlag = true;
                if (!string.IsNullOrWhiteSpace(qlnS_DanhMucThongTin1.txt_MaNV.Text))   // neu da chon CNVC moi empty content
                {
                    EmptyAllContent();
                }
                else        // khong thi chi can set up cac dtgv
                {
                    qlnS_DanhMucThongTin1.LoadComboThongTinBoSung();
                    qlnS_DanhMucThongTin1.LoadComboDaoTaoBD();
                    Setup_dtgv_CMNDHoChieu();
                    Setup_dtgv_NgoaiGD();
                    Setup_dtgv_TrongGD();
                    Setup_dtgv_DaoTaoBoiDuong();
                    Setup_dtgv_QuanHeGiaDinh();
                    Setup_dtgv_TrinhDoPhoThong();
                    //Setup_dtgv_DHMo();
                }
            //}
            //else
            //{
            //    MessageBox.Show("Xin vui lòng chọn đơn vị trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            #region THEM
                        
            if (bAddFlag)
            {
                if (!string.IsNullOrWhiteSpace(qlnS_DanhMucThongTin1.txt_MaNV.Text))
                {
                    try
                    {
                        ThemThongTin();
                        ThemThongTinBoSung();
                        ThemQTCT();
                        ThemHopDongTT();
                        ThemDaoTaoBD();
                        ThemThongTinGD();
                        ThemChinhTri();
                        ThemAvatar();
                        MessageBox.Show("Thao tác thêm thành công.\r\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshTreeVCNVC();
                        EmptyAllContent();
                        ResetInterface(true);
                        bAddFlag = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thao tác thêm không thành công.\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        qlnS_DanhMucThongTin1.oCNVC.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
                        qlnS_DanhMucThongTin1.oCNVC.Delete();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Xin vui lòng điền mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            #endregion

            #region SUA

            else
            {
                if (!string.IsNullOrWhiteSpace(qlnS_DanhMucThongTin1.txt_MaNV.Text))
                {
                    if (MessageBox.Show("Bạn muốn lưu các thông tin này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            SuaThongTin();
                            SuaThongTinBoSung();
                            SuaQTCT();
                            SuaHopDongTT();
                            SuaDaoTaoBD();
                            SuaThongTinGD();
                            SuaChinhTri();

                            MessageBox.Show("Thao tác sửa thành công.\r\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            EmptyAllContent();
                            ResetInterface(true);
                            RefreshTreeVCNVC(); // phong truong hop user sua ho ten
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Thao tác sửa không thành công.\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Xin vui lòng điền mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            #endregion
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            bAddFlag = false;
            ResetInterface(true);
            EmptyAllContent();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (qlnS_DonVi_CNVC1.TreeV_CNVC.SelectedNode != null)
            {
                if (MessageBox.Show("Mọi thông tin về người này sẽ bị xoá bỏ, bạn có chắc chắn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        qlnS_DanhMucThongTin1.oCNVC.MaNV = qlnS_DonVi_CNVC1.TreeV_CNVC.SelectedNode.Name;
                        qlnS_DanhMucThongTin1.oCNVC.Delete();
                        MessageBox.Show("Thao tác xoá thành công.\r\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetInterface(true);
                        RefreshTreeVCNVC();
                        EmptyAllContent();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thao tác xoá không thành công.\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn nhân viên.\r\n" , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                    

            
        }

        #endregion

        #region HAM PHU

        /// <summary>
        /// dieu chinh giao dien sau khi thuc hien 1 thao tac
        /// </summary>
        /// <param name="bShow">SHOW / ADD</param>
        private void ResetInterface(bool bShow)
        {
            if (bShow)
            {
                btn_Huy.Visible = qlnS_DanhMucThongTin1.btn_DelAvatar.Enabled = false;
                btn_Xoa.Visible = btn_Them.Visible = btn_Xoa.Enabled =
                    qlnS_DonVi_CNVC1.Enabled = true;
                qlnS_DanhMucThongTin1.tableLP_ThongTinChinh.Enabled =
                qlnS_DanhMucThongTin1.tableLP_ThongTinBoSung.Enabled =
                qlnS_DanhMucThongTin1.tableLP_QuaTrinhCongTac.Enabled =
                qlnS_DanhMucThongTin1.tableLP_HopDong_TuyenDung.Enabled =
                qlnS_DanhMucThongTin1.tableLP_DaoTaoBoiDuong.Enabled =
                qlnS_DanhMucThongTin1.tableLP_GiaDinh_BanThan.Enabled =
                qlnS_DanhMucThongTin1.tableLP_ChinhTri.Enabled =
                qlnS_DanhMucThongTin1.tableLP_ThongTinBoSung.Enabled = false;
            }
            else
            {
                btn_Huy.Visible =  qlnS_DanhMucThongTin1.tableLP_ThongTinChinh.Enabled =
                qlnS_DanhMucThongTin1.tableLP_ThongTinBoSung.Enabled =
                qlnS_DanhMucThongTin1.tableLP_QuaTrinhCongTac.Enabled =
                qlnS_DanhMucThongTin1.tableLP_HopDong_TuyenDung.Enabled =
                qlnS_DanhMucThongTin1.tableLP_DaoTaoBoiDuong.Enabled =
                qlnS_DanhMucThongTin1.tableLP_GiaDinh_BanThan.Enabled =
                qlnS_DanhMucThongTin1.tableLP_ChinhTri.Enabled =
                qlnS_DanhMucThongTin1.tableLP_ThongTinBoSung.Enabled = true;
                btn_Xoa.Visible = btn_Them.Visible = qlnS_DonVi_CNVC1.Enabled = false;

                qlnS_DanhMucThongTin1.btn_DelAvatar.Enabled = qlnS_DanhMucThongTin1.picB_HinhDaiDien.Image != null;
            }
        }

        /// <summary>
        /// refresh ds cnvc sau khi them
        /// </summary>
        private void RefreshTreeVCNVC()
        {
            string s = qlnS_DonVi_CNVC1.nSelectedDVID.ToString();
            qlnS_DonVi_CNVC1.RefreshTreeVCNVC(s);
        }

        #region HAM xoa thong tin

        private void EmptyAllContent()
        {
            EmptyThongTinContent();
            EmptyThongTinPhuContent();
            EmptyQTCTContent();
            EmptyHopDongTTContent();
            EmptyDaoTaoBDContent();
            EmptyGiaDinhContent();
            EmptyHoatDongCTContent();
            
        }

        private void EmptyThongTinContent()
        {
            qlnS_DanhMucThongTin1.txt_Ho.Text = qlnS_DanhMucThongTin1.txt_DiaChi.Text = qlnS_DanhMucThongTin1.txt_MaNV.Text =
                qlnS_DanhMucThongTin1.txt_MaSoThue.Text = qlnS_DanhMucThongTin1.txt_SoSoBHXH.Text = qlnS_DanhMucThongTin1.txt_Ten.Text = "";

            qlnS_DanhMucThongTin1.dTP_NgaySinh.Checked = false;
            qlnS_DanhMucThongTin1.comB_GioiTinh.SelectedIndex = 2;
            qlnS_DanhMucThongTin1.dtgv_CMNDHoChieu.DataSource = null;

            qlnS_DanhMucThongTin1.picB_HinhDaiDien.Image = null;

            Setup_dtgv_CMNDHoChieu();
        }

        private void EmptyThongTinPhuContent()
        {
            qlnS_DanhMucThongTin1.txt_TenGoiKhac.Text = qlnS_DanhMucThongTin1.txt_DanToc.Text =
                qlnS_DanhMucThongTin1.txt_TonGiao.Text = qlnS_DanhMucThongTin1.txt_NoiSinhXa.Text =
                qlnS_DanhMucThongTin1.txt_NoiSinhHuyen.Text = qlnS_DanhMucThongTin1.txt_QueXa.Text =
                qlnS_DanhMucThongTin1.txt_QueHuyen.Text = qlnS_DanhMucThongTin1.txt_HoKhau.Text =
                qlnS_DanhMucThongTin1.txt_ChieuCao.Text = qlnS_DanhMucThongTin1.txt_NhomMau.Text = "";

            qlnS_DanhMucThongTin1.comB_NoiSinhTinh.SelectedIndex =
                qlnS_DanhMucThongTin1.comB_QueTinh.SelectedIndex = 
                qlnS_DanhMucThongTin1.comB_TinhTrangHonNhan.SelectedIndex = -1;

           
        }

        private void EmptyQTCTContent()
        {
            qlnS_DanhMucThongTin1.dtgv_NgoaiGD.DataSource = qlnS_DanhMucThongTin1.dtgv_TrongGD.DataSource =
                qlnS_DanhMucThongTin1.dtgv_DHMo.DataSource = null;

            Setup_dtgv_NgoaiGD();
            Setup_dtgv_TrongGD();

        }

        private void EmptyHopDongTTContent()
        {
           
            qlnS_DanhMucThongTin1.dTP_NgayTuyenDung.Checked = false;
            qlnS_DanhMucThongTin1.txt_NgheNghiep.Text = "";
            qlnS_DanhMucThongTin1.txt_CoQuan.Text = "";
            qlnS_DanhMucThongTin1.dtgv_HopDong.DataSource = null;
        }

        private void EmptyDaoTaoBDContent()
        {
            qlnS_DanhMucThongTin1.txt_NgoaiNgu.Text =
                qlnS_DanhMucThongTin1.txt_TinHoc.Text = qlnS_DanhMucThongTin1.txt_SoTruong.Text =
                qlnS_DanhMucThongTin1.txt_TrinhDo.Text = "";

            qlnS_DanhMucThongTin1.dtgv_TrinhDoPhoThong.DataSource = qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.DataSource = null;

            qlnS_DanhMucThongTin1.comB_MoHinhDaoTao.SelectedIndex = -1;

            Setup_dtgv_TrinhDoPhoThong();
            Setup_dtgv_DaoTaoBoiDuong();
        }

        private void EmptyGiaDinhContent()
        {
            qlnS_DanhMucThongTin1.rtb_QuanHeToChuc.Text =
                qlnS_DanhMucThongTin1.rtb_ThanNhan.Text =
                qlnS_DanhMucThongTin1.rtb_ThongTinLichSu.Text = "";

            qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.DataSource = null;

            Setup_dtgv_QuanHeGiaDinh();
        }

        private void EmptyHoatDongCTContent()
        {
            qlnS_DanhMucThongTin1.cb_CongDoan.Checked =
                qlnS_DanhMucThongTin1.cb_DangVien.Checked =
                qlnS_DanhMucThongTin1.cb_DoanVien.Checked =
                qlnS_DanhMucThongTin1.dtp_NgayChinhThuc.Checked =
                qlnS_DanhMucThongTin1.dtp_NgayNhapNgu.Checked =
                qlnS_DanhMucThongTin1.dtp_NgayRaDang.Checked =
                qlnS_DanhMucThongTin1.dtp_NgayRaDoan.Checked =
                qlnS_DanhMucThongTin1.dTP_NgaySinh.Checked =
                qlnS_DanhMucThongTin1.dtp_NgayTaiNapDang.Checked =
                qlnS_DanhMucThongTin1.dtp_NgayTaiNapDoan.Checked =
                qlnS_DanhMucThongTin1.dTP_NgayTuyenDung.Checked =
                qlnS_DanhMucThongTin1.dtp_NgayVaoDang.Checked =
                qlnS_DanhMucThongTin1.dtp_NgayVaoDoan.Checked =
                qlnS_DanhMucThongTin1.dtp_NgayXuatNgu.Checked = false;

            qlnS_DanhMucThongTin1.txt_QuanHam.Text =
                qlnS_DanhMucThongTin1.txt_QuanLyNhaNuoc.Text =
                qlnS_DanhMucThongTin1.txt_DanhHieu.Text =
                qlnS_DanhMucThongTin1.txt_LyLuanChinhTri.Text =
                qlnS_DanhMucThongTin1.txt_ThuongBinh.Text =
                qlnS_DanhMucThongTin1.txt_GiaDinh.Text =
                qlnS_DanhMucThongTin1.rtb_KhenThuong.Text = qlnS_DanhMucThongTin1.rtb_KyLuat.Text = "";
        }


        #endregion

        #region HAM them thong tin

        private void ThemThongTin()
        {
            qlnS_DanhMucThongTin1.oCNVC.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVC.Ho = qlnS_DanhMucThongTin1.txt_Ho.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVC.Ten = qlnS_DanhMucThongTin1.txt_Ten.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVC.DiaChi = qlnS_DanhMucThongTin1.txt_DiaChi.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVC.SoBHXH = qlnS_DanhMucThongTin1.txt_SoSoBHXH.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVC.MaSoThue = qlnS_DanhMucThongTin1.txt_MaSoThue.Text.Trim();

            switch (qlnS_DanhMucThongTin1.comB_GioiTinh.SelectedIndex)
            {
                case 0:
                    qlnS_DanhMucThongTin1.oCNVC.GioiTinh = true;
                    break;

                case 1:
                    qlnS_DanhMucThongTin1.oCNVC.GioiTinh = false;
                    break;
                default:
                    qlnS_DanhMucThongTin1.oCNVC.GioiTinh = null;
                    break;
            }
            if (qlnS_DanhMucThongTin1.dTP_NgaySinh.Checked)
            {
                qlnS_DanhMucThongTin1.oCNVC.NgaySinh = qlnS_DanhMucThongTin1.dTP_NgaySinh.Value;
            }

            qlnS_DanhMucThongTin1.oCNVC.Add();

            qlnS_DanhMucThongTin1.oCMND.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            for (int i = 0; i < qlnS_DanhMucThongTin1.dtgv_CMNDHoChieu.Rows.Count - 1; i++) // bo dong cuoi cung
            {
                DataGridViewRow r = qlnS_DanhMucThongTin1.dtgv_CMNDHoChieu.Rows[i];
                
                qlnS_DanhMucThongTin1.oCMND.CMNDHoChieu = Convert.ToString(r.Cells[0].Value) == "CMND" ? true : false;
                qlnS_DanhMucThongTin1.oCMND.MaSo = Convert.ToString(r.Cells[2].Value);
                string t = Convert.ToString(r.Cells[3].Value);
                if (t != null && t != "")
                {
                    try
                    {
                        qlnS_DanhMucThongTin1.oCMND.NgayCap = Convert.ToDateTime(t);
                    }
                    catch (Exception)
                    {                        
                        throw new Exception("Ngày cấp của CMND/Hộ chiếu có định dạng không đúng");
                    }
                    
                }
                else
                    qlnS_DanhMucThongTin1.oCMND.NgayCap = null;
                qlnS_DanhMucThongTin1.oCMND.NoiCap = Convert.ToString(r.Cells[4].Value);
                qlnS_DanhMucThongTin1.oCMND.IsActive = Convert.ToBoolean(r.Cells[5].Value);

                qlnS_DanhMucThongTin1.oCMND.Add(); 
            }

            //// luồng tạm thời
            //qlnS_DanhMucThongTin1.oQTCT.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            //qlnS_DanhMucThongTin1.oQTCT.DonViID = (qlnS_DonVi_CNVC1.nSelectedDVID);
            //qlnS_DanhMucThongTin1.oQTCT.TinhTrang = true;
            //qlnS_DanhMucThongTin1.oQTCT.Add();
        }

        private void ThemThongTinBoSung()
        {
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.TenGoiKhac = qlnS_DanhMucThongTin1.txt_TenGoiKhac.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.DanToc = qlnS_DanhMucThongTin1.txt_DanToc.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.TonGiao = qlnS_DanhMucThongTin1.txt_TonGiao.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.NoiSinhXa = qlnS_DanhMucThongTin1.txt_NoiSinhXa.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.NoiSinhHuyen = qlnS_DanhMucThongTin1.txt_NoiSinhHuyen.Text.Trim();
            int i = Convert.ToInt16(qlnS_DanhMucThongTin1.comB_NoiSinhTinh.SelectedValue);  // khi null thi convert sang int thanh = 0
            if (i == -1 || i== 0)
                qlnS_DanhMucThongTin1.oCNVCInfoPhu.NoiSinhTinh = null;
            else
                qlnS_DanhMucThongTin1.oCNVCInfoPhu.NoiSinhTinh = i;
            
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.QueQuanXa = qlnS_DanhMucThongTin1.txt_QueXa.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.QueQuanHuyen = qlnS_DanhMucThongTin1.txt_QueHuyen.Text.Trim();
            i = Convert.ToInt16(qlnS_DanhMucThongTin1.comB_QueTinh.SelectedValue);
            if (i == -1 || i == 0)
                qlnS_DanhMucThongTin1.oCNVCInfoPhu.QueQuanTinh = null;
            else
                qlnS_DanhMucThongTin1.oCNVCInfoPhu.QueQuanTinh = i;
            
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.HoKhauThuongTru = qlnS_DanhMucThongTin1.txt_HoKhau.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.ChieuCao = qlnS_DanhMucThongTin1.txt_ChieuCao.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.NhomMau = qlnS_DanhMucThongTin1.txt_NhomMau.Text.Trim();
            i = Convert.ToInt16(qlnS_DanhMucThongTin1.comB_TinhTrangHonNhan.SelectedValue);
            if (i == -1 || i == 0)
                qlnS_DanhMucThongTin1.oCNVCInfoPhu.TinhTrangHonNhan = null;
            else
                qlnS_DanhMucThongTin1.oCNVCInfoPhu.TinhTrangHonNhan = i;

            qlnS_DanhMucThongTin1.oCNVCInfoPhu.Add();

        }

        private void ThemQTCT()
        {
            #region THEM QTCT NGOAI GD

            qlnS_DanhMucThongTin1.oNonOUNonGD.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            for (int i = 0; i < qlnS_DanhMucThongTin1.dtgv_NgoaiGD.Rows.Count - 1; i++) // bo dong cuoi cung
            {
                DataGridViewRow r = qlnS_DanhMucThongTin1.dtgv_NgoaiGD.Rows[i];

                qlnS_DanhMucThongTin1.oNonOUNonGD.TenDonVi = Convert.ToString(r.Cells[1].Value);
                qlnS_DanhMucThongTin1.oNonOUNonGD.ChucDanh = Convert.ToString(r.Cells[2].Value);
                qlnS_DanhMucThongTin1.oNonOUNonGD.ChucVu = Convert.ToString(r.Cells[3].Value);

                string t = Convert.ToString(r.Cells[4].Value);
                if (t != null && t != "")
                {
                    try
                    {
                        qlnS_DanhMucThongTin1.oNonOUNonGD.TuNgay = Convert.ToDateTime(t);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ngày bắt đầu hoạt động ngoài ĐH Mở - ngoài ngành giáo dục có định dạng không đúng");
                    }

                }
                else
                    qlnS_DanhMucThongTin1.oNonOUNonGD.TuNgay = null;

                t = Convert.ToString(r.Cells[4].Value);
                if (t != null && t != "")
                {
                    try
                    {
                        qlnS_DanhMucThongTin1.oNonOUNonGD.DenNgay = Convert.ToDateTime(t);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ngày kết thúc hoạt động ngoài ĐH Mở - ngoài ngành giáo dục có định dạng không đúng");
                    }

                }
                else
                    qlnS_DanhMucThongTin1.oNonOUNonGD.DenNgay = null;

                qlnS_DanhMucThongTin1.oNonOUNonGD.CongViecChinh = Convert.ToString(r.Cells[6].Value);

                qlnS_DanhMucThongTin1.oNonOUNonGD.Add();
            }

            #endregion THEM QTCT NGOAI GD

            #region THEM QTCT TRONG GD

            qlnS_DanhMucThongTin1.oNonOUGD.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            for (int i = 0; i < qlnS_DanhMucThongTin1.dtgv_TrongGD.Rows.Count - 1; i++) // bo dong cuoi cung
            {
                DataGridViewRow r = qlnS_DanhMucThongTin1.dtgv_TrongGD.Rows[i];

                qlnS_DanhMucThongTin1.oNonOUGD.TenDonVi = Convert.ToString(r.Cells[1].Value);
                qlnS_DanhMucThongTin1.oNonOUGD.ChucDanh = Convert.ToString(r.Cells[2].Value);
                qlnS_DanhMucThongTin1.oNonOUGD.ChucVu = Convert.ToString(r.Cells[3].Value);
                string t = Convert.ToString(r.Cells[4].Value);
                if (t != null && t != "")
                {
                    try
                    {
                        qlnS_DanhMucThongTin1.oNonOUGD.TuNgay = Convert.ToDateTime(t);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ngày kết thúc hoạt động ngoài ĐH Mở - trong ngành giáo dục có định dạng không đúng");
                    }

                }
                else
                    qlnS_DanhMucThongTin1.oNonOUGD.TuNgay = null;

                t = Convert.ToString(r.Cells[4].Value);
                if (t != null && t != "")
                {
                    try
                    {
                        qlnS_DanhMucThongTin1.oNonOUGD.DenNgay = Convert.ToDateTime(t);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ngày kết thúc hoạt động ngoài ĐH Mở - trong ngành giáo dục có định dạng không đúng");
                    }

                }
                else
                    qlnS_DanhMucThongTin1.oNonOUGD.DenNgay = null;

                qlnS_DanhMucThongTin1.oNonOUGD.CongViecChinh = Convert.ToString(r.Cells[6].Value);

                qlnS_DanhMucThongTin1.oNonOUGD.Add();
            }

            #endregion THEM QTCT TRONG GD

            //qlnS_DanhMucThongTin1.oQTCT.Add();
        }

        private void ThemHopDongTT()
        {
            qlnS_DanhMucThongTin1.oTTTuyenDung.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oTTTuyenDung.NgheNghiepTruocDay = qlnS_DanhMucThongTin1.txt_NgheNghiep.Text;
            qlnS_DanhMucThongTin1.oTTTuyenDung.CoQuanTuyenDung = qlnS_DanhMucThongTin1.txt_CoQuan.Text;
            if (qlnS_DanhMucThongTin1.dTP_NgayTuyenDung.Checked)
                qlnS_DanhMucThongTin1.oTTTuyenDung.NgayTuyenDung = qlnS_DanhMucThongTin1.dTP_NgayTuyenDung.Value;
            else
                qlnS_DanhMucThongTin1.oTTTuyenDung.NgayTuyenDung = null;

            qlnS_DanhMucThongTin1.oTTTuyenDung.Add();

        }

        private void ThemDaoTaoBD()
        {
            #region CHUYEN MON TONG QUAT

            qlnS_DanhMucThongTin1.oChuyenMonTQ.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oChuyenMonTQ.TinHoc = qlnS_DanhMucThongTin1.txt_TinHoc.Text;
            qlnS_DanhMucThongTin1.oChuyenMonTQ.SoTruongCTac = qlnS_DanhMucThongTin1.txt_SoTruong.Text;
            qlnS_DanhMucThongTin1.oChuyenMonTQ.TrinhDoChuyenMon = qlnS_DanhMucThongTin1.txt_TrinhDo.Text;
            int i = Convert.ToInt16(qlnS_DanhMucThongTin1.comB_MoHinhDaoTao.SelectedValue);
            if (i == -1 || i == 0)
                qlnS_DanhMucThongTin1.oChuyenMonTQ.MoHinhDaoTaoID = null;
            else
                qlnS_DanhMucThongTin1.oChuyenMonTQ.MoHinhDaoTaoID = i;

            qlnS_DanhMucThongTin1.oChuyenMonTQ.Add();

            #endregion

            #region TRINH DO PHO THONG

            qlnS_DanhMucThongTin1.oTrinhDoPT.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();

            for (int y = 0; y < qlnS_DanhMucThongTin1.dtgv_TrinhDoPhoThong.Rows.Count - 1; y++)
            {
                DataGridViewRow dr = qlnS_DanhMucThongTin1.dtgv_TrinhDoPhoThong.Rows[y];
                qlnS_DanhMucThongTin1.oTrinhDoPT.TruongCap1 = Convert.ToString(dr.Cells[0].Value);
                qlnS_DanhMucThongTin1.oTrinhDoPT.TruongCap2 = Convert.ToString(dr.Cells[1].Value);
                qlnS_DanhMucThongTin1.oTrinhDoPT.TruongCap3 = Convert.ToString(dr.Cells[2].Value);

                qlnS_DanhMucThongTin1.oTrinhDoPT.Add();
            }

            #endregion

            #region DAO TAO BOI DUONG

            qlnS_DanhMucThongTin1.oDaoTaoBD.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();

            for (int y = 0; y < qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Rows.Count - 1; y++)
            {
                DataGridViewRow dr = qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Rows[y];
                qlnS_DanhMucThongTin1.oDaoTaoBD.TenTruong = Convert.ToString(dr.Cells[1].Value);
                qlnS_DanhMucThongTin1.oDaoTaoBD.ChuyenNganhDaoTao = Convert.ToString(dr.Cells[2].Value);
                string t = Convert.ToString(dr.Cells[3].Value);
                if (t != null && t != "")
                {
                    try
                    {
                        qlnS_DanhMucThongTin1.oDaoTaoBD.TuNgay = Convert.ToDateTime(t);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ngày bắt đầu đào tạo bồi dưỡng có định dạng không đúng");
                    }

                }
                else
                    qlnS_DanhMucThongTin1.oDaoTaoBD.TuNgay = null;

                t = Convert.ToString(dr.Cells[4].Value);
                if (t != null && t != "")
                {
                    try
                    {
                        qlnS_DanhMucThongTin1.oDaoTaoBD.DenNgay = Convert.ToDateTime(t);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ngày kết thúc đào tạo bồi dưỡng có định dạng không đúng");
                    }

                }
                else
                    qlnS_DanhMucThongTin1.oDaoTaoBD.DenNgay = null;

                qlnS_DanhMucThongTin1.oDaoTaoBD.XepLoai = Convert.ToString(dr.Cells[6].Value);
                qlnS_DanhMucThongTin1.oDaoTaoBD.BD_TenChungChi = Convert.ToString(dr.Cells[7].Value);
                qlnS_DanhMucThongTin1.oDaoTaoBD.CQ_TenLuanVan = Convert.ToString(dr.Cells[9].Value);
                qlnS_DanhMucThongTin1.oDaoTaoBD.CQ_HoiDongCham = Convert.ToString(dr.Cells[10].Value);

                int x = Convert.ToInt16(dr.Cells[11].Value); // khi null thi convert se sang 0
                if (x == -1 || x == 0) 
                    qlnS_DanhMucThongTin1.oDaoTaoBD.HinhThucDaoTaoID = null;
                else
                    qlnS_DanhMucThongTin1.oDaoTaoBD.HinhThucDaoTaoID = x;

                x = Convert.ToInt16(dr.Cells[12].Value);
                if (x == -1 || x == 0)
                    qlnS_DanhMucThongTin1.oDaoTaoBD.CQ_VanBangID = null;
                else
                    qlnS_DanhMucThongTin1.oDaoTaoBD.CQ_VanBangID = x;

                qlnS_DanhMucThongTin1.oDaoTaoBD.Add();
            }

            #endregion


        }

        private void ThemThongTinGD()
        {
            #region QUAN HE GIA DINH

            qlnS_DanhMucThongTin1.oQuanHeGD.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();

            for (int y = 0; y < qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Rows.Count - 1; y++)
            {
                DataGridViewRow dr = qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Rows[y];
                qlnS_DanhMucThongTin1.oQuanHeGD.MoiQuanHe = Convert.ToString(dr.Cells[1].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.Ho = Convert.ToString(dr.Cells[2].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.Ten = Convert.ToString(dr.Cells[3].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.NamSinh = Convert.ToString(dr.Cells[4].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.QueQuan = Convert.ToString(dr.Cells[5].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.NgheNghiep = Convert.ToString(dr.Cells[6].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.ChucDanh = Convert.ToString(dr.Cells[7].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.DVCongTac = Convert.ToString(dr.Cells[8].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.ChucDanh = Convert.ToString(dr.Cells[9].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.DiaChi = Convert.ToString(dr.Cells[10].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.ThanhVienToChucXH = Convert.ToString(dr.Cells[11].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.HocTap = Convert.ToString(dr.Cells[12].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.GhiChu = Convert.ToString(dr.Cells[13].Value);

                qlnS_DanhMucThongTin1.oQuanHeGD.Add();
            }

            #endregion

            #region DAC DIEM BAN THAN

            qlnS_DanhMucThongTin1.oDacDiemBT.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oDacDiemBT.ThongTinLS = qlnS_DanhMucThongTin1.rtb_ThongTinLichSu.Text;
            qlnS_DanhMucThongTin1.oDacDiemBT.ThanNhanNuocNgoai = qlnS_DanhMucThongTin1.rtb_ThanNhan.Text;
            qlnS_DanhMucThongTin1.oDacDiemBT.QHToChucXH = qlnS_DanhMucThongTin1.rtb_QuanHeToChuc.Text;

            qlnS_DanhMucThongTin1.oDacDiemBT.Add();
            #endregion

        }

        private void ThemChinhTri()
        {
            qlnS_DanhMucThongTin1.oChinhTri.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();

            if (qlnS_DanhMucThongTin1.cb_DangVien.Checked)
            {
                qlnS_DanhMucThongTin1.oChinhTri.DangVien = true;
                if (qlnS_DanhMucThongTin1.dtp_NgayChinhThuc.Checked)
                    qlnS_DanhMucThongTin1.oChinhTri.NgayChinhThuc = qlnS_DanhMucThongTin1.dtp_NgayChinhThuc.Value;
                else
                    qlnS_DanhMucThongTin1.oChinhTri.NgayChinhThuc = null;

                if (qlnS_DanhMucThongTin1.dtp_NgayVaoDang.Checked)
                    qlnS_DanhMucThongTin1.oChinhTri.NgayVaoDang = qlnS_DanhMucThongTin1.dtp_NgayVaoDang.Value;
                else
                    qlnS_DanhMucThongTin1.oChinhTri.NgayVaoDang = null;

                if (qlnS_DanhMucThongTin1.dtp_NgayRaDang.Checked)
                    qlnS_DanhMucThongTin1.oChinhTri.NgayRaDang = qlnS_DanhMucThongTin1.dtp_NgayRaDang.Value;
                else
                    qlnS_DanhMucThongTin1.oChinhTri.NgayRaDang = null;

                if (qlnS_DanhMucThongTin1.dtp_NgayTaiNapDang.Checked)
                    qlnS_DanhMucThongTin1.oChinhTri.NgayTaiVaoDang = qlnS_DanhMucThongTin1.dtp_NgayTaiNapDang.Value;
                else
                    qlnS_DanhMucThongTin1.oChinhTri.NgayTaiVaoDang = null;
            }
            else
            {
                qlnS_DanhMucThongTin1.oChinhTri.DangVien = false;
            }

            if (qlnS_DanhMucThongTin1.cb_DoanVien.Checked)
            {
                qlnS_DanhMucThongTin1.oChinhTri.DoanVien = true;
                if (qlnS_DanhMucThongTin1.dtp_NgayVaoDoan.Checked)
                    qlnS_DanhMucThongTin1.oChinhTri.NgayVaoDoan = qlnS_DanhMucThongTin1.dtp_NgayVaoDoan.Value;
                else
                    qlnS_DanhMucThongTin1.oChinhTri.NgayVaoDoan = null;

                if (qlnS_DanhMucThongTin1.dtp_NgayRaDoan.Checked)
                    qlnS_DanhMucThongTin1.oChinhTri.NgayRaDoan = qlnS_DanhMucThongTin1.dtp_NgayRaDoan.Value;
                else
                    qlnS_DanhMucThongTin1.oChinhTri.NgayRaDoan = null;

                if (qlnS_DanhMucThongTin1.dtp_NgayTaiNapDoan.Checked)
                    qlnS_DanhMucThongTin1.oChinhTri.NgayTaiVaoDoan = qlnS_DanhMucThongTin1.dtp_NgayTaiNapDoan.Value;
                else
                    qlnS_DanhMucThongTin1.oChinhTri.NgayTaiVaoDoan = null;
            }
            else
            {
                qlnS_DanhMucThongTin1.oChinhTri.DoanVien = false;
            }

            qlnS_DanhMucThongTin1.oChinhTri.QuanHamCaoNhat = qlnS_DanhMucThongTin1.txt_QuanHam.Text;
            qlnS_DanhMucThongTin1.oChinhTri.DanhHieuCaoNhat = qlnS_DanhMucThongTin1.txt_DanhHieu.Text;
            qlnS_DanhMucThongTin1.oChinhTri.QuanLyNhaNuoc = qlnS_DanhMucThongTin1.txt_QuanLyNhaNuoc.Text;
            qlnS_DanhMucThongTin1.oChinhTri.LyLuanChinhTri = qlnS_DanhMucThongTin1.txt_LyLuanChinhTri.Text;
            qlnS_DanhMucThongTin1.oChinhTri.ThuongBinhHang = qlnS_DanhMucThongTin1.txt_ThuongBinh.Text;
            qlnS_DanhMucThongTin1.oChinhTri.GDChinhSach = qlnS_DanhMucThongTin1.txt_GiaDinh.Text;
            qlnS_DanhMucThongTin1.oChinhTri.KhenThuong = qlnS_DanhMucThongTin1.rtb_KhenThuong.Text;
            qlnS_DanhMucThongTin1.oChinhTri.KyLuat = qlnS_DanhMucThongTin1.rtb_KyLuat.Text;

            if (qlnS_DanhMucThongTin1.dtp_NgayNhapNgu.Checked)
                qlnS_DanhMucThongTin1.oChinhTri.NgayNhapNgu = qlnS_DanhMucThongTin1.dtp_NgayNhapNgu.Value;
            else
                qlnS_DanhMucThongTin1.oChinhTri.NgayNhapNgu = null;

            if (qlnS_DanhMucThongTin1.dtp_NgayXuatNgu.Checked)
                qlnS_DanhMucThongTin1.oChinhTri.NgayXuatNgu = qlnS_DanhMucThongTin1.dtp_NgayXuatNgu.Value;
            else
                qlnS_DanhMucThongTin1.oChinhTri.NgayXuatNgu = null;

            qlnS_DanhMucThongTin1.oChinhTri.Add();
        }

        private void ThemAvatar()
        {
            string path = qlnS_DanhMucThongTin1.openFileDialog1.FileName.ToString();
            if (!string.IsNullOrWhiteSpace(path))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(strImagePath);
                }
                catch (Exception ex)
                {
                    throw new Exception("Quá trình thêm hình đại diện không thành công.\r\n" + ex.Message); ;
                }

                using (Bitmap bmp = new Bitmap(qlnS_DanhMucThongTin1.picB_HinhDaiDien.Image))
                {
                    bmp.Save(strImagePath + qlnS_DanhMucThongTin1.openFileDialog1.SafeFileName);
                }

                qlnS_DanhMucThongTin1.oFile.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
                qlnS_DanhMucThongTin1.oFile.MoTa = "Hình đại diện";
                qlnS_DanhMucThongTin1.oFile.Path = strImagePath + qlnS_DanhMucThongTin1.openFileDialog1.SafeFileName;
                qlnS_DanhMucThongTin1.oFile.IsAvatar = true;
                qlnS_DanhMucThongTin1.oFile.Add();
                //qlnS_DanhMucThongTin1.openFileDialog1.
            }
        }

        #endregion HAM them thong tin

        #region HAM sua thong tin

        private void SuaThongTin()
        {
            qlnS_DanhMucThongTin1.oCNVC.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVC.Ho = qlnS_DanhMucThongTin1.txt_Ho.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVC.Ten = qlnS_DanhMucThongTin1.txt_Ten.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVC.DiaChi = qlnS_DanhMucThongTin1.txt_DiaChi.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVC.SoBHXH = qlnS_DanhMucThongTin1.txt_SoSoBHXH.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVC.MaSoThue = qlnS_DanhMucThongTin1.txt_MaSoThue.Text.Trim();

            switch (qlnS_DanhMucThongTin1.comB_GioiTinh.SelectedIndex)
            {
                case 0:
                    qlnS_DanhMucThongTin1.oCNVC.GioiTinh = true;
                    break;

                case 1:
                    qlnS_DanhMucThongTin1.oCNVC.GioiTinh = false;
                    break;
                default:
                    qlnS_DanhMucThongTin1.oCNVC.GioiTinh = null;
                    break;
            }
            if (qlnS_DanhMucThongTin1.dTP_NgaySinh.Checked)
            {
                qlnS_DanhMucThongTin1.oCNVC.NgaySinh = qlnS_DanhMucThongTin1.dTP_NgaySinh.Value;
            }
            else
                qlnS_DanhMucThongTin1.oCNVC.NgaySinh = null;

            try
            {
                qlnS_DanhMucThongTin1.oCNVC.Update(ma_nv_old);
                qlnS_DanhMucThongTin1.oQTCT.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
                qlnS_DanhMucThongTin1.oQTCT.Update_MaNV(ma_nv_old);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                               
            }

            qlnS_DanhMucThongTin1.oCMND.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oCMND.Delete();
            for (int i = 0; i < qlnS_DanhMucThongTin1.dtgv_CMNDHoChieu.Rows.Count - 1; i++) // bo dong cuoi cung
            {
                DataGridViewRow r = qlnS_DanhMucThongTin1.dtgv_CMNDHoChieu.Rows[i];


                qlnS_DanhMucThongTin1.oCMND.CMNDHoChieu = (Convert.ToString(r.Cells[0].Value) == "CMND") ? true : false;
                qlnS_DanhMucThongTin1.oCMND.MaSo = Convert.ToString(r.Cells[3].Value);
                string t = Convert.ToString(r.Cells[4].Value);
                if (t != null && t != "")
                {
                    try
                    {
                        qlnS_DanhMucThongTin1.oCMND.NgayCap = Convert.ToDateTime(t);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ngày cấp của CMND/Hộ chiếu có định dạng không đúng");
                    }

                }
                else
                    qlnS_DanhMucThongTin1.oCMND.NgayCap = null;
                qlnS_DanhMucThongTin1.oCMND.NoiCap = Convert.ToString(r.Cells[5].Value);
                qlnS_DanhMucThongTin1.oCMND.IsActive = (Convert.ToString(r.Cells[6].Value) == "") ? false : Convert.ToBoolean(r.Cells[6].Value);

                qlnS_DanhMucThongTin1.oCMND.Add();
            }

            #region AVATAR

            string path = qlnS_DanhMucThongTin1.openFileDialog1.FileName.ToString();
            if (!string.IsNullOrWhiteSpace(path))
            {
                using (Bitmap bmp = new Bitmap(qlnS_DanhMucThongTin1.picB_HinhDaiDien.Image))
                {
                    bmp.Save(strImagePath + qlnS_DanhMucThongTin1.openFileDialog1.SafeFileName);
                }

                qlnS_DanhMucThongTin1.oFile.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
                qlnS_DanhMucThongTin1.oFile.MoTa = "Hình đại diện";
                qlnS_DanhMucThongTin1.oFile.Path = strImagePath + qlnS_DanhMucThongTin1.openFileDialog1.SafeFileName;
                qlnS_DanhMucThongTin1.oFile.IsAvatar = true;
                qlnS_DanhMucThongTin1.oFile.DeleteAvatar();
                qlnS_DanhMucThongTin1.oFile.Add();
       
            }

            #endregion
        }

        private void SuaThongTinBoSung()
        {
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.TenGoiKhac = qlnS_DanhMucThongTin1.txt_TenGoiKhac.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.DanToc = qlnS_DanhMucThongTin1.txt_DanToc.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.TonGiao = qlnS_DanhMucThongTin1.txt_TonGiao.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.NoiSinhXa = qlnS_DanhMucThongTin1.txt_NoiSinhXa.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.NoiSinhHuyen = qlnS_DanhMucThongTin1.txt_NoiSinhHuyen.Text.Trim();
            int i = Convert.ToInt16(qlnS_DanhMucThongTin1.comB_NoiSinhTinh.SelectedValue);
            if (i == -1 || i == 0)
                qlnS_DanhMucThongTin1.oCNVCInfoPhu.NoiSinhTinh = null;
            else
                qlnS_DanhMucThongTin1.oCNVCInfoPhu.NoiSinhTinh = i;
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.QueQuanXa = qlnS_DanhMucThongTin1.txt_QueXa.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.QueQuanHuyen = qlnS_DanhMucThongTin1.txt_QueHuyen.Text.Trim();
            i = Convert.ToInt16(qlnS_DanhMucThongTin1.comB_QueTinh.SelectedValue);
            if (i == -1 || i == 0)
                qlnS_DanhMucThongTin1.oCNVCInfoPhu.QueQuanTinh = null;
            else
                qlnS_DanhMucThongTin1.oCNVCInfoPhu.QueQuanTinh = i;
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.HoKhauThuongTru = qlnS_DanhMucThongTin1.txt_HoKhau.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.ChieuCao = qlnS_DanhMucThongTin1.txt_ChieuCao.Text.Trim();
            qlnS_DanhMucThongTin1.oCNVCInfoPhu.NhomMau = qlnS_DanhMucThongTin1.txt_NhomMau.Text.Trim();            
            i = Convert.ToInt16(qlnS_DanhMucThongTin1.comB_TinhTrangHonNhan.SelectedValue);
            if (i == -1 || i == 0)
                qlnS_DanhMucThongTin1.oCNVCInfoPhu.TinhTrangHonNhan = null;
            else
                qlnS_DanhMucThongTin1.oCNVCInfoPhu.TinhTrangHonNhan = i;

            qlnS_DanhMucThongTin1.oCNVCInfoPhu.Update();

        }

        private void SuaQTCT()
        {
            #region SUA QTCT NGOAI GD

            qlnS_DanhMucThongTin1.oNonOUNonGD.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oNonOUNonGD.Delete();
            for (int i = 0; i < qlnS_DanhMucThongTin1.dtgv_NgoaiGD.Rows.Count - 1; i++) // bo dong cuoi cung
            {
                DataGridViewRow r = qlnS_DanhMucThongTin1.dtgv_NgoaiGD.Rows[i];
                
                qlnS_DanhMucThongTin1.oNonOUNonGD.TenDonVi = Convert.ToString(r.Cells[1].Value);
                qlnS_DanhMucThongTin1.oNonOUNonGD.ChucDanh = Convert.ToString(r.Cells[2].Value);
                qlnS_DanhMucThongTin1.oNonOUNonGD.ChucVu = Convert.ToString(r.Cells[3].Value);
                string t = Convert.ToString(r.Cells[4].Value);
                if (t != null && t != "")
                {
                    try
                    {
                        qlnS_DanhMucThongTin1.oNonOUNonGD.TuNgay = Convert.ToDateTime(t);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ngày bắt đầu hoạt động ngoài ĐH Mở - ngoài ngành giáo dục có định dạng không đúng");
                    }

                }
                else
                    qlnS_DanhMucThongTin1.oNonOUNonGD.TuNgay = null;

                t = Convert.ToString(r.Cells[5].Value);
                if (t != null && t != "")
                {
                    try
                    {
                        qlnS_DanhMucThongTin1.oNonOUNonGD.DenNgay = Convert.ToDateTime(t);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ngày kết thúc hoạt động ngoài ĐH Mở - ngoài ngành giáo dục có định dạng không đúng");
                    }

                }
                else
                    qlnS_DanhMucThongTin1.oNonOUNonGD.DenNgay = null;

                qlnS_DanhMucThongTin1.oNonOUNonGD.CongViecChinh = Convert.ToString(r.Cells[6].Value);

                qlnS_DanhMucThongTin1.oNonOUNonGD.Add();
            }

            #endregion SUA QTCT NGOAI GD

            #region SUA QTCT TRONG GD

            qlnS_DanhMucThongTin1.oNonOUGD.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oNonOUGD.Delete();
            for (int i = 0; i < qlnS_DanhMucThongTin1.dtgv_TrongGD.Rows.Count - 1; i++) // bo dong cuoi cung
            {
                DataGridViewRow r = qlnS_DanhMucThongTin1.dtgv_TrongGD.Rows[i];

                qlnS_DanhMucThongTin1.oNonOUGD.TenDonVi = Convert.ToString(r.Cells[1].Value);
                qlnS_DanhMucThongTin1.oNonOUGD.ChucDanh = Convert.ToString(r.Cells[2].Value);
                qlnS_DanhMucThongTin1.oNonOUGD.ChucVu = Convert.ToString(r.Cells[3].Value);

                string t = Convert.ToString(r.Cells[4].Value);
                if (t != null && t != "")
                {
                    try
                    {
                        qlnS_DanhMucThongTin1.oNonOUGD.TuNgay = Convert.ToDateTime(t);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ngày bắt đầu hoạt động ngoài ĐH Mở - trong ngành giáo dục có định dạng không đúng");
                    }

                }
                else
                    qlnS_DanhMucThongTin1.oNonOUGD.TuNgay = null;

                t = Convert.ToString(r.Cells[5].Value);
                if (t != null && t != "")
                {
                    try
                    {
                        qlnS_DanhMucThongTin1.oNonOUGD.DenNgay = Convert.ToDateTime(t);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ngày kết thúc hoạt động ngoài ĐH Mở - trong ngành giáo dục có định dạng không đúng");
                    }

                }
                else
                    qlnS_DanhMucThongTin1.oNonOUGD.DenNgay = null;

                qlnS_DanhMucThongTin1.oNonOUGD.CongViecChinh = Convert.ToString(r.Cells[6].Value);

                qlnS_DanhMucThongTin1.oNonOUGD.Add();
            }

            #endregion SUA QTCT TRONG GD
        }

        private void SuaHopDongTT()
        {
            qlnS_DanhMucThongTin1.oTTTuyenDung.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oTTTuyenDung.CoQuanTuyenDung = qlnS_DanhMucThongTin1.txt_CoQuan.Text;
            qlnS_DanhMucThongTin1.oTTTuyenDung.NgheNghiepTruocDay = qlnS_DanhMucThongTin1.txt_NgheNghiep.Text;
            if (qlnS_DanhMucThongTin1.dTP_NgayTuyenDung.Checked)
                qlnS_DanhMucThongTin1.oTTTuyenDung.NgayTuyenDung = qlnS_DanhMucThongTin1.dTP_NgayTuyenDung.Value;
            else
                qlnS_DanhMucThongTin1.oTTTuyenDung.NgayTuyenDung = null;

            qlnS_DanhMucThongTin1.oTTTuyenDung.Update();

        }

        private void SuaDaoTaoBD()
        {
            #region CHUYEN MON TONG QUAT

            qlnS_DanhMucThongTin1.oChuyenMonTQ.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oChuyenMonTQ.TinHoc = qlnS_DanhMucThongTin1.txt_TinHoc.Text;
            qlnS_DanhMucThongTin1.oChuyenMonTQ.NgoaiNgu = qlnS_DanhMucThongTin1.txt_NgoaiNgu.Text;
            qlnS_DanhMucThongTin1.oChuyenMonTQ.SoTruongCTac = qlnS_DanhMucThongTin1.txt_SoTruong.Text;
            qlnS_DanhMucThongTin1.oChuyenMonTQ.TrinhDoChuyenMon = qlnS_DanhMucThongTin1.txt_TrinhDo.Text;
            int i = Convert.ToInt16(qlnS_DanhMucThongTin1.comB_MoHinhDaoTao.SelectedValue);
            if (i == -1 || i == 0)
                qlnS_DanhMucThongTin1.oChuyenMonTQ.MoHinhDaoTaoID = null;
            else
                qlnS_DanhMucThongTin1.oChuyenMonTQ.MoHinhDaoTaoID = i;

            qlnS_DanhMucThongTin1.oChuyenMonTQ.Update();

            #endregion

            #region TRINH DO PHO THONG

            qlnS_DanhMucThongTin1.oTrinhDoPT.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oTrinhDoPT.Delete();
            for (int y = 0; y < qlnS_DanhMucThongTin1.dtgv_TrinhDoPhoThong.Rows.Count - 1; y++)
            {
                DataGridViewRow dr = qlnS_DanhMucThongTin1.dtgv_TrinhDoPhoThong.Rows[y];
                qlnS_DanhMucThongTin1.oTrinhDoPT.TruongCap1 = Convert.ToString(dr.Cells[0].Value);
                qlnS_DanhMucThongTin1.oTrinhDoPT.TruongCap2 = Convert.ToString(dr.Cells[1].Value);
                qlnS_DanhMucThongTin1.oTrinhDoPT.TruongCap3 = Convert.ToString(dr.Cells[2].Value);

                qlnS_DanhMucThongTin1.oTrinhDoPT.Add();
            }

            #endregion

            #region DAO TAO BOI DUONG

            qlnS_DanhMucThongTin1.oDaoTaoBD.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oDaoTaoBD.Delete();
            for (int y = 0; y < qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Rows.Count - 1; y++)
            {
                DataGridViewRow dr = qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Rows[y];
                qlnS_DanhMucThongTin1.oDaoTaoBD.TenTruong = Convert.ToString(dr.Cells[1].Value);
                qlnS_DanhMucThongTin1.oDaoTaoBD.ChuyenNganhDaoTao = Convert.ToString(dr.Cells[2].Value);

                string t = Convert.ToString(dr.Cells[3].Value);
                if (t != null && t != "")
                {
                    try
                    {
                        qlnS_DanhMucThongTin1.oDaoTaoBD.TuNgay = Convert.ToDateTime(t);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ngày bắt đầu đào tạo bồi dưỡng có định dạng không đúng");
                    }

                }
                else
                    qlnS_DanhMucThongTin1.oDaoTaoBD.TuNgay = null;

                t = Convert.ToString(dr.Cells[4].Value);
                if (t != null && t != "")
                {
                    try
                    {
                        qlnS_DanhMucThongTin1.oDaoTaoBD.DenNgay = Convert.ToDateTime(t);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ngày kết thúc đào tạo bồi dưỡng có định dạng không đúng");
                    }

                }
                else
                    qlnS_DanhMucThongTin1.oDaoTaoBD.DenNgay = null;

                qlnS_DanhMucThongTin1.oDaoTaoBD.XepLoai = Convert.ToString(dr.Cells[6].Value);
                qlnS_DanhMucThongTin1.oDaoTaoBD.BD_TenChungChi = Convert.ToString(dr.Cells[7].Value);
                qlnS_DanhMucThongTin1.oDaoTaoBD.CQ_TenLuanVan = Convert.ToString(dr.Cells[9].Value);
                qlnS_DanhMucThongTin1.oDaoTaoBD.CQ_HoiDongCham = Convert.ToString(dr.Cells[10].Value);

                int? x;

                if (dr.Cells[11].Value != Convert.DBNull && dr.Cells[11].Value != null)
                {
                    x = Convert.ToInt16(dr.Cells[11].Value);
                        qlnS_DanhMucThongTin1.oDaoTaoBD.HinhThucDaoTaoID = x;
                }
                else
                {
                    qlnS_DanhMucThongTin1.oDaoTaoBD.HinhThucDaoTaoID = null;
                }



                if (dr.Cells[12].Value != Convert.DBNull && dr.Cells[12].Value != null)
                {
                    x = Convert.ToInt16(dr.Cells[12].Value);
                        qlnS_DanhMucThongTin1.oDaoTaoBD.CQ_VanBangID = x;
                }
                else
                {
                    qlnS_DanhMucThongTin1.oDaoTaoBD.CQ_VanBangID = null;
                }

                qlnS_DanhMucThongTin1.oDaoTaoBD.Add();
            }

            #endregion
        }

        private void SuaThongTinGD()
        {
            #region QUAN HE GIA DINH

            qlnS_DanhMucThongTin1.oQuanHeGD.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oQuanHeGD.Delete();
            for (int y = 0; y < qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Rows.Count - 1; y++)
            {
                DataGridViewRow dr = qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Rows[y];
                qlnS_DanhMucThongTin1.oQuanHeGD.MoiQuanHe = Convert.ToString(dr.Cells[1].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.Ho = Convert.ToString(dr.Cells[2].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.Ten = Convert.ToString(dr.Cells[3].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.NamSinh = Convert.ToString(dr.Cells[4].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.QueQuan = Convert.ToString(dr.Cells[5].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.NgheNghiep = Convert.ToString(dr.Cells[6].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.ChucDanh = Convert.ToString(dr.Cells[7].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.DVCongTac = Convert.ToString(dr.Cells[8].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.DiaChi = Convert.ToString(dr.Cells[9].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.ThanhVienToChucXH = Convert.ToString(dr.Cells[10].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.HocTap = Convert.ToString(dr.Cells[11].Value);
                qlnS_DanhMucThongTin1.oQuanHeGD.GhiChu = Convert.ToString(dr.Cells[12].Value);

                qlnS_DanhMucThongTin1.oQuanHeGD.Add();
            }

            #endregion

            #region DAC DIEM BAN THAN

            qlnS_DanhMucThongTin1.oDacDiemBT.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();
            qlnS_DanhMucThongTin1.oDacDiemBT.ThongTinLS = qlnS_DanhMucThongTin1.rtb_ThongTinLichSu.Text;
            qlnS_DanhMucThongTin1.oDacDiemBT.ThanNhanNuocNgoai = qlnS_DanhMucThongTin1.rtb_ThanNhan.Text;
            qlnS_DanhMucThongTin1.oDacDiemBT.QHToChucXH = qlnS_DanhMucThongTin1.rtb_QuanHeToChuc.Text;

            qlnS_DanhMucThongTin1.oDacDiemBT.Update();

            #endregion
        }

        private void SuaChinhTri()
        {
            qlnS_DanhMucThongTin1.oChinhTri.MaNV = qlnS_DanhMucThongTin1.txt_MaNV.Text.Trim();

            if (qlnS_DanhMucThongTin1.cb_DangVien.Checked)
            {
                qlnS_DanhMucThongTin1.oChinhTri.DangVien = true;
                if (qlnS_DanhMucThongTin1.dtp_NgayChinhThuc.Checked)
                    qlnS_DanhMucThongTin1.oChinhTri.NgayChinhThuc = qlnS_DanhMucThongTin1.dtp_NgayChinhThuc.Value;
                else
                    qlnS_DanhMucThongTin1.oChinhTri.NgayChinhThuc = null;

                if (qlnS_DanhMucThongTin1.dtp_NgayVaoDang.Checked)
                    qlnS_DanhMucThongTin1.oChinhTri.NgayVaoDang = qlnS_DanhMucThongTin1.dtp_NgayVaoDang.Value;
                else
                    qlnS_DanhMucThongTin1.oChinhTri.NgayVaoDang = null;

                if (qlnS_DanhMucThongTin1.dtp_NgayRaDang.Checked)
                    qlnS_DanhMucThongTin1.oChinhTri.NgayRaDang = qlnS_DanhMucThongTin1.dtp_NgayRaDang.Value;
                else
                    qlnS_DanhMucThongTin1.oChinhTri.NgayRaDang = null;

                if (qlnS_DanhMucThongTin1.dtp_NgayTaiNapDang.Checked)
                    qlnS_DanhMucThongTin1.oChinhTri.NgayTaiVaoDang = qlnS_DanhMucThongTin1.dtp_NgayTaiNapDang.Value;
                else
                    qlnS_DanhMucThongTin1.oChinhTri.NgayTaiVaoDang = null;
            }

            if (qlnS_DanhMucThongTin1.cb_DoanVien.Checked)
            {
                qlnS_DanhMucThongTin1.oChinhTri.DoanVien = true;
                if (qlnS_DanhMucThongTin1.dtp_NgayVaoDoan.Checked)
                    qlnS_DanhMucThongTin1.oChinhTri.NgayVaoDoan = qlnS_DanhMucThongTin1.dtp_NgayVaoDoan.Value;
                else
                    qlnS_DanhMucThongTin1.oChinhTri.NgayVaoDoan = null;

                if (qlnS_DanhMucThongTin1.dtp_NgayRaDoan.Checked)
                    qlnS_DanhMucThongTin1.oChinhTri.NgayRaDoan = qlnS_DanhMucThongTin1.dtp_NgayRaDoan.Value;
                else
                    qlnS_DanhMucThongTin1.oChinhTri.NgayRaDoan = null;

                if (qlnS_DanhMucThongTin1.dtp_NgayTaiNapDoan.Checked)
                    qlnS_DanhMucThongTin1.oChinhTri.NgayTaiVaoDoan = qlnS_DanhMucThongTin1.dtp_NgayTaiNapDoan.Value;
                else
                    qlnS_DanhMucThongTin1.oChinhTri.NgayTaiVaoDoan = null;
            }

            qlnS_DanhMucThongTin1.oChinhTri.QuanHamCaoNhat = qlnS_DanhMucThongTin1.txt_QuanHam.Text;
            qlnS_DanhMucThongTin1.oChinhTri.DanhHieuCaoNhat = qlnS_DanhMucThongTin1.txt_DanhHieu.Text;
            qlnS_DanhMucThongTin1.oChinhTri.QuanLyNhaNuoc = qlnS_DanhMucThongTin1.txt_QuanLyNhaNuoc.Text;
            qlnS_DanhMucThongTin1.oChinhTri.LyLuanChinhTri = qlnS_DanhMucThongTin1.txt_LyLuanChinhTri.Text;
            qlnS_DanhMucThongTin1.oChinhTri.ThuongBinhHang = qlnS_DanhMucThongTin1.txt_ThuongBinh.Text;
            qlnS_DanhMucThongTin1.oChinhTri.GDChinhSach = qlnS_DanhMucThongTin1.txt_GiaDinh.Text;
            qlnS_DanhMucThongTin1.oChinhTri.KhenThuong = qlnS_DanhMucThongTin1.rtb_KhenThuong.Text;
            qlnS_DanhMucThongTin1.oChinhTri.KyLuat = qlnS_DanhMucThongTin1.rtb_KyLuat.Text;

            if (qlnS_DanhMucThongTin1.dtp_NgayNhapNgu.Checked)
                qlnS_DanhMucThongTin1.oChinhTri.NgayNhapNgu = qlnS_DanhMucThongTin1.dtp_NgayNhapNgu.Value;
            else
                qlnS_DanhMucThongTin1.oChinhTri.NgayNhapNgu = null;

            if (qlnS_DanhMucThongTin1.dtp_NgayXuatNgu.Checked)
                qlnS_DanhMucThongTin1.oChinhTri.NgayXuatNgu = qlnS_DanhMucThongTin1.dtp_NgayXuatNgu.Value;
            else
                qlnS_DanhMucThongTin1.oChinhTri.NgayXuatNgu = null;

            qlnS_DanhMucThongTin1.oChinhTri.Update();

        }

        #endregion HAM sua thong tin

        #region HAM Set up dtgv

        /// <summary>
        /// add cac cot khi them moi
        /// </summary>
        private void Setup_dtgv_CMNDHoChieu()
        {
            qlnS_DanhMucThongTin1.dtgv_CMNDHoChieu.Columns.Clear();
            DataGridViewTextBoxColumn col;

            DataGridViewComboBoxColumn combcol = new DataGridViewComboBoxColumn();
            combcol.Items.Add("");
            combcol.Items.Add("CMND");
            combcol.Items.Add("Hộ chiếu");
            combcol.HeaderText = "CMND / Hộ chiếu";
            combcol.Width = 150;
            qlnS_DanhMucThongTin1.dtgv_CMNDHoChieu.Columns.Add(combcol);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã NV";
            col.Width = 200;
            col.Visible = false;
            qlnS_DanhMucThongTin1.dtgv_CMNDHoChieu.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã số";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_CMNDHoChieu.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Ngày cấp";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_CMNDHoChieu.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Nơi cấp";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_CMNDHoChieu.Columns.Add(col);

            DataGridViewCheckBoxColumn cbcol = new DataGridViewCheckBoxColumn();
            cbcol.HeaderText = "Tình trạng";
            col.Width = 150;
            qlnS_DanhMucThongTin1.dtgv_CMNDHoChieu.Columns.Add(cbcol);
        }

        private void Setup_dtgv_HopDong()
        {
            qlnS_DanhMucThongTin1.dtgv_HopDong.Columns.Clear();
            DataGridViewTextBoxColumn col;
            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "CMND";
            qlnS_DanhMucThongTin1.dtgv_HopDong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã số";
            qlnS_DanhMucThongTin1.dtgv_HopDong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Ngày cấp";
            qlnS_DanhMucThongTin1.dtgv_HopDong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Nơi cấp";
            qlnS_DanhMucThongTin1.dtgv_HopDong.Columns.Add(col);

            DataGridViewCheckBoxColumn cbcol = new DataGridViewCheckBoxColumn();
            cbcol.HeaderText = "Tình trạng";
            qlnS_DanhMucThongTin1.dtgv_HopDong.Columns.Add(cbcol);

        }

        private void Setup_dtgv_NgoaiGD()
        {
            qlnS_DanhMucThongTin1.dtgv_NgoaiGD.Columns.Clear();
            DataGridViewTextBoxColumn col;

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã NV";
            col.Width = 200;
            col.Visible = false;
            qlnS_DanhMucThongTin1.dtgv_NgoaiGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên đơn vị";
            col.Width = 250;
            qlnS_DanhMucThongTin1.dtgv_NgoaiGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chức danh";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_NgoaiGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chức vụ";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_NgoaiGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Từ ngày";
            col.Width = 150;
            qlnS_DanhMucThongTin1.dtgv_NgoaiGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "đến ngày";
            col.Width = 150;
            qlnS_DanhMucThongTin1.dtgv_NgoaiGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = " Công việc chính ";
            col.Width = 250;
            qlnS_DanhMucThongTin1.dtgv_NgoaiGD.Columns.Add(col);

        }

        private void Setup_dtgv_TrongGD()
        {
            qlnS_DanhMucThongTin1.dtgv_TrongGD.Columns.Clear();
            DataGridViewTextBoxColumn col;

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã NV";
            col.Width = 200;
            col.Visible = false;
            qlnS_DanhMucThongTin1.dtgv_TrongGD.Columns.Add(col);
            
            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên đơn vị";
            col.Width = 252;
            qlnS_DanhMucThongTin1.dtgv_TrongGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chức danh";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_TrongGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chức vụ";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_TrongGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Từ ngày";
            col.Width = 150;
            qlnS_DanhMucThongTin1.dtgv_TrongGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "đến ngày";
            col.Width = 150;
            qlnS_DanhMucThongTin1.dtgv_TrongGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = " Công việc chính ";
            col.Width = 250;
            qlnS_DanhMucThongTin1.dtgv_TrongGD.Columns.Add(col);

        }

        private void Setup_dtgv_TrinhDoPhoThong()
        {
            qlnS_DanhMucThongTin1.dtgv_TrinhDoPhoThong.Columns.Clear();
            DataGridViewTextBoxColumn col;

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Trường cấp I";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_TrinhDoPhoThong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Trường cấp II";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_TrinhDoPhoThong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Trường cấp III";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_TrinhDoPhoThong.Columns.Add(col);

        }

        private void Setup_dtgv_DaoTaoBoiDuong()
        {
            qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Columns.Clear();
            DataGridViewTextBoxColumn col;

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã NV";
            col.Width = 200;
            col.Visible = false;
            qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên trường";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chuyên ngành đào tạo";
            col.Width = 250;
            qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Từ ngày";
            col.Width = 150;
            qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Đến ngày";
            col.Width = 150;
            qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "hinh thuc dao tao id";
            col.Width = 150; col.Visible = false;
            qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Xếp loại";
            col.Width = 100;
            qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên chứng chỉ";
            col.Width = 100;
            qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "van bang chinh quy id";
            col.Width = 150; col.Visible = false;
            qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên luận văn";
            col.Width = 100;
            qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Hội đồng chấm";
            col.Width = 100;
            qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Columns.Add(col);

            DataGridViewComboBoxColumn combcol = new DataGridViewComboBoxColumn();
            combcol.DataSource = qlnS_DanhMucThongTin1.dtHinhThucDT;
            combcol.HeaderText = "Hình thức đào tạo";
            combcol.DisplayMember = "ten_hinh_thuc";
            combcol.ValueMember = "id";
            combcol.Width = 150;
            qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Columns.Add(combcol);

            DataGridViewComboBoxColumn combcol2 = new DataGridViewComboBoxColumn();
            combcol2.DataSource = qlnS_DanhMucThongTin1.dtVanBangCQ;
            combcol2.DisplayMember = "ten_van_bang";
            combcol2.ValueMember = "id";
            combcol2.HeaderText = "Văn bằng";
            combcol2.Width = 150;
            qlnS_DanhMucThongTin1.dtgv_DaoTaoBoiDuong.Columns.Add(combcol2);
        }

        private void Setup_dtgv_QuanHeGiaDinh()
        {
            qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Columns.Clear();
            DataGridViewTextBoxColumn col;

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã NV";
            col.Width = 200;
            col.Visible = false;
            qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Quan hệ";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Họ";
            col.Width = 100;
            qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên";
            col.Width = 100;
            qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Năm sinh";
            col.Width = 100;
            qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Quê quán";
            col.Width = 150;
            qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Nghề nghiệp";
            col.Width = 150;
            qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chức danh - chức vụ";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Đơn vị công tác";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Địa chỉ";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Thành viên tổ chức xã hội";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Học tập";
            col.Width = 100;
            qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Ghi chú";
            col.Width = 200;
            qlnS_DanhMucThongTin1.dtgv_QuanHeGiaDinh.Columns.Add(col);

        }

        #endregion HAM Set up dtgv

        #endregion HAM PHU
    }
}
