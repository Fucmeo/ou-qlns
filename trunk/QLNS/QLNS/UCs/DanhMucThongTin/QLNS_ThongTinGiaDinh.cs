using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;

namespace QLNS.UCs.DanhMucThongTin
{
    public partial class QLNS_ThongTinGiaDinh : UserControl
    {
        bool bAddFlag;
        public Business.CNVC.CNVC_QHGiaDinh oQHeGiaDinh;
        Business.TinhTP oTinhTP;
        Business.QuocGia oQuocGia;
        public DataTable dtDSQHeGiaDinh;
         DataTable dtDSTinhTP;
         DataTable dtDSQuocGia;

        //string m_ma_nv = "";

        public QLNS_ThongTinGiaDinh()
        {
            InitializeComponent();
            oQHeGiaDinh = new Business.CNVC.CNVC_QHGiaDinh();
            oTinhTP = new TinhTP();
            oQuocGia = new QuocGia();
            dtDSQHeGiaDinh = new DataTable();
        }

        //public QLNS_ThongTinGiaDinh(string p_ma_nv)
        //{
        //    InitializeComponent();
        //    oQHeGiaDinh = new Business.CNVC.CNVC_QHGiaDinh();
        //    oTinhTP = new TinhTP();
        //    oQuocGia = new QuocGia();
        //    dtDSQHeGiaDinh = new DataTable();

        //    m_ma_nv = p_ma_nv;
        //}

        private void QLNS_ThongTinGiaDinh_Load(object sender, EventArgs e)
        {
            dtDSTinhTP = oTinhTP.GetData();
            LoadDataCboTinhTP(dtDSTinhTP);

            dtDSQuocGia = oQuocGia.GetData();
            LoadDataCboQuocGia();
        }

        public void GetData(string p_ma_nv)
        {
            oQHeGiaDinh.MaNV = p_ma_nv;
            dtDSQHeGiaDinh = oQHeGiaDinh.GetData();
            if (dtDSQHeGiaDinh != null && dtDSQHeGiaDinh.Rows.Count > 0)
            {
                PrepareDataSource();
                EditDtgInterface();
            }
        }

        

        #region Private Methods

        #region Tinh_Tp - Quoc Gia
        private void LoadDataCboTinhTP(DataTable p_dtDSTinhTP)
        {
            comB_Tinh.DataSource = p_dtDSTinhTP;
            comB_Tinh.DisplayMember = "ten_tinh_tp";
            comB_Tinh.ValueMember = "id";
        }

        private void LoadDataCboQuocGia()
        {
            comB_QuocGia.DataSource = dtDSQuocGia;
            comB_QuocGia.DisplayMember = "ten_quoc_gia";
            comB_QuocGia.ValueMember = "id";
        }

        private void comB_QuocGia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int v = Convert.ToInt32(comB_QuocGia.SelectedValue);
            DataTable dt = new DataTable();

            if (v == -1)
            {
                LoadDataCboTinhTP(dtDSTinhTP);
                comB_Tinh.SelectedValue = -1;
            }
            else
            {
                if (dtDSTinhTP.AsEnumerable().Where(a => a.Field<int>("quoc_gia_id") == v).Count() > 0)
                {
                    dt = dtDSTinhTP.AsEnumerable().Where(a => a.Field<int>("quoc_gia_id") == v).CopyToDataTable();

                    DataRow dr = dt.NewRow();
                    dr["ten_tinh_tp"] = "";
                    dr["id"] = -1;
                    dr["quoc_gia_id"] = -1;
                    dt.Rows.InsertAt(dr, 0);
                }

                LoadDataCboTinhTP(dt);
            }
        }

        private void comB_Tinh_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int v = Convert.ToInt16(comB_Tinh.SelectedValue);

