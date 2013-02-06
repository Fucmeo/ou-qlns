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
    public partial class QLNS_DSTinh : UserControl
    {
        bool check_all = false;
        TinhTP tinhtp;
        string ma_tinhtp = "";
        string ten_tinhtp = "";
        DataTable dsTinhTP;

        public QLNS_DSTinh()
        {
            InitializeComponent();
            tinhtp = new TinhTP();
            dsTinhTP = new DataTable();
        }

        private void btn_ChonTatCa_Click(object sender, EventArgs e)
        {
            if (check_all == false) //Nếu check all = false ==> set tick chọn toàn bộ
            {
                for (int i = 0; i < cLB_TinhTP.Items.Count; i++)
                {
                    cLB_TinhTP.SetItemChecked(i, true);
                }
                check_all = true;
            }
            else //Nếu check all = true ==> untick all
            {
                for (int i = 0; i < cLB_TinhTP.Items.Count; i++)
                {
                    cLB_TinhTP.SetItemChecked(i, false);
                }
                check_all = false;
            }
        }

        private void QLNS_DSTinh_Load(object sender, EventArgs e)
        {
            dsTinhTP = tinhtp.GetData_Compact();
            foreach (DataRow dr in dsTinhTP.Rows)
            {
                cLB_TinhTP.Items.Add(dr[1], false);
            }
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            ten_tinhtp = "";
            for (int i = 0; i < cLB_TinhTP.Items.Count; i++)
            {
                if (cLB_TinhTP.GetItemChecked(i) == true)
                    ten_tinhtp += cLB_TinhTP.Items[i].ToString() + "; ";
            }
            if (ten_tinhtp != "")
            {
                QLNS_TimKiem.ds_tinh_tp = ten_tinhtp.Substring(0, ten_tinhtp.Length - 2);
                QLNS_TimKiem.ClosePopup();
            }
        }
    }
}
