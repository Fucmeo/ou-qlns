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
    public partial class QDBoNhiem : UserControl
    {
        DonVi oDonVi;
        ChucVu oChucVu;
        Business.CNVC.CNVC_QTr_CongTac_OU oQtrCTacOU;
        Business.HDQD.KiemNhiem oKiemNhiem;

        DataTable dtDSBoNhiem;
        int row_count_bn = 0;
        DataTable dtDonVi;

        public static List<int> qtr_ctac_id = new List<int>();
        public static List<string> ma_nv = new List<string>();
        public static List<int> don_vi_id = new List<int>();
        public static List<int> chuc_vu_id = new List<int>();
        public static List<int> chuc_danh_id = new List<int>();
        public static List<DateTime> tu_ngay = new List<DateTime>();
        public static List<DateTime> den_ngay = new List<DateTime>();

        public QDBoNhiem()
        {
            InitializeComponent();
            oChucVu = new ChucVu();
            oDonVi = new DonVi();

            InitObjects();
        }

        private void InitObjects()
        {
            oQtrCTacOU = new Business.CNVC.CNVC_QTr_CongTac_OU();
            thongTinCNVC1.Set_IsSearchQtrCtac(true, this, "Bổ nhiệm");
            PrepareSourceLoaiQuyetDinh();
            PrepareDataTableDSBoNhiem();
            PreapreDataSource();
            dtDonVi = oDonVi.GetDonVi_All();
        }

        public void Fill_QtrCtacGridview(DataTable p_DSQtrCtac)
        {
            try
            {
                if (p_DSQtrCtac.Rows.Count > 0)
                {
                    dtg_DSQtrCtac.DataSource = p_DSQtrCtac;

                    EditDtgInterface();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy quá trình công tác cho nhân viên được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtg_DSQtrCtac.DataSource = null;
                    dtg_DSQtrCtac.Rows.Clear();
                    //dtg_DSQtrCtac.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Private methods
        private void PrepareSourceLoaiQuyetDinh()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("loai_quyet_dinh_id", typeof(int));
            dt.Columns.Add("ten_loai_quyet_dinh", typeof(string));

            dt.Rows.Add(new object[2] { 2, "Bổ nhiệm" });
            
            thongTinQuyetDinh1.comB_Loai.DataSource = dt;
            thongTinQuyetDinh1.comB_Loai.DisplayMember = "ten_loai_quyet_dinh";
            thongTinQuyetDinh1.comB_Loai.ValueMember = "loai_quyet_dinh_id";
        }

        private void PreapreDataSource()
        {
            try
            {
                comB_ChucVu.DataSource = oChucVu.GetList();
                comB_ChucVu.DisplayMember = "ten_chuc_vu";
                comB_ChucVu.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtg_DSQtrCtac.Columns["ma_hd_display"].HeaderText = "Mã hợp đồng";
            dtg_DSQtrCtac.Columns["ma_qd_display"].HeaderText = "Mã quyết định";
            dtg_DSQtrCtac.Columns["don_vi"].HeaderText = "Đơn vị";
            dtg_DSQtrCtac.Columns["don_vi"].Width = 200;
            dtg_DSQtrCtac.Columns["chuc_danh"].HeaderText = "Chức danh";
            dtg_DSQtrCtac.Columns["chuc_vu"].HeaderText = "Chức vụ";
            dtg_DSQtrCtac.Columns["tu_thoi_gian"].HeaderText = "Từ ngày";
            dtg_DSQtrCtac.Columns["den_thoi_gian"].HeaderText = "Đến ngày";
            dtg_DSQtrCtac.Columns["tinh_trang"].HeaderText = "Tình trạng";

            // An dtgv_DSLoaiQD ID
            dtg_DSQtrCtac.Columns["id"].Visible = false;
            dtg_DSQtrCtac.Columns["ma_hop_dong"].Visible = false;
            dtg_DSQtrCtac.Columns["ma_quyet_dinh"].Visible = false;
            dtg_DSQtrCtac.Columns["ma_nv"].Visible = false;
            dtg_DSQtrCtac.Columns["don_vi_id"].Visible = false;
            dtg_DSQtrCtac.Columns["chuc_danh_id"].Visible = false;
            dtg_DSQtrCtac.Columns["chuc_vu_id"].Visible = false;
        }

        private void PrepareDataTableDSBoNhiem()
        {
            dtDSBoNhiem = new DataTable();
            row_count_bn = 0;
            dtDSBoNhiem.Columns.Add("qtr_ctac_id", typeof(int));
            dtDSBoNhiem.Columns.Add("ma_nv", typeof(string));
            dtDSBoNhiem.Columns.Add("ho_ten", typeof(string));
            dtDSBoNhiem.Columns.Add("don_vi_id", typeof(int));
            dtDSBoNhiem.Columns.Add("don_vi", typeof(string));
            dtDSBoNhiem.Columns.Add("chuc_vu_id", typeof(int));
            dtDSBoNhiem.Columns.Add("chuc_vu", typeof(string));
            dtDSBoNhiem.Columns.Add("chuc_danh_id", typeof(int));
            dtDSBoNhiem.Columns.Add("chuc_danh", typeof(string));
            dtDSBoNhiem.Columns.Add("tu_ngay", typeof(DateTime));
            dtDSBoNhiem.Columns.Add("den_ngay", typeof(DateTime));
        }

        private void PrepareDTGVSource(DataTable dt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dtgv_DS.DataSource = bs;
            EditDtgInterface_DSBoNhiem();
        }

        private void EditDtgInterface_DSBoNhiem()
        {
            // Dat ten cho cac cot
            dtgv_DS.Columns["ma_nv"].HeaderText = "Mã nhân viên";
            dtgv_DS.Columns["ho_ten"].HeaderText = "Họ tên";
            dtgv_DS.Columns["don_vi"].HeaderText = "Đơn vị";
            dtgv_DS.Columns["chuc_danh"].HeaderText = "Chức danh";
            dtgv_DS.Columns["chuc_vu"].HeaderText = "Chức vụ";
            dtgv_DS.Columns["tu_ngay"].HeaderText = "Từ ngày";
            dtgv_DS.Columns["den_ngay"].HeaderText = "Đến ngày";

            // An cac cot ID
            dtgv_DS.Columns["qtr_ctac_id"].Visible = false;
            dtgv_DS.Columns["don_vi_id"].Visible = false;
            dtgv_DS.Columns["chuc_danh_id"].Visible = false;
            dtgv_DS.Columns["chuc_vu_id"].Visible = false;
        }

        private bool CheckInputData()
        {
            if (!String.IsNullOrEmpty(thongTinQuyetDinh1.txt_MaQD.Text))
                return true;
            else
                return false;
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

        private void btn_Nhap_Click(object sender, EventArgs e)
        {
            if (CheckInputData())
            {
                try
                {
                    oKiemNhiem = new Business.HDQD.KiemNhiem();
                    oKiemNhiem.MaQuyetDinh = thongTinQuyetDinh1.txt_MaQD.Text.Trim();
                    oKiemNhiem.Ten = thongTinQuyetDinh1.txt_TenQD.Text.Trim();
                    oKiemNhiem.LoaiQuyetDinh = Convert.ToInt32(thongTinQuyetDinh1.comB_Loai.SelectedValue.ToString());
                    oKiemNhiem.NgayKy = thongTinQuyetDinh1.dTP_NgayKy.Value;
                    oKiemNhiem.NgayHieuLucQD = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;
                    if (thongTinQuyetDinh1.dTP_NgayHetHan.Checked)
                        oKiemNhiem.NgayHetHanQD = thongTinQuyetDinh1.dTP_NgayHetHan.Value;
                    else
                        oKiemNhiem.NgayHetHanQD = null;
                    oKiemNhiem.MoTa = thongTinQuyetDinh1.rTB_MoTa.Text.Trim();
                    oKiemNhiem.Path = null;

                    #region Bo Nhiem Cong Tac
                    qtr_ctac_id = new List<int>();
                    ma_nv = new List<string>();
                    don_vi_id = new List<int>();
                    chuc_vu_id = new List<int>();
                    chuc_danh_id = new List<int>();
                    tu_ngay = new List<DateTime>();
                    den_ngay = new List<DateTime>();

                    foreach (DataRow dr in dtDSBoNhiem.Rows)
                    {
                        DateTime? m_dt_dv_denngay = null;
                        DateTime? m_dt_dieudong_denngay = null;
                        bool m_cb_dieudong_denngay = false;

                        if (dr["den_ngay"].ToString() == "")
                        {
                            m_dt_dieudong_denngay = null;
                            m_cb_dieudong_denngay = false;
                        }
                        else
                        {
                            m_dt_dieudong_denngay = Convert.ToDateTime(dr["den_ngay"].ToString());
                            m_cb_dieudong_denngay = true;
                        }

                        int m_selected_donvi = Convert.ToInt32(dr["don_vi_id"].ToString());
                        var result = (from c in dtDonVi.AsEnumerable()
                                      where c.Field<int>("id") == m_selected_donvi
                                      select new { den_ngay = c.Field<DateTime?>("den_ngay") }
                                        ).ToList();
                        DataTable dt = ToDataTable(result);
                        if (dt.Rows[0]["den_ngay"].ToString() != "")
                            m_dt_dv_denngay = Convert.ToDateTime(dt.Rows[0]["den_ngay"].ToString());
                        else
                            m_dt_dv_denngay = null;

                        if (m_dt_dieudong_denngay > m_dt_dv_denngay || (m_dt_dieudong_denngay == null && m_dt_dv_denngay != null)) //insert multiple don vi
                        {
                            #region Insert multiple Don vi
                            DataTable dt_donvi_new = oDonVi.GetDonVi_New(m_selected_donvi);
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

                                int m_qtr_congtac_id_ori = Convert.ToInt32(dr["qtr_ctac_id"].ToString());
                                string m_ma_nv_ori = dr["ma_nv"].ToString();

                                qtr_ctac_id.Add(m_qtr_congtac_id_ori);
                                ma_nv.Add(m_ma_nv_ori);
                                don_vi_id.Add(Convert.ToInt32(dr["don_vi_id"].ToString()));
                                chuc_vu_id.Add(Convert.ToInt32(dr["chuc_vu_id"].ToString()));
                                chuc_danh_id.Add(Convert.ToInt32(dr["chuc_danh_id"].ToString()));
                                tu_ngay.Add(Convert.ToDateTime(dr["tu_ngay"].ToString()).Date);
                                den_ngay.Add(ngay_hieu_luc_qd.AddDays(-1));

                                Forms.Popup frPopup = new Forms.Popup(new UCs.DonViCu(dt_donvi_new, m_cb_dieudong_denngay, m_dt_dieudong_denngay, m_qtr_congtac_id_ori, m_ma_nv_ori), "Danh sách đơn vị");
                                frPopup.ShowDialog();
                            }


                            #endregion

                        }
                        else if (m_dt_dieudong_denngay <= m_dt_dv_denngay || m_dt_dv_denngay == null) //insert 1 don vi
                        {
                            qtr_ctac_id.Add(Convert.ToInt32(dr["qtr_ctac_id"].ToString()));
                            ma_nv.Add(dr["ma_nv"].ToString());
                            don_vi_id.Add(Convert.ToInt32(dr["don_vi_id"].ToString()));
                            chuc_vu_id.Add(Convert.ToInt32(dr["chuc_vu_id"].ToString()));
                            chuc_danh_id.Add(Convert.ToInt32(dr["chuc_danh_id"].ToString()));

                            tu_ngay.Add(Convert.ToDateTime(dr["tu_ngay"].ToString()).Date);

                            if (dr["den_ngay"].ToString() == "")
                                den_ngay.Add(Convert.ToDateTime("01/01/1901").Date);
                            else
                                den_ngay.Add(Convert.ToDateTime(dr["den_ngay"].ToString()).Date);
                        }
                    }

                    #endregion

                    if (MessageBox.Show("Bạn thực sự muốn thêm quyết định bổ nhiệm cho (các) nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (oKiemNhiem.AddDieuDong(qtr_ctac_id.ToArray(), ma_nv.ToArray(), don_vi_id.ToArray(), chuc_vu_id.ToArray(), chuc_danh_id.ToArray(), tu_ngay.ToArray(), den_ngay.ToArray()))
                        {
                            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //ResetInterface();
                        }
                        else
                            MessageBox.Show("Thao tác thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dtg_DSQtrCtac_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_MaHD.Text = dtg_DSQtrCtac.CurrentRow.Cells["ma_hd_display"].Value.ToString();
                txt_ChucDanh.Text = dtg_DSQtrCtac.CurrentRow.Cells["chuc_danh"].Value.ToString();
                txt_ChucVu.Text = dtg_DSQtrCtac.CurrentRow.Cells["chuc_vu"].Value.ToString();
                txt_DonVi.Text = dtg_DSQtrCtac.CurrentRow.Cells["don_vi"].Value.ToString();
                dTP_NgayBatDau.Value = Convert.ToDateTime(dtg_DSQtrCtac.CurrentRow.Cells["tu_thoi_gian"].Value);
                if (dtg_DSQtrCtac.CurrentRow.Cells["den_thoi_gian"].Value.ToString() != "")
                {
                    dTP_NgayHetHan.Checked = true;
                    dTP_NgayHetHan.Value = Convert.ToDateTime(dtg_DSQtrCtac.CurrentRow.Cells["den_thoi_gian"].Value);
                }
                else
                {
                    dTP_NgayHetHan.Checked = false;
                    //dTP_NgayBatDau.Value = Convert.ToDateTime(dtg_DSQtrCtac.CurrentRow.Cells["den_thoi_gian"].Value);
                }
            }
            catch { }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                //string tmp = dtg_DSQtrCtac.SelectedRows[0].Cells["id"].ToString();

                oQtrCTacOU.ID = Convert.ToInt32(dtg_DSQtrCtac.SelectedRows[0].Cells["id"].Value.ToString());
                if (oQtrCTacOU.CheckLatestQtrCtac() == true)
                {
                    if (comB_ChucVu.Text != "")
                    {
                        DataRow dr = dtDSBoNhiem.NewRow();
                        dr["qtr_ctac_id"] = Convert.ToInt32(dtg_DSQtrCtac.SelectedRows[0].Cells["id"].Value.ToString());
                        dr["ma_nv"] = dtg_DSQtrCtac.CurrentRow.Cells["ma_nv"].Value.ToString();
                        dr["ho_ten"] = thongTinCNVC1.txt_Ho.Text.Trim() + " " + thongTinCNVC1.txt_Ten.Text.Trim();
                        dr["don_vi_id"] = Convert.ToInt32(dtg_DSQtrCtac.SelectedRows[0].Cells["don_vi_id"].Value.ToString());
                        dr["don_vi"] = dtg_DSQtrCtac.SelectedRows[0].Cells["don_vi"].Value.ToString();
                        if (dtg_DSQtrCtac.SelectedRows[0].Cells["chuc_danh"].Value.ToString() != "")
                        {
                            dr["chuc_danh_id"] = Convert.ToInt16(dtg_DSQtrCtac.SelectedRows[0].Cells["chuc_danh_id"].Value.ToString());
                            dr["chuc_danh"] = dtg_DSQtrCtac.SelectedRows[0].Cells["chuc_danh"].Value.ToString();
                        }
                        else
                        {
                            dr["chuc_danh_id"] = -1;
                            dr["chuc_danh"] = "";
                        }

                        if (comB_ChucVu.Text != "")
                        {
                            dr["chuc_vu_id"] = Convert.ToInt16(comB_ChucVu.SelectedValue);
                            dr["chuc_vu"] = comB_ChucVu.Text;
                        }
                        else
                        {
                            dr["chuc_vu_id"] = -1;
                            dr["chuc_vu"] = "";
                        }

                        dr["tu_ngay"] = dtp_TuNgayBN.Value;
                        if (dtp_DenNgayBN.Checked == true)
                            dr["den_ngay"] = dtp_DenNgayBN.Value;
                        else
                            dr["den_ngay"] = DBNull.Value;

                        dtDSBoNhiem.Rows.Add(dr);
                        row_count_bn++;

                        PrepareDTGVSource(dtDSBoNhiem);
                    }
                    else
                        MessageBox.Show("Vui lòng xác định chức vụ bổ nhiệm cho nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Không thể thực hiện quyết định bổ nhiệm trên quá trình công tác này của nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            try
            {
                int select_row = Convert.ToInt16(dtgv_DS.CurrentRow.Cells["qtr_ctac_id"].Value.ToString());
                DataRow[] drr = dtDSBoNhiem.Select("qtr_ctac_id=" + select_row);
                foreach (DataRow row in drr)
                    row.Delete();

                dtDSBoNhiem.AcceptChanges();
                PrepareDTGVSource(dtDSBoNhiem);
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn dòng dữ liệu cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
