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
    public partial class QLNS_QuocGiaTP : UserControl
    {
        #region global variables



        bool bAddFlag;
        //DataTable dtTinhTP, dtQuocGia , dtTinhTP_QuocGia;
        List<Business.QuocGia> lstQuocGia;
        List<Business.TinhTP> lstTP;
        TreeNode SelectedNode;
        Business.QuocGia oQuocGia;
        Business.TinhTP oTinhTP;
        bool AddSuccess = false;
        bool AddEditQuocGia;      // true khi thao tac vs QuocGia, false thi vs TinhTP
        //List<clsTinhTP_QuocGia> lstTP_QuocGia;
        #endregion

        public QLNS_QuocGiaTP()
        {
            InitializeComponent();

            lstTP = new List<Business.TinhTP>();
            lstQuocGia = new List<Business.QuocGia>();
            oQuocGia = new Business.QuocGia();
            oTinhTP = new Business.TinhTP();
        }

        private void QLNS_QuocGiaTP_Load(object sender, EventArgs e)
        {
            GetTinhTP_QuocGia();

            if (lstQuocGia != null)
            {
                //JoinTinhTP_QuocGia();
                UpdateTreeVDonVi();
                TreeV_QuocGiaTP.ExpandAll();
                FillQuocGiaCombo();
            }
            comB_QuocGia.SelectedIndex = -1;
        }

        private void GetTinhTP_QuocGia()
        {
            lstTP = oTinhTP.GetList();
            lstQuocGia = oQuocGia.GetList();
        }

        /// <summary> 
        /// Ham de quy , add cac don vi vao tree view
        /// </summary>
        private void UpdateTreeVDonVi()
        {
            TreeV_QuocGiaTP.Nodes.Clear();
            TreeNode newNode;
            TreeNode parentNode;
            for (int i = 0; i < lstQuocGia.Count; i++)
            {
                newNode = new TreeNode();
                newNode.Name = lstQuocGia[i].ID.ToString();
                newNode.Text = lstQuocGia[i].TenQuocGia;
                TreeV_QuocGiaTP.Nodes.Add(newNode);
            }

            for (int i = 0; i < lstQuocGia.Count; i++)
            {
                parentNode = TreeV_QuocGiaTP.Nodes[lstQuocGia[i].ID.ToString()];
                List<Business.TinhTP> lstTPCon = lstTP.Where(a => a.QuocGiaID == Convert.ToInt32(parentNode.Name)).ToList();
                for (int y = 0; y < lstTPCon.Count; y++)
                {
                    newNode = new TreeNode();
                    newNode.Name = Convert.ToString(lstTPCon[y].ID);
                    newNode.Text = lstTPCon[y].TenTinhTP;
                    TreeV_QuocGiaTP.Nodes[lstQuocGia[i].ID.ToString()].Nodes.Add(newNode);
                }


            }

            TreeV_QuocGiaTP.ExpandAll();
        }

        private void FillQuocGiaCombo()
        {

            comB_QuocGia.DataSource = lstQuocGia;
            comB_QuocGia.ValueMember = "id";
            comB_QuocGia.DisplayMember = "tenquocgia";
        }

        private void TreeV_QuocGiaTP_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectedNode = TreeV_QuocGiaTP.SelectedNode;
            if (SelectedNode != null)
            {
                if (SelectedNode.Level == 0)        // Nhom ngach
                {
                    txt_Ten.Text = SelectedNode.Text;
                    comB_QuocGia.SelectedIndex = -1;
                    SelectedNode.ExpandAll();
                }
                else        // ngach
                {
                    txt_Ten.Text = SelectedNode.Text;
                    int QuocGiaID = Convert.ToInt32(lstTP.Where(a => a.ID == Convert.ToInt16(SelectedNode.Name)).Select(a => a.QuocGiaID).First());
                    comB_QuocGia.SelectedValue = QuocGiaID;
                }
            }
        }

        private void TSMI_ThemQuocGia_Click(object sender, EventArgs e)
        {
            bAddFlag = true;
            AddEditQuocGia = true;
            ResetInterface(false);
            comB_QuocGia.SelectedIndex = -1;
        }

        private void TSMI_ThemTP_Click(object sender, EventArgs e)
        {
            bAddFlag = true;
            AddEditQuocGia = false;
            ResetInterface(false);
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (SelectedNode != null)
            {
                bAddFlag = false;
                ResetInterface(false);

                if (SelectedNode.Level == 0)        // Nhom ngach
                {
                    AddEditQuocGia = true;
                }
                else        // ngach
                {
                    AddEditQuocGia = false;
                }
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (SelectedNode != null &&
                        MessageBox.Show("Bạn muốn xoá thành phố / quốc gia này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (SelectedNode.Level == 0)
                {
                    oQuocGia.ID = Convert.ToInt32(SelectedNode.Name);
                    try
                    {
                        oQuocGia.Delete();
                        GetTinhTP_QuocGia();
                        UpdateTreeVDonVi();
                        MessageBox.Show("Xoá quốc gia thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_Ten.Text = "";
                        comB_QuocGia.SelectedIndex = -1;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xoá quốc gia không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    oTinhTP.ID = Convert.ToInt16(SelectedNode.Name);
                    try
                    {
                        oTinhTP.Delete();
                        GetTinhTP_QuocGia();
                        UpdateTreeVDonVi();
                        MessageBox.Show("Xoá thành phố thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xoá thành phố không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            #region Thêm
            if (bAddFlag)
            {
                if (AddEditQuocGia)       // Nhom ngach
                {
                    if (!string.IsNullOrWhiteSpace(txt_Ten.Text))
                    {
                        if (MessageBox.Show("Bạn muốn thêm quốc gia này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            oQuocGia.TenQuocGia = txt_Ten.Text.Trim();
                            try
                            {
                                oQuocGia.Add();
                                GetTinhTP_QuocGia();
                                UpdateTreeVDonVi();
                                FillQuocGiaCombo();
                                MessageBox.Show("Thêm quốc gia thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ResetInterface(true);
                                AddSuccess = true;
                            }
                            catch (Exception)
                            {
                                AddSuccess = false;
                                MessageBox.Show("Thêm quốc gia không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        
                    }
                    else
                    {
                        AddSuccess = false;
                        MessageBox.Show("Tên thành phố / quốc gia không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else        // Ngach
                {
                    if (!string.IsNullOrWhiteSpace(txt_Ten.Text))
                    {
                        if (MessageBox.Show("Bạn muốn thêm thành phố này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            oTinhTP.TenTinhTP = txt_Ten.Text.Trim();
                            oTinhTP.QuocGiaID = Convert.ToInt32(comB_QuocGia.SelectedValue);
                            try
                            {
                                oTinhTP.Add();
                                GetTinhTP_QuocGia();
                                UpdateTreeVDonVi();
                                FillQuocGiaCombo();
                                MessageBox.Show("Thêm thành phố thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ResetInterface(true);
                                AddSuccess = true;
                            }
                            catch (Exception)
                            {
                                AddSuccess = false;
                                MessageBox.Show("Thêm thành phố không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        
                    }
                    else
                    {
                        AddSuccess = false;
                        MessageBox.Show("Mã và tên thành phố không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }


            }
            #endregion

            #region Sửa
            else
            {
                if (AddEditQuocGia)       // Nhom ngach
                {
                    if (!string.IsNullOrWhiteSpace(txt_Ten.Text))
                    {
                        if (MessageBox.Show("Bạn muốn sửa quốc gia này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            oQuocGia.TenQuocGia = txt_Ten.Text.Trim();
                            oQuocGia.ID = Convert.ToInt32(SelectedNode.Name);
                            try
                            {
                                oQuocGia.Update();
                                GetTinhTP_QuocGia();
                                UpdateTreeVDonVi();
                                MessageBox.Show("sửa quốc gia thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ResetInterface(true);
                                AddSuccess = true;
                            }
                            catch (Exception)
                            {
                                AddSuccess = false;
                                MessageBox.Show("sửa quốc gia không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        
                    }
                    else
                    {
                         AddSuccess = false;
                        MessageBox.Show("Tên thành phố / quốc gia không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else        // Ngach
                {
                    if (!string.IsNullOrWhiteSpace(txt_Ten.Text))
                    {
                        if (MessageBox.Show("Bạn muốn sửa thành phố này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            oTinhTP.TenTinhTP = txt_Ten.Text.Trim();
                            oTinhTP.ID = Convert.ToInt16(SelectedNode.Name);
                            oTinhTP.QuocGiaID = Convert.ToInt32(comB_QuocGia.SelectedValue);
                            try
                            {
                                oTinhTP.Update();
                                GetTinhTP_QuocGia();
                                UpdateTreeVDonVi();
                                MessageBox.Show("sửa thành phố thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ResetInterface(true);
                                 AddSuccess = true;
                            }
                            catch (Exception)
                            {
                                 AddSuccess = false;
                                MessageBox.Show("sửa thành phố không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        
                    }
                    else
                    {
                         AddSuccess = false;
                        MessageBox.Show("Mã và tên thành phố không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            #endregion

            if ( AddSuccess )
            {
		       txt_Ten.Text = "";
                if (lstQuocGia.Count > 0 && !bAddFlag)
                {
                    comB_QuocGia.SelectedIndex = -1;
                }
            }
           
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ResetInterface(true);
        }

        private void ResetInterface(bool init)
        {
            if (init)
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = true;
                btn_Huy.Visible = btn_Luu.Visible = false;
                txt_Ten.Enabled = comB_QuocGia.Enabled = false;
                TreeV_QuocGiaTP.Enabled = true;
            }
            else
            {
                btn_Them.Visible = btn_Xoa.Visible = btn_Sua.Visible = false;
                btn_Huy.Visible = btn_Luu.Visible = true;
                txt_Ten.Enabled =  comB_QuocGia.Enabled = true;
                TreeV_QuocGiaTP.Enabled = false;

                if (bAddFlag) // thao tac them moi xoa rong cac field
                {
                     txt_Ten.Text = "";
                    if (comB_QuocGia.Items.Count > 0)
                        comB_QuocGia.SelectedIndex = 0;
                }
            }

        }
    }
}
