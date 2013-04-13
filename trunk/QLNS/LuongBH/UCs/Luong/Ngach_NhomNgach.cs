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
    public partial class Ngach_NhomNgach : UserControl
    {
        #region global variables

        //public class clsNgach_NhomNgach
        //{
        //    public int NhomNgachID { get; set; }
        //    public string TenNhomNgach { get; set; }
        //    public string MaNgach { get; set; }
        //    public string TenNgach { get; set; }

        //    public clsNgach_NhomNgach() { }
        //}

        bool bAddFlag;
        //DataTable dtNgach, dtNhomNgach , dtNgach_NhomNgach;
        List<Business.Luong.NhomNgach> lstNhomNgach;
        List<Business.Luong.Ngach> lstNgach;
        TreeNode SelectedNode;
        Business.Luong.NhomNgach oNhomNgach;
        Business.Luong.Ngach oNgach;
        bool AddEditNhomNgach;      // true khi thao tac vs NhomNgach, false thi vs Ngach
        //List<clsNgach_NhomNgach> lstNgach_NhomNgach;
        #endregion

        public Ngach_NhomNgach()
        {
            InitializeComponent();
            //lstNgach_NhomNgach = new List<clsNgach_NhomNgach>();
            //dtNgach = new DataTable();
            //dtNhomNgach = new DataTable();
            //dtNgach_NhomNgach = new DataTable();

            lstNgach = new List<Business.Luong.Ngach>();
            lstNhomNgach = new List<Business.Luong.NhomNgach>();
            oNhomNgach = new Business.Luong.NhomNgach();
            oNgach = new Business.Luong.Ngach();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Ngach_NhomNgach_Load(object sender, EventArgs e)
        {
            GetNgach_NhomNgach();

            if (lstNhomNgach != null)
            {
                //JoinNgach_NhomNgach();
                UpdateTreeVDonVi();
                TreeV_Ngach_NhomNgach.ExpandAll();
                FillNhomNgachCombo();
            }
            comB_NhomNgach.SelectedIndex = -1;
        }

        private void FillNhomNgachCombo()
        {

            comB_NhomNgach.DataSource = lstNhomNgach;
            comB_NhomNgach.ValueMember = "ID";
            comB_NhomNgach.DisplayMember = "TenNhomNgach";
        }

        private void GetNgach_NhomNgach()
        {
            lstNgach = oNgach.GetList();
            lstNhomNgach = oNhomNgach.GetList();
        }

        //private void JoinNgach_NhomNgach()
        //{
        //    var vNgach_NhomNgach = from a in lstNhomNgach
        //                          join b in lstNgach on a.ID equals b.NhomNgachID
        //                           select new clsNgach_NhomNgach { TenNhomNgach = a.TenNhomNgach, MaNgach = b.MaNgach, 
        //                                                            TenNgach =  b.TenNgach, NhomNgachID = b.NhomNgachID };

        //    lstNgach_NhomNgach = vNgach_NhomNgach.ToList<clsNgach_NhomNgach>();
        //}

       

        /// <summary> 
        /// Ham de quy , add cac don vi vao tree view
        /// </summary>
        private void UpdateTreeVDonVi()
        {
            TreeV_Ngach_NhomNgach.Nodes.Clear();
            TreeNode newNode;
             TreeNode parentNode ;
             for (int i = 0; i < lstNhomNgach.Count; i++)
             {
                 newNode = new TreeNode();
                 newNode.Name = lstNhomNgach[i].ID.ToString();
                 newNode.Text = lstNhomNgach[i].TenNhomNgach;
                 TreeV_Ngach_NhomNgach.Nodes.Add(newNode);
             }

             for (int i = 0; i < lstNhomNgach.Count; i++)
             {
                 parentNode = TreeV_Ngach_NhomNgach.Nodes[lstNhomNgach[i].ID.ToString()];
                 List<Business.Luong.Ngach> lstNgachCon = lstNgach.Where(a => a.NhomNgachID == Convert.ToInt32(parentNode.Name)).ToList();
                 for (int y = 0; y < lstNgachCon.Count; y++)
                 {
                     newNode = new TreeNode();
                     newNode.Name = lstNgachCon[y].MaNgach;
                     newNode.Text = lstNgachCon[y].TenNgach;
                     TreeV_Ngach_NhomNgach.Nodes[lstNhomNgach[i].ID.ToString()].Nodes.Add(newNode);
                 }


             }

             TreeV_Ngach_NhomNgach.ExpandAll();
        }

       

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (SelectedNode != null)
            {
                bAddFlag = false;
                ResetInterface(false);            
            }
            
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (SelectedNode != null &&
                        MessageBox.Show("Bạn muốn xoá ngạch / nhóm ngạch này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (SelectedNode.Level == 0) 
                {
                    oNhomNgach.ID = Convert.ToInt32(SelectedNode.Name);
                    try
                    {
                        oNhomNgach.Delete();
                        GetNgach_NhomNgach();
                        UpdateTreeVDonVi();
                        MessageBox.Show("Xoá nhóm ngạch thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_MaNgach.Text = txt_TenNgach.Text = "";
                        comB_NhomNgach.SelectedIndex = -1;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xoá nhóm ngạch không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    oNgach.MaNgach = Convert.ToString(SelectedNode.Name);
                    try
                    {
                        oNgach.Delete();
                        GetNgach_NhomNgach();
                        UpdateTreeVDonVi();
                        MessageBox.Show("Xoá ngạch thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xoá ngạch không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            #region Thêm
            if (bAddFlag)
            {
                if (AddEditNhomNgach)       // Nhom ngach
                {
                    if (!string.IsNullOrWhiteSpace(txt_TenNgach.Text) &&
                        MessageBox.Show("Bạn muốn thêm nhóm ngạch này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oNhomNgach.TenNhomNgach = txt_TenNgach.Text.Trim();
                        try
                        {
                            oNhomNgach.Add();
                            GetNgach_NhomNgach();
                            UpdateTreeVDonVi();
                            FillNhomNgachCombo();
                            MessageBox.Show("Thêm nhóm ngạch thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetInterface(true);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Thêm nhóm ngạch không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên ngạch / nhóm ngạch không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else        // Ngach
                {
                    if (!string.IsNullOrWhiteSpace(txt_TenNgach.Text) && !string.IsNullOrWhiteSpace(txt_MaNgach.Text) &&
                        MessageBox.Show("Bạn muốn thêm ngạch này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oNgach.TenNgach = txt_TenNgach.Text.Trim();
                        oNgach.MaNgach = txt_MaNgach.Text.Trim();
                        oNgach.NhomNgachID = Convert.ToInt32(comB_NhomNgach.SelectedValue);
                        try
                        {
                            oNgach.Add();
                            GetNgach_NhomNgach();
                            UpdateTreeVDonVi();
                            FillNhomNgachCombo();
                            MessageBox.Show("Thêm ngạch thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetInterface(true);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Thêm ngạch không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã và tên ngạch không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                
            } 
            #endregion

            #region Sửa
            else
            {
                if (AddEditNhomNgach)       // Nhom ngach
                {
                    if (!string.IsNullOrWhiteSpace(txt_TenNgach.Text) &&
                        MessageBox.Show("Bạn muốn sửa nhóm ngạch này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oNhomNgach.TenNhomNgach = txt_TenNgach.Text.Trim();
                        oNhomNgach.ID = Convert.ToInt32(SelectedNode.Name);
                        try
                        {
                            oNhomNgach.Update();
                            GetNgach_NhomNgach();
                            UpdateTreeVDonVi();
                            MessageBox.Show("sửa nhóm ngạch thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetInterface(true);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("sửa nhóm ngạch không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên ngạch / nhóm ngạch không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else        // Ngach
                {
                    if (!string.IsNullOrWhiteSpace(txt_TenNgach.Text) && !string.IsNullOrWhiteSpace(txt_MaNgach.Text) &&
                        MessageBox.Show("Bạn muốn sửa ngạch này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oNgach.TenNgach = txt_TenNgach.Text.Trim();
                        oNgach.MaNgach = SelectedNode.Name.ToString();
                        oNgach.NhomNgachID = Convert.ToInt32(comB_NhomNgach.SelectedValue);
                        try
                        {
                            if(txt_MaNgach.Text == SelectedNode.Name.ToString()) oNgach.Update(null);
                            else oNgach.Update(txt_MaNgach.Text.Trim());
                            GetNgach_NhomNgach();
                            UpdateTreeVDonVi();
                            MessageBox.Show("sửa ngạch thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetInterface(true);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("sửa ngạch không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã và tên ngạch không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } 
            #endregion

            txt_MaNgach.Text = txt_TenNgach.Text = "";
            if (lstNhomNgach.Count > 0 && !bAddFlag)
            {
                comB_NhomNgach.SelectedIndex = -1;
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ResetInterface(true);
        }

        private void TSMI_ThemNhomNgach_Click(object sender, EventArgs e)
        {
            bAddFlag = true;
            AddEditNhomNgach = true;
            ResetInterface(false);
            txt_MaNgach.Enabled = comB_NhomNgach.Enabled = false;
            comB_NhomNgach.SelectedIndex = -1;
        }

        private void TSMI_ThemNgach_Click(object sender, EventArgs e)
        {
            bAddFlag = true;
            AddEditNhomNgach = false;
            ResetInterface(false);
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
                txt_MaNgach.Enabled = txt_TenNgach.Enabled = comB_NhomNgach.Enabled = false;
                TreeV_Ngach_NhomNgach.Enabled = true;
            }
            else
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = false;
                btn_Huy.Visible = btn_Luu.Visible = true;
                txt_MaNgach.Enabled = txt_TenNgach.Enabled = comB_NhomNgach.Enabled = true;
                TreeV_Ngach_NhomNgach.Enabled = false;

                if (bAddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_MaNgach.Text = txt_TenNgach.Text = "";
                    if(comB_NhomNgach.Items.Count > 0)
                        comB_NhomNgach.SelectedIndex = 0;
                }
            }
            
        }

        private void TreeV_Ngach_NhomNgach_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectedNode = TreeV_Ngach_NhomNgach.SelectedNode;
            if (SelectedNode != null)
            {
                if (SelectedNode.Level == 0)
                {
                    txt_MaNgach.Text = "";
                    txt_TenNgach.Text = SelectedNode.Text;
                    comB_NhomNgach.SelectedIndex = -1;
                    SelectedNode.ExpandAll();
                }
                else
                {
                    txt_TenNgach.Text = SelectedNode.Text;
                    txt_MaNgach.Text = SelectedNode.Name;
                    int NhomNgachID = Convert.ToInt32(lstNgach.Where(a => a.MaNgach == SelectedNode.Name).Select(a => a.NhomNgachID).First());
                    comB_NhomNgach.SelectedValue = NhomNgachID;
                } 
            }
            
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            Point ptLowerLeft = new Point(0, btn_Them.Height);
            ptLowerLeft = btn_Them.PointToScreen(ptLowerLeft);
            contextMenuStrip1.Show(ptLowerLeft);
        }
    }
}
