﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HDQD.Forms
{
    public partial class Popup : Form
    {
        UserControl oUC;
        public Popup(UserControl _oUC)
        {
            InitializeComponent();
            oUC = _oUC;
            this.Size = oUC.Size;
        }

        public Popup()
        {
            UCs.DoiThongTinDV ucHopDong = new UCs.DoiThongTinDV();            
            ucHopDong.Dock = DockStyle.Fill;
            this.Controls.Add(ucHopDong);
        }

        private void Popup_Load(object sender, EventArgs e)
        {
            oUC.Dock = DockStyle.Fill;
            this.Controls.Add(oUC);
        }
    }
}
