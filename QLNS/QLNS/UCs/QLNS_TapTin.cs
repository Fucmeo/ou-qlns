using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QLNS.UCs
{
    public partial class QLNS_TapTin : UserControl
    {
        bool AddFlag;   // xac dinh thao tac add hay edit
        Business.CNVC.CNVC_File oFile;

        public QLNS_TapTin()
        {
            InitializeComponent();
            oFile = new Business.CNVC.CNVC_File();

        }

        

    }
}
