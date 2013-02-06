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
    public partial class MoHinhDaoTao : UserControl
    {
        #region global variables

        bool bAddFlag;
        Business.MoHinhDaoTao oMoHinhDaoTao;
        DataTable dtDSMoHinh;

        #endregion
        

        public MoHinhDaoTao()
        {
            InitializeComponent();
            oMoHinhDaoTao = new Business.MoHinhDaoTao();
        }

        

        #region xu ly buttons

        private void btn_Them_Click(object sender, EventArgs e)
        {
            bAddFlag = true;
            ResetInterface(false);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgv_DSMoHinh.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá mô hình đào tạo này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {                    
                    try
                    {
                        oMoHinhDaoTao.ID = Convert.ToInt16(dtgv_DSMoHinh.CurrentRow.Cells[0].Value.ToString());
                        if (oMoHinhDaoTao.Delete())
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
            bAddFlag = false;
            ResetInterface(false);
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Ten.Text))
            {
                #region thao tac them

                if (bAddFlag)
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm mô hình này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oMoHinhDaoTao.TenMoHinh = txt_Ten.Text.Trim();
                        oMoHinhDaoTao.MoTa = rtb_MoTa.Text.Trim();
                        try
                        {
                            if (oMoHinhDaoTao.Add())
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
                        oMoHinhDaoTao.ID = Convert.ToInt16(dtgv_DSMoHinh.CurrentRow.Cells[0].Value.ToString());
                        oMoHinhDaoTao.TenMoHinh = txt_Ten.Text.Trim();
                        oMoHinhDaoTao.MoTa = rtb_MoTa.Text.Trim();
                        try
                        {
                            if (oMoHinhDaoTao.Update())
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
                MessageBox.Show("Tên mô hình không được rỗng, xin vui lòng cung cấp tên mô hình", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ResetInterface(true);
        }

        #endregion

        

        #region xu ly giao dien

        private void dtgv_DSMoHinh_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSMoHinh.CurrentRow != null)
            {
                DisplayInfo(dtgv_DSMoHinh.CurrentRow);
            }
        }

        private void MoHinhDaoTao_Load(object sender, EventArgs e)
        {
            dtDSMoHinh = oMoHinhDaoTao.GetData();
            if (dtDSMoHinh != null)
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
                txt_Ten.Enabled = rtb_MoTa.Enabled = false;
                dtgv_DSMoHinh.Enabled = true;
                if (dtgv_DSMoHinh.CurrentRow != null)
                {
                    DisplayInfo(dtgv_DSMoHinh.CurrentRow);
                }
            }
            else
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = false;
                btn_Huy.Visible = btn_Luu.Visible = true;
                txt_Ten.Enabled = rtb_MoTa.Enabled = true;
                dtgv_DSMoHinh.Enabled = false;

                if (bAddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_Ten.Text = rtb_MoTa.Text = "";
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
                txt_Ten.Text = row.Cells[1].Value.ToString(); ;
                rtb_MoTa.Text = row.Cells[2].Value.ToString(); ;
            }
        }

        /// <summary>
        /// Refresh Data Source cho dtg sau moi lan thao tac
        /// </summary>
        private void RefreshDataSource()
        {
            Business.MoHinhDaoTao mh = new Business.MoHinhDaoTao();     // khong dung chung oChucVu duoc ???
            dtDSMoHinh = mh.GetData();
            PrepareDataSource();
            
        }

        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtDSMoHinh;
            dtgv_DSMoHinh.DataSource = bs;
            lbl_SoVanBang.Text = dtgv_DSMoHinh.Rows.Count.ToString();
            if (dtDSMoHinh != null)
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
            dtgv_DSMoHinh.Columns[1].HeaderText = "Tên mô hình";
            dtgv_DSMoHinh.Columns[1].Width = 300;
            dtgv_DSMoHinh.Columns[2].HeaderText = "Mô tả";
            dtgv_DSMoHinh.Columns[2].Width = 500;
            // An cot ID
            dtgv_DSMoHinh.Columns[0].Visible = false;
        }

        #endregion
    }

    
}