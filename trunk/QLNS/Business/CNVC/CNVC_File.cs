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
    public class CNVC_File
    {
        DataProvider.DataProvider dp;

        

        #region Init method

        public CNVC_File()
        {
            dp = new DataProvider.DataProvider();
            
        }
        

        #endregion

        #region Properties

        public enum eFileType { HopDong, BoNhiem, ThoiNhiem,DaoTao,BoiDuong, Avatar };

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

        private string mota;

        public string MoTa
        {
            get { return mota; }
            set { mota = value; }
        }

        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public eFileType FileType { get; set; }

        public string Link { get; set; }


        #endregion

        #region Methods

        public bool AddFileArray(string[] FilesPath)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[5]{
                new NpgsqlParameter("p_ma_nv",manv), 
                new NpgsqlParameter("p_path",FilesPath), 
                new NpgsqlParameter("p_mo_ta",mota),
                new NpgsqlParameter("p_file_type",FileType.ToString().ToLower()),
                new NpgsqlParameter("p_link_id",Link)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_file_array", paras);
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
            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("id",id), 
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("path",path), 
                new NpgsqlParameter("mo_ta",mota)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_file", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool DeleteAvatar()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{               
                new NpgsqlParameter("p_ma_nv",manv), 
            };
            check = (int)dp.executeScalarProc("sp_delete_avatar", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Delete_HD_QD(string[] DeletePaths)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[4]{               
                new NpgsqlParameter("p_path",DeletePaths),
                new NpgsqlParameter("p_ma_nv",manv),
                new NpgsqlParameter("p_link",Link),
                new NpgsqlParameter("p_file_type",FileType.ToString().ToLower())
            };
            check = (int)dp.executeScalarProc("sp_delete_cnvc_file_hd_qd", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        //public List<CNVC_File> GetData()
        //{
        //    DataTable dt;
        //    List<CNVC_File> listFile = new List<CNVC_File>();
        //    IDataParameter[] paras = new IDataParameter[3]{
        //        new NpgsqlParameter("p_ma_nv",manv),
        //        new NpgsqlParameter("p_file_type",FileType.ToString().ToLower())    ,
        //        new NpgsqlParameter("p_link_id",Link)    
        //    };

        //    dt = dp.getDataTableProc("sp_select_cnvc_file", paras);

        //    listFile = dt.AsEnumerable().Select(row =>
        //         new CNVC_File
        //         {
        //             id = row.Field<int>("id"),
        //             manv = row.Field<string>("ma_nv"),
        //             path = row.Field<string>("path"),                     
        //             mota = row.Field<string>("mo_ta"),
        //              =  ,
        //             Link = row.Field<string>("p_link_id")
        //         }).ToList();

        //    return listFile;
        //}

        public DataTable GetData()
        {
            DataTable dt;
            List<CNVC_File> listFile = new List<CNVC_File>();
            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("p_ma_nv",manv),
                new NpgsqlParameter("p_file_type",FileType.ToString().ToLower())    ,
                new NpgsqlParameter("p_link_id",Link)    
            };

            dt = dp.getDataTableProc("sp_select_cnvc_file", paras);

            return dt;
        }

        

        #endregion
    }
}
