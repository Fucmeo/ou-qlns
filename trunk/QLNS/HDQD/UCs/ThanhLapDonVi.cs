using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;
using System.Threading;

namespace HDQD.UCs
{
    public partial class ThanhLapDonVi : UserControl
    {
        Business.DonVi oDonvi;
        DataTable dtDonVi;
        List<Business.DonVi> dsDonVi_new;
        bool bAddFlag ;

        #region FILE Variables
        Business.FTP oFTP;
        public Business.HDQD.QD_File oFile;

        public static List<KeyValuePair<string, bool?>> Paths;

        public static string Desc;
        public static DataTable dtFile;
        string[] ServerPaths;
        int nNewFilesCount;         // so file add new
        string[] dbPaths;

        #endregion
        public ThanhLapDonVi()
        {
            InitializeComponent();
            oDonvi = new DonVi();
            dtDonVi = new DataTable();
            dsDonVi_new = new List<DonVi>();

            oFTP = new Business.FTP();
            oFile = new Business.HDQD.QD_File();
            dtFile = new DataTable();
            Paths = new List<KeyValuePair<string, bool?>>();
        }

        private void ThanhLapDonVi_Load(object sender, EventArgs e)
        {
            PrepareSourceLoaiQuyetDinh();
            PreapreDataSource();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            bAddFlag = true;
        }

