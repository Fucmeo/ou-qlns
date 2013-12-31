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
    public partial class HopDongCu : UserControl
    {
        Business.HDQD.CNVC_HopDong oHopdong;
        Business.HDQD.LoaiHopDong oLoaihopdong;
        Business.ChucDanh oChucdanh;
        Business.ChucVu oChucvu;
        Business.DonVi oDonvi;
        Business.HDQD.LoaiPhuCap oLoaiPC;
        Business.CNVC.CNVC cnvc;
        Business.FTP oFTP;
        public static Business.CNVC.CNVC_File oFile;

        Business.Luong.BacHeSo oBacHeSo;
        DataTable dtBacHeSo;

        DataTable dtLoaiPC;
        DataTable dtDonVi;

        DataTable dtPhuCap;
        int row_count_pc = 0;

        Business.HDQD.CNVC_PhuCap oCNVCPhuCap;

        bool IsUpdate = false;
        string p_ma_tuyen_dung_old = null;

        public HopDongCu()
        {
            InitializeComponent();
            InitObject();
            IsUpdate = false;
        }

        private void HopDongCu_Load(object sender, EventArgs e)
        {
            comb_Luong.SelectedIndex = 0;
        }

        #region Private Methods
        private void InitObject()
        {
            oHopdong = new Business.HDQD.CNVC_HopDong();
            oLoaihopdong = new Business.HDQD.LoaiHopDong();
            oChucdanh = new ChucDanh();
            oChucvu = new ChucVu();
            oDonvi = new DonVi();
            oFTP = new Business.FTP();
            oFile = new Business.CNVC.CNVC_File();
            oBacHeSo = new Business.Luong.BacHeSo();
            dtBacHeSo = new DataTable();

            oLoaiPC = new Business.HDQD.LoaiPhuCap();
            dtPhuCap = new DataTable();
            dtLoaiPC = new DataTable();
            dtDonVi = new DataTable();
            oCNVCPhuCap = new Business.HDQD.CNVC_PhuCap();

            dtLoaiPC = oLoaiPC.GetList_Cbo();

            PreapreDataSource();
            Prepare_Data_BacHeSo();
            PrepareDataTablePhuCap();
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

        private void PreapreDataSource()
        {
            try
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

                dtDonVi = oDonvi.GetInActiveDonVi();
                comB_DonVi.DataSource = dtDonVi;
                comB_DonVi.DisplayMember = "ten_don_vi";
                comB_DonVi.ValueMember = "id";
                Fill_Date_DonVi();

                comB_LoaiPhuCap.DataSource = dtLoaiPC;
                comB_LoaiPhuCap.DisplayMember = "ten_loai";
                comB_LoaiPhuCap.ValueMember = "id";
                EditInterface_LoaiPC();
            }
            catch (Exception)
            {

            }
        }

        private void Fill_Date_DonVi()
        {
            try
            {
                int m_don_vi_id = Convert.ToInt32(comB_DonVi.SelectedValue.ToString());
                var result = (from c in dtDonVi.AsEnumerable()
                              where c.Field<int>("id") == m_don_vi_id
                              select new { id = c.Field<int>("id"), tu_ngay = c.Field<DateTime>("tu_ngay"), den_ngay = c.Field<DateTime?>("den_ngay") }
                                  ).ToList();

                DataTable dt = ToDataTable(result);

                txt_TuNgay_DV.Text = Convert.ToDateTime(dt.Rows[0]["tu_ngay"].ToString()).ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"));
                txt_DenNgay_DV.Text = Convert.ToDateTime(dt.Rows[0]["den_ngay"].ToString()).ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"));

            }
            catch { }
        }

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

        private void comB_LoaiPhuCap_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EditInterface_LoaiPC();
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

        private void comB_DonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Date_DonVi();
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
                DateTime dtp_donvi_denngay = DateTime.ParseExact(txt_DenNgay_DV.Text, "dd/MM/yyyy", null);
                if (dtp_DenNgay.Checked == false || dtp_DenNgay.Value > dtp_donvi_denngay)
                {
                    #region Insert multiple donvi
                    int selected_donvi = Convert.ToInt32(comB_DonVi.SelectedValue);

                    DataTable dt_donvi_new = oDonvi.GetDonVi_New(selected_donvi);

                    string loai_qd = (from c in dt_donvi_new.AsEnumerable()
                                      select c.Field<string>("ten_loai_qd")).ElementAt(0).ToString();
                    string ten_qd = (from c in dt_donvi_new.AsEnumerable()
                                     select c.Field<string>("ten_qd")).ElementAt(0).ToString();
                    string ma_qd = (from c in dt_donvi_new.AsEnumerable()
                                    select c.Field<string>("ma_quyet_dinh")).ElementAt(0).ToString();
                    DateTime ngay_hieu_luc_qd = (from c in dt_donvi_new.AsEnumerable()
                                                 select c.Field<DateTime>("ngay_hieu_luc_qd")).ElementAt(0);

                    MessageBox.Show("Loại quyết định: " + loai_qd + "\nMã quyết định: " + ma_qd + "\nTên quyết định: " + ten_qd + "\nNgày hiệu lực: " + ngay_hieu_luc_qd.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN")) + "\nVui lòng chọn đơn vị phù hợp.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Forms.Popup frPopup = new Forms.Popup(new UCs.DonViCu(dt_donvi_new), "Danh sách đơn vị");
                    frPopup.ShowDialog();




                    #endregion
                }


            }
            else
                MessageBox.Show("Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool CheckInputData()
        {
            try
            {
                DateTime dt_donvi_tungay = DateTime.ParseExact(txt_TuNgay_DV.Text, "dd/MM/yyyy", null);
                DateTime dt_donvi_denngay = DateTime.ParseExact(txt_DenNgay_DV.Text, "dd/MM/yyyy", null);

                if (thongTinCNVC1.txt_MaNV.Text != "" && txt_MaHD.Text != "" &&
                        ((dtPhuCap.Rows.Count > 0 && cb_CoPhuCap.Checked == false) || cb_CoPhuCap.Checked == true) &&
                        (dtp_TuNgay.Value >= dt_donvi_tungay && dtp_TuNgay.Value <= dt_donvi_denngay))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        private void txt_MaHD_TextChanged(object sender, EventArgs e)
        {
            if (txt_MaHD.TextLength > 0)
                btn_Them.Enabled = btn_DungHD.Enabled = btn_NhapFile.Enabled = true;
            else
                btn_Them.Enabled = btn_DungHD.Enabled = btn_NhapFile.Enabled = false;
        }

    }
}
