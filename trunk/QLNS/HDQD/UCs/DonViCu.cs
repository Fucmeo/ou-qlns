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
    public partial class DonViCu : UserControl
    {
        Business.ChucDanh oChucdanh;
        Business.ChucVu oChucvu;

        DataTable m_Don_vi;
        bool m_co_thoi_han;
        DateTime m_Den_ngay_TD;

        public DonViCu()
        {
            InitializeComponent();
        }

        public DonViCu(DataTable p_dt_don_vi)
        {
            InitializeComponent();
            InitObject();

            m_Don_vi = p_dt_don_vi;
        }

        private void DonViCu_Load(object sender, EventArgs e)
        {
            PrepateDataDonVi(m_Don_vi);
        }

        #region Private Methods
        private void PrepateDataDonVi(DataTable p_dt_DonVi)
        {
            comB_DonVi.DataSource = p_dt_DonVi;
            comB_DonVi.DisplayMember = "ten_don_vi";
            comB_DonVi.ValueMember = "id";
            Fill_Date_DonVi();
        }

        private void Fill_Date_DonVi()
        {
            try
            {
                int m_don_vi_id = Convert.ToInt32(comB_DonVi.SelectedValue.ToString());
                var result = (from c in m_Don_vi.AsEnumerable()
                              where c.Field<int>("id") == m_don_vi_id
                              select new { id = c.Field<int>("id"), tu_ngay = c.Field<DateTime>("tu_ngay"), den_ngay = c.Field<DateTime?>("den_ngay") }
                                  ).ToList();

                DataTable dt = ToDataTable(result);

                lbl_Date_DonVi.Text = "Từ ngày: " + Convert.ToDateTime(dt.Rows[0]["tu_ngay"].ToString()).ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"))
                                        + "\nĐến ngày: " + Convert.ToDateTime(dt.Rows[0]["den_ngay"].ToString()).ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"));

            }
            catch { }
        }

        private void InitObject()
        {
            oChucdanh = new ChucDanh();
            oChucvu = new ChucVu();
            m_Don_vi = new DataTable();

            PreapreDataSource();
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
            }
            catch (Exception)
            {

            }
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

        private void comB_DonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Date_DonVi();
        }

        #endregion

        private void btn_Add_Click(object sender, EventArgs e)
        {

        }


    }
}
