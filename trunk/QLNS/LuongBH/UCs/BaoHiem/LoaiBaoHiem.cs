using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;

namespace LuongBH.UCs.BaoHiem
{
    public partial class LoaiBaoHiem : UserControl
    {
        Business.Luong.BaoHiem oBaoHiem;
        DataTable dtDSLoaiBaoHiem;
        DataTable dtDSBaoHiem_Detail;

        bool bIsAddNew = false;

        bool bAddLoaiBH = false;
        bool bAddDetailBH = false;

        public LoaiBaoHiem()
        {
            InitializeComponent();
            oBaoHiem = new Business.Luong.BaoHiem();
        }

        private void LoaiBaoHiem_Load(object sender, EventArgs e)
        {
            ResetInterface_LoaiBH(false);
            Fill_Data();

        }

        #region Private Methods
        private void Fill_Data()
        {
            Fill_Listbox_LoaiBH();
            Fill_Dtg_LoaiBH_Detail();
        }

        private void Fill_Listbox_LoaiBH()
        {
            dtDSLoaiBaoHiem = oBaoHiem.GetList_LoaiBH();
            if (dtDSLoaiBaoHiem != null)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dtDSLoaiBaoHiem;
                lsb_DanhSach.DataSource = bs;
                lsb_DanhSach.DisplayMember = "ten_loai";
                lsb_DanhSach.ValueMember = "id";
            }
        }

