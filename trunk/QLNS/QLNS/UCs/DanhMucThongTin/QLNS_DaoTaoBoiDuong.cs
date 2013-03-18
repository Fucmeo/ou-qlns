using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.CNVC;


namespace QLNS.UCs.DanhMucThongTin
{
    public partial class QLNS_DaoTaoBoiDuong : UserControl
    {
        public CNVC_DaoTaoBoiDuong oCNVC_DaoTaoBoiDuong;
        public Business.HinhThucDaoTao oHinhThucDaoTao;
        public Business.VanBangChinhQuy oVanBangChinhQuy;
        public DataTable dtDaoTaoBoiDuong , dtDaoTao , dtBoiDuong , dtHinhThuc, dtVanBang;

        bool bAddDaoTaoFlag = false;
        bool bAddBoiDuongFlag = false;

        public QLNS_DaoTaoBoiDuong()
        {
            InitializeComponent();
            oCNVC_DaoTaoBoiDuong = new CNVC_DaoTaoBoiDuong();
            oHinhThucDaoTao = new Business.HinhThucDaoTao();
            oVanBangChinhQuy = new Business.VanBangChinhQuy();
            dtDaoTaoBoiDuong = new DataTable();
            dtHinhThuc = new DataTable();
            dtDaoTao = new DataTable();
            dtBoiDuong = new DataTable();
            dtVanBang = new DataTable();
        }

        public void GetDaoTaoBoiDuongInfo(string m_MaNV)
        {
            oCNVC_DaoTaoBoiDuong.MaNV = m_MaNV;
            dtDaoTaoBoiDuong = oCNVC_DaoTaoBoiDuong.GetData();
            if (dtDaoTaoBoiDuong.Rows.Count > 0)
            {
                var t = dtDaoTaoBoiDuong.AsEnumerable().Where(a => a.Field<int?>("hinh_thuc_dao_tao_id").ToString() != "");
                if (t.Count() > 0)
                {
                    dtDaoTao = t.CopyToDataTable();
                }
                t = dtDaoTaoBoiDuong.AsEnumerable().Where(a => a.Field<int?>("hinh_thuc_dao_tao_id").ToString() == "");
                if (t.Count() > 0)
                {
                    dtBoiDuong = t.CopyToDataTable();
                }

            }
        }

        private void QLNS_DaoTaoBoiDuong_Load(object sender, EventArgs e)
        {
            LoadHinhThucData();
            LoadVanBangData();
        }

        private void LoadHinhThucData()
        {
            dtHinhThuc = oHinhThucDaoTao.GetData();

            DataTable dt = dtHinhThuc.Copy();

            //if (dt.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["ten_hinh_thuc"] = "";
            //    dr["id"] = -1;
            //    dt.Rows.InsertAt(dr, 0);
            //}
            
            // comb
            comB_HinhThuc.DataSource = dt;
            comB_HinhThuc.DisplayMember = "ten_hinh_thuc";
            comB_HinhThuc.ValueMember = "id";

            comB_HinhThuc.SelectedIndex = 0;
        }

