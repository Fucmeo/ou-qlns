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
    public partial class LoaiQuyetDinh : UserControl
    {
        bool bAddFlag;
        Business.HDQD.LoaiQuyetDinh oLoaiQuyetDinh;
        DataTable dtDSLoaiQuyetDinh;

        public LoaiQuyetDinh()
        {
            InitializeComponent();
            oLoaiQuyetDinh = new Business.HDQD.LoaiQuyetDinh();
        }

        private void LoaiQuyetDinh_Load(object sender, EventArgs e)
        {
            ResetInterface(true);
            dtDSLoaiQuyetDinh = oLoaiQuyetDinh.GetList();
            if (dtDSLoaiQuyetDinh != null)
            {
                PrepareDataSource();
                EditDtgInterface();
            }
        }

        #region Private methods

        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtDSLoaiQuyetDinh;
            dtgv_DSLoaiQD.DataSource = bs;
            lbl_SoLoaiQD.Text = dtgv_DSLoaiQD.Rows.Count.ToString();
            if (dtDSLoaiQuyetDinh != null)
            {
                btn_Sua.Visible = btn_Xoa.Visible = true;
            }
        }

        /// <summary>
        /// Sua ten, an  cac cot cua dtg cho phu hop
        /// </summary>
        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtgv_DSLoaiQD.Columns[1].HeaderText = "Tên loại quyết định";
            dtgv_DSLoaiQD.Columns[1].Width = 300;
            dtgv_DSLoaiQD.Columns[2].HeaderText = "Tên viết tắt";
            dtgv_DSLoaiQD.Columns[2].Width = 100;
            dtgv_DSLoaiQD.Columns[3].HeaderText = "Mô tả";
            dtgv_DSLoaiQD.Columns[3].Width = 500;
            // An dtgv_DSLoaiQD ID
            dtgv_DSLoaiQD.Columns[0].Visible = false;
        }

        /// <summary>
        /// Su dung thong tin row dang chon de hien thi len txt, comb,..
        /// </summary>
        /// <param name="row"></param>
        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_Ten.Text = row.Cells[1].Value.ToString();
                txt_TenVietTat.Text = row.Cells[2].Value.ToString();
                rTB_MoTa.Text = row.Cells[3].Value.ToString();
            }
        }

        /// <summary>
        /// An hien control, button
        /// </summary>
        /// <param name="init">true = init state, otherwise add/edit state</param>
        private void ResetInterface(bool init)
        {
            if (init)
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = true;
                btn_Huy.Visible = btn_Luu.Visible = false;
                txt_Ten.Enabled = txt_TenVietTat.Enabled = rTB_MoTa.Enabled = false;
                dtgv_DSLoaiQD.Enabled = true;
                if (dtgv_DSLoaiQD.CurrentRow != null)
                {
                    DisplayInfo(dtgv_DSLoaiQD.CurrentRow);
                }
            }
            else
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = false;
                btn_Huy.Visible = btn_Luu.Visible = true;
                txt_Ten.Enabled = txt_TenVietTat.Enabled = rTB_MoTa.Enabled = true;
                dtgv_DSLoaiQD.Enabled = false;

                if (bAddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_Ten.Text = txt_TenVietTat.Text = rTB_MoTa.Text = "";
                }
            }
        }

        /// <summary>
        /// Refresh Data Source cho dtg sau moi lan thao tac
        /// </summary>
        private void RefreshDataSource()
        {
            Business.HDQD.LoaiQuyetDinh loaiqd = new Business.HDQD.LoaiQuyetDinh();    // khong dung chung oChucVu duoc ???
            dtDSLoaiQuyetDinh = loaiqd.GetList();
            PrepareDataSource();

        }

        #endregion

        private void dtgv_DSLoaiQD_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSLoaiQD.CurrentRow != null)
            {
                DisplayInfo(dtgv_DSLoaiQD.CurrentRow);
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
            if (dtgv_DSLoaiQD.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá loại quyết định này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oLoaiQuyetDinh.ID = Convert.ToInt16(dtgv_DSLoaiQD.CurrentRow.Cells[0].Value.ToString());
                        if (oLoaiQuyetDinh.Delete())
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
            if (!string.IsNullOrWhiteSpace(txt_Ten.Text))
            {
                #region thao tac them

                if (bAddFlag)
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm loại phụ cấp này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oLoaiQuyetDinh.TenLoaiQuyetDinh = txt_Ten.Text.Trim();
                        oLoaiQuyetDinh.TenLoaiQD_Viettat = txt_TenVietTat.Text.Trim();
                        oLoaiQuyetDinh.MoTa = rTB_MoTa.Text.Trim();
                        try
                        {
                            if (oLoaiQuyetDinh.Add())
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
                    if (MessageBox.Show("Bạn thực sự muốn sửa mô hình này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oLoaiQuyetDinh.ID = Convert.ToInt16(dtgv_DSLoaiQD.CurrentRow.Cells[0].Value.ToString());
                        oLoaiQuyetDinh.TenLoaiQuyetDinh = txt_Ten.Text.Trim();
                        oLoaiQuyetDinh.TenLoaiQD_Viettat = txt_TenVietTat.Text.Trim();
                        oLoaiQuyetDinh.MoTa = rTB_MoTa.Text.Trim();
                        try
                        {
                            if (oLoaiQuyetDinh.Update())
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
                MessageBox.Show("Tên loại phụ cấp không được rỗng, xin vui lòng cung cấp tên loại phụ cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