        private void Fill_Dtg_LoaiBH_Detail()
        {
            dtDSBaoHiem_Detail = oBaoHiem.GetList_LoaiBH_Detail();
            if (dtDSBaoHiem_Detail != null)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dtDSBaoHiem_Detail;
                dtgv_BaoHiem.DataSource = bs;
                EditDtgInterface();
            }
        }

        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtgv_BaoHiem.Columns["ten_loai"].HeaderText = "Loại bảo hiêm";
            dtgv_BaoHiem.Columns["nhan_vien_dong"].HeaderText = "% Nhân viên đóng";
            dtgv_BaoHiem.Columns["nha_truong_dong"].HeaderText = "% Nhà trường đóng";
            dtgv_BaoHiem.Columns["tu_thoi_gian"].HeaderText = "Từ thời gian";
            dtgv_BaoHiem.Columns["den_thoi_gian"].HeaderText = "Đến thời gian";

            // An dtgv_BaoHiem ID
            dtgv_BaoHiem.Columns["id"].Visible = false;
            dtgv_BaoHiem.Columns["loai_bh_id"].Visible = false;
            dtgv_BaoHiem.Columns["ghi_chu"].Visible = false;
        }

        private void ResetInterface_LoaiBH(bool init)
        {
            if (init)
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = false;
                btn_Huy.Visible = btn_Luu.Visible = true;
                txt_LoaiBH.Enabled = true;
                nup_NhanVienDong.Enabled = nup_NhaTruongDong.Enabled = dtp_DenNgay.Enabled = dTP_TuNgay.Enabled = rTB_GhiChu.Enabled = false;
                lsb_DanhSach.Enabled = dtgv_BaoHiem.Enabled = false;
            }
            else
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = true;
                btn_Huy.Visible = btn_Luu.Visible = false;
                txt_LoaiBH.Enabled = false;
                nup_NhanVienDong.Enabled = nup_NhaTruongDong.Enabled = dtp_DenNgay.Enabled = dTP_TuNgay.Enabled = rTB_GhiChu.Enabled = false;
                lsb_DanhSach.Enabled = dtgv_BaoHiem.Enabled = true;
            }
        }

        private void ResetInterface_LoaiBH_Detail(bool init)
        {
            if (init)
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = false;
                btn_Huy.Visible = btn_Luu.Visible = true;
                nup_NhanVienDong.Enabled = nup_NhaTruongDong.Enabled = dtp_DenNgay.Enabled = dTP_TuNgay.Enabled = rTB_GhiChu.Enabled = true;
                txt_LoaiBH.Enabled = false;
                lsb_DanhSach.Enabled = dtgv_BaoHiem.Enabled = false;
            }
            else
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = true;
                btn_Huy.Visible = btn_Luu.Visible = false;
                nup_NhanVienDong.Enabled = nup_NhaTruongDong.Enabled = dtp_DenNgay.Enabled = dTP_TuNgay.Enabled = rTB_GhiChu.Enabled = false;
                txt_LoaiBH.Enabled = false;
                lsb_DanhSach.Enabled = dtgv_BaoHiem.Enabled = true;
            }
        }



        #endregion

        private void lsb_DanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_LoaiBH.Text = lsb_DanhSach.Text;
        }

        private void dtgv_BaoHiem_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgv_BaoHiem.SelectedRows.Count > 0)
                {
                    DataGridViewRow r = dtgv_BaoHiem.SelectedRows[0];
                    nup_NhanVienDong.Value = Convert.ToDecimal(r.Cells["nhan_vien_dong"].Value.ToString());
                    nup_NhaTruongDong.Value = Convert.ToDecimal(r.Cells["nha_truong_dong"].Value.ToString());

                    //string test = r.Cells["tu_thoi_gian"].Value();
                    //DateTime.ParseExact(r.Cells["tu_thoi_gian"].Value.ToString(), "dd/MM/yyyy", null);

                    dTP_TuNgay.Value = Convert.ToDateTime(r.Cells["tu_thoi_gian"].Value);

                    try
                    {
                        if (r.Cells["den_thoi_gian"].Value.ToString() != "")
                        {
                            dtp_DenNgay.Checked = true;
                            dtp_DenNgay.Value = Convert.ToDateTime(r.Cells["den_thoi_gian"].Value);
                        }
                        else
                        { dtp_DenNgay.Checked = false; }
                    }
                    catch
                    {
                        dtp_DenNgay.Checked = false;
                    }

                    rTB_GhiChu.Text = Convert.ToString(r.Cells["ghi_chu"].Value);

                }

            }
            catch (Exception)
            {

            }
        }

        private void TSMI_ThemLoaiBH_Click(object sender, EventArgs e)
        {
            bIsAddNew = true;
            bAddLoaiBH = true;
            bAddDetailBH = false;

            ResetInterface_LoaiBH(true);
            txt_LoaiBH.Text = "";
        }

        private void TSMI_ThemChiTietBH_Click(object sender, EventArgs e)
        {
            bIsAddNew = true;
            bAddLoaiBH = false;
            bAddDetailBH = true;

            ResetInterface_LoaiBH_Detail(true);
            rTB_GhiChu.Text = "";

            dTP_TuNgay.Value = DateTime.Now;
            dtp_DenNgay.Checked = false;

            nup_NhanVienDong.Value = nup_NhaTruongDong.Value = 1;
        }
        
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ResetInterface_LoaiBH(false);
        }

        private void TSMI_SuaLoaiBH_Click(object sender, EventArgs e)
        {
            bIsAddNew = false;
            bAddLoaiBH = true;
            bAddDetailBH = false;

            ResetInterface_LoaiBH(true);
        }

        private void TSMI_SuaChiTietBH_Click(object sender, EventArgs e)
        {
            bIsAddNew = false;
            bAddLoaiBH = false;
            bAddDetailBH = true;

            ResetInterface_LoaiBH_Detail(true);
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (bIsAddNew)
                {
                    if (bAddLoaiBH == true)
                    {
                        if (MessageBox.Show("Bạn thực sự muốn thêm loại bảo hiểm này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            oBaoHiem = new Business.Luong.BaoHiem();
                            oBaoHiem.Ten_Loai_BH = txt_LoaiBH.Text.Trim();
                            try
                            {
                                if (oBaoHiem.Add_LoaiBH())
                                {
                                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                Fill_Data();
                                ResetInterface_LoaiBH(false);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Thao tác thêm thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (bAddDetailBH == true)
                    {
                        if (lsb_DanhSach.SelectedItem == null)
                        {
                            MessageBox.Show("Vui lòng chọn một loại bảo hiểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int m_loai_bh_selected = Convert.ToInt32(lsb_DanhSach.SelectedValue.ToString());

                            if (MessageBox.Show("Bạn thực sự muốn thêm thông tin cho loại bảo hiểm này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                oBaoHiem = new Business.Luong.BaoHiem();
                                oBaoHiem.Loai_BH_ID = m_loai_bh_selected;
                                oBaoHiem.Nhan_Vien_Dong = Convert.ToDouble(nup_NhanVienDong.Value);
                                oBaoHiem.Nha_Truong_Dong = Convert.ToDouble(nup_NhaTruongDong.Value);
                                oBaoHiem.Tu_Thoi_gian = dTP_TuNgay.Value;
                                if (dtp_DenNgay.Checked == true)
                                    oBaoHiem.Den_Thoi_Gian = dtp_DenNgay.Value;
                                else
                                    oBaoHiem.Den_Thoi_Gian = null;

                                oBaoHiem.Ghi_Chu = rTB_GhiChu.Text;

                                try
                                {
                                    if (oBaoHiem.Add_LoaiBH_Detail())
                                    {
                                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                    Fill_Data();
                                    ResetInterface_LoaiBH_Detail(false);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Thao tác thêm thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (bAddLoaiBH == true)
                    {
                        if (lsb_DanhSach.SelectedItem == null)
                        {
                            MessageBox.Show("Vui lòng chọn một loại bảo hiểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (MessageBox.Show("Bạn thực sự muốn sửa loại bảo hiểm này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                oBaoHiem = new Business.Luong.BaoHiem();
                                oBaoHiem.Loai_BH_ID = Convert.ToInt32(lsb_DanhSach.SelectedValue.ToString());
                                oBaoHiem.Ten_Loai_BH = txt_LoaiBH.Text.Trim();
                                try
                                {
                                    if (oBaoHiem.Update_LoaiBH())
                                    {
                                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                    Fill_Data();
                                    ResetInterface_LoaiBH(false);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Thao tác cập nhật thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else if (bAddDetailBH == true)
                    {
                        if (MessageBox.Show("Bạn thực sự muốn sửa thông tin cho loại bảo hiểm này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                oBaoHiem = new Business.Luong.BaoHiem();
                                oBaoHiem.BH_ID = Convert.ToInt32(dtgv_BaoHiem.SelectedRows[0].Cells["id"].Value.ToString());
                                oBaoHiem.Loai_BH_ID = Convert.ToInt32(dtgv_BaoHiem.SelectedRows[0].Cells["loai_bh_id"].Value.ToString()); ;
                                oBaoHiem.Nhan_Vien_Dong = Convert.ToDouble(nup_NhanVienDong.Value);
                                oBaoHiem.Nha_Truong_Dong = Convert.ToDouble(nup_NhaTruongDong.Value);
                                oBaoHiem.Tu_Thoi_gian = dTP_TuNgay.Value;
                                if (dtp_DenNgay.Checked == true)
                                    oBaoHiem.Den_Thoi_Gian = dtp_DenNgay.Value;
                                else
                                    oBaoHiem.Den_Thoi_Gian = null;

                                oBaoHiem.Ghi_Chu = rTB_GhiChu.Text;


                                if (oBaoHiem.Update_LoaiBH_Detail())
                                {
                                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                Fill_Data();
                                ResetInterface_LoaiBH_Detail(false);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Thao tác cập nhật thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TSMI_XoaLoaiPC_Click(object sender, EventArgs e)
        {
            if (lsb_DanhSach.SelectedItem != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá loại bảo hiểm \"" + lsb_DanhSach.Text.ToString() + "\" ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oBaoHiem = new Business.Luong.BaoHiem();
                        oBaoHiem.Loai_BH_ID = Convert.ToInt32(lsb_DanhSach.SelectedValue.ToString());
                        if (oBaoHiem.Delete_LoaiBH())
                        {
                            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        Fill_Data();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xóa không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
                MessageBox.Show("Vui lòng chọn một loại bảo hiểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TSMI_XoaChiTietBH_Click(object sender, EventArgs e)
        {
            if (dtgv_BaoHiem.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá thông tin của bảo hiểm này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oBaoHiem = new Business.Luong.BaoHiem();
                        oBaoHiem.BH_ID = Convert.ToInt32(dtgv_BaoHiem.SelectedRows[0].Cells["id"].Value.ToString());

                        if (oBaoHiem.Delete_LoaiBH_Detail())
                        {
                            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        Fill_Data();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xóa không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng thông tin bảo hiểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
