using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.CNVC;


namespace QLNS.UCs.DanhMucThongTin
{
    public partial class QLNS_TrinhDo_ChuyenMon : UserControl
    {
        public CNVC_TrinhDoPhoThong oCNVC_TrinhDoPhoThong;
        public CNVC_ChuyenMonTongQuat oCNVC_ChuyenMonTongQuat;
        public DataTable dtTrinhDo, dtChuyenMon, dtTinhTP, dtMoHinh;
        Business.TinhTP oTinhTP;
        public static int nNewTinhTPID = 0;     // ID cua tinh thanh pho moi them vao

        public QLNS_TrinhDo_ChuyenMon()
        {
            InitializeComponent();
            oCNVC_ChuyenMonTongQuat = new CNVC_ChuyenMonTongQuat();
            oCNVC_TrinhDoPhoThong = new CNVC_TrinhDoPhoThong();
            dtChuyenMon = new DataTable();
            dtTrinhDo = new DataTable();
            dtTinhTP = new DataTable();
            dtMoHinh = new DataTable();
            oTinhTP = new Business.TinhTP();

        }

        public void GetTrinhDoInfo(string m_MaNV)
        {
            oCNVC_TrinhDoPhoThong.MaNV = m_MaNV;
            dtTrinhDo = oCNVC_TrinhDoPhoThong.GetData();
        }

        public void GetChuyenMonInfo(string m_MaNV)
        {
            oCNVC_ChuyenMonTongQuat.MaNV = m_MaNV;
            dtChuyenMon = oCNVC_ChuyenMonTongQuat.GetData();
        }

        private void QLNS_TrinhDo_ChuyenMon_Load(object sender, EventArgs e)
        {

        }

        private void LoadTinhData()
        {
            dtTinhTP = oTinhTP.GetData();

            DataTable dt = dtTinhTP.Copy();

            if (dt.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt.NewRow();
                dr["ten_tinh_tp"] = "";
                dr["id"] = -1;
                dr["quoc_gia_id"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }

            // comb
            comB_Tinh.DataSource = dt;
            comB_Tinh.DisplayMember = "ten_tinh_tp";
            comB_Tinh.ValueMember = "id"; 
        }

        

        public void FillInfo()
        {

            if (dtChuyenMon.Rows.Count > 0)
            {
                txt_TenTruong.Text = Convert.ToString(dtChuyenMon.Rows[0]["ten_truong"]);
                txt_PhuongXa.Text = Convert.ToString(dtChuyenMon.Rows[0]["phuong_xa"]);
                txt_QuanHuyen.Text = Convert.ToString(dtChuyenMon.Rows[0]["quan_huyen"]);

                if (dtChuyenMon.Rows[0]["tinh_thanhpho_id"].ToString() != "")
                {
                    comB_Tinh.SelectedValue = Convert.ToInt32(dtChuyenMon.Rows[0]["tinh_thanhpho_id"]);
                }
                else
                {
                    comB_Tinh.SelectedValue = -1;
                }

            }


            if (dtTrinhDo.Rows.Count > 0)
            {
                DataTable dt = dtTrinhDo.Copy();
                dtgv_TrinhDo.Columns.Clear();
                dtgv_TrinhDo.DataSource = dt;
                Setup_dtgv_CMNDHoChieu();

            }
        }

        private void Setup_dtgv_CMNDHoChieu()
        {
            dtgv_TrinhDo.Columns[0].Visible = dtgv_TrinhDo.Columns[6].Visible =
                dtgv_TrinhDo.Columns[8].Visible = false; // id , id tinh va ma nv

            dtgv_TrinhDo.Columns[1].HeaderText = "Cấp độ";
            dtgv_TrinhDo.Columns[1].Width = 150;
            dtgv_TrinhDo.Columns[2].HeaderText = "Tên trường";
            dtgv_TrinhDo.Columns[2].Width = 300;
            dtgv_TrinhDo.Columns[3].HeaderText = "Phường xã";
            dtgv_TrinhDo.Columns[3].Width = 100;
            dtgv_TrinhDo.Columns[4].HeaderText = "Quận huyện";
            dtgv_TrinhDo.Columns[4].Width = 100;
            dtgv_TrinhDo.Columns[5].HeaderText = "Tỉnh / TP";
            dtgv_TrinhDo.Columns[5].Width = 150;
            dtgv_TrinhDo.Columns[6].HeaderText = "Năm học";
            dtgv_TrinhDo.Columns[6].Width = 200;

           
        }

        private void Init_dtgv_TrinhDo()
        {
            dtgv_TrinhDo.Columns.Clear();
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã NV";
            col.Width = 200;
            col.Visible = false;
            dtgv_TrinhDo.Columns.Add(col);

            col.HeaderText = "Cấp độ";
            col.Width = 150;
            dtgv_TrinhDo.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên trường";
            col.Width = 300;
            dtgv_TrinhDo.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Phường xã";
            col.Width = 100;
            dtgv_TrinhDo.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Quận huyện";
            col.Width = 100;
            dtgv_TrinhDo.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tỉnh / TP";
            col.Width = 250;
            dtgv_TrinhDo.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tỉnh ID";
            col.Width = 10;
            col.Visible = false;
            dtgv_TrinhDo.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Năm học";
            col.Width = 200;
            dtgv_TrinhDo.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Id";
            col.Width = 10;
            col.Visible = false;
            dtgv_TrinhDo.Columns.Add(col);

            //dtgv_CMNDHoChieu.Rows.Add(1);
        }


    }
}
