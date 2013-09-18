using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;

namespace HDQD.UCs
{
    public partial class QDDungHopDong : UserControl
    {
        Business.HDQD.CNVC_HopDong oHopDong;
        DataTable dtDSHopDong;
        
        public QDDungHopDong()
        {
            InitializeComponent();
            oHopDong = new Business.HDQD.CNVC_HopDong();
            dtDSHopDong = new DataTable();

        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string ma_nv = txt_MaNV.Text == "" ? null : txt_MaNV.Text;
            string ma_hd = txt_MaHD.Text == "" ? null : txt_MaHD.Text;
            string ho_nv = txt_Ho.Text == "" ? null : txt_Ho.Text;
            string ten_nv = txt_Ten.Text == "" ? null : txt_Ten.Text;

            try
            {
                dtDSHopDong = oHopDong.Search_Dung_HD(ma_hd, ma_nv, ho_nv, ten_nv);
                if (dtDSHopDong != null)
                {
                    UCs.DSCNVC.eParentUC = DSCNVC.ParentUC.DungHopDong;
                    Forms.Popup frPopup = new Forms.Popup(new UCs.DSCNVC(dtDSHopDong), "QUẢN LÝ NHÂN SỰ - DANH SÁCH CNVC");
                    frPopup.ShowDialog();
                }
            }
            catch { }
        }

        #region Private Methods
        
        #endregion
    }
}
