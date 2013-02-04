using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNS.UCs
{
    public partial class QLNS_DanhMucThongTin : UserControl
    {
        #region global variables

        public string MaCNVC;
        Business.CNVC.CNVC oCNVC = new Business.CNVC.CNVC();
        Business.CNVC.CNVC_ThongTinPhu oCNVCInfoPhu = new Business.CNVC.CNVC_ThongTinPhu();
        Business.TinhTrangHonNhan oTinhTrangHN = new Business.TinhTrangHonNhan();
        Business.TinhTP oTinhTP = new Business.TinhTP();
        Business.CNVC.CNVC_QTr_CongTac_NonOU_GD oNonOUGD = new Business.CNVC.CNVC_QTr_CongTac_NonOU_GD();
        Business.CNVC.CNVC_QTr_CongTac_NonOU_NonGD oNonOUNonGD = new Business.CNVC.CNVC_QTr_CongTac_NonOU_NonGD();
        Business.CNVC.CNVC_QTr_CongTac_OU oQTCT = new Business.CNVC.CNVC_QTr_CongTac_OU();
        Business.CNVC.CNVC_ThongTinTuyenDung oTTTuyenDung = new Business.CNVC.CNVC_ThongTinTuyenDung();
        Business.CNVC.CNVC_DaoTaoBoiDuong oDaoTaoBD = new Business.CNVC.CNVC_DaoTaoBoiDuong();
        Business.CNVC.CNVC_ChuyenMonTongQuat oChuyenMonTQ = new Business.CNVC.CNVC_ChuyenMonTongQuat();
        Business.MoHinhDaoTao oMoHinhDT = new Business.MoHinhDaoTao();
        Business.CNVC.CNVC_TrinhDoPhoThong oTrinhDoPT = new Business.CNVC.CNVC_TrinhDoPhoThong();
        Business.CNVC.CNVC_QHGiaDinh oQuanHeGD = new Business.CNVC.CNVC_QHGiaDinh();
        Business.CNVC.CNVC_DacDiemLSBanThan oDacDiemBT = new Business.CNVC.CNVC_DacDiemLSBanThan();
        Business.CNVC.CNVC_ChinhTri oChinhTri = new Business.CNVC.CNVC_ChinhTri();
        Business.CNVC.CNVC_File oFile = new Business.CNVC.CNVC_File();


        DataTable dtCNVC, dtCNVCInfoPhu, dtTinhTP, dtTinhTrangHN,
                    dtQTCTNonOUGD , dtQTCTNonOUNonGD , dtTrongOU,
                    dtTTTuyenDung , dtDaoTaoBD , dtChuyenMonTQ,
                    dtMoHinhDT , dtTrinhDoPT, dtQuanHeGD,
                    dtDacDiemBT, dtChinhTri, dtFile;
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

            LoadThongTin();
        }

        public void LoadThongTin()
        {
            
            LoadThongTinTongQuat();
            LoadThongTinBoSung();
            LoadQTCongTac();
        }

        #region xu ly giao dien

            #region TAB THONG TIN

        private void LoadThongTinTongQuat()
        {
            oCNVC.MaNV = MaCNVC;
            dtCNVC = oCNVC.GetData();
            if ((dtCNVC) != null && dtCNVC.Rows.Count > 0)
            {
                txt_MaNV.Text = dtCNVC.Rows[0]["ma_nv"].ToString();
                txt_Ho.Text = dtCNVC.Rows[0]["ho"].ToString();
                txt_Ten.Text = dtCNVC.Rows[0]["ten"].ToString();
                txt_DiaChi.Text = dtCNVC.Rows[0]["dia_chi"].ToString();
                string dt = dtCNVC.Rows[0]["ngay_sinh"].ToString();
                if (!string.IsNullOrWhiteSpace(dt))
                    dTP_NgaySinh.Value = Convert.ToDateTime(dt);
                else
                    dTP_NgaySinh.Checked = false;
                txt_SoSoBHXH.Text = dtCNVC.Rows[0]["so_so_bhxh"].ToString();
                txt_MaSoThue.Text = dtCNVC.Rows[0]["ma_so_thue"].ToString();
                string gioitinh = dtCNVC.Rows[0]["gioi_tinh"].ToString();
                switch (gioitinh)
                {
                    case "true":
                        comB_GioiTinh.SelectedIndex = 1;
                        break;
                    case "false":
                        comB_GioiTinh.SelectedIndex = 0;
                        break;
                    default:
                        comB_GioiTinh.SelectedIndex = 2;
                        break;
                }
            }
            else
            {

            }

        }
        
            #endregion

            #region TAB THONG TIN BO SUNG

        private void LoadThongTinBoSung()
        {
            oCNVCInfoPhu.MaNV = MaCNVC;
            dtCNVCInfoPhu = oCNVCInfoPhu.GetData();
            dtTinhTP = oTinhTP.GetData();
            
            
            dtTinhTrangHN = oTinhTrangHN.GetData();
            if ((dtCNVCInfoPhu) != null && dtCNVCInfoPhu.Rows.Count >0)
            {
                txt_TenGoiKhac.Text = dtCNVCInfoPhu.Rows[0]["ten_goi_khac"].ToString();
                txt_DanToc.Text = dtCNVCInfoPhu.Rows[0]["dan_toc"].ToString();
                txt_TonGiao.Text = dtCNVCInfoPhu.Rows[0]["ton_giao"].ToString();
                txt_NoiSinhXa.Text = dtCNVCInfoPhu.Rows[0]["noi_sinh_xa"].ToString();
                txt_NoiSinhHuyen.Text = dtCNVCInfoPhu.Rows[0]["noi_sinh_huyen"].ToString();
                // comb
                comB_NoiSinhTinh.DataSource = dtTinhTP;
                comB_NoiSinhTinh.DisplayMember = "ten_tinh_tp";
                comB_NoiSinhTinh.ValueMember = "id";

                txt_QueHuyen.Text = dtCNVCInfoPhu.Rows[0]["que_quan_huyen"].ToString();
                txt_QueXa.Text = dtCNVCInfoPhu.Rows[0]["que_quan_xa"].ToString();
                // comb
                comB_QueTinh.DataSource = dtTinhTP;
                comB_QueTinh.DisplayMember = "ten_tinh_tp";
                comB_QueTinh.ValueMember = "id";

                txt_HoKhau.Text = dtCNVCInfoPhu.Rows[0]["noi_dk_hokhau_thuongtru"].ToString();
                txt_ChieuCao.Text = dtCNVCInfoPhu.Rows[0]["chieu_cao"].ToString();
                txt_NhomMau.Text = dtCNVCInfoPhu.Rows[0]["nhom_mau"].ToString();
                // comb
                comB_TinhTrangHonNhan.DataSource = dtTinhTrangHN;
                comB_TinhTrangHonNhan.DisplayMember = "ten";
                comB_TinhTrangHonNhan.ValueMember = "id";


            }


        }
        
            #endregion

            #region TAB QUA TRINH CONG TAC

        private void LoadQTCongTac()
        {
            #region NonOU - GD

            oNonOUGD.MaNV = MaCNVC;
            dtQTCTNonOUGD = oNonOUGD.GetData();
            if ((dtQTCTNonOUGD) != null && dtCNVC.Rows.Count > 0)
            {
                dtgv_TrongGD.DataSource = dtQTCTNonOUGD;
                SetupDataGridView("dtgv_TrongGD");
            }

            #endregion

            #region NonOU - NONGD

            oNonOUNonGD.MaNV = MaCNVC;
            dtQTCTNonOUNonGD = oNonOUNonGD.GetData();
            if ((dtQTCTNonOUNonGD) != null && dtQTCTNonOUNonGD.Rows.Count > 0)
            {
                dtgv_NgoaiGD.DataSource = dtQTCTNonOUNonGD;
                SetupDataGridView("dtgv_NgoaiGD");
            }

            #endregion

            #region Trong GD

            oQTCT.MaNV = MaCNVC;
            dtTrongOU = oQTCT.GetData();
            if ((dtTrongOU) != null && dtTrongOU.Rows.Count > 0)
            {
                dtgv_DHMo.DataSource = dtTrongOU;
                SetupDataGridView("dtgv_TrongOU");
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
        }

            #endregion

            #region TAB DAO TAO BOI DUONG

        private void LoadDaoTaoBD()
        {
            #region Chuyen mon tong quat

            oChuyenMonTQ.MaNV = MaCNVC;
            dtChuyenMonTQ = oChuyenMonTQ.GetData();
            dtMoHinhDT = oMoHinhDT.GetData();
            if ((dtChuyenMonTQ) != null && dtChuyenMonTQ.Rows.Count > 0)
            {
                txt_NgoaiNgu.Text = dtChuyenMonTQ.Rows[0]["ngoai_ngu"].ToString();
                txt_SoTruong.Text = dtChuyenMonTQ.Rows[0]["so_truong_cong_tac"].ToString();
                txt_TinHoc.Text = dtChuyenMonTQ.Rows[0]["tin_hoc"].ToString();
                txt_TrinhDo.Text = dtChuyenMonTQ.Rows[0]["trinh_do_chuyen_mon"].ToString();

                comB_MoHinhDaoTao.DataSource = dtMoHinhDT;
                comB_MoHinhDaoTao.DisplayMember = "ten_mo_hinh";
                comB_MoHinhDaoTao.ValueMember = "id";
            }

            #endregion

            #region Trinh do pho thong

            oDaoTaoBD.MaNV = MaCNVC;
            dtDaoTaoBD = oDaoTaoBD.GetData();
            if ((dtDaoTaoBD) != null && dtDaoTaoBD.Rows.Count > 0)
            {
                dtgv_DaoTaoBoiDuong.DataSource = dtDaoTaoBD;
                SetupDataGridView("dtgv_DaoTaoBoiDuong");
            }

            #endregion

            #region Dao tao boi duong

            oTrinhDoPT.MaNV = MaCNVC;
            dtTrinhDoPT = oTrinhDoPT.GetData();
            if ((dtTrinhDoPT) != null && dtTrinhDoPT.Rows.Count > 0)
            {
                dtgv_TrinhDoPhoThong.DataSource = dtTrinhDoPT;
                SetupDataGridView("dtgv_TrinhDoPhoThong");
            }

            #endregion

           
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
                dtgv_QuanHeGiaDinh.DataSource = dtQuanHeGD;
                SetupDataGridView("dtgv_QuanHeGiaDinh");
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


            #endregion
        }

            #endregion

            #region TAB HOAT DONG CHINH TRI

        private void LoadHoatDongCT()
        {
            oChinhTri.MaNV = MaCNVC;
            dtChinhTri = oChinhTri.GetData();
            if ((dtChinhTri) != null && dtChinhTri.Rows.Count > 0)
            {
                #region DOAN VIEN

                cb_DoanVien.Checked = dtChinhTri.Rows[0]["doan_vien"].ToString() == "True" ? true : false;
                if (cb_DoanVien.Checked)
                {
                    dtp_NgayRaDoan.Enabled = dtp_NgayVaoDoan.Enabled = dtp_NgayTaiNapDoan.Enabled = true;

                    string dt = dtChinhTri.Rows[0]["ngay_vao_doan"].ToString();
                    if (!string.IsNullOrWhiteSpace(dt))
                        dtp_NgayVaoDoan.Value = Convert.ToDateTime(dt);
                    else
                        dtp_NgayVaoDoan.Checked = false;

                    dt = dtChinhTri.Rows[0]["ngay_ra_doan"].ToString();
                    if (!string.IsNullOrWhiteSpace(dt))
                        dtp_NgayRaDoan.Value = Convert.ToDateTime(dt);
                    else
                        dtp_NgayRaDoan.Checked = false;

                    dt = dtChinhTri.Rows[0]["ngay_tai_gia_nhap_doan"].ToString();
                    if (!string.IsNullOrWhiteSpace(dt))
                        dtp_NgayTaiNapDoan.Value = Convert.ToDateTime(dt);
                    else
                        dtp_NgayTaiNapDoan.Checked = false;
                }

                #endregion

                #region DANG VIEN

                cb_DangVien.Checked = dtChinhTri.Rows[0]["dang_vien"].ToString() == "True" ? true : false;
                if (cb_DoanVien.Checked)
                {
                    dtp_NgayVaoDang.Enabled = dtp_NgayRaDang.Enabled = dtp_NgayTaiNapDang.Enabled = true;

                    string dt = dtChinhTri.Rows[0]["ngay_vao_dang"].ToString();
                    if (!string.IsNullOrWhiteSpace(dt))
                        dtp_NgayVaoDang.Value = Convert.ToDateTime(dt);
                    else
                        dtp_NgayVaoDang.Checked = false;

                    dt = dtChinhTri.Rows[0]["ngay_ra_dang"].ToString();
                    if (!string.IsNullOrWhiteSpace(dt))
                        dtp_NgayRaDang.Value = Convert.ToDateTime(dt);
                    else
                        dtp_NgayRaDang.Checked = false;

                    dt = dtChinhTri.Rows[0]["ngay_tai_gia_nhap_dang"].ToString();
                    if (!string.IsNullOrWhiteSpace(dt))
                        dtp_NgayTaiNapDang.Value = Convert.ToDateTime(dt);
                    else
                        dtp_NgayTaiNapDang.Checked = false;
                }

                #endregion

                #region THONG TIN KHAC

                cb_CongDoan.Checked = dtChinhTri.Rows[0]["is_cong_doan_vien"].ToString() == "True" ? true : false;

                string cb = dtChinhTri.Rows[0]["ngay_nhap_ngu"].ToString();
                if (!string.IsNullOrWhiteSpace(cb))
                    dtp_NgayNhapNgu.Value = Convert.ToDateTime(cb);
                else
                    dtp_NgayNhapNgu.Checked = false;

                cb = dtChinhTri.Rows[0]["ngay_xuat_ngu"].ToString();
                if (!string.IsNullOrWhiteSpace(cb))
                    dtp_NgayXuatNgu.Value = Convert.ToDateTime(cb);
                else
                    dtp_NgayXuatNgu.Checked = false;

                txt_QuanHam.Text = dtChinhTri.Rows[0]["quan_ham_cao_nhat"].ToString();
                txt_DanhHieu.Text = dtChinhTri.Rows[0]["danh_hieu_cao_nhat"].ToString();
                txt_QuanLyNhaNuoc.Text = dtChinhTri.Rows[0]["quan_ly_nha_nuoc"].ToString();
                txt_LyLuanChinhTri.Text = dtChinhTri.Rows[0]["ly_luan_chinh_tri"].ToString();
                txt_ThuongBinh.Text = dtChinhTri.Rows[0]["thuong_binh_hang"].ToString();
                txt_GiaDinh.Text = dtChinhTri.Rows[0]["gia_dinh_chinh_sach"].ToString();
                rtb_KhenThuong.Text = dtChinhTri.Rows[0]["khen_thuong"].ToString();
                rtb_KyLuat.Text = dtChinhTri.Rows[0]["ky_luat"].ToString();



                #endregion
 
            }
        }

            #endregion

            #region TAB TAP TIN LIEN QUAN

        private void LoadTapTinLienQuan()
        {
            oFile.MaNV = MaCNVC;
            dtFile = oFile.GetData();
            if ((dtFile) != null && dtFile.Rows.Count > 0)
            {

                dtgv_TapTin.DataSource = dtFile;
                SetupDataGridView("dtgv_TapTin");

            }

        }

            #endregion

        #endregion

        #region ham phu

        private void SetupDataGridView(string dtgv)
        {
            switch (dtgv)
            {
                #region TrongGD

                case "dtgv_TrongGD":
                    dtgv_TrongGD.Columns[0].Visible = dtgv_TrongGD.Columns[1].Visible = false;

                    dtgv_TrongGD.Columns[2].HeaderText = "Tên đơn vị";
                    dtgv_TrongGD.Columns[2].Width = 250;
                    dtgv_TrongGD.Columns[3].HeaderText = "Chức danh";
                    dtgv_TrongGD.Columns[3].Width = 200;
                    dtgv_TrongGD.Columns[4].HeaderText = "Chức vụ";
                    dtgv_TrongGD.Columns[4].Width = 200;
                    dtgv_TrongGD.Columns[5].HeaderText = "Từ ngày";
                    dtgv_TrongGD.Columns[5].Width = 150;
                    dtgv_TrongGD.Columns[6].HeaderText = "Đến ngày";
                    dtgv_TrongGD.Columns[6].Width = 150;
                    dtgv_TrongGD.Columns[7].HeaderText = "Công việc chính";
                    dtgv_TrongGD.Columns[7].Width = 250;

                    break;

                #endregion

                #region Ngoai GD

                case "dtgv_NgoaiGD":
                    dtgv_NgoaiGD.Columns[0].Visible = dtgv_NgoaiGD.Columns[1].Visible = false;

                    dtgv_NgoaiGD.Columns[2].HeaderText = "Tên đơn vị";
                    dtgv_NgoaiGD.Columns[2].Width = 250;
                    dtgv_NgoaiGD.Columns[3].HeaderText = "Chức danh";
                    dtgv_NgoaiGD.Columns[3].Width = 200;
                    dtgv_NgoaiGD.Columns[4].HeaderText = "Chức vụ";
                    dtgv_NgoaiGD.Columns[4].Width = 200;
                    dtgv_NgoaiGD.Columns[5].HeaderText = "Từ ngày";
                    dtgv_NgoaiGD.Columns[5].Width = 150;
                    dtgv_NgoaiGD.Columns[6].HeaderText = "Đến ngày";
                    dtgv_NgoaiGD.Columns[6].Width = 150;
                    dtgv_NgoaiGD.Columns[7].HeaderText = "Công việc chính";
                    dtgv_NgoaiGD.Columns[7].Width = 250;

                    break;

                #endregion

                #region Trong OU

                case "dtgv_TrongOU":
                    dtgv_DHMo.Columns[0].Visible = dtgv_DHMo.Columns[3].Visible = false;

                    dtgv_DHMo.Columns[1].HeaderText = "Hợp đồng";
                    dtgv_DHMo.Columns[1].Width = 250;
                    dtgv_DHMo.Columns[2].HeaderText = "Quyết định";
                    dtgv_DHMo.Columns[2].Width = 200;
                    dtgv_DHMo.Columns[4].HeaderText = "Đơn vị";
                    dtgv_DHMo.Columns[4].Width = 200;
                    dtgv_DHMo.Columns[5].HeaderText = "Chức danh";
                    dtgv_DHMo.Columns[5].Width = 150;
                    dtgv_DHMo.Columns[6].HeaderText = "Chức vụ";
                    dtgv_DHMo.Columns[6].Width = 150;
                    dtgv_DHMo.Columns[7].HeaderText = "Từ ngày";
                    dtgv_DHMo.Columns[7].Width = 100;
                    dtgv_DHMo.Columns[8].HeaderText = "Đến ngày";
                    dtgv_DHMo.Columns[8].Width = 100;
                    dtgv_DHMo.Columns[9].HeaderText = "Tình Trạng";
                    dtgv_DHMo.Columns[9].Width = 50;

                    break;

                #endregion

                #region Dao Tao Boi Duong

                case "dtgv_DaoTaoBoiDuong":

                    dtgv_DaoTaoBoiDuong.Columns[0].Visible = dtgv_DaoTaoBoiDuong.Columns[1].Visible = false;

                    dtgv_DaoTaoBoiDuong.Columns[2].HeaderText = "Tên trường";
                    dtgv_DaoTaoBoiDuong.Columns[2].Width = 200;
                    dtgv_DaoTaoBoiDuong.Columns[3].HeaderText = "Chuyên ngành đào tạo";
                    dtgv_DaoTaoBoiDuong.Columns[3].Width = 250;
                    dtgv_DaoTaoBoiDuong.Columns[4].HeaderText = "Từ ngày";
                    dtgv_DaoTaoBoiDuong.Columns[4].Width = 200;
                    dtgv_DaoTaoBoiDuong.Columns[5].HeaderText = "Đến ngày";
                    dtgv_DaoTaoBoiDuong.Columns[5].Width = 150;
                    dtgv_DaoTaoBoiDuong.Columns[6].HeaderText = "Hình thức đào tạo";
                    dtgv_DaoTaoBoiDuong.Columns[6].Width = 150;
                    dtgv_DaoTaoBoiDuong.Columns[7].HeaderText = "Xếp loại";
                    dtgv_DaoTaoBoiDuong.Columns[7].Width = 100;
                    dtgv_DaoTaoBoiDuong.Columns[8].HeaderText = "Tên chứng chỉ";
                    dtgv_DaoTaoBoiDuong.Columns[8].Width = 100;
                    dtgv_DaoTaoBoiDuong.Columns[9].HeaderText = "Văn bằng";
                    dtgv_DaoTaoBoiDuong.Columns[9].Width = 50;
                    dtgv_DaoTaoBoiDuong.Columns[10].HeaderText = "Tên luận văn";
                    dtgv_DaoTaoBoiDuong.Columns[10].Width = 50;
                    dtgv_DaoTaoBoiDuong.Columns[11].HeaderText = "Hội đồng chấm";
                    dtgv_DaoTaoBoiDuong.Columns[11].Width = 50;

                    break;

                #endregion

                #region Trinh do pho thong

                case "dtgv_TrinhDoPhoThong":

                    dtgv_TrinhDoPhoThong.Columns[0].Visible = dtgv_TrinhDoPhoThong.Columns[1].Visible = false;

                    dtgv_TrinhDoPhoThong.Columns[3].HeaderText = "Trường cấp II";
                    dtgv_TrinhDoPhoThong.Columns[3].Width = 250;
                    dtgv_TrinhDoPhoThong.Columns[2].HeaderText = "Trường cấp I";
                    dtgv_TrinhDoPhoThong.Columns[2].Width = 200;
                    dtgv_TrinhDoPhoThong.Columns[4].HeaderText = "Trường cấp III";
                    dtgv_TrinhDoPhoThong.Columns[4].Width = 200;

                    break;

                #endregion

                #region Quan he gia dinh

                case "dtgv_QuanHeGiaDinh":

                    dtgv_QuanHeGiaDinh.Columns[0].Visible = dtgv_QuanHeGiaDinh.Columns[1].Visible = false;

                    dtgv_QuanHeGiaDinh.Columns[3].HeaderText = "Họ";
                    dtgv_QuanHeGiaDinh.Columns[3].Width = 200;
                    dtgv_QuanHeGiaDinh.Columns[2].HeaderText = "Mối quan hệ";
                    dtgv_QuanHeGiaDinh.Columns[2].Width = 100;
                    dtgv_QuanHeGiaDinh.Columns[4].HeaderText = "Tên";
                    dtgv_QuanHeGiaDinh.Columns[4].Width = 100;
                    dtgv_QuanHeGiaDinh.Columns[5].HeaderText = "Năm sinh";
                    dtgv_QuanHeGiaDinh.Columns[5].Width = 100;
                    dtgv_QuanHeGiaDinh.Columns[6].HeaderText = "Quê Quán";
                    dtgv_QuanHeGiaDinh.Columns[6].Width = 150;
                    dtgv_QuanHeGiaDinh.Columns[7].HeaderText = "Nghề nghiệp";
                    dtgv_QuanHeGiaDinh.Columns[7].Width = 150;
                    dtgv_QuanHeGiaDinh.Columns[8].HeaderText = "Chức danh - chức vụ";
                    dtgv_QuanHeGiaDinh.Columns[8].Width = 200;
                    dtgv_QuanHeGiaDinh.Columns[9].HeaderText = "Đơn vị công tác";
                    dtgv_QuanHeGiaDinh.Columns[9].Width = 200;
                    dtgv_QuanHeGiaDinh.Columns[10].HeaderText = "Địa chỉ";
                    dtgv_QuanHeGiaDinh.Columns[10].Width = 200;
                    dtgv_QuanHeGiaDinh.Columns[11].HeaderText = "Thành viên tổ chức xã hội";
                    dtgv_QuanHeGiaDinh.Columns[11].Width = 200;
                    dtgv_QuanHeGiaDinh.Columns[12].HeaderText = "Học tập";
                    dtgv_QuanHeGiaDinh.Columns[12].Width = 100;
                    dtgv_QuanHeGiaDinh.Columns[13].HeaderText = "Ghi chú";
                    dtgv_QuanHeGiaDinh.Columns[13].Width = 200;

                    break;

                #endregion

                #region FILE

                case "dtgv_TapTin":

                    dtgv_TrongGD.Columns[0].Visible = dtgv_TrongGD.Columns[1].Visible = false;

                    dtgv_TrongGD.Columns[2].HeaderText = "Đường dẫn";
                    dtgv_TrongGD.Columns[2].Width = 400;
                    dtgv_TrongGD.Columns[3].HeaderText = "Mô tả";
                    dtgv_TrongGD.Columns[3].Width = 300;                    

                    break;

                #endregion

                default:
                    break;
            }
        }

        #endregion

    }
}
