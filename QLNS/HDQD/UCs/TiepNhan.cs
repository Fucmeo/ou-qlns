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
using System.Threading;

namespace HDQD.UCs
{
    public partial class TiepNhan : UserControl
    {
        Business.HDQD.CNVC_HopDong oHopdong;
        Business.ChucDanh oChucdanh;
        Business.ChucVu oChucvu;
        Business.DonVi oDonvi;
        Business.HDQD.LoaiPhuCap oLoaiPC;
        Business.CNVC.CNVC cnvc;
        Business.Luong.BacHeSo oBacHeSo;
        DataTable dtBacHeSo;
        DataTable dtDSDonVi;

        DataTable dtLoaiPC;

        DataTable dtPhuCap;
        int row_count_pc = 0;

        bool IsUpdate = false;
        string p_ma_tuyen_dung_old = null;

        #region Upload file
        Business.FTP oFTP;
        public static Business.CNVC.CNVC_File oFile;
        string[] ServerPaths;
        int nNewFilesCount;         // so file add new
        string[] dbPaths; 
        #endregion

        public TiepNhan()
        {
            InitializeComponent();
            InitObject();

            IsUpdate = false;
        }

        public TiepNhan(Business.HDQD.CNVC_HopDong p_HopDong, string p_ho, string p_ten)
        {
            InitializeComponent();
            InitObject();
            IsUpdate = true;

            oHopdong = p_HopDong;
            DisplayInfo(p_ho, p_ten);

            p_ma_tuyen_dung_old = oHopdong.Ma_Tuyen_Dung;
        }

        private void InitObject()
        {
            oHopdong = new Business.HDQD.CNVC_HopDong();
            oChucdanh = new ChucDanh();
            oChucvu = new ChucVu();
            oDonvi = new DonVi();
            oBacHeSo = new Business.Luong.BacHeSo();
            dtBacHeSo = new DataTable();
            oLoaiPC = new Business.HDQD.LoaiPhuCap();
            oFile = new Business.CNVC.CNVC_File();
            dtLoaiPC = new DataTable();
            dtPhuCap = new DataTable();
            oFTP = new Business.FTP();

            dtLoaiPC = oLoaiPC.GetList_Cbo();
            dtDSDonVi = new DataTable();

            PreapreDataSource();
            Prepare_Data_BacHeSo();
            PrepareDataTablePhuCap();
            thongTinQuyetDinh1.dTP_NgayHieuLuc.ValueChanged += dTP_NgayHieuLuc_ValueChanged;
        }

        void dTP_NgayHieuLuc_ValueChanged(object sender, EventArgs e)
        {
            string m_ma_ngach = comb_Ngach.SelectedValue.ToString();
            DateTime m_tu_ngay_select = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;
            LoadDataForCbo_BacHeso(m_ma_ngach, m_tu_ngay_select);
        }

        private void TiepNhan_Load(object sender, EventArgs e)
        {
            comb_Luong.SelectedIndex = 0;

            thongTinQuyetDinh1.comB_Loai.Enabled = false;
            
        }

        #region Private Methods
        private void ResetInterface()
        {
            thongTinCNVC1.txt_MaNV.Text = "";
            thongTinCNVC1.txt_Ho.Text = thongTinCNVC1.txt_Ten.Text = thongTinCNVC1.comB_ChucVu.Text = thongTinCNVC1.comB_DonVi.Text = "";

            thongTinQuyetDinh1.txt_MaQD.Text = thongTinQuyetDinh1.txt_TenQD.Text = txt_HeSo.Text = txt_Tien.Text
                = txt_TienPC.Text = txt_HeSoPC.Text = rTB_GhiChuPC.Text
                //= txt_HeSoLuong.Text = txt_PhanTram.Text 
                = thongTinQuyetDinh1.rTB_MoTa.Text = "";
            thongTinQuyetDinh1.dTP_NgayHetHan.Checked = false;
        }

