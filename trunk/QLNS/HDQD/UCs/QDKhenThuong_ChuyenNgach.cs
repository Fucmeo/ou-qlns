using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;

namespace HDQD.UCs
{
    public partial class QDKhenThuong_ChuyenNgach : UserControl
    {
        bool bAddPC; // de phan biet dang add hay edit PC
        bool bLoad_Luong_Complete , bLoad_PC_Complete;
        

        Business.HDQD.LoaiPhuCap oLoaiPC;
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

         }

         void SetupDTGV_PC()
         {

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
                 bLoad_PC_Complete = false;
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
                     DataTable dtMaNgach = dtBacHeSo.Columns["ma_ngach"].Table;
                     comb_Ngach.DataSource = dtMaNgach;
                     comb_Ngach.ValueMember = "ma_ngach";
                         comb_Ngach.DisplayMember = "ma_ngach";


                     DataTable dtBac = dtBacHeSo.Columns["bac"].Table;
                     comb_Bac.DataSource = dtBac;
                     comb_Bac.DisplayMember = "bac";
                     comb_Bac.ValueMember = "bac";
                 }

             }
             catch (Exception)
             {
             }
             
         }

         private void QDKhenThuong_ChuyenNgach_Load(object sender, EventArgs e)
         {
             InitObject();
             LoadCombo_NgachBac();
             LoadCombo_LoaiPC();
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
                 = rTB_GhiChuPC.Enabled = bEnable;

             dtgv_DSPhuCap.Enabled = btn_AddPC.Visible = !bEnable;


         }

         private void cb_ThayDoiLuong_CheckedChanged(object sender, EventArgs e)
         {
             btn_Edit_Luong.Enabled = btn_Del_Luong.Enabled = cb_ThayDoiLuong.Checked;
         }

         private void cb_ThayDoiPC_CheckedChanged(object sender, EventArgs e)
         {

             btn_AddPC.Enabled = btn_EditPC.Enabled = btn_DelPC.Enabled = cb_ThayDoiPC.Checked;

         }

         private void btn_Edit_Luong_Click(object sender, EventArgs e)
         {
             if (btn_Edit_Luong.ImageKey == "Edit Data.png")
             {
                 EnableLuongObjects(true);
                 ChangeLuongButtonImage(false);
             }
             else // save
             {
                 if (dtgv_Luong.SelectedRows != null && dtgv_Luong.SelectedRows.Count > 0
                    && MessageBox.Show("Bạn thực sự muốn sửa thông tin lương cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {

                     try
                     {
                         
                         
                         MessageBox.Show("Thêm thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         EnableLuongObjects(false);
                         ChangeLuongButtonImage(true);
                     }
                     catch (Exception)
                     {
                         MessageBox.Show("Thông tin lương chưa phù hợp, xin vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                 EnablePCObjects(true);
                 ChangePCButtonImage(false);
                 bAddPC = false;
             }
             else       // save
             {
                 if (dtgv_DSPhuCap.SelectedRows != null && dtgv_DSPhuCap.SelectedRows.Count > 0)
                 {
                     if (bAddPC) // Add
                     {

                         if (MessageBox.Show("Bạn thực sự muốn thêm thông tin phụ cấp cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                         {
                             try
                             {


                                 MessageBox.Show("Thêm thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 EnablePCObjects(false);
                                 ChangePCButtonImage(true);
                                 comB_LoaiPhuCap.Enabled = false;
                             }
                             catch (Exception)
                             {
                                 MessageBox.Show("Thông tin phụ cấp  chưa phù hợp, xin vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             }
                         }

                     }
                     else // Edit
                     {
                         if (MessageBox.Show("Bạn thực sự muốn sửa thông tin phụ cấp cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                         {
                             try
                             {


                                 MessageBox.Show("Sửa thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 EnablePCObjects(false);
                                 ChangePCButtonImage(true);
                             }
                             catch (Exception)
                             {
                                 MessageBox.Show("Thông tin phụ cấp  chưa phù hợp, xin vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             }
                         }
                     }


                     
                 }
                 
             }
             

         }

         private void btn_DelPC_Click(object sender, EventArgs e)
         {
             if (btn_DelPC.ImageKey == "Garbage.png")
             {
                 if (dtgv_Luong.SelectedRows != null && dtgv_Luong.SelectedRows.Count > 0
                    && MessageBox.Show("Bạn thực sự muốn xoá thông tin  phụ cấp cho nhân viên này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                     try
                     {


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
                 //txt_Tien.Text = Convert.ToDouble(txt_Tien.Text).ToString("#,#", CultureInfo.InvariantCulture);
                 txt.Text = Convert.ToDouble(txt.Text.Replace(",", "")).ToString("#,#");
                 txt.SelectionStart = txt.TextLength;
             }
         }
	}
}