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
            tableLP_ThayDoiTen.Controls.Add(lb, 0, row);

            ComboBox com = new ComboBox();
            com.Anchor = AnchorStyles.None;
            com.DropDownStyle = ComboBoxStyle.DropDownList;
            com.Width = 500;
            com.Name = "comB_DV_Ten_" + row.ToString();
            tableLP_ThayDoiTen.Controls.Add(com, 1, row);

            Label lb2 = new Label();
            lb2.Anchor = AnchorStyles.None;
            lb2.Text = "Sang";
            lb2.Name = "lbl_Sang_Ten_" + row.ToString();
            tableLP_ThayDoiTen.Controls.Add(lb2, 2, row);

            TextBox txt = new TextBox();
            txt.Anchor = AnchorStyles.None;
            txt.Name = "txt_DV_Ten_" + row.ToString();
            txt.Width = 500;
            tableLP_ThayDoiTen.Controls.Add(txt, 3, row);

            Label lb_ten_them = new Label();
            lb_ten_them.MouseClick += new MouseEventHandler(lb_MouseClick);
            lb_ten_them.Anchor = AnchorStyles.None;
            lb_ten_them.Text = "Thêm";
            lb_ten_them.Cursor = Cursors.Hand;
            lb_ten_them.Font = new Font(lb_ten_them.Font.Name,lb_ten_them.Font.Size, FontStyle.Underline);
            lb_ten_them.ForeColor = Color.Blue;
            lb_ten_them.Name = "txt_Them_Ten_"+ row.ToString();
            tableLP_ThayDoiTen.Controls.Add(lb_ten_them, 4, row);

            Label lb_ten_xoa = new Label();
            lb_ten_xoa.Anchor = AnchorStyles.None;
            lb_ten_xoa.MouseClick += new MouseEventHandler(lb_MouseClick);
            lb_ten_xoa.Text = "Xoá";
            lb_ten_xoa.Cursor = Cursors.Hand;
            lb_ten_xoa.Font = new Font(lb_ten_them.Font.Name, lb_ten_them.Font.Size, FontStyle.Underline);
            lb_ten_xoa.ForeColor = Color.Blue;
            lb_ten_xoa.Name = "txt_Xoa_Ten_" + row.ToString();
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
            string name = lb.Name;
            //int row = ((TableLayoutPanel)(lb.Parent)).GetRow(lb);
            //int row = Convert.ToInt16(name.Substring(name.Length - 1));
            int row = ((TableLayoutPanel)(lb.Parent)).RowCount;

            switch (lb.Parent.Name)
            {
                case "tableLP_ThayDoiTen":
                    if (name.Contains("Xoa"))
                    {
                        if (row != 1)   // khong duoc xoa dong dau tien
                        {
                            AddRemoveRow(tableLP_ThayDoiTen, "Remove", row);
                        }
                    }
                    else if (name.Contains("Them"))
                    {
                        if (row < 4)    // gioi han 4 dong
                        {
                            //tableLP_ThayDoiTen.Controls.Remove(lb); // remove chữ "thêm" trước khi thêm mới 
                            AddRemoveRow(tableLP_ThayDoiTen, "Add", row);
                        }
                        else
                        {
                            MessageBox.Show("Số lượng dòng vượt quá giới hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    break;

                case "tableLP_ThayDoiCD":
                    if (name.Contains("Xoa"))
                    {
                        AddRemoveRow(tableLP_ThayDoiCD, "Remove", row);
                    }
                    else if (name.Contains("Them"))
                    {
                        AddRemoveRow(tableLP_ThayDoiCD, "Add", row);
                    }
                    break;

                case "tableLP_ThayDoiCapBac":
                    if (name.Contains("Xoa"))
                    {
                        AddRemoveRow(tableLP_ThayDoiCapBac, "Remove", row);
                    }
                    else if (name.Contains("Them"))
                    {
                        AddRemoveRow(tableLP_ThayDoiCapBac, "Add", row);
                    }
                    break;

                default:
                    break;
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
        /// <param name="row"></param>
        private void AddRemoveRow(TableLayoutPanel tableLP, string Action, int row)
        {
            if (Action == "Add")
            {
                //string lbName = tableLP.Controls.Remove(
                tableLP.RowStyles.Add(new RowStyle());
                tableLP.RowCount++;
                GenUI_Name(row);
            }
            else if (Action == "Remove")
            {
                tableLP.RowCount--;
                row--;
                tableLP.RowStyles.RemoveAt(row);
                switch (tableLP.Name)
                {
                    case "tableLP_ThayDoiTen":

                        RemoveControlsFromTLP(tableLP_ThayDoiTen, new string[] { "lbl_Tu_Ten_" + row.ToString(), 
                        "comB_DV_Ten_" + row.ToString(),
                        "lbl_Sang_Ten_" + row.ToString(),
                        "txt_DV_Ten_" + row.ToString(),
                        "txt_Them_Ten_"+ row.ToString(),
                        "txt_Xoa_Ten_" + row.ToString()});

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
        private void RemoveControlsFromTLP(TableLayoutPanel TLP, string[] Controls)
        {
            foreach (string Control in Controls)
            {
                TLP.Controls.Remove(TLP.Controls[Control]);
            }
        }
    }
}