        private void btn_LuuThongTin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_TenDV.Text) && dTP_NgayHieuLuc.Checked)
            {
                if (bAddFlag)
                {
                    DonVi dv = new DonVi();
                    dv.TenDonVi = txt_TenDV.Text;
                    dv.TenDVVietTat = txt_TenDVTat.Text;
                    if (comb_DVTrucThuoc.Text != "")
                        dv.DVChaID = Convert.ToInt16(comb_DVTrucThuoc.SelectedValue);
                    else
                        dv.DVChaID = null;

                    dv.TuNgay = dTP_NgayHieuLuc.Value;
                    dv.GhiChu = rTB_GhiChu.Text;

                    int i = lstb_DSDV.Items.Count;
                    dsDonVi_new.Insert(i, dv);

                    lstb_DSDV.Items.Add(txt_TenDV.Text);
                }
                else
                {
                    DonVi dv = dsDonVi_new[lstb_DSDV.SelectedIndex];
                    dv.TenDonVi = txt_TenDV.Text.Trim();
                    dv.TenDVVietTat = txt_TenDVTat.Text;
                    dv.TuNgay = dTP_NgayHieuLuc.Value;
                    dv.GhiChu = rTB_GhiChu.Text;
                    if (comb_DVTrucThuoc.Text != "")
                        dv.DVChaID = Convert.ToInt16(comb_DVTrucThuoc.SelectedValue);
                    else
                        dv.DVChaID = null;

                    dsDonVi_new[lstb_DSDV.SelectedIndex] = dv;
                    lstb_DSDV.Items[lstb_DSDV.SelectedIndex] = dv.TenDonVi;
                }
                

                EnableControls(true);
            }
            else
            {
                MessageBox.Show("Tên đơn vị và ngày hiệu lực không được bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_HuyThongTin_Click(object sender, EventArgs e)
        {
            EnableControls(true);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            int index = lstb_DSDV.SelectedIndex;
            if (index != -1)
            {
                dsDonVi_new.RemoveAt(index);
                lstb_DSDV.Items.RemoveAt(index);
                txt_TenDV.Text = txt_TenDVTat.Text = rTB_GhiChu.Text = "";
                dTP_NgayHieuLuc.Checked = false;
                comb_DVTrucThuoc.SelectedIndex = 0;
            }
            
        }

        private void btn_Nhap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn nhập quyết định này hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (VerifyData())
                {
                    bool bUploadInfoSuccess = false;

                    Business.HDQD.QuyetDinh quyetdinh = new Business.HDQD.QuyetDinh();
                    quyetdinh.Ma_Quyet_Dinh = thongTinQuyetDinh1.txt_MaQD.Text;
                    quyetdinh.Ten_Quyet_Dinh = thongTinQuyetDinh1.txt_TenQD.Text;
                    quyetdinh.Loai_QuyetDinh_ID = Convert.ToInt16(thongTinQuyetDinh1.comB_Loai.SelectedValue);
                    quyetdinh.Ngay_Ky = thongTinQuyetDinh1.dTP_NgayKy.Value;
                    quyetdinh.Ngay_Hieu_Luc = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;
                    if (thongTinQuyetDinh1.dTP_NgayHetHan.Checked == true)
                        quyetdinh.Ngay_Het_Han = thongTinQuyetDinh1.dTP_NgayHetHan.Value;
                    else
                        quyetdinh.Ngay_Het_Han = null;
                    quyetdinh.MoTa = thongTinQuyetDinh1.rTB_MoTa.Text;

                    try
                    {
                        int count = dsDonVi_new.Count;
                        string[] ten_don_vi_moi = new string[count];
                        string[] ten_dv_viet_tat = new string[count];
                        int[] dv_cha_id = new int[count];
                        DateTime[] tu_ngay = new DateTime[count];
                        string[] ghi_chu = new string[count];

                        for (int i = 0; i < dsDonVi_new.Count; i++)
                        {
                            DonVi dv = new DonVi();
                            dv = dsDonVi_new[i];

                            ten_don_vi_moi[i] = dv.TenDonVi;
                            ten_dv_viet_tat[i] = dv.TenDVVietTat;
                            if (dv.DVChaID != null)
                                dv_cha_id[i] = dv.DVChaID.Value;
                            else
                                dv_cha_id[i] = 0;
                            tu_ngay[i] = dv.TuNgay.Value;
                        }

                        quyetdinh.Add_ThanhLapDV(ten_don_vi_moi, ten_dv_viet_tat, dv_cha_id, ghi_chu, tu_ngay);
                        MessageBox.Show("Thành lập đơn vị thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EnableControls(true);
                        bUploadInfoSuccess = true;
                        
                        if (Paths != null && Paths.Count > 0 && bUploadInfoSuccess)
                        {
                            UploadFile();
                        }
                        else
                        {
                            CleanUIData();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thành lập đơn vị không thành công.\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin của quyết định.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void CleanUIData()
        {
            lstb_DSDV.Items.Clear();
            dsDonVi_new.Clear();
            thongTinQuyetDinh1.txt_TenQD.Text = thongTinQuyetDinh1.txt_MaQD.Text = "";

            txt_TenDV.Text = txt_TenDVTat.Text = rTB_GhiChu.Text = "";
            dTP_NgayHieuLuc.Checked = false;
            comb_DVTrucThuoc.SelectedIndex = 0;

        }

        private bool VerifyData()
        {
            if (string.IsNullOrWhiteSpace(thongTinQuyetDinh1.txt_MaQD.Text) || string.IsNullOrWhiteSpace(thongTinQuyetDinh1.txt_TenQD.Text))
                return false;

            if (lstb_DSDV.Items.Count == 0)
            {
                return false;
            }

            return true;
        }

        private void PrepareSourceLoaiQuyetDinh()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("loai_quyet_dinh_id", typeof(int));
            dt.Columns.Add("ten_loai_quyet_dinh", typeof(string));

            dt.Rows.Add(new object[2] { 5, "Thành lập đơn vị" });


            thongTinQuyetDinh1.comB_Loai.DataSource = dt;
            thongTinQuyetDinh1.comB_Loai.DisplayMember = "ten_loai_quyet_dinh";
            thongTinQuyetDinh1.comB_Loai.ValueMember = "loai_quyet_dinh_id";
        }

        private void PreapreDataSource()
        {
            dtDonVi = oDonvi.GetActiveDonVi();
            DataRow row = dtDonVi.NewRow();
            dtDonVi.Rows.InsertAt(row, 0);

            comb_DVTrucThuoc.DataSource = dtDonVi;
            comb_DVTrucThuoc.DisplayMember = "ten_don_vi";
            comb_DVTrucThuoc.ValueMember = "id";
        }

        private void lstb_DSDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstb_DSDV.SelectedIndex != -1)
            {
                int index = lstb_DSDV.SelectedIndex;
                DonVi dv = new DonVi();
                dv = dsDonVi_new[index];
                txt_TenDV.Text = dv.TenDonVi;
                txt_TenDVTat.Text = dv.TenDVVietTat;
                if (dv.DVChaID != null)
                    comb_DVTrucThuoc.SelectedValue = dv.DVChaID;
                else
                    comb_DVTrucThuoc.SelectedValue = 0;
                if (dv.TuNgay != null)
                {
                    dTP_NgayHieuLuc.Value = dv.TuNgay.Value;
                    dTP_NgayHieuLuc.Checked = false;
                }
                else
                    dTP_NgayHieuLuc.Checked = false;
                rTB_GhiChu.Text = dv.GhiChu;

            }
        }

        private void EnableControls(bool p_value)
        {
            if (p_value == false)
            {
                gb_ThongTinDV.Enabled = true;

                gb_DSDVMoi.Enabled = thongTinQuyetDinh1.Enabled  = false;
                txt_TenDV.Focus();
            }
            else
            {
                gb_ThongTinDV.Enabled = false;
                gb_DSDVMoi.Enabled =thongTinQuyetDinh1.Enabled = true; 
            }
            if (bAddFlag)
            {
                txt_TenDV.Text = txt_TenDVTat.Text = rTB_GhiChu.Text = "";
                dTP_NgayHieuLuc.Checked = false;
                comb_DVTrucThuoc.SelectedIndex = 0;
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (lstb_DSDV.SelectedItem != null)
            {
                bAddFlag = false;
                EnableControls(false);
            }
        }

        #region FILE
        private void bw_upload_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] NewFiles = Paths.Where(a => a.Value == false).Select(a => a.Key).ToArray();
            for (int i = 0; i < nNewFilesCount; i++)
            {
                bw_upload.ReportProgress(i + 1);

                ServerPaths[i] = oFTP.UploadFile(NewFiles[i], NewFiles[i].Split('\\').Last(), thongTinQuyetDinh1.txt_MaQD.Text);
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
            if (Paths.Where(a => a.Value == false).Select(a => a.Key).ToArray().Length > 0)
            {
                MessageBox.Show("Quá trình đăng tập tin lên server thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbl_Status.Text = "Đăng hình hoàn tất!";
            }

            oFile.MaQD = thongTinQuyetDinh1.txt_MaQD.Text;
            oFile.MoTa = Desc;
            string[] DeleteFiles = Paths.Where(a => a.Value == null).Select(a => a.Key).ToArray();

            try
            {
                oFile.AddFileArray(ServerPaths);
                if (DeleteFiles.Length > 0)
                    oFile.Delete_HD_QD(DeleteFiles);
            }
            catch (Exception)
            {
                MessageBox.Show("Quá trình lưu tập tin không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CleanUIData();

            ((Form)this.Parent.Parent).ControlBox = true;
            this.Enabled = true;
        }

        private void bw_download_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] a = new string[1];

            for (int i = 0; i < dbPaths.Length; i++)
            {
                bw_download.ReportProgress(i + 1);


                a[0] = dbPaths[i];
                string downloadpath = oFTP.DownloadFile(a)[0];

                Paths.Add(new KeyValuePair<string, bool?>(downloadpath, true));

                Thread.Sleep(100);
            }
        }

        private void bw_download_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            pb_Status.Value = e.ProgressPercentage;
            // Set the text.
            lbl_Status.Text = "Đang tải tập tin ..." + e.ProgressPercentage.ToString() + " / " + dbPaths.Length.ToString();

        }

        private void bw_download_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbl_Status.Text = "Tải tập tin hoàn tất!";

            //Forms.Popup f = new Forms.Popup(new UCs.DSTapTin("HopDong", Paths, Desc), "QUẢN LÝ NHÂN SỰ - DANH SÁCH TẬP TIN");
            //UCs.DSTapTin.bHopDong = true;
            //f.ShowDialog();
        }

        private void btn_NhapFile_Click(object sender, EventArgs e)
        {
            if (thongTinQuyetDinh1.txt_MaQD.Text != "")
            {
                LoadFilesDB();
                DownLoadFile();
            }
            else
            {
                
            }

            //Form f = new Forms.Popup(new UCs.DSTapTin("ThanhLapDonVi", Paths, Desc), "QUẢN LÝ NHÂN SỰ - DANH SÁCH TẬP TIN");
            //f.ShowDialog();
        }

        private void DownLoadFile()
        {
            if (dtFile != null && dtFile.Rows.Count > 0)
            {
                pb_Status.Value = 0;
                pb_Status.Maximum = dtFile.Rows.Count;

                dbPaths = new string[dtFile.Rows.Count];
                for (int i = 0; i < dtFile.Rows.Count; i++)
                {
                    dbPaths[i] = dtFile.Rows[i]["path"].ToString();
                }

                Desc = dtFile.Rows[0]["mo_ta"].ToString();

                // Download 

                try
                {
                    bw_download.RunWorkerAsync();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Quá trình tải hình đại diện không thành công \r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void UploadFile()
        {
            #region HD

            nNewFilesCount = Paths.Where(a => a.Value == false).Count();
            ServerPaths = new string[nNewFilesCount];
            try
            {
                oFTP.oFileCate = FTP.FileCate.HDQD;
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

        private void LoadFilesDB()
        {
            oFile.MaQD = thongTinQuyetDinh1.txt_MaQD.Text;
            try
            {
                dtFile = oFile.GetData();
            }
            catch (Exception)
            {

            }

        } 
        #endregion
        
    }
}
