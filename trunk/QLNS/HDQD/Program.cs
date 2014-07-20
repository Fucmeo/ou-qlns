using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HDQD
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Business.CNVC.CNVC_File o = new Business.CNVC.CNVC_File();
            //o.Path.Add(@"D:\Entertainment\Pictures\Fashion\54CD3_55euro.jpg");
            //o.MoTa.Add("Mô tả");
            //o.Link.Add("Link HD");
            //o.Group.Add(1);
            //o.FileName.Add("HD Name");
            //o.Path.Add(@"D:\Untitled.png");
            //o.MoTa.Add("Mô tả");
            //o.Link.Add("Link HD");
            //o.Group.Add(1);
            //o.FileName.Add("HD Name");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.Popup(new UCs.QDKhenThuong_ChuyenNgach(),"HD"));
            //Application.Run(new Forms.Popup(new UCs.BoNhiem(), "QUẢN LÝ NHÂN SỰ - Thành lập đơn vị"));
        }

        public static string ma_nv = "", ho ="", ten=""; // cho viec search nv o phan chart
    }
}
