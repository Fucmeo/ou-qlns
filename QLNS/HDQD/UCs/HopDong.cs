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
using System.Globalization;
using System.Threading;

namespace HDQD.UCs
{
    public partial class HopDong : UserControl
    {
        Business.HDQD.CNVC_HopDong oHopdong;
        Business.HDQD.LoaiHopDong oLoaihopdong;
        Business.ChucDanh oChucdanh;
        Business.ChucVu oChucvu;
        Business.DonVi oDonvi;
        Business.HDQD.LoaiPhuCap oLoaiPC;
        Business.CNVC.CNVC cnvc;
        Business.FTP oFTP;
        public Business.CNVC.CNVC_File oFile;

        Business.Luong.BacHeSo oBacHeSo;
        DataTable dtBacHeSo;

        DataTable dtLoaiPC;

        DataTable dtPhuCap;
        int row_count_pc = 0;

        // KHANG - UPLOAD FILE
        public static List<KeyValuePair<string, bool?>> Paths;
        //public static string[] Paths;
        public static string Desc;
        public static DataTable dtFile;
        string[] ServerPaths;
        int nNewFilesCount;         // so file add new
        string[] dbPaths;


        public HopDong()
        {
            InitializeComponent();
            InitObject();

        }

        public HopDong(Business.HDQD.CNVC_HopDong p_HopDong)
        {
            InitializeComponent();
            InitObject();

            oHopdong = p_HopDong;
            DisplayInfo();
            LoadFilesDB(); // load danh sach file lien quan den hop dong nay
        }

