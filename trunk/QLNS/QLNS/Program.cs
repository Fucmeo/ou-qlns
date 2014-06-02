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
            //Application.Run(new Forms.Popup("",(new UCs.QLNS_QuocGiaTP())));
            Application.Run(new Forms.Main(new UCs.QLNS_HienThiThongTin()));
            //Application.Run(new Forms.Popup("test", new UCs.DanhMucThongTin.QLNS_NghienCuuKH()));
            //Application.Run(new Forms.Form1());
        }

        public static string selected_ma_nv = "";   // bien toan cuc ma_nv su dung khi hien thi thong tin nv

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

               // gb_init_heigh_percent : dung voi thu tu rowstyle cua TLP !!!!!
        static public void CollapseGroupBox(GroupBox collapse_gb , GroupBox[] other_gb, TableLayoutPanel TLP_Parent
            , int RowStyleIndex, UserControl UC, List<KeyValuePair<GroupBox,float>> gb_init_heigh_percent)
        {
            int CollapseSize = 30;
            int CollapsedGB = 1;        // so gb da collapse 
            int GBHeigh_Pixel = collapse_gb.Height;
            

            if (collapse_gb.Text.Contains("[+]"))    // Expand
            {
                for (int i = 0; i < gb_init_heigh_percent.Count; i++)
                {
                    TLP_Parent.RowStyles[i].SizeType = SizeType.Percent;

                    if (gb_init_heigh_percent[i].Key.Text.Contains("[-]") || i == RowStyleIndex) // gb dang expand hoac la gb duoc click
                    {
                        TLP_Parent.RowStyles[i].Height = gb_init_heigh_percent[i].Value;
                    }
                    else    // cac gb dang collapse
                    {
                        TLP_Parent.RowStyles[i].SizeType = SizeType.Absolute;
                        TLP_Parent.RowStyles[i].Height = CollapseSize;
                    }
                }
                collapse_gb.Text = collapse_gb.Text.Replace("[+]", "[-]");
            }
            else        // Collapse
            {
                for (int i = 0; i < other_gb.Length; i++)
                {
                    if (other_gb[i].Text.Contains("[+]"))
                    {
                        CollapsedGB++;
                    }
                }

                if (CollapsedGB < gb_init_heigh_percent.Count)   // o cho collapse gb cuoi cung
                {
                    TLP_Parent.RowStyles[RowStyleIndex].SizeType = SizeType.Absolute;
                    TLP_Parent.RowStyles[RowStyleIndex].Height = CollapseSize;

                    for (int i = 0; i < other_gb.Length; i++)
                    {
                        if (other_gb[i].Text.Contains("[-]"))      // cac gb dang expand
                        {
                            // (100% - (số gb đã collaspe * collapse size)) / ( so gb con lai - so gb đã collaspe = so gb chua collapse)
                            TLP_Parent.RowStyles[TLP_Parent.GetRow(other_gb[i])].SizeType = SizeType.Percent;
                            TLP_Parent.RowStyles[TLP_Parent.GetRow(other_gb[i])].Height += (100 - (CollapsedGB * CollapseSize)) / (other_gb.Length - CollapsedGB + 1);
                        }
                    }

                    for (int i = 0; i < other_gb.Length; i++)
                    {
                        if (other_gb[i].Text.Contains("[+]"))   // cac gb dang collapse
                        {
                            TLP_Parent.RowStyles[TLP_Parent.GetRow(other_gb[i])].SizeType = SizeType.Absolute;
                            TLP_Parent.RowStyles[TLP_Parent.GetRow(other_gb[i])].Height = CollapseSize;
                        }
                    }



                    collapse_gb.Text = collapse_gb.Text.Replace("[-]", "[+]");
                }

                
            }
        }
    }
}
