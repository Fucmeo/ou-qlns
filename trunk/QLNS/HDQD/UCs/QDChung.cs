using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;

namespace HDQD.UCs
{
    public partial class QDChung : UserControl
    {
        Business.ChucDanh oChucdanh;
        Business.ChucVu oChucvu;
        Business.DonVi oDonvi;
        Business.HDQD.LoaiPhuCap oLoaiPC;
        Business.HDQD.QuyetDinh oQuyetDinh;
        DinhNghiaCT ucDinhNghiaCT;
        Business.HDQD.LoaiQuyetDinh oLoaiQD;

        DataTable dtLoaiPC;
        DataTable dtPhuCap;
        int row_count_pc = 0;

        string chuoi_cong_thuc = "";
        string chuoi_cong_thuc_text = "";

        bool IsUpdate = false;
        string m_ma_qd_old = "";

        public QDChung()
        {
            InitializeComponent();
            InitObject(true);
        }

        public QDChung(string p_loai_quyet_dinh)
        {
            InitializeComponent();
            InitObject(false);
            IsUpdate = false;

            #region Xử lý dữ liệu cho cbo Loại Quyết Định
            DataTable dt = new DataTable();
            dt.Columns.Add("loai_quyet_dinh_id", typeof(int));
            dt.Columns.Add("ten_loai_quyet_dinh", typeof(string));

            switch (p_loai_quyet_dinh)
            {
                case "Đi du học":
                    dt.Rows.Add(new object[2] { 8, "Đi du học" });
                    break;
                case "Nghỉ thai sản":
                    dt.Rows.Add(new object[2] { 11, "Nghỉ thai sản" });
                    break;
                case "Nghỉ không lương":
                    dt.Rows.Add(new object[2] { 12, "Nghỉ không lương" });
                    gb_ThongTinLuong.Enabled = false;
                    break;
                case "Đi du lịch":
                    dt.Rows.Add(new object[2] { 13, "Đi du lịch" });
                    break;
                case "Thôi việc":
                    dt.Rows.Add(new object[2] { 14, "Thôi việc" });
                    break;
                case "Nghỉ hưu":
                    dt.Rows.Add(new object[2] { 15, "Nghỉ hưu" });
                    break;
                default:
                    break;
            }

            thongTinQuyetDinh1.comB_Loai.DataSource = dt;
            thongTinQuyetDinh1.comB_Loai.DisplayMember = "ten_loai_quyet_dinh";
            thongTinQuyetDinh1.comB_Loai.ValueMember = "loai_quyet_dinh_id";
            #endregion
        }

        public QDChung(string p_ma_qd, bool p_display)
        {
            InitializeComponent();
            InitObject(true);

            DisplayInfo(p_ma_qd);
            IsUpdate = true;
        }

