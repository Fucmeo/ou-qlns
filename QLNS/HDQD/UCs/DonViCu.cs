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
        Business.DonVi oDonVi;

        DataTable m_Don_vi;
        DateTime m_den_ngay_HD;
        bool m_cb_den_ngay_HD;

        List<int> mList_don_vi_selected;
        List<int> mList_chuc_vu_selected;
        List<int> mList_chuc_danh_selected;

        int m_don_vi_selected;
        DateTime? m_dTP_ngay_het_han_dv_selected;
        int m_chuc_vu_selected;
        int m_chuc_danh_selected;
        
        public DonViCu()
        {
            InitializeComponent();

            mList_don_vi_selected = new List<int>();
            mList_chuc_vu_selected = new List<int>();
            mList_chuc_danh_selected = new List<int>();
        }

        public DonViCu(DataTable p_dt_don_vi, bool p_cb_den_ngay_HD, DateTime p_den_ngay_HD)
        {
            InitializeComponent();
            InitObject();

            m_Don_vi = p_dt_don_vi;
            m_cb_den_ngay_HD = p_cb_den_ngay_HD;
            m_den_ngay_HD = p_den_ngay_HD;

            if (m_cb_den_ngay_HD == true)
            {
                lbl_DenNgayHD.Text = "Thời gian kết thúc hợp đồng: " + m_den_ngay_HD.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"));
            }
            else
            {
                lbl_DenNgayHD.Text = "Thời gian kết thúc hợp đồng: (không có)";
            }
        }

        private void DonViCu_Load(object sender, EventArgs e)
        {
            PrepateDataDonVi(m_Don_vi);
        }

        #region Private Methods
        private void PrepateDataDonVi(DataTable p_dt_DonVi)
        {
            //m_Don_vi = p_dt_DonVi;
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

                if (dt.Rows[0]["den_ngay"].ToString() != "")
                {
                    lbl_Date_DonVi.Text = "Từ ngày: " + Convert.ToDateTime(dt.Rows[0]["tu_ngay"]).ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"))
                                           + "\nĐến ngày: " + Convert.ToDateTime(dt.Rows[0]["den_ngay"]).ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"));
                }
                else
                {
                    lbl_Date_DonVi.Text = "Từ ngày: " + Convert.ToDateTime(dt.Rows[0]["tu_ngay"].ToString()).ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"))
                                           + "\nĐến ngày: ";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra:\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitObject()
        {
            oDonVi = new DonVi();
            oChucvu = new ChucVu();
            oChucdanh = new ChucDanh();

            mList_don_vi_selected = new List<int>();
            mList_chuc_vu_selected = new List<int>();
            mList_chuc_danh_selected = new List<int>();

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

        #endregion

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsb_DonVi.Items.Count == 0)
                {
                    m_don_vi_selected = Convert.ToInt32(comB_DonVi.SelectedValue.ToString());

                    var result = (from c in m_Don_vi.AsEnumerable()
                                  where c.Field<int>("id") == m_don_vi_selected
                                  select new { den_ngay = c.Field<DateTime?>("den_ngay") }
                                      ).ToList();

                    DataTable dt_tmp = ToDataTable(result);

                    if (dt_tmp.Rows[0]["den_ngay"].ToString() != "")
                        m_dTP_ngay_het_han_dv_selected = Convert.ToDateTime(dt_tmp.Rows[0]["den_ngay"].ToString());
                    else
                        m_dTP_ngay_het_han_dv_selected = null;

                    
                    if (comB_ChucVu.Text != "")
                        m_chuc_vu_selected = Convert.ToInt32(comB_ChucVu.SelectedValue.ToString());
                    else
                        m_chuc_vu_selected = -1;

                    if (comB_ChucDanh.Text != "")
                        m_chuc_danh_selected = Convert.ToInt32(comB_ChucDanh.SelectedValue.ToString());
                    else
                        m_chuc_danh_selected = -1;

                    lsb_DonVi.Items.Add(comB_DonVi.Text);
                }
                else
                    MessageBox.Show("Đã chọn một đơn vị. Không thể chọn thêm được. Vui lòng xóa đơn vị đã chọn trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch 
            {

            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            lsb_DonVi.Items.Clear();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (lsb_DonVi.Items.Count > 0 && m_don_vi_selected != -1)
            {
                if (!mList_don_vi_selected.Contains(m_don_vi_selected))
                {
                    mList_don_vi_selected.Add(m_don_vi_selected);
                    mList_chuc_vu_selected.Add(m_chuc_vu_selected);
                    mList_chuc_danh_selected.Add(m_chuc_danh_selected);
                }

                if ((m_den_ngay_HD > m_dTP_ngay_het_han_dv_selected || m_cb_den_ngay_HD == false) && m_dTP_ngay_het_han_dv_selected != null)
                {
                    //more don_vi
                    try
                    {
                        DataTable dt_donvi_new = oDonVi.GetDonVi_New(m_don_vi_selected);

                        if (dt_donvi_new.Rows.Count > 0)
                        {
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

                            m_Don_vi = dt_donvi_new;
                            PrepateDataDonVi(dt_donvi_new);

                            lsb_DonVi.Items.Clear();
                            m_don_vi_selected = -1;
                        }
                        else
                        {
                            try
                            {
                                if (MessageBox.Show("Không thể tìm thấy đơn vị mới hơn đơn vị được chọn, và thời gian hợp đồng kết thúc lớn hơn thời gian đơn vị ngừng hoạt động. Bạn có muốn thay đổi thời gian hợp đồng kết thúc bằng thời gian đơn vị ngừng hoạt động?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //final
                                    int i = mList_don_vi_selected.Count;
                                    HopDongCu.nSelectedChucDanhID = new int[i];
                                    HopDongCu.nSelectedChucVuID = new int[i];
                                    HopDongCu.nSelectedDonViID = new int[i];

                                    HopDongCu.nSelectedChucDanhID = mList_chuc_danh_selected.ToArray();
                                    HopDongCu.nSelectedChucVuID = mList_chuc_vu_selected.ToArray();
                                    HopDongCu.nSelectedDonViID = mList_don_vi_selected.ToArray();

                                    HopDongCu.nChange_DenNgay = true;
                                    HopDongCu.ndtp_DenNgay_Change = m_dTP_ngay_het_han_dv_selected.Value;

                                    ((Form)this.Parent.Parent).Close();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Có lỗi xảy ra!" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch 
                    {
                        MessageBox.Show("Có lỗi xảy ra trong quá trình tìm kiếm đơn vị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //final
                    int i = mList_don_vi_selected.Count;
                    HopDongCu.nSelectedChucDanhID = new int[i];
                    HopDongCu.nSelectedChucVuID = new int[i];
                    HopDongCu.nSelectedDonViID = new int[i];

                    HopDongCu.nSelectedChucDanhID = mList_chuc_danh_selected.ToArray();
                    HopDongCu.nSelectedChucVuID = mList_chuc_vu_selected.ToArray();
                    HopDongCu.nSelectedDonViID = mList_don_vi_selected.ToArray();

                    ((Form)this.Parent.Parent).Close();
                }
            }
            else
                MessageBox.Show("Vui lòng chọn một đơn vị trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void comB_DonVi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Date_DonVi();
        }

        
    }
}