        private void PrepareDTGVSource(DataTable dt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dtgv_DSPhuCap.DataSource = bs;
            EditDtgInterface();
        }

        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            //dtgv_DSPhuCap.Columns["loai_pc_id"].HeaderText = "Loại Phụ cấp ID";
            dtgv_DSPhuCap.Columns["ten_loai"].HeaderText = "Loại Phụ cấp";
            dtgv_DSPhuCap.Columns["value_khoan"].HeaderText = "Giá trị Khoán";
            dtgv_DSPhuCap.Columns["value_he_so"].HeaderText = "Giá trị Hệ số";
            dtgv_DSPhuCap.Columns["value_phan_tram"].HeaderText = "Giá trị Phần trăm";
            dtgv_DSPhuCap.Columns["phan_tram_huong"].HeaderText = "Phần trăm được hưởng";
            dtgv_DSPhuCap.Columns["tu_ngay"].HeaderText = "Từ ngày";
            dtgv_DSPhuCap.Columns["den_ngay"].HeaderText = "Đến ngày";

            // An cac cot ID
            dtgv_DSPhuCap.Columns["id"].Visible = false;
            dtgv_DSPhuCap.Columns["loai_pc_id"].Visible = false;
            dtgv_DSPhuCap.Columns["ghi_chu"].Visible = false;
        }

        private void PrepareDataTablePhuCap()
        {
            dtPhuCap = new DataTable();
            row_count_pc = 0;
            dtPhuCap.Columns.Add("id", typeof(int));
            dtPhuCap.Columns.Add("loai_pc_id", typeof(int));
            dtPhuCap.Columns.Add("ten_loai", typeof(string));
            dtPhuCap.Columns.Add("value_khoan", typeof(double));
            dtPhuCap.Columns.Add("value_he_so", typeof(double));
            dtPhuCap.Columns.Add("value_phan_tram", typeof(double));
            dtPhuCap.Columns.Add("phan_tram_huong", typeof(double));
            dtPhuCap.Columns.Add("tu_ngay", typeof(DateTime));
            dtPhuCap.Columns.Add("den_ngay", typeof(DateTime));
            dtPhuCap.Columns.Add("ghi_chu", typeof(string));
        }

        private void PreapreDataSource()
        {
            try
            {
                comB_ChucDanh.DataSource = oChucdanh.GetList();
                comB_ChucDanh.DisplayMember = "ten_chuc_danh";
                comB_ChucDanh.ValueMember = "id";

                comB_ChucVu.DataSource = oChucvu.GetList();
                comB_ChucVu.DisplayMember = "ten_chuc_vu";
                comB_ChucVu.ValueMember = "id";

                dtDSDonVi = oDonvi.GetActiveDonVi();
                comB_DonVi.DataSource = dtDSDonVi;
                comB_DonVi.DisplayMember = "ten_don_vi";
                comB_DonVi.ValueMember = "id";

                comB_LoaiPhuCap.DataSource = dtLoaiPC;
                comB_LoaiPhuCap.DisplayMember = "ten_loai";
                comB_LoaiPhuCap.ValueMember = "id";
                EditInterface_LoaiPC();
            }
            catch (Exception)
            {
                
            }
            
        }

        private void Prepare_Data_BacHeSo()
        {
            dtBacHeSo = oBacHeSo.GetData();
            Load_Data_Cbo_Ngach();

            try
            {
                string m_ma_ngach = comb_Ngach.SelectedValue.ToString();

                /*var result = (from c in dtBacHeSo.AsEnumerable()
                              where c.Field<string>("ma_ngach") == m_ma_ngach && c.Field<bool>("tinh_trang") == true
                              select new { id = c.Field<int>("id"), bac = c.Field<int>("bac"), he_so = c.Field<double>("he_so") }
                                  ).ToList();
                */

                DateTime m_tu_ngay_select = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;

                var result = (from c in dtBacHeSo.AsEnumerable()
                              where c.Field<string>("ma_ngach") == m_ma_ngach && m_tu_ngay_select >= c.Field<DateTime>("tu_ngay") && m_tu_ngay_select <= c.Field<DateTime?>("den_ngay")
                              orderby c.Field<int>("bac")
                              select new { id = c.Field<int>("id"), bac = c.Field<int>("bac"), he_so = c.Field<double>("he_so") }
                                  ).ToList();
                if (result.Count == 0)
                    result = (from c in dtBacHeSo.AsEnumerable()
                              where c.Field<string>("ma_ngach") == m_ma_ngach && c.Field<bool>("tinh_trang") == true && m_tu_ngay_select >= c.Field<DateTime>("tu_ngay")
                              orderby c.Field<int>("bac")
                              select new { id = c.Field<int>("id"), bac = c.Field<int>("bac"), he_so = c.Field<double>("he_so") }
                                  ).ToList();

                DataTable dt = ToDataTable(result);

                comb_Bac.DataSource = dt;
                comb_Bac.DisplayMember = "bac";
                comb_Bac.ValueMember = "id";

                if (result.Count != 0)
                {
                    int m_id = Convert.ToInt32(comb_Bac.SelectedValue.ToString());

                    var result1 = (from c in dtBacHeSo.AsEnumerable()
                                   where c.Field<int>("id") == m_id
                                   select c.Field<double>("he_so"));

                    double m_he_so = result1.ElementAt<double>(0);

                    txt_HeSo.Text = m_he_so.ToString();
                }
                else
                    txt_HeSo.Text = "";
                
            }
            catch { }
        }

