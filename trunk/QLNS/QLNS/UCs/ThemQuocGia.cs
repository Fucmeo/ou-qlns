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
    public partial class ThemQuocGia : UserControl
    {
        Business.QuocGia oQuocGia;
        string UCCallerName;    // ten UC cha goi UC them tinh quoc gia

        public ThemQuocGia(string m_Caller)
        {
            InitializeComponent();
            oQuocGia = new Business.QuocGia();
            UCCallerName = m_Caller;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_TenQuocGia.Text))
            {
                oQuocGia.TenQuocGia = txt_TenQuocGia.Text;

                try
                {
                    int i = oQuocGia.AddWithReturnID();
                    MessageBox.Show("Thao tác thêm thành công.\r\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (i != 0) // them thanh cong
                    {
                        switch (UCCallerName)
                        {
                            case "QLNS_ThongTinNV":
                                QLNS.UCs.DanhMucThongTin.QLNS_ThongTinNV.nNewQuocGiaID = i;
                                break;
                            case "QLNS_ThongTinNV_Phu":
                                QLNS.UCs.DanhMucThongTin.QLNS_ThongTinNV_Phu.nNewQuocGiaID = i;
                                break;
                            case "QLNS_LichSuBanThan":
                                QLNS.UCs.DanhMucThongTin.QLNS_LichSuBanThan.nNewQuocGiaID = i;
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
                MessageBox.Show("Xin vui lòng điền tên quốc gia.\r\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
