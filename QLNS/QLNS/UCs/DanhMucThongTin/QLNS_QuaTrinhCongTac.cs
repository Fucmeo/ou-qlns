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

namespace QLNS.UCs.DanhMucThongTin
{
    public partial class QLNS_QuaTrinhCongTac : UserControl
    {
        Business.CNVC.CNVC_QTr_CongTac_NonOU_GD oQtrCtac_NonOU_GD;
        DataTable dtCtac_NonOU_GD;
        Business.CNVC.CNVC_QTr_CongTac_NonOU_NonGD oQtrCtac_NonOU_NonGD;
        DataTable dtCtac_NonOU_NonGD;

        string m_ma_nv;
        bool bAddFlag;

        public QLNS_QuaTrinhCongTac()
        {
            InitializeComponent();
        }

        public QLNS_QuaTrinhCongTac(string p_ma_nv)
        {
            InitializeComponent();
            oQtrCtac_NonOU_GD = new Business.CNVC.CNVC_QTr_CongTac_NonOU_GD();
            oQtrCtac_NonOU_NonGD = new Business.CNVC.CNVC_QTr_CongTac_NonOU_NonGD();

            m_ma_nv = p_ma_nv;
        }

        private void QLNS_QuaTrinhCongTac_Load(object sender, EventArgs e)
        {
            Load_Qtr_Ctac_NonOU();

            ResetInterface(true);
        }