        private void InitObject()
        {
            oHopdong = new Business.HDQD.CNVC_HopDong();
            oLoaihopdong = new Business.HDQD.LoaiHopDong();
            oChucdanh = new ChucDanh();
            oChucvu = new ChucVu();
            oDonvi = new DonVi();
            oFTP = new Business.FTP();
            oFTP.oFileCate = FTP.FileCate.HDQD;
            oFile = new Business.CNVC.CNVC_File();
            oBacHeSo = new Business.Luong.BacHeSo();
            dtBacHeSo = new DataTable();
            dtFile = new DataTable();
            Paths = new List<KeyValuePair<string, bool?>>();
            oLoaiPC = new Business.HDQD.LoaiPhuCap();
            dtPhuCap = new DataTable();
            dtLoaiPC = new DataTable();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (CheckInputData())
            {
                bool bUploadInfoSuccess = false;    // KHANG : dung de biet upload info thanh cong 
                                                    // neu thanh cong moi upload file
                oHopdong.Ma_NV = thongTinCNVC1.txt_MaNV.Text;

                oHopdong.Ma_Tuyen_Dung = txt_MaHD.Text;
                oHopdong.Ma_Loai_HD = Convert.ToInt16(comB_LoaiHD.SelectedValue);

                oHopdong.La_QD_Tiep_Nhan = false;
                oHopdong.Ten_Quyet_Dinh = null;
                oHopdong.Loai_QD_ID = null;

                oHopdong.Co_Thoi_Han = cb_ThoiHan.Checked;

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

                oHopdong.Ghi_Chu = rTB_GhiChu.Text;

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

                try
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm hợp đồng cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                        if (Paths != null && Paths.Count > 0 && bUploadInfoSuccess)
                        {
                            UploadFile();
                        }
                    }
                }
                catch (Exception )
                {
                    MessageBox.Show("Thao tác thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void HopDong_Load(object sender, EventArgs e)
        {
            dtLoaiPC = oLoaiPC.GetList_Cbo();

            PreapreDataSource();
            Prepare_Data_BacHeSo();
            PrepareDataTablePhuCap();
            //CreateColumnsDtgv();

            comb_Luong.SelectedIndex = 0;
        }

        #region Private Methods

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


        private void Prepare_Data_BacHeSo()
        {
            dtBacHeSo = oBacHeSo.GetData();
            Load_Data_Cbo_Ngach();

            try
            {
                string m_ma_ngach = comb_Ngach.SelectedValue.ToString();

                var result = (from c in dtBacHeSo.AsEnumerable()
                              where c.Field<string>("ma_ngach") == m_ma_ngach && c.Field<bool>("tinh_trang") == true
                              select new { id = c.Field<int>("id"), bac = c.Field<int>("bac"), he_so = c.Field<double>("he_so") }
                                  ).ToList();

                DataTable dt = ToDataTable(result);

                comb_Bac.DataSource = dt;
                comb_Bac.DisplayMember = "bac";
                comb_Bac.ValueMember = "id";


                int m_id = Convert.ToInt32(comb_Bac.SelectedValue.ToString());

                var result1 = (from c in dtBacHeSo.AsEnumerable()
                               where c.Field<int>("id") == m_id
                               select c.Field<double>("he_so"));

                double m_he_so = result1.ElementAt<double>(0);

                txt_HeSo.Text = m_he_so.ToString();
            }
            catch { }
        }

        private void Load_Data_Cbo_Ngach()
        {
            try
            {
                var result = (from c in dtBacHeSo.AsEnumerable()
                              select new { ma_ngach = c.Field<string>("ma_ngach"), ten_ngach = c.Field<string>("ten_ngach") }
                              ).Distinct().ToList();

                DataTable dt = ToDataTable(result);

                comb_Ngach.DataSource = dt;
                comb_Ngach.DisplayMember = "ten_ngach";
                comb_Ngach.ValueMember = "ma_ngach";
            }
            catch { }
        }

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
            
            txt_MaHD.Text = txt_HeSo.Text = txt_Tien.Text
                = txt_TienPC.Text = txt_HeSoPC.Text = rTB_GhiChuPC.Text
                //= txt_HeSoLuong.Text = txt_PhanTram.Text 
                = rTB_GhiChu.Text = "";
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

            comB_DonVi.DataSource = oDonvi.GetActiveDonVi();
            comB_DonVi.DisplayMember = "ten_don_vi";
            comB_DonVi.ValueMember = "id";

            comB_LoaiPhuCap.DataSource = dtLoaiPC;
            comB_LoaiPhuCap.DisplayMember = "ten_loai";
            comB_LoaiPhuCap.ValueMember = "id";
            EditInterface_LoaiPC();
        }

        /// <summary>
        /// Khang - load ds file di kem HD nay
        /// </summary>
        private void LoadFilesDB()
        {
            oFile.MaNV = oHopdong.Ma_NV;
            oFile.Link = oHopdong.Ma_Hop_Dong;
            oFile.FileType = Business.CNVC.CNVC_File.eFileType.HopDong;
            try
            {
                dtFile = oFile.GetData();
            }
            catch (Exception)
            {
                
            }
             
        }

        private void DisplayInfo()
        {
            //thongTinCNVC1.txt_MaNV.Text = oHopdong.Ma_NV;
            //// thông tin Họ tên NV.
            //cnvc = new Business.CNVC.CNVC();
            //cnvc.MaNV = oHopdong.Ma_NV;
            //DataTable dtHoTenNV = cnvc.Search_Ho_Ten();
            //thongTinCNVC1.txt_Ho.Text = dtHoTenNV.Rows[0]["ho"].ToString();
            //thongTinCNVC1.txt_Ten.Text = dtHoTenNV.Rows[0]["ten"].ToString();

            //txt_MaHD.Text = oHopdong.Ma_Hop_Dong;
            //rTB_GhiChu.Text = oHopdong.Ghi_Chu;

            //if (oHopdong.Ngay_Ky != null)
            //{
            //    dTP_NgayKy.Checked = true;
            //    dTP_NgayKy.Value = oHopdong.Ngay_Ky.Value;
            //}
            //if (oHopdong.Ngay_Hieu_Luc != null)
            //{
            //    dtp_TuNgay.Checked = true;
            //    dtp_TuNgay.Value = oHopdong.Ngay_Hieu_Luc.Value;
            //}
            //if (oHopdong.Ngay_Het_Han != null)
            //{
            //    dtp_DenNgay.Checked = true;
            //    dtp_DenNgay.Value = oHopdong.Ngay_Het_Han.Value;
            //}

            ////Xử lý combo box
            //if (oHopdong.Chuc_Danh_ID != null)
            //    comB_ChucDanh.SelectedValue = oHopdong.Chuc_Danh_ID;
            //if (oHopdong.Chuc_Vu_ID != null)
            //    comB_ChucVu.SelectedValue = oHopdong.Chuc_Vu_ID;
            //if (oHopdong.Don_Vi_ID != null)
            //    comB_DonVi.SelectedValue = oHopdong.Don_Vi_ID;
            //if (oHopdong.Ma_Loai_HD != null)
            //    comB_LoaiHD.SelectedValue = oHopdong.Ma_Loai_HD;
            ////if (oHopdong.ThuViec_ChinhThuc == true) //chính thức
            ////    comB_ThuViecChinhThuc.Text = "Chính thức";
            ////else
            ////    comB_ThuViecChinhThuc.Text = "Thử việc";

            //cb_ThoiHan.Checked = oHopdong.Co_Thoi_Han.Value;

            ////try
            ////{
            ////    comB_ChucDanh.SelectedValue = oHopdong.Chuc_Danh_ID;
            ////    comB_ChucVu.SelectedValue = oHopdong.Chuc_Vu_ID;
            ////    comB_DonVi.SelectedValue = oHopdong.Don_Vi_ID;
            ////    comB_LoaiHD.SelectedValue = oHopdong.Ma_Loai_HD;
            ////    if (oHopdong.ThuViec_ChinhThuc == true) //chính thức
            ////        comB_ThuViecChinhThuc.Text = "Chính thức";
            ////    else
            ////        comB_ThuViecChinhThuc.Text = "Thử việc";
            ////}
            ////catch {
            ////    comB_ChucDanh.SelectedValue = 0;
            ////    comB_ChucVu.SelectedValue = 0;
            ////    comB_DonVi.SelectedValue = 0;
            ////    comB_LoaiHD.SelectedValue = 0;
            ////}
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

        #endregion

        private void txt_MaHD_TextChanged(object sender, EventArgs e)
        {
            if (txt_MaHD.TextLength > 0)
                btn_Them.Enabled = btn_DungHD.Enabled = btn_NhapFile.Enabled = true;
            else
                btn_Them.Enabled = btn_DungHD.Enabled = btn_NhapFile.Enabled = false;
        }

        private void comB_LoaiHD_DropDownClosed(object sender, EventArgs e)
        {
            //if (!comB_LoaiHD.Items.Contains(oHopdong.Loai_Hop_Dong))
            //{
            //    comB_LoaiHD.Items.Remove(oHopdong.Loai_Hop_Dong);
            //}
        }

        private void btn_DungHD_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_MaHD.Text) && !String.IsNullOrEmpty(thongTinCNVC1.txt_MaNV.Text))
            {
                try
                {
                    if (MessageBox.Show("Bạn thực sự muốn dừng hợp đồng của nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oHopdong.Ma_NV = thongTinCNVC1.txt_MaNV.Text;
                        oHopdong.Ma_Hop_Dong = txt_MaHD.Text;

                        if (oHopdong.StopHopDong())
                        {
                            MessageBox.Show("Thao tác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetInterface();
                        }
                        else
                            MessageBox.Show("Thao tác thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception )
                {
                    MessageBox.Show("Thao tác thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_NhapFile_Click(object sender, EventArgs e)
        {
            if (oHopdong.Ma_Hop_Dong != null)
            {
                LoadFilesDB();
                DownLoadFile();  
            }

            
        }

        // KHANG
        private void DownLoadFile()
        {
            if (dtFile != null && dtFile.Rows.Count > 0)
            {
                pb_Status.Value = 0;
                pb_Status.Maximum = dtFile.Rows.Count;

                dbPaths = new string[dtFile.Rows.Count];
                for (int i = 0; i < dtFile.Rows.Count; i++)
                {
                    dbPaths[i] = dtFile.Rows[i]["path"].ToString();
                }

                Desc = dtFile.Rows[0]["mo_ta"].ToString();

                // Download 
               
                try
                {
                    bw_download.RunWorkerAsync();
                    
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Quá trình tải hình đại diện không thành công \r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void UploadFile()
        {
            #region HD

            nNewFilesCount = Paths.Where(a => a.Value == false).Count();
            ServerPaths = new string[nNewFilesCount];
            try
            {
                oFTP.oFileCate = FTP.FileCate.HDQD;
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            string[] NewFiles = Paths.Where(a => a.Value == false).Select(a => a.Key).ToArray();
            for (int i = 0; i < nNewFilesCount; i++)
            {
                bw_upload.ReportProgress(i + 1);

                ServerPaths[i] = oFTP.UploadFile(NewFiles[i], NewFiles[i].Split('\\').Last(), oHopdong.Ma_Hop_Dong);
                Thread.Sleep(100);
                
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            pb_Status.Value = e.ProgressPercentage;
            // Set the text.
            lbl_Status.Text = "Đang đăng tập tin ..." + e.ProgressPercentage.ToString() + " / " + nNewFilesCount.ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Paths.Where(a => a.Value == false).Select(a => a.Key).ToArray().Length > 0)
            {
                MessageBox.Show("Quá trình đăng tập tin lên server thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbl_Status.Text = "Đăng hình hoàn tất!";
            }

            oFile.MaNV = oHopdong.Ma_NV;
            oFile.FileType = Business.CNVC.CNVC_File.eFileType.HopDong;
            oFile.Link = oHopdong.Ma_Hop_Dong;
            oFile.MoTa = Desc;
            string[] DeleteFiles = Paths.Where(a => a.Value == null).Select(a => a.Key).ToArray();

            try
            {
                oFile.AddFileArray(ServerPaths);
                if (DeleteFiles.Length > 0)
                    oFile.Delete_HD_QD(DeleteFiles);
            }
            catch (Exception)
            {
                MessageBox.Show("Quá trình lưu tập tin không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ((Form)this.Parent.Parent).ControlBox = true;
            this.Enabled = true;
        }

        private void bw_download_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] a = new string[1];

            for (int i = 0; i < dbPaths.Length; i++)
            {
                bw_download.ReportProgress(i + 1);

                
                a[0] = dbPaths[i];
                string downloadpath = oFTP.DownloadFile(a)[0];

                Paths.Add(new KeyValuePair<string, bool?>(downloadpath, true));

                Thread.Sleep(100);
            }

           
        }

        private void bw_download_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            pb_Status.Value = e.ProgressPercentage;
            // Set the text.
            lbl_Status.Text = "Đang tải tập tin ..." + e.ProgressPercentage.ToString() + " / " + dbPaths.Length.ToString();


        }

        private void bw_download_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbl_Status.Text = "Tải tập tin hoàn tất!";

            Forms.Popup f = new Forms.Popup(new UCs.DSTapTin(Paths, Desc), "QUẢN LÝ NHÂN SỰ - DANH SÁCH TẬP TIN");
            UCs.DSTapTin.bHopDong = true;
            f.ShowDialog();
        }

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

        private void comb_Ngach_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string m_ma_ngach = comb_Ngach.SelectedValue.ToString();

                var result = (from c in dtBacHeSo.AsEnumerable()
                              where c.Field<string>("ma_ngach") == m_ma_ngach && c.Field<bool>("tinh_trang") == true
                              select new { id = c.Field<int>("id"), bac = c.Field<int>("bac"), he_so = c.Field<double>("he_so") }
                                  ).ToList();

                DataTable dt = ToDataTable(result);

                comb_Bac.DataSource = dt;
                comb_Bac.DisplayMember = "bac";
                comb_Bac.ValueMember = "id";
            }
            catch { }
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
                dTP_NgayHetHanPC.Enabled = nup_PhanTramPC.Enabled = rTB_GhiChuPC.Enabled = dtgv_DSPhuCap.Enabled = !cb_CoPhuCap.Checked;
            EditInterface_LoaiPC();
        }

        private void btn_AddPC_Click(object sender, EventArgs e)
        {
            DataRow dr = dtPhuCap.NewRow();
            dr["id"] = row_count_pc;
            dr["loai_pc_id"] = comB_LoaiPhuCap.SelectedValue;
            dr["ten_loai"] = comB_LoaiPhuCap.Text;
            if (String.IsNullOrEmpty(txt_TienPC.Text))
                dr["value_khoan"] = DBNull.Value;
            else
                dr["value_khoan"] = Convert.ToDouble(txt_TienPC.Text);

            if (String.IsNullOrEmpty(txt_HeSoPC.Text))
                dr["value_he_so"] = DBNull.Value;
            else
                dr["value_he_so"] = Convert.ToDouble(txt_HeSoPC.Text);

            if (String.IsNullOrEmpty(nup_Value_PhanTramPC.Text))
                dr["value_phan_tram"] = DBNull.Value;
            else
                dr["value_phan_tram"] = Convert.ToDouble(nup_Value_PhanTramPC.Text);

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

        private void CreateColumnsDtgv()
        {
            dtgv_DSPhuCap.Columns.Add("id", "ID");
            dtgv_DSPhuCap.Columns.Add("loai_pc_id", "Loại Phụ cấp ID");
            dtgv_DSPhuCap.Columns.Add("ten_loai", "Loại Phụ cấp");
            dtgv_DSPhuCap.Columns.Add("value_khoan", "Giá trị Khoán");
            dtgv_DSPhuCap.Columns.Add("value_he_so", "Giá trị Hệ số");
            dtgv_DSPhuCap.Columns.Add("value_phan_tram", "Giá trị Phần trăm");
            dtgv_DSPhuCap.Columns.Add("phan_tram_huong", "Phần trăm được hưởng");
            dtgv_DSPhuCap.Columns.Add("tu_ngay", "Từ ngày");
            dtgv_DSPhuCap.Columns.Add("den_ngay", "Đến ngày");
            dtgv_DSPhuCap.Columns.Add("ghi_chu", "Ghi chú");

            dtgv_DSPhuCap.Columns["id"].Visible = false;
            //dtgv_DSPhuCap.Columns["loai_pc_id"].Visible = false;
            dtgv_DSPhuCap.Columns["ghi_chu"].Visible = false;
        }

        private void btn_DelPC_Click(object sender, EventArgs e)
        {
            int select_row = Convert.ToInt16(dtgv_DSPhuCap.CurrentRow.Cells["id"].Value.ToString());
            DataRow[] drr = dtPhuCap.Select("id=" + select_row);
            foreach (DataRow row in drr)            
                row.Delete();

            dtPhuCap.AcceptChanges();
            PrepareDTGVSource(dtPhuCap);
        }

        private void dtgv_DSPhuCap_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSPhuCap.CurrentRow != null)
            {
                try
                {
                    comB_LoaiPhuCap.Text = dtgv_DSPhuCap.CurrentRow.Cells["ten_loai"].Value.ToString();
                    txt_TienPC.Text = dtgv_DSPhuCap.CurrentRow.Cells["value_khoan"].Value.ToString();
                    txt_HeSoPC.Text = dtgv_DSPhuCap.CurrentRow.Cells["value_he_so"].Value.ToString();
                    nup_Value_PhanTramPC.Value = Convert.ToDecimal(dtgv_DSPhuCap.CurrentRow.Cells["value_phan_tram"].Value.ToString());
                    nup_PhanTramPC.Value = Convert.ToDecimal(dtgv_DSPhuCap.CurrentRow.Cells["phan_tram_huong"].Value.ToString());
                    dTP_NgayBatDauPC.Value = Convert.ToDateTime(dtgv_DSPhuCap.CurrentRow.Cells["tu_ngay"].Value.ToString());
                    if (dtgv_DSPhuCap.CurrentRow.Cells["den_ngay"].Value.ToString() != "")
                    {
                        dTP_NgayHetHanPC.Checked = true;
                        dTP_NgayHetHanPC.Value = Convert.ToDateTime(dtgv_DSPhuCap.CurrentRow.Cells["den_ngay"].Value.ToString());
                    }
                    else
                        dTP_NgayHetHanPC.Checked = false;

                    rTB_GhiChuPC.Text = dtgv_DSPhuCap.CurrentRow.Cells["ghi_chu"].Value.ToString();
                }
                catch { }
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
                txt_TienPC.Text = Convert.ToDouble(txt_TienPC.Text).ToString("#,#");
                txt_TienPC.SelectionStart = txt_TienPC.TextLength;
            }
        }

        private void comB_LoaiPhuCap_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EditInterface_LoaiPC();
        }

        private void EditInterface_LoaiPC()
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
    }
}
