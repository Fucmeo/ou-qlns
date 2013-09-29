using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace QLNS.UCs
{
    public partial class QLNS_TapTin : UserControl
    {
        bool AddFlag;   // xac dinh thao tac add hay edit
        Business.CNVC.CNVC_File oFile;
        Business.CNVC.CNVC oCNVC;
        DataTable dtFileGroup,dtFiles;
        Business.FTP oFTP;
        bool bBinding = true; // dung de tranh fire SelectedChange nhieu lan
        private int nNewFilesCount;
        private string[] ServerPaths;

        public QLNS_TapTin()
        {
            InitializeComponent();
            oCNVC = new Business.CNVC.CNVC();
            oFile = new Business.CNVC.CNVC_File();
            oFTP = new Business.FTP();
            dtFileGroup = new DataTable();
            dtFiles = new DataTable();
        }

        private void rdb_CongThuc_CheckedChanged(object sender, EventArgs e)
        {
            TLP_LoaiTimKiem.RowStyles[0].SizeType = TLP_LoaiTimKiem.RowStyles[1].SizeType = SizeType.Percent;

            if (((RadioButton)sender).Name == "rdb_NV")     // tim theo NV
            {
                TLP_LoaiTimKiem.RowStyles[0].Height = 99;
                TLP_LoaiTimKiem.RowStyles[1].Height = 1;
            }
            else
            {
                TLP_LoaiTimKiem.RowStyles[0].Height = 1;
                TLP_LoaiTimKiem.RowStyles[1].Height = 99;
            }
        }

        private void QLNS_TapTin_Load(object sender, EventArgs e)
        {
            TLP_LoaiTimKiem.RowStyles[0].SizeType = TLP_LoaiTimKiem.RowStyles[1].SizeType = SizeType.Percent;
            TLP_LoaiTimKiem.RowStyles[0].Height = 99;
            TLP_LoaiTimKiem.RowStyles[1].Height = 1;

            ControlInterface(true);

            Load_Bind_Combo();
        }

        private void ControlInterface(bool init)
        {
            btn_Them.Visible = btn_Sua.Visible = btn_Download.Visible = btn_Xoa.Visible = 
                gp_TimKiemInfo.Enabled = dtgv_DSTapTin.Enabled = init;

            gb_ChiTietFile.Enabled = btn_Luu.Visible = btn_Huy.Visible = !init;
            if (init)
            {
                
            }
            else
            {

            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (HDQD.Program.ma_nv != "")
            {
                AddFlag = true;
                oFile = new Business.CNVC.CNVC_File();
                HDQD.UCs.DSTapTin oDSTapTin = new HDQD.UCs.DSTapTin("QLNS_TapTin", oFile);
                oDSTapTin.txt_MaTapTin.Enabled = true;
                Form f = new Forms.Popup("QUẢN LÝ NHÂN SỰ - DANH SÁCH TẬP TIN", oDSTapTin);
                f.ShowDialog();

                if (oFile != null && oFile.Path.Count >0)
                {
                    try
                    {
                        pb_Status.Style = ProgressBarStyle.Blocks;
                        UploadFile();

                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }
            }
            else
            {
                MessageBox.Show("Xin vui lòng tìm và chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ClearAllInfo()
        {
            txt_Ho.Text = txt_MaNV.Text = txt_MaTapTin.Text = txt_MaTapTin_Detail.Text =
                txt_Ten.Text = txt_TenTapTin.Text = "";
            dtgv_DSTapTin.ClearSelection();
        }

        private void ClearDetailInfo()
        {
            txt_MaTapTin_Detail.Text= txt_TenTapTin.Text = rtb_MoTa.Text =  "";
        }


        private void Load_BindDTGV()
        {

        }

        private void Load_Bind_Combo()
        {
            try
            {
                dtFileGroup = oFile.GetFileGroupData();
                DataTable dt = dtFileGroup.Copy();
                DataTable dt2 = dtFileGroup.Copy();

                cb_LoaiTapTin.DataSource = dt;
                cb_LoaiTapTin.DisplayMember = "name";
                cb_LoaiTapTin.ValueMember = "id";

                cb_LoaiTT_Detail.DataSource = dt2;
                cb_LoaiTT_Detail.DisplayMember = "name";
                cb_LoaiTT_Detail.ValueMember = "id";
            }
            catch (Exception)
            {

            }
        }

        private void lbl_ThemLoaiFile_Click(object sender, EventArgs e)
        {
            HDQD.UCs.ThemLoaiFile oThemLoaiFile = new HDQD.UCs.ThemLoaiFile("QLNS_TapTin");
            oThemLoaiFile.Dock = DockStyle.Fill;
            Forms.Popup fPopup = new Forms.Popup("Thêm nhóm tập tin", oThemLoaiFile);
            fPopup.ShowDialog();

            Load_Bind_Combo();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgv_DSTapTin.SelectedRows != null &&
                MessageBox.Show("Bạn muốn xoá các tập tin này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int[] ids = new int[dtgv_DSTapTin.SelectedRows.Count];

                for (int i = 0; i < ids.Count(); i++)
                {
                    ids[i] = Convert.ToInt32(dtgv_DSTapTin.SelectedRows[i].Cells["id"].Value);
                }

                try
                {   
                    oFile.DeleteFile(ids);
                    MessageBox.Show("Xoá tập tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDTFiles();
                }
                catch (Exception)
                {
                    MessageBox.Show("Xoá tập tin không thành công, xin vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_MaNV.Text) || (!string.IsNullOrWhiteSpace(txt_Ho.Text) && !string.IsNullOrWhiteSpace(txt_Ten.Text)))
            {
                oCNVC.Ho = txt_Ho.Text.Trim();
                oCNVC.Ten = txt_Ten.Text.Trim();
                oCNVC.MaNV = string.IsNullOrWhiteSpace(txt_MaNV.Text.Trim()) ? null : txt_MaNV.Text.Trim();
                DataTable dt;

                try
                {
                    dt = oCNVC.SearchDataForQD(true);

                    if (dt != null && dt.Rows.Count > 0)
                    {

                        Forms.Popup frPopup = new Forms.Popup("QUẢN LÝ NHÂN SỰ - DANH SÁCH CNVC", new HDQD.UCs.DSCNVC(dt));
                        frPopup.ShowDialog();
                        Get_BindResult();
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên này khòng còn hợp đồng hoặc không tồn tại trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception)
                {
                    
                }
                
            }
            else
            {
                MessageBox.Show("Xin vui lòng cung cấp mã nhân viên hoặc họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshDTFiles()
        {
            if (rd_TheoLoai.Checked)
            {
                TimTheoLoaiFile();
            }
            else
            {
                Get_BindResult();
            }
        }

        private void Get_BindResult()
        {
            if (HDQD.Program.ma_nv != "")
            {
                oCNVC.MaNV = txt_MaNV.Text = HDQD.Program.ma_nv;
                txt_Ho.Text = HDQD.Program.ho;
                txt_Ten.Text = HDQD.Program.ten;

                oFile.MaNV = oCNVC.MaNV;
                oFile.Link = null;
                oFile.Group = null;
                dtFiles = oFile.GetData();
                if (dtFiles != null && dtFiles.Rows.Count > 0)
                {
                    bBinding = true;
                    dtgv_DSTapTin.DataSource = dtFiles;
                    SetupDTGV();
                    dtgv_DSTapTin.ClearSelection();
                    bBinding = false;
                }
                else
                {
                    dtgv_DSTapTin.DataSource = null;
                }
            }
        }

        private void SetupDTGV()
        {
            // An cac cot
            dtgv_DSTapTin.Columns["id"].Visible = dtgv_DSTapTin.Columns["path"].Visible =
                 dtgv_DSTapTin.Columns["group"].Visible = dtgv_DSTapTin.Columns["exist"].Visible = false;   

            dtgv_DSTapTin.Columns["ma_nv"].HeaderText = "Mã nhân viên";
            dtgv_DSTapTin.Columns["ma_nv"].Width = 150;
            dtgv_DSTapTin.Columns["ho"].HeaderText = "Họ";
            dtgv_DSTapTin.Columns["ho"].Width = 200;
            dtgv_DSTapTin.Columns["ten"].HeaderText = "Tên";
            dtgv_DSTapTin.Columns["ten"].Width = 150;
            dtgv_DSTapTin.Columns["group_name"].HeaderText = "Nhóm tập tin";
            dtgv_DSTapTin.Columns["group_name"].Width = 150;
            dtgv_DSTapTin.Columns["link"].HeaderText = "Mã";
            dtgv_DSTapTin.Columns["link"].Width = 150;
            dtgv_DSTapTin.Columns["file_name"].HeaderText = "Tên tập tin";
            dtgv_DSTapTin.Columns["file_name"].Width = 300;
            dtgv_DSTapTin.Columns["mo_ta"].HeaderText = "Mô tả";
            dtgv_DSTapTin.Columns["mo_ta"].Width = 450;

                  

        }

        private void btn_TimTheoLoaiFile_Click(object sender, EventArgs e)
        {
            TimTheoLoaiFile();
        }

        private void TimTheoLoaiFile()
        {
            oFile = new Business.CNVC.CNVC_File();
            if (string.IsNullOrWhiteSpace(txt_MaTapTin.Text))
                oFile.Link = null;
            else
                oFile.Link.Add(txt_MaTapTin.Text);
            oFile.Group.Add(Convert.ToInt16(cb_LoaiTapTin.SelectedValue));

            try
            {
                dtFiles = oFile.GetData();
                if (dtFiles != null && dtFiles.Rows.Count > 0)
                {
                    bBinding = true;
                    dtgv_DSTapTin.DataSource = dtFiles;
                    SetupDTGV();
                    dtgv_DSTapTin.ClearSelection();
                    bBinding = false;
                }
                else
                {
                    dtgv_DSTapTin.DataSource = null;
                }
            }
            catch (Exception)
            {
            }
        }

        private void dtgv_DSTapTin_SelectionChanged(object sender, EventArgs e)
        {
            if (!bBinding)
            {
                if (dtgv_DSTapTin.SelectedRows != null && dtgv_DSTapTin.SelectedRows.Count == 1)
                {
                    ClearDetailInfo();
                    DataGridViewRow row = dtgv_DSTapTin.SelectedRows[0];
                    cb_LoaiTT_Detail.SelectedValue = row.Cells["group"].Value;
                    txt_MaTapTin_Detail.Text = row.Cells["link"].Value.ToString();
                    txt_TenTapTin.Text = row.Cells["file_name"].Value.ToString();
                    rtb_MoTa.Text = row.Cells["mo_ta"].Value.ToString();
                }
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (dtgv_DSTapTin.SelectedRows != null )
            {
                if ( dtgv_DSTapTin.SelectedRows.Count == 1)
                {
                    AddFlag = false;
                    ControlInterface(false);
                }
                else
                {
                    MessageBox.Show("Xin vui lòng chỉ chọn 1 tập tin để sửa. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (!AddFlag)
            {
                int id = Convert.ToInt32(dtgv_DSTapTin.SelectedRows[0].Cells["id"].Value);
                oFile = new Business.CNVC.CNVC_File();
                oFile.ID = id;
                oFile.Group.Add(Convert.ToInt32(cb_LoaiTT_Detail.SelectedValue));
                oFile.Link.Add(txt_MaTapTin_Detail.Text);
                oFile.FileName.Add(txt_TenTapTin.Text);
                oFile.MoTa.Add(rtb_MoTa.Text);

                try
                {
                    if (oFile.UpdateFile())
                    {
                        MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ControlInterface(true);
                        ClearDetailInfo();
                        dtgv_DSTapTin.ClearSelection();
                        RefreshDTFiles();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Cập nhật không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ClearDetailInfo();
            dtgv_DSTapTin.ClearSelection();
            ControlInterface(true);
        }

        private void bw_upload_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < nNewFilesCount; i++)
            {
                bw_upload.ReportProgress(i + 1);

                ServerPaths[i] = oFTP.UploadFile(oFile.Path[i], oFile.Path[i].Split('\\').Last(), oFile.Group[i], HDQD.Program.ma_nv);
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

                    oFile.MaNV = HDQD.Program.ma_nv;
                    oFile.AddFileArray(ServerPaths);
                    Get_BindResult();
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

        private void btn_Download_Click(object sender, EventArgs e)
        {
            if (dtgv_DSTapTin.SelectedRows != null && dtgv_DSTapTin.SelectedRows.Count >0)
            {
                FBD.ShowDialog();
                if (FBD.SelectedPath != "")
                {
                    pb_Status.Value = 0;
                    pb_Status.Maximum = dtgv_DSTapTin.SelectedRows.Count;
                    pb_Status.Style = ProgressBarStyle.Marquee;
                    lbl_Status.Text = "Đang tải tập tin ...";

                    
                    // Download 
                    try
                    {
                        bw_download.RunWorkerAsync();
                    }
                    catch (Exception )
                    {
                    }

                    
                    
                }
            }
        }

        private void bw_download_DoWork(object sender, DoWorkEventArgs e)
        {
            //bw_download.ReportProgress(1);

            bool bSuccess = true;
            string[] SelectedPaths = new string[dtgv_DSTapTin.SelectedRows.Count];
            string[] DownloadedPaths = new string[dtgv_DSTapTin.SelectedRows.Count];
            for (int i = 0; i < dtgv_DSTapTin.SelectedRows.Count; i++)
            {
                SelectedPaths[i] = dtgv_DSTapTin.SelectedRows[i].Cells["path"].Value.ToString();
            }

            try
            {
                DownloadedPaths = oFTP.DownloadFile(SelectedPaths);
                bSuccess = true;
            }
            catch (Exception)
            {
                bSuccess = false;
                MessageBox.Show("Quá trình tải hình không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (bSuccess)   // neu download thanh cong
            {
                for (int i = 0; i < DownloadedPaths.Count(); i++)
                {
                    string FileName = DownloadedPaths[i].ToString().Split('\\').Last();
                    // Use Path class to manipulate file and directory paths. 
                    //string sourceFile = System.IO.Path.Combine(lsb_DSFile.SelectedItems[i].ToString(), FileName);
                    string destFile = System.IO.Path.Combine(FBD.SelectedPath, FileName);
                    try
                    {
                        File.Copy(DownloadedPaths[i].ToString(), destFile, true);
                    }
                    catch (Exception)
                    {
                        bSuccess = false;
                        MessageBox.Show("Quá trình tải hình không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                if (bSuccess)
                    MessageBox.Show("Quá trình tải hình thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void bw_download_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbl_Status.Text = "Quá trình tải hình hoàn tất!";
            pb_Status.Style = ProgressBarStyle.Blocks;
            pb_Status.Value = pb_Status.Maximum;
        }
    }
}
