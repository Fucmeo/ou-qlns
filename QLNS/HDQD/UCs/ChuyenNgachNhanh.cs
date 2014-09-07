﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;
using System.Reflection;
using System.Threading;


namespace HDQD.UCs
{
    public partial class ChuyenNgachNhanh : UserControl
    {
        Business.HDQD.LoaiQuyetDinh oLoaiQuyetDinh;
        Business.Luong.TinhLuong oTinhLuong;
        Business.CNVC.CNVC_QTr_CongTac_OU oCNVC_QTr_CongTac_OU;
        Business.FTP oFTP;
        public static Business.CNVC.CNVC_File oFile;
        List<string> lstMaNV;

        Business.Luong.BacHeSo oBacHeSo;
        DataTable dtBacHeSo;
        DataTable dtLuong;
        DataTable dtQtrCtac;
        DataTable dtDTGV; // data source cho data gridview

        List<KeyValuePair<string, string>> kvpDV;
        List<KeyValuePair<string, string>> kvpCV;
        List<KeyValuePair<string, string>> kvpNgachCu;
        List<KeyValuePair<string, int>> kvpBacCu;
        List<KeyValuePair<string, double>> kvpHSCu;
        List<KeyValuePair<string, DateTime>> kvpNgayHuongCu;

        List<KeyValuePair<string, int>> kvpBacMoi;
        List<KeyValuePair<string, string>> kvpNgachMoi;
        List<KeyValuePair<string, double>> kvpHSMoi;
        List<KeyValuePair<string, DateTime>> kvpNgayHuongMoi;


        // KHANG - UPLOAD FILE
        public static DataTable dtFile;
        string[] ServerPaths;
        int nNewFilesCount;         // so file add new
        string[] dbPaths;

        public ChuyenNgachNhanh()
        {
            InitializeComponent();
        }

        private void InitObject()
        {
            lstMaNV = new List<string>();
            oTinhLuong = new Business.Luong.TinhLuong();
            oFTP = new Business.FTP();
            oFile = new Business.CNVC.CNVC_File();
            oCNVC_QTr_CongTac_OU = new Business.CNVC.CNVC_QTr_CongTac_OU();
            oBacHeSo = new Business.Luong.BacHeSo();
            dtBacHeSo = new DataTable();
            dtFile = new DataTable();
            dtQtrCtac = new DataTable();

            kvpDV = new List<KeyValuePair<string, string>>();
            kvpCV = new List<KeyValuePair<string, string>>();
            kvpBacCu = new List<KeyValuePair<string, int>>();
            kvpNgachCu = new List<KeyValuePair<string, string>>();
            kvpHSCu = new List<KeyValuePair<string, double>>();
            kvpNgayHuongCu = new List<KeyValuePair<string, DateTime>>();

            kvpBacMoi = new List<KeyValuePair<string, int>>();
            kvpNgachMoi = new List<KeyValuePair<string, string>>();
            kvpHSMoi = new List<KeyValuePair<string, double>>();
            kvpNgayHuongMoi = new List<KeyValuePair<string, DateTime>>();

            dtLuong = new DataTable();

            oLoaiQuyetDinh = new Business.HDQD.LoaiQuyetDinh();


            thongTinCNVC1.txt_HoTen.KeyUp += new KeyEventHandler(txt_HoTen_KeyUp);
        }

