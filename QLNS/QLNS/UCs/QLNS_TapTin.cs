using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QLNS.UCs
{
    public partial class QLNS_TapTin : UserControl
    {
        bool AddFlag;   // xac dinh thao tac add hay edit
        Business.CNVC.CNVC_File oFile;

        public QLNS_TapTin(string _MaNV)
        {
            InitializeComponent();
            oFile = new Business.CNVC.CNVC_File();
            oFile.MaNV = _MaNV;
        }

        private void txt_DuongDan_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_DuongDan.Text = openFileDialog1.FileName;
            }

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            AddFlag = true;
            ResetInterface(false);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgv_DSTapTin.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá file này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oFile.ID = Convert.ToInt16(dtgv_DSTapTin.CurrentRow.Cells[0].Value.ToString());
                    try
                    {
                        oFile.Delete();
                        RefreshDataSource();
                        MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            AddFlag = false;
            ResetInterface(false);
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (txt_DuongDan.Text != "")
            {
                #region thao tac them
                if (AddFlag)
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm tập tin này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oFile.MoTa = rTB_MoTa.Text;
                        oFile.Path = txt_DuongDan.Text;
                        oFile.IsAvatar = false;
                        try
                        {
                            oFile.Add();
                            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ResetInterface(true);
                            RefreshDataSource();

                            

                            return;
                        }
                        catch
                        {
                            MessageBox.Show("Thao tác thêm thất bại.", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }

                    }

                }
                #endregion
                #region thao tac sua
                else                // thao tac sua
                {
                    if (MessageBox.Show("Bạn thực sự muốn sửa tập tin này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oFile.ID = Convert.ToInt32(dtgv_DSTapTin.SelectedRows[0].Cells[0].Value);
                        oFile.MoTa = rTB_MoTa.Text;
                        oFile.Path = txt_DuongDan.Text;

                        try
                        {
                            oFile.Update();
                            MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ResetInterface(true);
                            RefreshDataSource();

                            return;
                        }
                        catch
                        {
                            MessageBox.Show("Thao tác sửa thất bại.", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }                       
                    }
                }
                #endregion
            }
            else
                MessageBox.Show("Xin vui lòng chọn đường dẫn đến tập tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ResetInterface(true);
        }

        private void dtgv_DSTapTin_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSTapTin.CurrentRow != null)
                DisplayInfo(dtgv_DSTapTin.CurrentRow);
        }

        private void QLNS_TapTin_Load(object sender, EventArgs e)
        {
            List<Business.CNVC.CNVC_File> dt = oFile.GetData();
            if (dt != null)
            {
                PrepareDataSource(dt);
                EditDtgInterface();
            }

            ResetInterface(true);
        }

        #region Ham phu
        private void PrepareDataSource(List<Business.CNVC.CNVC_File> dt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dtgv_DSTapTin.DataSource = bs;
        }

        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtgv_DSTapTin.Columns[2].HeaderText = "Mô tả";
            dtgv_DSTapTin.Columns[2].Width = 250;
            dtgv_DSTapTin.Columns[3].HeaderText = "Đường dẫn";
            dtgv_DSTapTin.Columns[3].Width = 700;
            dtgv_DSTapTin.Columns[4].HeaderText = "Hình đại diện";
            dtgv_DSTapTin.Columns[4].Width = 50;
            // An cac cot ID
            dtgv_DSTapTin.Columns[0].Visible = dtgv_DSTapTin.Columns[1].Visible = false;
        }

        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_DuongDan.Text = row.Cells[3].Value.ToString();
                rTB_MoTa.Text = row.Cells[2].Value.ToString();
                cb_HinhDaiDien.Checked = Convert.ToBoolean(row.Cells[4].Value);
            }
        }

        private void ResetInterface(bool init)
        {
            if (init)
            {
                Program.DkButton(new Button[] { btn_Them, btn_Sua, btn_Xoa }, new Button[] { btn_Luu, btn_Huy });
                Program.DkControl(new Object[] {  txt_DuongDan, rTB_MoTa }, false, "Enable");
                dtgv_DSTapTin.Enabled = true;
                if (dtgv_DSTapTin.CurrentRow != null)
                    DisplayInfo(dtgv_DSTapTin.CurrentRow);
            }
            else
            {
                Program.DkControl(new Object[] { txt_DuongDan,rTB_MoTa }, true, "Enable");
                Program.DkButton(new Button[] { btn_Luu, btn_Huy }, new Button[] { btn_Them, btn_Sua, btn_Xoa });
                dtgv_DSTapTin.Enabled = false;
                if (AddFlag) // thao tac them moi xoa rong cac field
                {
                   txt_DuongDan.Text =  rTB_MoTa.Text = "";
                    cb_HinhDaiDien.Checked = false;
                }
            }
        }

        public void SaveStreamToFile(string fileFullPath, Stream stream)
        {
            if (stream.Length == 0) return;

            // Create a FileStream object to write a stream to a file
            using (FileStream fileStream = System.IO.File.Create(fileFullPath, (int)stream.Length))
            {
                // Fill the bytes[] array with the stream data
                byte[] bytesInStream = new byte[stream.Length];
                stream.Read(bytesInStream, 0, (int)bytesInStream.Length);

                // Use FileStream object to write to the specified file
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            }
        }

        private void RefreshDataSource()
        {            
            List<Business.CNVC.CNVC_File> dt = oFile.GetData();
            if (dt != null)
            {
                PrepareDataSource(dt);
                EditDtgInterface();
            }
        }

        #endregion
    }
}
