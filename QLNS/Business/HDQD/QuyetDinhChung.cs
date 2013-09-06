using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;
using System.Globalization;

namespace Business.HDQD
{
    public class QuyetDinhChung
    {
        DataProvider.DataProvider dp;

        #region Init method

        public QuyetDinhChung()
        {
            dp = new DataProvider.DataProvider();
        }
        
        #endregion

        #region Properties

        private string maquyetdinh;

        public string MaQuyetDinh
        {
            get { return maquyetdinh; }
            set { maquyetdinh = value; }
        }

        private int loaiquyetdinh;

        public int LoaiQuyetDinh
        {
            get { return loaiquyetdinh; }
            set { loaiquyetdinh = value; }
        }

        private string ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        private string[] path;

        public string[] Path
        {
            get { return path; }
            set { path = value; }
        }

        private string[] pathmota;

        public string[] PathMoTa
        {
            get { return pathmota; }
            set { pathmota = value; }
        }
        

        private string mota;

        public string MoTa
        {
            get { return mota; }
            set { mota = value; }
        }

        private DateTime ngayhieulucqd;

        public DateTime NgayHieuLucQD
        {
            get { return ngayhieulucqd; }
            set { ngayhieulucqd = value; }
        }


        private DateTime? ngayhethanqd;

        public DateTime? NgayHetHanQD
        {
            get { return ngayhethanqd; }
            set { ngayhethanqd = value; }
        }

        private DateTime ngaytaoqd;

        public DateTime NgayTaoQD
        {
            get { return ngaytaoqd; }
            set { ngaytaoqd = value; }
        }

        private DateTime[] ngaytaopc;

        public DateTime[] NgayTaoPC
        {
            get { return ngaytaopc; }
            set { ngaytaopc = value; }
        }

        private string[] manv;

        public string[] MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        private int[] loaiphucap;

        public int[] LoaiPhuCap
        {
            get { return loaiphucap; }
            set { loaiphucap = value; }
        }

        private string[] phucap;

        public string[] PhuCap
        {
            get { return phucap; }
            set { phucap = value; }
        }

        private bool[] heso_tienmat;

        public bool[] HeSo_TienMat
        {
            get { return heso_tienmat; }
            set { heso_tienmat = value; }
        }

        private DateTime[] ngaybatdau;

        public DateTime[] NgayBatDau
        {
            get { return ngaybatdau; }
            set { ngaybatdau = value; }
        }

        private DateTime[] ngayhethanpc;

        public DateTime[] NgayHetHanPC
        {
            get { return ngayhethanpc; }
            set { ngayhethanpc = value; }
        }

        private string[] ghichu;

        public string[] GhiChu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        
        #endregion

        #region Methods

        public bool Add()
        {
            int check;

            IDataParameter[] paras = new IDataParameter[17]{
                new NpgsqlParameter("ma_nv",manv),
                new NpgsqlParameter("ma_quyet_dinh",maquyetdinh + "_" + ngayhieulucqd.ToString("ddMMyyyy")),
                new NpgsqlParameter("ten",ten),
                new NpgsqlParameter("loai_quyet_dinh_id",loaiquyetdinh),
                new NpgsqlParameter("path",path),
                new NpgsqlParameter("path_mo_ta",pathmota),
                new NpgsqlParameter("mo_ta",mota),
                new NpgsqlParameter("ngay_hieu_luc_qd", ngayhieulucqd),
                new NpgsqlParameter("ngay_het_han_qd",ngayhethanqd),
                new NpgsqlParameter("ngay_tao_qd",ngaytaoqd),
                new NpgsqlParameter("loai_phu_cap_id",loaiphucap),
                new NpgsqlParameter("phu_cap",phucap),
                new NpgsqlParameter("heso_tienmat",heso_tienmat),
                new NpgsqlParameter("ngay_bat_dau_pc",ngaybatdau.Select( a => a.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ"))).ToArray()),  // format : mm/dd/yyyy
                new NpgsqlParameter("ngay_het_han_pc",ngayhethanpc.Select( a => a.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ"))).ToArray()),
                new NpgsqlParameter("ngay_tao_pc",ngaytaopc.Select( a => a.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ"))).ToArray()),
                new NpgsqlParameter("ghi_chu_pc",ghichu),
            };
            check = (int)dp.executeScalarProc("sp1_insert_quyet_dinh_chung", paras);
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
            IDataParameter[] paras = new IDataParameter[17]{
                new NpgsqlParameter("p_ma_nv",manv),
                new NpgsqlParameter("ma_quyet_dinh",maquyetdinh),
                new NpgsqlParameter("ten",ten),
                new NpgsqlParameter("loai_quyet_dinh_id",loaiquyetdinh),
                new NpgsqlParameter("path",path),
                new NpgsqlParameter("mo_ta",mota),
                new NpgsqlParameter("path_mo_ta",pathmota),
                new NpgsqlParameter("ngay_hieu_luc_qd",ngayhieulucqd),
                new NpgsqlParameter("ngay_het_han_qd",ngayhethanqd),
                new NpgsqlParameter("ngay_tao_qd",ngaytaoqd),
                new NpgsqlParameter("loai_phu_cap_id",loaiphucap),
                new NpgsqlParameter("phu_cap",phucap),
                new NpgsqlParameter("heso_tienmat",heso_tienmat),
                new NpgsqlParameter("ngay_bat_dau_pc",ngaybatdau.Select( a => a.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ"))).ToArray()),  // format : mm/dd/yyyy),
                new NpgsqlParameter("ngay_het_han_pc",ngayhethanpc.Select( a => a.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ"))).ToArray()),  // format : mm/dd/yyyy),
                new NpgsqlParameter("ngay_tao_pc",ngaytaopc.Select( a => a.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ"))).ToArray()),  // format : mm/dd/yyyy),
                new NpgsqlParameter("ghi_chu_pc",ghichu),

            };
            check = (int)dp.executeScalarProc("sp1_insert_quyet_dinh_chung", paras);
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
                new NpgsqlParameter("ma_quyet_dinh",maquyetdinh)
            };
            check = (int)dp.executeScalarProc("sp1_delete_quyet_dinh", paras);
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
