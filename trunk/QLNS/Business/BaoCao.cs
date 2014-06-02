using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using DataProvider;
using System.Data;


namespace Business
{
 
    public class BaoCao
    {
        DataProvider.DataProvider dp;


        public BaoCao()
        {
            dp = new DataProvider.DataProvider();
        }

        #region CNVC

        public DataTable NV_Theo_CD_CV(List<int> lstCD, List<int> lstCV, DateTime? tu_ngay, DateTime? den_ngay)
        {
            DataTable dt = new DataTable();

            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("p_ma_nv",lstCD == null ? null : lstCD.ToArray()),
                new NpgsqlParameter("p_ma_nv",lstCV == null ? null : lstCV.ToArray()),
                new NpgsqlParameter("p_tu_ngay",tu_ngay),
                new NpgsqlParameter("p_den_ngay",den_ngay)
            };

            dt = dp.getDataTableProc("sp4_bc_cnvc_by_cd_cv", paras);

            return dt;
        }

        public DataTable NV_Theo_Loai_HD(List<int> lstLoaiHD , DateTime? tu_ngay, DateTime? den_ngay)
        {
            DataTable dt = new DataTable();

            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("p_loai_hd_id",lstLoaiHD == null ? null : lstLoaiHD.ToArray()),
                new NpgsqlParameter("p_tu_ngay",tu_ngay),
                new NpgsqlParameter("p_den_ngay",den_ngay)
            };

            dt = dp.getDataTableProc("sp4_bc_cnvc_by_loai_hd", paras);

            return dt;
        }

        public DataTable NV_Theo_DV(List<int> lstLoaiDV, DateTime? tu_ngay, DateTime? den_ngay)
        {
            DataTable dt = new DataTable();

            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("p_dv_id",lstLoaiDV == null ? null : lstLoaiDV.ToArray()),
                new NpgsqlParameter("p_tu_ngay",tu_ngay),
                new NpgsqlParameter("p_den_ngay",den_ngay)
            };

            dt = dp.getDataTableProc("sp4_bc_cnvc_by_dv", paras);

            return dt;
        }

        public DataTable NV_Theo_HocHam_HocVi_GioiTinh(List<int> lstDV, List<int> lstChucDanh, List<int> lstHocHam)
        {
            DataTable dt = new DataTable();

            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("p_dv_id",lstDV == null ? null : lstDV.ToArray()),
                new NpgsqlParameter("p_cd_id",lstChucDanh),
                new NpgsqlParameter("p_hoc_ham_id",lstHocHam),
                new NpgsqlParameter("p_hoc_vi_id",null)
            };

            dt = dp.getDataTableProc("sp4_bc_so_luong_cnvc_hocham_hocvi_gioitinh", paras);

            return dt;
        }

        public DataTable NV_Theo_LoaiQD(List<int> lstLoaiQD, DateTime? tu_ngay, DateTime? den_ngay)
        {
            DataTable dt = new DataTable();

            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("p_loai_qd_id",lstLoaiQD == null ? null : lstLoaiQD.ToArray()),
                new NpgsqlParameter("p_tu_ngay",tu_ngay),
                new NpgsqlParameter("p_den_ngay",den_ngay)
            };

            dt = dp.getDataTableProc("sp4_bc_cnvc_by_loai_qd", paras);

            return dt;
        }

        public DataTable NV_Theo_HinhThuc_MoHinh(List<int> lstMoHinh, List<int> lstHinhThuc)
        {
            DataTable dt = new DataTable();

            IDataParameter[] paras = new IDataParameter[2]{
                new NpgsqlParameter("p_mo_hinh_id",lstMoHinh == null ? null : lstMoHinh.ToArray()),
                new NpgsqlParameter("p_hinh_thuc_id",lstHinhThuc == null ? null : lstHinhThuc.ToArray())
            };

            dt = dp.getDataTableProc("sp4_bc_nv_mo_hinh_hinh_thuc_dao_tao", paras);

            return dt;
        }

        #endregion
    }
}
