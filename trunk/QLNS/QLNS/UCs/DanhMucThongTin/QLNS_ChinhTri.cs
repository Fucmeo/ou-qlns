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
    public partial class QLNS_ChinhTri : UserControl
    {
        Business.CNVC.CNVC_ChinhTri oChinhTri;
        public DataTable dtChinhTri;
        Business.CNVC.CNVC_ChinhTriExt oChinhTriExt;
        public DataTable dtChinhTriExt;
        Business.ChucVu_ChinhTri oChucVu_ChinhTri;
        public DataTable dtChucVu_ChinhTri;

        //string m_ma_nv;
        int old_select_id;
        public static bool is_Modified_Ctri_CVu = true;
        bool bAddFlag;

        public QLNS_ChinhTri()
        {
            InitializeComponent();
            oChinhTri = new Business.CNVC.CNVC_ChinhTri();
            oChinhTriExt = new Business.CNVC.CNVC_ChinhTriExt();
            oChucVu_ChinhTri = new ChucVu_ChinhTri();
            dtChinhTri = new DataTable();
            dtChinhTriExt = new DataTable();
            dtChucVu_ChinhTri = new DataTable();
        }

        //public QLNS_ChinhTri(string p_ma_nv)
        //{
        //    InitializeComponent();
        //    oChinhTri = new Business.CNVC.CNVC_ChinhTri();
        //    oChinhTriExt = new Business.CNVC.CNVC_ChinhTriExt();
        //    oChucVu_ChinhTri = new ChucVu_ChinhTri();
            
        //    m_ma_nv = p_ma_nv;
        //}

        private void QLNS_ChinhTri_Load(object sender, EventArgs e)
        {
            //dtgv_DoanDang.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dtgv_DoanDang_DataBindingComplete);
            dtgv_DoanDang.SelectionChanged+=new EventHandler(dtgv_DoanDang_SelectionChanged);
        }

        public void LoadData(string p_ma_nv)
        {
            Load_Cbo_ChucVu_ChinhTri();
            Load_Chinh_Tri(p_ma_nv);
            Load_Chinh_Tri_Ext(p_ma_nv);
        }

        void dtgv_DoanDang_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgv_DoanDang.SelectionChanged += new EventHandler(dtgv_DoanDang_SelectionChanged);
        }

        void dtgv_DoanDang_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DoanDang.CurrentRow != null)
            {
                DisplayInfo(dtgv_DoanDang.CurrentRow);
            }
        }

        #region Private Methods
        private void ResetInterface(bool init)
        {
            if (init)
            {
                txt_TenToChuc.Enabled = dtp_NgayRa.Enabled = dtp_NgayVao.Enabled = dtp_NgayChinhThuc.Enabled = dtp_NgayTaiKetNap.Enabled = false;
                lbl_ThemChucVu.Enabled = lbl_XoaChucVu.Enabled = false;
                dtgv_DoanDang.Enabled = lbl_ThemChucVuMoi.Enabled = true;
                if (dtgv_DoanDang.CurrentRow != null)
                {
                    DisplayInfo(dtgv_DoanDang.CurrentRow);
                }

                lbl_ThemDoanDang.Text = "Thêm";
                lbl_SuaDoanDang.Text = "Sửa";
                lbl_XoaDoanDang.Visible = true;
            }
            else
            {
                txt_TenToChuc.Enabled = dtp_NgayRa.Enabled = dtp_NgayVao.Enabled = dtp_NgayChinhThuc.Enabled = dtp_NgayTaiKetNap.Enabled = true;
                dtgv_DoanDang.Enabled = lbl_ThemChucVuMoi.Enabled = false;
                lbl_ThemChucVu.Enabled = lbl_XoaChucVu.Enabled = true;
                if (bAddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_TenToChuc.Text = "";
                    listB_DSCV.Items.Clear();
                }

                lbl_ThemDoanDang.Text = "Lưu";
                lbl_SuaDoanDang.Text = "Hủy";
                lbl_XoaDoanDang.Visible = false;
            }
        }

        private void DisplayInfo(DataGridViewRow row)
        {
            int i = Convert.ToInt16(row.Cells["id"].Value.ToString());
            if (i != old_select_id)
            {
                IEnumerable<int[]> result = from c in dtChinhTriExt.AsEnumerable()
                                            where c.Field<int>("id") == i
                                            select c.Field<int[]>("chuc_vu_id_arr");
                try
                {
                    int[] b = result.ElementAt(0);
                    listB_DSCV.Items.Clear();

                    foreach (int item in b)
                    {
                        var kq_f = from d in dtChucVu_ChinhTri.AsEnumerable()
                                   where d.Field<int>("id") == item
                                   select d.Field<string>("ten_chuc_vu");
                        listB_DSCV.Items.Add(kq_f.ElementAt(0).ToString());
                    }
                }
                catch { }

                comB_Loai.Text = row.Cells["ten_loai_chinh_tri"].Value.ToString();
                txt_TenToChuc.Text = row.Cells["ten_to_chuc"].Value.ToString();

                if (row.Cells["ngay_vao"].Value.ToString() != "")
                {
                    dtp_NgayVao.Checked = true;
                    dtp_NgayVao.Value = Convert.ToDateTime(row.Cells["ngay_vao"].Value.ToString());
                }
                else
                    dtp_NgayVao.Checked = false;

                if (row.Cells["ngay_ra"].Value.ToString() != "")
                {
                    dtp_NgayRa.Checked = true;
                    dtp_NgayRa.Value = Convert.ToDateTime(row.Cells["ngay_ra"].Value.ToString());
                }
                else
                    dtp_NgayRa.Checked = false;

                if (row.Cells["ngay_tai_ket_nap"].Value.ToString() != "")
                {
                    dtp_NgayTaiKetNap.Checked = true;
                    dtp_NgayTaiKetNap.Value = Convert.ToDateTime(row.Cells["ngay_tai_ket_nap"].Value.ToString());
                }
                else
                    dtp_NgayTaiKetNap.Checked = false;

                if (row.Cells["ngay_chinh_thuc"].Value.ToString() != "")
                {
                    dtp_NgayChinhThuc.Checked = true;
                    dtp_NgayChinhThuc.Value = Convert.ToDateTime(row.Cells["ngay_chinh_thuc"].Value.ToString());
                }
                else
                    dtp_NgayChinhThuc.Checked = false;

                old_select_id = i;
            }
        
        }

        private void Load_Cbo_ChucVu_ChinhTri()
        {
            if (is_Modified_Ctri_CVu == true)
            {
                dtChucVu_ChinhTri = oChucVu_ChinhTri.GetData();
                is_Modified_Ctri_CVu = false;
            }
            string selection = comB_Loai.Text;
            if (selection != "")
            {
                var result = (from c in dtChucVu_ChinhTri.AsEnumerable()
                              where c.Field<string>("ten_loai_chinh_tri") == selection
                              select new { id = c.Field<int>("id"), ten_chuc_vu = c.Field<string>("ten_chuc_vu") }).ToList();

                DataTable dt = ToDataTable(result);
                comB_ChucVu.DataSource = dt;
                comB_ChucVu.DisplayMember = "ten_chuc_vu";
                comB_ChucVu.ValueMember = "id";
            }
        }

        private void Load_Chinh_Tri_Ext(string p_ma_nv)
        {
            oChinhTriExt.Ma_NV = p_ma_nv;
            dtChinhTriExt = oChinhTriExt.GetData();

            if (dtChinhTriExt != null && dtChinhTriExt.Rows.Count > 0)
            {
                PrepareDataSource();
                EditDtgInterface();
            }
        }

        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtChinhTriExt;
            dtgv_DoanDang.DataSource = bs;
        }

        private void EditDtgInterface()
        {
            dtgv_DoanDang.Columns["ten_loai_chinh_tri"].HeaderText = "Loại";
            dtgv_DoanDang.Columns["ngay_vao"].HeaderText = "Ngày vào";
            dtgv_DoanDang.Columns["ngay_chinh_thuc"].HeaderText = "Ngày chính thức";
            dtgv_DoanDang.Columns["ngay_ra"].HeaderText = "Ngày ra";
            dtgv_DoanDang.Columns["ngay_tai_ket_nap"].HeaderText = "Ngày tái kết nạp";
            dtgv_DoanDang.Columns["ten_to_chuc"].HeaderText = "Tên tổ chức";

            dtgv_DoanDang.Columns["id"].Visible = false;
            dtgv_DoanDang.Columns["ma_nv"].Visible = false;
            dtgv_DoanDang.Columns["loai_chinh_tri_id"].Visible = false;
            //dtgv_DoanDang.Columns["chuc_vu_id_arr"].Visible = false;
        }

        private void Load_Chinh_Tri(string p_ma_nv)
        {
            oChinhTri.Ma_NV = p_ma_nv;
            dtChinhTri = oChinhTri.GetData();

            if (dtChinhTri != null && dtChinhTri.Rows.Count > 0)
            {
                txt_QuanHam.Text = dtChinhTri.Rows[0]["quan_ham_cao_nhat"].ToString();
                txt_DanhHieu.Text = dtChinhTri.Rows[0]["danh_hieu_cao_nhat"].ToString();
                txt_ThuongBinh.Text = dtChinhTri.Rows[0]["thuong_binh_hang"].ToString();
                txt_GiaDinh.Text = dtChinhTri.Rows[0]["gia_dinh_chinh_sach"].ToString();
                txt_LyLuanChinhTri.Text = dtChinhTri.Rows[0]["ly_luan_chinh_tri"].ToString();
                txt_QuanLyNhaNuoc.Text = dtChinhTri.Rows[0]["quan_ly_nha_nuoc"].ToString();
                rtb_KhenThuong.Text = dtChinhTri.Rows[0]["khen_thuong"].ToString();
                rTB_KyLuat.Text = dtChinhTri.Rows[0]["ky_luat"].ToString();

                if (dtChinhTri.Rows[0]["ngay_nhap_ngu"].ToString() != "")
                {
                    dtp_NgayNhapNgu.Checked = true;
                    dtp_NgayNhapNgu.Value = Convert.ToDateTime(dtChinhTri.Rows[0]["ngay_nhap_ngu"].ToString());
                }
                else
                    dtp_NgayNhapNgu.Checked = false;

                if (dtChinhTri.Rows[0]["ngay_xuat_ngu"].ToString() != "")
                {
                    dtp_NgayXuatNgu.Checked = true;
                    dtp_NgayXuatNgu.Value = Convert.ToDateTime(dtChinhTri.Rows[0]["ngay_xuat_ngu"].ToString());
                }
                else
                    dtp_NgayXuatNgu.Checked = false;

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

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            oChinhTri = new Business.CNVC.CNVC_ChinhTri();
            oChinhTri.Ma_NV = Program.selected_ma_nv;
            oChinhTri.Quan_Ham_Cao_Nhat = txt_QuanHam.Text;
            oChinhTri.Danh_Hieu_Cao_Nhat = txt_DanhHieu.Text;
            oChinhTri.Thuong_Binh_Hang = txt_ThuongBinh.Text;
            oChinhTri.Gia_Dinh_Chinh_Sach = txt_GiaDinh.Text;
            oChinhTri.Ly_Luan_Chinh_Tri = txt_LyLuanChinhTri.Text;
            oChinhTri.Quan_Ly_Nha_Nuoc = txt_QuanLyNhaNuoc.Text;
            oChinhTri.Khen_Thuong = rtb_KhenThuong.Text;
            oChinhTri.Ky_Luat = rTB_KyLuat.Text;
            if (dtp_NgayNhapNgu.Checked == true)
                oChinhTri.Ngay_Nhap_Ngu = dtp_NgayNhapNgu.Value;
            if (dtp_NgayXuatNgu.Checked == true)
                oChinhTri.Ngay_Xuat_Ngu = dtp_NgayXuatNgu.Value;

            try
            {
                if (MessageBox.Show("Bạn thực sự muốn lưu thông tin chính trị chung cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oChinhTri.Save())
                    {
                        MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Thao tác lưu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác lưu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void comB_Loai_SelectionChangeCommitted(object sender, EventArgs e)
        {
            old_select_id = 0;
            listB_DSCV.Items.Clear();
            //Load_Cbo_ChucVu_ChinhTri();
        }

        private void lbl_ThemDoanDang_Click(object sender, EventArgs e)
        {
            if (lbl_ThemDoanDang.Text == "Thêm")
            {
                bAddFlag = true;
                ResetInterface(false);
                old_select_id = 0;
            }
            else //chức năng Lưu
            {
                oChinhTriExt = new Business.CNVC.CNVC_ChinhTriExt();
                oChinhTriExt.Ma_NV = Program.selected_ma_nv;
                string loai_ctr = comB_Loai.Text;
                switch (loai_ctr)
                {
                    case "Đoàn viên":
                        oChinhTriExt.Loai_Chinh_tri_ID = 1;
                        break;
                    case "Đảng viên":
                        oChinhTriExt.Loai_Chinh_tri_ID = 2;
                        break;
                    case "Dân quân tự vệ":
                        oChinhTriExt.Loai_Chinh_tri_ID = 3;
                        break;
                    case "Công đoàn viên":
                        oChinhTriExt.Loai_Chinh_tri_ID = 4;
                        break;
                    default:
                        break;
                }

                if (dtp_NgayVao.Checked == true)
                    oChinhTriExt.Ngay_Vao = dtp_NgayVao.Value;
                if (dtp_NgayRa.Checked == true)
                    oChinhTriExt.Ngay_Ra = dtp_NgayRa.Value;
                if (dtp_NgayTaiKetNap.Checked == true)
                    oChinhTriExt.Ngay_Tai_Ket_Nap = dtp_NgayTaiKetNap.Value;
                if (dtp_NgayChinhThuc.Checked == true)
                    oChinhTriExt.Ngay_Chinh_Thuc = dtp_NgayChinhThuc.Value;

                try
                {
                    int[] chuc_vu_id = new int[listB_DSCV.Items.Count];
                    for (int i = 0; i < listB_DSCV.Items.Count; i++)
                    {
                        string chuc_vu = listB_DSCV.Items[i].ToString();
                        var result = from c in dtChucVu_ChinhTri.AsEnumerable()
                                     where c.Field<string>("ten_chuc_vu") == chuc_vu
                                     select c.Field<int>("id");
                        chuc_vu_id[i] = Convert.ToInt16(result.ElementAt(0).ToString());
                    }
                    oChinhTriExt.Chuc_Vu_ID = chuc_vu_id;
                }
                catch { }
                oChinhTriExt.Ten_To_Chuc = txt_TenToChuc.Text;

                #region thao tac them
                if (bAddFlag)
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm hoạt động chính trị của nhân viên?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            if (oChinhTriExt.Add())
                                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            old_select_id = 0;
                            Load_Chinh_Tri_Ext(Program.selected_ma_nv);
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
                    if (MessageBox.Show("Bạn thực sự muốn sửa hoạt động chính trị này của nhân viên?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            oChinhTriExt.ID = Convert.ToInt32(dtgv_DoanDang.CurrentRow.Cells["id"].Value.ToString());
                            if (oChinhTriExt.Update())
                                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            old_select_id = 0;
                            Load_Chinh_Tri_Ext(Program.selected_ma_nv);
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

        private void lbl_SuaDoanDang_Click(object sender, EventArgs e)
        {
            if (lbl_SuaDoanDang.Text == "Sửa")
            {
                bAddFlag = false;
                ResetInterface(false);
                old_select_id = 0;
            }
            else if (lbl_SuaDoanDang.Text == "Hủy")
            {
                ResetInterface(true);
            }
        }

        private void lbl_XoaDoanDang_Click(object sender, EventArgs e)
        {
            if (dtgv_DoanDang.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá thông tin chính trị này của nhân viên?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oChinhTriExt.ID = Convert.ToInt16(dtgv_DoanDang.CurrentRow.Cells["id"].Value.ToString());
                        if (oChinhTriExt.Delete())
                            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        old_select_id = 0;
                        Load_Chinh_Tri_Ext(Program.selected_ma_nv);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void lbl_ThemChucVu_Click(object sender, EventArgs e)
        {
            if (!listB_DSCV.Items.Contains(comB_ChucVu.Text))
                listB_DSCV.Items.Add(comB_ChucVu.Text);
        }

        private void lbl_XoaChucVu_Click(object sender, EventArgs e)
        {
            listB_DSCV.Items.RemoveAt(listB_DSCV.SelectedIndex);
        }

        private void comB_Loai_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Cbo_ChucVu_ChinhTri();
        }

        private void lbl_ThemChucVuMoi_Click(object sender, EventArgs e)
        {
            QLNS.UCs.QLNS_ChucVu_ChinhTri chuc_vu_chtri = new QLNS_ChucVu_ChinhTri();
            QLNS.Forms.Popup popup = new Forms.Popup("Thêm chức vụ chính trị", chuc_vu_chtri);
            popup.ShowDialog();
            if (is_Modified_Ctri_CVu == true)
                Reload_Combo_ChucVu_ChinhTri();
        }

        private void Reload_Combo_ChucVu_ChinhTri()
        {
            Load_Cbo_ChucVu_ChinhTri();            
        
        }

    }
}
