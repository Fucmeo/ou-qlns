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
    public partial class NVTheo_DV : UserControl
    {
        Business.DonVi oDonVi;
        Business.BaoCao oBaoCao;
        public NVTheo_DV()
        {
            InitializeComponent();
            oDonVi = new Business.DonVi();
            oBaoCao = new Business.BaoCao();
        }

        private void NVTheo_DV_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_dv = oDonVi.GetActiveDonVi();


                clb_DV.DataSource = dt_dv;
                clb_DV.ValueMember = "id";
                clb_DV.DisplayMember = "ten_don_vi";



            }
            catch (Exception)
            {

            }
        }

        private void btn_BaoCao_Click(object sender, EventArgs e)
        {
            List<int> SelectedDV = new List<int>();

            foreach (object item in clb_DV.CheckedItems)
            {
                DataRowView drv = (DataRowView)item;
                SelectedDV.Add(Convert.ToInt32(drv["id"]));
            }

            if (SelectedDV.Count <= 0) SelectedDV = null;

            bool? con_hd;
            DateTime? dt_tu_ngay = new DateTime();
            DateTime? dt_den_ngay = new DateTime();

            if (rb_TheoTinhTrang.Checked)
            {
                con_hd = rb_ConHD.Checked;
                dt_tu_ngay = dt_den_ngay = null;
            }
            else
            {
                con_hd = null;

                if (dtp_TuNgay.Checked) dt_tu_ngay = dtp_TuNgay.Value;
                else dt_tu_ngay = null;


                if (dtp_DenNgay.Checked) dt_den_ngay = dtp_DenNgay.Value;
                else dt_den_ngay = null;
            }

            try
            {

                DataTable dt_NV = oBaoCao.NV_Theo_DV(SelectedDV, dt_tu_ngay, dt_den_ngay, con_hd);
                //DataSet.NVTheo_DV ds = new DataSet.NVTheo_DV();
                Reports.NVTheo_DV rpt = new Reports.NVTheo_DV();

                rpt.SetDataSource(dt_NV);
                crystalReportViewer1.ReportSource = rpt;
                ((TextObject)(rpt.Subreports["Header.rpt"].ReportDefinition.ReportObjects["rptName"])).Text = "BÁO CÁO NHÂN VIÊN THEO ĐƠN VỊ";

            }
            catch (Exception)
            {
                
            }
           

        }

        private void rb_TheoTinhTrang_CheckedChanged(object sender, EventArgs e)
        {
            rb_ConHD.Enabled = rb_HetHD.Enabled = rb_TheoTinhTrang.Checked;
        }

        private void rb_TheoThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            dtp_DenNgay.Enabled = dtp_TuNgay.Enabled = rb_TheoThoiGian.Checked;
        }
    }
}
