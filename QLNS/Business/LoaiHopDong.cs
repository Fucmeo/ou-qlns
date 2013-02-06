using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;

namespace Business
{
    public class LoaiHopDong
    {
        DataProvider.DataProvider dp;

        #region Init method

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

        private string loaihopdong;

        public string Loai_HD
        {
            get { return loaihopdong; }
            set { loaihopdong = value; }
        }

        private string mota;

        public string MoTa
        {
            get { return mota; }
            set { mota = value; }
        }

        private bool? bienche_hopdong;

        public bool? BienChe_HopDong
        {
            get { return bienche_hopdong; }
            set { bienche_hopdong = value; }
        }

        private bool? cothoihan;

        public bool? CoThoiHan
        {
            get { return cothoihan; }
            set { cothoihan = value; }
        }

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("loai_hop_dong",loaihopdong), 
                new NpgsqlParameter("mo_ta",mota),
                new NpgsqlParameter("bienche_hopdong",bienche_hopdong),
                new NpgsqlParameter("co_thoi_han",cothoihan)
            };
            check = (int)dp.executeScalarProc("sp_insert_loai_hop_dong", paras);
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
            IDataParameter[] paras = new IDataParameter[5]{
                new NpgsqlParameter("id",id), 
                new NpgsqlParameter("loai_hop_dong",loaihopdong), 
                new NpgsqlParameter("mo_ta",mota),
                new NpgsqlParameter("bienche_hopdong",bienche_hopdong),
                new NpgsqlParameter("co_thoi_han",cothoihan)
            };
            check = (int)dp.executeScalarProc("sp_update_loai_hop_dong", paras);
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
            check = (int)dp.executeScalarProc("sp_delete_loai_hop_dong", paras);
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
