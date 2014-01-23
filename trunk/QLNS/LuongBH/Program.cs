using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LuongBH
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LuongBH.Form1(new UCs.Luong.TinhLuong()));
        }
    }
}
