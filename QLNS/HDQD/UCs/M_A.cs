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
        Business.DonVi oDonvi;
        
        public M_A()
        {
            InitializeComponent();
            oDonvi = new DonVi();
        }

        private void M_A_Load(object sender, EventArgs e)
        {
            GenUI_TuDonVi(0);

            PreapreDataSource();
        }

        #region Private Methods
        private void PreapreDataSource()
        {
            DataTable dt = oDonvi.GetDonViList();
            DataRow row = dt.NewRow();
            dt.Rows.InsertAt(row, 0);

            comb_DVTrucThuoc.DataSource = dt;
            comb_DVTrucThuoc.DisplayMember = "ten_don_vi";
            comb_DVTrucThuoc.ValueMember = "id";
        }

        #endregion

        #region Khang
        #region Code giao diện

        /// <summary>
        /// Add combo box vao tableLP Tu Don Vi
        /// </summary>
        private void GenUI_TuDonVi(int row)
        {
            #region layout code
            ComboBox com = new ComboBox();
            com.Anchor = AnchorStyles.None;
            com.DropDownStyle = ComboBoxStyle.DropDownList;
            com.Width = 500;
            com.Name = "comB_TuDV_" + row.ToString();

            Label lb_ten_xoa = new Label();
            lb_ten_xoa.Anchor = AnchorStyles.Right;
            lb_ten_xoa.MouseClick += new MouseEventHandler(lb_ten_xoa_MouseClick);
            lb_ten_xoa.Text = "Xoá";
            lb_ten_xoa.Cursor = Cursors.Hand;
            lb_ten_xoa.Font = new Font(lb_ten_xoa.Font.Name, lb_ten_xoa.Font.Size, FontStyle.Underline);
            lb_ten_xoa.ForeColor = Color.Blue;
            lb_ten_xoa.Name = "txt_Xoa_Ten_" + row.ToString();

            tableLP_ComboTuDV.Controls.Add(com, 0, row);
            tableLP_ComboTuDV.Controls.Add(lb_ten_xoa, 1, row);

            #endregion
        }

        void lb_ten_xoa_MouseClick(object sender, MouseEventArgs e)
        {
            Label lb = ((Label)(sender));
            int TLPRows = tableLP_ComboTuDV.RowCount;
            int lbRow = tableLP_ComboTuDV.GetRow(lb);
            int lbCol = tableLP_ComboTuDV.GetColumn(lb);


            if (TLPRows > 1)   // khong duoc xoa dong cuoi cung
            {
                AddRemoveRow(tableLP_ComboTuDV, "Remove", lbRow);
                MoveUp(tableLP_ComboTuDV, lbRow);
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

                GenUI_TuDonVi(row);
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

        private void btn_ThemTuDV_Click(object sender, EventArgs e)
        {
            int TLPRows = tableLP_ComboTuDV.RowCount;
            int lbRow = tableLP_ComboTuDV.RowCount;


            if (TLPRows < 10)    // gioi han 10 dong
            {
                AddRemoveRow(tableLP_ComboTuDV, "Add", lbRow);
            }
            else
            {
                MessageBox.Show("Số lượng dòng vượt quá giới hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        #endregion
        
        
    }
}
