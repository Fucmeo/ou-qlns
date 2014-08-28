﻿using System;
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
        string ma_nv;

        Business.DonVi oDonVi;
        //Business.BaoCao oBaoCao;
        Business.CNVC.CNVC oCNVC;
        Business.CNVC.CNVC_CMND_HoChieu oCNVC_CMND_HoChieu;
        Business.CNVC.CNVC_ThongTinPhu oCNVC_ThongTinPhu;
        Business.CNVC.CNVC_ThongTinTuyenDung oCNVC_ThongTinTuyenDung;
        Business.TinhTP oTinhTP;
        Business.QuocGia oQuocGia;
        Business.Luong.TinhLuong oTinhLuong;
        Business.CNVC.CNVC_ChinhTri oCNVC_ChinhTri;
        Business.CNVC.CNVC_ChinhTriExt oCNVC_ChinhTriExt;
        Business.CNVC.CNVC_ChuyenMonTongQuat oCNVC_ChuyenMonTongQuat;
        Business.CNVC.CNVC_DienBienSK oCNVC_DienBienSK;

        DataTable dtTinhTP;
        DataTable dtQuocGia;
        DataTable dt_ThongTinChinh;
        DataTable dt_CMND_HoChieu;
        DataTable dt_CMND;
        DataTable dt_ThongTinPhu ;
        DataTable dt_ThongTinTuyenDung;
        DataTable dt_Qtr_Ctac_OU;
        DataTable dt_ChucDanh_ChucVu;
        DataTable dt_Luong;
        DataTable dt_ThongTinLuong;
        DataTable dt_ChinhTri;
        DataTable dt_ChinhTriExt;
        DataTable dt_Chinh_Tri_HCCB;
        DataTable dt_ChuyenMonTongQuat;
        DataTable dt_SucKhoe;

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
            oTinhLuong = new Business.Luong.TinhLuong();
            oCNVC_ChinhTri = new Business.CNVC.CNVC_ChinhTri();
            oCNVC_ChinhTriExt = new Business.CNVC.CNVC_ChinhTriExt();
            oCNVC_ChuyenMonTongQuat = new Business.CNVC.CNVC_ChuyenMonTongQuat();
            oCNVC_DienBienSK = new Business.CNVC.CNVC_DienBienSK();


            dt_SucKhoe = new DataTable();
            dt_Chinh_Tri_HCCB = new DataTable();
            dt_ChinhTri = new DataTable();
            dt_CMND_HoChieu = new DataTable();
            dt_CMND = new DataTable();
            dt_ThongTinPhu = new DataTable();
            dt_ThongTinTuyenDung = new DataTable();
            dtTinhTP = new DataTable();
            dtQuocGia = new DataTable();
            dt_ThongTinChinh = new DataTable();
            dt_Qtr_Ctac_OU = new DataTable();
            dt_ChucDanh_ChucVu = new DataTable();
            dt_Luong = new DataTable();
            dt_ThongTinLuong = new DataTable();
            dt_ChuyenMonTongQuat = new DataTable();
            dt_ChinhTriExt = new DataTable();
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

        void Prepare_SK()
        {
            DataTable dt = oCNVC_DienBienSK.GetData();

           
            if (dt != null && dt.Rows.Count>0)
            {

                dt_SucKhoe = (from a in dt.AsEnumerable()
                              select a).CopyToDataTable();

            }

        }

        void Prepare_ChinhTri()
        {
            try
            {
                dt_ChinhTri = oCNVC_ChinhTri.Get_Chinh_Tri_Info();

                dt_ChinhTriExt = oCNVC_ChinhTriExt.GetData();

                var dang = (from ct in dt_ChinhTriExt.AsEnumerable()
                            where ct.Field<string>("ten_loai_chinh_tri").ToLower().Contains("đảng")
                            select ct);

                DataTable dt = new DataTable();
                if (dang.Count() > 0)
                {
                    dt = dang.CopyToDataTable();
                }


                dt_ChinhTriExt = dt;

                

                dt_Chinh_Tri_HCCB = oCNVC_ChinhTri.Get_Chinh_Tri_HCCB();
            }
            catch (Exception)
            {
                
            }
        }

        void Prepare_ChuyenMonTongQuat()
        {
            try
            {
                dt_ChuyenMonTongQuat = oCNVC_ChuyenMonTongQuat.GetData();
            }
            catch (Exception)
            {
                
            }
        }

        void Prepare_ThongTinLuong()
        {
            try
            {
                string ngach="";
                string bac="";
                string heso="";
                DateTime? tungay;

                dt_Luong = oTinhLuong.GetThongTinLuong_ByNV(ma_nv);

                dt_ThongTinLuong.Columns.Add("ngach", typeof(string));
                dt_ThongTinLuong.Columns.Add("bac", typeof(string));
                dt_ThongTinLuong.Columns.Add("heso", typeof(string));
                dt_ThongTinLuong.Columns.Add("tungay", typeof(DateTime));

                if ((from l in dt_Luong.AsEnumerable()
                                where l.Field<DateTime>("den_ngay") >= DateTime.Now && l.Field<int?>("ngach_bac_heso_id") != null
                                 select l.Field<int>("luong_id")).Count() > 0)
                {
                     ngach = (from l in dt_Luong.AsEnumerable()
                              where l.Field<DateTime>("den_ngay") >= DateTime.Now && l.Field<int?>("ngach_bac_heso_id") != null
                                select l.Field<string>("ten_ngach")).First();

                 bac = (from l in dt_Luong.AsEnumerable()
                        where l.Field<DateTime>("den_ngay") >= DateTime.Now && l.Field<int?>("ngach_bac_heso_id") != null
                        select l.Field<int>("bac")).First().ToString();

                 heso = (from l in dt_Luong.AsEnumerable()
                         where l.Field<DateTime>("den_ngay") >= DateTime.Now && l.Field<int?>("ngach_bac_heso_id") != null
                               select l.Field<double>("he_so")).First().ToString();

                 tungay = (from l in dt_Luong.AsEnumerable()
                           where l.Field<DateTime>("den_ngay") >= DateTime.Now && l.Field<int?>("ngach_bac_heso_id") != null
                                   select l.Field<DateTime?>("tu_ngay")).First();
                }
                else
                {
                    tungay = null;
                }

                

                dt_ThongTinLuong.Rows.Add(new object[] { ngach, bac, heso, tungay });
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

                    dt_ThongTinChinh.Columns.Add("quoc_gia_text", typeof(string));
                    dt_ThongTinChinh.Rows[0]["quoc_gia_text"] = quoc_gia_text;

                    dt_ThongTinChinh.Columns.Add("tinh_thanhpho_text", typeof(string));
                    dt_ThongTinChinh.Rows[0]["tinh_thanhpho_text"] = tinh_thanhpho_text;

                    dt_ThongTinChinh.Columns.Add("gioi_tinh_text", typeof(string));
                    if (Convert.ToBoolean(dt_ThongTinChinh.Rows[0]["gioi_tinh"]))
                    {
                        dt_ThongTinChinh.Rows[0]["gioi_tinh_text"] = "Nam";
                    }
                    else
                    {
                        dt_ThongTinChinh.Rows[0]["gioi_tinh_text"] = "Nữ";
                    }
                }

                


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

        void Prepare_ChucDanh_ChucVu()
        {
            try
            {

                dt_ChucDanh_ChucVu.Columns.Add("ten_chuc_vu_concat", typeof(string));
                dt_ChucDanh_ChucVu.Columns.Add("ten_chuc_danh_concat", typeof(string));
                string ten_chuc_vu_concat = "";
                string ten_chuc_danh_concat = "";


                dt_Qtr_Ctac_OU = oCNVC.GetQtrCtacOUDT();

                List<string> lst_chuc_vu = (from cv in dt_Qtr_Ctac_OU.AsEnumerable()
                               where cv.Field<bool>("tinh_trang") == true
                               select  cv.Field<string>("ten_chuc_vu")).Distinct().ToList();

                for (int i = 0; i < lst_chuc_vu.Count; i++)
                {
                    if (lst_chuc_vu[i] != null)
                    {
                        ten_chuc_vu_concat = ten_chuc_vu_concat + " " + lst_chuc_vu[i].ToString();
                    }
                    
                }

                List<string> lst_chuc_danh = (from cv in dt_Qtr_Ctac_OU.AsEnumerable()
                                            where cv.Field<bool>("tinh_trang") == true
                                            select cv.Field<string>("ten_chuc_danh")).Distinct().ToList();

                for (int i = 0; i < lst_chuc_danh.Count; i++)
                {
                    if (lst_chuc_danh[i] != null)
                    {
                        ten_chuc_danh_concat = ten_chuc_danh_concat + " " + lst_chuc_danh[i].ToString();
                    }
                    
                }

                dt_ChucDanh_ChucVu.Rows.Add(new string[2] { ten_chuc_vu_concat, ten_chuc_danh_concat });

    
            }
            catch (Exception)
            {
                
            }
        }

        void Prepare_CMND()
        {
            try
            {
                dt_CMND_HoChieu = oCNVC_CMND_HoChieu.GetData();

                var CMND = (from cmnd in dt_CMND_HoChieu.AsEnumerable()
                            where cmnd.Field<string>("is_active") == "Còn hiệu lực" && cmnd.Field<string>("cmnd_hochieu") == "CMND"
                            select new
                            {
                                ma_so = cmnd.Field<string>("ma_so"),
                                ngay_cap = cmnd.Field<DateTime>("ngay_cap")
                            }).First() ;

                dt_CMND.Columns.Add("ma_so", typeof(string));
                dt_CMND.Columns.Add("ngay_cap", typeof(DateTime));

                dt_CMND.Rows.Add(new object[] { CMND.ma_so, CMND.ngay_cap });

            }
            catch (Exception)
            {
                
            }
        }

        private void NV_BoNoiVu_Load(object sender, EventArgs e)
        {
            ma_nv = "ĐHM131121";
            GetMasterData();
            oCNVC.MaNV = oCNVC_CMND_HoChieu.MaNV = oCNVC_ThongTinPhu.MaNV =
                    oCNVC_ThongTinTuyenDung.MaNV = oCNVC_ChinhTri.MaNV = oCNVC_ChinhTriExt.Ma_NV = 
                    oCNVC_ChuyenMonTongQuat.MaNV = oCNVC_DienBienSK.MaNV = ma_nv;

            Prepare_ThongTinChinh();
            Prepare_ThongTinPhu();
            Prepare_ChucDanh_ChucVu();
            Prepare_ThongTinLuong();
            Prepare_CMND();
            Prepare_ChinhTri();
            Prepare_ChuyenMonTongQuat();
            Prepare_SK();

            DataTable dt_ThongTinTuyenDung = oCNVC_ThongTinTuyenDung.GetData();

            /*
            var result = from thongtinchinh in dt_ThongTinChinh.AsEnumerable()
                         join cmnd in dt_CMND_HoChieu.AsEnumerable()
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
            rpt.Database.Tables["ChucDanh_ChucVu"].SetDataSource(dt_ChucDanh_ChucVu);
            rpt.Database.Tables["ThongTinLuong"].SetDataSource(dt_ThongTinLuong);
            rpt.Database.Tables["ChuyenMonTongQuat"].SetDataSource(dt_ChuyenMonTongQuat);
            rpt.Database.Tables["ChinhTri"].SetDataSource(dt_ChinhTri);
            rpt.Database.Tables["ChinhTriExt"].SetDataSource(dt_ChinhTriExt);
            rpt.Database.Tables["ChinhTri_HCCB"].SetDataSource(dt_Chinh_Tri_HCCB);
            rpt.Database.Tables["SucKhoe"].SetDataSource(dt_SucKhoe);

            //rpt.SetDataSource(dt_ThongTinChinh);
            //rpt.SetDataSource(dt_CMND_HoChieu);
            crystalReportViewer1.ReportSource = rpt;
            //((TextObject)(rpt.Subreports["Header.rpt"].ReportDefinition.ReportObjects["rptName"])).Text = "BÁO CÁO NHÂN VIÊN THEO ĐƠN VỊ";
        }
    }
}

