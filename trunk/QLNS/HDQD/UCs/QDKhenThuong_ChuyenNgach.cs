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
        bool bAddPC;

		 public QDKhenThuong_ChuyenNgach()
        {
            InitializeComponent();
		}

         private void QDKhenThuong_ChuyenNgach_Load(object sender, EventArgs e)
         {

         }

         void EnableLuongObjects(bool bEnable)
         {
             comb_Luong.Enabled = txt_Tien.Enabled = comb_Ngach.Enabled = comb_Bac.Enabled
                 = txt_HeSo.Enabled = nup_PhanTram.Enabled = dtp_TuNgay_Luong.Enabled = dtp_DenNgay_Luong.Enabled
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
                 = txt_HeSoPC.Enabled = txt_Luong_PC.Enabled
                 = nup_PhanTramPC.Enabled = txt_CongThucPC.Enabled
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
             }
         }

         private void btn_AddPC_Click(object sender, EventArgs e)
         {
             if (btn_AddPC.ImageKey == "Add.png")
             {
                 EnablePCObjects(true);
                 ChangePCButtonImage(false);
                 bAddPC = true;
             }

         }
	}
}