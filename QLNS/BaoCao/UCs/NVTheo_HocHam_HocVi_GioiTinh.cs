using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;
using CrystalDecisions.CrystalReports.Engine;

namespace BaoCao.UCs
{
    public partial class NVTheo_HocHam_HocVi_GioiTinh : UserControl
    {
        Business.DonVi oDonVi;
        Business.BaoCao oBaoCao;
        Business.ChucDanh oChucDanh;
        Business.VanBangChinhQuy oVangBangChinhQuy;

        bool LoadListBoxFinish = false; // de ngan tu dong trigger  event clb_DonVi_SelectedIndexChanged
        bool AllChecked = false;

        public NVTheo_HocHam_HocVi_GioiTinh()
        {
            InitializeComponent();
            oDonVi = new Business.DonVi();
            oBaoCao = new Business.BaoCao();
            oChucDanh = new ChucDanh();
            oVangBangChinhQuy = new VanBangChinhQuy();
        }

        private void NVTheo_HocHam_HocVi_GioiTinh_Load(object sender, EventArgs e)
        {
            try
            {
                LoadListBoxFinish = false;

                DataTable dt_dv = oDonVi.GetActiveDonVi();
                DataRow dr_dv = dt_dv.NewRow();
                dr_dv["ten_don_vi"] = "Tất cả";
                dr_dv["id"] = -1;
                dt_dv.Rows.InsertAt(dr_dv, 0);

                clb_DonVi.DataSource = dt_dv;
                clb_DonVi.ValueMember = "id";
                clb_DonVi.DisplayMember = "ten_don_vi";


                DataTable dt_hocham = oVangBangChinhQuy.GetVanBangList();
                DataRow dr_hocham = dt_hocham.NewRow();
                dr_hocham["ten_van_bang"] = "Tất cả";
                dr_hocham["id"] = -1;
                dt_hocham.Rows.InsertAt(dr_hocham, 0);

                clb_HocHam.DataSource = dt_hocham;
                clb_HocHam.ValueMember = "id";
                clb_HocHam.DisplayMember = "ten_van_bang";

                DataTable dt_chucdanh = oChucDanh.GetListWithNoEmptyRow();
                DataRow dr_chucdanh = dt_chucdanh.NewRow();
                dr_chucdanh["ten_chuc_danh"] = "Tất cả";
                dr_chucdanh["id"] = -1;
                dt_chucdanh.Rows.InsertAt(dr_chucdanh, 0);

                clb_ChucDanh.DataSource = dt_chucdanh;
                clb_ChucDanh.ValueMember = "id";
                clb_ChucDanh.DisplayMember = "ten_chuc_danh";

                LoadListBoxFinish = true;
            }
            catch (Exception)
            {
               
            }
        }

        private void clb_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (LoadListBoxFinish)
            {
                object selecteditem = ((CheckedListBox)sender).SelectedItem;

                DataRowView drv = (DataRowView)selecteditem;
                if (Convert.ToInt32(drv["id"]) == -1)
                {
                    if (((CheckedListBox)sender).GetItemCheckState(0) == CheckState.Checked)
                    {
                        for (int i = 0; i < ((CheckedListBox)sender).Items.Count; i++)
                        {
                            ((CheckedListBox)sender).SetItemCheckState(i, CheckState.Checked);
                        }
                    }
                    else if (((CheckedListBox)sender).GetItemCheckState(0) == CheckState.Unchecked)
                    {
                        for (int i = 0; i < ((CheckedListBox)sender).Items.Count; i++)
                        {
                            ((CheckedListBox)sender).SetItemCheckState(i, CheckState.Unchecked);
                        }
                    }
                }
                else
                {
                    if (((CheckedListBox)sender).GetItemCheckState(((CheckedListBox)sender).SelectedIndex) == CheckState.Checked)
                    {
                        AllChecked = true;
                        for (int i = 1; i < ((CheckedListBox)sender).Items.Count; i++)
                        {
                            if (((CheckedListBox)sender).GetItemCheckState(i) == CheckState.Unchecked)
                            {
                                AllChecked = false;
                                break;
                            }
                        }
                    }
                    else if (((CheckedListBox)sender).GetItemCheckState(((CheckedListBox)sender).SelectedIndex) == CheckState.Unchecked)
                    {
                        ((CheckedListBox)sender).SetItemCheckState(0, CheckState.Unchecked);
                        AllChecked = false;
                    }

                    if (AllChecked)
                    {
                        ((CheckedListBox)sender).SetItemCheckState(0, CheckState.Checked);
                    }
                }
                       
            }

        }

        private void btn_BaoCao_Click(object sender, EventArgs e)
        {
            List<int> SelectedDV = new List<int>();

            if (clb_DonVi.GetItemCheckState(0) == CheckState.Checked)
                SelectedDV = null;
            else
            {
                foreach (object item in clb_DonVi.CheckedItems)
                {
                    DataRowView drv = (DataRowView)item;

                    SelectedDV.Add(Convert.ToInt32(drv["id"]));
                }

                if (SelectedDV.Count <= 0) SelectedDV = null;
            }

            List<int> SelectedHocHam = new List<int>();

            if (clb_HocHam.GetItemCheckState(0) == CheckState.Checked)
                SelectedHocHam = null;
            else
            {
                foreach (object item in clb_HocHam.CheckedItems)
                {
                    DataRowView drv = (DataRowView)item;

                    SelectedHocHam.Add(Convert.ToInt32(drv["id"]));
                }

                if (SelectedHocHam.Count <= 0) SelectedHocHam = null;
            }

            List<int> SelectedChucDanh = new List<int>();

            if (clb_ChucDanh.GetItemCheckState(0) == CheckState.Checked)
                SelectedChucDanh = null;
            else
            {
                foreach (object item in clb_ChucDanh.CheckedItems)
                {
                    DataRowView drv = (DataRowView)item;

                    SelectedChucDanh.Add(Convert.ToInt32(drv["id"]));
                }

                if (SelectedChucDanh.Count <= 0) SelectedChucDanh = null;
            }

            DataTable dt_NV = oBaoCao.NV_Theo_HocHam_HocVi_GioiTinh(SelectedDV, SelectedChucDanh, SelectedHocHam);

            DataSet.NVTheo_HocHam_HocVi_GioiTinh ds = new DataSet.NVTheo_HocHam_HocVi_GioiTinh();
            Reports.NVTheo_HocHam_HocVi_GioiTinh rpt = new Reports.NVTheo_HocHam_HocVi_GioiTinh();

            rpt.SetDataSource(dt_NV);
            crystalReportViewer1.ReportSource = rpt;

            ((TextObject)(rpt.Subreports["Header.rpt"].ReportDefinition.ReportObjects["rptName"])).Text = "Báo cáo thống kê nhân viên";


        }
    }
}