        private void DisplayInfo(string p_ma_qd)
        {
            try
            {
                DataTable qd_info = oQuyetDinh.Search_QD_Chung(p_ma_qd);
                if (qd_info.Rows.Count >= 1)
                {
                    #region Thông tin Quyết Định
                    m_ma_qd_old = thongTinQuyetDinh1.txt_MaQD.Text = qd_info.Rows[0]["ma_quyet_dinh"].ToString();
                    thongTinQuyetDinh1.txt_TenQD.Text = qd_info.Rows[0]["ten_qd"].ToString();
                    thongTinQuyetDinh1.comB_Loai.SelectedValue = Convert.ToInt32(qd_info.Rows[0]["loai_qd_id"].ToString());

                    thongTinQuyetDinh1.dTP_NgayHieuLuc.Value = Convert.ToDateTime(qd_info.Rows[0]["ngay_hieu_luc"].ToString());
                    if (qd_info.Rows[0]["ngay_het_han"].ToString() != "")
                    {
                        thongTinQuyetDinh1.dTP_NgayHetHan.Value = Convert.ToDateTime(qd_info.Rows[0]["ngay_het_han"].ToString());
                    }
                    else
                        thongTinQuyetDinh1.dTP_NgayHetHan.Checked = false;

                    thongTinQuyetDinh1.dTP_NgayKy.Value = Convert.ToDateTime(qd_info.Rows[0]["ngay_ky"].ToString());
                    thongTinQuyetDinh1.rTB_MoTa.Text = qd_info.Rows[0]["mo_ta"].ToString();
                    #endregion

                    #region Lương - Thâm Niên Info
                    cb_Tham_Nien_NB.Checked = Convert.ToBoolean(qd_info.Rows[0]["tham_nien_nang_bac"].ToString());
                    cb_Tham_Nien_NG.Checked = Convert.ToBoolean(qd_info.Rows[0]["tham_nien_gd"].ToString());

                    if (Convert.ToBoolean(qd_info.Rows[0]["khong_tinh_luong"].ToString()) == false)
                    {
                        rb_KhongTinhLuong.Checked = true;
                    }
                    else
                    {
                        rb_TinhLuong.Checked = true;
                        if (Convert.ToBoolean(qd_info.Rows[0]["define_cthuc"].ToString()) == false)
                            rb_CT_MacDinh.Checked = true;
                        else
                        {
                            rb_CT_Moi.Checked = true;
                            nup_Value_PhanTramLuong.Value = Convert.ToDecimal(qd_info.Rows[0]["cthuc_phan_tram"].ToString());
                            txt_CongThucLuong.Text = qd_info.Rows[0]["chuoi_cong_thuc_text"].ToString();
                        }
                    }
                    #endregion

                    #region Nhân viên - Phụ Cấp Info
                    dtPhuCap = oQuyetDinh.Search_QD_Chung_Detail(p_ma_qd);
                    
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dtPhuCap;
                    dtgv_DSPhuCap.DataSource = bs;
                    EditDtgInterface_Display();
                    #endregion
                }
            }
            catch 
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình tải dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitObject(bool p_loadcbo_loaiqd)
        {
            oChucdanh = new ChucDanh();
            oChucvu = new ChucVu();
            oDonvi = new DonVi();
            oLoaiPC = new Business.HDQD.LoaiPhuCap();
            oQuyetDinh = new Business.HDQD.QuyetDinh();
            oLoaiQD = new Business.HDQD.LoaiQuyetDinh();
            ucDinhNghiaCT = new DinhNghiaCT();

            dtPhuCap = new DataTable();
            dtLoaiPC = new DataTable();

            dtLoaiPC = oLoaiPC.GetList_Cbo();
            PreapreDataSource();
            PrepareDataTablePhuCap();

            if (p_loadcbo_loaiqd)
            { LoadCbo_Loai_QD(); }

        }

        private void cb_Ins_Qtr_Ctac_CheckedChanged(object sender, EventArgs e)
        {
            Insert_Qtr_Ctac_OU(cb_Ins_Qtr_Ctac.Checked);
        }

        #region Private Methods

        private void EditDtgInterface_Display()
        {
            // Dat ten cho cac cot
            //dtgv_DSPhuCap.Columns["loai_pc_id"].HeaderText = "Loại Phụ cấp ID";
            dtgv_DSPhuCap.Columns["ma_nv"].HeaderText = "Mã nhân viên";
            dtgv_DSPhuCap.Columns["ten_nv"].HeaderText = "Tên nhân viên";
            dtgv_DSPhuCap.Columns["ten_don_vi"].HeaderText = "Tên đơn vị";
            dtgv_DSPhuCap.Columns["ten_chuc_vu"].HeaderText = "Chức vụ";
            dtgv_DSPhuCap.Columns["ten_chuc_danh"].HeaderText = "Chức danh";

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
            //dtgv_DSPhuCap.Columns["ma_nv"].Visible = false;
            dtgv_DSPhuCap.Columns["don_vi_id"].Visible = false;
            dtgv_DSPhuCap.Columns["chuc_vu_id"].Visible = false;
            dtgv_DSPhuCap.Columns["chuc_danh_id"].Visible = false;
            dtgv_DSPhuCap.Columns["ins_qtr_ctac"].Visible = false;
            dtgv_DSPhuCap.Columns["qtr_ctac_ou_id"].Visible = false;
            dtgv_DSPhuCap.Columns["co_phu_cap"].Visible = false;
            dtgv_DSPhuCap.Columns["ho"].Visible = false;
            dtgv_DSPhuCap.Columns["ten"].Visible = false;
        }

        private void LoadCbo_Loai_QD()
        {
            DataTable dt = oLoaiQD.GetList_Compact();
            DataRow[] drr = dt.Select("id in (4,5,9,10)");
            foreach (DataRow row in drr)
                row.Delete();

            dt.AcceptChanges();

            thongTinQuyetDinh1.comB_Loai.DataSource = dt;
            thongTinQuyetDinh1.comB_Loai.DisplayMember = "ten_loai";
            thongTinQuyetDinh1.comB_Loai.ValueMember = "id";
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

                comB_DonVi.DataSource = oDonvi.GetActiveDonVi();
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

        private void EditInterface_LoaiPC()
        {
            if (cb_CoPhuCap.Checked == false)
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

        private void Insert_Qtr_Ctac_OU(bool p_check)
        {
            comB_ChucDanh.Enabled = comB_ChucVu.Enabled = comB_DonVi.Enabled = p_check;
        }

        private void PrepareDTGVSource(DataTable dt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dtgv_DSPhuCap.DataSource = bs;
            EditDtgInterface();
        }

        private void PrepareDataTablePhuCap()
        {
            dtPhuCap = new DataTable();
            row_count_pc = 0;
            dtPhuCap.Columns.Add("id", typeof(int));
            dtPhuCap.Columns.Add("ma_nv", typeof(string));
            dtPhuCap.Columns.Add("ho", typeof(string));
            dtPhuCap.Columns.Add("ten", typeof(string));
            dtPhuCap.Columns.Add("ten_nv", typeof(string));
            dtPhuCap.Columns.Add("ins_qtr_ctac", typeof(bool));
            dtPhuCap.Columns.Add("don_vi_id", typeof(int));
            dtPhuCap.Columns.Add("ten_don_vi", typeof(string));
            dtPhuCap.Columns.Add("chuc_vu_id", typeof(int));
            dtPhuCap.Columns.Add("ten_chuc_vu", typeof(string));
            dtPhuCap.Columns.Add("chuc_danh_id", typeof(int));
            dtPhuCap.Columns.Add("ten_chuc_danh", typeof(string));
            dtPhuCap.Columns.Add("co_phu_cap", typeof(bool));
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

        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            //dtgv_DSPhuCap.Columns["loai_pc_id"].HeaderText = "Loại Phụ cấp ID";
            dtgv_DSPhuCap.Columns["ma_nv"].HeaderText = "Mã nhân viên";
            dtgv_DSPhuCap.Columns["ten_nv"].HeaderText = "Tên nhân viên";
            dtgv_DSPhuCap.Columns["ten_don_vi"].HeaderText = "Tên đơn vị";
            dtgv_DSPhuCap.Columns["ten_chuc_vu"].HeaderText = "Chức vụ";
            dtgv_DSPhuCap.Columns["ten_chuc_danh"].HeaderText = "Chức danh";

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
            //dtgv_DSPhuCap.Columns["ma_nv"].Visible = false;
            dtgv_DSPhuCap.Columns["don_vi_id"].Visible = false;
            dtgv_DSPhuCap.Columns["chuc_vu_id"].Visible = false;
            dtgv_DSPhuCap.Columns["chuc_danh_id"].Visible = false;
            dtgv_DSPhuCap.Columns["ins_qtr_ctac"].Visible = false;
            dtgv_DSPhuCap.Columns["co_phu_cap"].Visible = false;
            dtgv_DSPhuCap.Columns["ho"].Visible = false;
            dtgv_DSPhuCap.Columns["ten"].Visible = false;
        }

        private bool CheckInputData()
        {
            if (thongTinCNVC1.txt_MaNV.Text != "" && thongTinQuyetDinh1.txt_MaQD.Text != "" && 
                    ((dtPhuCap.Rows.Count > 0 && cb_CoPhuCap.Checked == false) || cb_CoPhuCap.Checked == true))
                return true;
            else
                return false;
        }
        #endregion

        #region Xử lý radio buttons
        private void Radio_Tinh_Luong(bool p_tinh_luong)
        {
            if (p_tinh_luong == false)
            {
                rb_CT_MacDinh.Enabled = rb_CT_Moi.Enabled = nup_Value_PhanTramLuong.Enabled = txt_CongThucLuong.Enabled = btn_ThietLap.Enabled = false;
            }
            else
            {
                rb_CT_MacDinh.Enabled = rb_CT_Moi.Enabled = true;
                Radio_Cong_thuc_Luong();
            }
        }

        private void Radio_Cong_thuc_Luong()
        {
            if (rb_CT_MacDinh.Checked == true)
                nup_Value_PhanTramLuong.Enabled = txt_CongThucLuong.Enabled = btn_ThietLap.Enabled = false;
            else if (rb_CT_Moi.Checked == true)
                nup_Value_PhanTramLuong.Enabled = txt_CongThucLuong.Enabled = btn_ThietLap.Enabled = true;

        }

        private void rb_TinhLuong_CheckedChanged(object sender, EventArgs e)
        {
            Radio_Tinh_Luong(true);
        }

        private void rb_KhongTinhLuong_CheckedChanged(object sender, EventArgs e)
        {
            Radio_Tinh_Luong(false);
        }

        private void rb_CT_MacDinh_CheckedChanged(object sender, EventArgs e)
        {
            Radio_Cong_thuc_Luong();
        }

        private void rb_CT_Moi_CheckedChanged(object sender, EventArgs e)
        {
            Radio_Cong_thuc_Luong();
        }
        #endregion

        private void btn_AddPC_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(thongTinCNVC1.txt_MaNV.Text.Trim()))
            {
                try
                {
                    DataRow dr = dtPhuCap.NewRow();
                    dr["id"] = row_count_pc;
                    dr["ma_nv"] = thongTinCNVC1.txt_MaNV.Text;
                    dr["ho"] = thongTinCNVC1.txt_Ho.Text.Trim();
                    dr["ten"] = thongTinCNVC1.txt_Ten.Text.Trim();
                    dr["ten_nv"] = thongTinCNVC1.txt_Ho.Text.Trim() + " " + thongTinCNVC1.txt_Ten.Text.Trim();

                    #region Xử lý phần insert qtr công tác
                    if (cb_Ins_Qtr_Ctac.Checked)
                    {
                        dr["ins_qtr_ctac"] = true;

                        if (comB_DonVi.Text != "")
                        {
                            dr["don_vi_id"] = Convert.ToInt16(comB_DonVi.SelectedValue.ToString());
                            dr["ten_don_vi"] = comB_DonVi.Text;
                        }
                        else
                        {
                            dr["don_vi_id"] = DBNull.Value;
                            dr["ten_don_vi"] = DBNull.Value;
                        }

                        if (comB_ChucVu.Text != "")
                        {
                            dr["chuc_vu_id"] = Convert.ToInt16(comB_ChucVu.SelectedValue.ToString());
                            dr["ten_chuc_vu"] = comB_ChucVu.Text;
                        }
                        else
                        {
                            dr["chuc_vu_id"] = DBNull.Value;
                            dr["ten_chuc_vu"] = DBNull.Value;
                        }

                        if (comB_ChucDanh.Text != "")
                        {
                            dr["chuc_danh_id"] = Convert.ToInt16(comB_ChucDanh.SelectedValue.ToString());
                            dr["ten_chuc_danh"] = comB_ChucDanh.Text;
                        }
                        else
                        {
                            dr["chuc_danh_id"] = DBNull.Value;
                            dr["ten_chuc_danh"] = DBNull.Value;
                        }
                    }
                    else
                    {
                        dr["ins_qtr_ctac"] = false;
                        dr["don_vi_id"] = DBNull.Value;
                        dr["ten_don_vi"] = DBNull.Value;
                        dr["chuc_vu_id"] = DBNull.Value;
                        dr["ten_chuc_vu"] = DBNull.Value;
                        dr["chuc_danh_id"] = DBNull.Value;
                        dr["ten_chuc_danh"] = DBNull.Value;
                    }
                    #endregion

                    dr["co_phu_cap"] = !cb_CoPhuCap.Checked;
                    if (!cb_CoPhuCap.Checked)
                    {
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
                    }
                    else
                    {
                        dr["loai_pc_id"] = DBNull.Value;
                        dr["ten_loai"] = DBNull.Value;
                        dr["value_khoan"] = DBNull.Value;
                        dr["value_he_so"] = DBNull.Value;
                        dr["value_phan_tram"] = DBNull.Value;
                        dr["phan_tram_huong"] = DBNull.Value;
                        dr["tu_ngay"] = DBNull.Value;
                        dr["den_ngay"] = DBNull.Value;
                        dr["ghi_chu"] = DBNull.Value;
                    }

                    dtPhuCap.Rows.Add(dr);
                    row_count_pc++;

                    PrepareDTGVSource(dtPhuCap);
                }
                catch { }
            }
            else
                MessageBox.Show("Vui lòng chọn thông tin nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void comB_LoaiPhuCap_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EditInterface_LoaiPC();
        }

        private void cb_CoPhuCap_CheckedChanged(object sender, EventArgs e)
        {
            comB_LoaiPhuCap.Enabled = txt_TienPC.Enabled = txt_HeSoPC.Enabled = dTP_NgayBatDauPC.Enabled = nup_Value_PhanTramPC.Enabled =
                dTP_NgayHetHanPC.Enabled = nup_PhanTramPC.Enabled = rTB_GhiChuPC.Enabled = !cb_CoPhuCap.Checked;
            EditInterface_LoaiPC();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (CheckInputData())
            {
                #region Declare Variables
                oQuyetDinh = new Business.HDQD.QuyetDinh();
                bool Tham_Nien_Nang_Bac = false;
                bool Tham_Nien_Nha_Giao = false;
                bool Define_Cong_Thuc = false;
                //string Cong_Thuc = "";
                double? Phan_Tram_Cong_Thuc;
                bool Khong_Tinh_Luong = false;

                List<string> ma_nv = new List<string>();
                List<bool> ins_qtr_ctac = new List<bool>();
                List<int> don_vi_id = new List<int>();
                List<int> chuc_vu_id = new List<int>();
                List<int> chuc_danh_id = new List<int>();
                List<bool> co_phu_cap = new List<bool>();
                List<int> loai_pc_id = new List<int>();
                List<double> value_khoan = new List<double>();
                List<double> value_heso = new List<double>();
                List<double> value_phantram = new List<double>();
                List<double> phan_tram = new List<double>();
                List<DateTime> tu_ngay = new List<DateTime>();
                List<DateTime> den_ngay = new List<DateTime>();
                List<string> ghi_chu = new List<string>();

                #endregion

                #region Quyet Dinh Info
                oQuyetDinh.Ma_Quyet_Dinh = thongTinQuyetDinh1.txt_MaQD.Text;
                oQuyetDinh.Ten_Quyet_Dinh = thongTinQuyetDinh1.txt_TenQD.Text;
                try
                {
                    oQuyetDinh.Loai_QuyetDinh_ID = Convert.ToInt32(thongTinQuyetDinh1.comB_Loai.SelectedValue.ToString());
                }
                catch 
                {
                    oQuyetDinh.Loai_QuyetDinh_ID = null;
                }
                    
                //oQuyetDinh.Loai_QuyetDinh_ID = 7;
                oQuyetDinh.Ngay_Ky = thongTinQuyetDinh1.dTP_NgayKy.Value;
                oQuyetDinh.Ngay_Hieu_Luc = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;
                if (thongTinQuyetDinh1.dTP_NgayHetHan.Checked)
                    oQuyetDinh.Ngay_Het_Han = thongTinQuyetDinh1.dTP_NgayHetHan.Value;
                else
                    oQuyetDinh.Ngay_Het_Han = null;
                oQuyetDinh.MoTa = thongTinQuyetDinh1.rTB_MoTa.Text;
                #endregion

                Tham_Nien_Nang_Bac = cb_Tham_Nien_NB.Checked;
                Tham_Nien_Nha_Giao = cb_Tham_Nien_NG.Checked;

                #region Công thức tính lương Info
                if (rb_TinhLuong.Checked && rb_CT_Moi.Checked)
                {
                    Define_Cong_Thuc = true;
                    //Cong_Thuc = txt_CongThucLuong.Text;
                    Phan_Tram_Cong_Thuc = Convert.ToDouble(nup_Value_PhanTramLuong.Value);
                }
                else
                {
                    Define_Cong_Thuc = false;
                    chuoi_cong_thuc = null;
                    chuoi_cong_thuc_text = null;
                    Phan_Tram_Cong_Thuc = null;
                }

                if (rb_KhongTinhLuong.Checked)
                    Khong_Tinh_Luong = true;
                else
                    Khong_Tinh_Luong = false;
                #endregion

                foreach (DataRow dr in dtPhuCap.Rows)
                {
                    ma_nv.Add(dr["ma_nv"].ToString());

                    #region Quá trình ctác Info
                    ins_qtr_ctac.Add(Convert.ToBoolean(dr["ins_qtr_ctac"].ToString()));
                    if (dr["don_vi_id"].ToString() == "")
                        don_vi_id.Add(-1);
                    else
                        don_vi_id.Add(Convert.ToInt32(dr["don_vi_id"].ToString()));

                    if (dr["chuc_vu_id"].ToString() == "")
                        chuc_vu_id.Add(-1);
                    else
                        chuc_vu_id.Add(Convert.ToInt32(dr["chuc_vu_id"].ToString()));

                    if (dr["chuc_danh_id"].ToString() == "")
                        chuc_danh_id.Add(-1);
                    else
                        chuc_danh_id.Add(Convert.ToInt32(dr["chuc_danh_id"].ToString()));
                    #endregion

                    #region Phu Cap Info
                    bool m_co_pc = Convert.ToBoolean(dr["co_phu_cap"].ToString());
                    co_phu_cap.Add(m_co_pc);
                    if (m_co_pc)
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
                    else
                    {
                        loai_pc_id.Add(-1);
                        value_khoan.Add(-1);
                        value_heso.Add(-1);
                        value_phantram.Add(-1);
                        phan_tram.Add(-1);
                        tu_ngay.Add(Convert.ToDateTime("01/01/1901").Date);
                        den_ngay.Add(Convert.ToDateTime("01/01/1901").Date);
                        ghi_chu.Add("");
                    }
                    #endregion
                }

                if (IsUpdate == false)
                {
                    try
                    {
                        if (MessageBox.Show("Bạn thực sự muốn thêm quyết định cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (oQuyetDinh.Add_QuyetDinhChung(Tham_Nien_Nang_Bac, Tham_Nien_Nha_Giao, Define_Cong_Thuc, chuoi_cong_thuc_text, chuoi_cong_thuc,
                                                                Phan_Tram_Cong_Thuc, Khong_Tinh_Luong,
                                                                ma_nv.ToArray(), ins_qtr_ctac.ToArray(), don_vi_id.ToArray(), chuc_vu_id.ToArray(), chuc_danh_id.ToArray(),
                                                                co_phu_cap.ToArray(), loai_pc_id.ToArray(), value_khoan.ToArray(), value_heso.ToArray(),
                                                                value_phantram.ToArray(), phan_tram.ToArray(), tu_ngay.ToArray(), den_ngay.ToArray(), ghi_chu.ToArray()))
                            {
                                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Thao tác thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (MessageBox.Show("Bạn thực sự muốn cập nhật quyết định cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (oQuyetDinh.Update_QuyetDinhChung(m_ma_qd_old, Tham_Nien_Nang_Bac, Tham_Nien_Nha_Giao, Define_Cong_Thuc, chuoi_cong_thuc_text, chuoi_cong_thuc,
                                                                Phan_Tram_Cong_Thuc, Khong_Tinh_Luong,
                                                                ma_nv.ToArray(), ins_qtr_ctac.ToArray(), don_vi_id.ToArray(), chuc_vu_id.ToArray(), chuc_danh_id.ToArray(),
                                                                co_phu_cap.ToArray(), loai_pc_id.ToArray(), value_khoan.ToArray(), value_heso.ToArray(),
                                                                value_phantram.ToArray(), phan_tram.ToArray(), tu_ngay.ToArray(), den_ngay.ToArray(), ghi_chu.ToArray()))
                            {
                                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Thao tác cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thao tác cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void dtgv_DSPhuCap_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSPhuCap.CurrentRow != null)
            {
                try
                {
                    thongTinCNVC1.txt_Ho.Text = dtgv_DSPhuCap.CurrentRow.Cells["ho"].Value.ToString();
                    thongTinCNVC1.txt_Ten.Text = dtgv_DSPhuCap.CurrentRow.Cells["ten"].Value.ToString();
                    thongTinCNVC1.txt_MaNV.Text = dtgv_DSPhuCap.CurrentRow.Cells["ma_nv"].Value.ToString();

                    cb_Ins_Qtr_Ctac.Checked = Convert.ToBoolean(dtgv_DSPhuCap.CurrentRow.Cells["ins_qtr_ctac"].Value.ToString());
                    comB_DonVi.SelectedValue = Convert.ToInt32(dtgv_DSPhuCap.CurrentRow.Cells["don_vi_id"].Value.ToString());
                    if (dtgv_DSPhuCap.CurrentRow.Cells["chuc_vu_id"].Value.ToString() != "")
                        comB_ChucVu.SelectedValue = Convert.ToInt32(dtgv_DSPhuCap.CurrentRow.Cells["chuc_vu_id"].Value.ToString());
                    else
                        comB_ChucVu.Text = "";
                    if (dtgv_DSPhuCap.CurrentRow.Cells["chuc_danh_id"].Value.ToString() != "")
                        comB_ChucDanh.SelectedValue = Convert.ToInt32(dtgv_DSPhuCap.CurrentRow.Cells["chuc_danh_id"].Value.ToString());
                    else
                        comB_ChucDanh.Text = "";
                    
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

        private void btn_ThietLap_Click(object sender, EventArgs e)
        {
            Forms.Popup frPopup = new Forms.Popup(ucDinhNghiaCT, "QUẢN LÝ NHÂN SỰ - ĐỊNH NGHĨA CÔNG THỨC TÍNH PHỤ CẤP");
            if (ucDinhNghiaCT.lstDisplayString.Count > 0)
            {

            }
            frPopup.ShowDialog();
            if (ucDinhNghiaCT.lstValueString.Count > 0)
            {
                chuoi_cong_thuc = string.Join("", ucDinhNghiaCT.lstValueString.ToArray());
                chuoi_cong_thuc_text = string.Join(" ", ucDinhNghiaCT.lstDisplayString.ToArray());

                txt_CongThucLuong.Text = chuoi_cong_thuc_text;
            }
        }

        private void btn_DeleteQD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn xoá quyết định này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (dtPhuCap.Rows.Count > 0 || thongTinQuyetDinh1.txt_MaQD.Text != "")
                    {
                        List<string> ma_nv = new List<string>();

                        foreach (DataRow dr in dtPhuCap.Rows)
                        {
                            ma_nv.Add(dr["ma_nv"].ToString());
                        }

                        oQuyetDinh.Ma_Quyet_Dinh = thongTinQuyetDinh1.txt_MaQD.Text;

                        if (oQuyetDinh.Delete(ma_nv.ToArray()))
                        {
                            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Không thể thực hiện thao tác xóa quyết định.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

    }
}
