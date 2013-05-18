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
    public partial class QLNS_ChucVu : UserControl
    {
        #region global variables

        bool bAddFlag;
        Business.ChucVu oChucVu;
        DataTable dtDSChucVu;

        #endregion

        public QLNS_ChucVu()
        {
            InitializeComponent();
            oChucVu = new Business.ChucVu();
        }

        #region xu ly buttons

        private void btn_Them_Click(object sender, EventArgs e)
        {
            bAddFlag = true; 
            ResetInterface(false);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgv_DSChucVu.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá chức vụ này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oChucVu.ID = Convert.ToInt16(dtgv_DSChucVu.CurrentRow.Cells[0].Value.ToString());
                        if (oChucVu.Delete())
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
            if (dtgv_DSChucVu.Rows.Count > 0 )
            {
                 bAddFlag = false;
                ResetInterface(false);
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_ChucVu.Text))
            {
                #region thao tac them

                if (bAddFlag)
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm chức vụ này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oChucVu.TenChucVu = txt_ChucVu.Text.Trim();
                        try
                        {
                            if (oChucVu.Add())
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
                    if (MessageBox.Show("Bạn thực sự muốn sửa chức vụ này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oChucVu.ID = Convert.ToInt16(dtgv_DSChucVu.CurrentRow.Cells[0].Value.ToString());
                        oChucVu.TenChucVu = txt_ChucVu.Text.Trim();
                        try
                        {
                            if (oChucVu.Update())
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
                MessageBox.Show("Tên chức vụ không được rỗng, xin vui lòng cung cấp tên mô hình", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ResetInterface(true);
        }

        #endregion

        #region xu ly giao dien

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSChucVu.CurrentRow != null)
            {
                DisplayInfo(dtgv_DSChucVu.CurrentRow);
            }
        }

        private void QLNS_ChucVu_Load(object sender, EventArgs e)
        {
            dtDSChucVu = oChucVu.GetListWithNoEmptyRow();
            if (dtDSChucVu != null)
            {
                PrepareDataSource();
                EditDtgInterface();   
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
                txt_ChucVu.Enabled = false;
                dtgv_DSChucVu.Enabled = true;
                if (dtgv_DSChucVu.CurrentRow != null)
                {
                    DisplayInfo(dtgv_DSChucVu.CurrentRow);
                }
            }
            else
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = false;
                btn_Huy.Visible = btn_Luu.Visible = true;
                txt_ChucVu.Enabled = true;
                dtgv_DSChucVu.Enabled = false;

                if (bAddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_ChucVu.Text = "";
                }
            }
        }

        #endregion

        #region ham phu

        /// <summary>
        /// Su dung thong tin row dang chon de hien thi len txt, comb,..
        /// </summary>
        /// <param name="row"></param>
        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_ChucVu.Text = row.Cells[1].Value.ToString();
            }
        }

        /// <summary>
        /// Refresh Data Source cho dtg sau moi lan thao tac
        /// </summary>
        private void RefreshDataSource()
        {
            Business.ChucVu cv = new Business.ChucVu();     // khong dung chung oChucVu duoc ???
            dtDSChucVu = cv.GetListWithNoEmptyRow();
            PrepareDataSource();
            
        }

        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtDSChucVu;
            dtgv_DSChucVu.DataSource = bs;
            lbl_SoChucVu.Text = dtgv_DSChucVu.Rows.Count.ToString();
            if (dtDSChucVu != null)
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
            dtgv_DSChucVu.Columns[1].HeaderText = "Tên chức vụ";
            dtgv_DSChucVu.Columns[1].Width = 250;
            // An cot ID
            dtgv_DSChucVu.Columns[0].Visible = false;         
        }

        #endregion
    }
}
