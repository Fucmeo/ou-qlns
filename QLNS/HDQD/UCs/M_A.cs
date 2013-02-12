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
    public partial class M_A : UserControl
    {
        Business.DonVi oDonVi;
        DataTable dtDonVi, dtChuyenDonVi;
        public M_A()
        {
            InitializeComponent();
            oDonVi = new DonVi();
            dtDonVi = oDonVi.GetActiveDonVi();
        }

        private void M_A_Load(object sender, EventArgs e)
        {
            GenUI_ToDV(0);
            GenUI_FromDV(0);
        }

        #region code giao diện
        /// <summary>
        /// Add cac control vao khung thay đổi tên.
        /// </summary>
        private void GenUI_FromDV(int row)
        {
            #region layout code
            Label lb = new Label();
            lb.Anchor = AnchorStyles.Left;
            lb.Text = "Từ đơn vị";
            lb.Name = "lbl_Tu_" + row.ToString();

            ComboBox com = new ComboBox();
            com.Anchor = AnchorStyles.None;
            com.DropDownStyle = ComboBoxStyle.DropDownList;
            com.Width = 500;
            com.Name = "comB_DV_Tu_" + row.ToString();

            TextBox txt = new TextBox();
            txt.Enabled = false;
            txt.Anchor = AnchorStyles.None;
            txt.Name = "txt_DV_cha_Tu_" + row.ToString();
            txt.Width = 500;

            TextBox txt2 = new TextBox();
            txt2.Enabled = false;
            txt2.Anchor = AnchorStyles.None;
            txt2.Name = "txt_DV_viet_tat_Tu_" + row.ToString();
            txt2.Width = 500;

            Label lb_ten_them = new Label();
            lb_ten_them.MouseClick += new MouseEventHandler(lb_MouseClick);
            lb_ten_them.Anchor = AnchorStyles.None;
            lb_ten_them.Text = "Thêm";
            lb_ten_them.Cursor = Cursors.Hand;
            lb_ten_them.Font = new Font(lb_ten_them.Font.Name, lb_ten_them.Font.Size, FontStyle.Underline);
            lb_ten_them.ForeColor = Color.Blue;
            lb_ten_them.Name = "txt_Them_Tu_" + row.ToString();


            Label lb_ten_xoa = new Label();
            lb_ten_xoa.Anchor = AnchorStyles.None;
            lb_ten_xoa.MouseClick += new MouseEventHandler(lb_MouseClick);
            lb_ten_xoa.Text = "Xoá";
            lb_ten_xoa.Cursor = Cursors.Hand;
            lb_ten_xoa.Font = new Font(lb_ten_them.Font.Name, lb_ten_them.Font.Size, FontStyle.Underline);
            lb_ten_xoa.ForeColor = Color.Blue;
            lb_ten_xoa.Name = "txt_Xoa_Tu_" + row.ToString();

            tableLP_Tu.Controls.Add(lb, 0, row);
            tableLP_Tu.Controls.Add(com, 1, row);
            tableLP_Tu.Controls.Add(txt, 2, row);
            tableLP_Tu.Controls.Add(txt2, 3, row);
            tableLP_Tu.Controls.Add(lb_ten_them, 4, row);
            tableLP_Tu.Controls.Add(lb_ten_xoa, 5, row);


            PopulateDonViComB(com, dtDonVi);
            #endregion

        }

        private void GenUI_ToDV(int row)
        {
            #region layout code
            Label lb = new Label();
            lb.Anchor = AnchorStyles.None;
            lb.Text = "Sang tên";
            lb.Name = "lbl_Sang_" + row.ToString();

            TextBox txt = new TextBox();
            txt.Anchor = AnchorStyles.None;
            txt.Name = "txt_DV_Sang_" + row.ToString();
            txt.Width = 500;

            Label lb3 = new Label();
            lb3.Anchor = AnchorStyles.None;
            lb3.Text = "Đơn vị trực thuộc";

            ComboBox com = new ComboBox();
            com.Anchor = AnchorStyles.None;
            com.DropDownStyle = ComboBoxStyle.DropDownList;
            com.Width = 500;
            com.Name = "comB_DV_cha_Sang_" + row.ToString();

            Label lb4 = new Label();
            lb4.Anchor = AnchorStyles.None;
            lb4.Text = "Tên viết tắt";

            TextBox txt2 = new TextBox();
            txt2.Anchor = AnchorStyles.None;
            txt2.Name = "txt_DV_viet_tat_Sang_" + row.ToString();
            txt2.Width = 500;

            Label lb5 = new Label();
            lb5.Anchor = AnchorStyles.None;
            lb5.Text = "Ghi chú";

            RichTextBox rtb = new RichTextBox();
            //rtb.Dock = DockStyle.Fill;
            rtb.Anchor = AnchorStyles.None;
            rtb.Name = "rtb_GhiChu" + row.ToString();
            rtb.Height = 100;
            rtb.Width = 500;

            Label lb6 = new Label();
            lb6.Anchor = AnchorStyles.None;
            lb6.Text = "Ngày hết hạn";

            DateTimePicker dtp = new DateTimePicker();
            dtp.ShowCheckBox = true;
            dtp.Checked = false;
            dtp.CustomFormat = "dd/MM/yyyy";
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.Name = "dtp_NgayHetHan_" + row.ToString();
            dtp.Anchor = AnchorStyles.None;

            Label lb_ten_them = new Label();
            lb_ten_them.MouseClick += new MouseEventHandler(lb_MouseClick);
            lb_ten_them.Anchor = AnchorStyles.None;
            lb_ten_them.Text = "Thêm";
            lb_ten_them.Cursor = Cursors.Hand;
            lb_ten_them.Font = new Font(lb_ten_them.Font.Name, lb_ten_them.Font.Size, FontStyle.Underline);
            lb_ten_them.ForeColor = Color.Blue;
            lb_ten_them.Name = "txt_Them_Sang_" + row.ToString();


            Label lb_ten_xoa = new Label();
            lb_ten_xoa.Anchor = AnchorStyles.None;
            lb_ten_xoa.MouseClick += new MouseEventHandler(lb_MouseClick);
            lb_ten_xoa.Text = "Xoá";
            lb_ten_xoa.Cursor = Cursors.Hand;
            lb_ten_xoa.Font = new Font(lb_ten_them.Font.Name, lb_ten_them.Font.Size, FontStyle.Underline);
            lb_ten_xoa.ForeColor = Color.Blue;
            lb_ten_xoa.Name = "txt_Xoa_Sang_" + row.ToString();

            Label lb_tim_nv = new Label();
            lb_tim_nv.Anchor = AnchorStyles.None;
            lb_tim_nv.MouseClick += new MouseEventHandler(lb_tim_nv_MouseClick);
            lb_tim_nv.Text = "Tìm nhân viên";
            lb_tim_nv.Cursor = Cursors.Hand;
            lb_tim_nv.Font = new Font(lb_ten_them.Font.Name, lb_ten_them.Font.Size, FontStyle.Underline);
            lb_tim_nv.ForeColor = Color.Blue;
            lb_tim_nv.Name = "txt_Xoa_Sang_" + row.ToString();

            tableLP_Sang.Controls.Add(lb, 0, row);
            tableLP_Sang.Controls.Add(txt, 1, row);
            tableLP_Sang.Controls.Add(lb3, 2, row);
            tableLP_Sang.Controls.Add(com, 3, row);
            tableLP_Sang.Controls.Add(lb4, 4, row);
            tableLP_Sang.Controls.Add(txt2, 5, row);
            tableLP_Sang.Controls.Add(lb5, 6, row);
            tableLP_Sang.Controls.Add(rtb, 7, row);
            tableLP_Sang.Controls.Add(lb6, 8, row);
            tableLP_Sang.Controls.Add(dtp, 9, row);
            tableLP_Sang.Controls.Add(lb_ten_them, 10, row);
            tableLP_Sang.Controls.Add(lb_ten_xoa, 11, row);
            tableLP_Sang.Controls.Add(lb_tim_nv, 12, row);

            PopulateDonViComB(com, dtChuyenDonVi);

            #endregion

        }

        void lb_tim_nv_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        /// <summary>
        /// duyệt các selected value ở TLP From, exclude nó trong comb DV trực thuộc ở TLP To
        /// </summary>
        /// <returns>Datatable chứa các đơn vị đã exclude</returns>
        //private DataTable ExcludeFromDonVi()
        //{
        //    DataTable dt = new DataTable();
        //    List<int> l = new List<int>();
        //    for (int i = 0; i < tableLP_Tu.RowCount; i++)
        //    {
        //        ComboBox c = (ComboBox)tableLP_Tu.Controls[i*tableLP_Tu.ColumnCount + 1];
        //        l.Add(Convert.ToInt32(c.SelectedValue));
        //    }
        //    //p.Field<int>("id"))
        //    dt = (from p in dtDonVi.AsEnumerable().Except(l) select p).CopyToDataTable();

        //    return dt;
        //}

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
                    case "tableLP_Tu":
                        GenUI_FromDV(row);
                        break;
                    case "tableLP_Sang":
                        GenUI_ToDV(row);
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

        private void CalculateHeight(TableLayoutPanel TLP)
        {
            for (int i = 0; i < TLP.RowCount; i++)
            {
                TLP.RowStyles[i].Height = TLP.Height / TLP.RowCount;
            }
        } 
        #endregion

        private void PopulateDonViComB(ComboBox comb, DataTable dt)
        {
            DataTable newdt = dt.Copy();
            comb.DataSource = newdt;
            comb.DisplayMember = "ten_don_vi";
            comb.ValueMember = "id";

            if (dtDonVi.Rows.Count > 0)
                comb.SelectedIndex = 0;
        }

    }
}
