﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HDQD.UCs
{
    public partial class DSTapTin : UserControl
    {
        const int nTLPControls = 6;
        Business.FTP oFTP;
        public static bool bHopDong = false;

        public DSTapTin(List<KeyValuePair<string,bool>> FilesPath = null, string Mota = null)
        {
            InitializeComponent();
            oFTP = new Business.FTP();
            if (FilesPath != null)
            {
                AddFiles(FilesPath, Mota);
            }
        }

        private void AddFiles(List<KeyValuePair<string, bool>> FilesPath, string MoTa)
        {
            for (int i = 0; i < FilesPath.Count; i++)
            {
                lsb_DSFile.Items.Add(FilesPath[i].Key.ToString());                
            }
            rtb_MoTa.Text = MoTa;
        }

        private void DSTapTin_Load(object sender, EventArgs e)
        {
            //GenUI_File(0);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (OFD.FileNames != null && OFD.ShowDialog() == DialogResult.OK)
            {
                if (oFTP.ChecFileSize(OFD.FileNames))
                {
                    lsb_DSFile.Items.AddRange(OFD.FileNames);
                    for (int i = 0; i < OFD.FileNames.Length; i++)
                    {
                        // add moi tinh trang exists = false
                        HopDong.Paths.Add(new KeyValuePair<string, bool>(lsb_DSFile.Items[i].ToString(), false));
                    }
                }
                else
                {
                    MessageBox.Show("Tập tin không được lớn hơn 2,5 MB.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (lsb_DSFile.Items.Count > 0)
            {
                if (!bHopDong)
                {
                    ThongTinQuyetDinh.Paths = new string[lsb_DSFile.Items.Count];
                    lsb_DSFile.Items.CopyTo(ThongTinQuyetDinh.Paths, 0);
                    ThongTinQuyetDinh.Desc = rtb_MoTa.Text;
                    ((Form)this.Parent).Close();
                }
                else
                {
                    // paths da duoc add vao list ngay khi add hinh`
                    HopDong.Desc = rtb_MoTa.Text;

                    ((Form)this.Parent).Close();
                }
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (lsb_DSFile.SelectedItem != null)
            {
                lsb_DSFile.Items.Remove(lsb_DSFile.SelectedItem);
                pb_Preview.Image = null;
                pb_Preview.ImageLocation = null;
            }
        }

        private void lsb_DSFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsb_DSFile.SelectedItem != null)
            {
                try
                {
                    pb_Preview.Image = Image.FromFile(lsb_DSFile.SelectedItem.ToString());
                    pb_Preview.ImageLocation = lsb_DSFile.SelectedItem.ToString();
                }
                catch (Exception)
                {
                    
                }
            }
        }

        private void btn_DownLoad_Click(object sender, EventArgs e)
        {
            if (lsb_DSFile.SelectedItems.Count > 0)
            {
                FBD.ShowDialog();
                
                if (FBD.SelectedPath != "")
                {
                    bool bSuccess = true;
                    string SavePath = FBD.SelectedPath;
                    for (int i = 0; i < lsb_DSFile.SelectedItems.Count; i++)
                    {
                        string FileName = lsb_DSFile.SelectedItems[i].ToString().Split('\\').Last();
                        // Use Path class to manipulate file and directory paths. 
                        //string sourceFile = System.IO.Path.Combine(lsb_DSFile.SelectedItems[i].ToString(), FileName);
                        string destFile = System.IO.Path.Combine(SavePath, FileName);
                        try
                        {
                            File.Copy(lsb_DSFile.SelectedItems[i].ToString(), destFile, true);
                        }
                        catch (Exception)
                        {
                            bSuccess = false;
                            break;
                        }

                    }
                    if(bSuccess)
                        MessageBox.Show("Quá trình tải hình thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #region Code giao dien
        //#region Code giao diện

        ///// <summary>
        ///// Add cac control vao khung thay đổi tên.
        ///// </summary>
        //private void GenUI_File(int row)
        //{
        //    #region layout code
        //    Label lb = new Label();
        //    lb.Anchor = AnchorStyles.None;
        //    lb.Text = "Đường dẫn";
        //    lb.Name = "lbl_DuongDan_" + row.ToString();

        //    TextBox txt = new TextBox();
        //    txt.Anchor = AnchorStyles.None;
        //    txt.Name = "txt_DuongDan_" + row.ToString();
        //    txt.DoubleClick += new EventHandler(txt_DoubleClick);
        //    txt.Width = 500;

        //    Label lb2 = new Label();
        //    lb2.Anchor = AnchorStyles.None;
        //    lb2.Text = "Mô tả";
        //    lb2.Name = "lbl_MoTa_" + row.ToString();


        //    RichTextBox rtb = new RichTextBox();
        //    rtb.Anchor = AnchorStyles.None;
        //    rtb.Name = "rtb_MoTa_" + row.ToString();
        //    rtb.Width = 500;

        //    Label lb_ten_them = new Label();
        //    lb_ten_them.MouseClick += new MouseEventHandler(lb_MouseClick);
        //    lb_ten_them.Anchor = AnchorStyles.None;
        //    lb_ten_them.Text = "Thêm";
        //    lb_ten_them.Cursor = Cursors.Hand;
        //    lb_ten_them.Font = new Font(lb_ten_them.Font.Name, lb_ten_them.Font.Size, FontStyle.Underline);
        //    lb_ten_them.ForeColor = Color.Blue;
        //    lb_ten_them.Name = "txt_Them_Ten_" + row.ToString();


        //    Label lb_ten_xoa = new Label();
        //    lb_ten_xoa.Anchor = AnchorStyles.None;
        //    lb_ten_xoa.MouseClick += new MouseEventHandler(lb_MouseClick);
        //    lb_ten_xoa.Text = "Xoá";
        //    lb_ten_xoa.Cursor = Cursors.Hand;
        //    lb_ten_xoa.Font = new Font(lb_ten_them.Font.Name, lb_ten_them.Font.Size, FontStyle.Underline);
        //    lb_ten_xoa.ForeColor = Color.Blue;
        //    lb_ten_xoa.Name = "txt_Xoa_Ten_" + row.ToString();

        //    tableLP_ChiTietFile.Controls.Add(lb, 0, row);
        //    tableLP_ChiTietFile.Controls.Add(txt, 1, row);
        //    tableLP_ChiTietFile.Controls.Add(lb_ten_them, 2, row);
        //    tableLP_ChiTietFile.Controls.Add(lb_ten_xoa, 3, row);
        //    tableLP_ChiTietFile.Controls.Add(lb2, 0, row + 1);
        //    tableLP_ChiTietFile.Controls.Add(rtb, 1, row + 1);


        //    #endregion

        //}

        //void txt_DoubleClick(object sender, EventArgs e)
        //{
        //    OFD.ShowDialog();
        //}


        ///// <summary>
        ///// xét label dược click thuộc tableLP nào, row index nào
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void lb_MouseClick(object sender, MouseEventArgs e)
        //{
        //    Label lb = ((Label)(sender));
        //    TableLayoutPanel tableLP_ChiTietFile = ((TableLayoutPanel)(lb.Parent));
        //    string name = lb.Name;
        //    int tableLP_ChiTietFileRows = tableLP_ChiTietFile.RowCount / 2;
        //    int lbRow = tableLP_ChiTietFile.GetRow(lb);
        //    int lbCol = tableLP_ChiTietFile.GetColumn(lb);
        //    int idx = tableLP_ChiTietFile.Controls.IndexOfKey(lb.Name);

        //    if (name.Contains("Xoa"))
        //    {
        //        if (tableLP_ChiTietFileRows > 1)   // khong duoc xoa dong con lai
        //        {
        //            // dòng bị xoá là dòng cuối 
        //            //thì unhide "Thêm" ở dòng kế cuối
        //            if ((lbRow + 2) / 2 == tableLP_ChiTietFileRows)
        //            {

        //                Control c = tableLP_ChiTietFile.Controls[idx - 1 - nTLPControls];    // trừ 1 để chuyển sang lb Thêm
        //                c.Visible = true;
        //            }
        //            AddRemoveRow(tableLP_ChiTietFile, "Remove", lbRow);
        //            if (lbRow != tableLP_ChiTietFile.RowCount)
        //                MoveUp(tableLP_ChiTietFile, lbRow);
        //        }
        //    }
        //    else if (name.Contains("Them"))
        //    {
        //        if (tableLP_ChiTietFileRows < 5)    // gioi han 5 file
        //        {
        //            lb.Visible = false; // hide chữ "thêm" trước khi thêm mới 
        //            AddRemoveRow(tableLP_ChiTietFile, "Add", ++lbRow);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Số lượng dòng vượt quá giới hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }

        //}

        ///// <summary>
        ///// move up controls sau khi xoá
        ///// </summary>
        ///// <param name="TLP"></param>
        //private void MoveUp(TableLayoutPanel TLP, int DelRow)
        //{
        //    for (int i = DelRow; i < TLP.RowCount; i = i + 2)
        //    {
        //        for (int y = 0; y < nTLPControls; y++)
        //        {
        //            Control c = TLP.Controls[i * 3 + y];
        //            if (y <= 3)
        //                TLP.SetRow(c, i);
        //            else
        //                TLP.SetRow(c, i + 1);
        //        }
        //    }

        //    //for (int i = ++DelRow; i <= TLP.RowCount; i++)
        //    //{
        //    //    int BackRow = i - 1;
        //    //    for (int y = 0; y < nTLPControls; y++)
        //    //    {
        //    //        Control c = TLP.Controls[BackRow * nTLPControls + y];
        //    //        TLP.SetRow(c, BackRow);


        //    //    }
        //    //}
        //}

        ///// <summary>
        ///// thêm xoá dòng tương ứng trong TLP
        ///// dịch chuyển các control
        ///// </summary>
        ///// <param name="tableLP">ten TLP muốn thêm / xoá dòng</param>
        ///// <param name="Action" value="Add/Remove">"Add","Remove"</param>
        ///// <param name="row">index của dòng</param>
        //private void AddRemoveRow(TableLayoutPanel tableLP, string Action, int row)
        //{
        //    if (Action == "Add")
        //    {
        //        tableLP.RowStyles.Insert(row, new RowStyle(SizeType.Absolute));
        //        tableLP.RowStyles.Insert(++row, new RowStyle(SizeType.Absolute));
        //        tableLP.RowCount += 2;
        //        CalculateHeight(tableLP);

        //        switch (tableLP.Name)
        //        {
        //            case "tableLP_ChiTietFile":
        //                GenUI_File(row);
        //                break;
        //            default:
        //                break;
        //        }

        //    }
        //    else if (Action == "Remove")
        //    {
        //        tableLP.RowStyles.RemoveAt(row);
        //        tableLP.RowStyles.RemoveAt(row);
        //        tableLP.RowCount -= 2;
        //        CalculateHeight(tableLP);
        //        RemoveControlsFromTLP(tableLP, row);
        //    }
        //}

        ///// <summary>
        ///// Dùng khi xoá 1 dòng trong TLP
        ///// </summary>
        ///// <param name="TLP"></param>
        ///// <param name="Controls"></param>
        //private void RemoveControlsFromTLP(TableLayoutPanel TLP, int row)
        //{
        //    for (int i = 0; i < nTLPControls; i++)
        //    {
        //        Control c = TLP.Controls[row / 2 * nTLPControls];    // do khi remove, thứ tự index sẽ bị đôn lên
        //        TLP.Controls.Remove(c);
        //    }
        //}

        //private void CalculateHeight(TableLayoutPanel TLP)
        //{
        //    for (int i = 0; i < TLP.RowCount; i++)
        //    {
        //        TLP.RowStyles[i].Height = TLP.Height / TLP.RowCount;
        //    }
        //}

        //#endregion
        #endregion
        
    }
}
