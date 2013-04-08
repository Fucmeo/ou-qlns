using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNS.UCs
{
    public partial class QLNS_ChucDanh : UserControl
    {
        #region global variables

        bool bAddFlag;
        Business.ChucDanh oChucDanh;
        DataTable dtDSChucDanh;

        #endregion

        public QLNS_ChucDanh()
        {
            InitializeComponent();
            oChucDanh = new Business.ChucDanh();
        }

        #region xu ly button

        private void btn_Them_Click(object sender, EventArgs e)
        {
            bAddFlag = true;
            ResetInterface(false);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgv_DSNhomNgach.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá chức danh này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oChucDanh.ID = Convert.ToInt16(dtgv_DSNhomNgach.CurrentRow.Cells[0].Value.ToString());
                        if (oChucDanh.Delete())
                        {
                            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        RefreshDataSource();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (dtgv_DSNhomNgach.Rows.Count > 0)
            {
                bAddFlag = false;
                ResetInterface(false);
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_ChucDanh.Text))
            {
                #region thao tac them

                if (bAddFlag)
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm chức danh này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oChucDanh.TenChucDanh = txt_ChucDanh.Text.Trim();
                        try
                        {
                            if (oChucDanh.Add())
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
                    if (MessageBox.Show("Bạn thực sự muốn sửa chức danh này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oChucDanh.ID = Convert.ToInt16(dtgv_DSNhomNgach.CurrentRow.Cells[0].Value.ToString());
                        oChucDanh.TenChucDanh = txt_ChucDanh.Text.Trim();
                        try
                        {
                            if (oChucDanh.Update())
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
                MessageBox.Show("Tên chức danh không được rỗng, xin vui lòng cung cấp tên chức danh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ResetInterface(true);
        }

        #endregion

        #region xu ly giao dien

        private void QLNS_ChucDanh_Load(object sender, EventArgs e)
        {
            dtDSChucDanh = oChucDanh.GetList();
            if (dtDSChucDanh != null)
            {
                PrepareDataSource();
                EditDtgInterface();
            }
        }

        private void dtgv_DSChucDanh_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSNhomNgach.CurrentRow != null)
            {
                DisplayInfo(dtgv_DSNhomNgach.CurrentRow);
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
                txt_ChucDanh.Enabled = false;
                dtgv_DSNhomNgach.Enabled = true;
                if (dtgv_DSNhomNgach.CurrentRow != null)
                {
                    DisplayInfo(dtgv_DSNhomNgach.CurrentRow);
                }
            }
            else
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = false;
                btn_Huy.Visible = btn_Luu.Visible = true;
                txt_ChucDanh.Enabled = true;
                dtgv_DSNhomNgach.Enabled = false;

                if (bAddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_ChucDanh.Text = "";
                }
            }

        #endregion

        }

        

        #region ham phu

        /// <summary>
        /// Su dung thong tin row dang chon de hien thi len txt, comb,..
        /// </summary>
        /// <param name="row"></param>
        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_ChucDanh.Text = row.Cells[1].Value.ToString();
            }
        }

        /// <summary>
        /// Refresh Data Source cho dtg sau moi lan thao tac
        /// </summary>
        private void RefreshDataSource()
        {
            Business.ChucDanh cd = new Business.ChucDanh();     // khong dung chung oChucDanh duoc ???
            dtDSChucDanh = cd.GetList();
            PrepareDataSource();
        }

        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtDSChucDanh;
            dtgv_DSNhomNgach.DataSource = bs;
            lbl_SoChucDanh.Text = dtgv_DSNhomNgach.Rows.Count.ToString();
            if (dtDSChucDanh != null)
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
            dtgv_DSNhomNgach.Columns[1].HeaderText = "Tên chức danh";
            dtgv_DSNhomNgach.Columns[1].Width = 250;
            // An cot ID
            dtgv_DSNhomNgach.Columns[0].Visible = false;         
        }

        #endregion

    }
}
