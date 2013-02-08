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
        public DoiThongTinDV()
        {
            InitializeComponent();
        }

        private void DoiThongTinDV_Load(object sender, EventArgs e)
        {
            GenUI_Name(0);
        }

        /// <summary>
        /// Add cac control vao khung thay đổi tên.
        /// </summary>
        private void GenUI_Name(int row)
        {
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

            switch (TLP.Name)
            {
                case "tableLP_ThayDoiTen":
                    if (name.Contains("Xoa"))
                    {
                        if (TLPRows > 1)   // khong duoc xoa dong cuoi cung
                        {
                            // dòng bị xoá là dòng cuối 
                            //thì unhide "Thêm" ở dòng kế cuối
                            if ((lbRow+1) == TLPRows)
                            {
                                Control c = TLP.Controls[4 + TLP.ColumnCount * (lbRow-1)];
                                c.Visible = true;
                            }
                            AddRemoveRow(tableLP_ThayDoiTen, "Remove", lbRow);
                            MoveUp(tableLP_ThayDoiTen, lbRow);
                        }
                    }
                    else if (name.Contains("Them"))
                    {
                        if (TLPRows < 4)    // gioi han 4 dong
                        {
                            TLP.Controls[4 + TLP.ColumnCount * (lbRow)].Visible = false; // hide chữ "thêm" trước khi thêm mới 
                            AddRemoveRow(tableLP_ThayDoiTen, "Add", ++lbRow);
                        }
                        else
                        {
                            MessageBox.Show("Số lượng dòng vượt quá giới hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;

                //case "tableLP_ThayDoiCD":
                //    if (name.Contains("Xoa"))
                //    {
                //        AddRemoveRow(tableLP_ThayDoiCD, "Remove", row);
                //    }
                //    else if (name.Contains("Them"))
                //    {
                //        AddRemoveRow(tableLP_ThayDoiCD, "Add", row);
                //    }
                //    break;

                //case "tableLP_ThayDoiCapBac":
                //    if (name.Contains("Xoa"))
                //    {
                //        AddRemoveRow(tableLP_ThayDoiCapBac, "Remove", row);
                //    }
                //    else if (name.Contains("Them"))
                //    {
                //        AddRemoveRow(tableLP_ThayDoiCapBac, "Add", row);
                //    }
                //    break;

                default:
                    break;
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
        /// Add cac control vao khung thay đổi cấp bậc.
        /// </summary>
        private void GenUI_Relationship()
        {

        }

        /// <summary>
        /// Add cac control vao khung thay đổi chức danh.
        /// </summary>
        private void GenUI_Title()
        {

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
                GenUI_Name(row);
            }
            else if (Action == "Remove")
            {
                tableLP.RowCount--;
                switch (tableLP.Name)
                {
                    case "tableLP_ThayDoiTen":

                        RemoveControlsFromTLP(tableLP_ThayDoiTen, row);

                        break;
                    default:
                        break;
                }
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
                Control c = TLP.Controls[row  * TLP.ColumnCount ];    // do khi remove, thứ tự index sẽ bị đôn lên
                TLP.Controls.Remove(c);
            }
        }
    }
}
