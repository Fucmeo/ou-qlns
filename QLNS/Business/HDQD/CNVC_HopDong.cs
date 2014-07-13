using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;

namespace Business.HDQD
{
    public class CNVC_HopDong
    {
        DataProvider.DataProvider dp;

        #region InitMethods
        public CNVC_HopDong()
        {
            dp = new DataProvider.DataProvider();
        }
        #endregion

        #region Properties
        private int? id;

        public int? ID
        {
            get { return id; }
            set { id = value; }
        }

        private string ma_nv;

        public string Ma_NV
        {
            get { return ma_nv; }
            set { ma_nv = value; }
        }

        private int? ma_loai_hd;

        public int? Ma_Loai_HD
        {
            get { return ma_loai_hd; }
            set { ma_loai_hd = value; }
        }

        private string loai_hd;

        public string Loai_Hop_Dong
        {
            get { return loai_hd; }
            set { loai_hd = value; }
        }

        private bool? co_thoi_han;

        public bool? Co_Thoi_Han
        {
            get { return co_thoi_han; }
            set { co_thoi_han = value; }
        }

        private DateTime? ngay_ky;

        public DateTime? Ngay_Ky
        {
            get { return ngay_ky; }
            set { ngay_ky = value; }
        }

        private DateTime? ngay_hieu_luc;

        public DateTime? Ngay_Hieu_Luc
        {
            get { return ngay_hieu_luc; }
            set { ngay_hieu_luc = value; }
        }

        private DateTime? ngay_het_han;

        public DateTime? Ngay_Het_Han
        {
            get { return ngay_het_han; }
            set { ngay_het_han = value; }
        }

        private DateTime? ngay_het_han_adj;

        public DateTime? Ngay_Het_Han_Adj
        {
            get { return ngay_het_han_adj; }
            set { ngay_het_han_adj = value; }
        }

        private int? chuc_vu_id;

        public int? Chuc_Vu_ID
        {
            get { return chuc_vu_id; }
            set { chuc_vu_id = value; }
        }

        private string chuc_vu;

        public string Chuc_Vu
        {
            get { return chuc_vu; }
            set { chuc_vu = value; }
        }

        private int? don_vi_id;

        public int? Don_Vi_ID
        {
            get { return don_vi_id; }
            set { don_vi_id = value; }
        }

        private string don_vi;

        public string Don_Vi
        {
            get { return don_vi; }
            set { don_vi = value; }
        }

        private int? chuc_danh_id;

        public int? Chuc_Danh_ID
        {
            get { return chuc_danh_id; }
            set { chuc_danh_id = value; }
        }

        private string chuc_danh;

        public string Chuc_Danh
        {
            get { return chuc_danh; }
            set { chuc_danh = value; }
        }

        private bool? tinh_trang;

        public bool? Tinh_Trang
        {
            get { return tinh_trang; }
            set { tinh_trang = value; }
        }

        private string ghi_chu;

        public string Ghi_Chu
        {
            get { return ghi_chu; }
            set { ghi_chu = value; }
        }

        public bool? Khoan_or_HeSo { get; set; }

        public double? Luong_Khoan { get; set; }

        public int? BacHeSo_ID { get; set; }

        public double? PhanTramHuong { get; set; }

        public string Ma_Tuyen_Dung { get; set; }

        public bool La_QD_Tiep_Nhan { get; set; }
        public string Ten_Quyet_Dinh { get; set; }
        public int? Loai_QD_ID { get; set; }
        public string MoTa_QD { get; set; }

        public bool Co_Phu_Cap { get; set; }

        public int[] Loai_Phu_Cap_ID { get; set; }

        public double[] Value_Khoan { get; set; }
        public double[] Value_HeSo { get; set; }
        public double[] Value_PhanTram { get; set; }
        public double[] PC_PhanTramHuong { get; set; }
        public DateTime[] PC_TuNgay { get; set; }
        public DateTime[] PC_DenNgay { get; set; }
        public string[] PC_GhiChu { get; set; }

        private string ma_hop_dong;

        public string Ma_Hop_Dong
        {
            get { return ma_hop_dong; }
            set { ma_hop_dong = value; }
        }

        public bool Tham_nien_nang_bac { get; set; }
        public bool Tham_nien_nha_giao { get; set; }
        #endregion

        #region Methods

