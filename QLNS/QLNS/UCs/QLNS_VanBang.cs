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
    public partial class QLNS_VanBang : UserControl
    {
        Business.VanBangChinhQuy vanbang;

        bool AddFlag;   // xac dinh thao tac add hay edit

        public QLNS_VanBang()
        {
            InitializeComponent();
            vanbang = new VanBangChinhQuy();

        }

        private void QLNS_VanBang_Load(object sender, EventArgs e)
        {
            DataTable dt = vanbang.GetVanBangList();
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
            dtgv_DSVanBang.DataSource = bs;
        }

        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtgv_DSVanBang.Columns[1].HeaderText = "Tên văn bằng";
            dtgv_DSVanBang.Columns[1].Width = 150;
            dtgv_DSVanBang.Columns[2].HeaderText = "Sau đại học?";
            dtgv_DSVanBang.Columns[3].HeaderText = "Mô tả";
            dtgv_DSVanBang.Columns[3].Width = 200;

            // An cac cot ID
            dtgv_DSVanBang.Columns[0].Visible = false;
        }

        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_Ten.Text = row.Cells[1].Value.ToString();
                rtb_MoTa.Text = row.Cells[3].Value.ToString();

                if (Convert.ToBoolean(row.Cells[2].Value) == true)
                    cb_SauDH.Checked = true;
                else
                    cb_SauDH.Checked = false;

                //txt_Department.Enabled = false;  // khong hieu sao no tu dong true???, nen phai set cho no false
            }
        }

        private void ResetInterface(bool init)
        {
            if (init)
            {
                Program.DkButton(new Button[] { btn_Them, btn_Sua, btn_Xoa }, new Button[] { btn_Luu, btn_Huy });
                Program.DkControl(new Object[] { txt_Ten, rtb_MoTa, cb_SauDH }, false, "Enable");
                dtgv_DSVanBang.Enabled = true;
                if (dtgv_DSVanBang.CurrentRow != null)
                    DisplayInfo(dtgv_DSVanBang.CurrentRow);
            }
            else
            {
                Program.DkControl(new Object[] { txt_Ten, rtb_MoTa, cb_SauDH }, true, "Enable");
                Program.DkButton(new Button[] { btn_Luu, btn_Huy }, new Button[] { btn_Them, btn_Sua, btn_Xoa });
                txt_Ten.Focus();
                dtgv_DSVanBang.Enabled = false;
                if (AddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_Ten.Text = rtb_MoTa.Text = "";
                    cb_SauDH.Checked = false;
                }
            }
        }

        private void RefreshDataSource()
        {
            vanbang = new VanBangChinhQuy();
            DataTable dt = vanbang.GetVanBangList();
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

        private void dtgv_DSVanBang_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSVanBang.CurrentRow != null)
                DisplayInfo(dtgv_DSVanBang.CurrentRow);
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
            if (dtgv_DSVanBang.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá văn bằng này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //vanbang = ToDepartmentObject(dtg_DepartmentList.CurrentRow);
                    vanbang = new VanBangChinhQuy(Convert.ToInt16(dtgv_DSVanBang.CurrentRow.Cells[0].Value.ToString()));
                    try
                    {
                        vanbang.Delete();
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
                #region thao tac them
                if (AddFlag)
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm văn bằng này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Department = ToDepartmentObject();
                        int? id = null;
                        bool saudh = false;
                        if (cb_SauDH.Checked == true)
                            saudh = true;
                        vanbang = new VanBangChinhQuy(id, txt_Ten.Text, saudh, rtb_MoTa.Text);
                        try
                        {
                            vanbang.Add();
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
                    if (MessageBox.Show("Bạn thực sự muốn sửa văn bằng này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt16(dtgv_DSVanBang.CurrentRow.Cells[0].Value.ToString());
                        bool saudh = false;
                        if (cb_SauDH.Checked == true)
                            saudh = true;
                        vanbang = new VanBangChinhQuy(id, txt_Ten.Text, saudh, rtb_MoTa.Text);
                        try
                        {
                            vanbang.Update();
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
                MessageBox.Show("Tên văn bằng không được rỗng, xin vui lòng cung cấp tên văn bằng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
