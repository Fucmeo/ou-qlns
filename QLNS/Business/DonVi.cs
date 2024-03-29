﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;

namespace Business
{
    public class DonVi
    {
        DataProvider.DataProvider dp;

        #region Init method

        public DonVi()
        {
            dp = new DataProvider.DataProvider();
        }

        public DonVi(int p_id)
        {
            id = p_id;
            dp = new DataProvider.DataProvider();
        }

        public DonVi(int? p_id, string p_tendvviettat, string p_tendonvi, int? p_dvchaid, DateTime? p_tungay, DateTime? p_denngay, bool? p_isactive, string p_ghichu)
        {
            id = p_id;
            tendvviettat = p_tendvviettat;
            tendonvi = p_tendonvi;
            dvchaid = p_dvchaid;
            tungay = p_tungay;
            denngay = p_denngay;
            isactive = p_isactive;
            ghichu = p_ghichu;
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

        private string tendvviettat;

        public string TenDVVietTat
        {
            get { return tendvviettat; }
            set { tendvviettat = value; }
        }

        private string tendonvi;

        public string TenDonVi
        {
            get { return tendonvi; }
            set { tendonvi = value; }
        }

        private int? dvchaid;

        public int? DVChaID
        {
            get { return dvchaid; }
            set { dvchaid = value; }
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

        private bool? isactive;

        public bool? IsActive
        {
            get { return isactive; }
            set { isactive = value; }
        }

        private string ghichu;

        public string GhiChu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        public int? loaidvid { get; set; }

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[8]{
                new NpgsqlParameter("ten_don_vi_viet_tat",tendvviettat),
                new NpgsqlParameter("ten_don_vi",tendonvi),
                new NpgsqlParameter("don_vi_cha_id",dvchaid),
                new NpgsqlParameter("tu_ngay",tungay),
                new NpgsqlParameter("den_ngay",denngay),
                new NpgsqlParameter("is_active",isactive),
                new NpgsqlParameter("ghi_chu",ghichu),
                new NpgsqlParameter("p_loai_don_vi_id",loaidvid)
            };
            check = (int)dp.executeScalarProc("sp_insert_don_vi", paras);
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
            IDataParameter[] paras = new IDataParameter[9]{
                new NpgsqlParameter("id",id),
                new NpgsqlParameter("ten_don_vi_viet_tat",tendvviettat),
                new NpgsqlParameter("ten_don_vi",tendonvi),
                new NpgsqlParameter("don_vi_cha_id",dvchaid),
                new NpgsqlParameter("tu_ngay",tungay),
                new NpgsqlParameter("den_ngay",denngay),
                new NpgsqlParameter("is_active",isactive),
                new NpgsqlParameter("ghi_chu",ghichu),
                new NpgsqlParameter("p_loai_don_vi_id",loaidvid)
            };
            check = (int)dp.executeScalarProc("sp_update_don_vi", paras);
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
                new NpgsqlParameter("id",id)
            };
            check = (int)dp.executeScalarProc("sp_delete_don_vi", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public List<DonVi> GetList()
        {
            DataTable dt = new DataTable();
            List<DonVi> listDonVi = new List<DonVi>();

            dt = dp.getDataTable("select * from v_don_vi_con_hd");
            listDonVi = dt.AsEnumerable().Select(row =>
                 new DonVi
                 {
                     id = row.Field<int>("id"),
                     tendonvi = row.Field<string>("ten_don_vi"),
                     dvchaid = row.Field<int?>("don_vi_cha_id")
                 }).ToList();

            return listDonVi;
        }

        public DataTable GetCNVCList(string ViewName)
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_" + ViewName);

            return dt;
        }

        public DataTable GetCNVCList_All(int dv_id)
        {
            DataTable dt = new DataTable();

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_dv_id",dv_id)               
            };

            dt = dp.getDataTableProc("sp_select_cnvc_from_dvid", paras);

            return dt;
        }

        public DataTable GetDonViDetailList()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_don_vi");

            return dt;
        }

        public DataTable GetDonViList()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_don_vi_list");

            return dt;
        }

        public DataTable GetActiveDonVi()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_don_vi_con_hd");

            return dt;
        }

        public DataTable GetInActiveDonVi()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_don_vi_ngung_hd");

            return dt;
        }

        public DataTable GetDonVi_All()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_don_vi_all");

            return dt;
        }

        public DataTable GetDonVi_New(int p_don_vi_id_old)
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_don_vi_old",p_don_vi_id_old)               
            };

            dt = dp.getDataTableProc("sp1_qsearch_don_vi_moi", paras);

            return dt;
        }

        #endregion
    }
}
