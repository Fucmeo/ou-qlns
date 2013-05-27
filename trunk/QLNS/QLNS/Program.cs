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
            //Application.Run(new Forms.Popup("",new QLNS.UCs.DanhMucThongTin.QLNS_DienBienSK()));
            Application.Run(new Forms.Main(new UCs.QLNS_HienThiThongTin()));
            //Application.Run(new Forms.Popup("test", new UCs.DanhMucThongTin.QLNS_ChinhTri()));
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

        /// <summary>
        /// Expand / Collapse GroupBox
        /// </summary>
        /// <param name="TLP_Parent">TLP Cha (chứa các groupbox can collapse)</param>
        /// <param name="collapse_gb">GroupBox duoc click</param>
        /// <param name="gp_heigh_percent"></param>
        /// <param name="gp_text">tên group box</param>
        /// <param name="MinSize">phần trăm heigh cua gb thi collapse</param>
        /// <param name="MinimizedSize"></param>
        /// <param name="CollapseSize"></param>
        /// <param name="init_heigh_percent"></param>
        /// <param name="gp_bottom_or_top"></param>
        static public void CollapseGroupBox(TableLayoutPanel TLP_Parent, GroupBox collapse_gb,GroupBox[] other_gb
            , int gp_heigh_percent, string gp_text, int MinSize, float[] init_heigh_percent , List<int> ExcludeGB = null, int _RowStyleIndex = -1)
        {
            int RowStyleIndex;
            if (_RowStyleIndex == -1)
                RowStyleIndex = TLP_Parent.GetRow(collapse_gb);
            else
                RowStyleIndex = _RowStyleIndex;

            int RowStyleCount = TLP_Parent.RowStyles.Count;

            if (collapse_gb.Text.Contains("[+]"))    // Expand
            {
                //for (int i = MinimizedSize; i <= gp_heigh_percent; i = i + CollapseSize)
                //{
                //    collapse_gb.Height = i;
                //    //Refresh();
                //    //Thread.Sleep(1);
                //}
                collapse_gb.Text = "[-] " + gp_text;
                collapse_gb.Height = gp_heigh_percent;

                for (int i = 0; i < RowStyleCount; i++)
                {
                    if (ExcludeGB != null && ExcludeGB.Count > 0 && ExcludeGB.Contains(i))
                    {
                        
                    }
                    else
                    {
                        TLP_Parent.RowStyles[i].SizeType = SizeType.Percent;
                        //TLP.RowStyles[i].Height = TLP.Height * init_percent_heigh[i];
                        TLP_Parent.RowStyles[i].Height = init_heigh_percent[i];
                    }
                    

                }
                collapse_gb.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top);
            }
            else        // Collapse
            {
                float increase_percent = TLP_Parent.Height / ( RowStyleCount - ExcludeGB.Count);
                //for (int i = gp_heigh_percent; i >= MinimizedSize; i = i - CollapseSize)
                //{
                //    collapse_gb.Height = i;
                //    //Refresh();
                //    //Thread.Sleep(1);
                //}
                collapse_gb.Text = "[+] " + gp_text;
                //gp.Height = MinimizedSize;

                for (int i = 0; i < RowStyleCount; i++)
                {
                    TLP_Parent.RowStyles[i].SizeType = SizeType.Percent;
                    if (i != RowStyleIndex)
                    {
                        //gp.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                        //TLP.RowStyles[i].Height = TLP.Height * init_percent_heigh[i] + increase_percent;
                        if (ExcludeGB != null && ExcludeGB.Count > 0 && ExcludeGB.Contains(i))
                        {
                            
                        }
                        else
                        {
                            TLP_Parent.RowStyles[i].Height = init_heigh_percent[i] + ((gp_heigh_percent - MinSize) / (RowStyleCount - 1));
                        }
                    }
                    else
                    {
                        collapse_gb.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                        TLP_Parent.RowStyles[i].Height = MinSize;
                    }
                }

                for (int i = 0; i < other_gb.Length; i++)
                {
                    other_gb[i].Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top);
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
                UC.Height += GBHeigh_Pixel;
                collapse_gb.Text = collapse_gb.Text.Replace("[+]", "[-]");
            }
            else        // Collapse
            {
                TLP_Parent.RowStyles[RowStyleIndex].SizeType = SizeType.Absolute;
                TLP_Parent.RowStyles[RowStyleIndex].Height = CollapseSize;

                for (int i = 0; i < other_gb.Length; i++)
                {
                    if (other_gb[i].Text.Contains("[+]"))
                    {
                        CollapsedGB++;
                    }
                }

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
                TLP_Parent.AutoScrollMinSize = new System.Drawing.Size(TLP_Parent.AutoScrollMinSize.Width
                                                                    ,TLP_Parent.AutoScrollMinSize.Height - GBHeigh_Pixel);

                collapse_gb.Text = collapse_gb.Text.Replace("[-]", "[+]");
            }
        }
    }
}
