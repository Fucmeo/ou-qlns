using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QLNS.UCs
{
    public partial class QLNS_DanhMucThongTin : UserControl
    {
        #region global variables

        public string MaCNVC;
        public Business.CNVC.CNVC oCNVC = new Business.CNVC.CNVC();
        public Business.CNVC.CNVC_CMND_HoChieu oCMND = new Business.CNVC.CNVC_CMND_HoChieu();
        public Business.CNVC.CNVC_ThongTinPhu oCNVCInfoPhu = new Business.CNVC.CNVC_ThongTinPhu();
        public Business.TinhTrangHonNhan oTinhTrangHN = new Business.TinhTrangHonNhan();
        public Business.TinhTP oTinhTP = new Business.TinhTP();
        public Business.CNVC.CNVC_QTr_CongTac_NonOU_GD oNonOUGD = new Business.CNVC.CNVC_QTr_CongTac_NonOU_GD();
        public Business.CNVC.CNVC_QTr_CongTac_NonOU_NonGD oNonOUNonGD = new Business.CNVC.CNVC_QTr_CongTac_NonOU_NonGD();
        public Business.CNVC.CNVC_QTr_CongTac_OU oQTCT = new Business.CNVC.CNVC_QTr_CongTac_OU();
        public Business.CNVC.CNVC_ThongTinTuyenDung oTTTuyenDung = new Business.CNVC.CNVC_ThongTinTuyenDung();
        public Business.CNVC.CNVC_DaoTaoBoiDuong oDaoTaoBD = new Business.CNVC.CNVC_DaoTaoBoiDuong();
        public Business.CNVC.CNVC_ChuyenMonTongQuat oChuyenMonTQ = new Business.CNVC.CNVC_ChuyenMonTongQuat();
        public Business.MoHinhDaoTao oMoHinhDT = new Business.MoHinhDaoTao();
        public Business.CNVC.CNVC_TrinhDoPhoThong oTrinhDoPT = new Business.CNVC.CNVC_TrinhDoPhoThong();
        public Business.CNVC.CNVC_QHGiaDinh oQuanHeGD = new Business.CNVC.CNVC_QHGiaDinh();
        public Business.CNVC.CNVC_LSBiBat oDacDiemBT = new Business.CNVC.CNVC_LSBiBat();
        public Business.CNVC.CNVC_ChinhTri oChinhTri = new Business.CNVC.CNVC_ChinhTri();
        public Business.CNVC.CNVC_File oFile = new Business.CNVC.CNVC_File();
        public Business.HinhThucDaoTao oHinhThucDT = new Business.HinhThucDaoTao();
        public Business.VanBangChinhQuy oVanBangCQ = new Business.VanBangChinhQuy();

        public DataTable dtCNVC, dtCNVCInfoPhu, dtTinhTP, dtTinhTrangHN,
                    dtQTCTNonOUGD , dtQTCTNonOUNonGD , dtTrongOU,
                    dtTTTuyenDung , dtDaoTaoBD , dtChuyenMonTQ,
                    dtMoHinhDT , dtTrinhDoPT, dtQuanHeGD,
                    dtDacDiemBT, dtChinhTri, dtCMND , dtHinhThucDT, dtVanBangCQ;

        public List<Business.CNVC.CNVC_File> lstFile = new List<Business.CNVC.CNVC_File>();

        public static int nNewTinhTPID = 0 , nNewMoHinhDT = 0; // ID cua tinh thanh pho , mo hinh dao tao moi them vao
        #endregion

        public QLNS_DanhMucThongTin()
        {
            InitializeComponent();
        }

        public QLNS_DanhMucThongTin(string _MaCNVC)
        {
            InitializeComponent();
            //oCNVC = new Business.CNVC.CNVC();
            
            //MaCNVC = oCNVC.MaNV = _MaCNVC;

            //LoadThongTin();
        }

        public void LoadThongTin()
        {
            EnableTableLP(true);

            LoadThongTinTongQuat();
            LoadThongTinBoSung();
            LoadQTCongTac();
            LoadHopDongTuyenDung();
            LoadDaoTaoBD();
            LoadThongTinGDBTI();
            LoadHoatDongCT();
            LoadTapTinLienQuan();

            
        }

        #region xu ly giao dien

            #region TAB THONG TIN

        private void LoadThongTinTongQuat()
        {            

            #region Thong tin CNVC

            UCs.QLNS_HienThiThongTin.ma_nv_old = oCNVC.MaNV = MaCNVC;
            dtCNVC = oCNVC.GetData();
            if ((dtCNVC) != null && dtCNVC.Rows.Count > 0)
            {
                txt_MaNV.Text = dtCNVC.Rows[0]["ma_nv"].ToString();
                txt_Ho.Text = dtCNVC.Rows[0]["ho"].ToString();
                txt_Ten.Text = dtCNVC.Rows[0]["ten"].ToString();
                txt_DiaChi.Text = dtCNVC.Rows[0]["dia_chi"].ToString();
                string dt = dtCNVC.Rows[0]["ngay_sinh"].ToString();
                if (!string.IsNullOrWhiteSpace(dt))
                {
                    dTP_NgaySinh.Checked = true;
                    dTP_NgaySinh.Value = Convert.ToDateTime(dt);
                }
                else
                    dTP_NgaySinh.Checked = false;
                txt_SoSoBHXH.Text = dtCNVC.Rows[0]["so_so_bhxh"].ToString();
                txt_MaSoThue.Text = dtCNVC.Rows[0]["ma_so_thue"].ToString();
                string gioitinh = dtCNVC.Rows[0]["gioi_tinh"].ToString();
                switch (gioitinh)
                {
                    case "True":
                        comB_GioiTinh.SelectedIndex = 0;
                        break;
                    case "False":
                        comB_GioiTinh.SelectedIndex = 1;
                        break;
                    default:
                        comB_GioiTinh.SelectedIndex = 2;
                        break;
                }
            }
            else
            {

            }

            #endregion

            #region CMND - HO CHIEU

            oCMND.MaNV = MaCNVC;
            dtCMND = oCMND.GetData();
            if ((dtCMND) != null && dtCMND.Rows.Count > 0)
            {
                dtgv_CMNDHoChieu.DataSource = null;
                dtgv_CMNDHoChieu.Columns.Clear();
                dtgv_CMNDHoChieu.DataSource = dtCMND;
                SetupDataGridView("dtgv_CMNDHoChieu");
                
            }
            else
            {
                dtgv_CMNDHoChieu.DataSource = null;
                dtgv_CMNDHoChieu.Columns.Clear();
                Setup_dtgv_CMNDHoChieu();
            }


            #endregion
        }
        
            #endregion

            #region TAB THONG TIN BO SUNG

        private void LoadThongTinBoSung()
        {
            oCNVCInfoPhu.MaNV = MaCNVC;
            dtCNVCInfoPhu = oCNVCInfoPhu.GetData();
            
           
            if ((dtCNVCInfoPhu) != null && dtCNVCInfoPhu.Rows.Count >0)
            {
                txt_TenGoiKhac.Text = dtCNVCInfoPhu.Rows[0]["ten_goi_khac"].ToString();
                txt_DanToc.Text = dtCNVCInfoPhu.Rows[0]["dan_toc"].ToString();
                txt_TonGiao.Text = dtCNVCInfoPhu.Rows[0]["ton_giao"].ToString();
                txt_NoiSinhXa.Text = dtCNVCInfoPhu.Rows[0]["noi_sinh_xa"].ToString();
                txt_NoiSinhHuyen.Text = dtCNVCInfoPhu.Rows[0]["noi_sinh_huyen"].ToString();
               

                txt_QueHuyen.Text = dtCNVCInfoPhu.Rows[0]["que_quan_huyen"].ToString();
                txt_QueXa.Text = dtCNVCInfoPhu.Rows[0]["que_quan_xa"].ToString();
                

                txt_HoKhau.Text = dtCNVCInfoPhu.Rows[0]["noi_dk_hokhau_thuongtru"].ToString();
                txt_ChieuCao.Text = dtCNVCInfoPhu.Rows[0]["chieu_cao"].ToString();
                txt_NhomMau.Text = dtCNVCInfoPhu.Rows[0]["nhom_mau"].ToString();

                LoadComboThongTinBoSung();
            }
            else    // TH null thi phai xoa trang content
            {
                EmptyThongTinPhuContent();
            }
        }

        public void LoadComboThongTinBoSung()
        {
            DataTable dtTinhTP2 = new DataTable();
            dtTinhTP = oTinhTP.GetData();
            dtTinhTrangHN = oTinhTrangHN.GetData();
            // comb
            comB_NoiSinhTinh.DataSource = dtTinhTP;
            comB_NoiSinhTinh.DisplayMember = "ten_tinh_tp";
            comB_NoiSinhTinh.ValueMember = "id";         

            // comb
            dtTinhTP2 = dtTinhTP.Copy();
            comB_QueTinh.DataSource = dtTinhTP2;
            comB_QueTinh.DisplayMember = "ten_tinh_tp";
            comB_QueTinh.ValueMember = "id";
            
            // comb
            comB_TinhTrangHonNhan.DataSource = dtTinhTrangHN;
            comB_TinhTrangHonNhan.DisplayMember = "ten";
            comB_TinhTrangHonNhan.ValueMember = "id";
            
            // dung cho TH load du lieu san co
            if (dtCNVCInfoPhu != null && dtCNVCInfoPhu.Rows.Count > 0)
            {
                if (dtCNVCInfoPhu.Rows[0]["noi_sinh_tinh"].ToString() == "")
                    comB_NoiSinhTinh.SelectedValue = -1;
                else
                    comB_NoiSinhTinh.SelectedValue = dtCNVCInfoPhu.Rows[0]["noi_sinh_tinh"];

                if (dtCNVCInfoPhu.Rows[0]["que_quan_tinh"].ToString() == "")
                    comB_QueTinh.SelectedValue = -1;
                else
                    comB_QueTinh.SelectedValue = dtCNVCInfoPhu.Rows[0]["que_quan_tinh"];

                if (dtCNVCInfoPhu.Rows[0]["ttr_hon_nhan_id"].ToString() == "")
                    comB_TinhTrangHonNhan.SelectedValue = -1;
                else
                    comB_TinhTrangHonNhan.SelectedValue = dtCNVCInfoPhu.Rows[0]["ttr_hon_nhan_id"];
            }
            else
            {
                comB_NoiSinhTinh.SelectedValue = -1;
                comB_QueTinh.SelectedValue = -1;
                comB_TinhTrangHonNhan.SelectedValue = -1;
            }
        }

        private void lbl_ThemTinhNoiSinh_Click(object sender, EventArgs e)
        {
            UCs.ThemTinhTP oThemTinhTP = new ThemTinhTP();
            oThemTinhTP.Dock = DockStyle.Fill;
            Forms.Popup fPopup = new Forms.Popup("Thêm tỉnh thành phố", oThemTinhTP);
            fPopup.ShowDialog();
            if (nNewTinhTPID > 0)
            {
                Label lb = (Label)sender;
                int? x = null;
                if (lb.Name == "lbl_ThemTinhNoiSinh")
                {
                    if (comB_QueTinh.SelectedValue != Convert.DBNull && comB_QueTinh.SelectedValue != null)
                        x = Convert.ToInt16(comB_QueTinh.SelectedValue);
                    else
                        x = null;
                }
                else if (lb.Name == "lbl_ThemTinhQue")
                {
                    if (comB_NoiSinhTinh.SelectedValue != Convert.DBNull && comB_NoiSinhTinh.SelectedValue != null)
                        x = Convert.ToInt16(comB_NoiSinhTinh.SelectedValue);
                    else
                        x = null;
                }

                dtTinhTP = oTinhTP.GetData();
                DataTable dtTinhTP2 = dtTinhTP.Copy();

                comB_NoiSinhTinh.DataSource = dtTinhTP;
                comB_NoiSinhTinh.DisplayMember = "ten_tinh_tp";
                comB_NoiSinhTinh.ValueMember = "id";

                comB_QueTinh.DataSource = dtTinhTP2;
                comB_QueTinh.DisplayMember = "ten_tinh_tp";
                comB_QueTinh.ValueMember = "id";

                if (QLNS_HienThiThongTin.bAddFlag)  // dang them thi chi can load vao thoi
                {
                    comB_NoiSinhTinh.SelectedValue = nNewTinhTPID;
                    comB_QueTinh.SelectedValue = nNewTinhTPID;
                }
                else
                {                    
                    if (lb.Name == "lbl_ThemTinhNoiSinh")
                    {
                        comB_NoiSinhTinh.SelectedValue = nNewTinhTPID;
                        comB_QueTinh.SelectedValue = x;
                    }
                    else if (lb.Name == "lbl_ThemTinhQue")
                    {
                        comB_QueTinh.SelectedValue = nNewTinhTPID;
                        comB_NoiSinhTinh.SelectedValue = x;
                    }

                }
                nNewTinhTPID = 0;

                
            }
        }

        private void lbl_ThemTinhQue_Click(object sender, EventArgs e)
        {

        }
        
            #endregion

            #region TAB QUA TRINH CONG TAC

        private void LoadQTCongTac()
        {
            #region NonOU - GD

            oNonOUGD.MaNV = MaCNVC;
            dtQTCTNonOUGD = oNonOUGD.GetData();
            if ((dtQTCTNonOUGD) != null && dtQTCTNonOUGD.Rows.Count > 0)
            {
                dtgv_TrongGD.DataSource = null;
                dtgv_TrongGD.Columns.Clear();
                dtgv_TrongGD.DataSource = dtQTCTNonOUGD;
                SetupDataGridView("dtgv_TrongGD");
            }
            else
            {
                dtgv_TrongGD.DataSource = null;
                dtgv_TrongGD.Columns.Clear();
                Setup_dtgv_TrongGD();
            }

            #endregion

            #region NonOU - NONGD

            oNonOUNonGD.MaNV = MaCNVC;
            dtQTCTNonOUNonGD = oNonOUNonGD.GetData();
            if ((dtQTCTNonOUNonGD) != null && dtQTCTNonOUNonGD.Rows.Count > 0)
            {
                dtgv_NgoaiGD.DataSource = null;
                dtgv_NgoaiGD.Columns.Clear();
                dtgv_NgoaiGD.DataSource = dtQTCTNonOUNonGD;
                SetupDataGridView("dtgv_NgoaiGD");
            }
            else
            {
                dtgv_NgoaiGD.DataSource = null;
                dtgv_NgoaiGD.Columns.Clear();
                Setup_dtgv_NgoaiGD();
            }
            #endregion

            #region Trong OU

            oQTCT.MaNV = MaCNVC;
            dtTrongOU = oQTCT.GetData();
            if ((dtTrongOU) != null && dtTrongOU.Rows.Count > 0)
            {
                dtgv_DHMo.DataSource = null;
                dtgv_DHMo.Columns.Clear();
                dtgv_DHMo.DataSource = dtTrongOU;
                SetupDataGridView("dtgv_TrongOU");
            }
            else
            {
                dtgv_DHMo.DataSource = null;
                dtgv_CMNDHoChieu.Columns.Clear();
            }

            #endregion

        }

            #endregion

            #region TAB HOP DONG - TUYEN DUNG

        private void LoadHopDongTuyenDung()
        {
            oTTTuyenDung.MaNV = MaCNVC;
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

            #endregion

            #region TAB DAO TAO BOI DUONG

        private void LoadDaoTaoBD()
        {
            #region Chuyen mon tong quat

            oChuyenMonTQ.MaNV = MaCNVC;
            dtChuyenMonTQ = oChuyenMonTQ.GetData();
            LoadComboDaoTaoBD();
            // load mo hinh dao tao
            if ((dtChuyenMonTQ) != null && dtChuyenMonTQ.Rows.Count > 0)
            {
                
                txt_NgoaiNgu.Text = dtChuyenMonTQ.Rows[0]["ngoai_ngu"].ToString();
                txt_TinHoc.Text = dtChuyenMonTQ.Rows[0]["tin_hoc"].ToString();
                txt_SoTruong.Text = dtChuyenMonTQ.Rows[0]["so_truong_cong_tac"].ToString();
                txt_TrinhDo.Text = dtChuyenMonTQ.Rows[0]["trinh_do_chuyen_mon"].ToString();            
            }
            else
            {
                EmptyDaoTaoBDContent();
            }

            #endregion

            #region Trinh do pho thong

            
            oTrinhDoPT.MaNV = MaCNVC;
            dtTrinhDoPT = oTrinhDoPT.GetData();
            if ((dtTrinhDoPT) != null && dtTrinhDoPT.Rows.Count > 0)
            {
                dtgv_TrinhDoPhoThong.DataSource = null;
                dtgv_TrinhDoPhoThong.Columns.Clear();
                dtgv_TrinhDoPhoThong.DataSource = dtTrinhDoPT;
                SetupDataGridView("dtgv_TrinhDoPhoThong");
            }
            else
            {
                dtgv_TrinhDoPhoThong.DataSource = null;
                dtgv_TrinhDoPhoThong.Columns.Clear();
                Setup_dtgv_TrinhDoPhoThong();
            }
            #endregion

            #region Dao tao boi duong

            oDaoTaoBD.MaNV = MaCNVC;
            dtDaoTaoBD = oDaoTaoBD.GetData();
            if ((dtDaoTaoBD) != null && dtDaoTaoBD.Rows.Count > 0)
            {
                dtgv_DaoTaoBoiDuong.DataSource = null;
                dtgv_DaoTaoBoiDuong.Columns.Clear();
                dtgv_DaoTaoBoiDuong.DataSource = dtDaoTaoBD;
                SetupDataGridView("dtgv_DaoTaoBoiDuong");
            }
            else
            {
                dtgv_DaoTaoBoiDuong.DataSource = null;
                dtgv_DaoTaoBoiDuong.Columns.Clear();
                Setup_dtgv_DaoTaoBoiDuong();
            }
            #endregion

           
        }

        public void LoadComboDaoTaoBD()
        {
            dtHinhThucDT = oHinhThucDT.GetData();
            dtVanBangCQ = oVanBangCQ.GetData();

            dtMoHinhDT = oMoHinhDT.GetData();
            comB_MoHinhDaoTao.DataSource = dtMoHinhDT;
            comB_MoHinhDaoTao.DisplayMember = "ten_mo_hinh";
            comB_MoHinhDaoTao.ValueMember = "id";
            if (dtChuyenMonTQ != null && dtChuyenMonTQ.Rows.Count > 0)
            {
                if (dtChuyenMonTQ.Rows[0]["mo_hinh_dao_tao_id"].ToString() == "")
                    comB_MoHinhDaoTao.SelectedValue = -1;
                else
                    comB_MoHinhDaoTao.SelectedValue = dtChuyenMonTQ.Rows[0]["mo_hinh_dao_tao_id"];
            }
            else
                comB_MoHinhDaoTao.SelectedValue = -1;
            
        }


            #endregion

            #region TAB THONG TIN GIA DINH - BAN THAN

        private void LoadThongTinGDBTI()
        {
            #region QUAN HE GIA DINH

            oQuanHeGD.MaNV = MaCNVC;
            dtQuanHeGD = oQuanHeGD.GetData();
            if ((dtQuanHeGD) != null && dtQuanHeGD.Rows.Count > 0)
            {
                dtgv_QuanHeGiaDinh.DataSource = null;
                dtgv_QuanHeGiaDinh.Columns.Clear();
                dtgv_QuanHeGiaDinh.DataSource = dtQuanHeGD;
                SetupDataGridView("dtgv_QuanHeGiaDinh");
            }
            else
            {
                dtgv_QuanHeGiaDinh.DataSource = null;
                dtgv_QuanHeGiaDinh.Columns.Clear();
                Setup_dtgv_QuanHeGiaDinh();
            }

            #endregion

            #region DAC DIEM BAN THAN

            oDacDiemBT.MaNV = MaCNVC;
            dtDacDiemBT = oDacDiemBT.GetData();
            if ((dtDacDiemBT) != null && dtDacDiemBT.Rows.Count > 0)
            {
                rtb_ThongTinLichSu.Text = dtDacDiemBT.Rows[0]["thong_tin_ls"].ToString();
                rtb_QuanHeToChuc.Text = dtDacDiemBT.Rows[0]["quan_he_to_chuc_ctr_xh"].ToString();
                rtb_ThanNhan.Text = dtDacDiemBT.Rows[0]["than_nhan_nuoc_ngoai"].ToString();
            }
            else
                EmptyGiaDinhContent();


            #endregion
        }

            #endregion

            #region TAB HOAT DONG CHINH TRI

        private void LoadHoatDongCT()
        {
            //oChinhTri.MaNV = MaCNVC;
            //dtChinhTri = oChinhTri.GetData();
            //if ((dtChinhTri) != null && dtChinhTri.Rows.Count > 0)
            //{
            //    #region DOAN VIEN

            //    cb_DoanVien.Checked = dtChinhTri.Rows[0]["doan_vien"].ToString() == "True" ? true : false;
            //    if (cb_DoanVien.Checked)
            //    {
            //        dtp_NgayRaDoan.Enabled = dtp_NgayVaoDoan.Enabled = dtp_NgayTaiNapDoan.Enabled = true;

            //        string dt = dtChinhTri.Rows[0]["ngay_vao_doan"].ToString();
            //        if (!string.IsNullOrWhiteSpace(dt))
            //        {
            //            dtp_NgayVaoDoan.Value = Convert.ToDateTime(dt);
            //            dtp_NgayVaoDoan.Checked = true;
            //        }
            //        else
            //            dtp_NgayVaoDoan.Checked = false;

            //        dt = dtChinhTri.Rows[0]["ngay_ra_khoi_doan"].ToString();
            //        if (!string.IsNullOrWhiteSpace(dt))
            //        {
            //            dtp_NgayRaDoan.Value = Convert.ToDateTime(dt);
            //            dtp_NgayRaDoan.Checked = true;
            //        }
            //        else
            //            dtp_NgayRaDoan.Checked = false;

            //        dt = dtChinhTri.Rows[0]["ngay_tai_gia_nhap_doan"].ToString();
            //        if (!string.IsNullOrWhiteSpace(dt))
            //        {
            //            dtp_NgayTaiNapDoan.Value = Convert.ToDateTime(dt);
            //            dtp_NgayTaiNapDoan.Checked = true;
            //        }
            //        else
            //            dtp_NgayTaiNapDoan.Checked = false;
            //    }

            //    #endregion

            //    #region DANG VIEN

            //    cb_DangVien.Checked = dtChinhTri.Rows[0]["dang_vien"].ToString() == "True" ? true : false;
            //    if (cb_DangVien.Checked)
            //    {
            //        dtp_NgayChinhThuc.Enabled = dtp_NgayVaoDang.Enabled = dtp_NgayRaDang.Enabled = dtp_NgayTaiNapDang.Enabled = true;

            //        string dt = dtChinhTri.Rows[0]["ngay_vao_dang"].ToString();
            //        if (!string.IsNullOrWhiteSpace(dt))
            //        {
            //            dtp_NgayVaoDang.Value = Convert.ToDateTime(dt);
            //            dtp_NgayVaoDang.Checked = true;
            //        }
            //        else
            //            dtp_NgayVaoDang.Checked = false;
                    
            //        dt = dtChinhTri.Rows[0]["ngay_ra_khoi_dang"].ToString();
            //        if (!string.IsNullOrWhiteSpace(dt))
            //        {
            //            dtp_NgayRaDang.Value = Convert.ToDateTime(dt);
            //            dtp_NgayRaDang.Checked = true;
            //        }
            //        else
            //            dtp_NgayRaDang.Checked = false;

            //        dt = dtChinhTri.Rows[0]["ngay_chinh_thuc"].ToString();
            //        if (!string.IsNullOrWhiteSpace(dt))
            //        {
            //            dtp_NgayChinhThuc.Value = Convert.ToDateTime(dt);
            //            dtp_NgayChinhThuc.Checked = true;
            //        }
            //        else
            //            dtp_NgayChinhThuc.Checked = false;

            //        dt = dtChinhTri.Rows[0]["ngay_tai_gia_nhap_dang"].ToString();
            //        if (!string.IsNullOrWhiteSpace(dt))
            //        {
            //            dtp_NgayTaiNapDang.Value = Convert.ToDateTime(dt);
            //            dtp_NgayTaiNapDang.Checked = true;
            //        }
            //        else
            //            dtp_NgayTaiNapDang.Checked = false;
            //    }

            //    #endregion

            //    #region THONG TIN KHAC

            //    cb_CongDoan.Checked = dtChinhTri.Rows[0]["is_cong_doan_vien"].ToString() == "True" ? true : false;

            //    string cb = dtChinhTri.Rows[0]["ngay_nhap_ngu"].ToString();
            //    if (!string.IsNullOrWhiteSpace(cb))
            //    {
            //        dtp_NgayNhapNgu.Value = Convert.ToDateTime(cb);
            //        dtp_NgayNhapNgu.Checked = true;
            //    }
            //    else
            //        dtp_NgayNhapNgu.Checked = false;

            //    cb = dtChinhTri.Rows[0]["ngay_xuat_ngu"].ToString();
            //    if (!string.IsNullOrWhiteSpace(cb))
            //    {
            //        dtp_NgayXuatNgu.Value = Convert.ToDateTime(cb);
            //        dtp_NgayXuatNgu.Checked = true;
            //    }
            //    else
            //        dtp_NgayXuatNgu.Checked = false;

            //    txt_QuanHam.Text = dtChinhTri.Rows[0]["quan_ham_cao_nhat"].ToString();
            //    txt_DanhHieu.Text = dtChinhTri.Rows[0]["danh_hieu_cao_nhat"].ToString();
            //    txt_QuanLyNhaNuoc.Text = dtChinhTri.Rows[0]["quan_ly_nha_nuoc"].ToString();
            //    txt_LyLuanChinhTri.Text = dtChinhTri.Rows[0]["ly_luan_chinh_tri"].ToString();
            //    txt_ThuongBinh.Text = dtChinhTri.Rows[0]["thuong_binh_hang"].ToString();
            //    txt_GiaDinh.Text = dtChinhTri.Rows[0]["gia_dinh_chinh_sach"].ToString();
            //    rtb_KhenThuong.Text = dtChinhTri.Rows[0]["khen_thuong"].ToString();
            //    rtb_KyLuat.Text = dtChinhTri.Rows[0]["ky_luat"].ToString();



            //    #endregion

            //}
            //else
            //    EmptyHoatDongCTContent();
        }

        private void cb_DoanVien_CheckedChanged(object sender, EventArgs e)
        {
            dtp_NgayVaoDoan.Enabled = dtp_NgayRaDoan.Enabled = dtp_NgayTaiNapDoan.Enabled = cb_DoanVien.Checked;
        }
        private void cb_DangVien_CheckedChanged(object sender, EventArgs e)
        {
            dtp_NgayVaoDang.Enabled = dtp_NgayRaDang.Enabled = dtp_NgayChinhThuc.Enabled = dtp_NgayTaiNapDang.Enabled = cb_DangVien.Checked;
        }

            #endregion

            #region TAB TAP TIN LIEN QUAN

        private void LoadTapTinLienQuan()
        {
            oFile.MaNV = MaCNVC;
            //lstFile = oFile.GetData();

            #region AVATAR

            picB_HinhDaiDien.Image = null;

            //var lst = (from f in lstFile
            //              where (f.IsAvatar == true) && (f.MaNV == oFile.MaNV)
            //              select f);

            //if (lst.Count() > 0)
            //{
            //    string path = ((Business.CNVC.CNVC_File)lst.First()).Path;

            //    try
            //    {
            //        picB_HinhDaiDien.Image = Image.FromFile(path);
            //        btn_DelAvatar.Enabled = true;
            //    }
            //    catch (FileNotFoundException ex)
            //    {
            //        MessageBox.Show("Hình không tồn tại \r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }

            //}
            //else
            //{
            //    btn_DelAvatar.Enabled = false;
            //}
            #endregion
        }

            #endregion

        private void picB_HinhDaiDien_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picB_HinhDaiDien.Image = Image.FromFile(openFileDialog1.FileName);
                    btn_DelAvatar.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Quá trình nạp hình thất bại" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion

        #region ham phu

        /// <summary>
        /// khi load du lieu vao (neu co)
        /// </summary>
        /// <param name="dtgv"></param>
        private void SetupDataGridView(string dtgv)
        {
            switch (dtgv)
            {
                #region CMND
                
               
                case "dtgv_CMNDHoChieu":
                    
                    DataGridViewComboBoxColumn combcol = new DataGridViewComboBoxColumn();
                    combcol.Items.Add("");
                    combcol.Items.Add("CMND");
                    combcol.Items.Add("Hộ chiếu");
                    combcol.HeaderText = "CMND / Hộ chiếu";
                    combcol.Width = 150;
                    dtgv_CMNDHoChieu.Columns.Insert(0,combcol);

                    dtgv_CMNDHoChieu.Columns[2].Visible = dtgv_CMNDHoChieu.Columns[1].Visible  = false;
                    dtgv_CMNDHoChieu.Columns[3].HeaderText = "Mã số";
                    dtgv_CMNDHoChieu.Columns[3].Width = 200;
                    dtgv_CMNDHoChieu.Columns[4].HeaderText = "Ngày cấp";
                    dtgv_CMNDHoChieu.Columns[4].Width = 200;
                    dtgv_CMNDHoChieu.Columns[5].HeaderText = "Nơi cấp";
                    dtgv_CMNDHoChieu.Columns[5].Width = 200;
                    dtgv_CMNDHoChieu.Columns[6].HeaderText = "Tình trạng";
                    dtgv_CMNDHoChieu.Columns[6].Width = 150;

                    foreach (DataGridViewRow r in dtgv_CMNDHoChieu.Rows)
                    {
                        r.Cells[0].Value = (Convert.ToBoolean(r.Cells[1].Value) == true) ? "CMND" : r.Cells[1].Value == null ? "" : "Hộ chiếu";
                    }

                    break;
                #endregion

                #region TrongGD

                case "dtgv_TrongGD":
                    dtgv_TrongGD.Columns[0].Visible = false;

                    dtgv_TrongGD.Columns[1].HeaderText = "Tên đơn vị";
                    dtgv_TrongGD.Columns[1].Width = 250;
                    dtgv_TrongGD.Columns[2].HeaderText = "Chức danh";
                    dtgv_TrongGD.Columns[2].Width = 200;
                    dtgv_TrongGD.Columns[3].HeaderText = "Chức vụ";
                    dtgv_TrongGD.Columns[3].Width = 200;
                    dtgv_TrongGD.Columns[4].HeaderText = "Từ ngày";
                    dtgv_TrongGD.Columns[4].Width = 150;
                    dtgv_TrongGD.Columns[5].HeaderText = "Đến ngày";
                    dtgv_TrongGD.Columns[5].Width = 150;
                    dtgv_TrongGD.Columns[6].HeaderText = "Công việc chính";
                    dtgv_TrongGD.Columns[6].Width = 250;

                    break;

                #endregion

                #region Ngoai GD

                case "dtgv_NgoaiGD":
                    dtgv_NgoaiGD.Columns[0].Visible  = false;

                    dtgv_NgoaiGD.Columns[1].HeaderText = "Tên đơn vị";
                    dtgv_NgoaiGD.Columns[1].Width = 250;
                    dtgv_NgoaiGD.Columns[2].HeaderText = "Chức danh";
                    dtgv_NgoaiGD.Columns[2].Width = 200;
                    dtgv_NgoaiGD.Columns[3].HeaderText = "Chức vụ";
                    dtgv_NgoaiGD.Columns[3].Width = 200;
                    dtgv_NgoaiGD.Columns[4].HeaderText = "Từ ngày";
                    dtgv_NgoaiGD.Columns[4].Width = 150;
                    dtgv_NgoaiGD.Columns[5].HeaderText = "Đến ngày";
                    dtgv_NgoaiGD.Columns[5].Width = 150;
                    dtgv_NgoaiGD.Columns[6].HeaderText = "Công việc chính";
                    dtgv_NgoaiGD.Columns[6].Width = 250;

                    break;

                #endregion

                #region Trong OU

                case "dtgv_TrongOU":
                    dtgv_DHMo.Columns["ma_nv"].Visible =
                        dtgv_DHMo.Columns["don_vi_id"].Visible =
                        dtgv_DHMo.Columns["chuc_danh_id"].Visible =
                        dtgv_DHMo.Columns["chuc_vu_id"].Visible = false;

                    dtgv_DHMo.Columns["ma_hop_dong"].HeaderText = "Hợp đồng";
                    dtgv_DHMo.Columns["ma_hop_dong"].Width = 250;
                    dtgv_DHMo.Columns["ma_quyet_dinh"].HeaderText = "Quyết định";
                    dtgv_DHMo.Columns["ma_quyet_dinh"].Width = 200;
                    dtgv_DHMo.Columns["don_vi"].HeaderText = "Đơn vị";
                    dtgv_DHMo.Columns["don_vi"].Width = 200;
                    dtgv_DHMo.Columns["chuc_danh"].HeaderText = "Chức danh";
                    dtgv_DHMo.Columns["chuc_danh"].Width = 150;
                    dtgv_DHMo.Columns["chuc_vu"].HeaderText = "Chức vụ";
                    dtgv_DHMo.Columns["chuc_vu"].Width = 150;
                    dtgv_DHMo.Columns["tu_thoi_gian"].HeaderText = "Từ ngày";
                    dtgv_DHMo.Columns["tu_thoi_gian"].Width = 100;
                    dtgv_DHMo.Columns["den_thoi_gian"].HeaderText = "Đến ngày";
                    dtgv_DHMo.Columns["den_thoi_gian"].Width = 100;
                    dtgv_DHMo.Columns["tinh_trang"].HeaderText = "Tình Trạng";
                    dtgv_DHMo.Columns["tinh_trang"].Width = 50;

                    break;

                #endregion

                #region Dao Tao Boi Duong

                case "dtgv_DaoTaoBoiDuong":

                    dtgv_DaoTaoBoiDuong.Columns[0].Visible = false;

                    dtgv_DaoTaoBoiDuong.Columns[1].HeaderText = "Tên trường";
                    dtgv_DaoTaoBoiDuong.Columns[1].Width = 200;
                    dtgv_DaoTaoBoiDuong.Columns[2].HeaderText = "Chuyên ngành đào tạo";
                    dtgv_DaoTaoBoiDuong.Columns[2].Width = 250;
                    dtgv_DaoTaoBoiDuong.Columns[3].HeaderText = "Từ ngày";
                    dtgv_DaoTaoBoiDuong.Columns[3].Width = 150;
                    dtgv_DaoTaoBoiDuong.Columns[4].HeaderText = "Đến ngày";
                    dtgv_DaoTaoBoiDuong.Columns[4].Width = 150;
                    dtgv_DaoTaoBoiDuong.Columns[5].Visible = false; // hinh thuc dao tao id
                    dtgv_DaoTaoBoiDuong.Columns[6].HeaderText = "Xếp loại";
                    dtgv_DaoTaoBoiDuong.Columns[6].Width = 100;
                    dtgv_DaoTaoBoiDuong.Columns[7].HeaderText = "Tên chứng chỉ";
                    dtgv_DaoTaoBoiDuong.Columns[7].Width = 100;
                    dtgv_DaoTaoBoiDuong.Columns[8].Visible = false; // van bang chinh quy id
                    dtgv_DaoTaoBoiDuong.Columns[9].HeaderText = "Tên luận văn";
                    dtgv_DaoTaoBoiDuong.Columns[9].Width = 100;
                    dtgv_DaoTaoBoiDuong.Columns[10].HeaderText = "Hội đồng chấm";
                    dtgv_DaoTaoBoiDuong.Columns[10].Width = 100;

                    DataGridViewComboBoxColumn combcol2 = new DataGridViewComboBoxColumn();
                    combcol2.DataSource = dtHinhThucDT;
                    combcol2.DisplayMember = "ten_hinh_thuc";
                    combcol2.ValueMember = "id"; 
                    combcol2.HeaderText = "Hình thức đào tạo";
                    combcol2.Width = 300;
                    combcol2.Name = "hinhthucdt";                   
                    dtgv_DaoTaoBoiDuong.Columns.Add(combcol2);

                    DataGridViewComboBoxColumn combcol3 = new DataGridViewComboBoxColumn();
                    combcol3.DataSource = dtVanBangCQ;
                    combcol3.DisplayMember = "ten_van_bang";
                    combcol3.ValueMember = "id";
                    combcol3.HeaderText = "Văn bằng";
                    combcol3.Width = 150;
                    dtgv_DaoTaoBoiDuong.Columns.Add(combcol3);

                    for (int i = 0; i < dtgv_DaoTaoBoiDuong.Rows.Count - 1; i++)
                    {
                        DataGridViewRow r = dtgv_DaoTaoBoiDuong.Rows[i];
                            
                        //((DataGridViewComboBoxCell)r.Cells[11]).Value = "ab";
                        r.Cells["hinhthucdt"].Value = r.Cells[5].Value;                        
                        r.Cells[12].Value = r.Cells[8].Value;
                    }

                    break;

                #endregion

                #region Trinh do pho thong

                case "dtgv_TrinhDoPhoThong":

                    dtgv_TrinhDoPhoThong.Columns[1].HeaderText = "Trường cấp II";
                    dtgv_TrinhDoPhoThong.Columns[1].Width = 200;
                    dtgv_TrinhDoPhoThong.Columns[0].HeaderText = "Trường cấp I";
                    dtgv_TrinhDoPhoThong.Columns[0].Width = 200;
                    dtgv_TrinhDoPhoThong.Columns[2].HeaderText = "Trường cấp III";
                    dtgv_TrinhDoPhoThong.Columns[2].Width = 200;

                    break;

                #endregion

                #region Quan he gia dinh

                case "dtgv_QuanHeGiaDinh":

                    dtgv_QuanHeGiaDinh.Columns[0].Visible  = false;

                    dtgv_QuanHeGiaDinh.Columns[2].HeaderText = "Họ";
                    dtgv_QuanHeGiaDinh.Columns[2].Width = 200;
                    dtgv_QuanHeGiaDinh.Columns[1].HeaderText = "Mối quan hệ";
                    dtgv_QuanHeGiaDinh.Columns[1].Width = 100;
                    dtgv_QuanHeGiaDinh.Columns[3].HeaderText = "Tên";
                    dtgv_QuanHeGiaDinh.Columns[3].Width = 100;
                    dtgv_QuanHeGiaDinh.Columns[4].HeaderText = "Năm sinh";
                    dtgv_QuanHeGiaDinh.Columns[4].Width = 100;
                    dtgv_QuanHeGiaDinh.Columns[5].HeaderText = "Quê Quán";
                    dtgv_QuanHeGiaDinh.Columns[5].Width = 150;
                    dtgv_QuanHeGiaDinh.Columns[6].HeaderText = "Nghề nghiệp";
                    dtgv_QuanHeGiaDinh.Columns[6].Width = 150;
                    dtgv_QuanHeGiaDinh.Columns[7].HeaderText = "Chức danh - chức vụ";
                    dtgv_QuanHeGiaDinh.Columns[7].Width = 200;
                    dtgv_QuanHeGiaDinh.Columns[8].HeaderText = "Đơn vị công tác";
                    dtgv_QuanHeGiaDinh.Columns[8].Width = 200;
                    dtgv_QuanHeGiaDinh.Columns[9].HeaderText = "Địa chỉ";
                    dtgv_QuanHeGiaDinh.Columns[9].Width = 200;
                    dtgv_QuanHeGiaDinh.Columns[10].HeaderText = "Thành viên tổ chức xã hội";
                    dtgv_QuanHeGiaDinh.Columns[10].Width = 200;
                    dtgv_QuanHeGiaDinh.Columns[11].HeaderText = "Học tập";
                    dtgv_QuanHeGiaDinh.Columns[11].Width = 100;
                    dtgv_QuanHeGiaDinh.Columns[12].HeaderText = "Ghi chú";
                    dtgv_QuanHeGiaDinh.Columns[12].Width = 200;

                    break;

                #endregion

            

                default:
                    break;
            }
        }

        public void EnableTableLP(bool enable)
        {
            tableLP_ThongTinChinh.Enabled =
            tableLP_ThongTinBoSung.Enabled =
            tableLP_QuaTrinhCongTac.Enabled =
            tableLP_HopDong_TuyenDung.Enabled =
            tableLP_DaoTaoBoiDuong.Enabled =
            tableLP_GiaDinh_BanThan.Enabled =
            tableLP_ChinhTri.Enabled =
            tableLP_ThongTinBoSung.Enabled =
            tableLP_ThongTinBoSung.Enabled =
            tableLP_ThongTinBoSung.Enabled = enable;
        }

        #region HAM xoa thong tin

        public void EmptyThongTinContent()
        {
            txt_Ho.Text = txt_DiaChi.Text = txt_MaNV.Text =
                txt_MaSoThue.Text = txt_SoSoBHXH.Text = txt_Ten.Text = "";

            dTP_NgaySinh.Checked = false;
            comB_GioiTinh.SelectedIndex = 2;
            dtgv_CMNDHoChieu.DataSource = null;

            dtgv_CMNDHoChieu.DataSource = null;
        }

        public void EmptyThongTinPhuContent()
        {
            txt_TenGoiKhac.Text = txt_DanToc.Text =
                txt_TonGiao.Text = txt_NoiSinhXa.Text =
                txt_NoiSinhHuyen.Text = txt_QueXa.Text =
                txt_QueHuyen.Text = txt_HoKhau.Text =
                txt_ChieuCao.Text = txt_NhomMau.Text = "";

            comB_NoiSinhTinh.SelectedIndex =
                comB_QueTinh.SelectedIndex =
                comB_TinhTrangHonNhan.SelectedIndex = -1;


        }

        public void EmptyHopDongTTContent()
        {

            dTP_NgayTuyenDung.Checked = false;
            txt_NgheNghiep.Text = "";
            txt_CoQuan.Text = "";
            dtgv_HopDong.DataSource = null;
        }

        public void EmptyDaoTaoBDContent()
        {
            txt_NgoaiNgu.Text =
                txt_TinHoc.Text = txt_SoTruong.Text =
                txt_TrinhDo.Text = "";

            comB_MoHinhDaoTao.SelectedIndex = -1;


        }

        public void EmptyGiaDinhContent()
        {
            rtb_QuanHeToChuc.Text =
                rtb_ThanNhan.Text =
                rtb_ThongTinLichSu.Text = "";

        }

        public void EmptyHoatDongCTContent()
        {
            cb_CongDoan.Checked =
                cb_DangVien.Checked =
                cb_DoanVien.Checked =
                dtp_NgayChinhThuc.Checked =
                dtp_NgayNhapNgu.Checked =
                dtp_NgayRaDang.Checked =
                dtp_NgayRaDoan.Checked =
                dTP_NgaySinh.Checked =
                dtp_NgayTaiNapDang.Checked =
                dtp_NgayTaiNapDoan.Checked =
                dTP_NgayTuyenDung.Checked =
                dtp_NgayVaoDang.Checked =
                dtp_NgayVaoDoan.Checked =
                dtp_NgayXuatNgu.Checked = false;

            txt_QuanHam.Text =
                txt_QuanLyNhaNuoc.Text =
                txt_DanhHieu.Text =
                txt_LyLuanChinhTri.Text =
                txt_ThuongBinh.Text =
                txt_GiaDinh.Text =
                rtb_KhenThuong.Text = rtb_KyLuat.Text = "";
        }


        #endregion

        #region HAM INIT dtgv   

        /// <summary>
        /// add cac cot khi them moi
        /// </summary>
        private void Setup_dtgv_CMNDHoChieu()
        {
            dtgv_CMNDHoChieu.Columns.Clear();
            DataGridViewTextBoxColumn col;

            DataGridViewComboBoxColumn combcol = new DataGridViewComboBoxColumn();
            combcol.Items.Add("");
            combcol.Items.Add("CMND");
            combcol.Items.Add("Hộ chiếu");            
            combcol.HeaderText = "CMND / Hộ chiếu";
            combcol.Width = 150;
            dtgv_CMNDHoChieu.Columns.Add(combcol);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã NV";
            col.Width = 200;
            col.Visible = false;
            dtgv_CMNDHoChieu.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã số";
            col.Width = 200;
            dtgv_CMNDHoChieu.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Ngày cấp";
            col.Width = 200;
            dtgv_CMNDHoChieu.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Nơi cấp";
            col.Width = 200;
            dtgv_CMNDHoChieu.Columns.Add(col);

            DataGridViewCheckBoxColumn cbcol = new DataGridViewCheckBoxColumn();
            cbcol.HeaderText = "Tình trạng";
            col.Width = 150;
            dtgv_CMNDHoChieu.Columns.Add(cbcol);

            //dtgv_CMNDHoChieu.Rows.Add(1);
        }

        private void Setup_dtgv_HopDong()
        {
            dtgv_HopDong.Columns.Clear();
            DataGridViewTextBoxColumn col;
            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "CMND";
            dtgv_HopDong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã số";
            dtgv_HopDong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Ngày cấp";
            dtgv_HopDong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Nơi cấp";
            dtgv_HopDong.Columns.Add(col);

            DataGridViewCheckBoxColumn cbcol = new DataGridViewCheckBoxColumn();
            cbcol.HeaderText = "Tình trạng";
            dtgv_HopDong.Columns.Add(cbcol);

        }

        private void Setup_dtgv_NgoaiGD()
        {
            dtgv_NgoaiGD.Columns.Clear();
            DataGridViewTextBoxColumn col;

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã NV";
            col.Width = 200;
            col.Visible = false;
            dtgv_NgoaiGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên đơn vị";
            col.Width = 250;
            dtgv_NgoaiGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chức danh";
            col.Width = 200;
            dtgv_NgoaiGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chức vụ";
            col.Width = 200;
            dtgv_NgoaiGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Từ ngày";
            col.Width = 150;
            dtgv_NgoaiGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Đến ngày";
            col.Width = 150;
            dtgv_NgoaiGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = " Công việc chính ";
            col.Width = 250;
            dtgv_NgoaiGD.Columns.Add(col);

        }

        private void Setup_dtgv_TrongGD()
        {
            dtgv_TrongGD.Columns.Clear();
            DataGridViewTextBoxColumn col;

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã NV";
            col.Width = 200;
            col.Visible = false;
            dtgv_TrongGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên đơn vị";
            col.Width = 252;
            dtgv_TrongGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chức danh";
            col.Width = 200;
            dtgv_TrongGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chức vụ";
            col.Width = 200;
            dtgv_TrongGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Từ ngày";
            col.Width = 150;
            dtgv_TrongGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Đến ngày";
            col.Width = 150;
            dtgv_TrongGD.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = " Công việc chính ";
            col.Width = 250;
            dtgv_TrongGD.Columns.Add(col);

        }

        private void Setup_dtgv_TrinhDoPhoThong()
        {
            dtgv_TrinhDoPhoThong.Columns.Clear();
            DataGridViewTextBoxColumn col;

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Trường cấp I";
            col.Width = 200;
            dtgv_TrinhDoPhoThong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Trường cấp II";
            col.Width = 200;
            dtgv_TrinhDoPhoThong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Trường cấp III";
            col.Width = 200;
            dtgv_TrinhDoPhoThong.Columns.Add(col);

        }

        private void Setup_dtgv_DaoTaoBoiDuong()
        {
            dtgv_DaoTaoBoiDuong.Columns.Clear();
            DataGridViewTextBoxColumn col;

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã NV";
            col.Width = 200;
            col.Visible = false;
            dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên trường";
            col.Width = 200;
            dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chuyên ngành đào tạo";
            col.Width = 250;
            dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Từ ngày";
            col.Width = 150;
            dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Đến ngày";
            col.Width = 150;
            dtgv_DaoTaoBoiDuong.Columns.Add(col);


            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "hinh thuc dao tao id";
            col.Width = 150; col.Visible = false;
            dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Xếp loại";
            col.Width = 100;
            dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên chứng chỉ";
            col.Width = 100;
            dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "hinh thuc dao tao id";
            col.Width = 150; col.Visible = false;
            dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên luận văn";
            col.Width = 100;
            dtgv_DaoTaoBoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Hội đồng chấm";
            col.Width = 100;
            dtgv_DaoTaoBoiDuong.Columns.Add(col);

            DataGridViewComboBoxColumn combcol = new DataGridViewComboBoxColumn();
            combcol.DataSource = dtHinhThucDT;
            combcol.DisplayMember = "ten_hinh_thuc";
            combcol.ValueMember = "id";
            combcol.HeaderText = "Hình thức đào tạo";
            combcol.Width = 150;
            
            dtgv_DaoTaoBoiDuong.Columns.Add(combcol);

            DataGridViewComboBoxColumn combcol2 = new DataGridViewComboBoxColumn();
            combcol2.DataSource = dtVanBangCQ;
            combcol2.DisplayMember = "ten_van_bang";
            combcol2.ValueMember = "id";
            combcol2.HeaderText = "Văn bằng";
            combcol2.Width = 150;
            dtgv_DaoTaoBoiDuong.Columns.Add(combcol2);

        }

        private void Setup_dtgv_QuanHeGiaDinh()
        {
            dtgv_QuanHeGiaDinh.Columns.Clear();
            DataGridViewTextBoxColumn col;

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã NV";
            col.Width = 200;
            col.Visible = false;
            dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Quan hệ";
            col.Width = 200;
            dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Họ";
            col.Width = 100;
            dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên";
            col.Width = 100;
            dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Năm sinh";
            col.Width = 100;
            dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Quê quán";
            col.Width = 150;
            dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Nghề nghiệp";
            col.Width = 150;
            dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chức danh - chức vụ";
            col.Width = 200;
            dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Đơn vị công tác";
            col.Width = 200;
            dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Địa chỉ";
            col.Width = 200;
            dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Thành viên tổ chức xã hội";
            col.Width = 200;
            dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Học tập";
            col.Width = 100;
            dtgv_QuanHeGiaDinh.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Ghi chú";
            col.Width = 200;
            dtgv_QuanHeGiaDinh.Columns.Add(col);

        }

        #endregion HAM INIT dtgv

        private void lbl_TapTinLienQuan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_MaNV.Text))
            {
                UCs.QLNS_TapTin oQLNS_TapTin = new UCs.QLNS_TapTin(txt_MaNV.Text);
                Forms.Popup fPopup = new Forms.Popup("Tập tin liên quan", oQLNS_TapTin);
                fPopup.ShowDialog();
            }
            else
            {
                MessageBox.Show("Xin vui lòng điền mã nhân viên.","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        

        #endregion

        private void btn_DelAvatar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xoá hình đại diện này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oFile.MaNV = txt_MaNV.Text.Trim();
                oFile.DeleteAvatar();
                btn_DelAvatar.Enabled = false;
                picB_HinhDaiDien.Image = null;
                openFileDialog1.FileName = null;
            }
            
        }

        private void lbl_ThemMoHinh_Click(object sender, EventArgs e)
        {
            //UCs.ThemMoHinhDT oThemMoHinhDT = new ThemMoHinhDT();
            //oThemMoHinhDT.Dock = DockStyle.Fill;
            //Forms.Popup fPopup = new Forms.Popup("Thêm mô hình đào tạo", oThemMoHinhDT);
            //fPopup.ShowDialog();
            //if (nNewMoHinhDT > 0)
            //{
            //    dtMoHinhDT = oMoHinhDT.GetData();

            //    comB_MoHinhDaoTao.DataSource = dtMoHinhDT;
            //    comB_MoHinhDaoTao.DisplayMember = "ten_mo_hinh";
            //    comB_MoHinhDaoTao.ValueMember = "id";

            //    comB_MoHinhDaoTao.SelectedValue = nNewMoHinhDT;
                

            //    nNewMoHinhDT = 0;
            //}
        }

        private void lbl_ChiTietSucKhoe_Click(object sender, EventArgs e)
        {
            
        }

    }
}