        private void LoadVanBangData()
        {
            dtVanBang = oVanBangChinhQuy.GetData();

            DataTable dt = dtVanBang.Copy();

            if (dt.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt.NewRow();
                dr["ten_van_bang"] = "";
                dr["id"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }

            // comb
            comB_VanBang.DataSource = dt;
            comB_VanBang.DisplayMember = "ten_van_bang";
            comB_VanBang.ValueMember = "id";

            comB_VanBang.SelectedIndex = 0;
        }

        public void FillDaoTaoData()
        {
            if (dtDaoTao.Rows.Count > 0)
            {
                DataTable dt = dtDaoTao.Copy();
                dtgv_DaoTao.Columns.Clear();
                dtgv_DaoTao.DataSource = dt;
                Setup_dtgv_DaoTao();
            }
        }

        public void FillBoiDuongData()
        {
            if (dtBoiDuong.Rows.Count > 0)
            {
                DataTable dt = dtBoiDuong.Copy();
                dtgv_BoiDuong.Columns.Clear();
                dtgv_BoiDuong.DataSource = dt;
                Setup_dtgv_BoiDuong();
            }
        }

        #region Init Gridview

        private void Init_dtgv_DaoTao()
        {
            dtgv_DaoTao.Columns.Clear();
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            col = new DataGridViewTextBoxColumn();
            col.Name = "id";
            col.Visible = false;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên trường";
            col.Name = "ten_truong";
            col.Width = 350;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chuyên ngành";
            col.Name = "chuyen_nganh_dao_tao";
            col.Width = 250;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Từ ngày";
            col.Name = "tu_ngay";
            col.Width = 100;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Đến ngày";
            col.Name = "den_ngay";
            col.Width = 100;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "hinh_thuc_dao_tao_id";
            col.Visible = false;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Hình thức";
            col.Name = "ten_hinh_thuc";
            col.Width = 200;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Xếp loại";
            col.Name = "xep_loai";
            col.Width = 150;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "cq_van_bang_id";
            col.Visible = false;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Văn bằng";
            col.Name = "ten_van_bang";
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên luận văn";
            col.Name = "cq_ten_luan_van";
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Hội đồng chấm";
            col.Name = "cq_hoi_dong_cham";
            dtgv_DaoTao.Columns.Add(col);
        }

        private void Init_dtgv_BoiDuong()
        {
            dtgv_BoiDuong.Columns.Clear();
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            col = new DataGridViewTextBoxColumn();
            col.Name = "id";
            col.Visible = false;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên trường";
            col.Name = "ten_truong";
            col.Width = 350;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chuyên ngành";
            col.Name = "chuyen_nganh_dao_tao";
            col.Width = 250;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Từ ngày";
            col.Name = "tu_ngay";
            col.Width = 100;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Đến ngày";
            col.Name = "den_ngay";
            col.Width = 100;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Xếp loại";
            col.Name = "xep_loai";
            col.Width = 150;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên chứng chỉ";
            col.Name = "bd_ten_chung_chi";
            dtgv_BoiDuong.Columns.Add(col);


        } 
        #endregion

        private void Setup_dtgv_DaoTao()
        {
            dtgv_DaoTao.Columns["ma_nv"].Visible = dtgv_DaoTao.Columns["id"].Visible = dtgv_DaoTao.Columns["hinh_thuc_dao_tao_id"].Visible =
                dtgv_DaoTao.Columns["cq_van_bang_id"].Visible = dtgv_DaoTao.Columns["bd_ten_chung_chi"].Visible = false; 

            //  
            dtgv_DaoTao.Columns["ten_truong"].HeaderText = "Tên trường";
            dtgv_DaoTao.Columns["ten_truong"].Width = 350;
            dtgv_DaoTao.Columns["chuyen_nganh_dao_tao"].HeaderText = "Chuyên ngành";
            dtgv_DaoTao.Columns["chuyen_nganh_dao_tao"].Width = 250;
            dtgv_DaoTao.Columns["tu_ngay"].HeaderText = "Từ ngày";
            dtgv_DaoTao.Columns["tu_ngay"].Width = 100;
            dtgv_DaoTao.Columns["den_ngay"].HeaderText = "Đến ngày";
            dtgv_DaoTao.Columns["den_ngay"].Width = 100;
            dtgv_DaoTao.Columns["ten_hinh_thuc"].HeaderText = "Hình thức";
            dtgv_DaoTao.Columns["ten_hinh_thuc"].Width = 200;
            dtgv_DaoTao.Columns["xep_loai"].HeaderText = "Xếp loại";
            dtgv_DaoTao.Columns["xep_loai"].Width = 150;
            dtgv_DaoTao.Columns["ten_van_bang"].HeaderText = "Văn bằng";
            dtgv_DaoTao.Columns["ten_van_bang"].Width = 200;
            dtgv_DaoTao.Columns["cq_ten_luan_van"].HeaderText = "Tên luận văn";
            dtgv_DaoTao.Columns["cq_ten_luan_van"].Width = 150;
            dtgv_DaoTao.Columns["cq_hoi_dong_cham"].HeaderText = "Hội đồng chấm";
            dtgv_DaoTao.Columns["cq_hoi_dong_cham"].Width = 150;
        }

        private void Setup_dtgv_BoiDuong()
        {
            dtgv_BoiDuong.Columns["id"].Visible = dtgv_BoiDuong.Columns["hinh_thuc_dao_tao_id"].Visible =
                dtgv_BoiDuong.Columns["cq_van_bang_id"].Visible = dtgv_BoiDuong.Columns["ten_hinh_thuc"].Visible =
               dtgv_BoiDuong.Columns["ten_van_bang"].Visible = dtgv_BoiDuong.Columns["cq_ten_luan_van"].Visible =
               dtgv_BoiDuong.Columns["cq_hoi_dong_cham"].Visible = dtgv_BoiDuong.Columns["ma_nv"].Visible = false;

            //  
            dtgv_BoiDuong.Columns["ten_truong"].HeaderText = "Tên trường";
            dtgv_BoiDuong.Columns["ten_truong"].Width = 350;
            dtgv_BoiDuong.Columns["chuyen_nganh_dao_tao"].HeaderText = "Chuyên ngành";
            dtgv_BoiDuong.Columns["chuyen_nganh_dao_tao"].Width = 250;
            dtgv_BoiDuong.Columns["tu_ngay"].HeaderText = "Từ ngày";
            dtgv_BoiDuong.Columns["tu_ngay"].Width = 100;
            dtgv_BoiDuong.Columns["den_ngay"].HeaderText = "Đến ngày";
            dtgv_BoiDuong.Columns["den_ngay"].Width = 100;
            dtgv_BoiDuong.Columns["xep_loai"].HeaderText = "Xếp loại";
            dtgv_BoiDuong.Columns["xep_loai"].Width = 150;
            dtgv_BoiDuong.Columns["bd_ten_chung_chi"].HeaderText = "Tên chứng chỉ";
            dtgv_BoiDuong.Columns["bd_ten_chung_chi"].Width = 150;
        }

        private void dtgv_DaoTao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_DaoTao.Rows.Count > 0 && dtgv_DaoTao.SelectedRows != null)
            {
                DataGridViewRow r = dtgv_DaoTao.SelectedRows[0];

                txt_TenTruong_DaoTao.Text = r.Cells["ten_truong"].Value.ToString();
                txt_ChuyenNganh_DaoTao.Text = r.Cells["chuyen_nganh_dao_tao"].Value.ToString();
                txt_XepLoai_DaoTao.Text = r.Cells["xep_loai"].Value.ToString();
                txt_TenLuanVan.Text = r.Cells["cq_ten_luan_van"].Value.ToString();
                txt_HoiDong.Text = r.Cells["cq_hoi_dong_cham"].Value.ToString();

                if (r.Cells["cq_van_bang_id"].Value.ToString() == "")
                {
                    comB_VanBang.SelectedValue = -1;
                }
                else
                {
                    comB_VanBang.SelectedValue = Convert.ToInt32(r.Cells["cq_van_bang_id"].Value);
                }
                comB_HinhThuc.SelectedValue = Convert.ToInt32(r.Cells["hinh_thuc_dao_tao_id"].Value);

                if (r.Cells["tu_ngay"].Value.ToString() != "")
                {
                    dTP_TuNgay_DaoTao.Checked = true;
                    dTP_TuNgay_DaoTao.Value = Convert.ToDateTime(r.Cells["tu_ngay"].Value);
                }
                else
                {
                    dTP_TuNgay_DaoTao.Checked = false;
                }

                if (r.Cells["den_ngay"].Value.ToString() != "")
                {
                    dTP_DenNgay_DaoTao.Checked = true;
                    dTP_DenNgay_DaoTao.Value = Convert.ToDateTime(r.Cells["den_ngay"].Value);
                }
                else
                {
                    dTP_DenNgay_DaoTao.Checked = false;
                }
            }
        }

