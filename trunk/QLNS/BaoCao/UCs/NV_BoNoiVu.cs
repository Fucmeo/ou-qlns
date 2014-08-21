using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaoCao.UCs
{
    public partial class NV_BoNoiVu : UserControl
    {
        Business.DonVi oDonVi;
        Business.BaoCao oBaoCao;
        Business.CNVC.CNVC oCNVC;
        Business.CNVC.CNVC_CMND_HoChieu oCNVC_CMND_HoChieu;
        Business.CNVC.CNVC_ThongTinPhu oCNVC_ThongTinPhu;

        public NV_BoNoiVu()
        {
            InitializeComponent();
            oDonVi = new Business.DonVi();
            oCNVC = new Business.CNVC.CNVC();
            oCNVC_CMND_HoChieu = new Business.CNVC.CNVC_CMND_HoChieu();
            oCNVC_ThongTinPhu = new Business.CNVC.CNVC_ThongTinPhu();


            oBaoCao = new Business.BaoCao();
        }

        private void NV_BoNoiVu_Load(object sender, EventArgs e)
        {
            oCNVC.MaNV = oCNVC_CMND_HoChieu.MaNV = oCNVC_ThongTinPhu.MaNV = "12333";

            DataTable dt_ThongTinChinh = oCNVC.GetData();
            dt_ThongTinChinh.Columns.Add("ho_ten",typeof(string));
            dt_ThongTinChinh.Rows[0]["ho_ten"] = dt_ThongTinChinh.Rows[0]["ho"].ToString().ToUpper() + " " + dt_ThongTinChinh.Rows[0]["ten"].ToString().ToUpper();
            dt_ThongTinChinh.Columns.Add("ngay_sinh_only", typeof(string));
            dt_ThongTinChinh.Columns.Add("thang_sinh", typeof(string));
            dt_ThongTinChinh.Columns.Add("nam_sinh", typeof(string));

            DateTime? ngay_sinh = Convert.ToDateTime(dt_ThongTinChinh.Rows[0]["ngay_sinh"].ToString());
            if (ngay_sinh.ToString() != "")
            {
                dt_ThongTinChinh.Rows[0]["ngay_sinh_only"] = ngay_sinh.Value.Day.ToString();
                dt_ThongTinChinh.Rows[0]["thang_sinh"] = ngay_sinh.Value.Month.ToString();
                dt_ThongTinChinh.Rows[0]["nam_sinh"] = ngay_sinh.Value.Year.ToString();
            }

            DataTable dt_CMND = oCNVC_CMND_HoChieu.GetData();

            DataTable dt_ThongTinPhu = oCNVC_ThongTinPhu.GetData();

            /*
            var result = from thongtinchinh in dt_ThongTinChinh.AsEnumerable()
                         join cmnd in dt_CMND.AsEnumerable()
                         on thongtinchinh["ma_nv"] equals cmnd["ma_nv"]
                         select new
                         {
                             ma_nv = thongtinchinh["ma_nv"],
                             ho = thongtinchinh["ho"],
                             ten = thongtinchinh["ten"],
                             cmnd_hochieu = cmnd["cmnd_hochieu"],
                             ma_so = cmnd["ma_so"]
                         };
             */

            Reports.NV_BoNoiVu rpt = new Reports.NV_BoNoiVu();

            rpt.Database.Tables["ThongTinChinh"].SetDataSource(dt_ThongTinChinh);
            rpt.Database.Tables["CMND_HoChieu"].SetDataSource(dt_CMND);
            rpt.Database.Tables["ThongTinPhu"].SetDataSource(dt_ThongTinPhu);

            //rpt.SetDataSource(dt_ThongTinChinh);
            //rpt.SetDataSource(dt_CMND);
            crystalReportViewer1.ReportSource = rpt;
            //((TextObject)(rpt.Subreports["Header.rpt"].ReportDefinition.ReportObjects["rptName"])).Text = "BÁO CÁO NHÂN VIÊN THEO ĐƠN VỊ";
        }
    }
}
