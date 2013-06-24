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
    public partial class DinhNghiaCT : UserControl
    {
        public  List<string> lstDisplayString,lstValueString;
        Business.HDQD.LoaiPhuCap oLoaiPhuCap;
        DataTable dtCongThucElement;
        int MouseCursorIndex;
        
        public DinhNghiaCT()
        {
            InitializeComponent();
            dtCongThucElement = new DataTable();
            oLoaiPhuCap = new Business.HDQD.LoaiPhuCap();
            lstValueString = new List<string>();
            lstDisplayString = new List<string>();
            if (lstDisplayString.Count > 0)
            {
                rtb_CongThuc.Text = string.Join(" ", lstDisplayString.ToArray());
            }
        }

        private void rtb_CongThuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void DinhNghiaCT_Load(object sender, EventArgs e)
        {
            dtCongThucElement = oLoaiPhuCap.GetDTCongThucElement();
            BindCongThucElementToLstB();
        }

        private void BindCongThucElementToLstB()
        {
            if (dtCongThucElement.Rows.Count > 0)
            {
                lstb_PhanTu.DataSource = dtCongThucElement;
                lstb_PhanTu.DisplayMember = "value_desc";
                lstb_PhanTu.ValueMember = "value_id";
            }
        }

        private void btn_Input_Click(object sender, EventArgs e)
        {
            if (lstb_PhanTu.SelectedItem != null)
            {
                rtb_CongThuc.Text += "[ " + lstb_PhanTu.Text + " ] ";
                lstValueString.Add(lstb_PhanTu.SelectedValue.ToString());
                lstDisplayString.Add(lstb_PhanTu.Text);
            }
            else if (lstb_ToanTu.SelectedItem != null)
            {
                rtb_CongThuc.Text += "[ " + lstb_ToanTu.Text + " ] ";
                lstValueString.Add(lstb_ToanTu.Text);
                lstDisplayString.Add(lstb_ToanTu.Text);
            }

        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            int i = rtb_CongThuc.SelectionStart;
            string s = rtb_CongThuc.Text;
            int LeftBracketsIndex;
            int a = s.Count();
            if (i != 0 & i - 1 <= s.Count() )
            {
                LeftBracketsIndex = s.LastIndexOf("[ ", i-1);
                if (LeftBracketsIndex >= 0) LeftBracketsIndex -= 1;
                string removed_string = s.Substring(LeftBracketsIndex + 1, i - 1 - LeftBracketsIndex);
                int removed_index = lstDisplayString.IndexOf(removed_string.Replace("[","").Replace("]","").Trim());
                lstValueString.RemoveAt(removed_index);
                lstDisplayString.Remove(removed_string.Replace("[", "").Replace("]", "").Trim());
                s = s.Remove(LeftBracketsIndex + 1 , i  -1 - LeftBracketsIndex);
                rtb_CongThuc.Text = s;
            }
        }

        private void rtb_CongThuc_MouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(rtb_CongThuc.SelectionStart.ToString());
            MouseCursorIndex = rtb_CongThuc.SelectionStart;
            MoveCursor();
        }

        private void MoveCursor()
        {
            string s = rtb_CongThuc.Text.Trim();
            int RightBracketsIndex;
            if (s.Count() > MouseCursorIndex - 1)
            {
                RightBracketsIndex = s.IndexOf("]", MouseCursorIndex);
                if(RightBracketsIndex  == -1)
                    rtb_CongThuc.SelectionStart = s.Count() ;
                else
                {
                    rtb_CongThuc.SelectionStart = RightBracketsIndex + 2;
                }
            }
        }


        private void lstb_ToanTu_MouseClick(object sender, MouseEventArgs e)
        {
            lstb_PhanTu.ClearSelected();
        }

        private void lstb_PhanTu_MouseClick(object sender, MouseEventArgs e)
        {
            lstb_ToanTu.ClearSelected();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                ((Form)this.Parent.Parent).Close();
            }
            catch (Exception)
            {
                
            }
        }
    }
}
