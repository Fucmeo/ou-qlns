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
    public partial class ThemTinhTP : UserControl
    {
        Business.TinhTP oTinhTP ;
        string UCCallerName;    // ten UC cha goi UC them tinh tp
        public ThemTinhTP()
        {
            InitializeComponent();
            oTinhTP = new Business.TinhTP();
        }

        public ThemTinhTP(string m_Caller)
        {
            InitializeComponent();
            oTinhTP = new Business.TinhTP();
            UCCallerName = m_Caller;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Ten.Text))
            {
                oTinhTP.TenTinhTP = txt_Ten.Text;
                oTinhTP.MoTa = rTB_GhiChu.Text;
                try
                {
                    int i = oTinhTP.AddWithReturnID();
                    MessageBox.Show("Thao tác thêm thành công.\r\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (i != 0) // them thanh cong
                    {
                        switch (UCCallerName)
                        {
                            case "QLNS_ThongTinNV":
                                QLNS.UCs.DanhMucThongTin.QLNS_ThongTinNV.nNewTinhTPID = i;
                                break;

                            default:
                                break;
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thao tác thêm không thành công.\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Xin vui lòng điền tên tỉnh thành phố.\r\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
