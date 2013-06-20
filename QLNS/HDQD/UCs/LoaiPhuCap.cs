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
    public partial class LoaiPhuCap : UserControl
    {
        bool bAddFlag;
        Business.HDQD.LoaiPhuCap oLoaiPhuCap;
        DataTable dtDSLoaiPhuCap;


        public LoaiPhuCap()
        {
            InitializeComponent();
            oLoaiPhuCap = new Business.HDQD.LoaiPhuCap();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            bAddFlag = true;
            ResetInterface(false);
        }

        private void LoaiPhuCap_Load(object sender, EventArgs e)
        {
            ResetInterface(true);
            dtDSLoaiPhuCap = oLoaiPhuCap.GetList();
            if (dtDSLoaiPhuCap != null)
            {
                PrepareDataSource();
                //EditDtgInterface();
            }
        }

        #region Private methods
        
        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtDSLoaiPhuCap;
            //dtgv_DSLoaiPC.DataSource = bs;
            //lbl_SoLoaiPC.Text = dtgv_DSLoaiPC.Rows.Count.ToString();
            if (dtDSLoaiPhuCap != null)
            {
                btn_Sua.Visible = btn_Xoa.Visible = true;
            }
        }

        /// <summary>
        /// Sua ten, an  cac cot cua dtg cho phu hop
        /// </summary>
        //private void EditDtgInterface()
        //{
        //    // Dat ten cho cac cot
        //    dtgv_DSLoaiPC.Columns[1].HeaderText = "Tên loại phụ cấp";
        //    dtgv_DSLoaiPC.Columns[1].Width = 300;
        //    dtgv_DSLoaiPC.Columns[2].HeaderText = "Tên viết tắt";
        //    dtgv_DSLoaiPC.Columns[2].Width = 100;
        //    dtgv_DSLoaiPC.Columns[3].HeaderText = "Mô tả";
        //    dtgv_DSLoaiPC.Columns[3].Width = 500;
        //    // An cot ID
        //    dtgv_DSLoaiPC.Columns[0].Visible = false;
        //}

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
            //if (init)
            //{
            //    btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = true;
            //    btn_Huy.Visible = btn_Luu.Visible = false;
            //    txt_Ten.Enabled = txt_TenVietTat.Enabled = rTB_MoTa.Enabled = false;
            //    dtgv_DSLoaiPC.Enabled = true;
            //    if (dtgv_DSLoaiPC.CurrentRow != null)
            //    {
            //        DisplayInfo(dtgv_DSLoaiPC.CurrentRow);
            //    }
            //}
            //else
            //{
            //    btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = false;
            //    btn_Huy.Visible = btn_Luu.Visible = true;
            //    txt_Ten.Enabled = txt_TenVietTat.Enabled = rTB_MoTa.Enabled = true;
            //    dtgv_DSLoaiPC.Enabled = false;

            //    if (bAddFlag) // thao tac them moi xoa rong cac field
            //    {
            //        txt_Ten.Text = txt_TenVietTat.Text = rTB_MoTa.Text = "";
            //    }
            //}
        }

        /// <summary>
        /// Refresh Data Source cho dtg sau moi lan thao tac
        /// </summary>
        private void RefreshDataSource()
        {
            Business.HDQD.LoaiPhuCap loaipc = new Business.HDQD.LoaiPhuCap();    // khong dung chung oChucVu duoc ???
            dtDSLoaiPhuCap = loaipc.GetList();
            PrepareDataSource();

        }

        #endregion

        private void dtgv_DSLoaiPC_SelectionChanged(object sender, EventArgs e)
        {
            //if (dtgv_DSLoaiPC.CurrentRow != null)
            //{
            //    DisplayInfo(dtgv_DSLoaiPC.CurrentRow);
            //}
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
            //if (dtgv_DSLoaiPC.CurrentRow != null)
            //{
            //    if (MessageBox.Show("Bạn thực sự muốn xoá loại phụ cấp này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            oLoaiPhuCap.ID = Convert.ToInt16(dtgv_DSLoaiPC.CurrentRow.Cells[0].Value.ToString());
            //            if (oLoaiPhuCap.Delete())
            //            {
            //                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            RefreshDataSource();

            //        }
            //        catch (Exception )
            //        {
            //            MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            //    }
            //}
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
                        oLoaiPhuCap.TenLoaiPhuCap = txt_Ten.Text.Trim();
                        oLoaiPhuCap.TenLoaiPC_Viettat = txt_TenVietTat.Text.Trim();
                        oLoaiPhuCap.MoTa = rTB_MoTa.Text.Trim();
                        try
                        {
                            if (oLoaiPhuCap.Add())
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
                        //oLoaiPhuCap.ID = Convert.ToInt16(dtgv_DSLoaiPC.CurrentRow.Cells[0].Value.ToString());
                        oLoaiPhuCap.TenLoaiPhuCap = txt_Ten.Text.Trim();
                        oLoaiPhuCap.TenLoaiPC_Viettat = txt_TenVietTat.Text.Trim();
                        oLoaiPhuCap.MoTa = rTB_MoTa.Text.Trim();
                        try
                        {
                            if (oLoaiPhuCap.Update())
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

        private void rdb_CheckedChanged(object sender, EventArgs e)
        {
            switch (((RadioButton)sender).Name)
            {
                case "rdb_Khoan":
                    TLP_CachTinh.Visible = false;
                    break;
                case "rdb_HeSo":
                    TLP_CachTinh.Visible = true;
                    lb_HeSo.Visible = comb_Luong.Visible = true;
                    TLP_CachTinh.RowStyles[1].SizeType = TLP_CachTinh.RowStyles[0].SizeType = SizeType.Percent;
                    TLP_CachTinh.RowStyles[1].Height = 1;
                    TLP_CachTinh.RowStyles[0].Height = 99;
                    break;

                case "rdb_CongThuc":
                    TLP_CachTinh.Visible = true;
                    lb_HeSo.Visible = comb_Luong.Visible = false;
                    TLP_CachTinh.RowStyles[0].SizeType = TLP_CachTinh.RowStyles[1].SizeType = SizeType.Percent;
                    TLP_CachTinh.RowStyles[0].Height = 1;
                    TLP_CachTinh.RowStyles[1].Height = 99;
                    break;
                default:
                    break;
            }
        }

        private void btn_ThietLap_Click(object sender, EventArgs e)
        {
            Forms.Popup frPopup = new Forms.Popup(new UCs.DinhNghiaCT(), "QUẢN LÝ NHÂN SỰ - ĐỊNH NGHĨA CÔNG THỨC TÍNH PHỤ CẤP");
            frPopup.ShowDialog();
        }


        private void rtb_CongThuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
