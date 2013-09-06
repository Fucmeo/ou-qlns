using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;

namespace Business.HDQD
{
    public class ThoiNhiem
    {
        #region Init method

        DataProvider.DataProvider dp;

        public ThoiNhiem()
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

        private DateTime ngaytaoqd;

        public DateTime NgayTaoQD
        {
            get { return ngaytaoqd; }
            set { ngaytaoqd = value; }
        }

        private string[] manv;

        public string[] MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        private int[] donvi;

        public int[] DonVi
        {
            get { return donvi; }
            set { donvi = value; }
        }

        private int[] chucvu;

        public int[] ChucVu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }
               
        
        #endregion

        #region Methods

        public bool AddThoiNhiem()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[11]{
                new NpgsqlParameter("ma_nv",manv),
                new NpgsqlParameter("ma_quyet_dinh",maquyetdinh + "_" + ngayhieulucqd.ToString("ddMMyyyy")),
                new NpgsqlParameter("ten",ten),
                new NpgsqlParameter("loai_quyet_dinh_id",loaiquyetdinh),
                new NpgsqlParameter("path",path),
                new NpgsqlParameter("path_mo_ta",pathmota),
                new NpgsqlParameter("mo_ta",mota),
                new NpgsqlParameter("ngay_hieu_luc_qd",ngayhieulucqd),
                new NpgsqlParameter("ngay_tao_qd",ngaytaoqd),
                new NpgsqlParameter("don_vi_id",donvi),
                new NpgsqlParameter("chuc_vu_id",chucvu)
            };
            check = (int)dp.executeScalarProc("sp1_insert_thoi_nhiem", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool UpdateThoiNhiem()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[11]{
                new NpgsqlParameter("ma_nv",manv),
                new NpgsqlParameter("ma_quyet_dinh",maquyetdinh),
                new NpgsqlParameter("ten",ten),
                new NpgsqlParameter("loai_quyet_dinh_id",loaiquyetdinh),
                new NpgsqlParameter("path",path),
                new NpgsqlParameter("path_mo_ta",pathmota),
                new NpgsqlParameter("mo_ta",mota),
                new NpgsqlParameter("ngay_hieu_luc_qd",ngayhieulucqd),
                new NpgsqlParameter("ngay_tao_qd",ngaytaoqd),
                new NpgsqlParameter("don_vi_id",donvi),
                new NpgsqlParameter("chuc_vu_id",chucvu)
            };
            check = (int)dp.executeScalarProc("sp1_insert_kiem_nhiem", paras);
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
                new NpgsqlParameter("p_ma_quyet_dinh",maquyetdinh)
            };
            check = (int)dp.executeScalarProc("sp1_delete_thoi_nhiem", paras);
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
