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
        Business.TrinhDo trinhdo;

        bool AddFlag;   // xac dinh thao tac add hay edit

        public QLNS_VanBang()
        {
            InitializeComponent();
            vanbang = new VanBangChinhQuy();
            trinhdo = new TrinhDo();

        }

        private void QLNS_VanBang_Load(object sender, EventArgs e)
        {
            DataTable dt = vanbang.GetVanBangList();
            if (dt != null)
            {
                PrepareDataSource(dt);
                EditDtgInterface();
            }
            LoadCboTrinhDo();

            ResetInterface(true);
        }

        #region Ham phu
        private void LoadCboTrinhDo()
        {
            DataTable dt = trinhdo.GetTrinhDoList();
            DataRow dr = dt.NewRow();
            dr["ten"] = "";
            dr["mo_ta"] = "";
            dr["id"] = -1;
            dt.Rows.InsertAt(dr, 0);

            comB_TrinhDo.DataSource = dt;
            comB_TrinhDo.DisplayMember = "ten";
            comB_TrinhDo.ValueMember = "id";
        }

        private void PrepareDataSource(DataTable dt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dtgv_DSVanBang.DataSource = bs;
        }

        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtgv_DSVanBang.Columns["ten_van_bang"].HeaderText = "Tên văn bằng";
            dtgv_DSVanBang.Columns["ten_van_bang"].Width = 150;
            
            dtgv_DSVanBang.Columns["mo_ta"].HeaderText = "Mô tả";
            dtgv_DSVanBang.Columns["mo_ta"].Width = 200;

            dtgv_DSVanBang.Columns["ten"].HeaderText = "Trình độ";
            dtgv_DSVanBang.Columns["ten"].Width = 150;

            // An cac cot ID
            dtgv_DSVanBang.Columns["id"].Visible = false;
            dtgv_DSVanBang.Columns["trinh_do_id"].Visible = false;
        }

        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_Ten.Text = row.Cells["ten_van_bang"].Value.ToString();
                rtb_MoTa.Text = row.Cells["mo_ta"].Value.ToString();

                //Xử lý combo Trình độ
                comB_TrinhDo.SelectedValue = dtgv_DSVanBang.CurrentRow.Cells["trinh_do_id"].Value;
            }
        }

        private void ResetInterface(bool init)
        {
            if (init)
            {
                Program.DkButton(new Button[] { btn_Them, btn_Sua, btn_Xoa }, new Button[] { btn_Luu, btn_Huy });
                Program.DkControl(new Object[] { txt_Ten, rtb_MoTa, comB_TrinhDo }, false, "Enable");
                dtgv_DSVanBang.Enabled = true;
                if (dtgv_DSVanBang.CurrentRow != null)
                    DisplayInfo(dtgv_DSVanBang.CurrentRow);
            }
            else
            {
                Program.DkControl(new Object[] { txt_Ten, rtb_MoTa, comB_TrinhDo }, true, "Enable");
                Program.DkButton(new Button[] { btn_Luu, btn_Huy }, new Button[] { btn_Them, btn_Sua, btn_Xoa });
                txt_Ten.Focus();
                dtgv_DSVanBang.Enabled = false;
                if (AddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_Ten.Text = rtb_MoTa.Text = "";
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
                    vanbang = new VanBangChinhQuy(Convert.ToInt16(dtgv_DSVanBang.CurrentRow.Cells["id"].Value.ToString()));
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
                        int? trinhdoid = null;
                        if (comB_TrinhDo.Text != "")
                            trinhdoid = Convert.ToInt32(comB_TrinhDo.SelectedValue.ToString());
                        
                        try
                        {
                            vanbang = new VanBangChinhQuy(id, txt_Ten.Text, trinhdoid, rtb_MoTa.Text);
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
                        int id = Convert.ToInt16(dtgv_DSVanBang.CurrentRow.Cells["id"].Value.ToString());
                        int? trinhdoid = null;
                        if (comB_TrinhDo.Text != "")
                            trinhdoid = Convert.ToInt32(comB_TrinhDo.SelectedValue.ToString());
                        
                        try
                        {
                            vanbang = new VanBangChinhQuy(id, txt_Ten.Text, trinhdoid, rtb_MoTa.Text);
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