        /*
        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[11]{
                new NpgsqlParameter("p_ma_nv",ma_nv),
                new NpgsqlParameter("p_ma_loai_hd",ma_loai_hd),
                new NpgsqlParameter("p_co_thoi_han",co_thoi_han),
                new NpgsqlParameter("p_ngay_ky",ngay_ky),
                new NpgsqlParameter("p_ngay_hieu_luc",ngay_hieu_luc),
                new NpgsqlParameter("p_ngay_het_han",ngay_het_han),
                new NpgsqlParameter("p_chuc_vu_chinh_id",chuc_vu_id),
                new NpgsqlParameter("p_don_vi_chinh_id",don_vi_id),
                new NpgsqlParameter("p_ghi_chu",ghi_chu),
                new NpgsqlParameter("p_ma_hop_dong",ma_hop_dong),
                new NpgsqlParameter("p_chuc_danh_chinh_id",chuc_danh_id)
            };
            check = (int)dp.executeScalarProc("sp1_insert_cnvc_hop_dong", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Add_wLuong()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[15]{
                new NpgsqlParameter("p_ma_nv",ma_nv),
                new NpgsqlParameter("p_ma_loai_hd",ma_loai_hd),
                new NpgsqlParameter("p_co_thoi_han",co_thoi_han),
                new NpgsqlParameter("p_ngay_ky",ngay_ky),
                new NpgsqlParameter("p_ngay_hieu_luc",ngay_hieu_luc),
                new NpgsqlParameter("p_ngay_het_han",ngay_het_han),
                new NpgsqlParameter("p_chuc_vu_chinh_id",chuc_vu_id),
                new NpgsqlParameter("p_don_vi_chinh_id",don_vi_id),
                new NpgsqlParameter("p_ghi_chu",ghi_chu),
                new NpgsqlParameter("p_ma_hop_dong",ma_hop_dong),
                new NpgsqlParameter("p_chuc_danh_chinh_id",chuc_danh_id),
                new NpgsqlParameter("p_khoan_or_heso",Khoan_or_HeSo),
                new NpgsqlParameter("p_luong_khoan",Luong_Khoan),
                new NpgsqlParameter("p_ngach_bac_heso_id",BacHeSo_ID),
                new NpgsqlParameter("p_phan_tram_huong",PhanTramHuong),
            };
            check = (int)dp.executeScalarProc("sp1_insert_cnvc_hop_dong", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }
        */

