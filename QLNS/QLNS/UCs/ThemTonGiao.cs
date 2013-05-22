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
    public partial class ThemTonGiao : UserControl
    {
        Business.TonGiao oTonGiao;
        string UCCallerName;    // ten UC cha goi UC them tinh quoc gia

        public ThemTonGiao(string m_Caller)
        {
            InitializeComponent();
            oTonGiao = new Business.TonGiao();
            UCCallerName = m_Caller;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_TenTonGiao.Text))
            {
                oTonGiao.TenTonGiao = txt_TenTonGiao.Text;

                try
                {
                    int i = oTonGiao.AddWithReturnID();
                    MessageBox.Show("Thao tác thêm thành công.\r\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (i != 0) // them thanh cong
                    {
                        switch (UCCallerName)
                        {
                            
                            case "QLNS_ThongTinNV_Phu":
                                QLNS.UCs.DanhMucThongTin.QLNS_ThongTinNV_Phu.nNewTonGiaoID = i;
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
                MessageBox.Show("Xin vui lòng điền tên tôn giáo.\r\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