        private void dtgv_BoiDuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_BoiDuong.Rows.Count > 0 && dtgv_BoiDuong.SelectedRows != null)
            {
                DataGridViewRow r = dtgv_BoiDuong.SelectedRows[0];

                txt_TenTruong_BoiDuong.Text = r.Cells["ten_truong"].Value.ToString();
                txt_ChuyenNganh_BoiDuong.Text = r.Cells["chuyen_nganh_dao_tao"].Value.ToString();
                txt_XepLoai_BoiDuong.Text = r.Cells["xep_loai"].Value.ToString();
                txt_TenChungChi.Text = r.Cells["bd_ten_chung_chi"].Value.ToString();

                if (r.Cells["tu_ngay"].Value.ToString() != "")
                {
                    dTP_TuNgay_BoiDuong.Checked = true;
                    dTP_TuNgay_BoiDuong.Value = Convert.ToDateTime(r.Cells["tu_ngay"].Value);
                }
                else
                {
                    dTP_TuNgay_BoiDuong.Checked = false;
                }

                if (r.Cells["den_ngay"].Value.ToString() != "")
                {
                    dTP_DenNgay_BoiDuong.Checked = true;
                    dTP_DenNgay_BoiDuong.Value = Convert.ToDateTime(r.Cells["den_ngay"].Value);
                }
                else
                {
                    dTP_DenNgay_BoiDuong.Checked = false;
                }
            }
        }

        private void ControlDaoTao(bool Add)
        {

            if (Add)
            {
                lbl_SuaDaoTao.Text = "Huỷ";
                lbl_ThemDaoTao.Text = "Lưu";
                txt_TenTruong_DaoTao.Enabled = txt_ChuyenNganh_DaoTao.Enabled = txt_XepLoai_DaoTao.Enabled
                    = txt_TenLuanVan.Enabled = txt_HoiDong.Enabled = dTP_DenNgay_DaoTao.Enabled =
                    dTP_TuNgay_DaoTao.Enabled = comB_HinhThuc.Enabled = comB_VanBang.Enabled = true;
                dtgv_DaoTao.Enabled = lbl_XoaDaoTao.Enabled = false;
            }
            else
            {
                lbl_SuaDaoTao.Text = "Sửa";
                lbl_ThemDaoTao.Text = "Thêm";
                txt_TenTruong_DaoTao.Enabled = txt_ChuyenNganh_DaoTao.Enabled = txt_XepLoai_DaoTao.Enabled
                    = txt_TenLuanVan.Enabled = txt_HoiDong.Enabled = dTP_DenNgay_DaoTao.Enabled =
                    dTP_TuNgay_DaoTao.Enabled = comB_HinhThuc.Enabled = comB_VanBang.Enabled = false;
                dtgv_DaoTao.Enabled = lbl_XoaDaoTao.Enabled = true;

            }
        }

        private void ControlBoiDuong(bool Add)
        {

            if (Add)
            {
                lbl_SuaBoiDuong.Text = "Huỷ";
                lbl_ThemBoiDuong.Text = "Lưu";
                txt_TenTruong_BoiDuong.Enabled = txt_ChuyenNganh_BoiDuong.Enabled = txt_XepLoai_BoiDuong.Enabled
                    = txt_TenChungChi.Enabled = dTP_DenNgay_BoiDuong.Enabled =
                    dTP_TuNgay_BoiDuong.Enabled = true;
                dtgv_BoiDuong.Enabled = lbl_XoaBoiDuong.Enabled = false;
            }
            else
            {
                lbl_SuaBoiDuong.Text = "Sửa";
                lbl_ThemBoiDuong.Text = "Thêm";
                txt_TenTruong_BoiDuong.Enabled = txt_ChuyenNganh_BoiDuong.Enabled = txt_XepLoai_BoiDuong.Enabled
                    = txt_TenChungChi.Enabled = dTP_DenNgay_BoiDuong.Enabled =
                    dTP_TuNgay_BoiDuong.Enabled = false;
                dtgv_BoiDuong.Enabled = lbl_XoaBoiDuong.Enabled = true;

            }
        }

        private void lbl_ThemDaoTao_Click(object sender, EventArgs e)
        {
            #region MyRegion

            if (lbl_ThemDaoTao.Text == "Thêm")
            {
                bAddDaoTaoFlag = true;
                ControlDaoTao(true);
                ClearDaoTaoData();
            }
            else        // LƯU
            {
                if (VerifyDaoTaoData())
                {
                    if (bAddDaoTaoFlag)   // Thêm mới
                    {
                        if ((MessageBox.Show("Thêm thông tin đào tạo của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            try
                            {
                                GetDaoTaoInputData();
                                oCNVC_DaoTaoBoiDuong.Add();

                                // load lai dtgv_CMND
                                GetDaoTaoBoiDuongInfo(Program.selected_ma_nv);
                                dtgv_DaoTao.DataSource = dtDaoTao;
                                Setup_dtgv_DaoTao();

                                MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin đào tạo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else        // Sửa
                    {
                        if ((MessageBox.Show("Sửa thông tin đào tạo của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            try
                            {
                                GetDaoTaoInputData();
                                oCNVC_DaoTaoBoiDuong.Update();

                                // load lai dtgv_CMND
                                GetDaoTaoBoiDuongInfo(Program.selected_ma_nv);
                                dtgv_DaoTao.DataSource = dtDaoTao;
                                Setup_dtgv_DaoTao();

                                MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin đào tạo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    ControlDaoTao(false);
                    ClearDaoTaoData();
                }
                else
                {
                    MessageBox.Show("Thông tin đào tạo không phù hợp, xin vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion
        }

        private void lbl_SuaDaoTao_Click(object sender, EventArgs e)
        {
            if (lbl_SuaDaoTao.Text == "Sửa")
            {
                if (dtgv_DaoTao.Rows.Count > 0 && dtgv_DaoTao.SelectedRows != null)
                {
                    txt_TenTruong_DaoTao.Focus();
                    bAddDaoTaoFlag = false;
                    ControlDaoTao(true);
                }
                else
                {
                    MessageBox.Show("Chưa có thông tin về trình độ phổ thông của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else        // HUỶ
            {
                bAddDaoTaoFlag = false;
                ControlDaoTao(false);
                ClearDaoTaoData();

            }
        }

        private void lbl_XoaDaoTao_Click(object sender, EventArgs e)
        {
            if (dtgv_DaoTao.SelectedRows != null &&
                (MessageBox.Show("Xoá dòng dữ liệu đào tạo của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                DataGridViewRow r = dtgv_DaoTao.SelectedRows[0];
                oCNVC_DaoTaoBoiDuong.ID = Convert.ToInt32(r.Cells["id"].Value);

                try
                {
                    oCNVC_DaoTaoBoiDuong.Delete();
                    // load lai dtgv_DaoTao
                    GetDaoTaoBoiDuongInfo(Program.selected_ma_nv);
                    dtgv_DaoTao.DataSource = dtDaoTao;
                    Setup_dtgv_DaoTao();

                    MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xoá không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private bool VerifyDaoTaoData()
        {
            return true;

        }

        private bool VerifyBoiDuongData()
        {
            return true;

        }

        private void GetDaoTaoInputData()
        {
            oCNVC_DaoTaoBoiDuong.ID = Convert.ToInt32(dtgv_DaoTao.SelectedRows[0].Cells["id"].Value);
            oCNVC_DaoTaoBoiDuong.MaNV = Program.selected_ma_nv;
            oCNVC_DaoTaoBoiDuong.TenTruong = txt_TenTruong_DaoTao.Text;
            oCNVC_DaoTaoBoiDuong.ChuyenNganhDaoTao = txt_ChuyenNganh_DaoTao.Text;
            oCNVC_DaoTaoBoiDuong.XepLoai = txt_XepLoai_DaoTao.Text;
            oCNVC_DaoTaoBoiDuong.CQ_TenLuanVan = txt_TenLuanVan.Text;
            oCNVC_DaoTaoBoiDuong.CQ_HoiDongCham = txt_HoiDong.Text;
            oCNVC_DaoTaoBoiDuong.BD_TenChungChi = "";

            if (dTP_TuNgay_DaoTao.Checked)
            {
                oCNVC_DaoTaoBoiDuong.TuNgay = dTP_TuNgay_DaoTao.Value;
            }
            else
            {
                oCNVC_DaoTaoBoiDuong.TuNgay = null;
            }

            if (dTP_DenNgay_DaoTao.Checked)
            {
                oCNVC_DaoTaoBoiDuong.DenNgay = dTP_DenNgay_DaoTao.Value;
            }
            else
            {
                oCNVC_DaoTaoBoiDuong.DenNgay = null;
            }
            if(Convert.ToInt32(comB_HinhThuc.SelectedValue) == -1 )  oCNVC_DaoTaoBoiDuong.HinhThucDaoTaoID = null;
            else oCNVC_DaoTaoBoiDuong.HinhThucDaoTaoID = Convert.ToInt32(comB_HinhThuc.SelectedValue);

            if (Convert.ToInt32(comB_VanBang.SelectedValue) == -1) oCNVC_DaoTaoBoiDuong.CQ_VanBangID = null;
            else oCNVC_DaoTaoBoiDuong.CQ_VanBangID = Convert.ToInt32(comB_VanBang.SelectedValue);
                 

        }

        private void GetBoiDuongInputData()
        {
            oCNVC_DaoTaoBoiDuong.ID = Convert.ToInt32(dtgv_BoiDuong.SelectedRows[0].Cells["id"].Value);
            oCNVC_DaoTaoBoiDuong.MaNV = Program.selected_ma_nv;
            oCNVC_DaoTaoBoiDuong.TenTruong = txt_TenTruong_BoiDuong.Text;
            oCNVC_DaoTaoBoiDuong.ChuyenNganhDaoTao = txt_ChuyenNganh_BoiDuong.Text;
            oCNVC_DaoTaoBoiDuong.XepLoai = txt_XepLoai_BoiDuong.Text;
            oCNVC_DaoTaoBoiDuong.BD_TenChungChi = txt_TenChungChi.Text;
            oCNVC_DaoTaoBoiDuong.CQ_HoiDongCham = "";
            oCNVC_DaoTaoBoiDuong.CQ_TenLuanVan = txt_TenLuanVan.Text;

            if (dTP_TuNgay_BoiDuong.Checked)
            {
                oCNVC_DaoTaoBoiDuong.TuNgay = dTP_TuNgay_BoiDuong.Value;
            }
            else
            {
                oCNVC_DaoTaoBoiDuong.TuNgay = null;
            }

            if (dTP_DenNgay_BoiDuong.Checked)
            {
                oCNVC_DaoTaoBoiDuong.DenNgay = dTP_DenNgay_BoiDuong.Value;
            }
            else
            {
                oCNVC_DaoTaoBoiDuong.DenNgay = null;
            }

            oCNVC_DaoTaoBoiDuong.HinhThucDaoTaoID = null;
            oCNVC_DaoTaoBoiDuong.CQ_VanBangID = null;


        }

        private void ClearDaoTaoData()
        {
            txt_TenTruong_DaoTao.Text = txt_ChuyenNganh_DaoTao.Text = txt_HoiDong.Text
                = txt_TenLuanVan.Text = txt_XepLoai_DaoTao.Text = "";
            
            dTP_DenNgay_DaoTao.Checked = dTP_TuNgay_DaoTao.Checked = false;

            comB_HinhThuc.SelectedIndex = comB_VanBang.SelectedIndex = 0;
        }

        private void ClearBoiDuongData()
        {
            txt_TenTruong_BoiDuong.Text = txt_ChuyenNganh_BoiDuong.Text = 
                txt_TenChungChi.Text = txt_XepLoai_BoiDuong.Text = "";

            dTP_DenNgay_BoiDuong.Checked = dTP_TuNgay_BoiDuong.Checked = false;

        }

        private void lbl_ThemBoiDuong_Click(object sender, EventArgs e)
        {
            #region MyRegion

            if (lbl_ThemBoiDuong.Text == "Thêm")
            {
                bAddBoiDuongFlag = true;
                ControlBoiDuong(true);
                ClearBoiDuongData();
            }
            else        // LƯU
            {
                if (VerifyBoiDuongData())
                {
                    if (bAddBoiDuongFlag)   // Thêm mới
                    {
                        if ((MessageBox.Show("Thêm thông tin bồi dưỡng của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            try
                            {
                                GetBoiDuongInputData();
                                oCNVC_DaoTaoBoiDuong.Add();

                                // load lai dtgv_CMND
                                GetDaoTaoBoiDuongInfo(Program.selected_ma_nv);
                                dtgv_BoiDuong.DataSource = dtBoiDuong;
                                Setup_dtgv_BoiDuong();

                                MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin bồi dưỡng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else        // Sửa
                    {
                        if ((MessageBox.Show("Sửa thông tin bồi dưỡng của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            try
                            {
                                GetBoiDuongInputData();
                                oCNVC_DaoTaoBoiDuong.Update();

                                // load lai dtgv_CMND
                                GetDaoTaoBoiDuongInfo(Program.selected_ma_nv);
                                dtgv_BoiDuong.DataSource = dtBoiDuong;
                                Setup_dtgv_BoiDuong();

                                MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin bồi dưỡng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    ControlBoiDuong(false);
                    ClearBoiDuongData();
                }
                else
                {
                    MessageBox.Show("Thông tin bồi dưỡng không phù hợp, xin vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion
        }

        private void lbl_SuaBoiDuong_Click(object sender, EventArgs e)
        {
            if (lbl_SuaBoiDuong.Text == "Sửa")
            {
                if (dtgv_BoiDuong.Rows.Count > 0 && dtgv_BoiDuong.SelectedRows != null)
                {
                    txt_TenTruong_BoiDuong.Focus();
                    bAddBoiDuongFlag = false;
                    ControlBoiDuong(true);
                }
                else
                {
                    MessageBox.Show("Chưa có thông tin về trình độ phổ thông của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else        // HUỶ
            {
                bAddBoiDuongFlag = false;
                ControlBoiDuong(false);
                ClearBoiDuongData();

            }
        }

        private void lbl_XoaBoiDuong_Click(object sender, EventArgs e)
        {
            if (dtgv_BoiDuong.SelectedRows != null &&
                (MessageBox.Show("Xoá dòng dữ liệu bồi dưỡng của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                DataGridViewRow r = dtgv_BoiDuong.SelectedRows[0];
                oCNVC_DaoTaoBoiDuong.ID = Convert.ToInt32(r.Cells["id"].Value);

                try
                {
                    oCNVC_DaoTaoBoiDuong.Delete();
                    // load lai dtgv_DaoTao
                    GetDaoTaoBoiDuongInfo(Program.selected_ma_nv);
                    dtgv_BoiDuong.DataSource = dtBoiDuong;
                    Setup_dtgv_BoiDuong();

                    MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xoá không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }
    }
}

