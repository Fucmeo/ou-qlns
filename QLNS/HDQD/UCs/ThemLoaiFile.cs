using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HDQD.UCs
{
    public partial class ThemLoaiFile : UserControl
    {
        Business.CNVC.CNVC_File oCNVC_File;
        string UCCallerName;    // ten UC cha goi UC them tinh quoc gia

        public ThemLoaiFile(string m_Caller)
        {
            InitializeComponent();
            oCNVC_File = new Business.CNVC.CNVC_File();
            UCCallerName = m_Caller;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_TenNhomTapTin.Text))
            {

                try
                {
                    bool i = oCNVC_File.AddFileGroup(txt_TenNhomTapTin.Text.Trim());
                    MessageBox.Show("Thao tác thêm thành công.\r\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ((Form)this.Parent.Parent).Close();
                    //if (i) // them thanh cong
                    //{
                    //    switch (UCCallerName)
                    //    {

                    //        case "QLNS_ThongTinNV_Phu":
                    //            QLNS.UCs.DanhMucThongTin.QLNS_ThongTinNV_Phu.nNewDanTocID = i;
                    //            break;

                    //        default:
                    //            break;
                    //    }
                        
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thao tác thêm không thành công.\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Xin vui lòng điền tên nhóm tập tin.\r\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
