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
    public partial class BacHeSo : UserControl
    {
        bool bAddFlag;
        Business.Luong.BacHeSo oBacHeSo;
        DataTable dtDSBacHeSo;

        Business.Luong.Ngach oNgach;
        DataTable dtDSNgach;


        public BacHeSo()
        {
            InitializeComponent();
            oBacHeSo = new Business.Luong.BacHeSo();
            oNgach = new Business.Luong.Ngach();
        }

        private void BacHeSo_Load(object sender, EventArgs e)
        {
            ResetInterface(true);
            dtDSBacHeSo = oBacHeSo.GetData();
            if (dtDSBacHeSo != null)
            {
                PrepareDataSource();
                EditDtgInterface();
            }

            LoadCboNgach();

        }

        #region Private methods
        private void LoadCboNgach()
        {
            dtDSNgach = oNgach.GetList_WithoutNullItem();

            comB_TenNgach.DataSource = dtDSNgach;
            comB_TenNgach.DisplayMember = "ten_ngach";
            comB_TenNgach.ValueMember = "ma_ngach";
        }
     
        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtDSBacHeSo;
            dtgv_DSBacHeSo.DataSource = bs;
            //lbl_SoLoaiQD.Text = dtgv_DSLoaiQD.Rows.Count.ToString();
            if (dtDSBacHeSo != null)
            {
                btn_Sua.Visible = btn_Xoa.Visible = true;
            }
        }

        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtgv_DSBacHeSo.Columns["ma_ngach"].HeaderText = "Mã ngạch";
            dtgv_DSBacHeSo.Columns["ten_ngach"].HeaderText = "Tên ngạch";
            dtgv_DSBacHeSo.Columns["bac"].HeaderText = "Bậc";
            dtgv_DSBacHeSo.Columns["he_so"].HeaderText = "Hệ số";
            dtgv_DSBacHeSo.Columns["is_vuot_khung"].HeaderText = "Vượt khung?";

            dtgv_DSBacHeSo.Columns["tu_ngay"].HeaderText = "Từ ngày";
            dtgv_DSBacHeSo.Columns["den_ngay"].HeaderText = "Đến ngày";

            // An dtgv_DSLoaiQD ID
            dtgv_DSBacHeSo.Columns["id"].Visible = false;
            dtgv_DSBacHeSo.Columns["tinh_trang"].Visible = false;
        }

        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_Bac.Text = row.Cells["bac"].Value.ToString();
                txt_HeSo.Text = row.Cells["he_so"].Value.ToString();
                comB_TenNgach.SelectedValue = row.Cells["ten_ngach"].Value.ToString();
                txt_MaNgach.Text = row.Cells["ma_ngach"].Value.ToString();

                try
                {
                    var str_nhom_ngach = from c in dtDSNgach.AsEnumerable()
                                         where c.Field<string>("ma_ngach") == txt_MaNgach.Text
                                         select c.Field<string>("ten_nhom");

                    txt_NhomNgach.Text = str_nhom_ngach.ElementAt(0).ToString();
                }
                catch { }
           
                if (row.Cells["is_vuot_khung"].Value.ToString() != "")
                    cb_VuotKhung.Checked = Convert.ToBoolean(row.Cells["is_vuot_khung"].Value.ToString());

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
                
            }
        }

      

        private void ResetInterface(bool init)
        {
            if (init)
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = true;
                btn_Huy.Visible = btn_Luu.Visible = false;
                txt_Bac.Enabled = txt_HeSo.Enabled = comB_TenNgach.Enabled = cb_VuotKhung.Enabled = 
                            dtp_TuNgay.Enabled = dtp_DenNgay.Enabled = false;
                dtgv_DSBacHeSo.Enabled = true;
                if (dtgv_DSBacHeSo.CurrentRow != null)
                {
                    DisplayInfo(dtgv_DSBacHeSo.CurrentRow);
                }
            }
            else
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = false;
                btn_Huy.Visible = btn_Luu.Visible = true;
                txt_Bac.Enabled = txt_HeSo.Enabled = comB_TenNgach.Enabled = cb_VuotKhung.Enabled = 
                            dtp_TuNgay.Enabled = dtp_DenNgay.Enabled = true;
                dtgv_DSBacHeSo.Enabled = false;

                if (bAddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_Bac.Text = txt_HeSo.Text = "";
                }
            }
        }

        private void RefreshDataSource()
        {
            Business.Luong.BacHeSo bacheso = new Business.Luong.BacHeSo();
            dtDSBacHeSo = bacheso.GetData();
            PrepareDataSource();

        }
        #endregion

        

        private void comB_TenNgach_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comB_TenNgach.Text != "")
            {
                txt_MaNgach.Text = comB_TenNgach.SelectedValue.ToString();
            }
        }

        private void dtgv_DSBacHeSo_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSBacHeSo.CurrentRow != null)
            {
                DisplayInfo(dtgv_DSBacHeSo.CurrentRow);
            }
        }

        private void txt_MaNgach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var str_nhom_ngach = from c in dtDSNgach.AsEnumerable()
                                     where c.Field<string>("ma_ngach") == txt_MaNgach.Text
                                     select c.Field<string>("ten_nhom");

                txt_NhomNgach.Text = str_nhom_ngach.ElementAt(0).ToString();
            }
            catch { }
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
            if (dtgv_DSBacHeSo.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá hệ số này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oBacHeSo.ID = Convert.ToInt16(dtgv_DSBacHeSo.CurrentRow.Cells["id"].Value.ToString());
                        if (oBacHeSo.Delete())
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
            if (!string.IsNullOrWhiteSpace(txt_Bac.Text) && !string.IsNullOrWhiteSpace(txt_HeSo.Text))
            {
                #region thao tac them

                if (bAddFlag)
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm hệ số này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oBacHeSo.Bac = Convert.ToInt32(txt_Bac.Text.Trim());
                        oBacHeSo.HeSo = Convert.ToDouble(txt_HeSo.Text.Trim());
                        oBacHeSo.MaNgach = comB_TenNgach.SelectedValue.ToString();
                        oBacHeSo.IsVuotKhung = cb_VuotKhung.Checked;
                        if (dtp_TuNgay.Checked == true)
                            oBacHeSo.TuNgay = dtp_TuNgay.Value;
                        else
                            oBacHeSo.TuNgay = null;
                        if (dtp_DenNgay.Checked == true)
                            oBacHeSo.DenNgay = dtp_DenNgay.Value;
                        else
                            oBacHeSo.DenNgay = null;

                        try
                        {
                            if (oBacHeSo.Add())
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
                    if (MessageBox.Show("Bạn thực sự muốn sửa hệ số này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oBacHeSo.ID = Convert.ToInt16(dtgv_DSBacHeSo.CurrentRow.Cells["id"].Value.ToString());
                        oBacHeSo.Bac = Convert.ToInt32(txt_Bac.Text.Trim());
                        oBacHeSo.HeSo = Convert.ToDouble(txt_HeSo.Text.Trim());
                        oBacHeSo.MaNgach = comB_TenNgach.SelectedValue.ToString();
                        oBacHeSo.IsVuotKhung = cb_VuotKhung.Checked;
                        if (dtp_TuNgay.Checked == true)
                            oBacHeSo.TuNgay = dtp_TuNgay.Value;
                        else
                            oBacHeSo.TuNgay = null;
                        if (dtp_DenNgay.Checked == true)
                            oBacHeSo.DenNgay = dtp_DenNgay.Value;
                        else
                            oBacHeSo.DenNgay = null;

                        try
                        {
                            if (oBacHeSo.Update())
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

        private void dtp_TuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_TuNgay.Checked == true && dtp_TuNgay.Enabled == true)
                dtp_DenNgay.Enabled = true;
            else
                dtp_DenNgay.Enabled = false;
        }

    
    }
}