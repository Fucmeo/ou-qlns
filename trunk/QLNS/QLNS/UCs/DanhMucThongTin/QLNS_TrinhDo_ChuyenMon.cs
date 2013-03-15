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
    public partial class QLNS_TrinhDo_ChuyenMon : UserControl
    {
        public CNVC_TrinhDoPhoThong oCNVC_TrinhDoPhoThong;
        public CNVC_ChuyenMonTongQuat oCNVC_ChuyenMonTongQuat;
        public DataTable dtTrinhDo, dtChuyenMon, dtTinhTP, dtMoHinh;
        Business.TinhTP oTinhTP;
        Business.MoHinhDaoTao oMoHinhDaoTao;

        bool bAddTrinhDoFlag = false;

        public static int nNewTinhTPID = 0;     // ID cua tinh thanh pho moi them vao

        public QLNS_TrinhDo_ChuyenMon()
        {
            InitializeComponent();
            oCNVC_ChuyenMonTongQuat = new CNVC_ChuyenMonTongQuat();
            oCNVC_TrinhDoPhoThong = new CNVC_TrinhDoPhoThong();
            dtChuyenMon = new DataTable();
            dtTrinhDo = new DataTable();
            dtTinhTP = new DataTable();
            dtMoHinh = new DataTable();
            oTinhTP = new Business.TinhTP();
            oMoHinhDaoTao = new Business.MoHinhDaoTao();
        }

        public void GetTrinhDoInfo(string m_MaNV)
        {
            oCNVC_TrinhDoPhoThong.MaNV = m_MaNV;
            dtTrinhDo = oCNVC_TrinhDoPhoThong.GetData();
        }

        public void GetChuyenMonInfo(string m_MaNV)
        {
            oCNVC_ChuyenMonTongQuat.MaNV = m_MaNV;
            dtChuyenMon = oCNVC_ChuyenMonTongQuat.GetData();
        }

        private void QLNS_TrinhDo_ChuyenMon_Load(object sender, EventArgs e)
        {
            LoadTinhData();
            LoadMoHinhData();
            comB_CapDo.SelectedIndex = 0;
        }

        private void LoadTinhData()
        {
            dtTinhTP = oTinhTP.GetData();

            DataTable dt = dtTinhTP.Copy();

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

        private void LoadMoHinhData()
        {
            dtMoHinh = oMoHinhDaoTao.GetData();

            DataTable dt = dtMoHinh.Copy();

            if (dt.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt.NewRow();
                dr["ten_mo_hinh"] = "";
                dr["id"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }

            // comb
            comB_MoHinhDaoTao.DataSource = dt;
            comB_MoHinhDaoTao.DisplayMember = "ten_mo_hinh";
            comB_MoHinhDaoTao.ValueMember = "id";
        }

        public void FillInfo()
        {

            if (dtChuyenMon.Rows.Count > 0)
            {
                txt_NgoaiNgu.Text = Convert.ToString(dtChuyenMon.Rows[0]["ngoai_ngu"]);
                txt_TinHoc.Text = Convert.ToString(dtChuyenMon.Rows[0]["tin_hoc"]);
                txt_SoTruong.Text = Convert.ToString(dtChuyenMon.Rows[0]["so_truong_cong_tac"]);
                txt_TrinhDoChuyenMon.Text = Convert.ToString(dtChuyenMon.Rows[0]["trinh_do_chuyen_mon"]);

                if (dtChuyenMon.Rows[0]["mo_hinh_dao_tao_id"].ToString() != "")
                {
                    comB_Tinh.SelectedValue = Convert.ToInt32(dtChuyenMon.Rows[0]["mo_hinh_dao_tao_id"]);
                }
                else
                {
                    comB_Tinh.SelectedValue = -1;
                }
            }

            if (dtTrinhDo.Rows.Count > 0)
            {
                DataTable dt = dtTrinhDo.Copy();
                dtgv_TrinhDo.Columns.Clear();
                dtgv_TrinhDo.DataSource = dt;
                Setup_dtgv_TrinhDo();

            }
        }

        private void Setup_dtgv_TrinhDo()
        {
            dtgv_TrinhDo.Columns["id"].Visible = dtgv_TrinhDo.Columns["ma_nv"].Visible =
                dtgv_TrinhDo.Columns["tinh_thanhpho_id"].Visible = false; // id , id tinh va ma nv

            dtgv_TrinhDo.Columns["cap_hoc"].HeaderText = "Cấp học";
            dtgv_TrinhDo.Columns["cap_hoc"].Width = 150;
            dtgv_TrinhDo.Columns["ten_truong"].HeaderText = "Tên trường";
            dtgv_TrinhDo.Columns["ten_truong"].Width = 300;
            dtgv_TrinhDo.Columns["phuong_xa"].HeaderText = "Phường xã";
            dtgv_TrinhDo.Columns["phuong_xa"].Width = 100;
            dtgv_TrinhDo.Columns["quan_huyen"].HeaderText = "Quận huyện";
            dtgv_TrinhDo.Columns["quan_huyen"].Width = 100;
            dtgv_TrinhDo.Columns["tinh_thanhpho"].HeaderText = "Tỉnh / TP";
            dtgv_TrinhDo.Columns["tinh_thanhpho"].Width = 150;
            dtgv_TrinhDo.Columns["nam_hoc"].HeaderText = "Năm học";
            dtgv_TrinhDo.Columns["nam_hoc"].Width = 200;

           
        }

        private void Init_dtgv_TrinhDo()
        {
            dtgv_TrinhDo.Columns.Clear();
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã NV";
            col.Name = "ma_nv";
            col.Width = 200;
            col.Visible = false;
            dtgv_TrinhDo.Columns.Add(col);

            col.HeaderText = "Cấp học";
            col.Name = "cap_hoc";
            col.Width = 150;
            dtgv_TrinhDo.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên trường";
            col.Name = "ten_truong";
            col.Width = 300;
            dtgv_TrinhDo.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Phường xã";
            col.Name = "phuong_xa";
            col.Width = 100;
            dtgv_TrinhDo.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Quận huyện";
            col.Name = "quan_huyen";
            col.Width = 100;
            dtgv_TrinhDo.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tỉnh / TP";
            col.Name = "tinh_thanhpho";
            col.Width = 250;
            dtgv_TrinhDo.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tỉnh ID";
            col.Name = "tinh_thanhpho_id";
            col.Width = 10;
            col.Visible = false;
            dtgv_TrinhDo.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Năm học";
            col.Name = "nam_hoc";
            col.Width = 200;
            dtgv_TrinhDo.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Id";
            col.Name = "id";
            col.Width = 10;
            col.Visible = false;
            dtgv_TrinhDo.Columns.Add(col);

        }

        private void dtgv_TrinhDo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_TrinhDo.Rows.Count > 0 && dtgv_TrinhDo.SelectedRows != null)
            {
                DataGridViewRow r = dtgv_TrinhDo.SelectedRows[0];

                txt_NamHoc.Text = r.Cells["nam_hoc"].Value.ToString();
                txt_TenTruong.Text = r.Cells["ten_truong"].Value.ToString();
                txt_PhuongXa.Text = r.Cells["phuong_xa"].Value.ToString();
                txt_QuanHuyen.Text = r.Cells["quan_huyen"].Value.ToString();

                comB_CapDo.Text = r.Cells["cap_hoc"].Value.ToString();

                if (r.Cells["tinh_thanhpho_id"].Value.ToString() != "")
                {
                    comB_Tinh.SelectedValue = Convert.ToInt32(r.Cells["tinh_thanhpho_id"].Value);

                }
                else
                {
                    comB_Tinh.SelectedValue = -1;
                }
                

            }
        }

        private void lbl_ThemTinh_Click(object sender, EventArgs e)
        {
            #region MyRegion

            if (lbl_ThemMoHinh.Text == "Thêm")
            {
                bAddTrinhDoFlag = true;
                ControlTrinhDo(true);
                ClearTrinhDoData();
            }
            else        // LƯU
            {
                if (VerifyTrinhDoData())
                {
                    if (bAddTrinhDoFlag)   // Thêm mới
                    {
                        if ((MessageBox.Show("Thêm thông tin về CMND / Hộ chiếu của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            try
                            {
                                GetTrinhDoInputData();
                                oCNVC_TrinhDoPhoThong.Add();

                                // load lai dtgv_CMND
                                dtTrinhDo = oCNVC_TrinhDoPhoThong.GetData();
                                dtgv_TrinhDo.DataSource = dtTrinhDo;
                                Setup_dtgv_TrinhDo();

                                MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin CMND/ Hộ chiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else        // Sửa
                    {
                        if ((MessageBox.Show("Sửa thông tin về CMND / Hộ chiếu của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            try
                            {
                                GetTrinhDoInputData();
                                oCNVC_TrinhDoPhoThong.Update();

                                // load lai dtgv_CMND
                                dtTrinhDo = oCNVC_TrinhDoPhoThong.GetData();
                                dtgv_TrinhDo.DataSource = dtTrinhDo;
                                Setup_dtgv_TrinhDo();

                                MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin CMND/ Hộ chiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }



                    ControlTrinhDo(false);
                    ClearTrinhDoData();
                }
                else
                {
                    MessageBox.Show("Thông tin CMND / Hộ chiếu không phù hợp, xin vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion
        }

        private void lbl_ThemMoHinh_Click(object sender, EventArgs e)
        {

        }

        private void lbl_ThemTrinhDoPT_Click(object sender, EventArgs e)
        {

        }

        private void lbl_SuaTrinhDoPT_Click(object sender, EventArgs e)
        {
            if (lbl_SuaTrinhDoPT.Text == "Sửa")
            {
                if (dtgv_TrinhDo.Rows.Count > 0 && dtgv_TrinhDo.SelectedRows != null)
                {
                    comB_CapDo.Focus();
                    bAddTrinhDoFlag = false;
                    ControlTrinhDo(true);
                }
                else
                {
                    MessageBox.Show("Chưa có thông tin về trình độ phổ thông của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else        // HUỶ
            {
                bAddTrinhDoFlag = false;
                ControlTrinhDo(false);
                ClearTrinhDoData();

            }
        }

        private void lbl_XoaTrinhDoPT_Click(object sender, EventArgs e)
        {
            if (dtgv_TrinhDo.SelectedRows != null &&
                (MessageBox.Show("Xoá dòng dữ liệu CMND / Hộ chiếu của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                DataGridViewRow r = dtgv_TrinhDo.SelectedRows[0];
                oCNVC_TrinhDoPhoThong.ID = Convert.ToInt32(r.Cells[6].Value);

                try
                {
                    oCNVC_TrinhDoPhoThong.Delete();
                    // load lai dtgv_CMND
                    dtTrinhDo = oCNVC_TrinhDoPhoThong.GetData();
                    dtgv_TrinhDo.DataSource = dtTrinhDo;
                    Setup_dtgv_TrinhDo();

                    MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xoá không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void btn_LuuChuyenMon_Click(object sender, EventArgs e)
        {

        }

        private void ControlTrinhDo(bool Add)
        {

            if (Add)
            {
                lbl_SuaTrinhDoPT.Text = "Huỷ";
                lbl_ThemMoHinh.Text = "Lưu";
                txt_TenTruong.Enabled = txt_PhuongXa.Enabled = txt_QuanHuyen.Enabled 
                    = txt_NamHoc.Enabled = comB_CapDo.Enabled = comB_Tinh.Enabled = true;
                dtgv_TrinhDo.Enabled = lbl_XoaTrinhDoPT.Enabled = false;
            }
            else
            {
                lbl_SuaTrinhDoPT.Text = "Sửa";
                lbl_ThemMoHinh.Text = "Thêm";
                txt_TenTruong.Enabled = txt_PhuongXa.Enabled = txt_QuanHuyen.Enabled
                    = txt_NamHoc.Enabled = comB_CapDo.Enabled = comB_Tinh.Enabled = false;
                dtgv_TrinhDo.Enabled = lbl_XoaTrinhDoPT.Enabled  = true;

            }
        }

        private bool VerifyTrinhDoData()
        {
            if (string.IsNullOrWhiteSpace(txt_TenTruong.Text) || Convert.ToInt32(comB_CapDo.SelectedValue) <= 0)
            {
                return false;
            }

            return true;
        }

        private void GetTrinhDoInputData()
        {
            oCNVC_TrinhDoPhoThong.MaNV = Program.selected_ma_nv;
            oCNVC_TrinhDoPhoThong.ID = Convert.ToInt32(dtgv_TrinhDo.SelectedRows[0].Cells["id"].Value);
            oCNVC_TrinhDoPhoThong.CapHoc = comB_CapDo.SelectedIndex == 0 ? 1 : comB_CapDo.SelectedIndex == 1 ? 2 : 3;
            oCNVC_TrinhDoPhoThong.TenTruong = txt_TenTruong.Text;
            oCNVC_TrinhDoPhoThong.Phuong = txt_PhuongXa.Text;
            oCNVC_TrinhDoPhoThong.Quan = txt_QuanHuyen.Text;
            oCNVC_TrinhDoPhoThong.NamHoc = txt_NamHoc.Text;

            if (Convert.ToInt32(comB_Tinh.SelectedValue) != -1)
            {
                oCNVC_TrinhDoPhoThong.Tinh = Convert.ToInt32(comB_Tinh.SelectedValue);
            }
            else
            {
                oCNVC_TrinhDoPhoThong.Tinh = null;
            }
        }

        private void ClearTrinhDoData()
        {
            txt_TenTruong.Text = txt_PhuongXa.Text = txt_QuanHuyen.Text
                    = txt_NamHoc.Text = "";
            comB_CapDo.SelectedIndex = comB_Tinh.SelectedIndex = 0;
        }

    }
}
