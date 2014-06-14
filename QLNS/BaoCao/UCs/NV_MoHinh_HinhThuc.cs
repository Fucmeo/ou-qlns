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
    public partial class NV_MoHinh_HinhThuc : UserControl
    {
        Business.MoHinhDaoTao oMoHinhDaoTao;
        Business.HinhThucDaoTao oHinhThucDaoTao;
        Business.BaoCao oBaoCao;

        public NV_MoHinh_HinhThuc()
        {
            InitializeComponent();
            oMoHinhDaoTao = new MoHinhDaoTao();
            oHinhThucDaoTao = new HinhThucDaoTao();
            oBaoCao = new Business.BaoCao();
        }

        private void NV_MoHinh_HinhThuc_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_mh = oMoHinhDaoTao.GetData();
                DataTable dt_ht = oHinhThucDaoTao.GetData();

                clb_MoHinh.DataSource = dt_mh;
                clb_MoHinh.ValueMember = "id";
                clb_MoHinh.DisplayMember = "ten_mo_hinh";


                clb_HinhThuc.DataSource = dt_ht;
                clb_HinhThuc.ValueMember = "id";
                clb_HinhThuc.DisplayMember = "ten_hinh_thuc";

            }
            catch (Exception)
            {

            }
        }

        private void btn_BaoCao_Click(object sender, EventArgs e)
        {
            List<int> SelectedMoHinh = new List<int>();
            List<int> SelectedHinhThuc = new List<int>();

            foreach (object item in clb_MoHinh.CheckedItems)
            {
                DataRowView drv = (DataRowView)item;
                SelectedMoHinh.Add(Convert.ToInt32(drv["id"]));
            }

            if (SelectedMoHinh.Count <= 0) SelectedMoHinh = null;

            foreach (object item in clb_HinhThuc.CheckedItems)
            {
                DataRowView drv = (DataRowView)item;
                SelectedHinhThuc.Add(Convert.ToInt32(drv["id"]));
            }

            if (SelectedHinhThuc.Count <= 0) SelectedHinhThuc = null;

          
            DataTable dt_NV = oBaoCao.NV_Theo_HinhThuc_MoHinh(SelectedMoHinh, SelectedHinhThuc);

            DataSet.NV_MoHinh_HinhThuc ds = new DataSet.NV_MoHinh_HinhThuc();
            Reports.NV_MoHinh_HinhThuc rpt = new Reports.NV_MoHinh_HinhThuc();

            rpt.SetDataSource(dt_NV);
            crystalReportViewer1.ReportSource = rpt;

            ((TextObject)(rpt.Subreports["Header.rpt"].ReportDefinition.ReportObjects["rptName"])).Text = "BÁO CÁO NHÂN VIÊN HỌC TẬP NƯỚC NGOÀI";


        }
    }
}
