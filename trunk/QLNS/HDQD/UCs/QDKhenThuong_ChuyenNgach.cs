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
    public partial class QDKhenThuong_ChuyenNgach : UserControl
    {
        bool bAddPC; // de phan biet dang add hay edit PC
        bool bLoad_Luong_Complete , bLoad_PC_Complete;
        

        Business.HDQD.LoaiPhuCap oLoaiPC;
        Business.HDQD.LoaiQuyetDinh oLoaiQuyetDinh;
        Business.Luong.TinhLuong oTinhLuong;
        Business.CNVC.CNVC cnvc;
        Business.FTP oFTP;
        public static Business.CNVC.CNVC_File oFile;

        Business.Luong.BacHeSo oBacHeSo;
        DataTable dtBacHeSo;
        DataTable dtLoaiPC;
        DataTable dtPhuCap;
        DataTable dtLuong;


        // KHANG - UPLOAD FILE
        public static DataTable dtFile;
        string[] ServerPaths;
        int nNewFilesCount;         // so file add new
        string[] dbPaths;

		 public QDKhenThuong_ChuyenNgach()
        {
            InitializeComponent();
		}

         private void InitObject()
         {

             oTinhLuong = new Business.Luong.TinhLuong();
             oFTP = new Business.FTP();
             oFile = new Business.CNVC.CNVC_File();
             oBacHeSo = new Business.Luong.BacHeSo();
             dtBacHeSo = new DataTable();
             dtFile = new DataTable();
             oLoaiPC = new Business.HDQD.LoaiPhuCap();
             dtPhuCap = new DataTable();
             dtLoaiPC = new DataTable();
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
                     Clear_Luong_Interface();
                     GetThongTin_Luong();

                     Clear_PC_Interface();
                     GetThongTin_PC();
                 }
             }
         }

         void SetupDTGV_Luong()
         {
             dtgv_Luong.Columns["khoan_or_heso"].HeaderText = "Khoán/Hệ số";
             dtgv_Luong.Columns["luong_khoan"].HeaderText = "Lương khoán";
             dtgv_Luong.Columns["phan_tram_huong"].HeaderText = "Phần trăm hưởng";
             dtgv_Luong.Columns["tu_ngay"].HeaderText = "Từ ngày";
             dtgv_Luong.Columns["den_ngay"].HeaderText = "Đến ngày";
             dtgv_Luong.Columns["ma_tuyen_dung"].HeaderText = "Mã hợp đồng";
             dtgv_Luong.Columns["la_qd_tiep_nhan"].HeaderText = "Là quyết định tiếp nhận";
             dtgv_Luong.Columns["ma_ngach"].HeaderText = "Mã ngạch";
             dtgv_Luong.Columns["bac"].HeaderText = "Bậc";
             dtgv_Luong.Columns["he_so"].HeaderText = "Hệ số";
             dtgv_Luong.Columns["ten_ngach"].HeaderText = "Tên ngạch";
             dtgv_Luong.Columns["loai_hop_dong"].HeaderText = "Loại hợp đồng";


             dtgv_Luong.Columns["ngach_bac_heso_id"].Visible
                 = dtgv_Luong.Columns["tuyen_dung_id"].Visible
                 = dtgv_Luong.Columns["den_ngay_adj_is_null"].Visible
                 = dtgv_Luong.Columns["co_thoi_han"].Visible
                 = dtgv_Luong.Columns["ma_nv"].Visible    
             =false;
         }

         void SetupDTGV_PC()
         {
             dtgv_DSPhuCap.Columns["value_khoan"].HeaderText = "Tiền khoán";
             dtgv_DSPhuCap.Columns["value_he_so"].HeaderText = "Hệ số";
             dtgv_DSPhuCap.Columns["value_phan_tram"].HeaderText = "Phần trăm theo công thức";
             dtgv_DSPhuCap.Columns["phan_tram_huong"].HeaderText = "Phần trăm hưởng";
             dtgv_DSPhuCap.Columns["tu_ngay"].HeaderText = "Từ ngày";
             dtgv_DSPhuCap.Columns["den_ngay"].HeaderText = "Đến ngày";
             dtgv_DSPhuCap.Columns["ghi_chu"].HeaderText = "Ghi chú";
             dtgv_DSPhuCap.Columns["ma_tuyen_dung"].HeaderText = "Mã hợp đồng";
             dtgv_DSPhuCap.Columns["ten_loai"].HeaderText = "Tên loại phụ cấp";
             dtgv_DSPhuCap.Columns["chuoi_cong_thuc_text"].HeaderText = "Công thức";

             dtgv_DSPhuCap.Columns["pc_id"].Visible =
                 dtgv_DSPhuCap.Columns["cnvc_tuyen_dung_id"].Visible =
                 dtgv_DSPhuCap.Columns["loai_pc_id"].Visible =
                 dtgv_DSPhuCap.Columns["la_qd_tiep_nhan"].Visible =
                 dtgv_DSPhuCap.Columns["p_den_ngay_adj_pc_is_null"].Visible =
                  false;
         }

         void GetThongTin_Luong()
         {
             try
             {
                 bLoad_Luong_Complete = false;
                 dtLuong = oTinhLuong.GetThongTinLuong_ByNV(thongTinCNVC1.txt_MaNV.Text);
                 dtgv_Luong.DataSource = dtLuong;
                 dtgv_Luong.ClearSelection();
                 SetupDTGV_Luong();
                 bLoad_Luong_Complete = true;
             }
             catch (Exception)
             {
                 MessageBox.Show("Không thể lấy thông tin lương của nhân viên này, xin vui lòng thử lại sau.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }

         void GetThongTin_PC()
         {
             try
             {
                 bLoad_PC_Complete = false;
                 dtPhuCap = oTinhLuong.GetThongTinPC_ByNV(thongTinCNVC1.txt_MaNV.Text);
                 dtgv_DSPhuCap.DataSource = dtPhuCap;
                 dtgv_DSPhuCap.ClearSelection();
                 SetupDTGV_PC();
                 bLoad_PC_Complete = true;
             }
             catch (Exception)
             {
                 MessageBox.Show("Không thể lấy thông tin phụ cấp của nhân viên này, xin vui lòng thử lại sau.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }

         void LoadCombo_LoaiPC()
         {
             try
             {
                 dtLoaiPC = oLoaiPC.GetList_Cbo();
                 comB_LoaiPhuCap.DataSource = dtLoaiPC;
                 comB_LoaiPhuCap.DisplayMember = "ten_loai";
                 comB_LoaiPhuCap.ValueMember = "id";
             }
             catch (Exception)
             {
                 
             }
         }

         void LoadCombo_NgachBac()
         {
             try
             {
                 dtBacHeSo = oBacHeSo.GetData();
                 if (dtBacHeSo.Rows.Count >0)
                 {


                     DataTable dtMaNgach = dtBacHeSo.DefaultView.ToTable(true, "ma_ngach"); 
                     comb_Ngach.DataSource = dtMaNgach;
                     comb_Ngach.ValueMember = "ma_ngach";
                         comb_Ngach.DisplayMember = "ma_ngach";


                         DataTable dtBac = dtBacHeSo.DefaultView.ToTable(true,new string[2]{ "bac","id"}); 
                     comb_Bac.DataSource = dtBac;
                     comb_Bac.DisplayMember = "bac";
                     comb_Bac.ValueMember = "id";
                 }

             }
             catch (Exception)
             {
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

         private void QDKhenThuong_ChuyenNgach_Load(object sender, EventArgs e)
         {
             InitObject();
             LoadCombo_NgachBac();
             LoadCombo_LoaiPC();
             LoadCombo_LoaiQD();
         }

         void LoadCombo_LoaiQD()
         {
             try
             {
                 DataTable dt = oLoaiQuyetDinh.GetList_Compact();
                 thongTinQuyetDinh1.comB_Loai.DataSource = dt;
                 thongTinQuyetDinh1.comB_Loai.DisplayMember = "ten_loai";
                 thongTinQuyetDinh1.comB_Loai.ValueMember = "id";
             }
             catch (Exception)
             {
                 
             }
             

         }

         void Clear_Luong_Interface()
         {
             txt_Tien.Text = txt_HeSo.Text = "";
             nup_PhanTram.Value = 100;

         }

         void Clear_PC_Interface()
         {
             nup_PhanTramPC.Value = nup_Value_PhanTramPC.Value = 100;
             txt_HeSoPC.Text = txt_TienPC.Text = txt_CongThucPC.Text
                 = rTB_GhiChuPC.Text =  txt_Luong_PC.Text = "";

         }

         void EnableLuongObjects(bool bEnable)
         {
             comb_Luong.Enabled = txt_Tien.Enabled = comb_Ngach.Enabled = comb_Bac.Enabled
                 = nup_PhanTram.Enabled = dtp_TuNgay_Luong.Enabled = dtp_DenNgay_Luong.Enabled
                 = bEnable;

             dtgv_Luong.Enabled = !bEnable;
         }

         void ChangeLuongButtonImage(bool bEnable)
         {

             if (bEnable)
             {
                 btn_Edit_Luong.ImageKey = "Edit Data.png";
                 btn_Del_Luong.ImageKey = "Garbage.png";
             }
             else
             {
                 btn_Edit_Luong.ImageKey = "Save.png";
                 btn_Del_Luong.ImageKey = "Cancel.png";
                 
             }
         }

         void ChangePCButtonImage(bool bEnable)
         {

             if (bEnable)
             {
                 btn_EditPC.ImageKey = "Edit Data.png";
                 btn_DelPC.ImageKey = "Garbage.png";
             }
             else
             {
                 btn_EditPC.ImageKey = "Save.png";
                 btn_DelPC.ImageKey = "Cancel.png";
                 
             }
         }

         void EnablePCObjects(bool bEnable)
         {
             dTP_NgayBatDauPC.Enabled = dTP_NgayHetHanPC.Enabled = nup_PhanTramPC.Enabled
                 = nup_Value_PhanTramPC.Enabled = txt_TienPC.Enabled
                 = nup_PhanTramPC.Enabled
                 = txt_HeSoPC.Enabled 
                 = rTB_GhiChuPC.Enabled = bEnable;

             dtgv_DSPhuCap.Enabled = btn_AddPC.Visible = !bEnable;

             EditInterface_LoaiPC();


         }

         private void cb_ThayDoiLuong_CheckedChanged(object sender, EventArgs e)
         {
             btn_Edit_Luong.Enabled = btn_Del_Luong.Enabled = cb_ThayDoiLuong.Checked;
         }

         private void cb_ThayDoiPC_CheckedChanged(object sender, EventArgs e)
         {

             btn_AddPC.Enabled = btn_EditPC.Enabled = btn_DelPC.Enabled = cb_ThayDoiPC.Checked;

         }

         private void EditInterface_LoaiPC()
         {
             try
             {
                 int id = Convert.ToInt16(comB_LoaiPhuCap.SelectedValue.ToString());
                 int cach_tinh = Convert.ToInt16((from c in dtLoaiPC.AsEnumerable()
                                                  where c.Field<int>("id") == id
                                                  select c.Field<int>("cach_tinh")).ElementAt(0).ToString());

                 string cong_thuc = (from c in dtLoaiPC.AsEnumerable()
                                     where c.Field<int>("id") == id
                                     select c.Field<string>("chuoi_cong_thuc")).ElementAt(0).ToString();
                 switch (cach_tinh)
                 {
                     case 1:
                         txt_TienPC.Enabled = true;
                         txt_HeSoPC.Enabled = false;
                         txt_HeSoPC.Text = "";
                         nup_Value_PhanTramPC.Enabled = false;
                         nup_Value_PhanTramPC.Value = 0;
                         break;
                     case 2:
                         txt_TienPC.Text = "";
                         txt_TienPC.Enabled = false;
                         txt_HeSoPC.Enabled = true;
                         txt_Luong_PC.Text = "Lương cơ bản";
                         nup_Value_PhanTramPC.Enabled = false;
                         nup_Value_PhanTramPC.Value = 0;
                         break;
                     case 3:
                         txt_TienPC.Text = "";
                         txt_TienPC.Enabled = false;
                         txt_HeSoPC.Enabled = true;
                         txt_Luong_PC.Text = "Lương tối thiểu";
                         nup_Value_PhanTramPC.Enabled = false;
                         nup_Value_PhanTramPC.Value = 0;
                         break;
                     case 4:
                         txt_TienPC.Text = "";
                         txt_HeSoPC.Text = "";
                         txt_TienPC.Enabled = false;
                         txt_HeSoPC.Enabled = false;
                         nup_Value_PhanTramPC.Enabled = true;
                         txt_CongThucPC.Text = cong_thuc;
                         break;
                     default:
                         break;
                 }
             }
             catch { }
         }

         private void btn_Edit_Luong_Click(object sender, EventArgs e)
         {
             if (dtgv_Luong.SelectedRows != null && dtgv_Luong.SelectedRows.Count > 0)
             {
                 if (btn_Edit_Luong.ImageKey == "Edit Data.png")
                 {
                     EnableLuongObjects(true);
                     ChangeLuongButtonImage(false);
                 }
                 else // save
                 {
                     if (MessageBox.Show("Bạn thực sự muốn sửa thông tin lương cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                     {
                         try
                         {
                             int id = Convert.ToInt16(dtgv_Luong.SelectedRows[0].Cells["tuyen_dung_id"].Value);

                             DataRow r = dtLuong.Select("tuyen_dung_id = " + id).First();

                             r["khoan_or_heso"] = comb_Luong.Text;
                             if (comb_Luong.Text == "Khoán")
                             {
                                 r["luong_khoan"] = Convert.ToDecimal(txt_Tien.Text);
                                 r["ten_ngach"] = DBNull.Value;
                                 r["bac"] = DBNull.Value;
                                 r["he_so"] = DBNull.Value;
                                 r["ma_ngach"] = DBNull.Value;
                                 r["ngach_bac_heso_id"] = DBNull.Value;
                             }
                             else
                             {
                                 r["luong_khoan"] = DBNull.Value;
                                 r["ten_ngach"] = dtBacHeSo.Select("id = " + comb_Bac.SelectedValue).First()["ten_ngach"];
                                 r["bac"] = comb_Bac.Text;
                                 r["he_so"] = txt_HeSo.Text;
                                 r["ma_ngach"] = comb_Ngach.Text;
                                 r["ngach_bac_heso_id"] = Convert.ToInt32(comb_Bac.SelectedValue);
                             }

                             r["phan_tram_huong"] = nup_PhanTram.Value;
                             r["tu_ngay"] = dtp_TuNgay_Luong.Value;

                             if (dtp_DenNgay_Luong.Checked)
                             {
                                 if (dtp_DenNgay_Luong.Value < dtp_TuNgay_Luong.Value)
                                     throw new ArgumentException();
                                 r["den_ngay"] = dtp_DenNgay_Luong.Value;
                             }
                             else
                                 r["den_ngay"] = DBNull.Value;


                             MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             EnableLuongObjects(false);
                             ChangeLuongButtonImage(true);
                             Clear_Luong_Interface();
                         }
                         catch (ArgumentException)
                         {
                             MessageBox.Show("Thông tin ngày hưởng lương chưa phù hợp, xin vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                         catch (Exception)
                         {
                             MessageBox.Show("Thông tin lương chưa phù hợp, xin vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                     }
                 }
             }
             
         }

         private void btn_Del_Luong_Click(object sender, EventArgs e)
         {
             if (btn_Del_Luong.ImageKey == "Garbage.png")
             {
                 if (dtgv_Luong.SelectedRows != null && dtgv_Luong.SelectedRows.Count > 0
                    && MessageBox.Show("Bạn thực sự muốn xoá thông tin lương cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                     try
                     {
                         int id = Convert.ToInt16(dtgv_Luong.SelectedRows[0].Cells["tuyen_dung_id"].Value);

                         DataRow r = dtLuong.Select("tuyen_dung_id = " + id).First();
                         dtLuong.Rows.Remove(r);
                         Clear_Luong_Interface();


                         MessageBox.Show("Xoá thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     catch (Exception)
                     {
                         MessageBox.Show("Xoá không thành công, xin vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }

             }
             else // cancel
             {
                 EnableLuongObjects(false);
                 ChangeLuongButtonImage(true);
             }
         }

         private void btn_EditPC_Click(object sender, EventArgs e)
         {
             if (btn_EditPC.ImageKey == "Edit Data.png")
             {
                 if (dtgv_DSPhuCap.SelectedRows != null && dtgv_DSPhuCap.SelectedRows.Count > 0)
                 {
                     EnablePCObjects(true);
                     ChangePCButtonImage(false);
                     bAddPC = false;
                 }

             }
             else       // save
             {

                 if (bAddPC) // Add
                 {
                     #region Adding

                     if (MessageBox.Show("Bạn thực sự muốn thêm thông tin phụ cấp cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                     {
                         try
                         {
                             DataRow newrow = dtPhuCap.NewRow();
                             newrow["tu_ngay"] = Convert.ToDateTime(dTP_NgayBatDauPC.Value);
                             if (dTP_NgayHetHanPC.Checked)
                             {
                                 if (dTP_NgayHetHanPC.Value < dTP_NgayBatDauPC.Value)
                                     throw new ArgumentException();

                                 newrow["den_ngay"] = Convert.ToDateTime(dTP_NgayHetHanPC.Value);
                             }
                             else
                                 newrow["den_ngay"] = DBNull.Value;

                             newrow["loai_pc_id"] = comB_LoaiPhuCap.SelectedValue;
                             newrow["ten_loai"] = comB_LoaiPhuCap.Text;
                             newrow["phan_tram_huong"] = nup_PhanTramPC.Value;
                             newrow["ghi_chu"] = rTB_GhiChuPC.Text;
                             newrow["p_den_ngay_adj_pc_is_null"] = false;

                             int id = Convert.ToInt16(comB_LoaiPhuCap.SelectedValue.ToString());

                             int cach_tinh = Convert.ToInt16((from c in dtLoaiPC.AsEnumerable()
                                                              where c.Field<int>("id") == id
                                                              select c.Field<int>("cach_tinh")).ElementAt(0).ToString());

                             switch (cach_tinh)
                             {
                                 case 1:
                                     newrow["value_khoan"] = Convert.ToDecimal(txt_TienPC.Text);
                                     newrow["value_he_so"] = DBNull.Value;
                                     newrow["value_phan_tram"] = DBNull.Value;
                                     break;
                                 case 2:
                                     newrow["value_khoan"] = DBNull.Value;
                                     newrow["value_he_so"] = (txt_HeSoPC.Text);
                                     newrow["value_phan_tram"] = DBNull.Value;
                                     break;
                                 case 3:
                                     newrow["value_khoan"] = DBNull.Value;
                                     newrow["value_he_so"] = (txt_HeSoPC.Text);
                                     newrow["value_phan_tram"] = DBNull.Value;
                                     break;
                                 case 4:
                                     newrow["value_khoan"] = DBNull.Value;
                                     newrow["value_he_so"] = DBNull.Value;
                                     newrow["value_phan_tram"] = nup_Value_PhanTramPC.Value;
                                     break;
                                 default:
                                     break;
                             }

                             dtPhuCap.Rows.Add(newrow);

                             MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             
                             ChangePCButtonImage(true);
                             comB_LoaiPhuCap.Enabled = false;
                             EnablePCObjects(false);

                             txt_TienPC.Enabled = txt_HeSoPC.Enabled = nup_Value_PhanTramPC.Enabled = false;


                         }
                         catch (ArgumentException)
                         {
                             MessageBox.Show("Thông tin ngày hưởng phụ cấp chưa phù hợp, xin vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                         catch (Exception)
                         {
                             MessageBox.Show("Thông tin phụ cấp  chưa phù hợp, xin vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                     }
                     #endregion

                 }
                 else // Edit
                 {
                     #region Edit
                     if (MessageBox.Show("Bạn thực sự muốn sửa thông tin phụ cấp cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                     {
                         try
                         {
                             int id = Convert.ToInt16(dtgv_DSPhuCap.SelectedRows[0].Cells["pc_id"].Value);

                             DataRow r = dtPhuCap.Select("pc_id = " + id).First();
                             r["tu_ngay"] = Convert.ToDateTime(dTP_NgayBatDauPC.Value);
                             if (dTP_NgayHetHanPC.Checked)
                             {
                                 if (dTP_NgayHetHanPC.Value < dTP_NgayBatDauPC.Value)
                                     throw new ArgumentException();

                                 r["den_ngay"] = Convert.ToDateTime(dTP_NgayHetHanPC.Value);
                             }
                             else
                                 r["den_ngay"] = DBNull.Value;

                             r["loai_pc_id"] = comB_LoaiPhuCap.SelectedValue;
                             r["ten_loai"] = comB_LoaiPhuCap.Text;
                             r["phan_tram_huong"] = nup_PhanTramPC.Value;
                             r["ghi_chu"] = rTB_GhiChuPC.Text;
                             r["p_den_ngay_adj_pc_is_null"] = false;

                             int loai_pc_id = Convert.ToInt16(comB_LoaiPhuCap.SelectedValue.ToString());

                             int cach_tinh = Convert.ToInt16((from c in dtLoaiPC.AsEnumerable()
                                                              where c.Field<int>("id") == loai_pc_id
                                                              select c.Field<int>("cach_tinh")).ElementAt(0).ToString());

                             switch (cach_tinh)
                             {
                                 case 1:
                                     r["value_khoan"] = Convert.ToDecimal(txt_TienPC.Text);
                                     r["value_he_so"] = DBNull.Value;
                                     r["value_phan_tram"] = DBNull.Value;
                                     break;
                                 case 2:
                                     r["value_khoan"] = DBNull.Value;
                                     r["value_he_so"] = (txt_HeSoPC.Text);
                                     r["value_phan_tram"] = DBNull.Value;
                                     break;
                                 case 3:
                                     r["value_khoan"] = DBNull.Value;
                                     r["value_he_so"] = (txt_HeSoPC.Text);
                                     r["value_phan_tram"] = DBNull.Value;
                                     break;
                                 case 4:
                                     r["value_khoan"] = DBNull.Value;
                                     r["value_he_so"] = DBNull.Value;
                                     r["value_phan_tram"] = nup_Value_PhanTramPC.Value;
                                     break;
                                 default:
                                     break;
                             }

                             MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             EnablePCObjects(false);
                             ChangePCButtonImage(true);

                             txt_TienPC.Enabled = txt_HeSoPC.Enabled = nup_Value_PhanTramPC.Enabled = false;
                         }
                         catch (ArgumentException)
                         {
                             MessageBox.Show("Thông tin ngày hưởng phụ cấp chưa phù hợp, xin vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                         catch (Exception)
                         {
                             MessageBox.Show("Thông tin phụ cấp  chưa phù hợp, xin vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                     }
                     #endregion
                 }


             }
           
         }

         private void btn_DelPC_Click(object sender, EventArgs e)
         {
             if (btn_DelPC.ImageKey == "Garbage.png")
             {
                 if (dtgv_DSPhuCap.SelectedRows != null && dtgv_DSPhuCap.SelectedRows.Count > 0
                    && MessageBox.Show("Bạn thực sự muốn xoá thông tin  phụ cấp cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                     try
                     {
                         int id = Convert.ToInt16(dtgv_DSPhuCap.SelectedRows[0].Cells["pc_id"].Value);

                         DataRow r = dtPhuCap.Select("pc_id = " + id).First();
                         dtPhuCap.Rows.Remove(r);
                         Clear_PC_Interface();

                         MessageBox.Show("Xoá thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     catch (Exception)
                     {
                         MessageBox.Show("Xoá không thành công, xin vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }

             }
             else // cancel
             {

                 EnablePCObjects(false);
                 ChangePCButtonImage(true);
                 comB_LoaiPhuCap.Enabled = false;

                 txt_TienPC.Enabled = txt_HeSoPC.Enabled = nup_Value_PhanTramPC.Enabled = false;
             }
         }

         private void btn_AddPC_Click(object sender, EventArgs e)
         {
             if (btn_AddPC.ImageKey == "Add.png")
             {
                 EnablePCObjects(true);
                 ChangePCButtonImage(false);
                 bAddPC = true;

                 comB_LoaiPhuCap.Enabled = true;
                 Clear_PC_Interface();
             }

         }

         private void txt_Tien_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
             {
                 e.Handled = true;
             }
         }

         private void txt_Tien_KeyUp(object sender, KeyEventArgs e)
         {
             TextBox txt = (TextBox)sender;

             if (!string.IsNullOrWhiteSpace(txt.Text) &&
                e.KeyCode != Keys.Left && e.KeyCode != Keys.Right &&
                e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
             {
                 txt.Text = Convert.ToDouble(txt.Text.Replace(",", "")).ToString("#,#");
                 txt.SelectionStart = txt.TextLength;
             }
         }

         private void dtgv_Luong_CellClick(object sender, DataGridViewCellEventArgs e)
         {
             if (bLoad_Luong_Complete)
             {
                 if (dtgv_Luong.SelectedRows != null && dtgv_Luong.SelectedRows.Count >0)
                 {
                     DataGridViewRow r =  dtgv_Luong.SelectedRows[0];

                     comb_Luong.Text = r.Cells["khoan_or_heso"].Value.ToString();
                     txt_Tien.Text = r.Cells["luong_khoan"].Value.ToString();
                     comb_Ngach.Text = r.Cells["ma_ngach"].Value.ToString();
                     comb_Bac.Text = r.Cells["bac"].Value.ToString();
                     txt_HeSo.Text = r.Cells["he_so"].Value.ToString();
                     nup_PhanTram.Value = Convert.ToInt16(r.Cells["phan_tram_huong"].Value);
                     dtp_TuNgay_Luong.Value = Convert.ToDateTime(r.Cells["tu_ngay"].Value);

                     if (r.Cells["den_ngay"].Value.ToString() != "")
                     {
                         dtp_DenNgay_Luong.Checked = true;
                         dtp_DenNgay_Luong.Value = Convert.ToDateTime(r.Cells["den_ngay"].Value);
                     }
                     else
                     {
                         dtp_DenNgay_Luong.Checked = false;
                     }
                 }
             }
         }

         private void dtgv_DSPhuCap_CellClick(object sender, DataGridViewCellEventArgs e)
         {
             if (bLoad_PC_Complete)
             {
                 try
                 {
                     if (dtgv_DSPhuCap.SelectedRows != null && dtgv_DSPhuCap.SelectedRows.Count > 0)
                     {
                         DataGridViewRow r = dtgv_DSPhuCap.SelectedRows[0];

                         txt_Luong_PC.Text = ""; // set o comB_LoaiPhuCap index changed
                         comB_LoaiPhuCap.Text = r.Cells["ten_loai"].Value.ToString();
                         
                         txt_CongThucPC.Text = r.Cells["chuoi_cong_thuc_text"].Value.ToString();
                         txt_TienPC.Text = r.Cells["value_khoan"].Value.ToString();
                         txt_HeSoPC.Text = r.Cells["value_he_so"].Value.ToString();
                         if (txt_TienPC.Text != "")
                             txt_TienPC.Text = Convert.ToDouble(txt_TienPC.Text.Replace(",", "")).ToString("#,#");

                         rTB_GhiChuPC.Text = r.Cells["ghi_chu"].Value.ToString();

                         if (r.Cells["phan_tram_huong"].Value != DBNull.Value)
                         {
                             nup_PhanTramPC.Value = Convert.ToDecimal(r.Cells["phan_tram_huong"].Value);
                         }
                         else
                         {
                             nup_PhanTramPC.Value = 0;
                         }

                         if (r.Cells["value_phan_tram"].Value != DBNull.Value)
                         {
                             nup_Value_PhanTramPC.Value = Convert.ToDecimal(r.Cells["value_phan_tram"].Value);
                         }
                         else
                         {
                             nup_Value_PhanTramPC.Value = 0;
                         }


                         dTP_NgayBatDauPC.Value = Convert.ToDateTime(r.Cells["tu_ngay"].Value);

                         if (r.Cells["den_ngay"].Value.ToString() != "")
                         {
                             dTP_NgayHetHanPC.Checked = true;
                             dTP_NgayHetHanPC.Value = Convert.ToDateTime(r.Cells["den_ngay"].Value);
                         }
                         else
                         {
                             dTP_NgayHetHanPC.Checked = false;
                         }
                     }
                 }
                 catch (Exception)
                 {
                    
                 }
                 
             }
         }

         private void comb_Ngach_SelectedIndexChanged(object sender, EventArgs e)
         {
             string m_ma_ngach = comb_Ngach.SelectedValue.ToString();
             DateTime m_tu_ngay_select = dtp_TuNgay_Luong.Value;
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

                 comb_Bac.DataSource = dt;
                 comb_Bac.DisplayMember = "bac";
                 comb_Bac.ValueMember = "id";

                 if (result.Count == 0)
                 {
                     txt_HeSo.Text = "";
                 }

             }
             catch
             { }
         }

         private void comb_Bac_SelectedIndexChanged(object sender, EventArgs e)
         {
             try
             {
                 int m_id = Convert.ToInt32(comb_Bac.SelectedValue.ToString());

                 var result = (from c in dtBacHeSo.AsEnumerable()
                               where c.Field<int>("id") == m_id
                               select c.Field<double>("he_so"));

                 double m_he_so = result.ElementAt<double>(0);

                 txt_HeSo.Text = m_he_so.ToString();
             }
             catch
             {
                 txt_HeSo.Text = "";
             }
         }

         private void comb_Luong_SelectionChangeCommitted(object sender, EventArgs e)
         {
             if (comb_Luong.Text == "Khoán")
             {
                 txt_Tien.Enabled = true;
                 comb_Bac.Enabled = comb_Ngach.Enabled = false;

             }
             else
             {
                 txt_Tien.Text = "";
                 txt_Tien.Enabled = false;
                 comb_Bac.Enabled = comb_Ngach.Enabled = true;
             }
         }

         private void comB_LoaiPhuCap_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (comB_LoaiPhuCap.Enabled)
             {
                 EditInterface_LoaiPC();
                 
             }
         }

         void ClearAllInterface()
         {
             thongTinCNVC1.txt_MaNV.Text = thongTinCNVC1.txt_HoTen.Text  = "";

             thongTinQuyetDinh1.txt_MaQD.Text = thongTinQuyetDinh1.txt_TenQD.Text = thongTinQuyetDinh1.rTB_MoTa.Text = "";
             thongTinQuyetDinh1.dTP_NgayHetHan.Checked = false;

             dtgv_DSPhuCap.DataSource = null;
             dtgv_Luong.DataSource = null;
             Clear_Luong_Interface();
             Clear_PC_Interface();
             dtLuong = new DataTable();
             dtPhuCap = new DataTable();
         }

         private void btn_Them_Click(object sender, EventArgs e)
         {
             if (btn_Edit_Luong.ImageKey != "Save.png" && btn_EditPC.ImageKey != "Save.png")
             {
                 if (thongTinQuyetDinh1.txt_MaQD.Text != "" && thongTinQuyetDinh1.txt_TenQD.Text != "")
                 {
                     if (MessageBox.Show("Bạn thực sự muốn lưu thông tin lương và phụ cấp cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                     {
                         
                         try
                         {
                             #region Get thong tin luong

                             int Luong_Rows = dtLuong.Rows.Count;

                             string[] khoan_or_heso = new string[Luong_Rows];
                             string[] luong_khoan = new string[Luong_Rows];
                             string[] phan_tram_huong = new string[Luong_Rows];
                             DateTime[] tu_ngay = new DateTime[Luong_Rows];
                             DateTime[] den_ngay = new DateTime[Luong_Rows];
                             int[] tuyen_dung_id = new int[Luong_Rows];
                             string[] ngach_bac_heso_id = new string[Luong_Rows];
                             bool[] den_ngay_adj_is_null = new bool[Luong_Rows];
                             string ma_nv = thongTinCNVC1.txt_MaNV.Text;

                             for (int i = 0; i < Luong_Rows; i++)
                             {
                                 DataRow r = dtLuong.Rows[i];

                                 khoan_or_heso[i] = r["khoan_or_heso"].ToString();
                                 if (r["luong_khoan"].ToString() != "")
                                     luong_khoan[i] = Convert.ToString(r["luong_khoan"]);
                                 else
                                     luong_khoan[i] = null;

                                 phan_tram_huong[i] = r["phan_tram_huong"].ToString();
                                 tu_ngay[i] = Convert.ToDateTime(r["tu_ngay"].ToString()).Date;

                                 if (r["den_ngay"].ToString() != "")
                                     den_ngay[i] = Convert.ToDateTime(r["den_ngay"].ToString()).Date;
                                 else
                                     den_ngay[i] = Convert.ToDateTime("01/01/1901").Date;

                                 tuyen_dung_id[i] = Convert.ToInt32(r["tuyen_dung_id"]);
                                 if (r["ngach_bac_heso_id"] != DBNull.Value)
                                 {
                                     ngach_bac_heso_id[i] = Convert.ToString(r["ngach_bac_heso_id"]);
                                 }
                                 else
                                 {
                                     ngach_bac_heso_id[i] = null;
                                 }
                                 
                                 den_ngay_adj_is_null[i] = Convert.ToBoolean(r["den_ngay_adj_is_null"]);
                             }

                             #endregion

                             #region Get thong tin pc

                             int PC_Rows = dtPhuCap.Rows.Count;

                             string[] value_khoan = new string[PC_Rows];
                             string[] value_he_so = new string[PC_Rows];
                             string[] value_phan_tram = new string[PC_Rows];
                             string[] phan_tram_huong_pc = new string[PC_Rows];
                             DateTime[] tu_ngay_pc = new DateTime[PC_Rows];
                             DateTime[] den_ngay_pc = new DateTime[PC_Rows];
                             string[] ghi_chu = new string[PC_Rows];
                             int[] pc_id = new int[PC_Rows];
                             int[] cnvc_tuyen_dung_id = new int[PC_Rows];
                             int[] loai_pc_id = new int[PC_Rows];
                             bool[] p_den_ngay_adj_pc_is_null = new bool[PC_Rows];

                             for (int i = 0; i < PC_Rows; i++)
                             {
                                 DataRow r = dtPhuCap.Rows[i];

                                 if (r["value_khoan"].ToString() != "")
                                     value_khoan[i] = Convert.ToString(r["value_khoan"]);
                                 else
                                     value_khoan[i] = null;

                                 if (r["value_he_so"].ToString() != "")
                                     value_he_so[i] = Convert.ToString(r["value_he_so"]);
                                 else
                                     value_he_so[i] = null;

                                 if (r["value_phan_tram"].ToString() != "")
                                     value_phan_tram[i] = Convert.ToString(r["value_phan_tram"]);
                                 else
                                     value_phan_tram[i] = null;

                                 if (r["phan_tram_huong"].ToString() != "")
                                     phan_tram_huong_pc[i] = Convert.ToString(r["phan_tram_huong"]);
                                 else
                                     phan_tram_huong_pc[i] = null;


                                 tu_ngay_pc[i] = Convert.ToDateTime(r["tu_ngay"].ToString()).Date;
                                 if (r["den_ngay"].ToString() != "")
                                     den_ngay_pc[i] = Convert.ToDateTime(r["den_ngay"].ToString()).Date;
                                 else
                                     den_ngay_pc[i] = Convert.ToDateTime("01/01/1901").Date;

                                 ghi_chu[i] = r["ghi_chu"].ToString();

                                 loai_pc_id[i] = Convert.ToInt32(r["loai_pc_id"]);
                                 pc_id[i] = Convert.ToInt32(r["pc_id"]);
                                 cnvc_tuyen_dung_id[i] = Convert.ToInt32(r["cnvc_tuyen_dung_id"]);
                                 p_den_ngay_adj_pc_is_null[i] = Convert.ToBoolean(r["p_den_ngay_adj_pc_is_null"]);
                             }

                             #endregion

                             #region Get thong tin QD

                             string ma_qd = thongTinQuyetDinh1.txt_MaQD.Text;
                             string ten_qd = thongTinQuyetDinh1.txt_TenQD.Text;
                             string mo_ta = thongTinQuyetDinh1.rTB_MoTa.Text;

                             int loai_qd_id = Convert.ToInt32(thongTinQuyetDinh1.comB_Loai.SelectedValue);
                             DateTime tu_ngay_qd = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;

                             DateTime den_ngay_qd;
                             if(thongTinQuyetDinh1.dTP_NgayHetHan.Checked)
                                  den_ngay_qd =thongTinQuyetDinh1.dTP_NgayHetHan.Value;
                             else
                                  den_ngay_qd = Convert.ToDateTime("01/01/1901").Date;

                             DateTime ngay_ky = thongTinQuyetDinh1.dTP_NgayKy.Value;

                             #endregion

                             oTinhLuong.UpdateLuong_PC(ma_nv, tuyen_dung_id, khoan_or_heso, luong_khoan, ngach_bac_heso_id, phan_tram_huong
                                                        , tu_ngay, den_ngay, den_ngay_adj_is_null, pc_id, cnvc_tuyen_dung_id
                                                        , value_khoan, value_he_so, value_phan_tram, phan_tram_huong_pc
                                                        , loai_pc_id, tu_ngay_pc, den_ngay_pc, p_den_ngay_adj_pc_is_null, ghi_chu
                                                        ,ma_qd,ten_qd,loai_qd_id,tu_ngay_qd,den_ngay_qd,ngay_ky,mo_ta);



                             if (oFile.Path.Count > 0 )
                             {
                                 UploadFile();
                             }

                             ClearAllInterface();

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
                     MessageBox.Show("Thông tin mã / tên quyết định không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 }
             }
             else
             {
                 MessageBox.Show("Có thông tin lương / phụ cấp chưa được lưu, xin vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
             
         }

         private void btn_NhapFile_Click(object sender, EventArgs e)
         {
             UCs.DSTapTin oDSTapTin = new UCs.DSTapTin("QDKhenThuong_ChuyenNgach", oFile);
             oDSTapTin.txt_MaTapTin.Enabled = false;
             Form f = new Forms.Popup(oDSTapTin, "QUẢN LÝ NHÂN SỰ - DANH SÁCH TẬP TIN");
             f.ShowDialog();
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

	}
}