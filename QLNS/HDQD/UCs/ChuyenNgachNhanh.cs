using System;
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
        List<KeyValuePair<string, int>> kvpLuongID;
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

        void InitObject_AfterSaving()
        {
            lstMaNV = new List<string>();
            oTinhLuong = new Business.Luong.TinhLuong();
            oFTP = new Business.FTP();
            oFile = new Business.CNVC.CNVC_File();
            oCNVC_QTr_CongTac_OU = new Business.CNVC.CNVC_QTr_CongTac_OU();
            oBacHeSo = new Business.Luong.BacHeSo();
            dtFile = new DataTable();

            dtQtrCtac = new DataTable();

            kvpLuongID = new List<KeyValuePair<string, int>>();
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

            kvpLuongID = new List<KeyValuePair<string, int>>();
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

                        GetChucDanh_ChucVu(thongTinCNVC1.txt_MaNV.Text);
                        GetThongTin_Luong(thongTinCNVC1.txt_MaNV.Text);


                        

                        thongTinCNVC1.txt_HoTen.Text = thongTinCNVC1.txt_MaNV.Text = "";
                    }
                }
            }
        }

        private void ChuyenNgachNhanh_Load(object sender, EventArgs e)
        {
            InitObject();
            LoadCombo_NgachBac();

            thongTinQuyetDinh1.comB_Loai.DataSource = null;

            DataTable dt = new DataTable();
            dt.Columns.Add("ten_loai_quyet_dinh", typeof(string));
            dt.Columns.Add("loai_quyet_dinh_id", typeof(int));

            dt.Rows.Add(new object[2]{"Chuyển ngạch",17});

            thongTinQuyetDinh1.comB_Loai.DataSource = dt;
            thongTinQuyetDinh1.comB_Loai.DisplayMember = "ten_loai_quyet_dinh";
            thongTinQuyetDinh1.comB_Loai.ValueMember = "loai_quyet_dinh_id";
        }

        void LoadCombo_NgachBac()
        {
            try
            {
                dtBacHeSo = oBacHeSo.GetData();
                if (dtBacHeSo.Rows.Count > 0)
                {


                    DataTable dtMaNgach = dtBacHeSo.DefaultView.ToTable(true, new string[2] { "ma_ngach", "ten_ngach" });
                    dtMaNgach.Columns.Add("ma_ten_ngach", typeof(string), "ten_ngach + '-' + ma_ngach");

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

                int luong_id = (from n in dtLuong.AsEnumerable()
                                where n.Field<int?>("ngach_bac_heso_id") != null
                                select n.Field<int>("luong_id")).Max();

                int bac_hs_id = (from l in dtLuong.AsEnumerable()
                                 where l.Field<int?>("luong_id") == luong_id
                                 select l.Field<int>("ngach_bac_heso_id")
                                ).First();

                DateTime tu_ngay = (from l in dtLuong.AsEnumerable()
                                    where l.Field<int?>("luong_id") == luong_id
                                    select l.Field<DateTime>("tu_ngay")
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

                

                kvpNgachCu.Add(new KeyValuePair<string,string>(ma_nv,ngach));
                kvpBacCu.Add(new KeyValuePair<string, int>(ma_nv, bac_hs_id));
                kvpLuongID.Add(new KeyValuePair<string, int>(ma_nv, luong_id));
                kvpHSCu.Add(new KeyValuePair<string, double>(ma_nv, hs));
                kvpNgayHuongCu.Add(new KeyValuePair<string, DateTime>(ma_nv, tu_ngay));

                kvpBacMoi.Add(new KeyValuePair<string, int>(ma_nv, bac_hs_id));

                lstMaNV.Add(thongTinCNVC1.txt_MaNV.Text);

                lb_DSCNVC.Items.Add(thongTinCNVC1.txt_HoTen.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể lấy thông tin ngạch bậc của nhân viên "+ma_nv+ " , có thể do nhân viên này không có lương hệ số, xin vui lòng thử lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                for (int i = 0; i < kvpDV.Count; i++)
                {
                    if (kvpDV[i].Key == ma_nv)
                    {
                        txt_DV.Text = kvpDV[i].Value;
                        break;
                    }

                    if (i + 1 == kvpDV.Count)
                    {
                        txt_DV.Text = "";   
                    }
                }

                for (int i = 0; i < kvpCV.Count; i++)
                {
                    if (kvpCV[i].Key == ma_nv)
                    {
                        txt_CV.Text = kvpCV[i].Value;
                        break;
                    }

                    if (i + 1 == kvpCV.Count)
                    {
                        txt_CV.Text = "";
                    }
                }

               

                foreach (KeyValuePair<string, string> kvp in kvpNgachCu)
                {
                    if (kvp.Key == ma_nv)
                    {
                        txt_NgachCu.Text = kvp.Value;
                        comb_NgachMoi.Text = kvp.Value;
                        break;
                    }
                }

                foreach (KeyValuePair<string, int> kvp in kvpBacCu)
                {
                    if (kvp.Key == ma_nv)
                    {
                        int bac = (from n in dtBacHeSo.AsEnumerable()
                                   where n.Field<int>("id") == kvp.Value
                                   select n.Field<int>("bac")).First();

                        txt_BacCu.Text = bac.ToString();
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

                #region Ngach Moi

                for (int i = 0; i < kvpNgayHuongMoi.Count; i++)
                {
                    if (kvpNgayHuongMoi[i].Key == ma_nv)
                    {
                        dtp_NgayBatDau.Value= kvpNgayHuongMoi[i].Value;
                        break;
                    }

                }

                for (int i = 0; i < kvpBacMoi.Count; i++)
                {
                    if (kvpBacMoi[i].Key == ma_nv)
                    {
                        comb_BacMoi.SelectedValue = kvpBacMoi[i].Value.ToString();
                        break;
                    }

                }
                
                #endregion
            }
        }

        private void btn_DelNV_Click(object sender, EventArgs e)
        {
            if (lb_DSCNVC.SelectedIndex != -1 &&
                MessageBox.Show("Bạn thực sự muốn xoá nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string ten_ma = lb_DSCNVC.SelectedItem.ToString();
                string ma_nv = ten_ma.Substring(ten_ma.IndexOf("-")).Replace("- ","");
                RemoveNVFromKVP(ma_nv);
                lb_DSCNVC.Items.Remove(ten_ma);
                lstMaNV.Remove(ma_nv);
            }
        }

        void RemoveNVFromKVP(string ma_nv)
        {
            #region Ngach Cu

            foreach (KeyValuePair<string, int> kvp in kvpLuongID)
            {
                if (kvp.Key == ma_nv)
                {
                    kvpLuongID.Remove(kvp);
                    break;
                }
            }

            foreach (KeyValuePair<string, string> kvp in kvpDV)
            {
                if (kvp.Key == ma_nv)
                {
                    kvpDV.Remove(kvp);
                    break;
                }
            }

            foreach (KeyValuePair<string, string> kvp in kvpCV)
            {
                if (kvp.Key == ma_nv)
                {
                    kvpCV.Remove(kvp);
                    break;
                }
            }

            foreach (KeyValuePair<string, string> kvp in kvpNgachCu)
            {
                if (kvp.Key == ma_nv)
                {
                    kvpNgachCu.Remove(kvp);
                    break;
                }
            }

            foreach (KeyValuePair<string, int> kvp in kvpBacCu)
            {
                if (kvp.Key == ma_nv)
                {
                    kvpBacCu.Remove(kvp);
                    break;
                }
            }

            foreach (KeyValuePair<string, double> kvp in kvpHSCu)
            {
                if (kvp.Key == ma_nv)
                {
                    kvpHSCu.Remove(kvp);
                    break;
                }
            }

            foreach (KeyValuePair<string, DateTime> kvp in kvpNgayHuongCu)
            {
                if (kvp.Key == ma_nv)
                {
                    kvpNgayHuongCu.Remove(kvp);
                    break;
                }
            }
            #endregion

            #region Ngach Moi

            foreach (KeyValuePair<string, int> kvp in kvpBacMoi)
            {
                if (kvp.Key == ma_nv)
                {
                    kvpBacMoi.Remove(kvp);
                    break;
                }
            }

            foreach (KeyValuePair<string, double> kvp in kvpHSMoi)
            {
                if (kvp.Key == ma_nv)
                {
                    kvpHSMoi.Remove(kvp);
                    break;
                }
            }

            foreach (KeyValuePair<string, string> kvp in kvpNgachMoi)
            {
                if (kvp.Key == ma_nv)
                {
                    kvpNgachMoi.Remove(kvp);
                    break;
                }
            }

            foreach (KeyValuePair<string, DateTime> kvp in kvpNgayHuongMoi)
            {
                if (kvp.Key == ma_nv)
                {
                    kvpNgayHuongMoi.Remove(kvp);
                    break;
                }
            } 

            #endregion


        }

        void EnableNgachMoi(bool enable)
        {
            comb_BacMoi.Enabled = dtp_NgayBatDau.Enabled = enable;

            thongTinCNVC1.Enabled = lb_DSCNVC.Enabled =  btn_DelNV.Enabled
                = btn_Them.Enabled = btn_NhapFile.Enabled = !enable;

            btn_Del_Luong.Visible = enable;

            if (enable)
            {
                btn_Edit_Luong.ImageKey = "Save.png";
            }
            else
            {
                btn_Edit_Luong.ImageKey = "Edit Data.png";
            }
        }

        private void btn_Edit_Luong_Click(object sender, EventArgs e)
        {
            if (btn_Edit_Luong.ImageKey == "Edit Data.png")
            {
                EnableNgachMoi(true);
            }
            else
            {
                string ten_ma = lb_DSCNVC.SelectedItem.ToString();
                string ma_nv = ten_ma.Substring(ten_ma.IndexOf("-")).Replace("- ", "");

                int bac_id = Convert.ToInt32(comb_BacMoi.SelectedValue);
                DateTime dt = dtp_NgayBatDau.Value;

                if (kvpNgayHuongMoi.Count == 0)
                {
                    kvpNgayHuongMoi.Add(new KeyValuePair<string, DateTime>(ma_nv, dt));
                }
                else
                {
                    for (int i = 0; i < kvpNgayHuongMoi.Count; i++)
                    {
                        if (kvpNgayHuongMoi[i].Key == ma_nv)
                        {
                            kvpNgayHuongMoi[i] = new KeyValuePair<string, DateTime>(ma_nv, dt);
                            break;
                        }

                        if (i + 1 == kvpNgayHuongMoi.Count) // add moi
                        {
                            kvpNgayHuongMoi.Add(new KeyValuePair<string, DateTime>(ma_nv, dt));
                        }
                    }
                }

                if (kvpBacMoi.Count == 0)
                {
                    kvpBacMoi.Add(new KeyValuePair<string, int>(ma_nv, bac_id));
                }
                else
                {
                    for (int i = 0; i < kvpBacMoi.Count; i++)
                    {
                        if (kvpBacMoi[i].Key == ma_nv)
                        {
                            kvpBacMoi[i] = new KeyValuePair<string, int>(ma_nv, bac_id);
                            break;
                        }

                        if (i + 1 == kvpBacMoi.Count) // add moi
                        {
                            kvpBacMoi.Add(new KeyValuePair<string, int>(ma_nv, bac_id));
                        }
                    }
                }

                

                EnableNgachMoi(false);
            }


        }

        private void comb_BacMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int m_id = Convert.ToInt32(comb_BacMoi.SelectedValue.ToString());

                var result = (from c in dtBacHeSo.AsEnumerable()
                              where c.Field<int>("id") == m_id
                              select c.Field<double>("he_so"));

                double m_he_so = result.ElementAt<double>(0);

                txt_HeSoMoi.Text = m_he_so.ToString();
            }
            catch
            {
                txt_HeSoMoi.Text = "";
            }
        }

        private void btn_Del_Luong_Click(object sender, EventArgs e)
        {
            EnableNgachMoi(false);
            comb_BacMoi.Text = txt_BacCu.Text;
            txt_HeSoMoi.Text = txt_HeSoCu.Text;
        }

        bool CheckNgachMoi_NgachCu()
        {
            for (int i = 0; i < kvpBacCu.Count; i++)
            {
                if (kvpBacCu[i].Key == kvpBacMoi[i].Key && kvpBacCu[i].Value == kvpBacMoi[i].Value) // ngach khong thay doi
                {
                    return false;
                }
            }
            return true;

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (btn_Edit_Luong.ImageKey != "Save.png")
            {
                if (thongTinQuyetDinh1.txt_MaQD.Text != "" && thongTinQuyetDinh1.txt_TenQD.Text != "")
                {
                    if (CheckNgachMoi_NgachCu())
                    {
                        if (MessageBox.Show("Bạn thực sự muốn lưu thông tin lương ngạch cho các nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            try
                            {
                                #region Get thong tin luong

                                int n = kvpLuongID.Count;

                                int[] luong_id = new int[n];
                                string[] ma_nv = new string[n];
                                int[] ngach_bac_heso_id = new int[n];
                                DateTime[] tu_ngay_luong = new DateTime[n];

                                for (int i = 0; i < n; i++)
                                {
                                    luong_id[i] = kvpLuongID[i].Value;
                                    ma_nv[i] = lstMaNV[i].ToString();
                                    ngach_bac_heso_id[i] = kvpBacMoi[i].Value;
                                    tu_ngay_luong[i] = kvpNgayHuongMoi[i].Value;
                                }

                                #endregion



                                #region Get thong tin QD

                                string ma_qd = thongTinQuyetDinh1.txt_MaQD.Text;
                                string ten_qd = thongTinQuyetDinh1.txt_TenQD.Text;
                                string mo_ta = thongTinQuyetDinh1.rTB_MoTa.Text;

                                int loai_qd_id = Convert.ToInt32(thongTinQuyetDinh1.comB_Loai.SelectedValue);
                                DateTime tu_ngay_qd = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;

                                DateTime den_ngay_qd;
                                if (thongTinQuyetDinh1.dTP_NgayHetHan.Checked)
                                    den_ngay_qd = thongTinQuyetDinh1.dTP_NgayHetHan.Value;
                                else
                                    den_ngay_qd = Convert.ToDateTime("01/01/1901").Date;

                                DateTime ngay_ky = thongTinQuyetDinh1.dTP_NgayKy.Value;

                                #endregion

                                oTinhLuong.Update_ChuyenNgachNhanh(ma_nv, luong_id, tu_ngay_luong, ngach_bac_heso_id
                                                           , ma_qd, ten_qd, loai_qd_id, tu_ngay_qd, den_ngay_qd, ngay_ky, mo_ta);



                                if (oFile.Path.Count > 0)
                                {
                                    UploadFile();
                                }

                                InitObject_AfterSaving();
                                EnableNgachMoi(false);
                                ClearInterface();

                                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Lưu không thành công, xin vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Có thông tin ngạch chưa được thay đổi, xin vui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin mã / tên quyết định không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Có thông tin lương ngạch chưa được lưu, xin vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearInterface()
        {
            txt_BacCu.Text = txt_CV.Text = txt_DV.Text = txt_HeSoCu.Text =
                   txt_HeSoMoi.Text = txt_NgachCu.Text = thongTinCNVC1.txt_HoTen.Text =
                   thongTinCNVC1.txt_MaNV.Text = thongTinQuyetDinh1.txt_MaQD.Text=
                   thongTinQuyetDinh1.txt_TenQD.Text = thongTinQuyetDinh1.rTB_MoTa.Text="";

            lb_DSCNVC.Items.Clear();
        }



        private void bw_upload_DoWork(object sender, DoWorkEventArgs e)
        {

            for (int i = 0; i < nNewFilesCount; i++)
            {
                bw_upload.ReportProgress(i + 1);

                ServerPaths[i] = oFTP.UploadFile(oFile.Path[i], oFile.Path[i].Split('\\').Last(), oFile.Group[i], thongTinQuyetDinh1.txt_MaQD.Text);
                Thread.Sleep(100);

            }
        }

        private void bw_upload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            pb_Status.Value = e.ProgressPercentage;
            // Set the text.
            lbl_Status.Text = "Đang đăng tập tin ..." + e.ProgressPercentage.ToString() + " / " + nNewFilesCount.ToString();
        }

        private void bw_upload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (oFile.Path.Count > 0)
            {
                MessageBox.Show("Quá trình đăng tập tin lên server thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbl_Status.Text = "Đăng hình hoàn tất!";

                try
                {
                    for (int i = 0; i < oFile.Path.Count; i++)
                    {
                        oFile.Link[i] = thongTinQuyetDinh1.txt_MaQD.Text;
                    }
                    oFile.MaNV = thongTinCNVC1.txt_MaNV.Text;
                    oFile.AddFileArray(ServerPaths);

                }
                catch (Exception)
                {
                    MessageBox.Show("Quá trình lưu tập tin không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ((Form)this.Parent.Parent).ControlBox = true;
                this.Enabled = true;
                oFile.DisputeObject();
            }



        }

        private void UploadFile()
        {
            #region HD

            nNewFilesCount = oFile.Path.Count;
            ServerPaths = new string[nNewFilesCount];
            try
            {

                pb_Status.Value = 0;
                pb_Status.Maximum = nNewFilesCount;

                //this.Enabled = false;
                ((Form)this.Parent.Parent).ControlBox = false;
                this.Enabled = false;
                bw_upload.RunWorkerAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("Quá trình tải hình lên server không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((Form)this.Parent.Parent).ControlBox = true;
                this.Enabled = true;
            }



            #endregion
        }


        private void btn_NhapFile_Click(object sender, EventArgs e)
        {
            UCs.DSTapTin oDSTapTin = new UCs.DSTapTin("ChuyenNgachNhanh", oFile);
            oDSTapTin.txt_MaTapTin.Enabled = false;
            Form f = new Forms.Popup(oDSTapTin, "QUẢN LÝ NHÂN SỰ - DANH SÁCH TẬP TIN");
            f.ShowDialog();
        }


    }
}
