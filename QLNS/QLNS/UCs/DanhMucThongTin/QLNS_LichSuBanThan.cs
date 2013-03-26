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
    public partial class QLNS_LichSuBanThan : UserControl
    {
        public CNVC_LSBiBat oCNVC_LSBiBat;
        public CNVC_QuanHeToChuc oCNVC_QuanHeToChuc;
        public DataTable dtLSBiBat, dtQHToChuc, dtTinhTP, dtQuocGia;

        Business.TinhTP oTinhTP;
        Business.QuocGia oQuocGia;

        bool bAddLSBiBatFlag = false, bAddQHToChucFlag = false;

        public static int nNewTinhTPID = 0;     // ID cua tinh thanh pho moi them vao
        public static int nNewQuocGiaID = 0;     // ID cua quoc gia moi them vao

        public QLNS_LichSuBanThan()
        {
            InitializeComponent();

            oCNVC_LSBiBat = new CNVC_LSBiBat();
            oCNVC_QuanHeToChuc = new CNVC_QuanHeToChuc();
            dtLSBiBat = new DataTable();
            dtQHToChuc = new DataTable();
            dtTinhTP = new DataTable();
            dtQuocGia = new DataTable();
            oTinhTP = new Business.TinhTP();
            oQuocGia = new Business.QuocGia();
        }

        public void GetLSBiBatInfo(string m_MaNV)
        {
            oCNVC_LSBiBat.MaNV = m_MaNV;
            dtLSBiBat = oCNVC_LSBiBat.GetData();
        }

        public void GetQHToChuc(string m_MaNV)
        {
            oCNVC_QuanHeToChuc.MaNV = m_MaNV;
            dtQHToChuc = oCNVC_QuanHeToChuc.GetData();
        }

        private void QLNS_LichSuBanThan_Load(object sender, EventArgs e)
        {
            LoadQuocGiaData();
            if (comB_QuocGia.Items.Count > 0)
                comB_QuocGia.SelectedIndex = 0;

            
             LoadTinhData(dtTinhTP.Copy());
            

            //Init_dtgv_CMNDHoChieu();
        }

        public void FillLSBiBatInfo()
        {
            if (dtLSBiBat.Rows.Count > 0)
            {
                DataTable dt = dtLSBiBat.Copy();
                dtgv_TienAn.Columns.Clear();
                dtgv_TienAn.DataSource = dt;
                Setup_dtgv_TienAn();
            }
        }

        public void FillQHToChucInfo()
        {
            if (dtQHToChuc.Rows.Count > 0)
            {
                DataTable dt = dtQHToChuc.Copy();
                dtgv_QHToChuc.Columns.Clear();
                dtgv_QHToChuc.DataSource = dt;
                Setup_dtgv_QHToChuc();
            }
        }
        #region Xu ly tinh / quoc gia

        public void LoadTinhData(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)        // de phong TH quoc gia dang chon khong co tp
            {
                dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id", typeof(int)), new DataColumn("ten_tinh_tp", typeof(string)), 
                                                        new DataColumn("quoc_gia_id", typeof(int)) });
            }
            if (dt.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt.NewRow();
                dr["ten_tinh_tp"] = "";
                dr["id"] = -1;
                dr["quoc_gia_id"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }

            // comb
            comB_Tinh.DataSource = dt;
            comB_Tinh.DisplayMember = "ten_tinh_tp";
            comB_Tinh.ValueMember = "id";
        }

        public void LoadQuocGiaData()
        {
            dtQuocGia = oQuocGia.GetData();
            dtTinhTP = oTinhTP.GetData();

            // comb
            comB_QuocGia.DataSource = dtQuocGia;
            comB_QuocGia.DisplayMember = "ten_quoc_gia";
            comB_QuocGia.ValueMember = "id";
        }

        private void comB_QuocGia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ChangeTinhCombByQuocGia();
        }

        private void ChangeTinhCombByQuocGia()
        {
            int v = Convert.ToInt32(comB_QuocGia.SelectedValue);

            if (v == -1)    // combo quoc gia rong
            {
                LoadTinhData(dtTinhTP);
            }
            else
            {
                var dt = dtTinhTP.AsEnumerable().Where(a => a.Field<int>("quoc_gia_id") == v);
                if (dt != null && dt.Count() > 0)
                {
                    LoadTinhData(dt.CopyToDataTable());
                }
                else
                {
                    LoadTinhData(null);
                }
            }
        }

        private void lbl_ThemTinh_Click(object sender, EventArgs e)
        {
            UCs.ThemTinhTP oThemTinhTP = new ThemTinhTP("QLNS_ThongTinNV");
            oThemTinhTP.Dock = DockStyle.Fill;
            Forms.Popup fPopup = new Forms.Popup("Thêm tỉnh thành phố", oThemTinhTP);
            fPopup.ShowDialog();
            if (nNewTinhTPID > 0)
            {
                int? x = null;

                if (comB_Tinh.SelectedValue != Convert.DBNull && comB_Tinh.SelectedValue != null)
                    x = Convert.ToInt16(comB_Tinh.SelectedValue);

                dtTinhTP = oTinhTP.GetData();

                comB_Tinh.DataSource = dtTinhTP;
                comB_Tinh.DisplayMember = "ten_tinh_tp";
                comB_Tinh.ValueMember = "id";

                if (x != null)
                {
                    comB_Tinh.SelectedValue = x;
                }
                nNewTinhTPID = 0;


            }
        }

        private void lbl_ThemQuocGia_Click(object sender, EventArgs e)
        {
            UCs.ThemQuocGia oThemQuocGia = new ThemQuocGia("QLNS_ThongTinNV");
            oThemQuocGia.Dock = DockStyle.Fill;
            Forms.Popup fPopup = new Forms.Popup("Thêm quốc gia", oThemQuocGia);
            fPopup.ShowDialog();
            if (nNewQuocGiaID > 0)
            {
                int? x = null;

                if (comB_Tinh.SelectedValue != Convert.DBNull && comB_Tinh.SelectedValue != null)
                    x = Convert.ToInt16(comB_Tinh.SelectedValue);

                dtQuocGia = oQuocGia.GetData();

                comB_QuocGia.DataSource = dtQuocGia;
                comB_QuocGia.DisplayMember = "ten_quoc_gia";
                comB_QuocGia.ValueMember = "id";

                if (x != null)
                {
                    comB_QuocGia.SelectedValue = x;
                }
                nNewQuocGiaID = 0;
            }
        }

        private void comB_Tinh_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int v = Convert.ToInt32(comB_Tinh.SelectedValue);

            if (v != -1)    // combo tinh rong
            {
                var ids = from c in dtTinhTP.AsEnumerable()
                          where c.Field<int>("id") == v
                          select c.Field<int>("quoc_gia_id");

                int quoc_gia_id = ids.ElementAt<int>(0);

                comB_QuocGia.SelectedValue = quoc_gia_id;
                ExcludeTinhData(quoc_gia_id, v);
            }
        }


        #endregion

        private void GetLSBiBatInputData()
        {
            if(bAddLSBiBatFlag == false)     // dang sua moi get id
                oCNVC_LSBiBat.ID = Convert.ToInt32(dtgv_TienAn.SelectedRows[0].Cells["id"].Value);

            oCNVC_LSBiBat.MaNV = Program.selected_ma_nv;
            oCNVC_LSBiBat.BiTu = comB_HinhThuc.SelectedIndex == 0 ? true : false;
            oCNVC_LSBiBat.TaiNoi = txt_TaiNoi.Text;
            oCNVC_LSBiBat.NguoiKhaiBao = txt_NguoiKhaiBao.Text;
            oCNVC_LSBiBat.NoiDung = rTB_NoiDung.Text;

            if (dTP_TuNgay.Checked)
            {
                oCNVC_LSBiBat.TuThoiGian = dTP_TuNgay.Value;
            }
            else
            {
                oCNVC_LSBiBat.TuThoiGian = null;
            }

            if (dTP_DenNgay.Checked)
            {
                oCNVC_LSBiBat.DenThoiGian = dTP_DenNgay.Value;
            }
            else
            {
                oCNVC_LSBiBat.DenThoiGian = null;
            }
        }

        private void GetQHToChucInputData()
        {
            if(bAddQHToChucFlag == false)     // dang sua moi get id
                oCNVC_QuanHeToChuc.ID = Convert.ToInt32(dtgv_QHToChuc.SelectedRows[0].Cells["id"].Value);

            oCNVC_QuanHeToChuc.MaNV = Program.selected_ma_nv;
            oCNVC_QuanHeToChuc.TenToChuc = txt_TenToChuc.Text;
            oCNVC_QuanHeToChuc.NuocNgoai = cb_NuocNgoai.Checked;
            oCNVC_QuanHeToChuc.ChucDanh = txt_ChucDanh.Text;
            oCNVC_QuanHeToChuc.ChucVu = txt_ChucVu.Text;
            oCNVC_QuanHeToChuc.PhuongXa = txt_PhuongXa.Text;
            oCNVC_QuanHeToChuc.QuanHuyen = txt_QuanHuyen.Text;

            if (dTP_TuThoiGian.Checked)
            {
                oCNVC_QuanHeToChuc.TuThoiGian = dTP_TuThoiGian.Value;
            }
            else
            {
                oCNVC_QuanHeToChuc.TuThoiGian = null;
            }

            if (dTP_DenThoiGian.Checked)
            {
                oCNVC_QuanHeToChuc.DenThoiGian = dTP_DenThoiGian.Value;
            }
            else
            {
                oCNVC_QuanHeToChuc.DenThoiGian = null;
            }

            if (Convert.ToInt32(comB_Tinh.SelectedValue) == -1) oCNVC_QuanHeToChuc.TinhTP = null;
            else oCNVC_QuanHeToChuc.TinhTP = Convert.ToInt32(comB_Tinh.SelectedValue);

            if (Convert.ToInt32(comB_QuocGia.SelectedValue) == -1) oCNVC_QuanHeToChuc.QuocGia = null;
            else oCNVC_QuanHeToChuc.QuocGia = Convert.ToInt32(comB_QuocGia.SelectedValue);
        }

        private void lbl_ThemTienAn_Click(object sender, EventArgs e)
        {
            #region MyRegion

            if (Program.selected_ma_nv != "")
            {
                if (lbl_ThemTienAn.Text == "Thêm")
                {
                    bAddLSBiBatFlag = true;
                    ControlLSBiBat(true);
                    ClearLSBiBatData();
                }
                else        // LƯU
                {

                    if (bAddLSBiBatFlag)   // Thêm mới
                    {
                        if ((MessageBox.Show("Thêm thông tin về tiền án / tiền sự của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            try
                            {
                                GetLSBiBatInputData();
                                oCNVC_LSBiBat.Add();

                                // load lai dtgv_CMND
                                dtLSBiBat = oCNVC_LSBiBat.GetData();
                                dtgv_TienAn.DataSource = dtLSBiBat;
                                Setup_dtgv_TienAn();

                                MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin tiền án / tiền sự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else        // Sửa
                    {
                        if ((MessageBox.Show("Sửa thông tin về tiền án / tiền sự của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            try
                            {
                                GetLSBiBatInputData();
                                oCNVC_LSBiBat.Update();

                                // load lai dtgv_CMND
                                dtLSBiBat = oCNVC_LSBiBat.GetData();
                                dtgv_TienAn.DataSource = dtLSBiBat;
                                Setup_dtgv_TienAn();

                                MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin tiền án / tiền sự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }



                    ControlLSBiBat(false);
                    ClearLSBiBatData();

                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            #endregion

        }

        private void lbl_SuaTienAn_Click(object sender, EventArgs e)
        {
            if (Program.selected_ma_nv != "")
            {
                if (lbl_SuaTienAn.Text == "Sửa")
                {
                    if (dtgv_TienAn.Rows.Count > 0 && dtgv_TienAn.SelectedRows != null)
                    {
                        txt_TaiNoi.Focus();
                        bAddLSBiBatFlag = false;
                        ControlLSBiBat(true);
                    }
                    else
                    {
                        MessageBox.Show("Chưa có thông tin về tiền án / tiền sử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else        // HUỶ
                {
                    bAddLSBiBatFlag = false;
                    ControlLSBiBat(false);
                    ClearLSBiBatData();

                }

            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void dtgv_TienAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_TienAn.Rows.Count > 0 && dtgv_TienAn.SelectedRows != null)
            {
                DataGridViewRow r = dtgv_TienAn.SelectedRows[0];

                if (r.Cells["bi_bat_bi_tu"].Value.ToString() == "Bị bắt")
                {
                    comB_HinhThuc.Text = "Bị bắt";
                }
                else
                {
                    comB_HinhThuc.Text = "Bị tù";
                }
                txt_TaiNoi.Text = r.Cells["tai_noi"].Value.ToString();

                if (r.Cells["tu_thoi_gian"].Value.ToString() != "" && r.Cells["tu_thoi_gian"].Value.ToString() != DateTime.MinValue.ToString())
                {
                    dTP_TuNgay.Checked = true;
                    dTP_TuNgay.Value = Convert.ToDateTime(r.Cells["tu_thoi_gian"].Value);
                }
                else
                    dTP_TuNgay.Checked = false;

                if (r.Cells["den_thoi_gian"].Value.ToString() != "" && r.Cells["den_thoi_gian"].Value.ToString() != DateTime.MinValue.ToString())
                {
                    dTP_DenNgay.Checked = true;
                    dTP_DenNgay.Value = Convert.ToDateTime(r.Cells["den_thoi_gian"].Value);
                }
                else
                    dTP_TuNgay.Checked = false;

                txt_NguoiKhaiBao.Text = r.Cells["nguoi_khai_bao"].Value.ToString();
                rTB_NoiDung.Text = r.Cells["noi_dung"].Value.ToString();

            }
        }

        private void lbl_ThemQH_Click(object sender, EventArgs e)
        {
            #region MyRegion
            if (Program.selected_ma_nv != "")
            {
                if (lbl_ThemQH.Text == "Thêm")
                {
                    bAddQHToChucFlag = true;
                    ControlQHToChuc(true);
                    ClearQHToChucData();
                }
                else        // LƯU
                {

                    if (bAddQHToChucFlag)   // Thêm mới
                    {
                        if ((MessageBox.Show("Thêm thông tin về quan hệ tổ chức của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            try
                            {
                                GetQHToChucInputData();
                                oCNVC_QuanHeToChuc.Add();

                                // load lai dtgv_CMND
                                dtQHToChuc = oCNVC_QuanHeToChuc.GetData();
                                dtgv_QHToChuc.DataSource = dtQHToChuc;
                                Setup_dtgv_QHToChuc();

                                MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin quan hệ tổ chức.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else        // Sửa
                    {
                        if ((MessageBox.Show("Sửa thông tin về quan hệ tổ chức của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            try
                            {
                                GetQHToChucInputData();
                                oCNVC_QuanHeToChuc.Update();

                                // load lai dtgv_CMND
                                dtQHToChuc = oCNVC_QuanHeToChuc.GetData();
                                dtgv_QHToChuc.DataSource = dtQHToChuc;
                                Setup_dtgv_QHToChuc();

                                MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin quan hệ tổ chức.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    ControlQHToChuc(false);
                    ClearQHToChucData();

                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
            #endregion

        }

        private void lbl_SuaQH_Click(object sender, EventArgs e)
        {
            if (Program.selected_ma_nv != "")
            {

                if (lbl_SuaQH.Text == "Sửa")
                {
                    if (dtgv_QHToChuc.Rows.Count > 0 && dtgv_QHToChuc.SelectedRows != null)
                    {
                        txt_TenToChuc.Focus();
                        bAddQHToChucFlag = false;
                        ControlQHToChuc(true);
                    }
                    else
                    {
                        MessageBox.Show("Chưa có thông tin về CMND / Hộ chiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else        // HUỶ
                {
                    bAddQHToChucFlag = false;
                    ControlQHToChuc(false);
                    ClearQHToChucData();

                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtgv_QHToChuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_QHToChuc.Rows.Count > 0 && dtgv_QHToChuc.SelectedRows != null)
            {
                DataGridViewRow r = dtgv_QHToChuc.SelectedRows[0];

                txt_TenToChuc.Text = r.Cells["ten_to_chuc"].Value.ToString();
                if (r.Cells["o_nuoc_ngoai"].Value.ToString() == "Nước ngoài")
                {
                    cb_NuocNgoai.Checked = true;
                }
                else
                {
                    cb_NuocNgoai.Checked = false;
                }
                txt_ChucDanh.Text = r.Cells["chuc_danh"].Value.ToString();
                txt_ChucVu.Text = r.Cells["chuc_vu"].Value.ToString();
                if (r.Cells["tu_thoi_gian"].Value.ToString() != "" && r.Cells["tu_thoi_gian"].Value.ToString() != DateTime.MinValue.ToString())
                {
                    dTP_TuThoiGian.Checked = true;
                    dTP_TuThoiGian.Value = Convert.ToDateTime(r.Cells["tu_thoi_gian"].Value);
                }
                else
                    dTP_TuThoiGian.Checked = false;

                if (r.Cells["den_thoi_gian"].Value.ToString() != "" && r.Cells["den_thoi_gian"].Value.ToString() != DateTime.MinValue.ToString())
                {
                    dTP_DenThoiGian.Checked = true;
                    dTP_DenThoiGian.Value = Convert.ToDateTime(r.Cells["den_thoi_gian"].Value);
                }
                else
                    dTP_DenThoiGian.Checked = false;

                txt_PhuongXa.Text = r.Cells["phuong_xa"].Value.ToString();
                txt_QuanHuyen.Text = r.Cells["quan_huyen"].Value.ToString();

                if (r.Cells["tinh_thanhpho"].Value.ToString() != "")
                {
                    comB_Tinh.SelectedValue = r.Cells["tinh_thanhpho"].Value;
                }
                else
                {
                    comB_Tinh.SelectedValue = -1;
                }

                if (r.Cells["quoc_gia"].Value.ToString() != "")
                {
                    comB_QuocGia.SelectedValue = r.Cells["quoc_gia"].Value;
                }
                else
                {
                    comB_QuocGia.SelectedValue = -1;
                }

            }
        }


        /// <summary>
        /// khi do full tinh vao combo, sau do chon 1 tinh, can phai exclude cac tinh o thuoc quoc gia do
        /// ==> loai bo nhung value tinh ra khoi combo
        /// </summary>
        /// <param name="quoc_gia_id"></param>
        /// <param name="SelectedValue">tinh mà ng dung da chon</param>
        private void ExcludeTinhData(int quoc_gia_id, int SelectedValue)
        {
            var dt = dtTinhTP.AsEnumerable().Where(a => a.Field<int>("quoc_gia_id") == quoc_gia_id);
            DataTable dt2 = dt.CopyToDataTable();
            if (dt2.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt2.NewRow();
                dr["ten_tinh_tp"] = "";
                dr["id"] = -1;
                dr["quoc_gia_id"] = -1;
                dt2.Rows.Add(dr);
            }

            // comb
            comB_Tinh.DataSource = dt2;
            comB_Tinh.DisplayMember = "ten_tinh_tp";
            comB_Tinh.ValueMember = "id";

            comB_Tinh.SelectedValue = SelectedValue;
        }

        private void lbl_XoaTienAn_Click(object sender, EventArgs e)
        {
            if (dtgv_TienAn.SelectedRows != null &&
                (MessageBox.Show("Xoá dòng dữ liệu về tiền án / tiền sự của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                DataGridViewRow r = dtgv_TienAn.SelectedRows[0];
                oCNVC_LSBiBat.ID = Convert.ToInt32(r.Cells["id"].Value);

                try
                {
                    oCNVC_LSBiBat.Delete();
                    // load lai dtgv_CMND
                    dtLSBiBat = oCNVC_LSBiBat.GetData();
                    dtgv_TienAn.DataSource = dtLSBiBat;
                    Setup_dtgv_TienAn();

                    MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xoá không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void lbl_XoaQH_Click(object sender, EventArgs e)
        {
            if (dtgv_QHToChuc.SelectedRows != null &&
                (MessageBox.Show("Xoá dòng dữ liệu về quan hệ tổ chức của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                DataGridViewRow r = dtgv_QHToChuc.SelectedRows[0];
                oCNVC_QuanHeToChuc.ID = Convert.ToInt32(r.Cells[6].Value);

                try
                {
                    oCNVC_QuanHeToChuc.Delete();
                    // load lai dtgv_CMND
                    dtQHToChuc = oCNVC_QuanHeToChuc.GetData();
                    dtgv_QHToChuc.DataSource = dtQHToChuc;
                    Setup_dtgv_QHToChuc();

                    MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xoá không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void Setup_dtgv_TienAn()
        {
            dtgv_TienAn.Columns["bi_bat_bi_tu"].HeaderText = "Bị bắt / bị tù";
            dtgv_TienAn.Columns["bi_bat_bi_tu"].Width = 150;

            dtgv_TienAn.Columns["ma_nv"].Visible = dtgv_TienAn.Columns["id"].Visible = false; // id va ma nv

            dtgv_TienAn.Columns["tai_noi"].HeaderText = "Tại nơi";
            dtgv_TienAn.Columns["tai_noi"].Width = 300;
            dtgv_TienAn.Columns["tu_thoi_gian"].HeaderText = "Từ ngày";
            dtgv_TienAn.Columns["tu_thoi_gian"].Width = 100;
            dtgv_TienAn.Columns["den_thoi_gian"].HeaderText = "Đến ngày";
            dtgv_TienAn.Columns["den_thoi_gian"].Width = 100;

            dtgv_TienAn.Columns["nguoi_khai_bao"].HeaderText = "Người khai báo";
            dtgv_TienAn.Columns["nguoi_khai_bao"].Width = 200;
            dtgv_TienAn.Columns["noi_dung"].HeaderText = "Nội dung";
            dtgv_TienAn.Columns["noi_dung"].Width = 350;


        }

        private void Setup_dtgv_QHToChuc()
        {
            dtgv_QHToChuc.Columns["ten_to_chuc"].HeaderText = "Tên tổ chức";
            dtgv_QHToChuc.Columns["ten_to_chuc"].Width = 250;

            dtgv_QHToChuc.Columns["id"].Visible = dtgv_QHToChuc.Columns["ma_nv"].Visible =
               dtgv_QHToChuc.Columns["tinh_thanhpho"].Visible = dtgv_QHToChuc.Columns["quoc_gia"].Visible = false; // id va ma nv

            dtgv_QHToChuc.Columns["o_nuoc_ngoai"].HeaderText = "Nước ngoài / trong nước";
            dtgv_QHToChuc.Columns["o_nuoc_ngoai"].Width = 250;
            dtgv_QHToChuc.Columns["chuc_danh"].HeaderText = "Chức danh";
            dtgv_QHToChuc.Columns["chuc_danh"].Width = 200;
            dtgv_QHToChuc.Columns["chuc_vu"].HeaderText = "Chức vụ";
            dtgv_QHToChuc.Columns["chuc_vu"].Width = 200;
            dtgv_QHToChuc.Columns["tu_thoi_gian"].HeaderText = "Từ thời gian";
            dtgv_QHToChuc.Columns["tu_thoi_gian"].Width = 150;

            dtgv_QHToChuc.Columns["den_thoi_gian"].HeaderText = "Đến thời gian";
            dtgv_QHToChuc.Columns["den_thoi_gian"].Width = 200;
            dtgv_QHToChuc.Columns["phuong_xa"].HeaderText = "Phường xã";
            dtgv_QHToChuc.Columns["phuong_xa"].Width = 200;
            dtgv_QHToChuc.Columns["quan_huyen"].HeaderText = "Quận huyện";
            dtgv_QHToChuc.Columns["quan_huyen"].Width = 150;
            dtgv_QHToChuc.Columns["ten_tinh_tp"].HeaderText = "Tỉnh / thành phố";
            dtgv_QHToChuc.Columns["ten_tinh_tp"].Width = 200;
            dtgv_QHToChuc.Columns["ten_quoc_gia"].HeaderText = "Quốc gia";
            dtgv_QHToChuc.Columns["ten_quoc_gia"].Width = 150;

        }

        private void ControlLSBiBat(bool Add)
        {
            if (Add)
            {
                lbl_SuaTienAn.Text = "Huỷ";
                lbl_ThemTienAn.Text = "Lưu";
                txt_TaiNoi.Enabled = txt_NguoiKhaiBao.Enabled = dTP_TuNgay.Enabled = dTP_DenNgay.Enabled
                    = comB_HinhThuc.Enabled = rTB_NoiDung.Enabled = true;
                dtgv_TienAn.Enabled = lbl_XoaTienAn.Enabled = false;
            }
            else
            {
                lbl_SuaTienAn.Text = "Sửa";
                lbl_ThemTienAn.Text = "Thêm";
                txt_TaiNoi.Enabled = txt_NguoiKhaiBao.Enabled = dTP_TuNgay.Enabled = dTP_DenNgay.Enabled
                    = comB_HinhThuc.Enabled = rTB_NoiDung.Enabled = false;
                dtgv_TienAn.Enabled = lbl_XoaTienAn.Enabled = true;

            }
        }

        private void ClearLSBiBatData()
        {
            txt_TaiNoi.Text = txt_NguoiKhaiBao.Text = rTB_NoiDung.Text = "";
            comB_HinhThuc.SelectedIndex = 0;
            dTP_TuNgay.Checked = dTP_DenNgay.Checked = false;
        }

        private void ControlQHToChuc(bool Add)
        {

            if (Add)
            {
                lbl_SuaQH.Text = "Huỷ";
                lbl_ThemQH.Text = "Lưu";
                txt_TenToChuc.Enabled = txt_ChucVu.Enabled = cb_NuocNgoai.Enabled = dTP_TuThoiGian.Enabled
                    = dTP_DenThoiGian.Enabled = txt_ChucDanh.Enabled = txt_PhuongXa.Enabled
                    = txt_QuanHuyen.Enabled = tableLP_Tinh.Enabled = tableLP_QuocGia.Enabled = true;
                dtgv_QHToChuc.Enabled = lbl_XoaQH.Enabled = false;
            }
            else
            {
                lbl_SuaQH.Text = "Sửa";
                lbl_ThemQH.Text = "Thêm";
                txt_TenToChuc.Enabled = txt_ChucVu.Enabled = cb_NuocNgoai.Enabled = dTP_TuThoiGian.Enabled
                    = dTP_DenThoiGian.Enabled = txt_ChucDanh.Enabled = txt_PhuongXa.Enabled
                    = txt_QuanHuyen.Enabled = tableLP_Tinh.Enabled = tableLP_QuocGia.Enabled = false;
                dtgv_QHToChuc.Enabled = lbl_XoaQH.Enabled = true;

            }
        }

        private void ClearQHToChucData()
        {
            txt_TenToChuc.Text = txt_ChucVu.Text = txt_QuanHuyen.Text = txt_PhuongXa.Text
                = txt_ChucDanh.Text = "";
            comB_Tinh.SelectedIndex = comB_QuocGia.SelectedIndex = 0;
            dTP_DenThoiGian.Checked = dTP_TuThoiGian.Checked = false;
        }
    }
}
