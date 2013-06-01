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
        Business.FTP oFTP;
        public Business.CNVC.CNVC_File oFile;

        Business.Luong.BacHeSo oBacHeSo;
        DataTable dtBacHeSo;

        // KHANG - UPLOAD FILE
        public static string[] Paths;
        public static string Desc;
        public static DataTable dtFile;

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
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (CheckInputData())
            {
                bool bUploadInfoSuccess = false;    // KHANG : dung de biet upload info thanh cong 
                                                    // neu thanh cong moi upload file
                oHopdong.Ma_NV = thongTinCNVC1.txt_MaNV.Text;

                oHopdong.Ma_Hop_Dong = txt_MaHD.Text;
                oHopdong.Ma_Loai_HD = Convert.ToInt16(comB_LoaiHD.SelectedValue);
                //if (comB_ThuViecChinhThuc.Text == "Thử việc")
                //    oHopdong.ThuViec_ChinhThuc = false;
                //else if (comB_ThuViecChinhThuc.Text == "Chính thức")
                //    oHopdong.ThuViec_ChinhThuc = true;

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

                if (comB_ChucDanh.SelectedText != "")
                    oHopdong.Chuc_Danh_ID = Convert.ToInt16(comB_ChucDanh.SelectedValue);
                else
                    oHopdong.Chuc_Danh_ID = null;

                if (comB_ChucVu.SelectedText != "")
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

                try
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm hợp đồng cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //if (oHopdong.Add())
                        if (oHopdong.Add_wLuong())
                        {
                            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bUploadInfoSuccess = true;
                            ResetInterface();
                        }
                        else
                            MessageBox.Show("Thao tác thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        if (Paths != null && Paths.Length > 0 && bUploadInfoSuccess)
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
            PreapreDataSource();
            Prepare_Data_BacHeSo();

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
            
            txt_MaHD.Text = txt_HeSo.Text 
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
            if (oHopdong.Chuc_Danh_ID != null)
                comB_ChucDanh.SelectedValue = oHopdong.Chuc_Danh_ID;
            if (oHopdong.Chuc_Vu_ID != null)
                comB_ChucVu.SelectedValue = oHopdong.Chuc_Vu_ID;
            if (oHopdong.Don_Vi_ID != null)
                comB_DonVi.SelectedValue = oHopdong.Don_Vi_ID;
            if (oHopdong.Ma_Loai_HD != null)
                comB_LoaiHD.SelectedValue = oHopdong.Ma_Loai_HD;
            //if (oHopdong.ThuViec_ChinhThuc == true) //chính thức
            //    comB_ThuViecChinhThuc.Text = "Chính thức";
            //else
            //    comB_ThuViecChinhThuc.Text = "Thử việc";

            cb_ThoiHan.Checked = oHopdong.Co_Thoi_Han.Value;

            //try
            //{
            //    comB_ChucDanh.SelectedValue = oHopdong.Chuc_Danh_ID;
            //    comB_ChucVu.SelectedValue = oHopdong.Chuc_Vu_ID;
            //    comB_DonVi.SelectedValue = oHopdong.Don_Vi_ID;
            //    comB_LoaiHD.SelectedValue = oHopdong.Ma_Loai_HD;
            //    if (oHopdong.ThuViec_ChinhThuc == true) //chính thức
            //        comB_ThuViecChinhThuc.Text = "Chính thức";
            //    else
            //        comB_ThuViecChinhThuc.Text = "Thử việc";
            //}
            //catch {
            //    comB_ChucDanh.SelectedValue = 0;
            //    comB_ChucVu.SelectedValue = 0;
            //    comB_DonVi.SelectedValue = 0;
            //    comB_LoaiHD.SelectedValue = 0;
            //}
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
            if (oHopdong != null)
            {
                LoadFilesDB();
                DownLoadFile();  
            }

            Forms.Popup f = new Forms.Popup(new UCs.DSTapTin(Paths,Desc), "QUẢN LÝ NHÂN SỰ - DANH SÁCH TẬP TIN");
            UCs.DSTapTin.bHopDong = true;
            f.ShowDialog();
        }

        // KHANG
        private void DownLoadFile()
        {
            if (dtFile != null && dtFile.Rows.Count > 0)
            {
                string[] dbPaths = new string[dtFile.Rows.Count];
                for (int i = 0; i < dtFile.Rows.Count; i++)
                {
                    dbPaths[i] = dtFile.Rows[i]["path"].ToString();
                }

                Desc = dtFile.Rows[0]["mo_ta"].ToString();

                // Download 
               
                try
                {
                    Paths = oFTP.DownloadFile(dbPaths);
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

            string[] ServerPath = new string[1];
            try
            {
                oFTP.oFileCate = FTP.FileCate.HDQD;
                ServerPath = oFTP.UploadFile(Paths, Paths.Select(b => b.Split('\\').Last()).ToArray(),
                                            oHopdong.Ma_Hop_Dong);

                oFile.MaNV = oHopdong.Ma_NV;
                oFile.FileType = Business.CNVC.CNVC_File.eFileType.HopDong;
                oFile.Link = oHopdong.Ma_Hop_Dong;
                try
                {
                    oFile.AddFileArray(ServerPath);

                }
                catch (Exception)
                {
                    MessageBox.Show("Quá trình lưu hình không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Quá trình tải hình lên server không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            

            #endregion
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
    }
}
