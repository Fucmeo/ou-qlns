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
        DataTable dtDonVi , dtChucVu;

        public DoiThongTinDV()
        {
            InitializeComponent();
            oDonVi = new DonVi();
            oChucVu = new ChucVu();
            dtDonVi = oDonVi.GetActiveDonVi();
            dtChucVu = oChucVu.GetList();
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
            tableLP_ThayDoiTen.Controls.Add(lb_ten_them, 4, row);
            tableLP_ThayDoiTen.Controls.Add(lb_ten_xoa, 5, row);


            PopulateDonViComB(com);
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

            Label lb = new Label();
            lb.Anchor = AnchorStyles.None;
            lb.Text = "Từ";
            lb.Name = "lbl_Tu_CapBac_" + row.ToString();


            ComboBox com2 = new ComboBox();
            com2.Anchor = AnchorStyles.None;
            com2.DropDownStyle = ComboBoxStyle.DropDownList;
            com2.Width = 500;
            com2.Name = "comB_Tu_CapBac_" + row.ToString();


            Label lb2 = new Label();
            lb2.Anchor = AnchorStyles.None;
            lb2.Text = "Sang";
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
            tableLP_ThayDoiCapBac.Controls.Add(lb, 1, row);
            tableLP_ThayDoiCapBac.Controls.Add(com2, 2, row);
            tableLP_ThayDoiCapBac.Controls.Add(lb2, 3, row);
            tableLP_ThayDoiCapBac.Controls.Add(com3, 4, row);
            tableLP_ThayDoiCapBac.Controls.Add(lb_ten_them, 5, row);
            tableLP_ThayDoiCapBac.Controls.Add(lb_ten_xoa, 6, row);


            #endregion
        }

        /// <summary>
        /// Add cac control vao khung thay đổi chức danh.
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

            tableLP_ThayDoiCD.Controls.Add(com, 0, row);
            tableLP_ThayDoiCD.Controls.Add(lb, 1, row);
            tableLP_ThayDoiCD.Controls.Add(com2, 2, row);
            tableLP_ThayDoiCD.Controls.Add(lb2, 3, row);
            tableLP_ThayDoiCD.Controls.Add(com3, 4, row);
            tableLP_ThayDoiCD.Controls.Add(lb_ten_them, 5, row);
            tableLP_ThayDoiCD.Controls.Add(lb_ten_xoa, 6, row);

            PopulateDonViComB(com);
            PopulateChucVuComB(com2);
            PopulateChucVuComB(com3);

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
                tableLP.RowCount++;
                switch (tableLP.Name)
                {
                    case "tableLP_ThayDoiTen":
                        GenUI_Name(row);
                        break;
                    case "tableLP_ThayDoiCD":
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
                tableLP.RowCount--;
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
                case "cb_ThayDoiChucDanh":
                    tableLP_ThayDoiCD.Enabled = cb.Checked;
                    break;
                default:
                    break;
            }
        } 
        #endregion

        private void PopulateDonViComB(ComboBox comb)
        {
            comb.DataSource = dtDonVi;
            comb.DisplayMember = "ten_don_vi";
            comb.ValueMember = "id";

            if (dtDonVi.Rows.Count > 0)
                comb.SelectedIndex = 0;
        }

        private void PopulateChucVuComB(ComboBox comb)
        {
            comb.DataSource = dtChucVu;
            comb.DisplayMember = "ten_chuc_vu";
            comb.ValueMember = "id";

            if (dtChucVu.Rows.Count > 0)
                comb.SelectedIndex = 0;
        }
    }
}
