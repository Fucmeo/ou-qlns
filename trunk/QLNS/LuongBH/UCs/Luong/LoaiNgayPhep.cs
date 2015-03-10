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
        bool bAdd , bLoadListBoxDone = false;
        Business.Luong.LoaiNgayPhep oLoaiNgayPhep;
        Business.HDQD.LoaiPhuCap oLoaiPhuCap;
        DataTable dtLoaiNgayPhep , dtLoaiNgayPhep_compact;
        DataTable dtLoaiPC;

        public LoaiNgayPhep()
        {
            InitializeComponent();
            oLoaiNgayPhep = new Business.Luong.LoaiNgayPhep();
            dtLoaiNgayPhep_compact = new DataTable();
            dtLoaiNgayPhep = new DataTable();
            oLoaiPhuCap = new Business.HDQD.LoaiPhuCap();
        }

        private void LoaiNgayPhep_Load(object sender, EventArgs e)
        {
            try
            {
                
                dtLoaiPC = oLoaiPhuCap.GetList();

                InitListBox();
                ResetInterface(true);

                ReloadLoaiNgayPhep();

                
                dtgv_DS.ClearSelection();
            }
            catch (Exception)
            {
                
            }
            
        }

        void ReloadLoaiNgayPhep()
        {
            dtLoaiNgayPhep = oLoaiNgayPhep.GetData();
            dtLoaiNgayPhep_compact = oLoaiNgayPhep.GetData_Compact();

            if (dtLoaiNgayPhep != null && dtLoaiNgayPhep.Rows.Count > 0)
            {

                PrepareDataSource();
                EditDtgInterface();

            }
        }

        void InitListBox()
        {
            bLoadListBoxDone = false;
            if (dtLoaiPC != null && dtLoaiPC.Rows.Count >0)
            {
                lstb_DS.DataSource = dtLoaiPC;
                lstb_DS.DisplayMember = "ten_loai";
                lstb_DS.ValueMember = "id";
                lstb_DS.ClearSelected();
                bLoadListBoxDone = true;
            }
        }

        void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtLoaiNgayPhep_compact;
            dtgv_DS.DataSource = bs;
        }

        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtgv_DS.Columns["ten_loai_ngay_phep"].HeaderText = "Tên loại ngày phép";
            dtgv_DS.Columns["ten_loai_ngay_phep"].Width = 350;

            dtgv_DS.Columns["ghi_chu"].HeaderText = "Ghi chú";
            dtgv_DS.Columns["ghi_chu"].Width = 400;


            // An cac cot ID
            dtgv_DS.Columns["id_loai_ngay_phep"].Visible =              false;
        }

        private void ResetInterface(bool b)
        {

            btn_Them.Visible = btn_Sua.Visible = btn_Xoa.Visible = dtgv_DS.Enabled = lstb_DS.Enabled = b;
            txt_Ten.Enabled = rTB_GhiChu.Enabled =  numericUpDown1.Enabled =  btn_Luu.Visible = btn_Huy.Visible = !b;

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
            if (dtgv_DS.SelectedRows != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá loại ngày phép \"" + dtgv_DS.SelectedRows[0].Cells["ten_loai_ngay_phep"].Value.ToString() + "\" ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int id = Convert.ToInt32(dtgv_DS.SelectedRows[0].Cells["id_loai_ngay_phep"].Value);
                        oLoaiNgayPhep.Delete(id);
                        MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ReloadLoaiNgayPhep();
                        ResetInterface(true);
                        txt_Ten.Text = rTB_GhiChu.Text = "";
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xoá không thành công. Xin vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void dtgv_DS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_DS.SelectedRows != null)
            {
                bLoadListBoxDone = false;
                lstb_DS.ClearSelected();
                bLoadListBoxDone = true;

                DataRow dr = dtLoaiNgayPhep.AsEnumerable().Where(a => a.Field<int>("id_loai_ngay_phep") ==
                                                        Convert.ToInt16(dtgv_DS.SelectedRows[0].Cells["id_loai_ngay_phep"].Value)).First();

                txt_Ten.Text = dr["ten_loai_ngay_phep"].ToString();
                rTB_GhiChu.Text = dr["ghi_chu"].ToString();


            }
        }

        private void lstb_DS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bLoadListBoxDone)
            {
                int loai_pc_id = Convert.ToInt32(lstb_DS.SelectedValue);

                DataRow dr = dtLoaiNgayPhep.AsEnumerable().Where(a => a.Field<int>("id_loai_ngay_phep") ==
                                                        Convert.ToInt16(dtgv_DS.SelectedRows[0].Cells["id_loai_ngay_phep"].Value) && 
                                                                a.Field<int>("id_loai_pc") == loai_pc_id) .First();

                numericUpDown1.Value = Convert.ToDecimal(dr["phan_tram"]);
            }
        }
    }
}
