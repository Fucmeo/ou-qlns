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
    public class QD_File
    {
        DataProvider.DataProvider dp;

        

        #region Init method

        public QD_File()
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

        public string MaQD { get; set; }

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

        #endregion

        #region Methods

        public bool AddFileArray(string[] FilesPath)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("p_ma_qd",MaQD), 
                new NpgsqlParameter("p_path",FilesPath), 
                new NpgsqlParameter("p_mo_ta",mota)
            };
            check = (int)dp.executeScalarProc("sp1_insert_quyetdinh_file", paras);
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
                new NpgsqlParameter("ma_nv",MaQD), 
                new NpgsqlParameter("path",path), 
                new NpgsqlParameter("mo_ta",mota)
            };
            check = (int)dp.executeScalarProc("sp_update_QD_File", paras);
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
            IDataParameter[] paras = new IDataParameter[2]{               
                new NpgsqlParameter("p_path",DeletePaths),
                new NpgsqlParameter("p_ma_nv",MaQD)
            };
            check = (int)dp.executeScalarProc("sp1_delete_qd_file", paras);
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
            List<QD_File> listFile = new List<QD_File>();
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",MaQD)
            };

            dt = dp.getDataTableProc("sp_select_qd_File", paras);

            return dt;
        }

        

        #endregion
    }
}