            if (v != -1)
            {
                var ids = from c in dtDSTinhTP.AsEnumerable()
                          where c.Field<int>("id") == v
                          select c.Field<int>("quoc_gia_id");

                int quoc_gia_id = ids.ElementAt<int>(0);

                comB_QuocGia.SelectedValue = quoc_gia_id;
            }
        }

        #endregion

        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtDSQHeGiaDinh;
            dtgv_QuanHeGiaDinh.DataSource = bs;
            //lbl_SoLoaiHD.Text = dtgv_DSLoaiHD.Rows.Count.ToString();
            if (dtDSQHeGiaDinh != null && dtDSQHeGiaDinh.Rows.Count > 0)
            {
                lbl_Sua.Visible = lbl_Xoa.Visible = true;
            }
        }

        private void EditDtgInterface()
        {
            dtgv_QuanHeGiaDinh.Columns["moi_quan_he"].HeaderText = "Mối quan hệ";
            dtgv_QuanHeGiaDinh.Columns["than_nhan_nuoc_ngoai"].HeaderText = "Thân nhân nước ngoài";
            dtgv_QuanHeGiaDinh.Columns["ho"].HeaderText = "Họ";
            dtgv_QuanHeGiaDinh.Columns["ten"].HeaderText = "Tên";
            dtgv_QuanHeGiaDinh.Columns["nam_sinh"].HeaderText = "Năm sinh";
            dtgv_QuanHeGiaDinh.Columns["que_quan"].HeaderText = "Quê quán";
            dtgv_QuanHeGiaDinh.Columns["nghe_nghiep"].HeaderText = "Nghề nghiệp";
            dtgv_QuanHeGiaDinh.Columns["chuc_danh_chuc_vu"].HeaderText = "Chức danh/Chức vụ";
            dtgv_QuanHeGiaDinh.Columns["don_vi_cong_tac"].HeaderText = "Đơn vị công tác";
            dtgv_QuanHeGiaDinh.Columns["hoc_tap"].HeaderText = "Học tập";
            //dtgv_QuanHeGiaDinh.Columns["so_nha"].HeaderText = "Số nhà";
            //dtgv_QuanHeGiaDinh.Columns["duong"].HeaderText = "Đường";
            //dtgv_QuanHeGiaDinh.Columns["phuong_xa"].HeaderText = "Phường/Xã";
            //dtgv_QuanHeGiaDinh.Columns["quan_huyen"].HeaderText = "Quận/Huyện";
            //dtgv_QuanHeGiaDinh.Columns["ten_tinh_tp"].HeaderText = "Tỉnh/Thành Phố";
            //dtgv_QuanHeGiaDinh.Columns["ten_quoc_gia"].HeaderText = "Quốc gia";


            dtgv_QuanHeGiaDinh.Columns["id"].Visible = false;
            dtgv_QuanHeGiaDinh.Columns["ma_nv"].Visible = false;
            dtgv_QuanHeGiaDinh.Columns["tinh_thanhpho"].Visible = false;
            dtgv_QuanHeGiaDinh.Columns["quoc_gia"].Visible = false;
            dtgv_QuanHeGiaDinh.Columns["thanh_vien_to_chuc_ctr_xh"].Visible = false;
            dtgv_QuanHeGiaDinh.Columns["ghi_chu"].Visible = false;

            dtgv_QuanHeGiaDinh.Columns["so_nha"].Visible = false;
            dtgv_QuanHeGiaDinh.Columns["duong"].Visible = false;
            dtgv_QuanHeGiaDinh.Columns["phuong_xa"].Visible = false;
            dtgv_QuanHeGiaDinh.Columns["quan_huyen"].Visible = false;
            dtgv_QuanHeGiaDinh.Columns["ten_tinh_tp"].Visible = false;
            dtgv_QuanHeGiaDinh.Columns["ten_quoc_gia"].Visible = false;
            dtgv_QuanHeGiaDinh.Columns["is_dang_vien"].Visible = false;
        }

        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                string moi_quan_he = row.Cells["moi_quan_he"].Value.ToString();
                comB_MoiQH.Text = moi_quan_he;

                if (row.Cells["than_nhan_nuoc_ngoai"].Value.ToString() != "")
                    cb_ThanNhanNuocNgoai.Checked = Convert.ToBoolean(row.Cells["than_nhan_nuoc_ngoai"].Value.ToString());
                txt_Ho.Text = row.Cells["ho"].Value.ToString();
                txt_Ten.Text = row.Cells["ten"].Value.ToString();
                txt_NamSinh.Text = row.Cells["nam_sinh"].Value.ToString();
                txt_QueQuan.Text = row.Cells["que_quan"].Value.ToString();
                txt_NgheNghiep.Text = row.Cells["nghe_nghiep"].Value.ToString();
                txt_ChucDanh.Text = row.Cells["chuc_danh_chuc_vu"].Value.ToString();
                txt_DVCongTac.Text = row.Cells["don_vi_cong_tac"].Value.ToString();
                txt_HocTap.Text = row.Cells["hoc_tap"].Value.ToString();
                rTB_ThanhVienToChuc.Text = row.Cells["thanh_vien_to_chuc_ctr_xh"].Value.ToString();
                rTB_GhiChu.Text = row.Cells["ghi_chu"].Value.ToString();

                txt_SoNha.Text = row.Cells["so_nha"].Value.ToString();
                txt_Duong.Text = row.Cells["duong"].Value.ToString();
                txt_Phuong.Text = row.Cells["phuong_xa"].Value.ToString();
                txt_Quan.Text = row.Cells["quan_huyen"].Value.ToString();
                if (row.Cells["tinh_thanhpho"].Value.ToString() != "")
                    comB_Tinh.SelectedValue = Convert.ToInt32(row.Cells["tinh_thanhpho"].Value.ToString());
                if (row.Cells["quoc_gia"].Value.ToString() != "")
                    comB_QuocGia.SelectedValue = Convert.ToInt32(row.Cells["quoc_gia"].Value.ToString());

                if (row.Cells["is_dang_vien"].Value.ToString() != "")
                    cb_LaDangVien.Checked = Convert.ToBoolean(row.Cells["is_dang_vien"].Value.ToString());
            }
        }

        private void RefreshDataSource()
        {
            Business.CNVC.CNVC_QHGiaDinh qhegiadinh = new Business.CNVC.CNVC_QHGiaDinh();
            qhegiadinh.MaNV = Program.selected_ma_nv;
            dtDSQHeGiaDinh = qhegiadinh.GetData();
            PrepareDataSource();
        }

        private void ResetInterface(bool init)
        {
            if (init)
            {
                //lbl_Them.Visible = lbl_Xoa.Visible = lbl_Sua.Visible = true;
                //btn_Huy.Visible = 
                comB_MoiQH.Enabled = cb_ThanNhanNuocNgoai.Enabled = cb_LaDangVien.Enabled = txt_Ho.Enabled = txt_Ten.Enabled = txt_NamSinh.Enabled =
                    txt_QueQuan.Enabled = txt_NgheNghiep.Enabled = txt_ChucDanh.Enabled = txt_DVCongTac.Enabled = 
                    txt_HocTap.Enabled = rTB_ThanhVienToChuc.Enabled = rTB_GhiChu.Enabled = txt_SoNha.Enabled = txt_Duong.Enabled = 
                    txt_Phuong.Enabled = txt_Quan.Enabled = comB_Tinh.Enabled = comB_QuocGia.Enabled = false;

                dtgv_QuanHeGiaDinh.Enabled = true;
                if (dtgv_QuanHeGiaDinh.CurrentRow != null)
                {
                    DisplayInfo(dtgv_QuanHeGiaDinh.CurrentRow);
                }

                lbl_Them.Text = "Thêm";
                lbl_Sua.Text = "Sửa";
                lbl_Xoa.Visible = true;
            }
            else
            {
                //lbl_Them.Visible = lbl_Xoa.Visible = lbl_Sua.Visible = false;
                //btn_Huy.Visible = 
                comB_MoiQH.Enabled = cb_ThanNhanNuocNgoai.Enabled = cb_LaDangVien.Enabled = txt_Ho.Enabled = txt_Ten.Enabled = txt_NamSinh.Enabled =
                    txt_QueQuan.Enabled = txt_NgheNghiep.Enabled = txt_ChucDanh.Enabled = txt_DVCongTac.Enabled =
                    txt_HocTap.Enabled = rTB_ThanhVienToChuc.Enabled = rTB_GhiChu.Enabled = txt_SoNha.Enabled = txt_Duong.Enabled =
                    txt_Phuong.Enabled = txt_Quan.Enabled = comB_Tinh.Enabled = comB_QuocGia.Enabled = true;
                dtgv_QuanHeGiaDinh.Enabled = false;

                if (bAddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_Ho.Text = txt_Ten.Text = txt_NamSinh.Text = txt_QueQuan.Text = txt_NgheNghiep.Text = txt_ChucDanh.Text = txt_DVCongTac.Text =
                    txt_HocTap.Text = rTB_ThanhVienToChuc.Text = rTB_GhiChu.Text = txt_SoNha.Text = txt_Duong.Text =
                    txt_Phuong.Text = txt_Quan.Text = "";

                    cb_ThanNhanNuocNgoai.Checked = cb_LaDangVien.Checked = false;
                }

                lbl_Them.Text = "Lưu";
                lbl_Sua.Text = "Hủy";
                lbl_Xoa.Visible = false;
            }
        }

        #endregion

        private void dtgv_QuanHeGiaDinh_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_QuanHeGiaDinh.CurrentRow != null)
            {
                DisplayInfo(dtgv_QuanHeGiaDinh.CurrentRow);
            }
        }

        private void lbl_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgv_QuanHeGiaDinh.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá thông tin quan hệ này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oQHeGiaDinh.ID = Convert.ToInt16(dtgv_QuanHeGiaDinh.CurrentRow.Cells["id"].Value.ToString());
                        if (oQHeGiaDinh.Delete())
                        {
                            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RefreshDataSource();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void lbl_Them_Click(object sender, EventArgs e)
        {
            if (Program.selected_ma_nv != "")
            {

                if (lbl_Them.Text == "Thêm")
                {
                    bAddFlag = true;
                    ResetInterface(false);
                }
                else //chức năng Lưu
                {
                    if (!string.IsNullOrWhiteSpace(txt_Ten.Text))
                    {
                        oQHeGiaDinh.MaNV = Program.selected_ma_nv;
                        oQHeGiaDinh.MoiQuanHe = comB_MoiQH.Text;
                        oQHeGiaDinh.ThanNhanNuocNgoai = cb_ThanNhanNuocNgoai.Checked;
                        oQHeGiaDinh.Ho = txt_Ho.Text;
                        oQHeGiaDinh.Ten = txt_Ten.Text;
                        oQHeGiaDinh.NamSinh = txt_NamSinh.Text;
                        oQHeGiaDinh.QueQuan = txt_QueQuan.Text;
                        oQHeGiaDinh.NgheNghiep = txt_NgheNghiep.Text;
                        oQHeGiaDinh.ChucDanh = txt_ChucDanh.Text;
                        oQHeGiaDinh.DVCongTac = txt_DVCongTac.Text;
                        oQHeGiaDinh.HocTap = txt_HocTap.Text;
                        oQHeGiaDinh.ThanhVienToChucXH = rTB_ThanhVienToChuc.Text;
                        oQHeGiaDinh.GhiChu = rTB_GhiChu.Text;
                        oQHeGiaDinh.So_Nha = txt_SoNha.Text;
                        oQHeGiaDinh.Duong = txt_Duong.Text;
                        oQHeGiaDinh.Phuong_Xa = txt_Phuong.Text;
                        oQHeGiaDinh.Quan_Huyen = txt_Quan.Text;
                        if (comB_Tinh.Text != "")
                            oQHeGiaDinh.Tinh_ThanhPho = Convert.ToInt32(comB_Tinh.SelectedValue);
                        if (comB_QuocGia.Text != "")
                            oQHeGiaDinh.Quoc_Gia = Convert.ToInt32(comB_QuocGia.SelectedValue);
                        oQHeGiaDinh.Is_Dang_vien = cb_LaDangVien.Checked;

                        #region thao tac them

                        if (bAddFlag)
                        {
                            if (MessageBox.Show("Bạn thực sự muốn thêm thông tin quan hệ gia đình này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                try
                                {
                                    if (oQHeGiaDinh.Add())
                                    {
                                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                    RefreshDataSource();
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
                        else
                        {
                            if (MessageBox.Show("Bạn thực sự muốn thông tin quan hệ gia đình này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                oQHeGiaDinh.ID = Convert.ToInt32(dtgv_QuanHeGiaDinh.CurrentRow.Cells["id"].Value.ToString());
                                try
                                {
                                    if (oQHeGiaDinh.Update())
                                    {
                                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                    RefreshDataSource();
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
                    else
                        MessageBox.Show("Vui lòng cung cấp đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lbl_Sua_Click(object sender, EventArgs e)
        {
            if (Program.selected_ma_nv != "")
            {

                if (lbl_Sua.Text == "Sửa")
                {
                    bAddFlag = false;
                    ResetInterface(false);
                }
                else if (lbl_Sua.Text == "Hủy")
                {
                    ResetInterface(true);
                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



    }
}
