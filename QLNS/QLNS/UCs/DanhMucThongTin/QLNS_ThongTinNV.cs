using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.CNVC;

namespace QLNS.UCs.DanhMucThongTin
{
    public partial class QLNS_ThongTinNV : UserControl
    {
        public CNVC oCNVC = new CNVC();
        public DataTable dtCNVC;
        public QLNS_ThongTinNV()
        {
            InitializeComponent();
            dtCNVC = new DataTable();
        }

        public void GetCNVCInfo(string m_MaNV)
        {
            oCNVC.MaNV = m_MaNV;
            dtCNVC = oCNVC.GetData();
        }

        public void LoadInfo()
        {    
  
            if (dtCNVC != null && dtCNVC.Rows.Count > 0)
            {
                txt_MaHoSo.Text = Convert.ToString(dtCNVC.Rows[0]["ma_nv"]);
                txt_MaNV.Text = Convert.ToString(dtCNVC.Rows[0]["ma_nv"]);
                txt_Ho.Text =  Convert.ToString(dtCNVC.Rows[0]["ho"]);
                txt_Ten.Text = Convert.ToString(dtCNVC.Rows[0]["ten"]);
                txt_SoSoBHXH.Text = Convert.ToString(dtCNVC.Rows[0]["so_so_bhxh"]);
                txt_MaSoThue.Text = Convert.ToString(dtCNVC.Rows[0]["ma_so_thue"]);
                //txt_SoNha.Text = Convert.ToString(dtCNVC.Rows[0][""]);
                //txt_Duong.Text = Convert.ToString(dtCNVC.Rows[0][""]);
                //txt_PhuongXa.Text = Convert.ToString(dtCNVC.Rows[0][""]);
                //txt_QuanHuyen.Text = Convert.ToString(dtCNVC.Rows[0][""]);
                string gioitinh = dtCNVC.Rows[0]["gioi_tinh"].ToString();
                switch (gioitinh)
                {
                    case "True":
                        comB_GioiTinh.SelectedIndex = 0;
                        break;
                    case "False":
                        comB_GioiTinh.SelectedIndex = 1;
                        break;
                    default:
                        comB_GioiTinh.SelectedIndex = 2;
                        break;
                }
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {

        }
    }
}
