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
    public partial class NVTheo_LoaiQD : UserControl
    {
        Business.HDQD.LoaiQuyetDinh oLoaiQD;
        Business.BaoCao oBaoCao;

        public NVTheo_LoaiQD()
        {
            InitializeComponent();
            oLoaiQD = new Business.HDQD.LoaiQuyetDinh();
            oBaoCao = new Business.BaoCao();
        }

        private void NVTheo_LoaiQD_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_loaiqd = oLoaiQD.GetList_Compact();


                clb_LoaiQD.DataSource = dt_loaiqd;
                clb_LoaiQD.ValueMember = "id";
                clb_LoaiQD.DisplayMember = "ten_loai";



            }
            catch (Exception)
            {

            }
        }

        private void btn_BaoCao_Click(object sender, EventArgs e)
        {
            List<int> SelectedLoaiQD = new List<int>();

            foreach (object item in clb_LoaiQD.CheckedItems)
            {
                DataRowView drv = (DataRowView)item;
                SelectedLoaiQD.Add(Convert.ToInt32(drv["id"]));
            }

            if (SelectedLoaiQD.Count <= 0) SelectedLoaiQD = null;

            DateTime? dt_tu_ngay = new DateTime();
            DateTime? dt_den_ngay = new DateTime();

            if (dtp_TuNgay.Checked) dt_tu_ngay = dtp_TuNgay.Value;
            else dt_tu_ngay = null;


            if (dtp_DenNgay.Checked) dt_den_ngay = dtp_DenNgay.Value;
            else dt_den_ngay = null;


            DataTable dt_NV = oBaoCao.NV_Theo_LoaiQD(SelectedLoaiQD, dt_tu_ngay, dt_den_ngay);

            DataSet.NVTheo_LoaiQD ds = new DataSet.NVTheo_LoaiQD();
            Reports.NVTheo_LoaiQD rpt = new Reports.NVTheo_LoaiQD();

            rpt.SetDataSource(dt_NV);
            crystalReportViewer1.ReportSource = rpt;

            ((TextObject)(rpt.Subreports["Header.rpt"].ReportDefinition.ReportObjects["rptName"])).Text = "BÁO CÁO NHÂN VIÊN THEO LOẠI QUYẾT ĐỊNH";

        }
    }
}
