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
    public partial class DoiThongTinDV : UserControl
    {
        Business.DonVi oDonVi;
        Business.ChucVu oChucVu;
        Business.HDQD.QuyetDinh oQuyetDinh;
        DataTable dtDonVi , dtChucVu , dtChuyenDonVi ;  // dtChuyenDonVi chua cac don vi co the tro thanh parent cua dtDonVi  
        const int TenDVPos = 3 , TenDVTatPos = 5, DV_TenPos = 1, CD_TuPos = 2, CD_SangPos = 4, DV_CapBacPos = 0, DV_CapBacChaPos = 2, DV_CVPos = 0;
        int TLPTenColCount , TLPCVColCount , TLPCapBacColCount;

        public DoiThongTinDV()
        {
            InitializeComponent();
            oDonVi = new DonVi();
            oChucVu = new ChucVu();
            oQuyetDinh = new Business.HDQD.QuyetDinh();
            dtDonVi = oDonVi.GetActiveDonVi();
            dtChucVu = oChucVu.GetList();

            TLPTenColCount = tableLP_ThayDoiTen.ColumnCount;
            TLPCVColCount = tableLP_ThayDoiCV.ColumnCount;
            TLPCapBacColCount = tableLP_ThayDoiCapBac.ColumnCount;
        }

        private void PrepareSourceLoaiQuyetDinh()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("loai_quyet_dinh_id", typeof(int));
            dt.Columns.Add("ten_loai_quyet_dinh", typeof(string));

            dt.Rows.Add(new object[2] { 1, "Đổi thông tin đơn vị" });

            thongTinQuyetDinh1.comB_Loai.DataSource = dt;
            thongTinQuyetDinh1.comB_Loai.DisplayMember = "ten_loai_quyet_dinh";
            thongTinQuyetDinh1.comB_Loai.ValueMember = "loai_quyet_dinh_id";

            thongTinQuyetDinh1.comB_Loai.SelectedIndex = 0;
        }

        private void DoiThongTinDV_Load(object sender, EventArgs e)
        {
            GenUI_Name(0);
            GenUI_Relationship(0);
            GenUI_Title(0);
        }

        #region Code giao diện

        /// <summary>
        /// Add cac control vao khung thay đổi tên.
        /// </summary>
        private void GenUI_Name(int row)
        {
            #region layout code
            Label lb = new Label();
            lb.Anchor = AnchorStyles.None;
            lb.Text = "Từ";
            lb.Name = "lbl_Tu_Ten_" + row.ToString();


            ComboBox com = new ComboBox();
            com.Anchor = AnchorStyles.None;
            com.DropDownStyle = ComboBoxStyle.DropDownList;
            com.Width = 500;
            com.Name = "comB_DV_Ten_" + row.ToString();


            Label lb2 = new Label();
            lb2.Anchor = AnchorStyles.None;
            lb2.Text = "Sang";
            lb2.Name = "lbl_Sang_Ten_" + row.ToString();


            TextBox txt = new TextBox();
            txt.Anchor = AnchorStyles.None;
            txt.Name = "txt_DV_Ten_" + row.ToString();
            txt.Width = 500;

            Label lb3 = new Label();
            lb3.Anchor = AnchorStyles.None;
            lb3.Text = "Viết tắt";
            lb3.Name = "lbl_Sang_Ten_tat_" + row.ToString();


            TextBox txt2 = new TextBox();
            txt2.Anchor = AnchorStyles.None;
            txt2.Name = "txt_DV_tat_Ten_" + row.ToString();
            txt2.Width = 500;


            Label lb_ten_them = new Label();
            lb_ten_them.MouseClick += new MouseEventHandler(lb_MouseClick);
            lb_ten_them.Anchor = AnchorStyles.None;
            lb_ten_them.Text = "Thêm";
            lb_ten_them.Cursor = Cursors.Hand;
            lb_ten_them.Font = new Font(lb_ten_them.Font.Name, lb_ten_them.Font.Size, FontStyle.Underline);
            lb_ten_them.ForeColor = Color.Blue;
            lb_ten_them.Name = "txt_Them_Ten_" + row.ToString();


            Label lb_ten_xoa = new Label();
            lb_ten_xoa.Anchor = AnchorStyles.None;
            lb_ten_xoa.MouseClick += new MouseEventHandler(lb_MouseClick);
            lb_ten_xoa.Text = "Xoá";
            lb_ten_xoa.Cursor = Cursors.Hand;
            lb_ten_xoa.Font = new Font(lb_ten_them.Font.Name, lb_ten_them.Font.Size, FontStyle.Underline);
            lb_ten_xoa.ForeColor = Color.Blue;
            lb_ten_xoa.Name = "txt_Xoa_Ten_" + row.ToString();

            tableLP_ThayDoiTen.Controls.Add(lb, 0, row);
            tableLP_ThayDoiTen.Controls.Add(com, 1, row);
            tableLP_ThayDoiTen.Controls.Add(lb2, 2, row);
            tableLP_ThayDoiTen.Controls.Add(txt, 3, row);
            tableLP_ThayDoiTen.Controls.Add(lb3, 4, row);
            tableLP_ThayDoiTen.Controls.Add(txt2, 5, row);
            tableLP_ThayDoiTen.Controls.Add(lb_ten_them, 6, row);
            tableLP_ThayDoiTen.Controls.Add(lb_ten_xoa, 7, row);


            PopulateDonViComB(com,dtDonVi);
            #endregion

        }

        /// <summary>
        /// Add cac control vao khung thay đổi quan hệ.
        /// </summary>
        private void GenUI_Relationship(int row)
        {

            #region layout code
            ComboBox com = new ComboBox();
            com.Anchor = AnchorStyles.None;
            com.DropDownStyle = ComboBoxStyle.DropDownList;
            com.Width = 500;
            com.Name = "comB_DV_CapBac_" + row.ToString();
            com.SelectionChangeCommitted += new EventHandler(com_SelectionChangeCommitted);

            Label lb2 = new Label();
            lb2.Anchor = AnchorStyles.None;
            lb2.Text = " Chuyển sang trực thuộc";
            lb2.Width = 500;
            lb2.Name = "lbl_Sang_CapBac_" + row.ToString();


            ComboBox com3 = new ComboBox();
            com3.Anchor = AnchorStyles.None;
            com3.DropDownStyle = ComboBoxStyle.DropDownList;
            com3.Width = 500;
            com3.Name = "comB_Sang_CapBac_" + row.ToString();


            Label lb_ten_them = new Label();
            lb_ten_them.MouseClick += new MouseEventHandler(lb_MouseClick);
            lb_ten_them.Anchor = AnchorStyles.None;
            lb_ten_them.Text = "Thêm";
            lb_ten_them.Cursor = Cursors.Hand;
            lb_ten_them.Font = new Font(lb_ten_them.Font.Name, lb_ten_them.Font.Size, FontStyle.Underline);
            lb_ten_them.ForeColor = Color.Blue;
            lb_ten_them.Name = "txt_Them_CapBac_" + row.ToString();


            Label lb_ten_xoa = new Label();
            lb_ten_xoa.Anchor = AnchorStyles.None;
            lb_ten_xoa.MouseClick += new MouseEventHandler(lb_MouseClick);
            lb_ten_xoa.Text = "Xoá";
            lb_ten_xoa.Cursor = Cursors.Hand;
            lb_ten_xoa.Font = new Font(lb_ten_them.Font.Name, lb_ten_them.Font.Size, FontStyle.Underline);
            lb_ten_xoa.ForeColor = Color.Blue;
            lb_ten_xoa.Name = "txt_Xoa_CapBac_" + row.ToString();


            tableLP_ThayDoiCapBac.Controls.Add(com, 0, row);
            tableLP_ThayDoiCapBac.Controls.Add(lb2, 1, row);
            tableLP_ThayDoiCapBac.Controls.Add(com3, 2, row);
            tableLP_ThayDoiCapBac.Controls.Add(lb_ten_them, 3, row);
            tableLP_ThayDoiCapBac.Controls.Add(lb_ten_xoa, 4, row);

            PopulateDonViComB(com,dtDonVi);
            if (dtDonVi.Rows.Count > 1)
            {
                dtChuyenDonVi = (from p in dtDonVi.AsEnumerable() where p.Field<int>("id") != Convert.ToInt32(com.SelectedValue) select p).CopyToDataTable();
                PopulateDonViComB(com3, dtChuyenDonVi);
            }
            
            #endregion
        }

        void com_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dtDonVi.Rows.Count > 1)
            {
                ComboBox combo = (ComboBox)sender;
                TableLayoutPanel TLP = (TableLayoutPanel)combo.Parent;
                ComboBox combo2 = (ComboBox)TLP.Controls["comB_Sang_CapBac_" + combo.Name.Substring(combo.Name.Length - 1, 1)];

                dtChuyenDonVi = (from p in dtDonVi.AsEnumerable() where p.Field<int>("id") != Convert.ToInt32(combo.SelectedValue) select p).CopyToDataTable();
                PopulateDonViComB(combo2, dtChuyenDonVi);
            }
            
        }

        /// <summary>
        /// Add cac control vao khung thay đổi Chức vụ.
        /// </summary>
        private void GenUI_Title(int row)
        {
            #region layout code
            ComboBox com = new ComboBox();
            com.Anchor = AnchorStyles.None;
            com.DropDownStyle = ComboBoxStyle.DropDownList;
            com.Width = 500;
            com.Name = "comB_DV_ChucVu_" + row.ToString();

            Label lb = new Label();
            lb.Anchor = AnchorStyles.None;
            lb.Text = "Từ";
            lb.Name = "lbl_Tu_ChucVu_" + row.ToString();


            ComboBox com2 = new ComboBox();
            com2.Anchor = AnchorStyles.None;
            com2.DropDownStyle = ComboBoxStyle.DropDownList;
            com2.Width = 500;
            com2.Name = "comB_Tu_ChucVu_" + row.ToString();


            Label lb2 = new Label();
            lb2.Anchor = AnchorStyles.None;
            lb2.Text = "Sang";
            lb2.Name = "lbl_Sang_ChucVu_" + row.ToString();


            ComboBox com3 = new ComboBox();
            com3.Anchor = AnchorStyles.None;
            com3.DropDownStyle = ComboBoxStyle.DropDownList;
            com3.Width = 500;
            com3.Name = "comB_Sang_ChucVu_" + row.ToString();


            Label lb_ten_them = new Label();
            lb_ten_them.MouseClick += new MouseEventHandler(lb_MouseClick);
            lb_ten_them.Anchor = AnchorStyles.None;
            lb_ten_them.Text = "Thêm";
            lb_ten_them.Cursor = Cursors.Hand;
            lb_ten_them.Font = new Font(lb_ten_them.Font.Name, lb_ten_them.Font.Size, FontStyle.Underline);
            lb_ten_them.ForeColor = Color.Blue;
            lb_ten_them.Name = "txt_Them_ChucVu_" + row.ToString();


            Label lb_ten_xoa = new Label();
            lb_ten_xoa.Anchor = AnchorStyles.None;
            lb_ten_xoa.MouseClick += new MouseEventHandler(lb_MouseClick);
            lb_ten_xoa.Text = "Xoá";
            lb_ten_xoa.Cursor = Cursors.Hand;
            lb_ten_xoa.Font = new Font(lb_ten_them.Font.Name, lb_ten_them.Font.Size, FontStyle.Underline);
            lb_ten_xoa.ForeColor = Color.Blue;
            lb_ten_xoa.Name = "txt_Xoa_ChucVu_" + row.ToString();

            tableLP_ThayDoiCV.Controls.Add(com, 0, row);
            tableLP_ThayDoiCV.Controls.Add(lb, 1, row);
            tableLP_ThayDoiCV.Controls.Add(com2, 2, row);
            tableLP_ThayDoiCV.Controls.Add(lb2, 3, row);
            tableLP_ThayDoiCV.Controls.Add(com3, 4, row);
            tableLP_ThayDoiCV.Controls.Add(lb_ten_them, 5, row);
            tableLP_ThayDoiCV.Controls.Add(lb_ten_xoa, 6, row);

            PopulateDonViComB(com,dtDonVi);
            PopulateChucVuComB(com2,dtChucVu);
            PopulateChucVuComB(com3, dtChucVu);

            #endregion
        }

        /// <summary>
        /// xét label dược click thuộc tableLP nào, row index nào
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lb_MouseClick(object sender, MouseEventArgs e)
        {
            Label lb = ((Label)(sender));
            TableLayoutPanel TLP = ((TableLayoutPanel)(lb.Parent));
            string name = lb.Name;
            int TLPRows = TLP.RowCount;
            int lbRow = TLP.GetRow(lb);
            int lbCol = TLP.GetColumn(lb);

            if (name.Contains("Xoa"))
            {
                if (TLPRows > 1)   // khong duoc xoa dong cuoi cung
                {
                    // dòng bị xoá là dòng cuối 
                    //thì unhide "Thêm" ở dòng kế cuối
                    if ((lbRow + 1) == TLPRows)
                    {
                        Control c = TLP.Controls[lbCol - 1 + TLP.ColumnCount * (lbRow - 1)];    // trừ 1 để chuyển sang lb Thêm
                        c.Visible = true;
                    }
                    AddRemoveRow(TLP, "Remove", lbRow);
                    MoveUp(TLP, lbRow);
                }
            }
            else if (name.Contains("Them"))
            {
                if (TLPRows < 4)    // gioi han 4 dong
                {
                    TLP.Controls[lbCol + TLP.ColumnCount * (lbRow)].Visible = false; // hide chữ "thêm" trước khi thêm mới 
                    AddRemoveRow(TLP, "Add", ++lbRow);
                }
                else
                {
                    MessageBox.Show("Số lượng dòng vượt quá giới hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        /// <summary>
        /// move up controls sau khi xoá
        /// </summary>
        /// <param name="TLP"></param>
        private void MoveUp(TableLayoutPanel TLP, int DelRow)
        {
            for (int i = ++DelRow; i <= TLP.RowCount; i++)
            {
                int BackRow = i - 1;
                for (int y = 0; y < TLP.ColumnCount; y++)
                {
                    Control c = TLP.Controls[BackRow * TLP.ColumnCount + y];
                    TLP.SetRow(c, BackRow);


                }
            }

        }

        /// <summary>
        /// thêm xoá dòng tương ứng trong TLP
        /// dịch chuyển các control
        /// </summary>
        /// <param name="tableLP">ten TLP muốn thêm / xoá dòng</param>
        /// <param name="Action" value="Add/Remove">"Add","Remove"</param>
        /// <param name="row">index của dòng</param>
        private void AddRemoveRow(TableLayoutPanel tableLP, string Action, int row)
        {
            if (Action == "Add")
            {
                tableLP.RowStyles.Insert(row, new RowStyle(SizeType.Absolute));                
                tableLP.RowCount++;
                CalculateHeight(tableLP);
                
                switch (tableLP.Name)
                {
                    case "tableLP_ThayDoiTen":
                        GenUI_Name(row);
                        break;
                    case "tableLP_ThayDoiCV":
                        GenUI_Title(row);
                        break;
                    case "tableLP_ThayDoiCapBac":
                        GenUI_Relationship(row);
                        break;

                    default:
                        break;
                }

            }
            else if (Action == "Remove")
            {
                tableLP.RowStyles.RemoveAt(row);
                tableLP.RowCount--;
                CalculateHeight(tableLP);
                RemoveControlsFromTLP(tableLP, row);
            }
        }

        /// <summary>
        /// Dùng khi xoá 1 dòng trong TLP
        /// </summary>
        /// <param name="TLP"></param>
        /// <param name="Controls"></param>
        private void RemoveControlsFromTLP(TableLayoutPanel TLP, int row)
        {
            for (int i = 0; i < TLP.ColumnCount; i++)
            {
                Control c = TLP.Controls[row * TLP.ColumnCount];    // do khi remove, thứ tự index sẽ bị đôn lên
                TLP.Controls.Remove(c);
            }
        }

        private void cb_ThayDoi_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = ((CheckBox)(sender));
            switch (cb.Name)
            {
                case "cb_ThayDoiCapBac":
                    tableLP_ThayDoiCapBac.Enabled = cb.Checked;
                    break;
                case "cb_ThayDoiTen":
                    tableLP_ThayDoiTen.Enabled = cb.Checked;
                    break;
                case "cb_ThayDoiChucVu":
                    tableLP_ThayDoiCV.Enabled = cb.Checked;
                    break;
                default:
                    break;
            }
        }

        private void CalculateHeight(TableLayoutPanel TLP)
        {
            for (int i = 0; i < TLP.RowCount; i++)
            {
                TLP.RowStyles[i].Height = TLP.Height / TLP.RowCount;
            }
        }

        #endregion

        private void PopulateDonViComB(ComboBox comb,DataTable dt)
        {
            DataTable newdt = dt.Copy();
            comb.DataSource = newdt;
            comb.DisplayMember = "ten_don_vi";
            comb.ValueMember = "id";

            if (dtDonVi.Rows.Count > 0)
                comb.SelectedIndex = 0;
        }

        private void PopulateChucVuComB(ComboBox comb,DataTable dt)
        {
            DataTable newdt = dt.Copy();
            comb.DataSource = newdt;
            comb.DisplayMember = "ten_chuc_vu";
            comb.ValueMember = "id";

            if (dtChucVu.Rows.Count > 0)
                comb.SelectedIndex = 0;
        }

        private void btn_Nhap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn nhập quyết định này hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int[] IDDV_Ten = null; string[] TenDV_Ten = null; string[] TenDVTat_Ten = null;
                int[] IDDV_CV = null; int[] IDCu_CV = null; int[] IDMoi_CV = null;
                int[] IDDV_CapBac = null; int[] IDDVCha_CapBac = null;

                try
                {
                    if (VerifyAndGetDataQD(ref IDDV_Ten, ref TenDV_Ten, ref TenDVTat_Ten,
                                            ref   IDDV_CV, ref  IDCu_CV, ref  IDMoi_CV,
                                            ref   IDDV_CapBac, ref  IDDVCha_CapBac))
                    {
                        GetQDDetails();

                        oQuyetDinh.Add_ThayDoiThongTinDV(IDDV_Ten, TenDV_Ten, TenDVTat_Ten, IDDV_CV, IDCu_CV, IDMoi_CV, IDDV_CapBac, IDDVCha_CapBac);

                        MessageBox.Show("Nhập quyết định thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nhập không thành công.\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {

        }

        private bool VerifyAndGetDataQD(ref int[] m_IDDV_Ten, ref string[] m_TenDV_Ten, ref string[] m_TenDVTat_Ten,                                        
                                        ref  int[] m_IDDV_CV, ref int[] m_IDCu_CV, ref int[] m_IDMoi_CV,
                                        ref  int[] m_IDDV_CapBac, ref int[] m_IDDVCha_CapBac)
        {
            if (string.IsNullOrWhiteSpace(thongTinQuyetDinh1.txt_MaQD.Text) || string.IsNullOrWhiteSpace(thongTinQuyetDinh1.txt_TenQD.Text))
            {
                throw new Exception("Mã và tên quyết định không được để trống.");
            }

            #region Ten
            if (cb_ThayDoiTen.Checked)
            {
                m_IDDV_Ten = new int[tableLP_ThayDoiTen.RowCount];
                m_TenDV_Ten = new string[tableLP_ThayDoiTen.RowCount];
                m_TenDVTat_Ten = new string[tableLP_ThayDoiTen.RowCount];
                for (int i = 0; i < tableLP_ThayDoiTen.RowCount; i++)
                {
                    TextBox txt_TenDV = (TextBox)tableLP_ThayDoiTen.Controls[i * TLPTenColCount + TenDVPos];
                    TextBox txt_TenDV_Tat = (TextBox)tableLP_ThayDoiTen.Controls[i * TLPTenColCount + TenDVTatPos];
                    if (string.IsNullOrWhiteSpace(txt_TenDV.Text))
                    {
                        throw new Exception("Tên đơn vị không được để trống.");
                    }
                    else
                    {
                        m_TenDV_Ten[i] = txt_TenDV.Text.Trim();
                        m_TenDVTat_Ten[i] = txt_TenDV_Tat.Text.Trim();
                    }

                    m_IDDV_Ten[i] = Convert.ToInt32(((ComboBox)tableLP_ThayDoiTen.Controls[i * TLPTenColCount + DV_TenPos]).SelectedValue);
                }

                if (m_IDDV_Ten.Distinct().Count() < m_IDDV_Ten.Length)    // distinct ma < length ==> co don vi trung nhau
                {
                    throw new Exception("Đơn vị ở phần thay đổi tên đơn vị không được trùng lắp.");
                }
            } 
            #endregion

            #region Chuc Vu
            if (cb_ThayDoiChucVu.Checked)
            {
                int[] a = new int[tableLP_ThayDoiCV.RowCount * 2];
                m_IDDV_CV = new int[tableLP_ThayDoiCV.RowCount];
                m_IDCu_CV = new int[tableLP_ThayDoiCV.RowCount];
                m_IDMoi_CV = new int[tableLP_ThayDoiCV.RowCount];

                for (int i = 0; i < tableLP_ThayDoiCV.RowCount; i++)
                {
                    m_IDDV_CV[i] = Convert.ToInt32(((ComboBox)tableLP_ThayDoiCV.Controls[i * TLPCVColCount + DV_CVPos]).SelectedValue);
                    a[i * 2] = m_IDCu_CV[i] = Convert.ToInt32(((ComboBox)tableLP_ThayDoiCV.Controls[i * TLPCVColCount + CD_TuPos]).SelectedValue);
                    a[i * 2 + 1] = m_IDMoi_CV[i] = Convert.ToInt32(((ComboBox)tableLP_ThayDoiCV.Controls[i * TLPCVColCount + CD_SangPos]).SelectedValue);
                }

                if (a.Distinct().Count() < a.Length)    // distinct ma < length ==> co don vi trung nhau
                {
                    throw new Exception("Chức vụ ở phần thay đổi tên Chức vụ không được trùng lắp.");
                }
            } 
            #endregion

            #region Cap Bac
            if (cb_ThayDoiCapBac.Checked)
            {
                m_IDDV_CapBac = new int[tableLP_ThayDoiCapBac.RowCount];
                m_IDDVCha_CapBac = new int[tableLP_ThayDoiCapBac.RowCount];

                for (int i = 0; i < tableLP_ThayDoiCapBac.RowCount; i++)
                {
                    m_IDDV_CapBac[i] = Convert.ToInt32(((ComboBox)tableLP_ThayDoiCapBac.Controls[i * TLPCapBacColCount + DV_CapBacPos]).SelectedValue);
                    m_IDDVCha_CapBac[i] = Convert.ToInt32(((ComboBox)tableLP_ThayDoiCapBac.Controls[i * TLPCapBacColCount + DV_CapBacChaPos]).SelectedValue);
                }
                // distinct ma < length ==> co don vi trung nhau
                if (m_IDDV_CapBac.Distinct().Count() < m_IDDV_CapBac.Length)    
                {
                    throw new Exception("Đơn vị ở phần thay đổi tên cấp bậc không được trùng lắp.");
                }
            }
            
            #endregion

            return true;
            
        }

        private void GetQDDetails()
        {
            oQuyetDinh.Ma_Quyet_Dinh = thongTinQuyetDinh1.txt_MaQD.Text.Trim();
            oQuyetDinh.Ten_Quyet_Dinh = thongTinQuyetDinh1.txt_TenQD.Text;
            oQuyetDinh.Ngay_Ky = thongTinQuyetDinh1.dTP_NgayKy.Value;
            oQuyetDinh.Ngay_Ky_Tu = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;
            if (thongTinQuyetDinh1.dTP_NgayHetHan.Checked)
            {
                oQuyetDinh.Ngay_Ky_Den = thongTinQuyetDinh1.dTP_NgayHetHan.Value;
            }
            else
                oQuyetDinh.Ngay_Ky_Den = null;

            oQuyetDinh.MoTa = thongTinQuyetDinh1.rTB_MoTa.Text;
        }


    }
}
