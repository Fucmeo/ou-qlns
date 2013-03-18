using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;


namespace Business.CNVC
{
    public class CNVC_QuanHeToChuc
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_QuanHeToChuc()
        {
            dp = new DataProvider.DataProvider();
        }

        #endregion

        #region Properties

        public int ID { get; set; }

        public string MaNV { get; set; }

        public bool NuocNgoai { get; set; }

        public string TenToChuc { get; set; }

        public string ChucDanh { get; set; }

        public string ChucVu { get; set; }

        public DateTime? TuThoiGian { get; set; }

        public DateTime? DenThoiGian { get; set; }

        public string PhuongXa { get; set; }

        public string QuanHuyen { get; set; }

        public int? TinhTP { get; set; }

        public int? QuocGia { get; set; }

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[11]{
                new NpgsqlParameter("p_ma_nv",MaNV),
                new NpgsqlParameter("p_o_nuoc_ngoai",NuocNgoai),
                new NpgsqlParameter("p_ten_to_chuc",TenToChuc),
                new NpgsqlParameter("p_phuong_xa",PhuongXa),
                new NpgsqlParameter("p_quan_huyen",QuanHuyen),
                new NpgsqlParameter("p_tinh_thanhpho",TinhTP),
                new NpgsqlParameter("p_quoc_gia",QuocGia),
                new NpgsqlParameter("p_chuc_danh",ChucDanh),
                new NpgsqlParameter("p_chuc_vu",ChucVu),
                new NpgsqlParameter("p_tu_thoi_gian",TuThoiGian),
                new NpgsqlParameter("p_den_thoi_gian",DenThoiGian)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_ls_quan_he", paras);
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
            IDataParameter[] paras = new IDataParameter[12]{
                new NpgsqlParameter("p_id",ID),
                new NpgsqlParameter("p_ma_nv",MaNV),
                new NpgsqlParameter("p_o_nuoc_ngoai",NuocNgoai),
                new NpgsqlParameter("p_ten_to_chuc",TenToChuc),
                new NpgsqlParameter("p_phuong_xa",PhuongXa),
                new NpgsqlParameter("p_quan_huyen",QuanHuyen),
                new NpgsqlParameter("p_tinh_thanhpho",TinhTP),
                new NpgsqlParameter("p_quoc_gia",QuocGia),
                new NpgsqlParameter("p_chuc_danh",ChucDanh),
                new NpgsqlParameter("p_chuc_vu",ChucVu),
                new NpgsqlParameter("p_tu_thoi_gian",TuThoiGian),
                new NpgsqlParameter("p_den_thoi_gian",DenThoiGian)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_ls_quan_he", paras);
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
                new NpgsqlParameter("p_id",ID)
               
            };
            check = (int)dp.executeScalarProc("sp_delete_cnvc_ls_quan_he", paras);
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
                new NpgsqlParameter("p_ma_nv",MaNV)               
            };

            dt = dp.getDataTableProc("sp_select_cnvc_ls_quan_he", paras);

            return dt;
        }

        #endregion
    }
}
