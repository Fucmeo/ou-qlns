﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;

namespace Business.CNVC
{
    public class CNVC_DaoTaoBoiDuong
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_DaoTaoBoiDuong()
        {
            dp = new DataProvider.DataProvider();
        }
        

        #endregion

        #region Properties

        public static CNVC_File oFile_DaoTao { get; set; }

        public static CNVC_File oFile_BoiDuong { get; set; }

        private int? id;

        public int? ID
        {
            get { return id; }
            set { id = value; }
        }

        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        private string tentruong;

        public string TenTruong
        {
            get { return tentruong; }
            set { tentruong = value; }
        }

        private string chuyennganhdaotao;

        public string ChuyenNganhDaoTao
        {
            get { return chuyennganhdaotao; }
            set { chuyennganhdaotao = value; }
        }

        private DateTime? tungay;

        public DateTime? TuNgay
        {
            get { return tungay; }
            set { tungay = value; }
        }

        private DateTime? denngay;

        public DateTime? DenNgay
        {
            get { return denngay; }
            set { denngay = value; }
        }

        private int? hinhthucdaotaoid;

        public int? HinhThucDaoTaoID
        {
            get { return hinhthucdaotaoid; }
            set { hinhthucdaotaoid = value; }
        }

        private string xeploai;

        public string XepLoai
        {
            get { return xeploai; }
            set { xeploai = value; }
        }

        private string bd_tenchungchi;

        public string BD_TenChungChi
        {
            get { return bd_tenchungchi; }
            set { bd_tenchungchi = value; }
        }

        private int? cq_vanbangid;

        public int? CQ_VanBangID
        {
            get { return cq_vanbangid; }
            set { cq_vanbangid = value; }
        }

        private string cq_tenluanvan;

        public string CQ_TenLuanVan
        {
            get { return cq_tenluanvan; }
            set { cq_tenluanvan = value; }
        }

        private string cq_hoidongcham;

        public string CQ_HoiDongCham
        {
            get { return cq_hoidongcham; }
            set { cq_hoidongcham = value; }
        }

        public int? TinhTP { get; set; }

        public int? QuocGia { get; set; }

        public Double? Diem { get; set; }

        public DateTime? NgayCapBang { get; set; }

        public string GhiChu { get; set; }

        public int? PhuongThucDaoTaoID { get; set; }

        public int? TrinhDoID { get; set; }

        public string CQ_NguoiHuongDan { get; set; }

        public string SoHieuBang { get; set; }

        public string MaVaoSo { get; set; }

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[21]{
                new NpgsqlParameter("ma_nv",manv),
                new NpgsqlParameter("ten_truong",tentruong),
                new NpgsqlParameter("chuyen_nganh_dao_tao",chuyennganhdaotao),
                new NpgsqlParameter("tu_ngay",tungay),
                new NpgsqlParameter("den_ngay",denngay),
                new NpgsqlParameter("hinh_thuc_dao_tao_id",hinhthucdaotaoid),
                new NpgsqlParameter("xep_loai",xeploai),
                new NpgsqlParameter("bd_ten_chung_chi",bd_tenchungchi),
                new NpgsqlParameter("cq_van_bang_id",cq_vanbangid),
                new NpgsqlParameter("cq_ten_luan_van",cq_tenluanvan),
                new NpgsqlParameter("cq_hoi_dong_cham",cq_hoidongcham),
                new NpgsqlParameter("tinh_thanhpho",TinhTP),
                new NpgsqlParameter("quoc_gia",QuocGia),
                new NpgsqlParameter("diem",Diem),
                new NpgsqlParameter("ngay_cap_bang",NgayCapBang),
                new NpgsqlParameter("ghi_chu",GhiChu),
                new NpgsqlParameter("cq_trinh_do_id",TrinhDoID),
                new NpgsqlParameter("cq_phuong_thuc_dao_tao_id",PhuongThucDaoTaoID),
                new NpgsqlParameter("cq_nguoi_huong_dan",CQ_NguoiHuongDan),
                new NpgsqlParameter("so_hieu_bang",SoHieuBang),
                new NpgsqlParameter("ma_vao_so",MaVaoSo)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_daotao_va_boiduong", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Update()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[22]{
                new NpgsqlParameter("p_id",id),
                new NpgsqlParameter("p_ma_nv",manv),
                new NpgsqlParameter("p_ten_truong",tentruong),
                new NpgsqlParameter("p_chuyen_nganh_dao_tao",chuyennganhdaotao),
                new NpgsqlParameter("p_tu_ngay",tungay),
                new NpgsqlParameter("p_den_ngay",denngay),
                new NpgsqlParameter("p_hinh_thuc_dao_tao_id",hinhthucdaotaoid),
                new NpgsqlParameter("p_xep_loai",xeploai),
                new NpgsqlParameter("p_bd_ten_chung_chi",bd_tenchungchi),
                new NpgsqlParameter("p_cq_van_bang_id",cq_vanbangid),
                new NpgsqlParameter("p_cq_ten_luan_van",cq_tenluanvan),
                new NpgsqlParameter("p_cq_hoi_dong_cham",cq_hoidongcham),
                new NpgsqlParameter("p_tinh_thanhpho",TinhTP),
                new NpgsqlParameter("p_quoc_gia",QuocGia),
                new NpgsqlParameter("diem",Diem),
                new NpgsqlParameter("ngay_cap_bang",NgayCapBang),
                new NpgsqlParameter("ghi_chu",GhiChu),
                new NpgsqlParameter("cq_trinh_do_id",TrinhDoID),
                new NpgsqlParameter("cq_phuong_thuc_dao_tao_id",PhuongThucDaoTaoID),
                new NpgsqlParameter("p_cq_nguoi_huong_dan",CQ_NguoiHuongDan),
                new NpgsqlParameter("p_so_hieu_bang",SoHieuBang),
                new NpgsqlParameter("p_ma_vao_so",MaVaoSo)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_daotao_va_boiduong", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Delete()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_id",id)
            };
            check = (int)dp.executeScalarProc("sp_delete_cnvc_daotao_va_boiduong", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable GetData()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",manv)               
            };

            dt = dp.getDataTableProc("sp_select_cnvc_daotao_boiduong", paras);

            return dt;
        }

        #endregion
    }
}