        public bool Add_wLuong_PhuCap()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[29]{
                new NpgsqlParameter("p_ma_nv",ma_nv),
                new NpgsqlParameter("p_ma_loai_hd",ma_loai_hd),
                new NpgsqlParameter("p_ma_tuyen_dung",Ma_Tuyen_Dung + "_" + ngay_hieu_luc.Value.ToString("ddMMyyyy")),
                new NpgsqlParameter("p_la_qd_tiep_nhan",La_QD_Tiep_Nhan),
                new NpgsqlParameter("p_ten_qd",Ten_Quyet_Dinh),
                new NpgsqlParameter("p_loai_qd_id",Loai_QD_ID),
                new NpgsqlParameter("p_co_thoi_han",co_thoi_han),
                new NpgsqlParameter("p_ngay_ky",ngay_ky),
                new NpgsqlParameter("p_ngay_hieu_luc",ngay_hieu_luc),
                new NpgsqlParameter("p_ngay_het_han",ngay_het_han),
                new NpgsqlParameter("p_chuc_vu_chinh_id",chuc_vu_id),
                new NpgsqlParameter("p_don_vi_chinh_id",don_vi_id),
                new NpgsqlParameter("p_chuc_danh_chinh_id",chuc_danh_id),
                new NpgsqlParameter("p_ghi_chu",ghi_chu),
                new NpgsqlParameter("p_khoan_or_heso",Khoan_or_HeSo),
                new NpgsqlParameter("p_luong_khoan",Luong_Khoan),
                new NpgsqlParameter("p_heso_luong_id",BacHeSo_ID),
                new NpgsqlParameter("p_phan_tram_huong_luong",PhanTramHuong),
                new NpgsqlParameter("p_co_phu_cap",Co_Phu_Cap),
                new NpgsqlParameter("p_loai_phu_cap_id",Loai_Phu_Cap_ID),
                new NpgsqlParameter("p_value_khoan",Value_Khoan),
                new NpgsqlParameter("p_value_he_so",Value_HeSo),
                new NpgsqlParameter("p_value_phan_tram",Value_PhanTram),
                new NpgsqlParameter("p_phan_tram_huong_pc",PC_PhanTramHuong),
                new NpgsqlParameter("p_tu_ngay_pc",PC_TuNgay),
                new NpgsqlParameter("p_den_ngay_pc",PC_DenNgay),
                new NpgsqlParameter("p_ghi_chu_pc",PC_GhiChu),
                new NpgsqlParameter("p_tham_nien_nang_bac",Tham_nien_nang_bac),
                new NpgsqlParameter("p_tham_nien_gd",Tham_nien_nha_giao)
            };
            check = (int)dp.executeScalarProc("sp1_insert_cnvc_tuyen_dung", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Update_wLuong_PhuCap(string p_ma_tuyen_dung_old)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[30]{
                new NpgsqlParameter("p_ma_nv",ma_nv),
                new NpgsqlParameter("p_ma_loai_hd",ma_loai_hd),
                new NpgsqlParameter("p_ma_tuyen_dung_old",p_ma_tuyen_dung_old),
                new NpgsqlParameter("p_ma_tuyen_dung_new",Ma_Tuyen_Dung + "_" + ngay_hieu_luc.Value.ToString("ddMMyyyy")),
                new NpgsqlParameter("p_la_qd_tiep_nhan",La_QD_Tiep_Nhan),
                new NpgsqlParameter("p_ten_qd",Ten_Quyet_Dinh),
                new NpgsqlParameter("p_loai_qd_id",Loai_QD_ID),
                new NpgsqlParameter("p_co_thoi_han",co_thoi_han),
                new NpgsqlParameter("p_ngay_ky",ngay_ky),
                new NpgsqlParameter("p_ngay_hieu_luc",ngay_hieu_luc),
                new NpgsqlParameter("p_ngay_het_han",ngay_het_han),
                new NpgsqlParameter("p_chuc_vu_chinh_id",chuc_vu_id),
                new NpgsqlParameter("p_don_vi_chinh_id",don_vi_id),
                new NpgsqlParameter("p_chuc_danh_chinh_id",chuc_danh_id),
                new NpgsqlParameter("p_ghi_chu",ghi_chu),
                new NpgsqlParameter("p_khoan_or_heso",Khoan_or_HeSo),
                new NpgsqlParameter("p_luong_khoan",Luong_Khoan),
                new NpgsqlParameter("p_heso_luong_id",BacHeSo_ID),
                new NpgsqlParameter("p_phan_tram_huong_luong",PhanTramHuong),
                new NpgsqlParameter("p_co_phu_cap",Co_Phu_Cap),
                new NpgsqlParameter("p_loai_phu_cap_id",Loai_Phu_Cap_ID),
                new NpgsqlParameter("p_value_khoan",Value_Khoan),
                new NpgsqlParameter("p_value_he_so",Value_HeSo),
                new NpgsqlParameter("p_value_phan_tram",Value_PhanTram),
                new NpgsqlParameter("p_phan_tram_huong_pc",PC_PhanTramHuong),
                new NpgsqlParameter("p_tu_ngay_pc",PC_TuNgay),
                new NpgsqlParameter("p_den_ngay_pc",PC_DenNgay),
                new NpgsqlParameter("p_ghi_chu_pc",PC_GhiChu),
                new NpgsqlParameter("p_tham_nien_nang_bac",Tham_nien_nang_bac),
                new NpgsqlParameter("p_tham_nien_gd",Tham_nien_nha_giao)
            };
            check = (int)dp.executeScalarProc("sp1_update_cnvc_tuyen_dung", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Add_HopDongOld(int[] p_don_vi_chinh_id, int[] p_chuc_vu_chinh_id, int[] p_chuc_danh_chinh_id)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[29]{
                new NpgsqlParameter("p_ma_nv",ma_nv),
                new NpgsqlParameter("p_ma_loai_hd",ma_loai_hd),
                new NpgsqlParameter("p_ma_tuyen_dung",Ma_Tuyen_Dung + "_" + ngay_hieu_luc.Value.ToString("ddMMyyyy")),
                new NpgsqlParameter("p_la_qd_tiep_nhan",La_QD_Tiep_Nhan),
                new NpgsqlParameter("p_ten_qd",Ten_Quyet_Dinh),
                new NpgsqlParameter("p_loai_qd_id",Loai_QD_ID),
                new NpgsqlParameter("p_co_thoi_han",co_thoi_han),
                new NpgsqlParameter("p_ngay_ky",ngay_ky),
                new NpgsqlParameter("p_ngay_hieu_luc",ngay_hieu_luc),
                new NpgsqlParameter("p_ngay_het_han",ngay_het_han),
                new NpgsqlParameter("p_chuc_vu_chinh_id",p_chuc_vu_chinh_id),
                new NpgsqlParameter("p_don_vi_chinh_id",p_don_vi_chinh_id),
                new NpgsqlParameter("p_chuc_danh_chinh_id",p_chuc_danh_chinh_id),
                new NpgsqlParameter("p_ghi_chu",ghi_chu),
                new NpgsqlParameter("p_khoan_or_heso",Khoan_or_HeSo),
                new NpgsqlParameter("p_luong_khoan",Luong_Khoan),
                new NpgsqlParameter("p_heso_luong_id",BacHeSo_ID),
                new NpgsqlParameter("p_phan_tram_huong_luong",PhanTramHuong),
                new NpgsqlParameter("p_co_phu_cap",Co_Phu_Cap),
                new NpgsqlParameter("p_loai_phu_cap_id",Loai_Phu_Cap_ID),
                new NpgsqlParameter("p_value_khoan",Value_Khoan),
                new NpgsqlParameter("p_value_he_so",Value_HeSo),
                new NpgsqlParameter("p_value_phan_tram",Value_PhanTram),
                new NpgsqlParameter("p_phan_tram_huong_pc",PC_PhanTramHuong),
                new NpgsqlParameter("p_tu_ngay_pc",PC_TuNgay),
                new NpgsqlParameter("p_den_ngay_pc",PC_DenNgay),
                new NpgsqlParameter("p_ghi_chu_pc",PC_GhiChu),
                new NpgsqlParameter("p_tham_nien_nang_bac",Tham_nien_nang_bac),
                new NpgsqlParameter("p_tham_nien_gd",Tham_nien_nha_giao)
            };
            check = (int)dp.executeScalarProc("sp1_insert_cnvc_tuyen_dung_dvold", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        //public bool Update()
        //{
        //    int check;
        //    IDataParameter[] paras = new IDataParameter[13]{
        //        new NpgsqlParameter("p_ma_nv",ma_nv),
        //        new NpgsqlParameter("p_ma_loai_hd",ma_loai_hd),
        //        new NpgsqlParameter("p_thuviec_chinhthuc",thuviec_chinhthuc),
        //        new NpgsqlParameter("p_ngay_ky",ngay_ky),
        //        new NpgsqlParameter("p_ngay_hieu_luc",ngay_hieu_luc),
        //        new NpgsqlParameter("p_ngay_het_han",ngay_het_han),
        //        new NpgsqlParameter("p_chuc_vu_chinh_id",chuc_vu_id),
        //        new NpgsqlParameter("p_don_vi_chinh_id",don_vi_id),
        //        new NpgsqlParameter("p_tinh_trang",tinh_trang),
        //        new NpgsqlParameter("p_ghi_chu",ghi_chu),
        //        new NpgsqlParameter("p_chuc_danh_chinh_id",chuc_danh_id),
        //        new NpgsqlParameter("p_ma_hop_dong_new",ma_hop_dong),
        //        new NpgsqlParameter("p_ma_hop_dong_old",ma_hop_dong)
        //    };
            
        //    check = (int)dp.executeScalarProc("sp1_insert_cnvc_hop_dong", paras);
        //    if (check > 0)
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        public bool StopHopDong()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("p_ma_nv",ma_nv),
                new NpgsqlParameter("p_ma_hop_dong",ma_hop_dong),
                new NpgsqlParameter("p_date_stop", DateTime.Now)
            };

            check = (int)dp.executeScalarProc("sp1_update_cnvc_dung_hopdong", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable Search_HD(string p_ma_nv, string p_ho, string p_ten, string p_ma_hop_dong, int? p_ma_loai_hd, bool? p_co_thoi_han, DateTime? p_ngay_ky_tu, DateTime? p_ngay_ky_den)
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[8]{
                new NpgsqlParameter("p_ma_nv",p_ma_nv),
                new NpgsqlParameter("p_ho_nv",p_ho),
                new NpgsqlParameter("p_ten_nv",p_ten),
                new NpgsqlParameter("p_ma_hd",p_ma_hop_dong),
                new NpgsqlParameter("p_loai_hd",p_ma_loai_hd),
                new NpgsqlParameter("p_co_thoi_han",p_co_thoi_han),
                new NpgsqlParameter("p_ngay_ky_tu",p_ngay_ky_tu),
                new NpgsqlParameter("p_ngay_ky_den",p_ngay_ky_den)
            };

            dt = dp.getDataTableProc("sp1_qsearch_hop_dong", paras);

            return dt;
        }

        public DataTable Search_Dung_HD(string p_ma_hop_dong, string p_ma_nv, string p_ho_nv, string p_ten_nv)
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("p_ma_hd",p_ma_hop_dong),
                new NpgsqlParameter("p_ma_nv",p_ma_nv),
                new NpgsqlParameter("p_ho_nv",p_ho_nv),
                new NpgsqlParameter("p_ten_nv",p_ten_nv)
            };

            dt = dp.getDataTableProc("sp1_qsearch_dung_hop_dong", paras);

            return dt;
        }

        public DataTable Search_QD_TiepNhan(string p_ma_qd)
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_qd",p_ma_qd)
            };

            dt = dp.getDataTableProc("sp1_select_tiep_nhan", paras);

            return dt;
        }

        public bool Delete()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[2]{
                new NpgsqlParameter("p_ma_nv",ma_nv),
                new NpgsqlParameter("p_ma_hop_dong",ma_hop_dong)
            };
            check = (int)dp.executeScalarProc("sp1_delete_cnvc_hop_dong", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
