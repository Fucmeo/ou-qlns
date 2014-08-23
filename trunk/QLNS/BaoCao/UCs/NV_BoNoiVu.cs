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
        Business.CNVC.CNVC_ThongTinTuyenDung oCNVC_ThongTinTuyenDung;
        Business.TinhTP oTinhTP;
        Business.QuocGia oQuocGia;

        DataTable dtTinhTP;
        DataTable dtQuocGia;
        DataTable dt_ThongTinChinh;
        DataTable dt_CMND;
        DataTable dt_ThongTinPhu ;
        DataTable dt_ThongTinTuyenDung;


        public NV_BoNoiVu()
        {
            InitializeComponent();
            oDonVi = new Business.DonVi();
            oCNVC = new Business.CNVC.CNVC();
            oCNVC_CMND_HoChieu = new Business.CNVC.CNVC_CMND_HoChieu();
            oCNVC_ThongTinPhu = new Business.CNVC.CNVC_ThongTinPhu();
            oCNVC_ThongTinTuyenDung = new Business.CNVC.CNVC_ThongTinTuyenDung();
            oQuocGia = new Business.QuocGia();
            oTinhTP = new Business.TinhTP();

            dt_CMND = new DataTable();
            dt_ThongTinPhu = new DataTable();
            dt_ThongTinTuyenDung = new DataTable();
            dtTinhTP = new DataTable();
            dtQuocGia = new DataTable();
            dt_ThongTinChinh = new DataTable();
        }

        private void GetMasterData()
        {
            try
            {
                dtTinhTP = oTinhTP.GetData();
                dtQuocGia = oQuocGia.GetData();
            }
            catch (Exception)
            {
                
            }

        }

        void Prepare_ThongTinChinh()
        {
            try
            {
                string tinh_thanhpho_text = "";
                string quoc_gia_text = "";

                dt_ThongTinChinh = oCNVC.GetData();

                if (dt_ThongTinChinh.Rows.Count > 0)
                {
                    if (dt_ThongTinChinh.Rows[0]["tinh_thanhpho"].ToString() != "")
                    {
                        int tinh_thanhpho_id = Convert.ToInt32(dt_ThongTinChinh.Rows[0]["tinh_thanhpho"].ToString());
                        tinh_thanhpho_text = (from tp in dtTinhTP.AsEnumerable()
                                              where tp.Field<int>("id") == tinh_thanhpho_id
                                              select tp.Field<string>("ten_tinh_tp")).First();
                    }

                    if (dt_ThongTinChinh.Rows[0]["quoc_gia"].ToString() != "")
                    {
                        int quoc_gia_id = Convert.ToInt32(dt_ThongTinChinh.Rows[0]["quoc_gia"].ToString());
                        quoc_gia_text = (from tp in dtQuocGia.AsEnumerable()
                                         where tp.Field<int>("id") == quoc_gia_id
                                         select tp.Field<string>("ten_quoc_gia")).First();
                    }

                    dt_ThongTinChinh.Columns.Add("ho_ten", typeof(string));
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
                }

                dt_ThongTinChinh.Columns.Add("quoc_gia_text", typeof(string));
                dt_ThongTinChinh.Rows[0]["quoc_gia_text"] = quoc_gia_text;

                dt_ThongTinChinh.Columns.Add("tinh_thanhpho_text", typeof(string));
                dt_ThongTinChinh.Rows[0]["tinh_thanhpho_text"] = tinh_thanhpho_text;


            }
            catch (Exception)
            {
                
            }
           
        }

        void Prepare_ThongTinPhu()
        {
            try
            {
                dt_ThongTinPhu = oCNVC_ThongTinPhu.GetData();

                string hokhau_thuongtru_tinh_text = "";
                string noi_sinh_tinh_text = "";
                string que_quan_tinh_text = "";
                string que_quan_quoc_gia_text = "";
                string hokhau_thuongtru_quoc_gia_text = "";
                string quoc_tich_text = "";

                if (dt_ThongTinPhu.Rows.Count > 0)
                {
                    if (dt_ThongTinPhu.Rows[0]["noi_sinh_tinh"].ToString() != "")
                    {
                        int noi_sinh_tinh_id = Convert.ToInt32(dt_ThongTinPhu.Rows[0]["noi_sinh_tinh"].ToString());
                        noi_sinh_tinh_text = (from tp in dtTinhTP.AsEnumerable()
                                              where tp.Field<int>("id") == noi_sinh_tinh_id
                                              select tp.Field<string>("ten_tinh_tp")).First();
                    }

                    if (dt_ThongTinPhu.Rows[0]["hokhau_thuongtru_tinh"].ToString() != "")
                    {
                        int hokhau_thuongtru_tinh_id = Convert.ToInt32(dt_ThongTinPhu.Rows[0]["hokhau_thuongtru_tinh"].ToString());
                        hokhau_thuongtru_tinh_text = (from tp in dtTinhTP.AsEnumerable()
                                                      where tp.Field<int>("id") == hokhau_thuongtru_tinh_id
                                                      select tp.Field<string>("ten_tinh_tp")).First();
                    }

                    if (dt_ThongTinPhu.Rows[0]["que_quan_tinh"].ToString() != "")
                    {
                        int que_quan_tinh_id = Convert.ToInt32(dt_ThongTinPhu.Rows[0]["que_quan_tinh"].ToString());
                        que_quan_tinh_text = (from tp in dtTinhTP.AsEnumerable()
                                              where tp.Field<int>("id") == que_quan_tinh_id
                                              select tp.Field<string>("ten_tinh_tp")).First();
                    }

                    if (dt_ThongTinPhu.Rows[0]["que_quan_quoc_gia"].ToString() != "")
                    {
                        int que_quan_quoc_gia_id = Convert.ToInt32(dt_ThongTinPhu.Rows[0]["que_quan_quoc_gia"].ToString());
                        que_quan_quoc_gia_text = (from tp in dtQuocGia.AsEnumerable()
                                                  where tp.Field<int>("id") == que_quan_quoc_gia_id
                                                  select tp.Field<string>("ten_quoc_gia")).First();

                    }

                    if (dt_ThongTinPhu.Rows[0]["hokhau_thuongtru_quoc_gia"].ToString() != "")
                    {
                        int hokhau_thuongtru_quoc_gia_id = Convert.ToInt32(dt_ThongTinPhu.Rows[0]["hokhau_thuongtru_quoc_gia"].ToString());
                        hokhau_thuongtru_quoc_gia_text = (from tp in dtQuocGia.AsEnumerable()
                                                          where tp.Field<int>("id") == hokhau_thuongtru_quoc_gia_id
                                                          select tp.Field<string>("ten_quoc_gia")).First();
                    }

                    if (dt_ThongTinPhu.Rows[0]["quoc_tich"].ToString() != "")
                    {
                        int quoc_tich_id = Convert.ToInt32(dt_ThongTinPhu.Rows[0]["quoc_tich"].ToString());
                        quoc_tich_text = (from tp in dtQuocGia.AsEnumerable()
                                          where tp.Field<int>("id") == quoc_tich_id
                                          select tp.Field<string>("ten_quoc_gia")).First();
                    }

                }

                dt_ThongTinPhu.Columns.Add("hokhau_thuongtru_tinh_text", typeof(string));
                dt_ThongTinPhu.Rows[0]["hokhau_thuongtru_tinh_text"] = hokhau_thuongtru_tinh_text;

                dt_ThongTinPhu.Columns.Add("noi_sinh_tinh_text", typeof(string));
                dt_ThongTinPhu.Rows[0]["noi_sinh_tinh_text"] = noi_sinh_tinh_text;

                dt_ThongTinPhu.Columns.Add("que_quan_tinh_text", typeof(string));
                dt_ThongTinPhu.Rows[0]["que_quan_tinh_text"] = que_quan_tinh_text;

                dt_ThongTinPhu.Columns.Add("que_quan_quoc_gia_text", typeof(string));
                dt_ThongTinPhu.Rows[0]["que_quan_quoc_gia_text"] = que_quan_quoc_gia_text;

                dt_ThongTinPhu.Columns.Add("hokhau_thuongtru_quoc_gia_text", typeof(string));
                dt_ThongTinPhu.Rows[0]["hokhau_thuongtru_quoc_gia_text"] = hokhau_thuongtru_quoc_gia_text;

                dt_ThongTinPhu.Columns.Add("quoc_tich_text", typeof(string));
                dt_ThongTinPhu.Rows[0]["quoc_tich_text"] = quoc_tich_text;
            }
            catch (Exception)
            {
                
            }
            
            
        }

        private void NV_BoNoiVu_Load(object sender, EventArgs e)
        {
            GetMasterData();
            oCNVC.MaNV = oCNVC_CMND_HoChieu.MaNV = oCNVC_ThongTinPhu.MaNV =
                    oCNVC_ThongTinTuyenDung.MaNV = "ĐHM091039";

            Prepare_ThongTinChinh();
            Prepare_ThongTinPhu();

            DataTable dt_CMND = oCNVC_CMND_HoChieu.GetData();

            

            DataTable dt_ThongTinTuyenDung = oCNVC_ThongTinTuyenDung.GetData();

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
            rpt.Database.Tables["ThongTinTuyenDung"].SetDataSource(dt_ThongTinTuyenDung);

            //rpt.SetDataSource(dt_ThongTinChinh);
            //rpt.SetDataSource(dt_CMND);
            crystalReportViewer1.ReportSource = rpt;
            //((TextObject)(rpt.Subreports["Header.rpt"].ReportDefinition.ReportObjects["rptName"])).Text = "BÁO CÁO NHÂN VIÊN THEO ĐƠN VỊ";
        }
    }
}
