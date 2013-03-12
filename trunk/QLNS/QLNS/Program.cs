using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLNS
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
            //Application.Run(new Forms.QLNS_ThongTin());
            Application.Run(new Forms.Main(new UCs.QLNS_HienThiThongTin()));
        }

        public static string selected_ma_nv = "";

        static public void DkButton(Button[] ShowButtons, Button[] HideButtons)
        {
            foreach (Button sb in ShowButtons)
            {
                sb.Visible = true;
            }
            foreach (Button hb in HideButtons)
            {
                hb.Visible = false;
            }
        }

        static public void DkControl(Object[] controls, bool val, string type)
        {
            foreach (Control c in controls)
            {
                if (type == "Enable")
                {
                    c.Enabled = val;
                }
                else if (type == "Visible")
                {
                    c.Visible = val;
                }
            }
        }
    }
}
