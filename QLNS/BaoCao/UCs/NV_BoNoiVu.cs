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

        public NV_BoNoiVu()
        {
            InitializeComponent();
            oDonVi = new Business.DonVi();
            oBaoCao = new Business.BaoCao();
        }

        private void NV_BoNoiVu_Load(object sender, EventArgs e)
        {
            DataTable dt_NV = new DataTable();

            DataTable dt_ThongTinChinh = oBaoCao.NV_ThongTinChinh("12333");
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


            

            //dt_ThongTinChinh.Columns["

            DataTable dt_CMND = oBaoCao.NV_CMND("12333");

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

            //rpt.SetDataSource(dt_ThongTinChinh);
            //rpt.SetDataSource(dt_CMND);
            crystalReportViewer1.ReportSource = rpt;
            //((TextObject)(rpt.Subreports["Header.rpt"].ReportDefinition.ReportObjects["rptName"])).Text = "BÁO CÁO NHÂN VIÊN THEO ĐƠN VỊ";
        }
    }
}
