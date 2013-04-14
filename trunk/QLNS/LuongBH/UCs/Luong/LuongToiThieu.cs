using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;

namespace LuongBH.UCs.Luong
{
    public partial class LuongToiThieu : UserControl
    {
        bool bAddFlag;
        Business.Luong.LuongToiThieu oLuongToiThieu;
        DataTable dtDSLuongToiThieu;

        public LuongToiThieu()
        {
            InitializeComponent();
            oLuongToiThieu = new Business.Luong.LuongToiThieu();
        }

        private void txt_Luong_TextChanged(object sender, EventArgs e)
        {

        }

        private void LuongToiThieu_Load(object sender, EventArgs e)
        {
            ResetInterface(true);
            dtDSLuongToiThieu = oLuongToiThieu.GetData();
            if (dtDSLuongToiThieu != null)
            {
                PrepareDataSource();
                EditDtgInterface();
            }
        }

        #region Private methods
        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtDSLuongToiThieu;
            dtgv_DSLuong.DataSource = bs;
            //lbl_SoLoaiQD.Text = dtgv_DSLoaiQD.Rows.Count.ToString();
            if (dtDSLuongToiThieu != null)
            {
                btn_Sua.Visible = btn_Xoa.Visible = true;
            }
        }

        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtgv_DSLuong.Columns["tien_luong"].HeaderText = "Tiền lương";
            //dtgv_DSBacHeSo.Columns["tien_luong"].Width = 300;
            dtgv_DSLuong.Columns["tu_ngay"].HeaderText = "Từ ngày";
            dtgv_DSLuong.Columns["den_ngay"].HeaderText = "Đến ngày";
            
            // An dtgv_DSLoaiQD ID
            dtgv_DSLuong.Columns["id"].Visible = false;
            dtgv_DSLuong.Columns["tinh_trang"].Visible = false;
        }

        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_Luong.Text = row.Cells["tien_luong"].Value.ToString();
                if (row.Cells["tu_ngay"].Value.ToString() != "")
                {
                    dtp_TuNgay.Value = Convert.ToDateTime(row.Cells["tu_ngay"].Value.ToString());
                    dtp_TuNgay.Checked = true;
                }
                else
                    dtp_TuNgay.Checked = false;
                if (row.Cells["den_ngay"].Value.ToString() != "")
                {
                    dtp_DenNgay.Value = Convert.ToDateTime(row.Cells["den_ngay"].Value.ToString());
                    dtp_DenNgay.Checked = true;
                }
                else
                    dtp_DenNgay.Checked = false;
                if (row.Cells["tinh_trang"].Value != null)
                    cb_TinhTrang.Checked = Convert.ToBoolean(row.Cells["tinh_trang"].Value.ToString());
            }
        }

        private void ResetInterface(bool init)
        {
            if (init)
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = true;
                btn_Huy.Visible = btn_Luu.Visible = false;
                txt_Luong.Enabled = dtp_TuNgay.Enabled = dtp_DenNgay.Enabled = false;
                dtgv_DSLuong.Enabled = true;
                if (dtgv_DSLuong.CurrentRow != null)
                {
                    DisplayInfo(dtgv_DSLuong.CurrentRow);
                }
            }
            else
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = false;
                btn_Huy.Visible = btn_Luu.Visible = true;
                txt_Luong.Enabled = dtp_TuNgay.Enabled = dtp_DenNgay.Enabled = true;
                dtgv_DSLuong.Enabled = false;

                if (bAddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_Luong.Text = "";
                }
            }
        }

        private void RefreshDataSource()
        {
            Business.Luong.LuongToiThieu luongtoithieu = new Business.Luong.LuongToiThieu();
            dtDSLuongToiThieu = luongtoithieu.GetData();
            PrepareDataSource();

        }
        #endregion

        private void dtp_TuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_TuNgay.Checked == true && dtp_TuNgay.Enabled == true)
                dtp_DenNgay.Enabled = true;
            else
                dtp_DenNgay.Enabled = false;
        }

        private void dtgv_DSBacHeSo_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSLuong.CurrentRow != null)
            {
                DisplayInfo(dtgv_DSLuong.CurrentRow);
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            bAddFlag = true;
            ResetInterface(false);
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            bAddFlag = false;
            ResetInterface(false);
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ResetInterface(true);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgv_DSLuong.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá mục lương tối thiểu này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oLuongToiThieu.ID = Convert.ToInt16(dtgv_DSLuong.CurrentRow.Cells["id"].Value.ToString());
                        if (oLuongToiThieu.Delete())
                        {
                            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        RefreshDataSource();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Luong.Text))
            {
                #region thao tac them

                if (bAddFlag)
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm mức lương này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oLuongToiThieu.TienLuong = Convert.ToDouble(txt_Luong.Text.Trim());
                        if (dtp_TuNgay.Checked == true)
                            oLuongToiThieu.TuNgay = dtp_TuNgay.Value;
                        else
                            oLuongToiThieu.TuNgay = null;
                        if (dtp_DenNgay.Checked == true)
                            oLuongToiThieu.DenNgay = dtp_DenNgay.Value;
                        else
                            oLuongToiThieu.DenNgay = null;

                        try
                        {
                            if (oLuongToiThieu.Add())
                            {
                                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
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
                    if (MessageBox.Show("Bạn thực sự muốn sửa mức lương này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oLuongToiThieu.ID = Convert.ToInt16(dtgv_DSLuong.CurrentRow.Cells["id"].Value.ToString());
                        oLuongToiThieu.TienLuong = Convert.ToDouble(txt_Luong.Text.Trim());
                        if (dtp_TuNgay.Checked == true)
                            oLuongToiThieu.TuNgay = dtp_TuNgay.Value;
                        else
                            oLuongToiThieu.TuNgay = null;
                        if (dtp_DenNgay.Checked == true)
                            oLuongToiThieu.DenNgay = dtp_DenNgay.Value;
                        else
                            oLuongToiThieu.DenNgay = null;

                        try
                        {
                            if (oLuongToiThieu.Update())
                            {
                                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Thao tác sửa thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }

                RefreshDataSource();
                ResetInterface(true);

                #endregion
            }
            else
                MessageBox.Show("Giá trị lương tối thiểu không được rỗng, xin vui lòng cung cấp đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
        }
    }
}
