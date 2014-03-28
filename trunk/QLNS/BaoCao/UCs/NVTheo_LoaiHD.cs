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
    public partial class NVTheo_LoaiHD : UserControl
    {
        Business.HDQD.LoaiHopDong oLoaiHD;
        Business.BaoCao oBaoCao;

        public NVTheo_LoaiHD()
        {
            InitializeComponent();
            oLoaiHD = new Business.HDQD.LoaiHopDong();
            oBaoCao = new Business.BaoCao();
        }

        private void NVTheo_LoaiHD_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_loaihd = oLoaiHD.GetList_Compact();


                clb_LoaiHD.DataSource = dt_loaihd;
                clb_LoaiHD.ValueMember = "id";
                clb_LoaiHD.DisplayMember = "loai_hop_dong";


              
            }
            catch (Exception)
            {

            }
        }

        private void btn_BaoCao_Click(object sender, EventArgs e)
        {
            List<int> SelectedLoaiHD = new List<int>();

            foreach (object item in clb_LoaiHD.CheckedItems)
            {
                DataRowView drv = (DataRowView)item;
                SelectedLoaiHD.Add(Convert.ToInt32(drv["id"]));
            }

            if (SelectedLoaiHD.Count <= 0) SelectedLoaiHD = null;

            DateTime? dt_tu_ngay = new DateTime();
            DateTime? dt_den_ngay = new DateTime();

            if (dtp_TuNgay.Checked) dt_tu_ngay = dtp_TuNgay.Value;
            else dt_tu_ngay = null;


            if (dtp_DenNgay.Checked) dt_den_ngay = dtp_DenNgay.Value;
            else dt_den_ngay = null;


            DataTable dt_NV = oBaoCao.NV_Theo_Loai_HD(SelectedLoaiHD,  dt_tu_ngay,dt_den_ngay);

            DataSet.NVTheo_LoaiHD ds = new DataSet.NVTheo_LoaiHD();
            Reports.NVTheo_LoaiHD rpt = new Reports.NVTheo_LoaiHD();

            rpt.SetDataSource(dt_NV);
            crystalReportViewer1.ReportSource = rpt;

            ((TextObject)(rpt.Subreports["Header.rpt"].ReportDefinition.ReportObjects["rptName"])).Text = "BÁO CÁO NHÂN VIÊN THEO LOẠI HỢP ĐỒNG";

        }
    }
}