        void txt_HoTen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (thongTinCNVC1.txt_MaNV.Text != "")
                {
                    if (!lstMaNV.Contains(thongTinCNVC1.txt_MaNV.Text))
                    {
                        lstMaNV.Add(thongTinCNVC1.txt_MaNV.Text);

                        lb_DSCNVC.Items.Add(thongTinCNVC1.txt_HoTen.Text);

                        GetThongTin_Luong(thongTinCNVC1.txt_MaNV.Text);
                        GetChucDanh_ChucVu(thongTinCNVC1.txt_MaNV.Text);
                        

                        

                        thongTinCNVC1.txt_HoTen.Text = thongTinCNVC1.txt_MaNV.Text = "";
                    }
                }
            }
        }

        private void ChuyenNgachNhanh_Load(object sender, EventArgs e)
        {
            InitObject();
            LoadCombo_NgachBac();
        }

        void LoadCombo_NgachBac()
        {
            try
            {
                dtBacHeSo = oBacHeSo.GetData();
                if (dtBacHeSo.Rows.Count > 0)
                {


                    DataTable dtMaNgach = dtBacHeSo.DefaultView.ToTable(true, new string[2] { "ma_ngach", "ten_ngach" });
                    dtMaNgach.Columns.Add("ma_ten_ngach", typeof(string), "ma_ngach + '-' + ten_ngach");

                    DataView dv = dtMaNgach.AsDataView();
                    dv.Sort = "ten_ngach";
                    dtMaNgach = dv.ToTable();

                    comb_NgachMoi.DataSource = dtMaNgach;
                    comb_NgachMoi.ValueMember = "ma_ngach";
                    comb_NgachMoi.DisplayMember = "ma_ten_ngach";


                    DataTable dtBac = dtBacHeSo.DefaultView.ToTable(true, new string[2] { "bac", "id" });
                    comb_BacMoi.DataSource = dtBac;
                    comb_BacMoi.DisplayMember = "bac";
                    comb_BacMoi.ValueMember = "id";
                }

            }
            catch (Exception)
            {
            }

        }

        void GetChucDanh_ChucVu(string ma_nv)
        {
            try
            {
                oCNVC_QTr_CongTac_OU.MaNV = ma_nv;
                dtQtrCtac = oCNVC_QTr_CongTac_OU.GetData();

                string dv = (from d in dtQtrCtac.AsEnumerable()
                             where d.Field<string>("tinh_trang") == "Đang công tác"
                             select d.Field<string>("don_vi")
                            ).First();

                string cv = (from d in dtQtrCtac.AsEnumerable()
                             where d.Field<string>("tinh_trang") == "Đang công tác"
                             select d.Field<string>("chuc_vu")
                            ).First();

                kvpCV.Add(new KeyValuePair<string,string>(ma_nv,cv));
                kvpDV.Add(new KeyValuePair<string,string>(ma_nv,dv));
            }
            catch (Exception)
            {
                
            }
        }

        void GetThongTin_Luong(string ma_nv)
        {
            try
            {
                dtLuong = oTinhLuong.GetThongTinLuong_ByNV(ma_nv);

                int bac_hs_id = (from l in dtLuong.AsEnumerable()
                                 where l.Field<int?>("ngach_bac_heso_id") != null
                                 select l.Field<int>("ngach_bac_heso_id")
                                ).First();

                string ngach = (from n in dtBacHeSo.AsEnumerable()
                                where n.Field<int>("id") == bac_hs_id
                                select n.Field<string>("ten_ngach") + "-" + n.Field<string>("ma_ngach")).First();

                int bac = (from n in dtBacHeSo.AsEnumerable()
                                where n.Field<int>("id") == bac_hs_id
                           select n.Field<int>("bac")).First();

                double hs = (from n in dtBacHeSo.AsEnumerable()
                              where n.Field<int>("id") == bac_hs_id
                             select n.Field<double>("he_so")).First();

                DateTime tu_ngay = (from l in dtLuong.AsEnumerable()
                                    where l.Field<int?>("ngach_bac_heso_id") != null
                                    select l.Field<DateTime>("tu_ngay")
                                ).First();

                kvpNgachCu.Add(new KeyValuePair<string,string>(ma_nv,ngach));
                kvpBacCu.Add(new KeyValuePair<string, int>(ma_nv, bac));
                kvpHSCu.Add(new KeyValuePair<string, double>(ma_nv, hs));
                kvpNgayHuongCu.Add(new KeyValuePair<string, DateTime>(ma_nv, tu_ngay));
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể lấy thông tin ngạch bậc của nhân viên này, có thể do nhân viên này không có lương hệ số, xin vui lòng thử lại sau.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Convert List to Data Table
        private DataTable ToDataTable<T>(List<T> items)
        {
            var table = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                table.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                table.Rows.Add(values);
            }

            return table;
        }
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
        #endregion

        private void comb_NgachMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m_ma_ngach = comb_NgachMoi.SelectedValue.ToString();
            DateTime m_tu_ngay_select = dtp_NgayBatDau.Value;
            LoadDataForCbo_BacHeso(m_ma_ngach, m_tu_ngay_select);
        }

        private void LoadDataForCbo_BacHeso(string p_ma_ngach, DateTime p_tu_ngay)
        {
            try
            {
                var result = (from c in dtBacHeSo.AsEnumerable()
                              where c.Field<string>("ma_ngach") == p_ma_ngach && p_tu_ngay >= c.Field<DateTime>("tu_ngay") && p_tu_ngay <= c.Field<DateTime?>("den_ngay")
                              orderby c.Field<int>("bac")
                              select new { id = c.Field<int>("id"), bac = c.Field<int>("bac"), he_so = c.Field<double>("he_so") }
                                  ).ToList();
                if (result.Count == 0)
                    result = (from c in dtBacHeSo.AsEnumerable()
                              where c.Field<string>("ma_ngach") == p_ma_ngach && c.Field<bool>("tinh_trang") == true && p_tu_ngay >= c.Field<DateTime>("tu_ngay")
                              orderby c.Field<int>("bac")
                              select new { id = c.Field<int>("id"), bac = c.Field<int>("bac"), he_so = c.Field<double>("he_so") }
                                  ).ToList();

                DataTable dt = ToDataTable(result);

                comb_BacMoi.DataSource = dt;
                comb_BacMoi.DisplayMember = "bac";
                comb_BacMoi.ValueMember = "id";

                if (result.Count == 0)
                {
                    txt_HeSoMoi.Text = "";
                }

            }
            catch
            { }
        }

        private void lb_DSCNVC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( lb_DSCNVC.SelectedIndex != -1)
            {
                string ten_ma = lb_DSCNVC.SelectedItem.ToString();
                string ma_nv = ten_ma.Substring(ten_ma.IndexOf("-")).Replace("- ","");

                #region Ngach Cu
                foreach (KeyValuePair<string, string> kvp in kvpDV)
                {
                    if (kvp.Key == ma_nv)
                    {
                        txt_DV.Text = kvp.Value;
                        break;
                    }
                }

                foreach (KeyValuePair<string, string> kvp in kvpCV)
                {
                    if (kvp.Key == ma_nv)
                    {
                        txt_CV.Text = kvp.Value;
                        break;
                    }
                }

                foreach (KeyValuePair<string, string> kvp in kvpNgachCu)
                {
                    if (kvp.Key == ma_nv)
                    {
                        txt_NgachCu.Text = kvp.Value;
                        break;
                    }
                }

                foreach (KeyValuePair<string, int> kvp in kvpBacCu)
                {
                    if (kvp.Key == ma_nv)
                    {
                        txt_BacCu.Text = kvp.Value.ToString();
                        break;
                    }
                }

                foreach (KeyValuePair<string, double> kvp in kvpHSCu)
                {
                    if (kvp.Key == ma_nv)
                    {
                        txt_HeSoCu.Text = kvp.Value.ToString();
                        break;
                    }
                }

                foreach (KeyValuePair<string, DateTime> kvp in kvpNgayHuongCu)
                {
                    if (kvp.Key == ma_nv)
                    {
                        dtp_NgayCu.Value = kvp.Value;
                        break;
                    }
                } 
                #endregion
            }
        }
    }
}