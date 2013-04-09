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
    public partial class LoaiHopDong : UserControl
    {
        bool bAddFlag;
        Business.HDQD.LoaiHopDong oLoaiHopDong;
        DataTable dtDSLoaiHopDong;


        public LoaiHopDong()
        {
            InitializeComponent();
            oLoaiHopDong = new Business.HDQD.LoaiHopDong();
        }

        private void LoaiHopDong_Load(object sender, EventArgs e)
        {
            ResetInterface(true);
            dtDSLoaiHopDong = oLoaiHopDong.GetList();
            if (dtDSLoaiHopDong != null)
            {
                PrepareDataSource();
                EditDtgInterface();
            }

            foreach (DataGridViewRow row in dtgv_DSLoaiHD.Rows)
            {
                if (row.Cells[3].Value.ToString() == "False")
                    row.Cells[3].Value = "Bien che";
            }
        }

        #region Private methods

        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtDSLoaiHopDong;
            dtgv_DSLoaiHD.DataSource = bs;
            lbl_SoLoaiHD.Text = dtgv_DSLoaiHD.Rows.Count.ToString();
            if (dtDSLoaiHopDong != null)
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
            dtgv_DSLoaiHD.Columns[1].Name = "Ten_Loai_Hop_Dong";
            dtgv_DSLoaiHD.Columns[1].HeaderText = "Tên loại hợp đồng";
            dtgv_DSLoaiHD.Columns[1].Width = 200;
            dtgv_DSLoaiHD.Columns[2].Name = "Mo_Ta";
            dtgv_DSLoaiHD.Columns[2].HeaderText = "Mô tả";
            dtgv_DSLoaiHD.Columns[2].Width = 500;
            dtgv_DSLoaiHD.Columns[3].Name = "BC_HD";
            dtgv_DSLoaiHD.Columns[3].HeaderText = "Biên chế hoặc hợp đồng?";
            //dtgv_DSLoaiHD.Columns[3].Width = 100;
            dtgv_DSLoaiHD.Columns[4].Name = "Co_Thoi_Han";
            dtgv_DSLoaiHD.Columns[4].HeaderText = "Có thời hạn?";
            // An cot ID
            dtgv_DSLoaiHD.Columns[0].Name = "ID";
            dtgv_DSLoaiHD.Columns[0].Visible = false;
        }

        /// <summary>
        /// Su dung thong tin row dang chon de hien thi len txt, comb,..
        /// </summary>
        /// <param name="row"></param>
        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_Ten.Text = row.Cells[1].Value.ToString();
                //txt_TenVietTat.Text = row.Cells[2].Value.ToString();
                rTB_MoTa.Text = row.Cells[2].Value.ToString();
                bool bienche_hd = Convert.ToBoolean(row.Cells[3].Value);
                if (bienche_hd == true)
                    comB_Loai.Text = "Biên chế";
                else
                    comB_Loai.Text = "Hợp đồng";

                bool co_thoihan = Convert.ToBoolean(row.Cells[4].Value);
                cb_ThoiHan.Checked = co_thoihan;

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
                txt_Ten.Enabled = comB_Loai.Enabled = cb_ThoiHan.Enabled = rTB_MoTa.Enabled = false;
                dtgv_DSLoaiHD.Enabled = true;
                if (dtgv_DSLoaiHD.CurrentRow != null)
                {
                    DisplayInfo(dtgv_DSLoaiHD.CurrentRow);
                }
            }
            else
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = false;
                btn_Huy.Visible = btn_Luu.Visible = true;
                txt_Ten.Enabled = comB_Loai.Enabled = cb_ThoiHan.Enabled = rTB_MoTa.Enabled = true;
                dtgv_DSLoaiHD.Enabled = false;

                if (bAddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_Ten.Text = rTB_MoTa.Text = "";
                    cb_ThoiHan.Checked = false;
                }
            }
        }

        /// <summary>
        /// Refresh Data Source cho dtg sau moi lan thao tac
        /// </summary>
        private void RefreshDataSource()
        {
            Business.HDQD.LoaiHopDong loaihd = new Business.HDQD.LoaiHopDong();
            dtDSLoaiHopDong = loaihd.GetList();
            PrepareDataSource();

        }

        #endregion

        private void dtgv_DSLoaiHD_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSLoaiHD.CurrentRow != null)
            {
                DisplayInfo(dtgv_DSLoaiHD.CurrentRow);
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            bAddFlag = true;
            ResetInterface(false);
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
            if (dtgv_DSLoaiHD.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá loại hợp đồng này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oLoaiHopDong.ID = Convert.ToInt16(dtgv_DSLoaiHD.CurrentRow.Cells[0].Value.ToString());
                        if (oLoaiHopDong.Delete())
                        {
                            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        RefreshDataSource();

                    }
                    catch (Exception )
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Ten.Text))
            {
                #region thao tac them

                if (bAddFlag)
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm loại hợp đồng này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oLoaiHopDong.Loai_Hop_Dong = txt_Ten.Text.Trim();
                        oLoaiHopDong.MoTa = rTB_MoTa.Text.Trim();
                        if (comB_Loai.Text == "Biên chế")
                            oLoaiHopDong.BienChe_HopDong = true;
                        else if (comB_Loai.Text == "Hợp đồng")
                            oLoaiHopDong.BienChe_HopDong = false;
                        else if (comB_Loai.Text == "")
                            MessageBox.Show("Phải chọn hình thức biên chế hoặc hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        oLoaiHopDong.Co_Thoi_Han = cb_ThoiHan.Checked;
                        try
                        {
                            if (oLoaiHopDong.Add())
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
                        oLoaiHopDong.ID = Convert.ToInt16(dtgv_DSLoaiHD.CurrentRow.Cells[0].Value.ToString());
                        oLoaiHopDong.Loai_Hop_Dong = txt_Ten.Text.Trim();
                        oLoaiHopDong.MoTa = rTB_MoTa.Text.Trim();
                        if (comB_Loai.Text == "Biên chế")
                            oLoaiHopDong.BienChe_HopDong = true;
                        else if (comB_Loai.Text == "Hợp đồng")
                            oLoaiHopDong.BienChe_HopDong = false;
                        else if (comB_Loai.Text == "")
                            MessageBox.Show("Phải chọn hình thức biên chế hoặc hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        oLoaiHopDong.Co_Thoi_Han = cb_ThoiHan.Checked;
                        try
                        {
                            if (oLoaiHopDong.Update())
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

        private void dtgv_DSLoaiHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[3].Name == "BC_HD")
            {
                //bool temp = (bool)e.Value;
                //e.Value = (bool)e.Value ? "Biên chế" : "Hợp đồng";
                //e.FormattingApplied = true;
            }
        }
    }
}
