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

        public TiepNhan()
        {
            InitializeComponent();
            InitObject();
        }

        public TiepNhan(Business.HDQD.CNVC_HopDong p_HopDong)
        {
            InitializeComponent();
            InitObject();

            oHopdong = p_HopDong;
            DisplayInfo();
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
        }

        private void TiepNhan_Load(object sender, EventArgs e)
        {
            PreapreDataSource();
            Prepare_Data_BacHeSo();

            comb_Luong.SelectedIndex = 0;
        }

        #region Private Methods
        private void PreapreDataSource()
        {
            comB_ChucDanh.DataSource = oChucdanh.GetList();
            comB_ChucDanh.DisplayMember = "ten_chuc_danh";
            comB_ChucDanh.ValueMember = "id";

            comB_ChucVu.DataSource = oChucvu.GetList();
            comB_ChucVu.DisplayMember = "ten_chuc_vu";
            comB_ChucVu.ValueMember = "id";

            comB_DonVi.DataSource = oDonvi.GetActiveDonVi();
            comB_DonVi.DisplayMember = "ten_don_vi";
            comB_DonVi.ValueMember = "id";

            comB_LoaiPhuCap.DataSource = oLoaiPC.GetList();
            comB_LoaiPhuCap.DisplayMember = "ten_loai";
            comB_LoaiPhuCap.ValueMember = "id";
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

        private void DisplayInfo()
        { 
        
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

        private void cb_CoPhuCap_CheckedChanged(object sender, EventArgs e)
        {
            comB_LoaiPhuCap.Enabled = txt_TienPC.Enabled = txt_HeSoPC.Enabled = comB_LuongPC.Enabled = txt_CongThucPC.Enabled = dTP_NgayBatDauPC.Enabled =
                dTP_NgayHetHanPC.Enabled = nup_PhanTramPC.Enabled = rTB_GhiChuPC.Enabled = !cb_CoPhuCap.Checked;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {

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
            if (thongTinCNVC1.txt_MaNV.Text != "" && thongTinQuyetDinh1.txt_MaQD.Text != "")
                return true;
            else
                return false;
        }
    }
}
