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
    public partial class NVTheo_CD_CV : UserControl
    {
        Business.ChucDanh oChucdanh;
        Business.ChucVu oChucvu;
        Business.BaoCao oBaoCao;

        public NVTheo_CD_CV()
        {
            InitializeComponent();
            oChucdanh = new ChucDanh();
            oChucvu = new ChucVu();
            oBaoCao = new Business.BaoCao();
        }

        private void NVTheo_CD_CV_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_cd = oChucdanh.GetList();
                DataTable dt_cv = oChucvu.GetList();

                if (dt_cd != null && dt_cd.Rows.Count > 0)
                    dt_cd.Rows.RemoveAt(0);

                if (dt_cv != null && dt_cv.Rows.Count > 0)
                    dt_cv.Rows.RemoveAt(0);

                clb_ChucDanh.DataSource = dt_cd;
                clb_ChucDanh.ValueMember = "id";
                clb_ChucDanh.DisplayMember = "ten_chuc_danh";


                clb_ChucVu.DataSource = dt_cv;
                clb_ChucVu.ValueMember = "id";
                clb_ChucVu.DisplayMember = "ten_chuc_vu";

            }
            catch (Exception)
            {
                
            }
            
        }

        private void btn_BaoCao_Click(object sender, EventArgs e)
        {
            List<int> SelectedChucDanh = new List<int>();
            List<int> SelectedChucVu = new List<int>();

            foreach (object item in clb_ChucDanh.CheckedItems)
            {
                DataRowView drv = (DataRowView)item;
                SelectedChucDanh.Add(Convert.ToInt32(drv["id"]));
            }

            if (SelectedChucDanh.Count <= 0) SelectedChucDanh = null;

            foreach (object item in clb_ChucVu.CheckedItems)
            {
                DataRowView drv = (DataRowView)item;
                SelectedChucVu.Add(Convert.ToInt32(drv["id"]));
            }

            if (SelectedChucVu.Count <= 0) SelectedChucVu = null;

            DateTime? dt_tu_ngay = new DateTime();
            DateTime? dt_den_ngay = new DateTime();

            if (dtp_TuNgay.Checked) dt_tu_ngay = dtp_TuNgay.Value;
            else dt_tu_ngay = null;


            if (dtp_DenNgay.Checked) dt_den_ngay = dtp_DenNgay.Value;
            else dt_den_ngay = null;

            DataTable dt_NV = oBaoCao.NV_Theo_CD_CV(SelectedChucDanh, SelectedChucVu, dt_tu_ngay,dt_den_ngay);

            DataSet.NVTheoCD_CV ds = new DataSet.NVTheoCD_CV();
            Reports.NVTheoCD_CV rpt = new Reports.NVTheoCD_CV();

            rpt.SetDataSource(dt_NV);
            crystalReportViewer1.ReportSource = rpt;

            ((TextObject)(rpt.Subreports["Header.rpt"].ReportDefinition.ReportObjects["rptName"])).Text = "BÁO CÁO NHÂN VIÊN THEO CHỨC DANH, CHỨC VỤ";


        }


    }
}
