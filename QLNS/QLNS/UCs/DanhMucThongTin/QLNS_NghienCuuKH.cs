using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNS.UCs.DanhMucThongTin
{
    public partial class QLNS_NghienCuuKH : UserControl
    {
        List<KeyValuePair<GroupBox, float>> lst_gb;

        public QLNS_NghienCuuKH()
        {
            InitializeComponent();

            lst_gb = new List<KeyValuePair<GroupBox, float>>();
            lst_gb.Add(new KeyValuePair<GroupBox, float>(gb_Sach, float.Parse("20")));
            lst_gb.Add(new KeyValuePair<GroupBox, float>(gb_ChuongTrinh, float.Parse("20")));
            lst_gb.Add(new KeyValuePair<GroupBox, float>(gb_BaiBao, float.Parse("20")));
            lst_gb.Add(new KeyValuePair<GroupBox, float>(gb_BangPhatMinh, float.Parse("15")));
            lst_gb.Add(new KeyValuePair<GroupBox, float>(gb_HuongDanNCS, float.Parse("25")));

            gb_Sach.MouseClick += new MouseEventHandler(gb_Sach_MouseClick);
            gb_ChuongTrinh.MouseClick += new MouseEventHandler(gb_ChuongTrinh_MouseClick);
            gb_BaiBao.MouseClick += new MouseEventHandler(gb_BaiBao_MouseClick);
            gb_BangPhatMinh.MouseClick += new MouseEventHandler(gb_BangPhatMinh_MouseClick);

            gb_HuongDanNCS.MouseClick += new MouseEventHandler(gb_HuongDanNCS_MouseClick);

        }

        void gb_HuongDanNCS_MouseClick(object sender, MouseEventArgs e)
        {
            Program.CollapseGroupBox((GroupBox)sender, 
                new GroupBox[] { gb_Sach, gb_ChuongTrinh, gb_BaiBao, gb_BangPhatMinh }, tableLP_NghienCuuKH, 4, this,lst_gb);
        }

        void gb_BangPhatMinh_MouseClick(object sender, MouseEventArgs e)
        {
            Program.CollapseGroupBox((GroupBox)sender,
                new GroupBox[] { gb_Sach, gb_ChuongTrinh, gb_BaiBao, gb_HuongDanNCS }, tableLP_NghienCuuKH, 3, this, lst_gb);
        }

        void gb_BaiBao_MouseClick(object sender, MouseEventArgs e)
        {
            Program.CollapseGroupBox((GroupBox)sender,
                new GroupBox[] { gb_Sach, gb_ChuongTrinh, gb_BangPhatMinh, gb_HuongDanNCS }, tableLP_NghienCuuKH, 2, this, lst_gb);
        }

        void gb_ChuongTrinh_MouseClick(object sender, MouseEventArgs e)
        {
            Program.CollapseGroupBox((GroupBox)sender,
                new GroupBox[] { gb_Sach, gb_BaiBao, gb_BangPhatMinh, gb_HuongDanNCS }, tableLP_NghienCuuKH, 1, this, lst_gb);
        }

        void gb_Sach_MouseClick(object sender, MouseEventArgs e)
        {
            Program.CollapseGroupBox((GroupBox)sender,
                new GroupBox[] { gb_ChuongTrinh, gb_BaiBao, gb_BangPhatMinh, gb_HuongDanNCS }, tableLP_NghienCuuKH, 0, this, lst_gb);
        }

        private void lb_Them_ChuBien_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Forms.Popup("QUẢN LÝ NHÂN SỰ - THÊM CHỦ BIÊN", new NCKH_ThemNguoi());
            f.ShowDialog();
        }
    }
}
