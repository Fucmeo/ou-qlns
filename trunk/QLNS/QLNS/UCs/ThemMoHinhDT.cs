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
        public ThemMoHinhDT()
        {
            InitializeComponent();
            oMoHinhDT = new Business.MoHinhDaoTao();
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
                        QLNS_DanhMucThongTin.nNewMoHinhDT = i;
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
