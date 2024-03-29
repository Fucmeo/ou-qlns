﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;

namespace Business.HDQD
{
    public class LoaiHopDong
    {
        DataProvider.DataProvider dp;

        #region Inits Methods
        public LoaiHopDong()
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

        private string loai_hopdong;

        public string Loai_Hop_Dong
        {
            get { return loai_hopdong; }
            set { loai_hopdong = value; }
        }

        private string mota;

        public string MoTa
        {
            get { return mota; }
            set { mota = value; }
        }

       

        #endregion

        #region Methods
        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[2]{
                new NpgsqlParameter("p_loai_hop_dong",loai_hopdong),
                new NpgsqlParameter("p_mo_ta",mota)
            };
            check = (int)dp.executeScalarProc("sp1_insert_loai_hop_dong", paras);
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
            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("p_id",id), 
                new NpgsqlParameter("p_loai_hop_dong",loai_hopdong),
                new NpgsqlParameter("p_mo_ta",mota)
            };
            check = (int)dp.executeScalarProc("sp1_update_loai_hop_dong", paras);
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
            check = (int)dp.executeScalarProc("sp1_delete_loai_hop_dong", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable GetList()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_loai_hop_dong");

            return dt;
        }

        public DataTable GetList_Compact()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_loai_hop_dong_compact");

            return dt;
        }
        #endregion
    }
}
