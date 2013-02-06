using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataProvider;

namespace QLNS.UCs
{
    public partial class QLNS_TimKiem : UserControl
    {
        TreeNode selectnode;
        SearchConditions search;
        List<SearchConditions> list_searchconditions;
        DataProvider.DataProvider dp;
        static Forms.Popup fPopup;

        public static string ds_tinh_tp = "";
        public static string ds_mohinhdt = "";

        public QLNS_TimKiem()
        {
            InitializeComponent();
            list_searchconditions = new List<SearchConditions>();
            dp = new DataProvider.DataProvider();
            
        }


        #region Class Search Conditions
        class SearchConditions
        {
            public string tblname { get; set; }
            public string colname { get; set; }
            public string value { get; set; }
            public string valueto { get; set; }
            public string condition { get; set; }

            public SearchConditions(string p_tblname, string p_colname, string p_value, string p_condition)
            {
                tblname = p_tblname;
                colname = p_colname;
                value = p_value;
                condition = p_condition;
            }

            public SearchConditions(string p_tblname, string p_colname, string p_value, string p_valueto, string p_condition)
            {
                tblname = p_tblname;
                colname = p_colname;
                value = p_value;
                valueto = p_valueto;
                condition = p_condition;
            }
        };
        #endregion

        #region Xử lý tab Hiển thị
        private void btn_Chon_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in TreeV_DSThongTin.Nodes)
            {
                if (node.StateImageIndex != 0 || node.StateImageIndex != -1)
                {
                    //TreeNode parent = TreeV_DSHienThi.Nodes.Add(node.Text);
                    AddSelectChildNode(node);
                }
            }
            TreeV_DSHienThi.ExpandAll();
        }

        private void AddSelectChildNode(TreeNode node)
        {
            foreach (TreeNode child in node.Nodes)
            {
                if (child.Checked == true)
                    TreeV_DSHienThi.Nodes.Add(child.Name, child.Text);
                AddSelectChildNode(child);
            }
        }

        private void btn_ChonHet_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in TreeV_DSThongTin.Nodes)
            {
                //TreeNode parent = TreeV_DSHienThi.Nodes.Add(node.Text);
                AddAllChildNode(node);
            }
            TreeV_DSHienThi.ExpandAll();
        }

        private void AddAllChildNode(TreeNode node)
        {
            foreach (TreeNode child in node.Nodes)
            {
                TreeV_DSHienThi.Nodes.Add(child.Name, child.Text);
                AddAllChildNode(child);
            }
        }

        private void btn_Bo_Click(object sender, EventArgs e)
        {
            if (selectnode != null)
                TreeV_DSHienThi.Nodes.Remove(selectnode);
        }

        private void btn_BoHet_Click(object sender, EventArgs e)
        {
            TreeV_DSHienThi.Nodes.Clear();
        }

        private void TreeV_DSHienThi_DoubleClick(object sender, EventArgs e)
        {
            if (selectnode != null)
                TreeV_DSHienThi.Nodes.Remove(selectnode);
        }

        private void TreeV_DSHienThi_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectnode = e.Node;
        }

        private void TreeV_DSThongTin_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();
            //foreach (TreeNode node in TreeV_DSThongTin.Nodes)
            //{
            //    if (node != e.Node)
            //        node.Collapse();
            //}
        }
        #endregion

        #region Xử lý tab Thông Tin

        private void comb_CmndHochieu_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_cmnd_hochieu.cmnd_hochieu")
                {
                    if (comb_CmndHochieu.Text == "CMND")
                        temp.value = "true";
                    else if (comb_CmndHochieu.Text == "Hộ chiếu")
                        temp.value = "false";
                    else
                        list_searchconditions.Remove(temp);
                    return;
                }
            }
            if (comb_CmndHochieu.Text != "")
            {
                if (comb_CmndHochieu.Text == "CMND")
                    list_searchconditions.Add(new SearchConditions("cnvc_cmnd_hochieu", "cnvc_cmnd_hochieu.cmnd_hochieu", "true", "="));
                else if (comb_CmndHochieu.Text == "Hộ chiếu")
                    list_searchconditions.Add(new SearchConditions("cnvc_cmnd_hochieu", "cnvc_cmnd_hochieu.cmnd_hochieu", "false", "="));


            }

        }

        private void dtp_NgayCap_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_cmnd_hochieu.ngay_cap")
                {
                    //list_searchconditions.Remove(temp);
                    if (dtp_NgayCap.Checked == false)
                        list_searchconditions.Remove(temp);
                    else
                        temp.value = dtp_NgayCap.Value.ToShortDateString();
                    return;
                }
            }
            if (dtp_NgayCap.Checked == true)
            {
                //string ngaycap = "";
                //if (dtp_NgayCap.Checked == true)
                //    ngaycap = dtp_NgayCap.Value.ToShortDateString();
                list_searchconditions.Add(new SearchConditions("cnvc_cmnd_hochieu", "cnvc_cmnd_hochieu.ngay_cap", dtp_NgayCap.Value.ToShortDateString(), "="));

            }
        }

        private void dtp_NgayHetHan_Leave(object sender, EventArgs e)
        {

        }

        private void dTP_NgaySinh_Tu_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc.ngay_sinh")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgaySinh_Tu.Checked == false)
                        list_searchconditions.Remove(temp);
                    else
                        temp.value = dTP_NgaySinh_Tu.Value.ToShortDateString();
                    return;
                }
            }
            if (dTP_NgaySinh_Tu.Checked == true)
            {
                string ngaysinhden = DateTime.Now.ToShortDateString();
                if (dTP_NgaySinh_Den.Checked == true)
                    ngaysinhden = dTP_NgaySinh_Den.Value.ToShortDateString();
                list_searchconditions.Add(new SearchConditions("cnvc", "cnvc.ngay_sinh", dTP_NgaySinh_Tu.Value.ToShortDateString(), ngaysinhden, "between"));

            }
        }

        private void dTP_NgaySinh_Den_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc.ngay_sinh")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgaySinh_Den.Checked == false)
                        temp.valueto = DateTime.Now.ToShortDateString();
                    else
                        temp.valueto = dTP_NgaySinh_Den.Value.ToShortDateString();
                    return;
                }
            }
            //if (dTP_NgaySinh_Den.Checked == true)
            //{
            //    string ngaysinhden = "";
            //    if (dTP_NgaySinh_Den.Checked == true)
            //        ngaysinhden = dTP_NgaySinh_Den.Value.ToShortDateString();
            //    list_searchconditions.Add(new SearchConditions("cnvc", "cnvc.ngay_sinh", dTP_NgaySinh_Tu.Value.ToShortDateString(), ngaysinhden, "between"));

            //}
        }

        private void dTP_NgaySinh_Tu_ValueChanged(object sender, EventArgs e)
        {
            if (dTP_NgaySinh_Tu.Checked == true)
                dTP_NgaySinh_Den.Enabled = true;
            else
            {
                dTP_NgaySinh_Den.Enabled = false;
                dTP_NgaySinh_Den.Checked = false;
            }
        }

        private void comB_GioiTinh_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc.gioi_tinh")
                {
                    //list_searchconditions.Remove(temp);
                    //temp.value = txt_NoiCap.Text;
                    if (comB_GioiTinh.Text == "Nam")
                        temp.value = "true";
                    else if (comB_GioiTinh.Text == "Nữ")
                        temp.value = "false";
                    else
                        list_searchconditions.Remove(temp);
                    return;
                }
            }
            if (comB_GioiTinh.Text != "")
            {
                if (comB_GioiTinh.Text == "Nam")
                    list_searchconditions.Add(new SearchConditions("cnvc", "cnvc.gioi_tinh", "true", "="));
                else if (comB_GioiTinh.Text == "Nữ")
                    list_searchconditions.Add(new SearchConditions("cnvc", "cnvc.gioi_tinh", "false", "="));


            }
        }
        private void txt_MaNV_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc.ma_nv")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_MaNV.Text;
                    return;
                }
            }
            if (txt_MaNV.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc", "cnvc.ma_nv", txt_MaNV.Text, "like"));

            }
        }

        private void txt_MaSoThue_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc.ma_so_thue")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_MaSoThue.Text;
                    return;
                }
            }
            if (txt_MaSoThue.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc", "cnvc.ma_so_thue", txt_MaSoThue.Text, "like"));

            }
        }

        private void txt_Ho_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc.ho")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_Ho.Text;
                    return;
                }
            }
            if (txt_Ho.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc", "cnvc.ho", txt_Ho.Text, "like"));

            }
        }

        private void txt_Ten_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc.ten")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_Ten.Text;
                    return;
                }
            }
            if (txt_Ten.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc", "cnvc.ten", txt_Ten.Text, "like"));

            }
        }

        private void txt_DiaChi_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc.dia_chi")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_DiaChi.Text;
                    return;
                }
            }
            if (txt_DiaChi.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc", "cnvc.dia_chi", txt_DiaChi.Text, "like"));

            }
        }

        private void txt_SoSoBHXH_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc.so_so_bhxh")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_SoSoBHXH.Text;
                    return;
                }
            }
            if (txt_SoSoBHXH.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc", "cnvc.so_so_bhxh", txt_SoSoBHXH.Text, "like"));

            }
        }

        private void txt_SoCMND_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_cmnd_hochieu.ma_so")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_SoCMND.Text;
                    return;
                }
            }
            if (txt_SoCMND.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_cmnd_hochieu", "cnvc_cmnd_hochieu.ma_so", txt_SoCMND.Text, "like"));

            }
        }

        private void txt_NoiCap_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_cmnd_hochieu.noi_cap")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_NoiCap.Text;
                    return;
                }
            }
            if (txt_NoiCap.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_cmnd_hochieu", "cnvc_cmnd_hochieu.noi_cap", txt_NoiCap.Text, "like"));

            }
        }


        #endregion

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder();

            #region Xử lý mệnh đề SELECT
            query.Append("select cnvc.ma_nv, ");
            foreach (TreeNode node in TreeV_DSHienThi.Nodes)
            {
                query.Append(node.Name + ", ");
            }
            query.Remove(query.ToString().Length - 2, 2);

            #endregion

            #region Xử lý mệnh đề FROM
            List<string> tbllstall = new List<string>();
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.tblname != "cnvc")
                    tbllstall.Add(temp.tblname);
            }
            foreach (TreeNode node in TreeV_DSHienThi.Nodes)
            {
                string tblname = node.Name.Substring(0, node.Name.IndexOf("."));
                if (tblname != "cnvc")
                    tbllstall.Add(tblname);
            }

            List<string> tbllstdis = new List<string>();
            tbllstdis = tbllstall.Distinct().ToList();

            query.Append(" from cnvc");
            for (int i = 0; i < tbllstdis.Count; i++)
            {
                query.Append(" inner join " + tbllstdis[i] + " on " + "cnvc.ma_nv = " + tbllstdis[i] + ".ma_nv");
            }
            //string a = query.ToString();

            #endregion

            #region Xử lý mệnh đề WHERE
            string searchoperator = "";
            if (rbtn_And.Checked == true)
                searchoperator = "and";
            else
                searchoperator = "or";

            query.Append(" where ");
            foreach (SearchConditions temp in list_searchconditions)
            {
                switch (temp.condition)
                {
                    case "like":
                        query.Append(" lower(" + temp.colname + ") like lower('%" + temp.value + "%') " + searchoperator + " ");
                        break;
                    case "=":
                        query.Append(temp.colname + " = " + temp.value + " " + searchoperator + " ");
                        break;
                    case "between":
                        if (temp.valueto != "")
                            query.Append(temp.colname + " between '" + temp.value + "' and '" + temp.valueto + "' " + searchoperator + " ");
                        else
                            query.Append(temp.colname + " between '" + temp.value + "' and '" + temp.value + "' " + searchoperator + " ");
                        break;
                }
                //query.Append(temp.colname + " = " + temp.value + " " + searchoperator + " ");
            }
            query.Remove(query.ToString().Length - searchoperator.Length - 1, searchoperator.Length + 1);
            query.Append(";");

            #endregion

            #region Xử lý hiển thị kết quả tìm kiếm
            try
            {
                string b = query.ToString();
                //MessageBox.Show(b);
                DataTable result = dp.getDataTable(b);

                if (dtgv_KQTimKiem.Rows.Count > 1)
                    dtgv_KQTimKiem.Rows.Clear();

                BindingSource bs = new BindingSource();
                bs.DataSource = result;
                dtgv_KQTimKiem.DataSource = bs;

                TabC_DanhMucThongTin.SelectedTab = tabP_KetQua;
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình tìm kiếm. Vui lòng cung cấp lại thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        #region Xử lý tab Thông tin phụ
        private void txt_TenGoiKhac_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_thong_tin_phu.ten_goi_khac")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_TenGoiKhac.Text;
                    return;
                }
            }
            if (txt_TenGoiKhac.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_thong_tin_phu", "cnvc_thong_tin_phu.ten_goi_khac", txt_TenGoiKhac.Text, "like"));

            }
        }

        private void txt_TonGiao_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_thong_tin_phu.ton_giao")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_TonGiao.Text;
                    return;
                }
            }
            if (txt_TonGiao.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_thong_tin_phu", "cnvc_thong_tin_phu.ton_giao", txt_TonGiao.Text, "like"));

            }
        }

        private void txt_NoiSinhHuyen_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_thong_tin_phu.noi_sinh_huyen")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_NoiSinhHuyen.Text;
                    return;
                }
            }
            if (txt_NoiSinhHuyen.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_thong_tin_phu", "cnvc_thong_tin_phu.noi_sinh_huyen", txt_NoiSinhHuyen.Text, "like"));

            }
        }

        private void txt_NoiSinhXa_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_thong_tin_phu.noi_sinh_xa")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_NoiSinhXa.Text;
                    return;
                }
            }
            if (txt_NoiSinhXa.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_thong_tin_phu", "cnvc_thong_tin_phu.noi_sinh_xa", txt_NoiSinhXa.Text, "like"));

            }
        }

        private void txt_DanToc_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_thong_tin_phu.dan_toc")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_DanToc.Text;
                    return;
                }
            }
            if (txt_DanToc.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_thong_tin_phu", "cnvc_thong_tin_phu.dan_toc", txt_DanToc.Text, "like"));

            }
        }

        private void txt_QueXa_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_thong_tin_phu.que_quan_xa")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_QueXa.Text;
                    return;
                }
            }
            if (txt_QueXa.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_thong_tin_phu", "cnvc_thong_tin_phu.que_quan_xa", txt_QueXa.Text, "like"));

            }
        }

        private void txt_QueHuyen_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_thong_tin_phu.que_quan_huyen")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_QueHuyen.Text;
                    return;
                }
            }
            if (txt_QueHuyen.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_thong_tin_phu", "cnvc_thong_tin_phu.que_quan_huyen", txt_QueHuyen.Text, "like"));

            }
        }

        private void txt_HoKhau_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_thong_tin_phu.noi_dk_hokhau_thuongtru")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_HoKhau.Text;
                    return;
                }
            }
            if (txt_HoKhau.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_thong_tin_phu", "cnvc_thong_tin_phu.noi_dk_hokhau_thuongtru", txt_HoKhau.Text, "like"));

            }
        }

        private void txt_NhomMau_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_thong_tin_phu.nhom_mau")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_NhomMau.Text;
                    return;
                }
            }
            if (txt_NhomMau.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_thong_tin_phu", "cnvc_thong_tin_phu.nhom_mau", txt_NhomMau.Text, "like"));

            }
        }

        private void txt_ChieuCao_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_thong_tin_phu.chieu_cao")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_ChieuCao.Text;
                    return;
                }
            }
            if (txt_ChieuCao.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_thong_tin_phu", "cnvc_thong_tin_phu.chieu_cao", txt_ChieuCao.Text, "like"));

            }
        }


        #endregion

        #region Xử lý tab Hoạt động chính trị
        private void cb_DoanVien_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.doan_vien")
                {
                    if (cb_DoanVien.Checked == true)
                        temp.value = "true";
                    else
                        list_searchconditions.Remove(temp);
                    return;
                }
            }
            if (cb_DoanVien.Checked == true)
            {
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.doan_vien", "true", "="));
            }
        }

        private void dTP_NgayVaoDoan_Tu_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_vao_doan")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayVaoDoan_Tu.Checked == false)
                        list_searchconditions.Remove(temp);
                    else
                        temp.value = dTP_NgayVaoDoan_Tu.Value.ToShortDateString();
                    return;
                }
            }
            if (dTP_NgayVaoDoan_Tu.Checked == true)
            {
                string ngayvaodoan_den = DateTime.Now.ToShortDateString();
                if (dTP_NgayVaoDoan_Den.Checked == true)
                    ngayvaodoan_den = dTP_NgayVaoDoan_Den.Value.ToShortDateString();
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.ngay_vao_doan", dTP_NgayVaoDoan_Tu.Value.ToShortDateString(), ngayvaodoan_den, "between"));

            }
        }

        private void dTP_NgayVaoDoan_Tu_ValueChanged(object sender, EventArgs e)
        {
            if (dTP_NgayVaoDoan_Tu.Checked == true)
                dTP_NgayVaoDoan_Den.Enabled = true;
            else
            {
                dTP_NgayVaoDoan_Den.Enabled = false;
                dTP_NgayVaoDoan_Den.Checked = false;
            }
        }

        private void dTP_NgayVaoDoan_Den_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_vao_doan")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayVaoDoan_Den.Checked == false)
                        temp.valueto = DateTime.Now.ToShortDateString();
                    else
                        temp.valueto = dTP_NgayVaoDoan_Den.Value.ToShortDateString();
                    return;
                }
            }
        }

        private void dTP_NgayRaDoan_Tu_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_ra_khoi_doan")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayRaDoan_Tu.Checked == false)
                        list_searchconditions.Remove(temp);
                    else
                        temp.value = dTP_NgayRaDoan_Tu.Value.ToShortDateString();
                    return;
                }
            }
            if (dTP_NgayRaDoan_Tu.Checked == true)
            {
                string ngayradoan_den = DateTime.Now.ToShortDateString();
                if (dTP_NgayRaDoan_Den.Checked == true)
                    ngayradoan_den = dTP_NgayRaDoan_Den.Value.ToShortDateString();
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.ngay_ra_khoi_doan", dTP_NgayRaDoan_Tu.Value.ToShortDateString(), ngayradoan_den, "between"));

            }
        }

        private void dTP_NgayRaDoan_Tu_ValueChanged(object sender, EventArgs e)
        {
            if (dTP_NgayRaDoan_Tu.Checked == true)
                dTP_NgayRaDoan_Den.Enabled = true;
            else
            {
                dTP_NgayRaDoan_Den.Enabled = false;
                dTP_NgayRaDoan_Den.Checked = false;
            }
        }

        private void dTP_NgayRaDoan_Den_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_ra_khoi_doan")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayRaDoan_Den.Checked == false)
                        temp.valueto = DateTime.Now.ToShortDateString();
                    else
                        temp.valueto = dTP_NgayRaDoan_Den.Value.ToShortDateString();
                    return;
                }
            }
        }

        private void dTP_NgayTaiKNDoan_Tu_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_tai_gia_nhap_doan")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayTaiKNDoan_Tu.Checked == false)
                        list_searchconditions.Remove(temp);
                    else
                        temp.value = dTP_NgayTaiKNDoan_Tu.Value.ToShortDateString();
                    return;
                }
            }
            if (dTP_NgayTaiKNDoan_Tu.Checked == true)
            {
                string ngaytaikndoan_den = DateTime.Now.ToShortDateString();
                if (dTP_NgayTaiKNDoan_Den.Checked == true)
                    ngaytaikndoan_den = dTP_NgayTaiKNDoan_Den.Value.ToShortDateString();
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.ngay_tai_gia_nhap_doan", dTP_NgayTaiKNDoan_Tu.Value.ToShortDateString(), ngaytaikndoan_den, "between"));

            }
        }

        private void dTP_NgayTaiKNDoan_Tu_ValueChanged(object sender, EventArgs e)
        {
            if (dTP_NgayTaiKNDoan_Tu.Checked == true)
                dTP_NgayTaiKNDoan_Den.Enabled = true;
            else
            {
                dTP_NgayTaiKNDoan_Den.Enabled = false;
                dTP_NgayTaiKNDoan_Den.Checked = false;
            }

        }

        private void dTP_NgayTaiKNDoan_Den_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_tai_gia_nhap_doan")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayTaiKNDoan_Den.Checked == false)
                        temp.valueto = DateTime.Now.ToShortDateString();
                    else
                        temp.valueto = dTP_NgayTaiKNDoan_Den.Value.ToShortDateString();
                    return;
                }
            }
        }

        private void cb_DangVien_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.dang_vien")
                {
                    if (cb_DangVien.Checked == true)
                        temp.value = "true";
                    else
                        list_searchconditions.Remove(temp);
                    return;
                }
            }
            if (cb_DangVien.Checked == true)
            {
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.dang_vien", "true", "="));
            }
        }

        private void dTP_NgayVaoDang_Tu_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_vao_dang")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayVaoDang_Tu.Checked == false)
                        list_searchconditions.Remove(temp);
                    else
                        temp.value = dTP_NgayVaoDang_Tu.Value.ToShortDateString();
                    return;
                }
            }
            if (dTP_NgayVaoDang_Tu.Checked == true)
            {
                string ngayvaodang_den = DateTime.Now.ToShortDateString();
                if (dTP_NgayVaoDang_Den.Checked == true)
                    ngayvaodang_den = dTP_NgayVaoDang_Den.Value.ToShortDateString();
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.ngay_vao_dang", dTP_NgayVaoDang_Tu.Value.ToShortDateString(), ngayvaodang_den, "between"));

            }
        }

        private void dTP_NgayVaoDang_Tu_ValueChanged(object sender, EventArgs e)
        {
            if (dTP_NgayVaoDang_Tu.Checked == true)
                dTP_NgayVaoDang_Den.Enabled = true;
            else
            {
                dTP_NgayVaoDang_Den.Enabled = false;
                dTP_NgayVaoDang_Den.Checked = false;
            }
        }

        private void dTP_NgayVaoDang_Den_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_vao_dang")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayVaoDang_Den.Checked == false)
                        temp.valueto = DateTime.Now.ToShortDateString();
                    else
                        temp.valueto = dTP_NgayVaoDang_Den.Value.ToShortDateString();
                    return;
                }
            }
        }

        private void dTP_NgayRaDang_Tu_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_ra_khoi_dang")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayRaDang_Tu.Checked == false)
                        list_searchconditions.Remove(temp);
                    else
                        temp.value = dTP_NgayRaDang_Tu.Value.ToShortDateString();
                    return;
                }
            }
            if (dTP_NgayRaDang_Tu.Checked == true)
            {
                string ngayradang_den = DateTime.Now.ToShortDateString();
                if (dTP_NgayRaDang_Den.Checked == true)
                    ngayradang_den = dTP_NgayRaDang_Den.Value.ToShortDateString();
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.ngay_ra_khoi_dang", dTP_NgayRaDang_Tu.Value.ToShortDateString(), ngayradang_den, "between"));

            }
        }

        private void dTP_NgayRaDang_Tu_ValueChanged(object sender, EventArgs e)
        {
            if (dTP_NgayRaDang_Tu.Checked == true)
                dTP_NgayRaDang_Den.Enabled = true;
            else
            {
                dTP_NgayRaDang_Den.Enabled = false;
                dTP_NgayRaDang_Den.Checked = false;
            }
        }

        private void dTP_NgayRaDang_Den_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_ra_khoi_dang")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayRaDang_Den.Checked == false)
                        temp.valueto = DateTime.Now.ToShortDateString();
                    else
                        temp.valueto = dTP_NgayRaDang_Den.Value.ToShortDateString();
                    return;
                }
            }
        }

        private void dTP_NgayTaiKNDang_Tu_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_tai_gia_nhap_dang")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayTaiKNDang_Tu.Checked == false)
                        list_searchconditions.Remove(temp);
                    else
                        temp.value = dTP_NgayTaiKNDang_Tu.Value.ToShortDateString();
                    return;
                }
            }
            if (dTP_NgayTaiKNDang_Tu.Checked == true)
            {
                string ngaytaikndang_den = DateTime.Now.ToShortDateString();
                if (dTP_NgayTaiKNDang_Tu.Checked == true)
                    ngaytaikndang_den = dTP_NgayTaiKNDang_Tu.Value.ToShortDateString();
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.ngay_tai_gia_nhap_dang", dTP_NgayTaiKNDang_Tu.Value.ToShortDateString(), ngaytaikndang_den, "between"));

            }
        }

        private void dTP_NgayTaiKNDang_Tu_ValueChanged(object sender, EventArgs e)
        {
            if (dTP_NgayTaiKNDang_Tu.Checked == true)
                dTP_NgayTaiKNDang_Tu.Enabled = true;
            else
            {
                dTP_NgayTaiKNDang_Tu.Enabled = false;
                dTP_NgayTaiKNDang_Tu.Checked = false;
            }
        }

        private void dTP_NgayTaiKNDang_Den_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_tai_gia_nhap_dang")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayTaiKNDang_Tu.Checked == false)
                        temp.valueto = DateTime.Now.ToShortDateString();
                    else
                        temp.valueto = dTP_NgayTaiKNDang_Tu.Value.ToShortDateString();
                    return;
                }
            }
        }

        private void cb_CongDoan_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.is_cong_doan_vien")
                {
                    if (cb_CongDoan.Checked == true)
                        temp.value = "true";
                    else
                        list_searchconditions.Remove(temp);
                    return;
                }
            }
            if (cb_CongDoan.Checked == true)
            {
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.is_cong_doan_vien", "true", "="));
            }
        }

        private void txt_QuanHam_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.quan_ham_cao_nhat")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_QuanHam.Text;
                    return;
                }
            }
            if (txt_QuanHam.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.quan_ham_cao_nhat", txt_QuanHam.Text, "like"));

            }
        }

        private void txt_QuanLyNhaNuoc_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.quan_ly_nha_nuoc")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_QuanLyNhaNuoc.Text;
                    return;
                }
            }
            if (txt_QuanLyNhaNuoc.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.quan_ly_nha_nuoc", txt_QuanLyNhaNuoc.Text, "like"));

            }
        }

        private void txt_ThuongBinh_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.thuong_binh_hang")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_ThuongBinh.Text;
                    return;
                }
            }
            if (txt_ThuongBinh.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.thuong_binh_hang", txt_ThuongBinh.Text, "like"));

            }
        }

        private void txt_DanhHieu_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.danh_hieu_cao_nhat")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_DanhHieu.Text;
                    return;
                }
            }
            if (txt_DanhHieu.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.danh_hieu_cao_nhat", txt_DanhHieu.Text, "like"));

            }
        }

        private void txt_LyLuanChinhTri_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ly_luan_chinh_tri")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_LyLuanChinhTri.Text;
                    return;
                }
            }
            if (txt_LyLuanChinhTri.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.ly_luan_chinh_tri", txt_LyLuanChinhTri.Text, "like"));

            }
        }

        private void txt_GiaDinh_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.gia_dinh_chinh_sach")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_GiaDinh.Text;
                    return;
                }
            }
            if (txt_GiaDinh.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.gia_dinh_chinh_sach", txt_GiaDinh.Text, "like"));

            }
        }

        private void rtb_KhenThuong_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.khen_thuong")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = rtb_KhenThuong.Text;
                    return;
                }
            }
            if (rtb_KhenThuong.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.khen_thuong", rtb_KhenThuong.Text, "like"));

            }
        }

        private void rtb_KyLuat_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ky_luat")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = rtb_KyLuat.Text;
                    return;
                }
            }
            if (rtb_KyLuat.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.ky_luat", rtb_KyLuat.Text, "like"));

            }
        }

        private void dTP_NgayNhapNgu_Tu_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_nhap_ngu")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayNhapNgu_Tu.Checked == false)
                        list_searchconditions.Remove(temp);
                    else
                        temp.value = dTP_NgayNhapNgu_Tu.Value.ToShortDateString();
                    return;
                }
            }
            if (dTP_NgayNhapNgu_Tu.Checked == true)
            {
                string ngaynhapngu_den = DateTime.Now.ToShortDateString();
                if (dTP_NgayNhapNgu_Den.Checked == true)
                    ngaynhapngu_den = dTP_NgayNhapNgu_Den.Value.ToShortDateString();
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.ngay_nhap_ngu", dTP_NgayNhapNgu_Tu.Value.ToShortDateString(), ngaynhapngu_den, "between"));

            }
        }

        private void dTP_NgayNhapNgu_Tu_ValueChanged(object sender, EventArgs e)
        {
            if (dTP_NgayNhapNgu_Tu.Checked == true)
                dTP_NgayNhapNgu_Den.Enabled = true;
            else
            {
                dTP_NgayNhapNgu_Den.Enabled = false;
                dTP_NgayNhapNgu_Den.Checked = false;
            }
        }

        private void dTP_NgayNhapNgu_Den_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_nhap_ngu")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayNhapNgu_Den.Checked == false)
                        temp.valueto = DateTime.Now.ToShortDateString();
                    else
                        temp.valueto = dTP_NgayNhapNgu_Den.Value.ToShortDateString();
                    return;
                }
            }
        }

        private void dTP_NgayXuatNgu_Tu_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_xuat_ngu")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayXuatNgu_Tu.Checked == false)
                        list_searchconditions.Remove(temp);
                    else
                        temp.value = dTP_NgayXuatNgu_Tu.Value.ToShortDateString();
                    return;
                }
            }
            if (dTP_NgayXuatNgu_Tu.Checked == true)
            {
                string ngayxuatngu_den = DateTime.Now.ToShortDateString();
                if (dTP_NgayXuatNgu_Den.Checked == true)
                    ngayxuatngu_den = dTP_NgayXuatNgu_Den.Value.ToShortDateString();
                list_searchconditions.Add(new SearchConditions("cnvc_chinh_tri", "cnvc_chinh_tri.ngay_xuat_ngu", dTP_NgayXuatNgu_Tu.Value.ToShortDateString(), ngayxuatngu_den, "between"));

            }
        }

        private void dTP_NgayXuatNgu_Tu_ValueChanged(object sender, EventArgs e)
        {
            if (dTP_NgayXuatNgu_Tu.Checked == true)
                dTP_NgayXuatNgu_Den.Enabled = true;
            else
            {
                dTP_NgayXuatNgu_Den.Enabled = false;
                dTP_NgayXuatNgu_Den.Checked = false;
            }
        }

        private void dTP_NgayXuatNgu_Den_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chinh_tri.ngay_xuat_ngu")
                {
                    //list_searchconditions.Remove(temp);
                    if (dTP_NgayXuatNgu_Den.Checked == false)
                        temp.valueto = DateTime.Now.ToShortDateString();
                    else
                        temp.valueto = dTP_NgayXuatNgu_Den.Value.ToShortDateString();
                    return;
                }
            }
        }


        #endregion

        #region Xử lý tab Đào tạo bồi dưỡng - Chuyên môn
        private void txt_NgoaiNgu_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chuyen_mon_tong_quat.ngoai_ngu")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_NgoaiNgu.Text;
                    return;
                }
            }
            if (txt_NgoaiNgu.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_chuyen_mon_tong_quat", "cnvc_chuyen_mon_tong_quat.ngoai_ngu", txt_NgoaiNgu.Text, "like"));

            }
        }

        private void txt_TinHoc_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chuyen_mon_tong_quat.tin_hoc")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_TinHoc.Text;
                    return;
                }
            }
            if (txt_TinHoc.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_chuyen_mon_tong_quat", "cnvc_chuyen_mon_tong_quat.tin_hoc", txt_TinHoc.Text, "like"));

            }
        }

        private void txt_SoTruong_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chuyen_mon_tong_quat.so_truong_cong_tac")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_SoTruong.Text;
                    return;
                }
            }
            if (txt_SoTruong.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_chuyen_mon_tong_quat", "cnvc_chuyen_mon_tong_quat.so_truong_cong_tac", txt_SoTruong.Text, "like"));

            }
        }

        private void txt_TrinhDo_Leave(object sender, EventArgs e)
        {
            foreach (SearchConditions temp in list_searchconditions)
            {
                if (temp.colname == "cnvc_chuyen_mon_tong_quat.trinh_do_chuyen_mon")
                {
                    //list_searchconditions.Remove(temp);
                    temp.value = txt_TrinhDo.Text;
                    return;
                }
            }
            if (txt_TrinhDo.Text != "")
            {
                list_searchconditions.Add(new SearchConditions("cnvc_chuyen_mon_tong_quat", "cnvc_chuyen_mon_tong_quat.trinh_do_chuyen_mon", txt_TrinhDo.Text, "like"));

            }
        }


        #endregion

        private void lbl_ChonTinhNoiSinh_Click(object sender, EventArgs e)
        {
            ds_tinh_tp = "";

            UCs.QLNS_DSTinh oDSTinhTP = new QLNS_DSTinh();
            oDSTinhTP.Dock = DockStyle.Fill;
            fPopup = new Forms.Popup("Danh sách tỉnh thành phố", oDSTinhTP);
            fPopup.ShowDialog();

            txt_NoiSinhTinh.Text = ds_tinh_tp;
        }

       

        private void lbl_ChọnTinhQue_Click(object sender, EventArgs e)
        {
            ds_tinh_tp = "";

            UCs.QLNS_DSTinh oDSTinhTP = new QLNS_DSTinh();
            oDSTinhTP.Dock = DockStyle.Fill;
            fPopup = new Forms.Popup("Danh sách tỉnh thành phố", oDSTinhTP);
            fPopup.ShowDialog();

            txt_QueQuanTinh.Text = ds_tinh_tp;
        }

        public static void ClosePopup()
        {
            fPopup.Close();
        }

        private void lbl_ThemMoHinh_Click(object sender, EventArgs e)
        {
            //ds_mohinhdt = "";

            //UCs.MoHinhDaoTao oDSMohinhDT = new MoHinhDaoTao();
            //oDSMohinhDT.Dock = DockStyle.Fill;
            //fPopup = new Forms.Popup("Danh sách mô hình đào tạo", oDSMohinhDT);
            //fPopup.ShowDialog();

            //txt_MoHinhDaoTao.Text = ds_mohinhdt;
        }





    }
}
