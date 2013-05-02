using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.CNVC;


namespace QLNS.UCs.DanhMucThongTin
{
    public partial class QLNS_DaoTaoBoiDuong : UserControl
    {
        public CNVC_DaoTaoBoiDuong oCNVC_DaoTaoBoiDuong;
        public Business.HinhThucDaoTao oHinhThucDaoTao;
        public Business.VanBangChinhQuy oVanBangChinhQuy;
        public Business.MoHinhDaoTao oMoHinh;
        Business.TinhTP oTinhTP;
        Business.QuocGia oQuocGia;
        public DataTable dtTinhTP, dtQuocGia, dtDaoTaoBoiDuong, dtDaoTao, dtBoiDuong, dtHinhThuc, dtVanBang , dtMoHinh;

        bool bAddDaoTaoFlag = false;
        bool bAddBoiDuongFlag = false;

        public static int nNewTinhTPID = 0;     // ID cua tinh thanh pho moi them vao
        public static int nNewQuocGiaID = 0;     // ID cua quoc gia moi them vao

        public QLNS_DaoTaoBoiDuong()
        {
            InitializeComponent();
            oCNVC_DaoTaoBoiDuong = new CNVC_DaoTaoBoiDuong();
            oHinhThucDaoTao = new Business.HinhThucDaoTao();
            oVanBangChinhQuy = new Business.VanBangChinhQuy();
            oMoHinh = new Business.MoHinhDaoTao();
            dtDaoTaoBoiDuong = new DataTable();
            dtHinhThuc = new DataTable();
            dtDaoTao = new DataTable();
            dtBoiDuong = new DataTable();
            dtVanBang = new DataTable();
            dtTinhTP = new DataTable();
            dtQuocGia = new DataTable();
            dtMoHinh = new DataTable();
            oTinhTP = new Business.TinhTP();
            oQuocGia = new Business.QuocGia();
        }

        public void GetDaoTaoBoiDuongInfo(string m_MaNV)
        {
            oCNVC_DaoTaoBoiDuong.MaNV = m_MaNV;
            dtDaoTaoBoiDuong = oCNVC_DaoTaoBoiDuong.GetData();
            if (dtDaoTaoBoiDuong.Rows.Count > 0)
            {
                var t = dtDaoTaoBoiDuong.AsEnumerable().Where(a => a.Field<int?>("hinh_thuc_dao_tao_id").ToString() != "");
                if (t.Count() > 0)
                {
                    dtDaoTao = t.CopyToDataTable();
                }
                t = dtDaoTaoBoiDuong.AsEnumerable().Where(a => a.Field<int?>("hinh_thuc_dao_tao_id").ToString() == "");
                if (t.Count() > 0)
                {
                    dtBoiDuong = t.CopyToDataTable();
                }

            }
        }

        private void QLNS_DaoTaoBoiDuong_Load(object sender, EventArgs e)
        {
            GetComboData();

            SetupComboDS();

            LoadHinhThucData();
            LoadVanBangData();
            LoadMoHinhData();

        }

        #region Xu ly tinh tp

        public void GetComboData()
        {
            dtTinhTP = oTinhTP.GetData();
            dtQuocGia = oQuocGia.GetData();
        }

        public void SetupComboDS()
        {
            SetupTinhDS();

            #region Quoc Gia
            DataTable dt4 = dtQuocGia.Copy();
            if (dt4.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt4.NewRow();
                dr["ten_quoc_gia"] = "";
                dr["id"] = -1;
                dt4.Rows.Add(dr);
            }
            comB_QuocGia_DaoTao.DataSource = dt4;
            comB_QuocGia_DaoTao.DisplayMember = "ten_quoc_gia";
            comB_QuocGia_DaoTao.ValueMember = "id";

            DataTable dt5 = dt4.Copy();

            comB_QuocGia_BoiDuong.DataSource = dt5;
            comB_QuocGia_BoiDuong.DisplayMember = "ten_quoc_gia";
            comB_QuocGia_BoiDuong.ValueMember = "id";


            #endregion

        }

        public void SetupTinhDS()
        {
            #region Tinh TP
            DataTable dt = dtTinhTP.Copy();
            if (dt.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt.NewRow();
                dr["ten_tinh_tp"] = "";
                dr["id"] = -1;
                dr["quoc_gia_id"] = -1;
                dt.Rows.Add(dr);
            }

            comB_Tinh_BoiDuong.DataSource = dt;
            comB_Tinh_BoiDuong.DisplayMember = "ten_tinh_tp";
            comB_Tinh_BoiDuong.ValueMember = "id";

            DataTable dt2 = dt.Copy();
            comB_Tinh_DaoTao.DataSource = dt2;
            comB_Tinh_DaoTao.DisplayMember = "ten_tinh_tp";
            comB_Tinh_DaoTao.ValueMember = "id";

            #endregion
        }

        private void comB_QuocGia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (((ComboBox)sender).Name)
            {
                case "comB_QuocGia_DaoTao":
                    ChangeTinhCombByQuocGia(comB_QuocGia_DaoTao, comB_Tinh_DaoTao);
                    break;

                case "comB_QuocGia_BoiDuong":
                    ChangeTinhCombByQuocGia(comB_QuocGia_BoiDuong, comB_Tinh_BoiDuong);
                    break;

                default:
                    break;
            }
        }

        private void ChangeTinhCombByQuocGia(ComboBox Comb_QuocGia, ComboBox Comb_Tinh)
        {
            int v = Convert.ToInt32(Comb_QuocGia.SelectedValue);

            if (v == -1)    // combo quoc gia rong
            {
                LoadTinhData(dtTinhTP, Comb_Tinh);
            }
            else
            {
                var dt = dtTinhTP.AsEnumerable().Where(a => a.Field<int>("quoc_gia_id") == v);
                if (dt != null && dt.Count() > 0)
                {
                    LoadTinhData(dt.CopyToDataTable(), Comb_Tinh);
                }
                else
                {
                    LoadTinhData(null, Comb_Tinh);
                }
            }
        }

