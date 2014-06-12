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
    public partial class QLNS_LoaiDonVi : UserControl
    {
        Business.LoaiDonVi LoaiDonVi;

        bool AddFlag;   // xac dinh thao tac add hay edit

        public QLNS_LoaiDonVi()
        {
            InitializeComponent();
            LoaiDonVi = new Business.LoaiDonVi();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void QLNS_LoaiLoaiDonVi_Load(object sender, EventArgs e)
        {
            DataTable dt = LoaiDonVi.GetList();
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
            dtgv_DSLoaiDonVi.DataSource = bs;
        }

        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtgv_DSLoaiDonVi.Columns[1].HeaderText = "Tên loại đơn vị";
            dtgv_DSLoaiDonVi.Columns[1].Width = 300;

            // An cac cot ID
            dtgv_DSLoaiDonVi.Columns[0].Visible = false;
        }

        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_Ten.Text = row.Cells[1].Value.ToString();


            }
        }

        private void ResetInterface(bool init)
        {
            if (init)
            {
                Program.DkButton(new Button[] { btn_Them, btn_Sua, btn_Xoa }, new Button[] { btn_Luu, btn_Huy });
                Program.DkControl(new Object[] { txt_Ten}, false, "Enable");
                dtgv_DSLoaiDonVi.Enabled = true;
                if (dtgv_DSLoaiDonVi.CurrentRow != null)    
                    DisplayInfo(dtgv_DSLoaiDonVi.CurrentRow);
            }
            else
            {
                Program.DkControl(new Object[] { txt_Ten }, true, "Enable");
                Program.DkButton(new Button[] { btn_Luu, btn_Huy }, new Button[] { btn_Them, btn_Sua, btn_Xoa });
                txt_Ten.Focus();
                dtgv_DSLoaiDonVi.Enabled = false;
                if (AddFlag) // thao tac them moi xoa rong cac field
                {
                     txt_Ten.Text = "";
                }
            }
        }


        private void RefreshDataSource()
        {
            LoaiDonVi = new Business.LoaiDonVi();
            DataTable dt = LoaiDonVi.GetList();
            if (dt != null)
            {
                PrepareDataSource(dt);
                EditDtgInterface();
            }
        }

        #endregion

        private void dtgv_DSLoaiDonVi_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSLoaiDonVi.CurrentRow != null)
                DisplayInfo(dtgv_DSLoaiDonVi.CurrentRow);
        }

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
            if (dtgv_DSLoaiDonVi.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá loại đơn vị này? ", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //vanbang = ToDepartmentObject(dtg_DepartmentList.CurrentRow);
                    LoaiDonVi.ID = (Convert.ToInt16(dtgv_DSLoaiDonVi.CurrentRow.Cells[0].Value.ToString()));
                    try
                    {
                        LoaiDonVi.Delete();
                        RefreshDataSource();
                        MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Xoá không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (txt_Ten.Text != "" )
            {
                #region thao tac them
                if (AddFlag)
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm loại đơn vị này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string tendv = txt_Ten.Text;



                        LoaiDonVi.TenLoai = tendv;
                        try
                        {
                            LoaiDonVi.Add();
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
                    if (MessageBox.Show("Bạn thực sự muốn sửa loại đơn vị này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt16(dtgv_DSLoaiDonVi.CurrentRow.Cells[0].Value.ToString());
                        string tendv = txt_Ten.Text;

                        LoaiDonVi.ID = id;
                        LoaiDonVi.TenLoai = tendv;

                            try
                            {
                                LoaiDonVi.Update();
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
                MessageBox.Show("Tên loại đơn vị không được rỗng, xin vui lòng cung cấp tên loại đơn vị", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
