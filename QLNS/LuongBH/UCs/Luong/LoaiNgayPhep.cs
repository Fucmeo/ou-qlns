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
        bool  bLoadListBoxDone ;
        bool? bAdd = null;
        Business.Luong.LoaiNgayPhep oLoaiNgayPhep;
        Business.HDQD.LoaiPhuCap oLoaiPhuCap;
        DataTable dtLoaiNgayPhep , dtLoaiNgayPhep_compact;
        DataTable dtLoaiPC;
        List<KeyValuePair<int, double>> PC_PhanTram;

        public LoaiNgayPhep()
        {
            InitializeComponent();
            oLoaiNgayPhep = new Business.Luong.LoaiNgayPhep();
            dtLoaiNgayPhep_compact = new DataTable();
            dtLoaiNgayPhep = new DataTable();
            oLoaiPhuCap = new Business.HDQD.LoaiPhuCap();
            PC_PhanTram = new List<KeyValuePair<int, double>>();
            
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
            //dtLoaiNgayPhep = oLoaiNgayPhep.GetData();
            //dtLoaiNgayPhep_compact = oLoaiNgayPhep.GetData_Compact();

            //if (dtLoaiNgayPhep != null && dtLoaiNgayPhep.Rows.Count > 0)
            //{

            //    PrepareDataSource();
            //    EditDtgInterface();

            //}
        }

        void InitListBox()
        {
            bLoadListBoxDone = false;
            if (dtLoaiPC != null && dtLoaiPC.Rows.Count >0)
            {
                // them row Lương de add vao listbox
                DataRow newrow = dtLoaiPC.NewRow();
                newrow["ten_loai"] = "Lương";
                newrow["id"] = 0;

                dtLoaiPC.Rows.Add(newrow);

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

            btn_Them.Visible = btn_Sua.Visible = btn_Xoa.Visible = dtgv_DS.Enabled  =  b;
            txt_Ten.Enabled = rTB_GhiChu.Enabled =  numericUpDown1.Enabled =  btn_Luu.Visible = btn_Huy.Visible = !b;

        }

        // khi them moi loai ngay phep
        void Init_New_PC_PhanTram()
        {
            PC_PhanTram = new List<KeyValuePair<int, double>>();
            for (int i = 0; i < dtLoaiPC.Rows.Count; i++)
            {
                PC_PhanTram.Add(new KeyValuePair<int,double>(Convert.ToInt32(dtLoaiPC.Rows[i]["id"]),100));
            }
            //PC_PhanTram.Add(new KeyValuePair<int, double>(0, 100)); // Add cho luong
        }


        // khi dang update loai ngay phep
        void Assign_PC_PhanTram_When_Update()
        {
            PC_PhanTram = new List<KeyValuePair<int, double>>();

            int cach_tinh_count = dtLoaiNgayPhep.AsEnumerable().Where(a => a.Field<int>("id_loai_ngay_phep") ==
                                                            Convert.ToInt16(dtgv_DS.SelectedRows[0].Cells["id_loai_ngay_phep"].Value)).Count();

            DataRow[] dr = dtLoaiNgayPhep.AsEnumerable().Where(a => a.Field<int>("id_loai_ngay_phep") ==
                                                            Convert.ToInt16(dtgv_DS.SelectedRows[0].Cells["id_loai_ngay_phep"].Value)).ToArray();

            for (int i = 0; i < cach_tinh_count; i++)
            {
                
                double phan_tram = Convert.ToDouble(dr[i]["phan_tram"]);

                PC_PhanTram.Add(new KeyValuePair<int, double>(Convert.ToInt32(dr[i]["id_loai_pc"]), phan_tram));
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ResetInterface(false);
            txt_Ten.Text = rTB_GhiChu.Text = "";
            lstb_DS.ClearSelected();
            numericUpDown1.Value = 100;
            bAdd = true;
            Init_New_PC_PhanTram();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ResetInterface(true);
            txt_Ten.Text = rTB_GhiChu.Text = "";
            lstb_DS.ClearSelected();
            numericUpDown1.Value = 100;
            bAdd = null;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (dtgv_DS.SelectedRows != null)
            {
                ResetInterface(false);
                bAdd = false;
                Assign_PC_PhanTram_When_Update();
            }
            else
            {
                MessageBox.Show("Xin vui lòng chọn 1 loại ngày phép để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            //if (bAdd == true)
            //{
            //    if ( txt_Ten.Text != "" )
            //    {
            //        if (MessageBox.Show("Bạn thực sự muốn thêm loại ngày phép \"" + txt_Ten.Text + "\" ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            try
            //            {
            //                int[] a_pc_id = new int[PC_PhanTram.Count];
            //                double[] a_phan_tram = new double[PC_PhanTram.Count];

            //                for (int i = 0; i < PC_PhanTram.Count; i++)
            //                {
            //                    a_pc_id[i] = PC_PhanTram[i].Key;
            //                    a_phan_tram[i] = PC_PhanTram[i].Value;
            //                }

            //                oLoaiNgayPhep.Add(txt_Ten.Text, rTB_GhiChu.Text, a_pc_id, a_phan_tram);
            //                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //                ReloadLoaiNgayPhep();
            //                ResetInterface(true);
            //                txt_Ten.Text = rTB_GhiChu.Text = "";
            //            }
            //            catch (Exception)
            //            {
            //                MessageBox.Show("Thêm không thành công. Xin vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            }
                        
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Tên loại ngày phép không được để rỗng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //else
            //{
            //    if (txt_Ten.Text != "")
            //    {
            //        if (MessageBox.Show("Bạn thực sự muốn sửa loại ngày phép \"" + txt_Ten.Text + "\" ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            try
            //            {
            //                int[] a_pc_id = new int[PC_PhanTram.Count];
            //                double[] a_phan_tram = new double[PC_PhanTram.Count];

            //                for (int i = 0; i < PC_PhanTram.Count; i++)
            //                {
            //                    a_pc_id[i] = PC_PhanTram[i].Key;
            //                    a_phan_tram[i] = PC_PhanTram[i].Value;
            //                }

            //                oLoaiNgayPhep.Update(Convert.ToInt16(dtgv_DS.SelectedRows[0].Cells["id_loai_ngay_phep"].Value), txt_Ten.Text, rTB_GhiChu.Text, a_pc_id, a_phan_tram);
            //                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //                ReloadLoaiNgayPhep();
            //                ResetInterface(true);
            //                txt_Ten.Text = rTB_GhiChu.Text = "";
            //            }
            //            catch (Exception)
            //            {
            //                MessageBox.Show("Sửa không thành công. Xin vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            }

            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Tên loại ngày phép không được để rỗng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}

            //bAdd = null;
            //ResetInterface(true);
            //txt_Ten.Text = rTB_GhiChu.Text = "";
            //lstb_DS.ClearSelected();
            //numericUpDown1.Value = 100;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            //if (dtgv_DS.SelectedRows != null)
            //{
            //    if (MessageBox.Show("Bạn thực sự muốn xoá loại ngày phép \"" + dtgv_DS.SelectedRows[0].Cells["ten_loai_ngay_phep"].Value.ToString() + "\" ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            int id = Convert.ToInt32(dtgv_DS.SelectedRows[0].Cells["id_loai_ngay_phep"].Value);
            //            oLoaiNgayPhep.Delete(id);
            //            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            ReloadLoaiNgayPhep();
            //            ResetInterface(true);
            //            txt_Ten.Text = rTB_GhiChu.Text = "";
            //        }
            //        catch (Exception)
            //        {
            //            MessageBox.Show("Xoá không thành công. Xin vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //    }
            //}
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
            if (bLoadListBoxDone )
            {
                int loai_pc_id = Convert.ToInt32(lstb_DS.SelectedValue);
                if (bAdd == null)
                {
                    DataRow dr = dtLoaiNgayPhep.AsEnumerable().Where(a => a.Field<int>("id_loai_ngay_phep") ==
                                                            Convert.ToInt16(dtgv_DS.SelectedRows[0].Cells["id_loai_ngay_phep"].Value) &&
                                                                    a.Field<int>("id_loai_pc") == loai_pc_id).First();

                    numericUpDown1.Value = Convert.ToDecimal(dr["phan_tram"]);
                }
                else
                {
                    double phan_tram_new=100;
                    for (int i = 0; i < PC_PhanTram.Count; i++)
                    {
                        if (PC_PhanTram[i].Key==loai_pc_id)
                        {
                            phan_tram_new = PC_PhanTram[i].Value;
                            break;
                        }
                    }
                    numericUpDown1.Value = Convert.ToDecimal(phan_tram_new);

                }
                
            }

        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
            int loai_pc_id = Convert.ToInt32(lstb_DS.SelectedValue);

            for (int i = 0; i < PC_PhanTram.Count; i++)
            {
                if (PC_PhanTram[i].Key == loai_pc_id)
                {
                    PC_PhanTram.RemoveAt(i);
                    PC_PhanTram.Add(new KeyValuePair<int, double>(loai_pc_id,Convert.ToDouble(numericUpDown1.Value)));
                    break;
                }
            }
        }

        private void dtgv_DS_SelectionChanged(object sender, EventArgs e)
        {
            
        }
    }
}