        public void LoadTinhData(DataTable dt, ComboBox Comb_Tinh)
        {
            if (dt == null || dt.Rows.Count == 0)        // de phong TH quoc gia dang chon khong co tp
            {
                dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id", typeof(int)), new DataColumn("ten_tinh_tp", typeof(string)), 
                                                        new DataColumn("quoc_gia_id", typeof(int)) });
            }
            if (dt.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt.NewRow();
                dr["ten_tinh_tp"] = "";
                dr["id"] = -1;
                dr["quoc_gia_id"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }

            // comb
            Comb_Tinh.DataSource = dt;
            Comb_Tinh.DisplayMember = "ten_tinh_tp";
            Comb_Tinh.ValueMember = "id";

        }

        private void comB_Tinh_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int v = Convert.ToInt32(((ComboBox)sender).SelectedValue);

            if (v != -1)    // combo tinh khac rong
            {
                var ids = from c in dtTinhTP.AsEnumerable()
                          where c.Field<int>("id") == v
                          select c.Field<int>("quoc_gia_id");

                int quoc_gia_id = ids.ElementAt<int>(0);

                switch (((ComboBox)sender).Name)
                {
                    case "comB_Tinh_DaoTao":
                        comB_QuocGia_DaoTao.SelectedValue = quoc_gia_id;
                        ExcludeTinhData(comB_Tinh_DaoTao, quoc_gia_id, v);
                        break;

                    case "comB_Tinh_BoiDuong":
                        comB_QuocGia_BoiDuong.SelectedValue = quoc_gia_id;
                        ExcludeTinhData(comB_Tinh_BoiDuong, quoc_gia_id, v);
                        break;


                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// khi do full tinh vao combo, sau do chon 1 tinh, can phai exclude cac tinh o thuoc quoc gia do
        /// ==> loai bo nhung value tinh ra khoi combo
        /// </summary>
        /// <param name="Comb_Tinh"></param>
        /// <param name="quoc_gia_id"></param>
        /// <param name="SelectedValue">tinh mà ng dung da chon</param>
        private void ExcludeTinhData(ComboBox Comb_Tinh, int quoc_gia_id, int SelectedValue)
        {
            var dt = dtTinhTP.AsEnumerable().Where(a => a.Field<int>("quoc_gia_id") == quoc_gia_id);
            DataTable dt2 = dt.CopyToDataTable();
            if (dt2.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt2.NewRow();
                dr["ten_tinh_tp"] = "";
                dr["id"] = -1;
                dr["quoc_gia_id"] = -1;
                dt2.Rows.Add(dr);
            }

            // comb
            Comb_Tinh.DataSource = dt2;
            Comb_Tinh.DisplayMember = "ten_tinh_tp";
            Comb_Tinh.ValueMember = "id";

            Comb_Tinh.SelectedValue = SelectedValue;
        }

        private void lbl_ThemTinh_Click(object sender, EventArgs e)
        {
            UCs.ThemTinhTP oThemTinhTP = new ThemTinhTP("QLNS_DaoTaoBoiDuong");
            oThemTinhTP.Dock = DockStyle.Fill;
            Forms.Popup fPopup = new Forms.Popup("Thêm tỉnh thành phố", oThemTinhTP);
            fPopup.ShowDialog();
            if (nNewTinhTPID > 0)
            {
                int? v_BoiDuong = null, v_DaoTao = null;

                if (comB_Tinh_BoiDuong.SelectedValue != Convert.DBNull && comB_Tinh_BoiDuong.SelectedValue != null)
                {
                    v_BoiDuong = Convert.ToInt16(comB_Tinh_BoiDuong.SelectedValue);
                }

                if (comB_Tinh_DaoTao.SelectedValue != Convert.DBNull && comB_Tinh_DaoTao.SelectedValue != null)
                {
                    v_DaoTao = Convert.ToInt16(comB_Tinh_DaoTao.SelectedValue);
                }

                dtTinhTP = oTinhTP.GetData();

                SetupTinhDS();

                if (v_BoiDuong != null) comB_Tinh_BoiDuong.SelectedValue = v_BoiDuong;
                if (v_DaoTao != null) comB_Tinh_DaoTao.SelectedValue = v_DaoTao;

                nNewTinhTPID = 0;
            }
        }

        private void lbl_ThemQuocGia_Click(object sender, EventArgs e)
        {
            UCs.ThemQuocGia oThemQuocGia = new ThemQuocGia("QLNS_DaoTaoBoiDuong");
            oThemQuocGia.Dock = DockStyle.Fill;
            Forms.Popup fPopup = new Forms.Popup("Thêm quốc gia", oThemQuocGia);
            fPopup.ShowDialog();
            if (nNewQuocGiaID > 0)
            {
                Label lbl = ((Label)sender);
                ComboBox com = null;
                switch (lbl.Name)
                {
                    case "lbl_ThemQuocGia_DaoTao":
                        com = comB_QuocGia_DaoTao;
                        break;

                    case "lbl_ThemQuocGia_BoiDuong":
                        com = comB_QuocGia_BoiDuong;
                        break;

                    default:
                        break;
                }
                int? x = null;

                if (com.SelectedValue != Convert.DBNull && com.SelectedValue != null)
                    x = Convert.ToInt16(com.SelectedValue);

                dtQuocGia = oQuocGia.GetData();

                com.DataSource = dtQuocGia;
                com.DisplayMember = "ten_quoc_gia";
                com.ValueMember = "id";

                if (x != null)
                {
                    com.SelectedValue = x;
                }
                nNewQuocGiaID = 0;
            }
        }

        #endregion

        private void LoadHinhThucData()
        {
            dtHinhThuc = oHinhThucDaoTao.GetData();

            DataTable dt = dtHinhThuc.Copy();

            //if (dt.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["ten_hinh_thuc"] = "";
            //    dr["id"] = -1;
            //    dt.Rows.InsertAt(dr, 0);
            //}
            
            // comb
            comB_HinhThuc.DataSource = dt;
            comB_HinhThuc.DisplayMember = "ten_hinh_thuc";
            comB_HinhThuc.ValueMember = "id";

            comB_HinhThuc.SelectedIndex = 0;
        }

        private void LoadVanBangData()
        {
            dtVanBang = oVanBangChinhQuy.GetData();

            DataTable dt = dtVanBang.Copy();

            if (dt.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt.NewRow();
                dr["ten_van_bang"] = "";
                dr["id"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }

            // comb
            comB_VanBang.DataSource = dt;
            comB_VanBang.DisplayMember = "ten_van_bang";
            comB_VanBang.ValueMember = "id";

            comB_VanBang.SelectedIndex = 0;
        }

        private void LoadMoHinhData()
        {
            dtMoHinh = oMoHinh.GetData();

            DataTable dt = dtMoHinh.Copy();

            if (dt.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt.NewRow();
                dr["ten_mo_hinh"] = "";
                dr["id"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }

            // comb
            comB_PhuongThucDT.DataSource = dt;
            comB_PhuongThucDT.DisplayMember = "ten_mo_hinh";
            comB_PhuongThucDT.ValueMember = "id";

            comB_PhuongThucDT.SelectedIndex = 0;
        }

        public void FillDaoTaoData()
        {
            if (dtDaoTao.Rows.Count > 0)
            {
                DataTable dt = dtDaoTao.Copy();
                dtgv_DaoTao.Columns.Clear();
                dtgv_DaoTao.DataSource = dt;
                Setup_dtgv_DaoTao();
            }
        }

        public void FillBoiDuongData()
        {
            if (dtBoiDuong.Rows.Count > 0)
            {
                DataTable dt = dtBoiDuong.Copy();
                dtgv_BoiDuong.Columns.Clear();
                dtgv_BoiDuong.DataSource = dt;
                Setup_dtgv_BoiDuong();
            }
        }

        #region Init Gridview

        private void Init_dtgv_DaoTao()
        {
            dtgv_DaoTao.Columns.Clear();
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            col = new DataGridViewTextBoxColumn();
            col.Name = "id";
            col.Visible = false;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên trường";
            col.Name = "ten_truong";
            col.Width = 350;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chuyên ngành";
            col.Name = "chuyen_nganh_dao_tao";
            col.Width = 250;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Từ ngày";
            col.Name = "tu_ngay";
            col.Width = 100;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Đến ngày";
            col.Name = "den_ngay";
            col.Width = 100;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "hinh_thuc_dao_tao_id";
            col.Visible = false;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Hình thức";
            col.Name = "ten_hinh_thuc";
            col.Width = 200;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Xếp loại";
            col.Name = "xep_loai";
            col.Width = 150;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "cq_van_bang_id";
            col.Visible = false;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Văn bằng";
            col.Name = "ten_van_bang";
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên luận văn";
            col.Name = "cq_ten_luan_van";
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Hội đồng chấm";
            col.Name = "cq_hoi_dong_cham";
            dtgv_DaoTao.Columns.Add(col);
        }

        private void Init_dtgv_BoiDuong()
        {
            dtgv_BoiDuong.Columns.Clear();
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            col = new DataGridViewTextBoxColumn();
            col.Name = "id";
            col.Visible = false;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên trường";
            col.Name = "ten_truong";
            col.Width = 350;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chuyên ngành";
            col.Name = "chuyen_nganh_dao_tao";
            col.Width = 250;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Từ ngày";
            col.Name = "tu_ngay";
            col.Width = 100;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Đến ngày";
            col.Name = "den_ngay";
            col.Width = 100;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Xếp loại";
            col.Name = "xep_loai";
            col.Width = 150;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên chứng chỉ";
            col.Name = "bd_ten_chung_chi";
            dtgv_BoiDuong.Columns.Add(col);


        } 
        #endregion

        private void Setup_dtgv_DaoTao()
        {

            if (dtgv_DaoTao.Rows.Count > 0)
                dtgv_DaoTao.Rows[0].Selected = false;

            dtgv_DaoTao.Columns["ma_nv"].Visible = dtgv_DaoTao.Columns["id"].Visible = dtgv_DaoTao.Columns["hinh_thuc_dao_tao_id"].Visible =
                dtgv_DaoTao.Columns["cq_van_bang_id"].Visible = dtgv_DaoTao.Columns["bd_ten_chung_chi"].Visible =
                dtgv_DaoTao.Columns["tinh_thanhpho_id"].Visible = dtgv_DaoTao.Columns["trinh_do_id"].Visible 
                = dtgv_DaoTao.Columns["quoc_gia_id"].Visible = false; 

            //  
            dtgv_DaoTao.Columns["ten_truong"].HeaderText = "Tên trường";
            dtgv_DaoTao.Columns["ten_truong"].Width = 350;
            dtgv_DaoTao.Columns["chuyen_nganh_dao_tao"].HeaderText = "Chuyên ngành";
            dtgv_DaoTao.Columns["chuyen_nganh_dao_tao"].Width = 250;
            dtgv_DaoTao.Columns["tu_ngay"].HeaderText = "Từ ngày";
            dtgv_DaoTao.Columns["tu_ngay"].Width = 100;
            dtgv_DaoTao.Columns["den_ngay"].HeaderText = "Đến ngày";
            dtgv_DaoTao.Columns["den_ngay"].Width = 100;
            dtgv_DaoTao.Columns["ten_hinh_thuc"].HeaderText = "Hình thức";
            dtgv_DaoTao.Columns["ten_hinh_thuc"].Width = 200;
            dtgv_DaoTao.Columns["xep_loai"].HeaderText = "Xếp loại";
            dtgv_DaoTao.Columns["xep_loai"].Width = 150;
            dtgv_DaoTao.Columns["ten_van_bang"].HeaderText = "Văn bằng";
            dtgv_DaoTao.Columns["ten_van_bang"].Width = 200;
            dtgv_DaoTao.Columns["cq_ten_luan_van"].HeaderText = "Tên luận văn";
            dtgv_DaoTao.Columns["cq_ten_luan_van"].Width = 150;
            dtgv_DaoTao.Columns["cq_hoi_dong_cham"].HeaderText = "Hội đồng chấm";
            dtgv_DaoTao.Columns["cq_hoi_dong_cham"].Width = 150;
            dtgv_DaoTao.Columns["ten_tinh_tp"].HeaderText = "Tỉnh/TP";
            dtgv_DaoTao.Columns["ten_tinh_tp"].Width = 150;
            dtgv_DaoTao.Columns["ten_quoc_gia"].HeaderText = "Quốc gia";
            dtgv_DaoTao.Columns["ten_quoc_gia"].Width = 150;


            dtgv_DaoTao.Columns["ten"].HeaderText = "Trình độ";
            dtgv_DaoTao.Columns["ten"].Width = 150;
            dtgv_DaoTao.Columns["diem"].HeaderText = "Điểm";
            dtgv_DaoTao.Columns["diem"].Width = 100;
            dtgv_DaoTao.Columns["ghi_chu"].HeaderText = "Ghi chú";
            dtgv_DaoTao.Columns["ghi_chu"].Width = 150;
            dtgv_DaoTao.Columns["ngay_cap_bang"].HeaderText = "Ngày cấp bằng";
            dtgv_DaoTao.Columns["ngay_cap_bang"].Width = 150;
            dtgv_DaoTao.Columns["cq_phuong_thuc_dao_tao"].HeaderText = "Phương thức đào tạo";
            dtgv_DaoTao.Columns["cq_phuong_thuc_dao_tao"].Width = 200;
        }

        private void Setup_dtgv_BoiDuong()
        {
            if (dtgv_BoiDuong.Rows.Count > 0)
                dtgv_BoiDuong.Rows[0].Selected = false;

            dtgv_BoiDuong.Columns["id"].Visible = dtgv_BoiDuong.Columns["hinh_thuc_dao_tao_id"].Visible =
                dtgv_BoiDuong.Columns["cq_van_bang_id"].Visible = dtgv_BoiDuong.Columns["ten_hinh_thuc"].Visible =
               dtgv_BoiDuong.Columns["ten_van_bang"].Visible = dtgv_BoiDuong.Columns["cq_ten_luan_van"].Visible =
               dtgv_BoiDuong.Columns["cq_hoi_dong_cham"].Visible = dtgv_BoiDuong.Columns["ma_nv"].Visible =
               dtgv_BoiDuong.Columns["tinh_thanhpho_id"].Visible = dtgv_BoiDuong.Columns["quoc_gia_id"].Visible =
               dtgv_BoiDuong.Columns["ten"].Visible = dtgv_BoiDuong.Columns["cq_phuong_thuc_dao_tao"].Visible =
               dtgv_BoiDuong.Columns["trinh_do_id"].Visible = false;

            //  
            dtgv_BoiDuong.Columns["ten_truong"].HeaderText = "Tên trường";
            dtgv_BoiDuong.Columns["ten_truong"].Width = 350;
            dtgv_BoiDuong.Columns["chuyen_nganh_dao_tao"].HeaderText = "Chuyên ngành";
            dtgv_BoiDuong.Columns["chuyen_nganh_dao_tao"].Width = 250;
            dtgv_BoiDuong.Columns["tu_ngay"].HeaderText = "Từ ngày";
            dtgv_BoiDuong.Columns["tu_ngay"].Width = 100;
            dtgv_BoiDuong.Columns["den_ngay"].HeaderText = "Đến ngày";
            dtgv_BoiDuong.Columns["den_ngay"].Width = 100;
            dtgv_BoiDuong.Columns["xep_loai"].HeaderText = "Xếp loại";
            dtgv_BoiDuong.Columns["xep_loai"].Width = 150;
            dtgv_BoiDuong.Columns["bd_ten_chung_chi"].HeaderText = "Tên chứng chỉ";
            dtgv_BoiDuong.Columns["bd_ten_chung_chi"].Width = 150;
            dtgv_BoiDuong.Columns["ten_tinh_tp"].HeaderText = "Tỉnh/TP";
            dtgv_BoiDuong.Columns["ten_tinh_tp"].Width = 150;
            dtgv_BoiDuong.Columns["ten_quoc_gia"].HeaderText = "Quốc gia";
            dtgv_BoiDuong.Columns["ten_quoc_gia"].Width = 150;
            dtgv_BoiDuong.Columns["diem"].HeaderText = "Điểm";
            dtgv_BoiDuong.Columns["diem"].Width = 100;
            dtgv_BoiDuong.Columns["ghi_chu"].HeaderText = "Ghi chú";
            dtgv_BoiDuong.Columns["ghi_chu"].Width = 150;
            dtgv_BoiDuong.Columns["ngay_cap_bang"].HeaderText = "Ngày cấp chứng chỉ";
            dtgv_BoiDuong.Columns["ngay_cap_bang"].Width = 150;
        }

        private void dtgv_DaoTao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_DaoTao.Rows.Count > 0 && dtgv_DaoTao.SelectedRows != null)
            {
                DataGridViewRow r = dtgv_DaoTao.SelectedRows[0];

                txt_TenTruong_DaoTao.Text = r.Cells["ten_truong"].Value.ToString();
                txt_ChuyenNganh_DaoTao.Text = r.Cells["chuyen_nganh_dao_tao"].Value.ToString();
                txt_XepLoai_DaoTao.Text = r.Cells["xep_loai"].Value.ToString();
                txt_TenLuanVan.Text = r.Cells["cq_ten_luan_van"].Value.ToString();
                txt_HoiDong.Text = r.Cells["cq_hoi_dong_cham"].Value.ToString();
                txt_Diem_DaoTao.Text = r.Cells["diem"].Value.ToString();
                rtb_GhiChu_DaoTao.Text = r.Cells["ghi_chu"].Value.ToString();

                if (r.Cells["cq_van_bang_id"].Value.ToString() == "")
                {
                    comB_VanBang.SelectedValue = -1;
                }
                else
                {
                    comB_VanBang.SelectedValue = Convert.ToInt32(r.Cells["cq_van_bang_id"].Value);
                }

                if (r.Cells["tinh_thanhpho_id"].Value.ToString() == "")
                {
                    comB_Tinh_DaoTao.SelectedValue = -1;
                }
                else
                {
                    comB_Tinh_DaoTao.SelectedValue = Convert.ToInt32(r.Cells["tinh_thanhpho_id"].Value);
                }

                if (r.Cells["quoc_gia_id"].Value.ToString() == "")
                {
                    comB_QuocGia_DaoTao.SelectedValue = -1;
                }
                else
                {
                    comB_QuocGia_DaoTao.SelectedValue = Convert.ToInt32(r.Cells["quoc_gia_id"].Value);
                }

                comB_HinhThuc.SelectedValue = Convert.ToInt32(r.Cells["hinh_thuc_dao_tao_id"].Value);

                if (r.Cells["tu_ngay"].Value.ToString() != "")
                {
                    dTP_TuNgay_DaoTao.Checked = true;
                    dTP_TuNgay_DaoTao.Value = Convert.ToDateTime(r.Cells["tu_ngay"].Value);
                }
                else
                {
                    dTP_TuNgay_DaoTao.Checked = false;
                }

                if (r.Cells["ngay_cap_bang"].Value.ToString() != "")
                {
                    dtp_NgayCapBang_DaoTao.Checked = true;
                    dtp_NgayCapBang_DaoTao.Value = Convert.ToDateTime(r.Cells["ngay_cap_bang"].Value);
                }
                else
                {
                    dtp_NgayCapBang_DaoTao.Checked = false;
                }

                if (r.Cells["den_ngay"].Value.ToString() != "")
                {
                    dTP_DenNgay_DaoTao.Checked = true;
                    dTP_DenNgay_DaoTao.Value = Convert.ToDateTime(r.Cells["den_ngay"].Value);
                }
                else
                {
                    dTP_DenNgay_DaoTao.Checked = false;
                }
            }
        }

        private void dtgv_BoiDuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_BoiDuong.Rows.Count > 0 && dtgv_BoiDuong.SelectedRows != null)
            {
                DataGridViewRow r = dtgv_BoiDuong.SelectedRows[0];

                txt_TenTruong_BoiDuong.Text = r.Cells["ten_truong"].Value.ToString();
                txt_ChuyenNganh_BoiDuong.Text = r.Cells["chuyen_nganh_dao_tao"].Value.ToString();
                txt_XepLoai_BoiDuong.Text = r.Cells["xep_loai"].Value.ToString();
                txt_TenChungChi.Text = r.Cells["bd_ten_chung_chi"].Value.ToString();
                txt_Diem_BoiDuong.Text = r.Cells["diem"].Value.ToString();
                rtb_GhiChu_BoiDuong.Text = r.Cells["ghi_chu"].Value.ToString();

                if (r.Cells["tu_ngay"].Value.ToString() != "")
                {
                    dTP_TuNgay_BoiDuong.Checked = true;
                    dTP_TuNgay_BoiDuong.Value = Convert.ToDateTime(r.Cells["tu_ngay"].Value);
                }
                else
                {
                    dTP_TuNgay_BoiDuong.Checked = false;
                }

                if (r.Cells["den_ngay"].Value.ToString() != "")
                {
                    dTP_DenNgay_BoiDuong.Checked = true;
                    dTP_DenNgay_BoiDuong.Value = Convert.ToDateTime(r.Cells["den_ngay"].Value);
                }
                else
                {
                    dTP_DenNgay_BoiDuong.Checked = false;
                }

                if (r.Cells["tinh_thanhpho_id"].Value.ToString() == "")
                {
                    comB_Tinh_BoiDuong.SelectedValue = -1;
                }
                else
                {
                    comB_Tinh_BoiDuong.SelectedValue = Convert.ToInt32(r.Cells["tinh_thanhpho_id"].Value);
                }

                if (r.Cells["quoc_gia_id"].Value.ToString() == "")
                {
                    comB_QuocGia_BoiDuong.SelectedValue = -1;
                }
                else
                {
                    comB_QuocGia_BoiDuong.SelectedValue = Convert.ToInt32(r.Cells["quoc_gia_id"].Value);
                }

                if (r.Cells["ngay_cap_bang"].Value.ToString() != "")
                {
                    dtp_NgayCap_BoiDuong.Checked = true;
                    dtp_NgayCap_BoiDuong.Value = Convert.ToDateTime(r.Cells["ngay_cap_bang"].Value);
                }
                else
                {
                    dtp_NgayCap_BoiDuong.Checked = false;
                }
            }
        }

        private void ControlDaoTao(bool Add)
        {

            txt_TenTruong_DaoTao.Enabled = txt_ChuyenNganh_DaoTao.Enabled = txt_XepLoai_DaoTao.Enabled
                    = txt_TenLuanVan.Enabled = txt_HoiDong.Enabled = dTP_DenNgay_DaoTao.Enabled =
                    dTP_TuNgay_DaoTao.Enabled = comB_HinhThuc.Enabled = comB_PhuongThucDT.Enabled =
                     txt_Diem_DaoTao.Enabled = rtb_GhiChu_DaoTao.Enabled =
                    comB_VanBang.Enabled = comB_QuocGia_DaoTao.Enabled = comB_Tinh_DaoTao.Enabled
                    = dtp_NgayCapBang_DaoTao.Enabled = tableLP_DaoTao_QG.Enabled = tableLP_DaoTao_Tinh.Enabled = Add;

            dtgv_DaoTao.Enabled = lbl_XoaDaoTao.Enabled = !Add;

            if (Add)
            {
                lbl_SuaDaoTao.Text = "Huỷ";
                lbl_ThemDaoTao.Text = "Lưu";
                
            }
            else
            {
                lbl_SuaDaoTao.Text = "Sửa";
                lbl_ThemDaoTao.Text = "Thêm";
                
            }
        }

        private void ControlBoiDuong(bool Add)
        {
            txt_TenTruong_BoiDuong.Enabled = txt_ChuyenNganh_BoiDuong.Enabled = txt_XepLoai_BoiDuong.Enabled
                    = txt_TenChungChi.Enabled = dTP_DenNgay_BoiDuong.Enabled =
                    dTP_TuNgay_BoiDuong.Enabled = comB_QuocGia_BoiDuong.Enabled =
                    txt_Diem_BoiDuong.Enabled = rtb_GhiChu_BoiDuong.Enabled =
                    comB_Tinh_BoiDuong.Enabled = tableLP_BoiDuong_Tinh.Enabled = tableLP_BoiDuong_QG.Enabled = Add;
            dtgv_BoiDuong.Enabled = lbl_XoaBoiDuong.Enabled = !Add;

            if (Add)
            {
                lbl_SuaBoiDuong.Text = "Huỷ";
                lbl_ThemBoiDuong.Text = "Lưu";
                
            }
            else
            {
                lbl_SuaBoiDuong.Text = "Sửa";
                lbl_ThemBoiDuong.Text = "Thêm";
            }
        }

        private void lbl_ThemDaoTao_Click(object sender, EventArgs e)
        {
            #region MyRegion

            if (Program.selected_ma_nv != "")
            {
                if (lbl_ThemDaoTao.Text == "Thêm")
                {
                    bAddDaoTaoFlag = true;
                    ControlDaoTao(true);
                    ClearDaoTaoData();
                }
                else        // LƯU
                {
                    if (VerifyDaoTaoData())
                    {
                        if (bAddDaoTaoFlag)   // Thêm mới
                        {
                            if ((MessageBox.Show("Thêm thông tin đào tạo của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                            {
                                try
                                {
                                    GetDaoTaoInputData();
                                    oCNVC_DaoTaoBoiDuong.Add();

                                    // load lai dtgv_CMND
                                    GetDaoTaoBoiDuongInfo(Program.selected_ma_nv);
                                    dtgv_DaoTao.DataSource = dtDaoTao;
                                    Setup_dtgv_DaoTao();
                                    ControlDaoTao(false);
                                    ClearDaoTaoData();

                                    MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin đào tạo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else        // Sửa
                        {
                            if ((MessageBox.Show("Sửa thông tin đào tạo của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                            {
                                try
                                {
                                    GetDaoTaoInputData();
                                    oCNVC_DaoTaoBoiDuong.Update();

                                    // load lai dtgv_CMND
                                    GetDaoTaoBoiDuongInfo(Program.selected_ma_nv);
                                    dtgv_DaoTao.DataSource = dtDaoTao;
                                    Setup_dtgv_DaoTao();
                                    ControlDaoTao(false);
                                    ClearDaoTaoData();

                                    MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin đào tạo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }

                        
                    }
                    else
                    {
                        MessageBox.Show("Thông tin đào tạo không phù hợp, xin vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
            #endregion
        }

        private void lbl_SuaDaoTao_Click(object sender, EventArgs e)
        {
            if (Program.selected_ma_nv != "")
            {
                if (lbl_SuaDaoTao.Text == "Sửa")
                {
                    if (dtgv_DaoTao.Rows.Count > 0 && dtgv_DaoTao.SelectedRows != null)
                    {
                        txt_TenTruong_DaoTao.Focus();
                        bAddDaoTaoFlag = false;
                        ControlDaoTao(true);
                    }
                    else
                    {
                        MessageBox.Show("Chưa có thông tin về trình độ phổ thông của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else        // HUỶ
                {
                    bAddDaoTaoFlag = false;
                    ControlDaoTao(false);
                    ClearDaoTaoData();

                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void lbl_XoaDaoTao_Click(object sender, EventArgs e)
        {
            if (dtgv_DaoTao.SelectedRows != null &&
                (MessageBox.Show("Xoá dòng dữ liệu đào tạo của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                DataGridViewRow r = dtgv_DaoTao.SelectedRows[0];
                oCNVC_DaoTaoBoiDuong.ID = Convert.ToInt32(r.Cells["id"].Value);

                try
                {
                    oCNVC_DaoTaoBoiDuong.Delete();
                    // load lai dtgv_DaoTao
                    GetDaoTaoBoiDuongInfo(Program.selected_ma_nv);
                    dtgv_DaoTao.DataSource = dtDaoTao;
                    Setup_dtgv_DaoTao();

                    MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xoá không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private bool VerifyDaoTaoData()
        {
            return true;

        }

        private bool VerifyBoiDuongData()
        {
            return true;

        }

        private void GetDaoTaoInputData()
        {
            if(bAddDaoTaoFlag == false)
                oCNVC_DaoTaoBoiDuong.ID = Convert.ToInt32(dtgv_DaoTao.SelectedRows[0].Cells["id"].Value);

            oCNVC_DaoTaoBoiDuong.MaNV = Program.selected_ma_nv;
            oCNVC_DaoTaoBoiDuong.TenTruong = txt_TenTruong_DaoTao.Text;
            oCNVC_DaoTaoBoiDuong.ChuyenNganhDaoTao = txt_ChuyenNganh_DaoTao.Text;
            oCNVC_DaoTaoBoiDuong.XepLoai = txt_XepLoai_DaoTao.Text;
            oCNVC_DaoTaoBoiDuong.CQ_TenLuanVan = txt_TenLuanVan.Text;
            oCNVC_DaoTaoBoiDuong.CQ_HoiDongCham = txt_HoiDong.Text;
            oCNVC_DaoTaoBoiDuong.BD_TenChungChi = "";
            oCNVC_DaoTaoBoiDuong.GhiChu = rtb_GhiChu_DaoTao.Text;
            if (Convert.ToInt16(comB_PhuongThucDT.SelectedValue) == -1)
            {
                oCNVC_DaoTaoBoiDuong.PhuongThucDaoTaoID = null;
            }
            else
            {
                oCNVC_DaoTaoBoiDuong.PhuongThucDaoTaoID = Convert.ToInt16(comB_PhuongThucDT.SelectedValue);
            }
            
            if (Convert.ToInt16(comB_VanBang.SelectedValue) == -1)
            {
                oCNVC_DaoTaoBoiDuong.CQ_VanBangID = null;
            }
            else
            {
                oCNVC_DaoTaoBoiDuong.CQ_VanBangID = Convert.ToInt16(comB_VanBang.SelectedValue);
            }

            if (Convert.ToInt16(comB_VanBang.SelectedValue) == -1)
            {
                oCNVC_DaoTaoBoiDuong.TrinhDoID = null;
            }
            else
            {
                

                int? nTrinhDoID = dtVanBang.AsEnumerable().Where(a => a.Field<int>("id") == Convert.ToInt16(comB_VanBang.SelectedValue)).Select(b => b.Field<int?>("trinh_do_id")).First();
                oCNVC_DaoTaoBoiDuong.TrinhDoID = nTrinhDoID;
            }

            if (txt_Diem_DaoTao.Text != "")
            {
                try
                {
                    oCNVC_DaoTaoBoiDuong.Diem = Convert.ToDouble(txt_Diem_DaoTao.Text);
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
            else
                oCNVC_DaoTaoBoiDuong.Diem = null;

            if (dTP_TuNgay_DaoTao.Checked)
            {
                oCNVC_DaoTaoBoiDuong.TuNgay = dTP_TuNgay_DaoTao.Value;
            }
            else
            {
                oCNVC_DaoTaoBoiDuong.TuNgay = null;
            }

            if (dtp_NgayCapBang_DaoTao.Checked)
            {
                oCNVC_DaoTaoBoiDuong.NgayCapBang = dtp_NgayCapBang_DaoTao.Value;
            }
            else
            {
                oCNVC_DaoTaoBoiDuong.NgayCapBang = null;
            }

            if (dTP_DenNgay_DaoTao.Checked)
            {
                oCNVC_DaoTaoBoiDuong.DenNgay = dTP_DenNgay_DaoTao.Value;
            }
            else
            {
                oCNVC_DaoTaoBoiDuong.DenNgay = null;
            }
            if(Convert.ToInt32(comB_HinhThuc.SelectedValue) == -1 )  oCNVC_DaoTaoBoiDuong.HinhThucDaoTaoID = null;
            else oCNVC_DaoTaoBoiDuong.HinhThucDaoTaoID = Convert.ToInt32(comB_HinhThuc.SelectedValue);

            if (Convert.ToInt32(comB_VanBang.SelectedValue) == -1) oCNVC_DaoTaoBoiDuong.CQ_VanBangID = null;
            else oCNVC_DaoTaoBoiDuong.CQ_VanBangID = Convert.ToInt32(comB_VanBang.SelectedValue);

            if (Convert.ToInt32(comB_QuocGia_DaoTao.SelectedValue) == -1) oCNVC_DaoTaoBoiDuong.QuocGia = null;
            else oCNVC_DaoTaoBoiDuong.QuocGia = Convert.ToInt32(comB_QuocGia_DaoTao.SelectedValue);

            if (Convert.ToInt32(comB_Tinh_DaoTao.SelectedValue) == -1) oCNVC_DaoTaoBoiDuong.TinhTP = null;
            else oCNVC_DaoTaoBoiDuong.TinhTP = Convert.ToInt32(comB_Tinh_DaoTao.SelectedValue);

        }

        private void GetBoiDuongInputData()
        {
            if(bAddBoiDuongFlag == false)
                oCNVC_DaoTaoBoiDuong.ID = Convert.ToInt32(dtgv_BoiDuong.SelectedRows[0].Cells["id"].Value);

            oCNVC_DaoTaoBoiDuong.MaNV = Program.selected_ma_nv;
            oCNVC_DaoTaoBoiDuong.TenTruong = txt_TenTruong_BoiDuong.Text;
            oCNVC_DaoTaoBoiDuong.ChuyenNganhDaoTao = txt_ChuyenNganh_BoiDuong.Text;
            oCNVC_DaoTaoBoiDuong.XepLoai = txt_XepLoai_BoiDuong.Text;
            oCNVC_DaoTaoBoiDuong.BD_TenChungChi = txt_TenChungChi.Text;
            oCNVC_DaoTaoBoiDuong.CQ_TenLuanVan = txt_TenLuanVan.Text;
            oCNVC_DaoTaoBoiDuong.GhiChu = rtb_GhiChu_BoiDuong.Text;
            if (txt_Diem_BoiDuong.Text != "")
            {
                try
                {
                    oCNVC_DaoTaoBoiDuong.Diem = Convert.ToDouble(txt_Diem_BoiDuong.Text);
                }
                catch (Exception)
                {
                    throw;
                }

            }
            else
                oCNVC_DaoTaoBoiDuong.Diem = null;

            if (dTP_TuNgay_BoiDuong.Checked)
            {
                oCNVC_DaoTaoBoiDuong.TuNgay = dTP_TuNgay_BoiDuong.Value;
            }
            else
            {
                oCNVC_DaoTaoBoiDuong.TuNgay = null;
            }

            if (dTP_DenNgay_BoiDuong.Checked)
            {
                oCNVC_DaoTaoBoiDuong.DenNgay = dTP_DenNgay_BoiDuong.Value;
            }
            else
            {
                oCNVC_DaoTaoBoiDuong.DenNgay = null;
            }

            if (dtp_NgayCap_BoiDuong.Checked)
            {
                oCNVC_DaoTaoBoiDuong.NgayCapBang = dtp_NgayCap_BoiDuong.Value;
            }
            else
            {
                oCNVC_DaoTaoBoiDuong.NgayCapBang = null;
            }

            oCNVC_DaoTaoBoiDuong.HinhThucDaoTaoID = null;
            oCNVC_DaoTaoBoiDuong.CQ_VanBangID = null;
            oCNVC_DaoTaoBoiDuong.CQ_HoiDongCham = "";
            oCNVC_DaoTaoBoiDuong.TrinhDoID = null;
            oCNVC_DaoTaoBoiDuong.PhuongThucDaoTaoID = null;

            if (Convert.ToInt32(comB_QuocGia_BoiDuong.SelectedValue) == -1) oCNVC_DaoTaoBoiDuong.QuocGia = null;
            else oCNVC_DaoTaoBoiDuong.QuocGia = Convert.ToInt32(comB_QuocGia_BoiDuong.SelectedValue);

            if (Convert.ToInt32(comB_Tinh_BoiDuong.SelectedValue) == -1) oCNVC_DaoTaoBoiDuong.TinhTP = null;
            else oCNVC_DaoTaoBoiDuong.TinhTP = Convert.ToInt32(comB_Tinh_BoiDuong.SelectedValue);
        }

        private void ClearDaoTaoData()
        {
            txt_TenTruong_DaoTao.Text = txt_ChuyenNganh_DaoTao.Text = txt_HoiDong.Text
                = txt_TenLuanVan.Text = txt_XepLoai_DaoTao.Text = txt_Diem_DaoTao.Text = txt_TrinhDo.Text = rtb_GhiChu_DaoTao.Text = "";
            
            dTP_DenNgay_DaoTao.Checked = dTP_TuNgay_DaoTao.Checked = dtp_NgayCapBang_DaoTao.Checked = false;

            comB_HinhThuc.SelectedIndex = comB_VanBang.SelectedIndex = comB_Tinh_DaoTao.SelectedIndex = comB_VanBang.SelectedIndex = comB_QuocGia_DaoTao.SelectedIndex = 0;

            if (dtgv_DaoTao.SelectedRows.Count > 0) dtgv_DaoTao.SelectedRows[0].Selected = false;
        }

        private void ClearBoiDuongData()
        {
            txt_TenTruong_BoiDuong.Text = txt_ChuyenNganh_BoiDuong.Text = 
                txt_TenChungChi.Text = txt_XepLoai_BoiDuong.Text = txt_Diem_BoiDuong.Text = rtb_GhiChu_BoiDuong.Text = "";

            dTP_DenNgay_BoiDuong.Checked = dTP_TuNgay_BoiDuong.Checked = dtp_NgayCap_BoiDuong.Checked = false;

            comB_Tinh_BoiDuong.SelectedIndex = comB_QuocGia_BoiDuong.SelectedIndex = 0;

            if (dtgv_BoiDuong.SelectedRows.Count > 0) dtgv_BoiDuong.SelectedRows[0].Selected = false;
        }

        private void lbl_ThemBoiDuong_Click(object sender, EventArgs e)
        {
            #region MyRegion

            if (Program.selected_ma_nv != "")
            {
                if (lbl_ThemBoiDuong.Text == "Thêm")
                {
                    bAddBoiDuongFlag = true;
                    ControlBoiDuong(true);
                    ClearBoiDuongData();
                }
                else        // LƯU
                {
                    if (VerifyBoiDuongData())
                    {
                        if (bAddBoiDuongFlag)   // Thêm mới
                        {
                            if ((MessageBox.Show("Thêm thông tin bồi dưỡng của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                            {
                                try
                                {
                                    GetBoiDuongInputData();
                                    oCNVC_DaoTaoBoiDuong.Add();

                                    // load lai dtgv_CMND
                                    GetDaoTaoBoiDuongInfo(Program.selected_ma_nv);
                                    dtgv_BoiDuong.DataSource = dtBoiDuong;
                                    Setup_dtgv_BoiDuong();

                                    MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin bồi dưỡng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else        // Sửa
                        {
                            if ((MessageBox.Show("Sửa thông tin bồi dưỡng của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                            {
                                try
                                {
                                    GetBoiDuongInputData();
                                    oCNVC_DaoTaoBoiDuong.Update();

                                    // load lai dtgv_CMND
                                    GetDaoTaoBoiDuongInfo(Program.selected_ma_nv);
                                    dtgv_BoiDuong.DataSource = dtBoiDuong;
                                    Setup_dtgv_BoiDuong();

                                    MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin bồi dưỡng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }

                        ControlBoiDuong(false);
                        ClearBoiDuongData();
                    }
                    else
                    {
                        MessageBox.Show("Thông tin bồi dưỡng không phù hợp, xin vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } 
            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            #endregion
        }

        private void lbl_SuaBoiDuong_Click(object sender, EventArgs e)
        {
            if (Program.selected_ma_nv != "")
            {
                if (lbl_SuaBoiDuong.Text == "Sửa" )
                {
                    if ( dtgv_BoiDuong.SelectedRows.Count > 0)
                    {
                        txt_TenTruong_BoiDuong.Focus();
                        bAddBoiDuongFlag = false;
                        ControlBoiDuong(true);
                    }
                    else
                    {
                        MessageBox.Show("Chưa có thông tin hoặc chưa chọn thông tin về trình độ phổ thông của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else        // HUỶ
                {
                    bAddBoiDuongFlag = false;
                    ControlBoiDuong(false);
                    ClearBoiDuongData();

                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void lbl_XoaBoiDuong_Click(object sender, EventArgs e)
        {
            if (dtgv_BoiDuong.SelectedRows != null &&
                (MessageBox.Show("Xoá dòng dữ liệu bồi dưỡng của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                DataGridViewRow r = dtgv_BoiDuong.SelectedRows[0];
                oCNVC_DaoTaoBoiDuong.ID = Convert.ToInt32(r.Cells["id"].Value);

                try
                {
                    oCNVC_DaoTaoBoiDuong.Delete();
                    // load lai dtgv_DaoTao
                    GetDaoTaoBoiDuongInfo(Program.selected_ma_nv);
                    dtgv_BoiDuong.DataSource = dtBoiDuong;
                    Setup_dtgv_BoiDuong();

                    MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xoá không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void txt_TenTruong_BoiDuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void comB_VanBang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int nSelectedVB = Convert.ToInt16(comB_VanBang.SelectedValue);

            txt_TrinhDo.Text = dtVanBang.AsEnumerable().Where(a => a.Field<int>("id") == nSelectedVB)
                                                        .Select(b => b.Field<string>("ten")).First();
        }
    }
}

