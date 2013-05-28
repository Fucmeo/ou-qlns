using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;
using System.Reflection;
using OutlookStyleControls;
using System.Collections;

namespace QLNS.UCs.DanhMucThongTin
{
    public partial class QLNS_ChinhTri : UserControl
    {
        Business.CNVC.CNVC_ChinhTri oChinhTri;
        public DataTable dtChinhTri;

        Business.CNVC.CNVC_ChinhTri oChinhTri_HCCB;
        public DataTable dtChinhTriHCCB;

        Business.CNVC.CNVC_ChinhTri oChinhTri_LoaiCtr;
        public DataTable dtLoaiCtrBasic;

        Business.CNVC.CNVC_ChinhTri oCtr_ToChuc;
        public DataTable dtCTrToChuc;

        Business.CNVC.CNVC_ChinhTri oCtr_ChucVu;
        public DataTable dtCTrChucVu;

        Business.CNVC.CNVC_ChinhTriExt oChinhTriExt;
        public DataTable dtChinhTriExt;
        Business.ChucVu_ChinhTri oChucVu_ChinhTri;
        public DataTable dtChucVu_ChinhTri;
        List<KeyValuePair<GroupBox, float>> lst_gb;

        //string m_ma_nv;
        int old_select_id;
        public static bool is_Modified_Ctri_CVu = true;
        bool bAddFlag_ToChuc;
        bool bAddFlag_ChucVu;

        public QLNS_ChinhTri()
        {
            InitializeComponent();
            oChinhTri = new Business.CNVC.CNVC_ChinhTri();
            dtChinhTri = new DataTable();

            oChinhTri_HCCB = new Business.CNVC.CNVC_ChinhTri();
            dtChinhTriHCCB = new DataTable();

            oChinhTri_LoaiCtr = new Business.CNVC.CNVC_ChinhTri();
            dtLoaiCtrBasic = new DataTable();

            oCtr_ToChuc = new Business.CNVC.CNVC_ChinhTri();
            dtCTrToChuc = new DataTable();

            oChucVu_ChinhTri = new ChucVu_ChinhTri();
            dtChucVu_ChinhTri = new DataTable();

            oCtr_ChucVu = new Business.CNVC.CNVC_ChinhTri();
            dtCTrChucVu = new DataTable();

            //oChinhTriExt = new Business.CNVC.CNVC_ChinhTriExt();
            //oChucVu_ChinhTri = new ChucVu_ChinhTri();
            //dtChinhTriExt = new DataTable();
            //dtChucVu_ChinhTri = new DataTable();
        }

        //public QLNS_ChinhTri(string p_ma_nv)
        //{
        //    InitializeComponent();
        //    oChinhTri = new Business.CNVC.CNVC_ChinhTri();
        //    oChinhTriExt = new Business.CNVC.CNVC_ChinhTriExt();
        //    oChucVu_ChinhTri = new ChucVu_ChinhTri();
            
        //    m_ma_nv = p_ma_nv;
        //}

        private void QLNS_ChinhTri_Load(object sender, EventArgs e)
        {
            //dtgv_DoanDang.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dtgv_DoanDang_DataBindingComplete);

            // KHANG - GROUP DTGV
            //dtgv_DoanDang.SelectionChanged+=new EventHandler(dtgv_DoanDang_SelectionChanged);
            dtgv_DoanDang.CellContentClick += new DataGridViewCellEventHandler(dtgv_DoanDang_CellContentClick);

            gb_InfoChung_HoiCuuCB.MouseClick += new MouseEventHandler(gb_InfoChung_HoiCuuCB_MouseClick);
            gb_LoaiHinhCT.MouseClick += new MouseEventHandler(gb_LoaiHinhCT_MouseClick);
            gb_ToChuc_CV_QTHD.MouseClick += new MouseEventHandler(gb_ToChuc_CV_QTHD_MouseClick);

            lst_gb = new List<KeyValuePair<GroupBox, float>>();
            lst_gb.Add(new KeyValuePair<GroupBox,float>(gb_InfoChung_HoiCuuCB,float.Parse("25")));
            lst_gb.Add(new KeyValuePair<GroupBox, float>(gb_LoaiHinhCT, float.Parse("40")));
            lst_gb.Add(new KeyValuePair<GroupBox, float>(gb_ToChuc_CV_QTHD, float.Parse("35")));

        }

        void gb_ToChuc_CV_QTHD_MouseClick(object sender, MouseEventArgs e)
        {
                Program.CollapseGroupBox((GroupBox)sender, new GroupBox[] { gb_InfoChung_HoiCuuCB, gb_LoaiHinhCT }, tableLP_ChinhTri, 2, this,
                     lst_gb);
            
        }

        void gb_LoaiHinhCT_MouseClick(object sender, MouseEventArgs e)
        {
                Program.CollapseGroupBox((GroupBox)sender, new GroupBox[] { gb_InfoChung_HoiCuuCB, gb_ToChuc_CV_QTHD }, tableLP_ChinhTri, 1, this,
                        lst_gb);
            
        }

        void gb_InfoChung_HoiCuuCB_MouseClick(object sender, MouseEventArgs e)
        {

                Program.CollapseGroupBox(gb_InfoChung_HoiCuuCB, new GroupBox[] { gb_ToChuc_CV_QTHD, gb_LoaiHinhCT }, tableLP_ChinhTri, 0, this,
                        lst_gb);
            
        }

