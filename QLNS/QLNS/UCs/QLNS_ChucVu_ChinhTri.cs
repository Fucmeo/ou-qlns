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
    public partial class QLNS_ChucVu_ChinhTri : UserControl
    {
        //QLNS.UCs.DanhMucThongTin.QLNS_ChinhTri m_UC_Chinh_Tri;
        Business.ChucVu_ChinhTri oChucVu_ChTri;
        DataTable dtChucVu_ChTri;
        bool bAddFlag;

        public QLNS_ChucVu_ChinhTri()
        {
            InitializeComponent();
            oChucVu_ChTri = new ChucVu_ChinhTri();

            //m_UC_Chinh_Tri = p_UC_Chinh_Tri;
        }

        private void QLNS_ChucVu_ChinhTri_Load(object sender, EventArgs e)
        {
            dtChucVu_ChTri = oChucVu_ChTri.GetData();
            if (dtChucVu_ChTri != null)
            {
                PrepareDataSource();
                EditDtgInterface();
            }

            ResetInterface(true);
        }

        #region Private Methods
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
                txt_Ten.Enabled = comB_Loai.Enabled = false;
                dtgv_DSChucVuDonVi.Enabled = true;
                if (dtgv_DSChucVuDonVi.CurrentRow != null)
                {
                    DisplayInfo(dtgv_DSChucVuDonVi.CurrentRow);
                }
            }
            else
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = false;
                btn_Huy.Visible = btn_Luu.Visible = true;
                txt_Ten.Enabled = comB_Loai.Enabled = true;
                dtgv_DSChucVuDonVi.Enabled = false;

                if (bAddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_Ten.Text = "";
                }
            }
        }

        /// <summary>
        /// Su dung thong tin row dang chon de hien thi len txt, comb,..
        /// </summary>
        /// <param name="row"></param>
        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_Ten.Text = row.Cells["ten_chuc_vu"].Value.ToString();
                comB_Loai.Text = row.Cells["ten_loai_chinh_tri"].Value.ToString();
            }
        }

        /// <summary>
        /// Refresh Data Source cho dtg sau moi lan thao tac
        /// </summary>
        private void RefreshDataSource()
        {
            Business.ChucVu_ChinhTri cv = new ChucVu_ChinhTri();
            dtChucVu_ChTri = cv.GetData();
            PrepareDataSource();

        }

        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtChucVu_ChTri;
            dtgv_DSChucVuDonVi.DataSource = bs;
            //lbl_SoChucVu.Text = dtgv_DSChucVu.Rows.Count.ToString();
            if (dtChucVu_ChTri != null)
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
            dtgv_DSChucVuDonVi.Columns["ten_chuc_vu"].HeaderText = "Tên chức vụ";
            dtgv_DSChucVuDonVi.Columns["ten_chuc_vu"].Width = 250;
            dtgv_DSChucVuDonVi.Columns["ten_loai_chinh_tri"].HeaderText = "Tên loại chính trị";
            dtgv_DSChucVuDonVi.Columns["ten_loai_chinh_tri"].Width = 250;
            // An cot ID
            dtgv_DSChucVuDonVi.Columns["id"].Visible = false;
            dtgv_DSChucVuDonVi.Columns["loai_chinh_tri_id"].Visible = false;
        }


        #endregion

        private void dtgv_DSChucVuDonVi_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSChucVuDonVi.CurrentRow != null)
            {
                DisplayInfo(dtgv_DSChucVuDonVi.CurrentRow);
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            bAddFlag = true;
            ResetInterface(false);
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (dtgv_DSChucVuDonVi.Rows.Count > 0)
            {
                bAddFlag = false;
                ResetInterface(false);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ResetInterface(true);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgv_DSChucVuDonVi.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá chức vụ chính trị này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oChucVu_ChTri.ID = Convert.ToInt16(dtgv_DSChucVuDonVi.CurrentRow.Cells["id"].Value.ToString());
                        if (oChucVu_ChTri.Delete())
                        {
                            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        QLNS.UCs.DanhMucThongTin.QLNS_ChinhTri.is_Modified_Ctri_CVu = true;
                        RefreshDataSource();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Ten.Text))
            {
                oChucVu_ChTri = new ChucVu_ChinhTri();
                oChucVu_ChTri.Ten = txt_Ten.Text.Trim();
                string loai_chinh_tri = comB_Loai.Text.Trim();
                switch (loai_chinh_tri)
                {
                    case "Đoàn viên":
                        oChucVu_ChTri.LoaiChinhTri_ID = 1;
                        break;
                    case "Đảng viên":
                        oChucVu_ChTri.LoaiChinhTri_ID = 2;
                        break;
                    case "Dân quân tự vệ":
                        oChucVu_ChTri.LoaiChinhTri_ID = 3;
                        break;
                    case "Công đoàn viên":
                        oChucVu_ChTri.LoaiChinhTri_ID = 4;
                        break;
                    default:
                        break;
                }

                #region thao tac them

                if (bAddFlag)
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm chức vụ chính trị này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                        try
                        {
                            if (oChucVu_ChTri.Add())
                            {
                                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            QLNS.UCs.DanhMucThongTin.QLNS_ChinhTri.is_Modified_Ctri_CVu = true;
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
                    if (MessageBox.Show("Bạn thực sự muốn sửa chức vụ chính trị này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oChucVu_ChTri.ID = Convert.ToInt16(dtgv_DSChucVuDonVi.CurrentRow.Cells["id"].Value.ToString());
                        try
                        {
                            if (oChucVu_ChTri.Update())
                            {
                                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            QLNS.UCs.DanhMucThongTin.QLNS_ChinhTri.is_Modified_Ctri_CVu = true;
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
                MessageBox.Show("Tên chức vụ không được rỗng, xin vui lòng cung cấp đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