        private void dtgv_QTCT_Ngoai_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_QTCT_Ngoai.CurrentRow != null)
            {
                DisplayInfo(dtgv_QTCT_Ngoai.CurrentRow);
            }
        }

        #region Private Methods
        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_TenDV.Text = row.Cells["ten_don_vi"].Value.ToString();
                txt_ChucDanh.Text = row.Cells["chuc_danh"].Value.ToString();
                txt_ChucVu.Text = row.Cells["chuc_vu"].Value.ToString();
                rTB_CongViecChinh.Text = row.Cells["cong_viec"].Value.ToString();

                if (row.Cells["tu_ngay"].Value.ToString() != "")
                {
                    dTP_TuNgay.Checked = true;
                    dTP_TuNgay.Value = Convert.ToDateTime(row.Cells["tu_ngay"].Value.ToString());
                }
                else
                    dTP_TuNgay.Checked = false;

                if (row.Cells["den_ngay"].Value.ToString() != "")
                {
                    dTP_DenNgay.Checked = true;
                    dTP_DenNgay.Value = Convert.ToDateTime(row.Cells["den_ngay"].Value.ToString());
                }
                else
                    dTP_DenNgay.Checked = false;

                if (row.Cells["is_gd"].Value.ToString() == "Trong ngành giáo dục")
                    comB_Nganh.Text = "Trong ngành giáo dục";
                else
                    comB_Nganh.Text = "Ngoài ngành giáo dục";
            }
        }

        private void Load_Qtr_Ctac_NonOU()
        {
            dtCtac_NonOU_GD = new DataTable();
            dtCtac_NonOU_NonGD = new DataTable();

            oQtrCtac_NonOU_GD.MaNV = m_ma_nv;
            dtCtac_NonOU_GD = oQtrCtac_NonOU_GD.GetData();

            oQtrCtac_NonOU_NonGD.MaNV = m_ma_nv;
            dtCtac_NonOU_NonGD = oQtrCtac_NonOU_NonGD.GetData();

            if (((dtCtac_NonOU_GD) != null && dtCtac_NonOU_GD.Rows.Count > 0) || ((dtCtac_NonOU_NonGD) != null && dtCtac_NonOU_NonGD.Rows.Count > 0))
            {
                PrepareDataSource();
                EditDtgInterface();
            }
        }

        private void EditDtgInterface()
        {
            dtgv_QTCT_Ngoai.Columns["is_gd"].HeaderText = "Trong ngành giáo dục?";
            dtgv_QTCT_Ngoai.Columns["is_gd"].Width = 170;
            dtgv_QTCT_Ngoai.Columns["ten_don_vi"].HeaderText = "Tên đơn vị";
            dtgv_QTCT_Ngoai.Columns["ten_don_vi"].Width = 150;
            dtgv_QTCT_Ngoai.Columns["chuc_danh"].HeaderText = "Chức danh";
            dtgv_QTCT_Ngoai.Columns["chuc_vu"].HeaderText = "Chức vụ";
            dtgv_QTCT_Ngoai.Columns["tu_ngay"].HeaderText = "Từ ngày";
            dtgv_QTCT_Ngoai.Columns["den_ngay"].HeaderText = "Đến ngày";
            dtgv_QTCT_Ngoai.Columns["cong_viec"].HeaderText = "Công việc chính";
            dtgv_QTCT_Ngoai.Columns["cong_viec"].Width = 200;
            
            dtgv_QTCT_Ngoai.Columns["id"].Visible = false;
            dtgv_QTCT_Ngoai.Columns["ma_nv"].Visible = false;
        }

        private void PrepareDataSource()
        {
            var result = ((from c in dtCtac_NonOU_GD.AsEnumerable()
                           select new
                           {
                               is_gd = "Trong ngành giáo dục",
                               id = c.Field<int>("id"),
                               ma_nv = c.Field<string>("ma_nv"),
                               ten_don_vi = c.Field<string>("ten_don_vi"),
                               chuc_danh = c.Field<string>("chuc_danh"),
                               chuc_vu = c.Field<string>("chuc_vu"),
                               tu_ngay = c.Field<DateTime?>("tu_ngay"),
                               den_ngay = c.Field<DateTime?>("den_ngay"),
                               cong_viec = c.Field<string>("cong_viec_chinh")
                           }
                                  ).Union(
                                from d in dtCtac_NonOU_NonGD.AsEnumerable()
                                select new
                                {
                                    is_gd = "Ngoài ngành giáo dục",
                                    id = d.Field<int>("id"),
                                    ma_nv = d.Field<string>("ma_nv"),
                                    ten_don_vi = d.Field<string>("ten_don_vi"),
                                    chuc_danh = d.Field<string>("chuc_danh"),
                                    chuc_vu = d.Field<string>("chuc_vu"),
                                    tu_ngay = d.Field<DateTime?>("tu_ngay"),
                                    den_ngay = d.Field<DateTime?>("den_ngay"),
                                    cong_viec = d.Field<string>("cong_viec_chinh")
                                })).ToList();

            DataTable dt = ToDataTable(result);

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dtgv_QTCT_Ngoai.DataSource = bs;

            if (dt != null)
            {
                //lbl_Sua.Visible = lbl_Xoa.Visible = true;
            }
        }

        private void ResetInterface(bool init)
        {
            if (init)
            {
                lbl_ThemNgoai.Visible = lbl_SuaNgoai.Visible = true;
                //btn_Huy.Visible = 
                //btn_Luu.Visible = false;
                txt_ChucDanh.Enabled = txt_ChucVu.Enabled = txt_TenDV.Enabled = comB_Nganh.Enabled = dTP_DenNgay.Enabled = dTP_TuNgay.Enabled = rTB_CongViecChinh.Enabled = false;

                dtgv_QTCT_Ngoai.Enabled = true;
                if (dtgv_QTCT_Ngoai.CurrentRow != null)
                {
                    DisplayInfo(dtgv_QTCT_Ngoai.CurrentRow);
                }
            }
            else
            {
                lbl_ThemNgoai.Visible = lbl_SuaNgoai.Visible = false;
                //btn_Huy.Visible = 
                //btn_Luu.Visible = true;
                txt_ChucDanh.Enabled = txt_ChucVu.Enabled = txt_TenDV.Enabled = comB_Nganh.Enabled = dTP_DenNgay.Enabled = dTP_TuNgay.Enabled = rTB_CongViecChinh.Enabled = true;
                dtgv_QTCT_Ngoai.Enabled = false;

                if (bAddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_ChucDanh.Text = txt_ChucVu.Text = txt_TenDV.Text = rTB_CongViecChinh.Text = "";
                }
            }
        }
       
        #endregion

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

        private void lbl_ThemNgoai_Click(object sender, EventArgs e)
        {
            bAddFlag = true;
            ResetInterface(false);
        }

        private void lbl_SuaNgoai_Click(object sender, EventArgs e)
        {
            bAddFlag = false;
            ResetInterface(false);
        }

    }
}
