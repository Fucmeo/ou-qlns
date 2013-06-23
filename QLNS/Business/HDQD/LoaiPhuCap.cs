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
    public class LoaiPhuCap
    {
        DataProvider.DataProvider dp;
        ExpressionTree ET;

        #region Init Methods
        public LoaiPhuCap()
        {
            dp = new DataProvider.DataProvider();
            ET = new ExpressionTree();
        }

        #endregion

        #region Properties
        private int? id;

        public int? ID
        {
            get { return id; }
            set { id = value; }
        }

        private string ten;

        public string TenLoaiPhuCap
        {
            get { return ten; }
            set { ten = value; }
        }

        private string tenviettat;

        public string TenLoaiPC_Viettat
        {
            get { return tenviettat; }
            set { tenviettat = value; }
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
            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("p_ten_loai",ten),
                new NpgsqlParameter("p_ten_viet_tat",tenviettat),
                new NpgsqlParameter("p_mo_ta",mota)
            };
            check = (int)dp.executeScalarProc("sp1_insert_loai_phu_cap", paras);
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
                new NpgsqlParameter("p_id",id), 
                new NpgsqlParameter("p_ten_loai",ten),
                new NpgsqlParameter("p_ten_viet_tat",tenviettat),
                new NpgsqlParameter("p_mo_ta",mota)
            };
            check = (int)dp.executeScalarProc("sp1_update_loai_phu_cap", paras);
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
            check = (int)dp.executeScalarProc("sp1_delete_loai_phu_cap", paras);
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

            dt = dp.getDataTable("select * from v_loai_phu_cap");

            return dt;
        }

        public DataTable GetList_Cbo()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_loai_phu_cap_cbo");

            return dt;
        }

        public bool AddDetail(int loaipc_id, DateTime tungay , DateTime? denngay , string ghichu , int cachtinh , string chuoi_cong_thuc )
        {
            List<string> lstValue = new List<string>();
            List<Boolean> lstIsLeaf = new List<Boolean>();
            List<Boolean> lstIsRoot = new List<Boolean>();
            List<string> lstLeftNode = new List<string>();
            List<string> lstRightNode = new List<string>();

            if (cachtinh == 4)
            {
                ET.GetExpressionTreeData(ET.Infix2ExpressionTree(chuoi_cong_thuc));
                lstValue = ET.lstValue;
                lstIsLeaf = ET.lstIsLeaf;
                lstIsRoot = ET.lstIsRoot;
                lstLeftNode = ET.lstLeftNode;
                lstRightNode = ET.lstRightNode;
            }
            else
            {
                lstValue = null;
                lstIsLeaf = null;
                lstIsRoot = null;
                lstLeftNode = null;
                lstRightNode = null;
            }

            int check;
            IDataParameter[] paras = new IDataParameter[11]{
                new NpgsqlParameter("p_loai_pc_id",loaipc_id), 
                new NpgsqlParameter("p_cach_tinh",cachtinh),
                new NpgsqlParameter("p_tu_ngay",tungay),
                new NpgsqlParameter("p_den_ngay",denngay),
                new NpgsqlParameter("p_ghi_chu",ghichu),
                new NpgsqlParameter("m_value",(lstValue == null) ? null : lstValue.ToArray()),
                new NpgsqlParameter("m_is_leaf",(lstValue == null) ? null :lstIsLeaf.ToArray()),
                new NpgsqlParameter("m_is_root",(lstValue == null) ? null :lstIsRoot.ToArray()),
                new NpgsqlParameter("m_left_node",(lstValue == null) ? null :lstLeftNode.ToArray()),
                new NpgsqlParameter("m_right_node",(lstValue == null) ? null :lstRightNode.ToArray()),
                new NpgsqlParameter("m_chuoi_cong_thuc",chuoi_cong_thuc)
            };
            check = (int)dp.executeScalarProc("sp1_insert_loai_phu_cap_detail", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool DeleteDetail(int p_id)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_id",p_id)
            };
            check = (int)dp.executeScalarProc("sp1_delete_loai_phu_cap_detail", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable GetDTCachTinhDetail()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_loai_phu_cap_detail");

            return dt;
        }

        public DataTable GetDTCongThucElement()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_cong_thuc_element");

            return dt;
        }


        #endregion


    }
}
