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
    public partial class QLNS_DonVi_CNVC : UserControl
    {
        #region global variables

        Business.DonVi oDonVi;
        Business.CNVC.CNVC oCNVC;
        
        DataTable dtDSCNVC;
        List<Business.DonVi> listDonVi;
        UCs.QLNS_DanhMucThongTin UCDanhMucThongTin;
        public int nSelectedDVID = 0;

        #endregion

        #region xu ly giao dien

        public QLNS_DonVi_CNVC()
        {
            InitializeComponent();
            oDonVi = new Business.DonVi();
            oCNVC = new Business.CNVC.CNVC();
        }

        public QLNS_DonVi_CNVC( ref UCs.QLNS_DanhMucThongTin _UCDanhMucThongTin)
        {
            InitializeComponent();
            oDonVi = new Business.DonVi();
            oCNVC = new Business.CNVC.CNVC();
            UCDanhMucThongTin = _UCDanhMucThongTin;
        }

        private void QLNS_DonVi_CNVC_Load(object sender, EventArgs e)
        {
            listDonVi = oDonVi.GetList();
            if (listDonVi != null)
            {
                UpdateTreeVDonVi(listDonVi,null);
                TreeV_DonVi.ExpandAll();
            }
        }

        private void TreeV_DonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.IsExpanded)
                e.Node.Collapse();
            else
                e.Node.Expand();

            dtDSCNVC = oDonVi.GetCNVCList(e.Node.Name);
            nSelectedDVID = Convert.ToInt32(e.Node.Name);
            if (dtDSCNVC != null && dtDSCNVC.Rows.Count > 0)
            {
                FillTreeVCNVC();
            }
            else
            {
                TreeV_CNVC.Nodes.Clear();
            }
            UCDanhMucThongTin.EmptyDaoTaoBDContent();
            UCDanhMucThongTin.EmptyGiaDinhContent();
            UCDanhMucThongTin.EmptyHoatDongCTContent();
            UCDanhMucThongTin.EmptyHopDongTTContent();
            UCDanhMucThongTin.EmptyThongTinContent();
            UCDanhMucThongTin.EmptyThongTinPhuContent();
            UCDanhMucThongTin.EnableTableLP(false);
                    
        }

        private void TreeV_CNVC_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //UCs.QLNS_DanhMucThongTin DanhMucThongTin = new QLNS_DanhMucThongTin(e.Node.Name);
            UCDanhMucThongTin.MaCNVC = e.Node.Name;
            UCDanhMucThongTin.LoadThongTin();
        }

        private void btn_TimDonVi_Click(object sender, EventArgs e)
        {
            if (TreeV_DonVi.Nodes.Count > 0 && txt_TimDonVi.TextLength > 0)
            {
                // set lai mau` cho treeview
                ResetDVTreeViewColor(TreeV_DonVi.Nodes);


                //FindNode(TreeV_DonVi.Nodes, txt_TimDonVi.Text.Trim());
                var nodes = listDonVi.Where(x => x.TenDonVi.Contains(txt_TimDonVi.Text.Trim()));
                foreach (var node in nodes)
                {
                    TreeNode[] arrTreeNode = TreeV_DonVi.Nodes.Find(node.ID.ToString(), true);
                    foreach (TreeNode n in arrTreeNode) // do ID lam key, nen chi foreach 1 lan
                    {
                        n.BackColor = Color.Aqua;
                    }
                }

            }
            else
            {
                MessageBox.Show("Hiện tại chưa có đơn vị nào hoặc điều kiện tìm không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void ResetDVTreeViewColor(TreeNodeCollection TreeNodesCol)
        {
             if (TreeNodesCol.Count <= 0)
            {
                return;
            }
            else
            {
                foreach (TreeNode TreeNode in TreeNodesCol)
                {
                    TreeNode.BackColor = Color.White;
                    ResetDVTreeViewColor(TreeNode.Nodes);
                }                
            }
        }

       
        private void btn_TimCNVC_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region ham phu

        public void FindNode(TreeNodeCollection nodeCollection, string TextToFind) 
        {
            foreach (TreeNode node in nodeCollection)
            {
                if (node.Text.Contains(TextToFind))
                {
                    TreeV_DonVi.SelectedNode = node;
                    TreeNode parentNode = node.Parent;
                    while (parentNode != null)
                    {
                        parentNode.Expand();
                        parentNode = parentNode.Parent;
                    }
                    break;
                }
                FindNode(node.Nodes, TextToFind);
            }
        }

        /// <summary>
        /// Ham de quy , add cac don vi vao tree view
        /// </summary>
        private void UpdateTreeVDonVi(IEnumerable<Business.DonVi> listDV, TreeNode parentNode)
        {
            // lay ra nhung nodes co parentID = ID cua parentNode
            var nodes = listDV.Where(x => parentNode == null ? x.DVChaID == null : x.DVChaID == int.Parse(parentNode.Name));
             foreach (var node in nodes)
            {
                TreeNode newNode = new TreeNode();
                newNode.Name = node.ID.ToString();
                newNode.Text = node.TenDonVi;
                if (node.IsActive == false) newNode.BackColor = Color.Gray;
                if (parentNode == null)
                {
                    TreeV_DonVi.Nodes.Add(newNode);
                }
                else
                {
                    parentNode.Nodes.Add(newNode);
                }
                UpdateTreeVDonVi(listDV, newNode);
            }
        }

        private void FillTreeVCNVC()
        {
            TreeV_CNVC.Nodes.Clear();
            foreach (DataRow row in dtDSCNVC.Rows)
            {
                TreeV_CNVC.Nodes.Add(row["ma_nv"].ToString(), row["ho"].ToString() + " " + row["ten"].ToString());
            }
        }

        /// <summary>
        /// UC QLNS_HienThiThongTin se goi ham nay, xai khi them thanh cong
        /// </summary>
        /// <param name="_MaDV">ma don vi dang chon</param>
        public void RefreshTreeVCNVC(string _MaDV)
        {
            TreeV_DonVi.SelectedNode.Name = _MaDV;
            dtDSCNVC = oDonVi.GetCNVCList(_MaDV);
            TreeV_CNVC.Nodes.Clear();
            if (dtDSCNVC != null && dtDSCNVC.Rows.Count > 0)
            {
                
                foreach (DataRow row in dtDSCNVC.Rows)
                {
                    TreeV_CNVC.Nodes.Add(row["ma_nv"].ToString(), row["ho"].ToString() + " " + row["ten"].ToString());
                }
            }
        }


        #endregion

        private void btn_LamTuoi_Click(object sender, EventArgs e)
        {
            TreeV_DonVi.Nodes.Clear();
            TreeV_CNVC.Nodes.Clear();
            listDonVi = oDonVi.GetList();
            UpdateTreeVDonVi(listDonVi, null);
            TreeV_DonVi.ExpandAll();
        }

        private void TreeV_DonVi_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nSelectedDVID = Convert.ToInt32(e.Node.Name);
        }

        

        

        


    }
}
