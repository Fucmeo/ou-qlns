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
    public partial class LoaiNgayPhep : UserControl
    {
        bool bAdd;
        Business.Luong.LoaiNgayPhep oLoaiNgayPhep;
        DataTable dtLoaiNgayPhep;

        public LoaiNgayPhep()
        {
            InitializeComponent();
            oLoaiNgayPhep = new Business.Luong.LoaiNgayPhep();
            dtLoaiNgayPhep = new DataTable();
        }

        private void LoaiNgayPhep_Load(object sender, EventArgs e)
        {
            dtLoaiNgayPhep = oLoaiNgayPhep.GetData();
            if (dtLoaiNgayPhep != null && dtLoaiNgayPhep.Rows.Count >0)
            {
                PrepareDataSource();
                EditDtgInterface();
                ResetInterface(true);
            }
        }

        void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtLoaiNgayPhep;
            dtgv_DS.DataSource = bs;
        }

        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtgv_DS.Columns["ten"].HeaderText = "Tên loại ngày phép";
            dtgv_DS.Columns["ten"].Width = 350;

            dtgv_DS.Columns["ghi_chu"].HeaderText = "Ghi chú";
            dtgv_DS.Columns["ghi_chu"].Width = 400;


            // An cac cot ID
            dtgv_DS.Columns["id"].Visible = dtgv_DS.Columns["tinh_luong"].Visible = dtgv_DS.Columns["cong_thuc_id"].Visible = false;
        }

        private void ResetInterface(bool b)
        {

            btn_Them.Visible = btn_Sua.Visible = btn_Xoa.Visible = dtgv_DS.Enabled =  b;
            txt_Ten.Enabled = rTB_GhiChu.Enabled = lstb_DS.Enabled = numericUpDown1.Enabled =  btn_Luu.Visible = btn_Huy.Visible = !b;

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ResetInterface(false);
            txt_Ten.Text = rTB_GhiChu.Text = "";
            lstb_DS.ClearSelected();
            numericUpDown1.Value = 100;
            bAdd = true;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ResetInterface(true);
            txt_Ten.Text = rTB_GhiChu.Text = "";
            lstb_DS.ClearSelected();
            numericUpDown1.Value = 100;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            ResetInterface(false);
            bAdd = false;
        
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (bAdd)
            {
                
            }
            else
            {

            }

            ResetInterface(true);
            txt_Ten.Text = rTB_GhiChu.Text = "";
            lstb_DS.ClearSelected();
            numericUpDown1.Value = 100;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (lstb_DS.SelectedItem != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá loại ngày phép \"" + lstb_DS.Text.ToString() + "\" ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                }

            }
        }
    }
}