        // KHANG - GROUP DTGV
        void dtgv_DoanDang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_DoanDang.SelectedRows != null && dtgv_DoanDang.SelectedRows.Count > 0)
            {
                    DisplayInfo(dtgv_DoanDang.CurrentRow);              
            }
        }

        public void LoadData(string p_ma_nv)
        {
            //Load_Cbo_ChucVu_ChinhTri();
            Load_Chinh_Tri(p_ma_nv);
            Load_Chinh_Tri_Ext(p_ma_nv);
            Load_Chinh_Tri_HCCB(p_ma_nv);
            Load_Loai_Chinh_Tri_Basic(p_ma_nv);
            Load_To_Chuc(p_ma_nv);
            GetDataChucVu(p_ma_nv);
        }

        void dtgv_DoanDang_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgv_DoanDang.SelectionChanged += new EventHandler(dtgv_DoanDang_SelectionChanged);
        }

        void dtgv_DoanDang_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DoanDang.SelectedRows != null && dtgv_DoanDang.SelectedRows.Count > 0)
            {
                DisplayInfo(dtgv_DoanDang.SelectedRows[0]);
            }
        }

        #region Private Methods
        private void ResetInterface_CTri_To_Chuc(bool init)
        {
            if (init)
            {
                comB_LoaiHinhCT_ToChuc.Enabled = txt_TenToChuc.Enabled = dtp_ToChuc_NgayVao.Enabled = dtp_ToChuc_NgayRa.Enabled = false;
                dtgv_DoanDang.Enabled = listb_DSChucVu.Enabled = true;
                if (dtgv_DoanDang.CurrentRow != null)
                {
                    DisplayInfo(dtgv_DoanDang.CurrentRow);
                }

                lb_Them_ToChuc.Text = "Thêm";
                lb_Sua__ToChuc.Text = "Sửa";
                lb_Xoa_ToChuc.Visible = true;
            }
            else
            {
                comB_LoaiHinhCT_ToChuc.Enabled = txt_TenToChuc.Enabled = dtp_ToChuc_NgayVao.Enabled = dtp_ToChuc_NgayRa.Enabled = true;
                dtgv_DoanDang.Enabled = listb_DSChucVu.Enabled = false;
                if (bAddFlag_ToChuc) // thao tac them moi xoa rong cac field
                {
                    txt_TenToChuc.Text = "";
                }

                lb_Them_ToChuc.Text = "Lưu";
                lb_Sua__ToChuc.Text = "Hủy";
                lb_Xoa_ToChuc.Visible = false;
            }
        }

        private void ResetInterface_CTri_Chuc_Vu(bool init)
        {
            if (init)
            {
                comB_LoaiHinhCT_ChucVu.Enabled = comB_TenToChuc.Enabled = comB_ChucVu.Enabled = dtp_ChucVu_NgayVao.Enabled = dtp_ChucVu_NgayRa.Enabled = false;
                lbl_Them_Chuc_Vu.Text = "Thêm";
                lbl_Sua_Chuc_Vu.Text = "Sửa";
                lbl_Xoa_Chuc_Vu.Visible = true;
                listb_DSChucVu.Enabled = dtgv_DoanDang.Enabled = true;
            }
            else
            {
                comB_LoaiHinhCT_ChucVu.Enabled = comB_TenToChuc.Enabled = comB_ChucVu.Enabled = dtp_ChucVu_NgayVao.Enabled = dtp_ChucVu_NgayRa.Enabled = true;
                lbl_Them_Chuc_Vu.Text = "Lưu";
                lbl_Sua_Chuc_Vu.Text = "Hủy";
                lbl_Xoa_Chuc_Vu.Visible = false;
                listb_DSChucVu.Enabled = dtgv_DoanDang.Enabled = false;
            }
        }

        private void ResetInterface_Chinh_Tri_Info(bool init)
        {
            txt_GiaDinh.Enabled = rTB_KyLuat.Enabled = rtb_KhenThuong.Enabled = init;
        }

        private void ResetInterface_Chinh_Tri_HCCB(bool init)
        {
            txt_QuanHam.Enabled = txt_DanhHieu.Enabled = txt_ThuongBinh.Enabled = rtb_KhenThuong_TrungDoan.Enabled =
                dtp_NgayNhapNgu.Enabled = dtp_NgayXuatNgu.Enabled = cb_ChienDau.Enabled = init;
        }

        private void ResetInterface_Loai_Chinh_Tri_Basic(bool init)
        {
            cb_DangVien.Enabled = cb_DoanVien.Enabled = cb_DanQuan.Enabled = cb_CongDoan.Enabled = init;

            if (cb_DangVien.Checked == true && cb_DangVien.Enabled == true)
                dtp_NgayDuBiLan1.Enabled = dtp_NgayChinhThucLan1.Enabled = dtp_NgayDuBiLan2.Enabled = dtp_NgayChinhThucLan2.Enabled =
                    dtp_DangVien_NgayRa.Enabled = rtb_DangVien_GhiChu.Enabled = txt_NgHD1.Enabled = txt_NgHD2.Enabled = true;
            else
                dtp_NgayDuBiLan1.Enabled = dtp_NgayChinhThucLan1.Enabled = dtp_NgayDuBiLan2.Enabled = dtp_NgayChinhThucLan2.Enabled =
                    dtp_DangVien_NgayRa.Enabled = rtb_DangVien_GhiChu.Enabled = txt_NgHD1.Enabled = txt_NgHD2.Enabled = false;

            if (cb_DoanVien.Checked == true && cb_DoanVien.Enabled == true)
                dtp_KetNapLan1.Enabled = dtp_KetNapLan2.Enabled = dtp_DoanVien_NgayRa.Enabled = rtb_DoanVien_GhiChu.Enabled = true;
            else
                dtp_KetNapLan1.Enabled = dtp_KetNapLan2.Enabled = dtp_DoanVien_NgayRa.Enabled = rtb_DoanVien_GhiChu.Enabled = false;

            if (cb_DanQuan.Checked == true && cb_DanQuan.Enabled == true)
                dtp_DanQuan_NgayVao.Enabled = dtp_DanQuan_NgayRa.Enabled = rtb_DanQuan_GhiChu.Enabled = true;
            else
                dtp_DanQuan_NgayVao.Enabled = dtp_DanQuan_NgayRa.Enabled = rtb_DanQuan_GhiChu.Enabled = false;

            if (cb_CongDoan.Checked == true && cb_CongDoan.Enabled == true)
                dtp_CongDoan_NgayVao.Enabled = dtp_CongDoan_NgayRa.Enabled = rtb_CongDoan_GhiChu.Enabled = true;
            else
                dtp_CongDoan_NgayVao.Enabled = dtp_CongDoan_NgayRa.Enabled = rtb_CongDoan_GhiChu.Enabled = false;
        }

        private void DisplayInfo(DataGridViewRow row)
        {
            try
            {
                comB_LoaiHinhCT_ToChuc.Text = row.Cells["ten_loai_ctr"].Value.ToString();
                txt_TenToChuc.Text = row.Cells["ten_to_chuc"].Value.ToString();

                if (row.Cells["tu_ngay"].Value.ToString() != "")
                {
                    dtp_ToChuc_NgayVao.Checked = true;
                    dtp_ToChuc_NgayVao.Value = Convert.ToDateTime(row.Cells["tu_ngay"].Value.ToString());
                }
                else
                    dtp_ToChuc_NgayVao.Checked = false;

                if (row.Cells["den_ngay"].Value.ToString() != "")
                {
                    dtp_ToChuc_NgayRa.Checked = true;
                    dtp_ToChuc_NgayRa.Value = Convert.ToDateTime(row.Cells["den_ngay"].Value.ToString());
                }
                else
                    dtp_ToChuc_NgayRa.Checked = false;
            }
            catch { }
        }

        private void Load_Cbo_ChucVu_ChinhTri()
        {
            if (is_Modified_Ctri_CVu == true)
            {
                dtChucVu_ChinhTri = oChucVu_ChinhTri.GetData();
                is_Modified_Ctri_CVu = false;
            }
            string selection = comB_LoaiHinhCT_ChucVu.Text;
            if (selection != "")
            {
                var result = (from c in dtChucVu_ChinhTri.AsEnumerable()
                              where c.Field<string>("ten_loai_chinh_tri") == selection
                              select new { id = c.Field<int>("id"), ten_chuc_vu = c.Field<string>("ten_chuc_vu") }).ToList();

                DataTable dt = ToDataTable(result);
                comB_ChucVu.DataSource = dt;
                comB_ChucVu.DisplayMember = "ten_chuc_vu";
                comB_ChucVu.ValueMember = "id";
            }
        }

        private void Load_Chinh_Tri_Ext(string p_ma_nv)
        {
            
        }

        private void Load_Loai_Chinh_Tri_Basic(string p_ma_nv)
        {
            oChinhTri_LoaiCtr.MaNV = p_ma_nv;
            dtLoaiCtrBasic = oChinhTri_LoaiCtr.Get_Loai_Ctr_Basic();

            if (dtLoaiCtrBasic != null && dtLoaiCtrBasic.Rows.Count > 0)
            {
                foreach (DataRow row in dtLoaiCtrBasic.Rows)
                {
                    string ten_loai_ctr = row["ten_loai_ctr"].ToString();
                    switch (ten_loai_ctr)
                    {
                        case "Đoàn viên":
                            cb_DoanVien.Checked = true;
                            #region DoanVien
                            if (row["ngay_ra"].ToString() != "")
                            {
                                dtp_DoanVien_NgayRa.Checked = true;
                                dtp_DoanVien_NgayRa.Value = Convert.ToDateTime(row["ngay_ra"].ToString());
                            }
                            else
                                dtp_DoanVien_NgayRa.Checked = false;

                            if (row["ngay_chinh_thuc_1"].ToString() != "")
                            {
                                dtp_KetNapLan1.Checked = true;
                                dtp_KetNapLan1.Value = Convert.ToDateTime(row["ngay_chinh_thuc_1"].ToString());
                            }
                            else
                                dtp_KetNapLan1.Checked = false;

                            if (row["ngay_chinh_thuc_2"].ToString() != "")
                            {
                                dtp_KetNapLan2.Checked = true;
                                dtp_KetNapLan2.Value = Convert.ToDateTime(row["ngay_chinh_thuc_2"].ToString());
                            }
                            else
                                dtp_KetNapLan2.Checked = false;

                            rtb_DoanVien_GhiChu.Text = row["ghi_chu"].ToString();
                            #endregion

                            break;
                        case "Đảng viên":
                            #region Dang vien
                            cb_DangVien.Checked = true;

                            if (row["ngay_du_bi_1"].ToString() != "")
                            {
                                dtp_NgayDuBiLan1.Checked = true;
                                dtp_NgayDuBiLan1.Value = Convert.ToDateTime(row["ngay_du_bi_1"].ToString());
                            }
                            else
                                dtp_NgayDuBiLan1.Checked = false;

                            if (row["ngay_chinh_thuc_1"].ToString() != "")
                            {
                                dtp_NgayChinhThucLan1.Checked = true;
                                dtp_NgayChinhThucLan1.Value = Convert.ToDateTime(row["ngay_chinh_thuc_1"].ToString());
                            }
                            else
                                dtp_NgayChinhThucLan1.Checked = false;

                            if (row["ngay_du_bi_2"].ToString() != "")
                            {
                                dtp_NgayDuBiLan2.Checked = true;
                                dtp_NgayDuBiLan2.Value = Convert.ToDateTime(row["ngay_du_bi_2"].ToString());
                            }
                            else
                                dtp_NgayDuBiLan2.Checked = false;

                            if (row["ngay_chinh_thuc_2"].ToString() != "")
                            {
                                dtp_NgayChinhThucLan2.Checked = true;
                                dtp_NgayChinhThucLan2.Value = Convert.ToDateTime(row["ngay_chinh_thuc_2"].ToString());
                            }
                            else
                                dtp_NgayChinhThucLan2.Checked = false;

                            if (row["ngay_ra"].ToString() != "")
                            {
                                dtp_DangVien_NgayRa.Checked = true;
                                dtp_DangVien_NgayRa.Value = Convert.ToDateTime(row["ngay_ra"].ToString());
                            }
                            else
                                dtp_DangVien_NgayRa.Checked = false;

                            rtb_DangVien_GhiChu.Text = row["ghi_chu"].ToString();
                            txt_NgHD1.Text = row["nguoi_huong_dan_1"].ToString();
                            txt_NgHD2.Text = row["nguoi_huong_dan_2"].ToString();
                            #endregion

                            break;
                        case "Dân quân tự vệ":
                            cb_DanQuan.Checked = true;
                            #region DanQuanTuVe
                            if (row["ngay_ra"].ToString() != "")
                            {
                                dtp_DanQuan_NgayRa.Checked = true;
                                dtp_DanQuan_NgayRa.Value = Convert.ToDateTime(row["ngay_ra"].ToString());
                            }
                            else
                                dtp_DanQuan_NgayRa.Checked = false;

                            if (row["ngay_chinh_thuc_1"].ToString() != "")
                            {
                                dtp_DanQuan_NgayVao.Checked = true;
                                dtp_DanQuan_NgayVao.Value = Convert.ToDateTime(row["ngay_chinh_thuc_1"].ToString());
                            }
                            else
                                dtp_DanQuan_NgayVao.Checked = false;

                            rtb_DanQuan_GhiChu.Text = row["ghi_chu"].ToString();
                            #endregion

                            break;
                        case "Công đoàn viên":
                            cb_CongDoan.Checked = true;
                            #region CongDoan
                            if (row["ngay_ra"].ToString() != "")
                            {
                                dtp_CongDoan_NgayRa.Checked = true;
                                dtp_CongDoan_NgayRa.Value = Convert.ToDateTime(row["ngay_ra"].ToString());
                            }
                            else
                                dtp_CongDoan_NgayRa.Checked = false;

                            if (row["ngay_chinh_thuc_1"].ToString() != "")
                            {
                                dtp_CongDoan_NgayVao.Checked = true;
                                dtp_CongDoan_NgayVao.Value = Convert.ToDateTime(row["ngay_chinh_thuc_1"].ToString());
                            }
                            else
                                dtp_CongDoan_NgayVao.Checked = false;

                            rtb_CongDoan_GhiChu.Text = row["ghi_chu"].ToString();
                            #endregion

                            break;
                        default:
                            break;
                    }
                }

                ResetInterface_Loai_Chinh_Tri_Basic(false);
            }
        }

        private void Load_Chinh_Tri_HCCB(string p_ma_nv)
        {
            oChinhTri_HCCB.MaNV = p_ma_nv;
            dtChinhTriHCCB = oChinhTri_HCCB.Get_Chinh_Tri_HCCB();

            if (dtChinhTriHCCB != null && dtChinhTriHCCB.Rows.Count > 0)
            {
                txt_QuanHam.Text = dtChinhTriHCCB.Rows[0]["quan_ham_cao_nhat"].ToString();
                txt_DanhHieu.Text = dtChinhTriHCCB.Rows[0]["danh_hieu_cao_nhat"].ToString();
                txt_ThuongBinh.Text = dtChinhTriHCCB.Rows[0]["thuong_binh_hang"].ToString();
                rtb_KhenThuong_TrungDoan.Text = dtChinhTriHCCB.Rows[0]["cap_khen_thuong_nvqs"].ToString();

                if (dtChinhTriHCCB.Rows[0]["ngay_nhap_ngu"].ToString() != "")
                {
                    dtp_NgayNhapNgu.Checked = true;
                    dtp_NgayNhapNgu.Value = Convert.ToDateTime(dtChinhTriHCCB.Rows[0]["ngay_nhap_ngu"].ToString());
                }
                else
                    dtp_NgayNhapNgu.Checked = false;

                if (dtChinhTriHCCB.Rows[0]["ngay_xuat_ngu"].ToString() != "")
                {
                    dtp_NgayXuatNgu.Checked = true;
                    dtp_NgayXuatNgu.Value = Convert.ToDateTime(dtChinhTriHCCB.Rows[0]["ngay_xuat_ngu"].ToString());
                }
                else
                    dtp_NgayXuatNgu.Checked = false;

                if (dtChinhTriHCCB.Rows[0]["tham_gia_chien_dau"].ToString() != "")
                {
                    cb_ChienDau.Checked = Convert.ToBoolean(dtChinhTriHCCB.Rows[0]["tham_gia_chien_dau"].ToString());
                }
                else
                    cb_ChienDau.Checked = false;

                ResetInterface_Chinh_Tri_HCCB(false);

            }
        }

        private void Load_Chinh_Tri(string p_ma_nv)
        {
            oChinhTri.MaNV = p_ma_nv;
            dtChinhTri = oChinhTri.Get_Chinh_Tri_Info();

            if (dtChinhTri != null && dtChinhTri.Rows.Count > 0)
            {               
                txt_GiaDinh.Text = dtChinhTri.Rows[0]["gia_dinh_chinh_sach"].ToString();
                rtb_KhenThuong.Text = dtChinhTri.Rows[0]["khen_thuong"].ToString();
                rTB_KyLuat.Text = dtChinhTri.Rows[0]["ky_luat"].ToString();

            }

            ResetInterface_Chinh_Tri_Info(false);
        }

        private void Load_To_Chuc(string p_ma_nv)
        {
            oCtr_ToChuc.MaNV = p_ma_nv;
            dtCTrToChuc = oCtr_ToChuc.Get_Chinh_Tri_To_Chuc();

            if (dtCTrToChuc != null && dtCTrToChuc.Rows.Count > 0)
            {
                PrepareDataSource();
                EditDtgInterface();
            }
        }

        private void Load_Cbo_ToChuc_ChucVu()
        {
            DataTable dtToChuc = dtCTrToChuc.Copy();
            string selection = comB_LoaiHinhCT_ChucVu.Text;
            if (selection != "")
            {
                var result = (from c in dtToChuc.AsEnumerable()
                              where c.Field<string>("ten_loai_ctr") == selection
                              select new { id = c.Field<int>("id"), ten_to_chuc = c.Field<string>("ten_to_chuc") }).ToList();

                DataTable dt = ToDataTable(result);
                comB_TenToChuc.DataSource = dt;
                comB_TenToChuc.DisplayMember = "ten_to_chuc";
                comB_TenToChuc.ValueMember = "id";
            }
        }

        private void GetDataChucVu(string p_ma_nv)
        {
            oCtr_ChucVu.MaNV = p_ma_nv;
            dtCTrChucVu = oCtr_ChucVu.Get_Chinh_Tri_Chuc_Vu();
        }

        private void Load_Listbox_ChucVu(int p_to_chuc_id)
        {
            try
            {
                var result = (from c in dtCTrChucVu.AsEnumerable()
                              where c.Field<int>("to_chuc_id") == p_to_chuc_id
                              select new { id = c.Field<int>("id"), ten_cv_ctr = c.Field<string>("ten_cv_ctr") }).ToList();

                DataTable dt = ToDataTable(result);
                listb_DSChucVu.DataSource = dt;
                listb_DSChucVu.DisplayMember = "ten_cv_ctr";
                listb_DSChucVu.ValueMember = "id";
            }
            catch { }
        
        }

        private void DisplayInfo_ChucVu(int p_id_tbl_chucvu)
        {
            try
            {
                var result = (from c in dtCTrChucVu.AsEnumerable()
                              where c.Field<int>("id") == p_id_tbl_chucvu
                              select new { id = c.Field<int>("id"), 
                                            to_chuc_id = c.Field<int>("to_chuc_id"),
                                            ten_to_chuc = c.Field<string>("ten_to_chuc"), 
                                            loai_ctr_id = c.Field<int>("loai_ctr_id"),
                                            ten_loai_ctr = c.Field<string>("ten_loai_ctr"),
                                            tu_ngay = c.Field<DateTime?>("tu_ngay"),
                                            den_ngay = c.Field<DateTime?>("den_ngay"),
                                            chuc_vu_id = c.Field<int>("chuc_vu_id"),
                                            ten_cv_ctr = c.Field<string>("ten_cv_ctr") }).ToList();


                DataTable dt = ToDataTable(result);
                
                comB_LoaiHinhCT_ChucVu.Text = dt.Rows[0]["ten_loai_ctr"].ToString();

                Load_Cbo_ChucVu_ChinhTri();
                Load_Cbo_ToChuc_ChucVu();

                comB_TenToChuc.SelectedValue = Convert.ToInt32(dt.Rows[0]["to_chuc_id"].ToString());
                comB_ChucVu.SelectedValue = Convert.ToInt32(dt.Rows[0]["chuc_vu_id"].ToString());
                
                if (dt.Rows[0]["tu_ngay"].ToString() != "")
                    dtp_ChucVu_NgayVao.Value = Convert.ToDateTime(dt.Rows[0]["tu_ngay"].ToString());
                else
                    dtp_ChucVu_NgayVao.Checked = false;
                if (dt.Rows[0]["den_ngay"].ToString() != "")
                    dtp_ChucVu_NgayRa.Value = Convert.ToDateTime(dt.Rows[0]["den_ngay"].ToString());
                else
                    dtp_ChucVu_NgayRa.Checked = false;
            }
            catch { }
        }

        private void PrepareDataSource()
        {
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dtChinhTriExt;
            //dtgv_DoanDang.DataSource = bs;

            // ------- KHANG - replace DTGV by OUTLOOK GRID
            DataTable dt = dtCTrToChuc.Copy();
            dt.TableName = "dt";
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            dtgv_DoanDang.BindData(ds, "dt");

            ///////////// SORT _ GROUP ////////////////

            // set the group template to use, e.g. to sort alphabetically:
            dtgv_DoanDang.GroupTemplate = new OutlookgGridDefaultGroup();

            // specify the column the Group will be associated with:
            dtgv_DoanDang.GroupTemplate.Column = dtgv_DoanDang.Columns["ten_loai_ctr"];

            // all groups in the list will be collapsed,
            // so only the groups are displayed, not the items
            dtgv_DoanDang.GroupTemplate.Collapsed = true;

            // sort the grid using the DataRowComparer object
            // the DataRowComparer constructor takes two parameters,
            // the column that will be sorted on, and the direction
            // in which to sort (ascending or descending)
            dtgv_DoanDang.Sort(new DataRowComparer(dtgv_DoanDang.Columns["ten_loai_ctr"].Index, ListSortDirection.Ascending));
        }

        private void EditDtgInterface()
        {
            dtgv_DoanDang.Columns["ten_loai_ctr"].HeaderText = "Loại";
            dtgv_DoanDang.Columns["ten_to_chuc"].HeaderText = "Tên tổ chức";
            dtgv_DoanDang.Columns["ten_to_chuc"].Width = 200;
            dtgv_DoanDang.Columns["tu_ngay"].HeaderText = "Bắt đầu sinh hoạt từ";
            dtgv_DoanDang.Columns["tu_ngay"].Width = 200;
            dtgv_DoanDang.Columns["den_ngay"].HeaderText = "Kết thúc sinh hoạt";
            dtgv_DoanDang.Columns["den_ngay"].Width = 200;

            dtgv_DoanDang.Columns["id"].Visible = false;
            dtgv_DoanDang.Columns["ma_nv"].Visible = false;
            dtgv_DoanDang.Columns["loai_ctr_id"].Visible = false;
            dtgv_DoanDang.Columns["ghi_chu"].Visible = false;
        }

        #region Convert List to Data Table
        private DataTable ToDataTable<T>(List<T> items)
        {
            var table = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                table.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                table.Rows.Add(values);
            }

            return table;
        }
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
        #endregion

        #endregion

        private void btn_Luu_ThongTinChung_Click(object sender, EventArgs e)
        {
            if (btn_Luu_ThongTinChung.ImageKey == "Edit Data.png")
            {
                ResetInterface_Chinh_Tri_Info(true);
                btn_Luu_ThongTinChung.ImageKey = "Save.png";
            }
            else
            {
                if (Program.selected_ma_nv != "")
                {
                    oChinhTri = new Business.CNVC.CNVC_ChinhTri();
                    oChinhTri.MaNV = Program.selected_ma_nv;
                    oChinhTri.GiaDinhChinhSach = txt_GiaDinh.Text;
                    oChinhTri.KhenThuong = rtb_KhenThuong.Text;
                    oChinhTri.KyLuat = rTB_KyLuat.Text;
                    
                    try
                    {
                        if (MessageBox.Show("Bạn thực sự muốn lưu thông tin chính trị chung cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (oChinhTri.Save_Chinh_Tri_Info())
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

                    ResetInterface_Chinh_Tri_Info(false);
                    btn_Luu_ThongTinChung.ImageKey = "Edit Data.png";
                }
                else
                {
                    MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
            
        }

        
        private void comB_Loai_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Cbo_ChucVu_ChinhTri();
        }

        private void lbl_ThemChucVuMoi_Click(object sender, EventArgs e)
        {
            QLNS.UCs.QLNS_ChucVu_ChinhTri chuc_vu_chtri = new QLNS_ChucVu_ChinhTri();
            QLNS.Forms.Popup popup = new Forms.Popup("Thêm chức vụ chính trị", chuc_vu_chtri);
            popup.ShowDialog();
            if (is_Modified_Ctri_CVu == true)
                Reload_Combo_ChucVu_ChinhTri();
        }

        private void Reload_Combo_ChucVu_ChinhTri()
        {
            Load_Cbo_ChucVu_ChinhTri();            
        
        }

        private void btn_Luu_HoiCB_Click(object sender, EventArgs e)
        {
            if (btn_Luu_HoiCB.ImageKey == "Edit Data.png")
            {
                ResetInterface_Chinh_Tri_HCCB(true);
                btn_Luu_HoiCB.ImageKey = "Save.png";
            }
            else
            {
                if (Program.selected_ma_nv != "")
                {
                    oChinhTri_HCCB = new Business.CNVC.CNVC_ChinhTri();
                    oChinhTri_HCCB.MaNV = Program.selected_ma_nv;
                    oChinhTri_HCCB.QuanHamCaoNhat = txt_QuanHam.Text;
                    oChinhTri_HCCB.DanhHieuCaoNhat = txt_DanhHieu.Text;
                    oChinhTri_HCCB.ThuongBinhHang = txt_ThuongBinh.Text;
                    oChinhTri_HCCB.CapKhenThuongNVQS = rtb_KhenThuong_TrungDoan.Text;

                    oChinhTri_HCCB.ThamGiaChienDau = cb_ChienDau.Checked;

                    if (dtp_NgayNhapNgu.Checked)
                        oChinhTri_HCCB.NgayNhapNgu = dtp_NgayNhapNgu.Value;
                    else
                        oChinhTri_HCCB.NgayNhapNgu = null;

                    if (dtp_NgayXuatNgu.Checked)
                        oChinhTri_HCCB.NgayXuatNgu = dtp_NgayXuatNgu.Value;
                    else
                        oChinhTri_HCCB.NgayXuatNgu = null;

                    try
                    {
                        if (MessageBox.Show("Bạn thực sự muốn lưu thông tin hội cựu chiến binh cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (oChinhTri_HCCB.Save_Chinh_Tri_HCCB())
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

                    ResetInterface_Chinh_Tri_HCCB(false);
                    btn_Luu_HoiCB.ImageKey = "Edit Data.png";
                }
                else
                {
                    MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_Luu_Loai_CT_Click(object sender, EventArgs e)
        {
            if (btn_Luu_Loai_CT.ImageKey == "Edit Data.png")
            {
                ResetInterface_Loai_Chinh_Tri_Basic(true);
                btn_Luu_Loai_CT.ImageKey = "Save.png";
            }
            else
            {
                if (Program.selected_ma_nv != "")
                {
                    oChinhTri_LoaiCtr = new Business.CNVC.CNVC_ChinhTri();
                    oChinhTri_LoaiCtr.MaNV = Program.selected_ma_nv;

                    List<int> loai_ctr = new List<int>();
                    List<string> du_bi_1 = new List<string>();
                    List<string> chinh_thuc_1 = new List<string>();
                    List<string> du_bi_2 = new List<string>();
                    List<string> chinh_thuc_2 = new List<string>();
                    List<string> ngay_ra = new List<string>();
                    List<string> ghi_chu = new List<string>();
                    List<string> nguoi_huong_dan1 = new List<string>();
                    List<string> nguoi_huong_dan2 = new List<string>();


                    if (cb_DangVien.Checked)
                    {
                        loai_ctr.Add(2);

                        if (dtp_NgayDuBiLan1.Checked == true)
                            du_bi_1.Add(dtp_NgayDuBiLan1.Value.ToShortDateString());
                        else
                            du_bi_1.Add(null);

                        if (dtp_NgayChinhThucLan1.Checked == true)
                            chinh_thuc_1.Add(dtp_NgayChinhThucLan1.Value.ToShortDateString());
                        else
                            chinh_thuc_1.Add(null);

                        if (dtp_NgayDuBiLan2.Checked == true)
                            du_bi_2.Add(dtp_NgayDuBiLan2.Value.ToShortDateString());
                        else
                            du_bi_2.Add(null);

                        if (dtp_NgayChinhThucLan2.Checked == true)
                            chinh_thuc_2.Add(dtp_NgayChinhThucLan2.Value.ToShortDateString());
                        else
                            chinh_thuc_2.Add(null);

                        if (dtp_DangVien_NgayRa.Checked == true)
                            ngay_ra.Add(dtp_DangVien_NgayRa.Value.ToShortDateString());
                        else
                            ngay_ra.Add(null);

                        ghi_chu.Add(rtb_DangVien_GhiChu.Text);
                        nguoi_huong_dan1.Add(txt_NgHD1.Text);
                        nguoi_huong_dan2.Add(txt_NgHD2.Text);
                    }

                    if (cb_DoanVien.Checked)
                    {
                        loai_ctr.Add(1);

                        if (dtp_KetNapLan1.Checked == true)
                            chinh_thuc_1.Add(dtp_KetNapLan1.Value.ToShortDateString());
                        else
                            chinh_thuc_1.Add(null);

                        if (dtp_KetNapLan2.Checked == true)
                            chinh_thuc_2.Add(dtp_KetNapLan2.Value.ToShortDateString());
                        else
                            chinh_thuc_2.Add(null);

                        if (dtp_DoanVien_NgayRa.Checked == true)
                            ngay_ra.Add(dtp_DoanVien_NgayRa.Value.ToShortDateString());
                        else
                            ngay_ra.Add(null);

                        ghi_chu.Add(rtb_DoanVien_GhiChu.Text);
                        nguoi_huong_dan1.Add(null);
                        nguoi_huong_dan2.Add(null);
                    }

                    if (cb_DanQuan.Checked)
                    {
                        loai_ctr.Add(3);

                        if (dtp_DanQuan_NgayVao.Checked == true)
                            chinh_thuc_1.Add(dtp_DanQuan_NgayVao.Value.ToShortDateString());
                        else
                            chinh_thuc_1.Add(null);

                        if (dtp_DanQuan_NgayRa.Checked == true)
                            ngay_ra.Add(dtp_DanQuan_NgayRa.Value.ToShortDateString());
                        else
                            ngay_ra.Add(null);

                        ghi_chu.Add(rtb_DanQuan_GhiChu.Text);
                        nguoi_huong_dan1.Add(null);
                        nguoi_huong_dan2.Add(null);
                    }

                    if (cb_CongDoan.Checked)
                    {
                        loai_ctr.Add(4);

                        if (dtp_CongDoan_NgayVao.Checked == true)
                            chinh_thuc_1.Add(dtp_CongDoan_NgayVao.Value.ToShortDateString());
                        else
                            chinh_thuc_1.Add(null);

                        if (dtp_CongDoan_NgayRa.Checked == true)
                            ngay_ra.Add(dtp_CongDoan_NgayRa.Value.ToShortDateString());
                        else
                            ngay_ra.Add(null);

                        ghi_chu.Add(rtb_CongDoan_GhiChu.Text);
                        nguoi_huong_dan1.Add(null);
                        nguoi_huong_dan2.Add(null);
                    }

                    try
                    {
                        if (MessageBox.Show("Bạn thực sự muốn lưu thông tin chính trị cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            oChinhTri_LoaiCtr.NgayDuBi_1 = du_bi_1.ToArray();
                            oChinhTri_LoaiCtr.NgayChinhThuc_1 = chinh_thuc_1.ToArray();
                            oChinhTri_LoaiCtr.NgayDuBi_2 = du_bi_2.ToArray();
                            oChinhTri_LoaiCtr.NgayChinhThuc_2 = chinh_thuc_2.ToArray();
                            oChinhTri_LoaiCtr.NgayRa = ngay_ra.ToArray();
                            oChinhTri_LoaiCtr.GhiChu_Ctr_Basic = ghi_chu.ToArray();
                            oChinhTri_LoaiCtr.NguoiHuongDan1 = nguoi_huong_dan1.ToArray();
                            oChinhTri_LoaiCtr.NguoiHuongDan2 = nguoi_huong_dan2.ToArray();

                            if (oChinhTri_LoaiCtr.Save_Loai_Chinh_Tri_Basic(loai_ctr.ToArray()))
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

                    ResetInterface_Loai_Chinh_Tri_Basic(false);
                    btn_Luu_Loai_CT.ImageKey = "Edit Data.png";
                }
                else
                {
                    MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cb_DangVien_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_DangVien.Checked == true && cb_DangVien.Enabled == true)
                dtp_NgayDuBiLan1.Enabled = dtp_NgayChinhThucLan1.Enabled = dtp_NgayDuBiLan2.Enabled = dtp_NgayChinhThucLan2.Enabled =
                    dtp_DangVien_NgayRa.Enabled = true;
            else
                dtp_NgayDuBiLan1.Enabled = dtp_NgayChinhThucLan1.Enabled = dtp_NgayDuBiLan2.Enabled = dtp_NgayChinhThucLan2.Enabled =
                    dtp_DangVien_NgayRa.Enabled = false;
        }

        private void cb_DoanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_DoanVien.Checked == true && cb_DoanVien.Enabled == true)
                dtp_KetNapLan1.Enabled = dtp_KetNapLan2.Enabled = dtp_DoanVien_NgayRa.Enabled = true;
            else
                dtp_KetNapLan1.Enabled = dtp_KetNapLan2.Enabled = dtp_DoanVien_NgayRa.Enabled = false;
        }

        private void cb_DanQuan_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_DanQuan.Checked == true && cb_DanQuan.Enabled == true)
                dtp_DanQuan_NgayVao.Enabled = dtp_DanQuan_NgayRa.Enabled = true;
            else
                dtp_DanQuan_NgayVao.Enabled = dtp_DanQuan_NgayRa.Enabled = false;
        }

        private void cb_CongDoan_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_CongDoan.Checked == true && cb_CongDoan.Enabled == true)
                dtp_CongDoan_NgayVao.Enabled = dtp_CongDoan_NgayRa.Enabled = true;
            else
                dtp_CongDoan_NgayVao.Enabled = dtp_CongDoan_NgayRa.Enabled = false;
        }

        private void lb_Them_ToChuc_Click(object sender, EventArgs e)
        {
            if (Program.selected_ma_nv != "")
            {

                if (lb_Them_ToChuc.Text == "Thêm")
                {
                    bAddFlag_ToChuc = true;
                    ResetInterface_CTri_To_Chuc(false);
                    //old_select_id = 0;
                }
                else //chức năng Lưu
                {
                    oCtr_ToChuc = new Business.CNVC.CNVC_ChinhTri();
                    oCtr_ToChuc.MaNV = Program.selected_ma_nv;
                    oCtr_ToChuc.TenToChuc = txt_TenToChuc.Text;

                    string loai_ctr = comB_LoaiHinhCT_ToChuc.Text;
                    switch (loai_ctr)
                    {
                        case "Đoàn viên":
                            oCtr_ToChuc.LoaiChinhTriID = 1;
                            break;
                        case "Đảng viên":
                            oCtr_ToChuc.LoaiChinhTriID = 2;
                            break;
                        case "Dân quân tự vệ":
                            oCtr_ToChuc.LoaiChinhTriID = 3;
                            break;
                        case "Công đoàn viên":
                            oCtr_ToChuc.LoaiChinhTriID = 4;
                            break;
                        default:
                            break;
                    }

                    if (dtp_ToChuc_NgayVao.Checked == true)
                        oCtr_ToChuc.BatDauSinhHoat = dtp_ToChuc_NgayVao.Value;
                    if (dtp_ToChuc_NgayRa.Checked == true)
                        oCtr_ToChuc.KetThucSinhHoat = dtp_ToChuc_NgayRa.Value;


                    #region thao tac them
                    if (bAddFlag_ToChuc)
                    {
                        if (MessageBox.Show("Bạn thực sự muốn thêm hoạt động chính trị của nhân viên?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                if (oCtr_ToChuc.Add_To_Chuc())
                                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Thao tác thêm thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                    #endregion

                    #region thao tac sua
                    else                // thao tac sua
                    {
                        if (MessageBox.Show("Bạn thực sự muốn sửa hoạt động chính trị này của nhân viên?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                oCtr_ToChuc.ToChuc_ID = Convert.ToInt32(dtgv_DoanDang.CurrentRow.Cells["id"].Value.ToString());
                                if (oCtr_ToChuc.Update_To_Chuc())
                                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Thao tác sửa thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    #endregion

                    //old_select_id = 0;
                    Load_To_Chuc(Program.selected_ma_nv);
                    ResetInterface_CTri_To_Chuc(true);
                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lb_Sua__ToChuc_Click(object sender, EventArgs e)
        {
            if (Program.selected_ma_nv != "")
            {
                if (lb_Sua__ToChuc.Text == "Sửa")
                {
                    bAddFlag_ToChuc = false;
                    ResetInterface_CTri_To_Chuc(false);
                    //old_select_id = 0;
                }
                else if (lb_Sua__ToChuc.Text == "Hủy")
                {
                    ResetInterface_CTri_To_Chuc(true);
                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lb_Xoa_ToChuc_Click(object sender, EventArgs e)
        {
            if (dtgv_DoanDang.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá thông tin chính trị này của nhân viên?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oCtr_ToChuc.ToChuc_ID = Convert.ToInt16(dtgv_DoanDang.CurrentRow.Cells["id"].Value.ToString());
                        if (oCtr_ToChuc.Delete_To_Chuc())
                            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //old_select_id = 0;
                        Load_To_Chuc(Program.selected_ma_nv);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void dtgv_DoanDang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgv_DoanDang.SelectedRows != null && dtgv_DoanDang.SelectedRows.Count > 0)
                {
                    DisplayInfo(dtgv_DoanDang.CurrentRow);
                    Load_Listbox_ChucVu(Convert.ToInt32(dtgv_DoanDang.CurrentRow.Cells["id"].Value.ToString()));
                }
            }
            catch { }
        }

        private void lbl_ThemChucVu_Click_1(object sender, EventArgs e)
        {
            QLNS.UCs.QLNS_ChucVu_ChinhTri chuc_vu_chtri = new QLNS_ChucVu_ChinhTri();
            QLNS.Forms.Popup popup = new Forms.Popup("Thêm chức vụ chính trị", chuc_vu_chtri);
            popup.ShowDialog();
            if (is_Modified_Ctri_CVu == true)
                Reload_Combo_ChucVu_ChinhTri();
        }

        private void comB_LoaiHinhCT_ChucVu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_Cbo_ChucVu_ChinhTri();
            Load_Cbo_ToChuc_ChucVu();
        }

        private void lbl_Them_Chuc_Vu_Click(object sender, EventArgs e)
        {
            if (Program.selected_ma_nv != "")
            {

                if (lbl_Them_Chuc_Vu.Text == "Thêm")
                {
                    bAddFlag_ChucVu = true;
                    ResetInterface_CTri_Chuc_Vu(false);
                    //old_select_id = 0;
                }
                else //chức năng Lưu
                {
                    oCtr_ChucVu = new Business.CNVC.CNVC_ChinhTri();
                    oCtr_ChucVu.ToChuc_ID = Convert.ToInt32(comB_TenToChuc.SelectedValue.ToString());
                    if (dtp_ChucVu_NgayVao.Checked == true)
                        oCtr_ChucVu.TuNgay = dtp_ChucVu_NgayVao.Value;
                    if (dtp_ChucVu_NgayRa.Checked == true)
                        oCtr_ChucVu.DenNgay = dtp_ChucVu_NgayRa.Value;
                    oCtr_ChucVu.ChucVuID = Convert.ToInt32(comB_ChucVu.SelectedValue.ToString());
                    #region thao tac them
                    if (bAddFlag_ChucVu)
                    {
                        if (MessageBox.Show("Bạn thực sự muốn thêm chức vụ chính trị của nhân viên?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                if (oCtr_ChucVu.Add_Chuc_Vu())
                                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //old_select_id = 0;
                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Thao tác thêm thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                    #endregion

                    #region thao tac sua
                    else                // thao tac sua
                    {
                        if (MessageBox.Show("Bạn thực sự muốn sửa chức vụ chính trị này của nhân viên?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                oCtr_ChucVu.ID_TblChucVu = Convert.ToInt32(listb_DSChucVu.SelectedValue.ToString());
                                if (oCtr_ChucVu.Update_Chuc_Vu())
                                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //old_select_id = 0;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Thao tác sửa thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    #endregion

                    //Load_Chinh_Tri_Ext(Program.selected_ma_nv);
                    GetDataChucVu(Program.selected_ma_nv);
                    ResetInterface_CTri_Chuc_Vu(true);
                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lbl_Sua_Chuc_Vu_Click(object sender, EventArgs e)
        {
            if (Program.selected_ma_nv != "")
            {
                if (lbl_Sua_Chuc_Vu.Text == "Sửa")
                {
                    bAddFlag_ChucVu = false;
                    ResetInterface_CTri_Chuc_Vu(false);
                    //old_select_id = 0;
                }
                else if (lbl_Sua_Chuc_Vu.Text == "Hủy")
                {
                    ResetInterface_CTri_Chuc_Vu(true);
                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listb_DSChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DisplayInfo_ChucVu(Convert.ToInt32(listb_DSChucVu.SelectedValue.ToString()));
            }
            catch { }
        }

        private void lbl_Xoa_Chuc_Vu_Click(object sender, EventArgs e)
        {
            if (listb_DSChucVu.SelectedValue.ToString() != "")
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá chức vụ chính trị này của nhân viên?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oCtr_ChucVu.ID_TblChucVu = Convert.ToInt32(listb_DSChucVu.SelectedValue.ToString());
                        if (oCtr_ChucVu.Delete_Chuc_Vu())
                            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //old_select_id = 0;                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    GetDataChucVu(Program.selected_ma_nv);
                    ResetInterface_CTri_Chuc_Vu(true);
                }
            }
        }

        
    }

    #region Comparers - used to sort CustomerInfo objects and DataRows of a DataTable

    /// <summary>
    /// reusable custom DataRow comparer implementation, can be used to sort DataTables
    /// </summary>
    public class DataRowComparer : IComparer
    {
        ListSortDirection direction;
        int columnIndex;

        public DataRowComparer(int columnIndex, ListSortDirection direction)
        {
            this.columnIndex = columnIndex;
            this.direction = direction;
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {

            DataRow obj1 = (DataRow)x;
            DataRow obj2 = (DataRow)y;
            return string.Compare(obj1[columnIndex].ToString(), obj2[columnIndex].ToString()) * (direction == ListSortDirection.Ascending ? 1 : -1);
        }
        #endregion
    }

    // custom object comparer implementation
    public class ContactInfoComparer : IComparer
    {
        private int propertyIndex;
        ListSortDirection direction;

        public ContactInfoComparer(int propertyIndex, ListSortDirection direction)
        {
            this.propertyIndex = propertyIndex;
            this.direction = direction;
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {
            ContactInfo obj1 = (ContactInfo)x;
            ContactInfo obj2 = (ContactInfo)y;

            switch (propertyIndex)
            {
                case 1:
                    return CompareStrings(obj1.Name, obj2.Name);
                case 2:
                    return CompareDates(obj1.Date, obj2.Date);
                case 3:
                    return CompareStrings(obj1.Subject, obj2.Subject);
                case 4:
                    return CompareNumbers(obj1.Concentration, obj2.Concentration);
                default:
                    return CompareNumbers((double)obj1.Id, (double)obj2.Id);
            }
        }
        #endregion

        private int CompareStrings(string val1, string val2)
        {
            return string.Compare(val1, val2) * (direction == ListSortDirection.Ascending ? 1 : -1);
        }

        private int CompareDates(DateTime val1, DateTime val2)
        {
            if (val1 > val2) return (direction == ListSortDirection.Ascending ? 1 : -1);
            if (val1 < val2) return (direction == ListSortDirection.Ascending ? -1 : 1);
            return 0;
        }

        private int CompareNumbers(double val1, double val2)
        {
            if (val1 > val2) return (direction == ListSortDirection.Ascending ? 1 : -1);
            if (val1 < val2) return (direction == ListSortDirection.Ascending ? -1 : 1);
            return 0;
        }
    }
    #endregion Comparers

    #region ContactInfo - example business object implementation
    public class ContactInfo
    {
        public ContactInfo()
        {
        }
        public ContactInfo(int id, string name, DateTime date, string subject, double con)
        {
            this.id = id;
            this.name = name;
            this.date = date;
            this.subject = subject;
            this.concentration = con;
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        private double concentration;

        public double Concentration
        {
            get { return concentration; }
            set { concentration = value; }
        }

    }

    #endregion  
}
