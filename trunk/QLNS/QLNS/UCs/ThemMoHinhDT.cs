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
    public partial class ThemMoHinhDT : UserControl
    {
        Business.MoHinhDaoTao oMoHinhDT;
        string UCCallerName;    // ten UC cha goi UC them tinh tp
        public ThemMoHinhDT(string m_Caller)
        {
            InitializeComponent();
            oMoHinhDT = new Business.MoHinhDaoTao();
            UCCallerName = m_Caller;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Ten.Text))
            {
                oMoHinhDT.TenMoHinh = txt_Ten.Text;
                oMoHinhDT.MoTa = rTB_MoTa.Text;
                try
                {
                    int i = oMoHinhDT.AddWithReturnID();
                    MessageBox.Show("Thao tác thêm thành công.\r\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (i != 0) // them thanh cong
                    {
                        switch (UCCallerName)
                        {
                            case "QLNS_TrinhDo_ChuyenMon":
                                QLNS.UCs.DanhMucThongTin.QLNS_TrinhDo_ChuyenMon.nNewMoHinhID = i;
                                break;

                            default:
                                break;
                        }
                        ((Form)this.Parent.Parent).Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thao tác thêm không thành công.\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Xin vui lòng điền tên mô hình.\r\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