        private void Load_Data_Cbo_Ngach()
        {
            try
            {
                var result = (from c in dtBacHeSo.AsEnumerable()
                              orderby c.Field<string>("ten_ngach")
                              select new { ma_ngach = c.Field<string>("ma_ngach"), ten_ngach = c.Field<string>("ten_ngach") }
                              ).Distinct().ToList();

                DataTable dt = ToDataTable(result);

                comb_Ngach.DataSource = dt;
                comb_Ngach.DisplayMember = "ten_ngach";
                comb_Ngach.ValueMember = "ma_ngach";
            }
            catch { }
        }

        private void DisplayInfo(string cnvc_ho, string cnvc_ten)
        {
            thongTinCNVC1.txt_MaNV.Text = oHopdong.Ma_NV;
            thongTinCNVC1.txt_Ho.Text = cnvc_ho;
            thongTinCNVC1.txt_Ten.Text = cnvc_ten;

            thongTinQuyetDinh1.txt_MaQD.Text = oHopdong.Ma_Tuyen_Dung.Substring(0, oHopdong.Ma_Tuyen_Dung.Length - 9);
            thongTinQuyetDinh1.txt_TenQD.Text = oHopdong.Ten_Quyet_Dinh;
            thongTinQuyetDinh1.rTB_MoTa.Text = oHopdong.MoTa_QD;
            if (oHopdong.Ngay_Ky != null)
            {
                thongTinQuyetDinh1.dTP_NgayKy.Value = oHopdong.Ngay_Ky.Value;
            }
            if (oHopdong.Ngay_Hieu_Luc != null)
            {
                thongTinQuyetDinh1.dTP_NgayHieuLuc.Value = oHopdong.Ngay_Hieu_Luc.Value;
            }
            if (oHopdong.Ngay_Het_Han != null)
            {
                thongTinQuyetDinh1.dTP_NgayHetHan.Checked = true;
                thongTinQuyetDinh1.dTP_NgayHetHan.Value = oHopdong.Ngay_Het_Han.Value;
            }
            if (oHopdong.Loai_QD_ID != null)
                thongTinQuyetDinh1.comB_Loai.SelectedValue = oHopdong.Loai_QD_ID;

            //Xử lý combo box
            if (oHopdong.Chuc_Danh_ID != null)
                comB_ChucDanh.SelectedValue = oHopdong.Chuc_Danh_ID;
            if (oHopdong.Chuc_Vu_ID != null)
                comB_ChucVu.SelectedValue = oHopdong.Chuc_Vu_ID;
            if (oHopdong.Don_Vi_ID != null)
                comB_DonVi.SelectedValue = oHopdong.Don_Vi_ID;

            try
            {
                cb_ThamNienNB.Checked = oHopdong.Tham_nien_nang_bac;
                cb_ThamNienNG.Checked = oHopdong.Tham_nien_nha_giao;
            }
            catch { }

            #region Luong Info
            txt_Tien.Text = oHopdong.Luong_Khoan.ToString();
            nup_PhanTram.Value = Convert.ToDecimal(oHopdong.PhanTramHuong.Value);
            if (oHopdong.Khoan_or_HeSo == true)
                comb_Luong.Text = "Hệ số";
            else
                comb_Luong.Text = "Khoán";

            if (oHopdong.BacHeSo_ID != null)
            {
                var result = (from c in dtBacHeSo.AsEnumerable()
                              where c.Field<int>("id") == oHopdong.BacHeSo_ID && c.Field<bool>("tinh_trang") == true
                              select c.Field<string>("ma_ngach")
                            );

                string ma_ngach = result.ElementAt(0).ToString();

                comb_Ngach.SelectedValue = ma_ngach;
                comb_Bac.SelectedValue = oHopdong.BacHeSo_ID;

                var result1 = (from c in dtBacHeSo.AsEnumerable()
                               where c.Field<int>("id") == oHopdong.BacHeSo_ID
                               select c.Field<double>("he_so"));

                double m_he_so = result1.ElementAt<double>(0);

                txt_HeSo.Text = m_he_so.ToString();
            }
            #endregion

            #region Phu Cap Info
            cb_CoPhuCap.Checked = !oHopdong.Co_Phu_Cap;

            if (oHopdong.Co_Phu_Cap == true)
            {
                Business.HDQD.CNVC_PhuCap oCNVCPhuCap = new Business.HDQD.CNVC_PhuCap();
                dtPhuCap = oCNVCPhuCap.GetList_PhuCap_byCNVC(oHopdong.Ma_Tuyen_Dung, oHopdong.Ma_NV);
                PrepareDTGVSource(dtPhuCap);
            }
            #endregion
            
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

        private void comb_Luong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comb_Luong.SelectedIndex == 0)      // he so
            {
                comb_Ngach.Enabled //= txt_HeSo.Enabled 
                    = nup_PhanTram.Enabled = comb_Bac.Enabled = true;
                txt_Tien.Enabled = false;
            }
            else
            {
                comb_Ngach.Enabled //= txt_HeSo.Enabled 
                    = nup_PhanTram.Enabled = comb_Bac.Enabled = false;
                txt_Tien.Enabled = true;
            }
        }     

        private void comb_Ngach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m_ma_ngach = comb_Ngach.SelectedValue.ToString();
            DateTime m_tu_ngay_select = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;
            LoadDataForCbo_BacHeso(m_ma_ngach, m_tu_ngay_select);
        }

        private void LoadDataForCbo_BacHeso(string p_ma_ngach, DateTime p_tu_ngay)
        {
            try
            {
                /*var result = (from c in dtBacHeSo.AsEnumerable()
                              where c.Field<string>("ma_ngach") == m_ma_ngach && c.Field<bool>("tinh_trang") == true
                              select new { id = c.Field<int>("id"), bac = c.Field<int>("bac"), he_so = c.Field<double>("he_so") }
                                  ).ToList();
                */


                var result = (from c in dtBacHeSo.AsEnumerable()
                              where c.Field<string>("ma_ngach") == p_ma_ngach && p_tu_ngay >= c.Field<DateTime>("tu_ngay") && p_tu_ngay <= c.Field<DateTime?>("den_ngay")
                              orderby c.Field<int>("bac")
                              select new { id = c.Field<int>("id"), bac = c.Field<int>("bac"), he_so = c.Field<double>("he_so") }
                                  ).ToList();
                if (result.Count == 0)
                    result = (from c in dtBacHeSo.AsEnumerable()
                              where c.Field<string>("ma_ngach") == p_ma_ngach && c.Field<bool>("tinh_trang") == true && p_tu_ngay >= c.Field<DateTime>("tu_ngay")
                              orderby c.Field<int>("bac")
                              select new { id = c.Field<int>("id"), bac = c.Field<int>("bac"), he_so = c.Field<double>("he_so") }
                                  ).ToList();

                DataTable dt = ToDataTable(result);

                comb_Bac.DataSource = dt;
                comb_Bac.DisplayMember = "bac";
                comb_Bac.ValueMember = "id";

                if (result.Count == 0)
                {
                    txt_HeSo.Text = "";
                }

            }
            catch
            { }
        }
        
        private void comb_Bac_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int m_id = Convert.ToInt32(comb_Bac.SelectedValue.ToString());

                var result = (from c in dtBacHeSo.AsEnumerable()
                              where c.Field<int>("id") == m_id
                              select c.Field<double>("he_so"));

                double m_he_so = result.ElementAt<double>(0);

                txt_HeSo.Text = m_he_so.ToString();
            }
            catch { }
        }

        private void cb_CoPhuCap_CheckedChanged(object sender, EventArgs e)
        {
            comB_LoaiPhuCap.Enabled = txt_TienPC.Enabled = txt_HeSoPC.Enabled = dTP_NgayBatDauPC.Enabled =
                dTP_NgayHetHanPC.Enabled = nup_PhanTramPC.Enabled = rTB_GhiChuPC.Enabled = dtgv_DSPhuCap.Enabled = nup_Value_PhanTramPC.Enabled =
                btn_AddPC.Enabled = btn_DelPC.Enabled = !cb_CoPhuCap.Checked;
            EditInterface_LoaiPC();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (CheckInputData())
            {
                oHopdong = new Business.HDQD.CNVC_HopDong();

                bool bUploadInfoSuccess = false;    // KHANG : dung de biet upload info thanh cong 
                // neu thanh cong moi upload file
                oHopdong.Ma_NV = thongTinCNVC1.txt_MaNV.Text;

                oHopdong.Ma_Tuyen_Dung = thongTinQuyetDinh1.txt_MaQD.Text;
                oHopdong.Ma_Loai_HD = null;

                oHopdong.La_QD_Tiep_Nhan = true;
                oHopdong.Ten_Quyet_Dinh = thongTinQuyetDinh1.txt_TenQD.Text;
                oHopdong.Loai_QD_ID = 10;

                //oHopdong.Co_Thoi_Han = cb_ThoiHan.Checked;
                oHopdong.Co_Thoi_Han = true;

                oHopdong.Ngay_Ky = thongTinQuyetDinh1.dTP_NgayKy.Value;
                oHopdong.Ngay_Hieu_Luc = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;

                if (thongTinQuyetDinh1.dTP_NgayHetHan.Checked == true)
                    oHopdong.Ngay_Het_Han = thongTinQuyetDinh1.dTP_NgayHetHan.Value;
                else
                    oHopdong.Ngay_Het_Han = null;

                //if (comB_DonVi.SelectedText != "")
                oHopdong.Don_Vi_ID = Convert.ToInt16(comB_DonVi.SelectedValue);
                //else
                //    oHopdong.Don_Vi_ID = null;

                if (comB_ChucDanh.Text != "")
                    oHopdong.Chuc_Danh_ID = Convert.ToInt16(comB_ChucDanh.SelectedValue);
                else
                    oHopdong.Chuc_Danh_ID = null;

                if (comB_ChucVu.Text != "")
                    oHopdong.Chuc_Vu_ID = Convert.ToInt16(comB_ChucVu.SelectedValue);
                else
                    oHopdong.Chuc_Vu_ID = null;

                oHopdong.Ghi_Chu = thongTinQuyetDinh1.rTB_MoTa.Text;
                oHopdong.Tham_nien_nang_bac = cb_ThamNienNB.Checked;
                oHopdong.Tham_nien_nha_giao = cb_ThamNienNG.Checked;

                #region Lương Info
                if (comb_Luong.SelectedIndex == 0)      // he so
                {
                    oHopdong.Khoan_or_HeSo = true;
                    oHopdong.Luong_Khoan = null;
                    oHopdong.BacHeSo_ID = Convert.ToInt32(comb_Bac.SelectedValue.ToString());
                    oHopdong.PhanTramHuong = Convert.ToDouble(nup_PhanTram.Value);
                }
                else
                {
                    oHopdong.Khoan_or_HeSo = false;
                    oHopdong.Luong_Khoan = Convert.ToDouble(txt_Tien.Text);
                    oHopdong.BacHeSo_ID = null;
                    oHopdong.PhanTramHuong = Convert.ToDouble(nup_PhanTram.Value);
                }

                #endregion

                #region Phu cap Info
                oHopdong.Co_Phu_Cap = !cb_CoPhuCap.Checked;

                List<int> loai_pc_id = new List<int>();
                List<double> value_khoan = new List<double>();
                List<double> value_heso = new List<double>();
                List<double> value_phantram = new List<double>();
                List<double> phan_tram = new List<double>();
                List<DateTime> tu_ngay = new List<DateTime>();
                List<DateTime> den_ngay = new List<DateTime>();
                List<string> ghi_chu = new List<string>();

                foreach (DataRow dr in dtPhuCap.Rows)
                {
                    int loaipc_id = Convert.ToInt16(dr["loai_pc_id"].ToString());
                    loai_pc_id.Add(loaipc_id);

                    int cach_tinh = Convert.ToInt16((from c in dtLoaiPC.AsEnumerable()
                                                     where c.Field<int>("id") == loaipc_id
                                                     select c.Field<int>("cach_tinh")).ElementAt(0).ToString());

                    switch (cach_tinh)
                    {
                        case 1:
                            if (dr["value_khoan"].ToString() == "")
                                value_khoan.Add(-1);
                            else
                                value_khoan.Add(Convert.ToDouble(dr["value_khoan"].ToString()));

                            value_heso.Add(-1);
                            value_phantram.Add(-1);
                            break;
                        case 2:
                            value_khoan.Add(-1);

                            if (dr["value_he_so"].ToString() == "")
                                value_heso.Add(-1);
                            else
                                value_heso.Add(Convert.ToDouble(dr["value_he_so"].ToString()));

                            value_phantram.Add(-1);
                            break;
                        case 3:
                            value_khoan.Add(-1);

                            if (dr["value_he_so"].ToString() == "")
                                value_heso.Add(-1);
                            else
                                value_heso.Add(Convert.ToDouble(dr["value_he_so"].ToString()));

                            value_phantram.Add(-1);
                            break;
                        case 4:
                            value_khoan.Add(-1);
                            value_heso.Add(-1);

                            if (dr["value_phan_tram"].ToString() == "")
                                value_phantram.Add(-1);
                            else
                                value_phantram.Add(Convert.ToDouble(dr["value_phan_tram"].ToString()));
                            break;
                        default:
                            break;
                    }
                    phan_tram.Add(Convert.ToDouble(dr["phan_tram_huong"].ToString()));
                    tu_ngay.Add(Convert.ToDateTime(dr["tu_ngay"].ToString()).Date);

                    if (dr["den_ngay"].ToString() == "")
                        den_ngay.Add(Convert.ToDateTime("01/01/1901").Date);
                    else
                        den_ngay.Add(Convert.ToDateTime(dr["den_ngay"].ToString()).Date);

                    ghi_chu.Add(dr["ghi_chu"].ToString());
                }

                oHopdong.Loai_Phu_Cap_ID = loai_pc_id.ToArray();
                oHopdong.Value_Khoan = value_khoan.ToArray();
                oHopdong.Value_HeSo = value_heso.ToArray();
                oHopdong.Value_PhanTram = value_phantram.ToArray();
                oHopdong.PC_PhanTramHuong = phan_tram.ToArray();
                oHopdong.PC_TuNgay = tu_ngay.ToArray();
                oHopdong.PC_DenNgay = den_ngay.ToArray();
                oHopdong.PC_GhiChu = ghi_chu.ToArray();

                #endregion

                if (IsUpdate == false)
                {
                    try
                    {
                        if (MessageBox.Show("Bạn thực sự muốn thêm quyết định tiếp nhận cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //if (oHopdong.Add())
                            //if (oHopdong.Add_wLuong())
                            if (oHopdong.Add_wLuong_PhuCap())
                            {
                                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bUploadInfoSuccess = true;
                                ResetInterface();
                            }
                            else
                                MessageBox.Show("Thao tác thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            if (oFile.Path.Count > 0 && bUploadInfoSuccess)
                            {
                                UploadFile();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thao tác thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        if (MessageBox.Show("Bạn thực sự muốn sửa quyết định tiếp nhận cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //if (oHopdong.Add())
                            //if (oHopdong.Add_wLuong())
                            if (oHopdong.Update_wLuong_PhuCap(p_ma_tuyen_dung_old))
                            {
                                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bUploadInfoSuccess = true;
                                ResetInterface();
                            }
                            else
                                MessageBox.Show("Thao tác cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            if (oFile.Path.Count > 0 && bUploadInfoSuccess)
                            {
                                UploadFile();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thao tác thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #region KHANG - UPLOAD / DOWNLOAD FILE
        private void UploadFile()
        {
            #region HD

            nNewFilesCount = oFile.Path.Count;
            ServerPaths = new string[nNewFilesCount];
            try
            {

                pb_Status.Value = 0;
                pb_Status.Maximum = nNewFilesCount;

                //this.Enabled = false;
                ((Form)this.Parent.Parent).ControlBox = false;
                this.Enabled = false;
                bw_upload.RunWorkerAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("Quá trình tải hình lên server không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((Form)this.Parent.Parent).ControlBox = true;
                this.Enabled = true;
            }



            #endregion
        }

        private void bw_upload_DoWork(object sender, DoWorkEventArgs e)
        {

            for (int i = 0; i < nNewFilesCount; i++)
            {
                bw_upload.ReportProgress(i + 1);

                ServerPaths[i] = oFTP.UploadFile(oFile.Path[i], oFile.Path[i].Split('\\').Last(), oFile.Group[i], oHopdong.Ma_Tuyen_Dung);
                Thread.Sleep(100);

            }
        }

        private void bw_upload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            pb_Status.Value = e.ProgressPercentage;
            // Set the text.
            lbl_Status.Text = "Đang đăng tập tin ..." + e.ProgressPercentage.ToString() + " / " + nNewFilesCount.ToString();
        }

        private void bw_upload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (oFile.Path.Count >0)
            {
                MessageBox.Show("Quá trình đăng tập tin lên server thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbl_Status.Text = "Đăng hình hoàn tất!";

                try
                {
                    for (int i = 0; i < oFile.Path.Count; i++)
                    {
                        oFile.Link[i] = oHopdong.Ma_Tuyen_Dung;
                    }
                    oFile.MaNV = oHopdong.Ma_NV;
                    oFile.AddFileArray(ServerPaths);

                }
                catch (Exception)
                {
                    MessageBox.Show("Quá trình lưu tập tin không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ((Form)this.Parent.Parent).ControlBox = true;
                this.Enabled = true;
                oFile.DisputeObject();
            }


            
        }



        private void btn_NhapFile_Click(object sender, EventArgs e)
        {
            UCs.DSTapTin oDSTapTin = new UCs.DSTapTin("TiepNhan", oFile);
            oDSTapTin.txt_MaTapTin.Enabled = false;
            Form f = new Forms.Popup(oDSTapTin, "QUẢN LÝ NHÂN SỰ - DANH SÁCH TẬP TIN");
            f.ShowDialog();
        }

      

        #endregion

        private void txt_Tien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txt_Tien_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Tien.Text) &&
                e.KeyCode != Keys.Left && e.KeyCode != Keys.Right &&
                e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
            {
                //txt_Tien.Text = Convert.ToDouble(txt_Tien.Text).ToString("#,#", CultureInfo.InvariantCulture);
                txt_Tien.Text = Convert.ToDouble(txt_Tien.Text).ToString("#,#");
                txt_Tien.SelectionStart = txt_Tien.TextLength;
            }
        }

        private void txt_TienPC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txt_TienPC_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_TienPC.Text) &&
                e.KeyCode != Keys.Left && e.KeyCode != Keys.Right &&
                e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
            {
                //txt_Tien.Text = Convert.ToDouble(txt_Tien.Text).ToString("#,#", CultureInfo.InvariantCulture);
                txt_TienPC.Text = Convert.ToDouble(txt_TienPC.Text).ToString("#,#");
                txt_TienPC.SelectionStart = txt_TienPC.TextLength;
            }
        }

        private bool CheckInputData()
        {
            try
            {
                var result = (from c in dtDSDonVi.AsEnumerable()
                              where c.Field<int>("id") == Convert.ToInt32(comB_DonVi.SelectedValue.ToString())
                              select new { tu_ngay = c.Field<DateTime>("tu_ngay") }).ToList();

                //DataTable dt = ToDataTable(result);

                if (thongTinQuyetDinh1.dTP_NgayHieuLuc.Value >= result[0].tu_ngay)
                {
                    if (thongTinCNVC1.txt_MaNV.Text != "" && thongTinQuyetDinh1.txt_MaQD.Text != "" && thongTinQuyetDinh1.txt_TenQD.Text != "" &&
                            ((dtPhuCap.Rows.Count > 0 && cb_CoPhuCap.Checked == false) || cb_CoPhuCap.Checked == true))
                        return true;
                    else
                        return false;
                }
                else
                {
                    MessageBox.Show("Thời gian bắt đầu hợp đồng sớm hơn thời gian đơn vị bắt đầu hoạt động. Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void comB_LoaiPhuCap_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EditInterface_LoaiPC();
        }

        private void EditInterface_LoaiPC()
        {
            try
            {
                int id = Convert.ToInt16(comB_LoaiPhuCap.SelectedValue.ToString());
                int cach_tinh = Convert.ToInt16((from c in dtLoaiPC.AsEnumerable()
                                                 where c.Field<int>("id") == id
                                                 select c.Field<int>("cach_tinh")).ElementAt(0).ToString());

                string cong_thuc = (from c in dtLoaiPC.AsEnumerable()
                                    where c.Field<int>("id") == id
                                    select c.Field<string>("chuoi_cong_thuc")).ElementAt(0).ToString();
                switch (cach_tinh)
                {
                    case 1:
                        txt_TienPC.Enabled = true;
                        txt_HeSoPC.Enabled = false;
                        nup_Value_PhanTramPC.Enabled = false;
                        break;
                    case 2:
                        txt_TienPC.Enabled = false;
                        txt_HeSoPC.Enabled = true;
                        txt_Luong_PC.Text = "Lương cơ bản";
                        nup_Value_PhanTramPC.Enabled = false;
                        break;
                    case 3:
                        txt_TienPC.Enabled = false;
                        txt_HeSoPC.Enabled = true;
                        txt_Luong_PC.Text = "Lương tối thiểu";
                        nup_Value_PhanTramPC.Enabled = false;
                        break;
                    case 4:
                        txt_TienPC.Enabled = false;
                        txt_HeSoPC.Enabled = false;
                        nup_Value_PhanTramPC.Enabled = true;
                        txt_CongThucPC.Text = cong_thuc;
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        private void btn_AddPC_Click(object sender, EventArgs e)
        {
            DataRow dr = dtPhuCap.NewRow();
            dr["id"] = row_count_pc;
            dr["loai_pc_id"] = comB_LoaiPhuCap.SelectedValue;
            dr["ten_loai"] = comB_LoaiPhuCap.Text;
            if (!String.IsNullOrEmpty(txt_TienPC.Text) && txt_TienPC.Enabled == true)
                dr["value_khoan"] = Convert.ToDouble(txt_TienPC.Text);
            else
                dr["value_khoan"] = DBNull.Value;

            if (!String.IsNullOrEmpty(txt_HeSoPC.Text) && txt_HeSoPC.Enabled == true)
                dr["value_he_so"] = Convert.ToDouble(txt_HeSoPC.Text);
            else
                dr["value_he_so"] = DBNull.Value;

            if (!String.IsNullOrEmpty(nup_Value_PhanTramPC.Text) && nup_Value_PhanTramPC.Enabled == true)
                dr["value_phan_tram"] = Convert.ToDouble(nup_Value_PhanTramPC.Text);
            else
                dr["value_phan_tram"] = DBNull.Value;

            dr["phan_tram_huong"] = Convert.ToDouble(nup_PhanTramPC.Value);

            try
            {
                dr["tu_ngay"] = dTP_NgayBatDauPC.Value;

                if (dTP_NgayHetHanPC.Checked)
                    dr["den_ngay"] = dTP_NgayHetHanPC.Value;
                else
                    dr["den_ngay"] = DBNull.Value;
            }
            catch { }

            dr["ghi_chu"] = rTB_GhiChuPC.Text;

            dtPhuCap.Rows.Add(dr);
            row_count_pc++;

            PrepareDTGVSource(dtPhuCap);
        }

        private void btn_DelPC_Click(object sender, EventArgs e)
        {
            try
            {
                int select_row = Convert.ToInt16(dtgv_DSPhuCap.CurrentRow.Cells["id"].Value.ToString());
                DataRow[] drr = dtPhuCap.Select("id=" + select_row);
                foreach (DataRow row in drr)
                    row.Delete();

                dtPhuCap.AcceptChanges();
                PrepareDTGVSource(dtPhuCap);
            }
            catch 
            {
                MessageBox.Show("Vui lòng chọn dòng dữ liệu cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_DungHD_Click(object sender, EventArgs e)
        {

        }

        
    }
}
