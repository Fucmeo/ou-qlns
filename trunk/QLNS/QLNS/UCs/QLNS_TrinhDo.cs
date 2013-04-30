using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;

namespace QLNS.UCs
{
    public partial class QLNS_TrinhDo : UserControl
    {
        Business.TrinhDo oTrinhDo;
        DataTable dtDSTrinhDo;
        bool AddFlag;   // xac dinh thao tac add hay edit

        public QLNS_TrinhDo()
        {
            InitializeComponent();
            oTrinhDo = new TrinhDo();
        }

        private void QLNS_TrinhDo_Load(object sender, EventArgs e)
        {
            DataTable dt = oTrinhDo.GetTrinhDoList();
            if (dt != null)
            {
                PrepareDataSource(dt);
                EditDtgInterface();
            }

            ResetInterface(true);
        }


        #region Ham phu
        private void PrepareDataSource(DataTable dt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dtgv_DSTrinhDo.DataSource = bs;
        }

        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtgv_DSTrinhDo.Columns["ten"].HeaderText = "Tên";
            dtgv_DSTrinhDo.Columns["ten"].Width = 150;
            //dtgv_DSTrinhDo.Columns[2].HeaderText = "Sau đại học?";
            
            // An cac cot ID
            dtgv_DSTrinhDo.Columns["id"].Visible = false;
            dtgv_DSTrinhDo.Columns["mo_ta"].Visible = false;
        }

        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_Ten.Text = row.Cells["ten"].Value.ToString();
            }
        }

        private void ResetInterface(bool init)
        {
            if (init)
            {
                Program.DkButton(new Button[] { btn_Them, btn_Sua, btn_Xoa }, new Button[] { btn_Luu, btn_Huy });
                Program.DkControl(new Object[] { txt_Ten}, false, "Enable");
                dtgv_DSTrinhDo.Enabled = true;
                if (dtgv_DSTrinhDo.CurrentRow != null)
                    DisplayInfo(dtgv_DSTrinhDo.CurrentRow);
            }
            else
            {
                Program.DkControl(new Object[] { txt_Ten}, true, "Enable");
                Program.DkButton(new Button[] { btn_Luu, btn_Huy }, new Button[] { btn_Them, btn_Sua, btn_Xoa });
                txt_Ten.Focus();
                dtgv_DSTrinhDo.Enabled = false;
                if (AddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_Ten.Text= "";
                }
            }
        }

        private void RefreshDataSource()
        {
            oTrinhDo = new TrinhDo();
            DataTable dt = oTrinhDo.GetTrinhDoList();
            if (dt != null)
            {
                PrepareDataSource(dt);
                EditDtgInterface();
            }
        }

        #endregion

        private void btn_Them_Click(object sender, EventArgs e)
        {
            AddFlag = true;
            ResetInterface(false);
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            AddFlag = false;
            ResetInterface(false);
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ResetInterface(true);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgv_DSTrinhDo.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá trình độ này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oTrinhDo.ID = Convert.ToInt16(dtgv_DSTrinhDo.CurrentRow.Cells["id"].Value.ToString());
                    try
                    {
                        oTrinhDo.Delete();
                        RefreshDataSource();
                        MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (txt_Ten.Text != "")
            {
                oTrinhDo.Ten = txt_Ten.Text;
                #region thao tac them
                if (AddFlag)
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm trình độ này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                        try
                        {
                            oTrinhDo.Add();
                            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ResetInterface(true);
                            RefreshDataSource();

                            return;
                        }
                        catch
                        {
                            MessageBox.Show("Thao tác thêm thất bại.", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }

                    }

                }
                #endregion
                #region thao tac sua
                else                // thao tac sua
                {
                    if (MessageBox.Show("Bạn thực sự muốn sửa trình độ này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oTrinhDo.ID = Convert.ToInt16(dtgv_DSTrinhDo.CurrentRow.Cells["id"].Value.ToString());
                        
                        try
                        {
                            oTrinhDo.Update();
                            MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ResetInterface(true);
                            RefreshDataSource();

                            return;
                        }
                        catch
                        {
                            MessageBox.Show("Thao tác sửa thất bại.", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }

                    }
                }
                #endregion
            }
            else
                MessageBox.Show("Tên trình độ không được rỗng, xin vui lòng cung cấp tên trình độ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dtgv_DSTrinhDo_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSTrinhDo.CurrentRow != null)
                DisplayInfo(dtgv_DSTrinhDo.CurrentRow);
        }

    }
}
