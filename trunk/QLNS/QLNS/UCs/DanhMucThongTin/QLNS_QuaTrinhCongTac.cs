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
        public DataTable dtCtac_NonOU_GD;
        Business.CNVC.CNVC_QTr_CongTac_NonOU_NonGD oQtrCtac_NonOU_NonGD;
        public DataTable dtCtac_NonOU_NonGD;
        Business.CNVC.CNVC_QTr_CongTac_OU oQtrCtac_OU;
        DataTable dtCtac_OU;

        //string m_ma_nv;
        bool bAddFlag;

        public QLNS_QuaTrinhCongTac()
        {
            InitializeComponent();
            dtCtac_NonOU_GD = new DataTable();
            dtCtac_NonOU_NonGD = new DataTable();
            oQtrCtac_OU = new Business.CNVC.CNVC_QTr_CongTac_OU();
            oQtrCtac_NonOU_GD = new Business.CNVC.CNVC_QTr_CongTac_NonOU_GD();
            oQtrCtac_NonOU_NonGD = new Business.CNVC.CNVC_QTr_CongTac_NonOU_NonGD();
        }

        //public QLNS_QuaTrinhCongTac(string p_ma_nv)
        //{
        //    InitializeComponent();
        //    oQtrCtac_NonOU_GD = new Business.CNVC.CNVC_QTr_CongTac_NonOU_GD();
        //    oQtrCtac_NonOU_NonGD = new Business.CNVC.CNVC_QTr_CongTac_NonOU_NonGD();
        //    oQtrCtac_OU = new Business.CNVC.CNVC_QTr_CongTac_OU();

        //    m_ma_nv = p_ma_nv;
        //}

        private void QLNS_QuaTrinhCongTac_Load(object sender, EventArgs e)
        {
            //Load_Qtr_Ctac_NonOU();
            //Load_Qtr_Ctac_OU();

            ResetInterface(true);
        }

        public void dtgv_QTCT_Ngoai_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_QTCT_Ngoai.CurrentRow != null)
            {
                DisplayInfo(dtgv_QTCT_Ngoai.CurrentRow);
            }
        }

        #region Private Methods
        public void Load_Qtr_Ctac_OU(string p_ma_nv)
        {
            oQtrCtac_OU.MaNV = p_ma_nv;
            dtCtac_OU = oQtrCtac_OU.GetData();

            if ((dtCtac_OU) != null && dtCtac_OU.Rows.Count > 0)
            {
                PrepareDataSource_Trong();
                EditDtgInterface_Trong();
            }
        }

        private void PrepareDataSource_Trong()
        {
            BindingSource bs = new BindingSource();
            DataTable dt = dtCtac_OU.Copy();
            bs.DataSource = dt;
            dtgv_QTCT_Trong.DataSource = bs;
        }

        private void EditDtgInterface_Trong()
        {
            dtgv_QTCT_Trong.Columns["ma_hop_dong"].HeaderText = "Mã hợp đồng";
            dtgv_QTCT_Trong.Columns["ma_hop_dong"].Width = 120;
            dtgv_QTCT_Trong.Columns["ma_quyet_dinh"].HeaderText = "Mã quyết định";
            dtgv_QTCT_Trong.Columns["ma_quyet_dinh"].Width = 120;
            dtgv_QTCT_Trong.Columns["don_vi"].HeaderText = "Tên đơn vị";
            dtgv_QTCT_Trong.Columns["chuc_danh"].HeaderText = "Chức danh";
            dtgv_QTCT_Trong.Columns["chuc_vu"].HeaderText = "Chức vụ";
            dtgv_QTCT_Trong.Columns["tu_thoi_gian"].HeaderText = "Từ thời gian";
            dtgv_QTCT_Trong.Columns["tu_thoi_gian"].Width = 120;
            dtgv_QTCT_Trong.Columns["den_thoi_gian"].HeaderText = "Đến thời gian";
            dtgv_QTCT_Trong.Columns["den_thoi_gian"].Width = 120;
            dtgv_QTCT_Trong.Columns["tinh_trang"].HeaderText = "Tình trạng";

            dtgv_QTCT_Trong.Columns["id"].Visible = false;
            dtgv_QTCT_Trong.Columns["ma_nv"].Visible = false;
            dtgv_QTCT_Trong.Columns["don_vi_id"].Visible = false;
            dtgv_QTCT_Trong.Columns["chuc_danh_id"].Visible = false;
            dtgv_QTCT_Trong.Columns["chuc_vu_id"].Visible = false;
        }

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

        public void Load_Qtr_Ctac_NonOU(string p_ma_nv)
        {
            //dtCtac_NonOU_GD = new DataTable();
            //dtCtac_NonOU_NonGD = new DataTable();

            oQtrCtac_NonOU_GD.MaNV = p_ma_nv;
            dtCtac_NonOU_GD = oQtrCtac_NonOU_GD.GetData();

            oQtrCtac_NonOU_NonGD.MaNV = p_ma_nv;
            dtCtac_NonOU_NonGD = oQtrCtac_NonOU_NonGD.GetData();

            if (((dtCtac_NonOU_GD) != null && dtCtac_NonOU_GD.Rows.Count > 0) || ((dtCtac_NonOU_NonGD) != null && dtCtac_NonOU_NonGD.Rows.Count > 0))
            {
                PrepareDataSource_Ngoai();
                EditDtgInterface_Ngoai();
            }
        }

        private void EditDtgInterface_Ngoai()
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

        private void PrepareDataSource_Ngoai()
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
                lbl_SuaNgoai.Visible = lbl_XoaNgoai.Visible = true;
            }
        }

        private void ResetInterface(bool init)
        {
            if (init)
            {
                txt_ChucDanh.Enabled = txt_ChucVu.Enabled = txt_TenDV.Enabled = comB_Nganh.Enabled = dTP_DenNgay.Enabled = dTP_TuNgay.Enabled = rTB_CongViecChinh.Enabled = false;

                dtgv_QTCT_Ngoai.Enabled = true;
                if (dtgv_QTCT_Ngoai.CurrentRow != null)
                {
                    DisplayInfo(dtgv_QTCT_Ngoai.CurrentRow);
                }

                lbl_ThemNgoai.Text = "Thêm";
                lbl_SuaNgoai.Text = "Sửa";
                lbl_XoaNgoai.Visible = true;
            }
            else
            {
                txt_ChucDanh.Enabled = txt_ChucVu.Enabled = txt_TenDV.Enabled = dTP_DenNgay.Enabled = dTP_TuNgay.Enabled = rTB_CongViecChinh.Enabled = true;
                dtgv_QTCT_Ngoai.Enabled = comB_Nganh.Enabled = false;

                if (bAddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_ChucDanh.Text = txt_ChucVu.Text = txt_TenDV.Text = rTB_CongViecChinh.Text = "";
                    comB_Nganh.Enabled = true;
                }

                lbl_ThemNgoai.Text = "Lưu";
                lbl_SuaNgoai.Text = "Hủy";
                lbl_XoaNgoai.Visible = false;
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
            if (lbl_ThemNgoai.Text == "Thêm")
            {
                bAddFlag = true;
                ResetInterface(false);
            }
            else //chức năng Lưu
            {
                bool is_gd;
                if (comB_Nganh.Text == "Trong ngành giáo dục")
                {
                    is_gd = true;
                    oQtrCtac_NonOU_GD = new Business.CNVC.CNVC_QTr_CongTac_NonOU_GD();
                    oQtrCtac_NonOU_GD.MaNV = Program.selected_ma_nv;
                    oQtrCtac_NonOU_GD.TenDonVi = txt_TenDV.Text;
                    oQtrCtac_NonOU_GD.ChucDanh = txt_ChucDanh.Text;
                    oQtrCtac_NonOU_GD.ChucVu = txt_ChucVu.Text;
                    oQtrCtac_NonOU_GD.CongViecChinh = rTB_CongViecChinh.Text;
                    if (dTP_TuNgay.Checked == true)
                        oQtrCtac_NonOU_GD.TuNgay = dTP_TuNgay.Value;
                    if (dTP_DenNgay.Checked == true)
                        oQtrCtac_NonOU_GD.DenNgay = dTP_DenNgay.Value;
                }
                else
                {
                    is_gd = false;
                    oQtrCtac_NonOU_NonGD = new Business.CNVC.CNVC_QTr_CongTac_NonOU_NonGD();
                    oQtrCtac_NonOU_NonGD.MaNV = Program.selected_ma_nv;
                    oQtrCtac_NonOU_NonGD.TenDonVi = txt_TenDV.Text;
                    oQtrCtac_NonOU_NonGD.ChucDanh = txt_ChucDanh.Text;
                    oQtrCtac_NonOU_NonGD.ChucVu = txt_ChucVu.Text;
                    oQtrCtac_NonOU_NonGD.CongViecChinh = rTB_CongViecChinh.Text;
                    if (dTP_TuNgay.Checked == true)
                        oQtrCtac_NonOU_NonGD.TuNgay = dTP_TuNgay.Value;
                    if (dTP_DenNgay.Checked == true)
                        oQtrCtac_NonOU_NonGD.DenNgay = dTP_DenNgay.Value;
                }

                #region thao tac them
                if (bAddFlag)
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm quá trình công tác của nhân viên?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            if (is_gd == true) // trong ngành giáo dục
                            {
                                if (oQtrCtac_NonOU_GD.Add())
                                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            { 
                                if (oQtrCtac_NonOU_NonGD.Add())
                                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            Load_Qtr_Ctac_NonOU(Program.selected_ma_nv);
                            ResetInterface(true);
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
                    if (MessageBox.Show("Bạn thực sự muốn sửa quá trình công tác này của nhân viên?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            if (is_gd == true) // trong ngành giáo dục
                            {
                                oQtrCtac_NonOU_GD.ID = Convert.ToInt32(dtgv_QTCT_Ngoai.CurrentRow.Cells["id"].Value.ToString());
                                if (oQtrCtac_NonOU_GD.Update())
                                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                oQtrCtac_NonOU_NonGD.ID = Convert.ToInt32(dtgv_QTCT_Ngoai.CurrentRow.Cells["id"].Value.ToString());
                                if (oQtrCtac_NonOU_NonGD.Update())
                                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            Load_Qtr_Ctac_NonOU(Program.selected_ma_nv);
                            ResetInterface(true);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Thao tác sửa thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                #endregion
            }
            
        }

        private void lbl_SuaNgoai_Click(object sender, EventArgs e)
        {
            if (lbl_SuaNgoai.Text == "Sửa")
            {
                bAddFlag = false;
                ResetInterface(false);
            }
            else if (lbl_SuaNgoai.Text == "Hủy")
            {
                ResetInterface(true);
            }
        }

        private void lbl_XoaNgoai_Click(object sender, EventArgs e)
        {
            if (dtgv_QTCT_Ngoai.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá thông tin quá trình công tác này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (comB_Nganh.Text == "Trong ngành giáo dục")
                        {
                            oQtrCtac_NonOU_GD = new Business.CNVC.CNVC_QTr_CongTac_NonOU_GD();
                            oQtrCtac_NonOU_GD.ID = Convert.ToInt16(dtgv_QTCT_Ngoai.CurrentRow.Cells["id"].Value.ToString());
                            if (oQtrCtac_NonOU_GD.Delete())
                                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            oQtrCtac_NonOU_NonGD = new Business.CNVC.CNVC_QTr_CongTac_NonOU_NonGD();
                            oQtrCtac_NonOU_NonGD.ID = Convert.ToInt16(dtgv_QTCT_Ngoai.CurrentRow.Cells["id"].Value.ToString());
                            if (oQtrCtac_NonOU_NonGD.Delete())
                                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        Load_Qtr_Ctac_NonOU(Program.selected_ma_nv);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

    }
}
