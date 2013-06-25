using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HDQD
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
            Application.Run(new Forms.Popup(new UCs.HopDong(), "QUẢN LÝ NHÂN SỰ - Loại phụ cấp"));
            //Application.Run(new Forms.Popup(new UCs.BoNhiem(), "QUẢN LÝ NHÂN SỰ - Thành lập đơn vị"));
        }
    }
}
