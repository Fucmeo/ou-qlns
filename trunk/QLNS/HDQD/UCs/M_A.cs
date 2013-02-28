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
    public partial class M_A : UserControl
    {
        Business.DonVi oDonvi;
        Business.CNVC.CNVC oCNVC;
        List<Business.DonVi> dsDonVi_new;
        List<string> dsCNVC;
        List<string> ds_tenCNVC;
        DataTable dtDonVi;

        public static string[] m_ma_nv;
        public static string[] m_ho_ten;
        public static int row_count;
        public static bool hitOK;

        public static bool is_Tach_DV = false; //true = tach; false = gop
        
        //public M_A()
        //{
        //    InitializeComponent();
        //    oDonvi = new DonVi();
        //    oCNVC = new Business.CNVC.CNVC();
        //    dsDonVi_new = new List<DonVi>();
        //    dsCNVC = new List<string>();
        //    ds_tenCNVC = new List<string>();

        //    dtDonVi = new DataTable();
        //}

        public M_A(bool p_is_Tach_DV)
        {
            InitializeComponent();
            oDonvi = new DonVi();
            oCNVC = new Business.CNVC.CNVC();
            dsDonVi_new = new List<DonVi>();
            dsCNVC = new List<string>();
            ds_tenCNVC = new List<string>();

            dtDonVi = new DataTable();

            is_Tach_DV = p_is_Tach_DV;
        }

        private void M_A_Load(object sender, EventArgs e)
        {
            PrepareSourceLoaiQuyetDinh();
            PreapreDataSource();
            GenUI_TuDonVi(0);

            if (is_Tach_DV == true) //tách đơn vị
            {
                btn_ThemTuDV.Enabled = false;
            }
            else //gộp đơn vị
            {
                lb_TimNV.Enabled = groupBox4.Enabled = false;
            }
        }

        #region Private Methods
        private void PrepareSourceLoaiQuyetDinh()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("loai_quyet_dinh_id", typeof(int));
            dt.Columns.Add("ten_loai_quyet_dinh", typeof(string));

            if (is_Tach_DV == true) //tách đơn vị
            {
                dt.Rows.Add(new object[2] { 5, "Tách đơn vị" });
            }
            else //gộp đơn vị
            {
                dt.Rows.Add(new object[2] { 9, "Gộp đơn vị" });
            }

            thongTinQuyetDinh1.comB_Loai.DataSource = dt;
            thongTinQuyetDinh1.comB_Loai.DisplayMember = "ten_loai_quyet_dinh";
            thongTinQuyetDinh1.comB_Loai.ValueMember = "loai_quyet_dinh_id";
        }

        private void PreapreDataSource()
        {
            dtDonVi = oDonvi.GetDonViList();
            DataRow row = dtDonVi.NewRow();
            dtDonVi.Rows.InsertAt(row, 0);

            comb_DVTrucThuoc.DataSource = dtDonVi;
            comb_DVTrucThuoc.DisplayMember = "ten_don_vi";
            comb_DVTrucThuoc.ValueMember = "id";
        }

        private void EnableControls(bool p_value)
        {
            if (p_value == false)
            {
                btn_LuuThongTin.Enabled = btn_HuyThongTin.Enabled = lb_TimNV.Enabled = txt_TenDV.Enabled = txt_TenDVTat.Enabled = 
                    comb_DVTrucThuoc.Enabled = dTP_NgayHieuLuc.Enabled = rTB_GhiChu.Enabled = true;
                btn_ThemTuDV.Enabled = btn_ThemSangDV.Enabled = btn_XoaSangDV.Enabled = btn_Nhap.Enabled = btn_Huy.Enabled = false;

                txt_TenDV.Text = txt_TenDVTat.Text = rTB_GhiChu.Text = "";
                txt_TenDV.Focus();

                thongTinQuyetDinh1.Enabled = false;

                listB_SangDV.Enabled = tableLP_ComboTuDV.Enabled = false;
                listB_DSNV.Items.Clear();
            }
            else
            {
                btn_LuuThongTin.Enabled = btn_HuyThongTin.Enabled = lb_TimNV.Enabled = txt_TenDV.Enabled = txt_TenDVTat.Enabled =
                    comb_DVTrucThuoc.Enabled = dTP_NgayHieuLuc.Enabled = rTB_GhiChu.Enabled = false;
                btn_ThemTuDV.Enabled = btn_ThemSangDV.Enabled = btn_XoaSangDV.Enabled = btn_Nhap.Enabled = btn_Huy.Enabled = true;

                txt_TenDV.Text = txt_TenDVTat.Text = rTB_GhiChu.Text = "";
                //txt_TenDV.Focus();

                thongTinQuyetDinh1.Enabled = true;

                listB_SangDV.Enabled = tableLP_ComboTuDV.Enabled = true;
                listB_DSNV.Items.Clear();
            }

            if (is_Tach_DV == true) //tách đơn vị
            {
                btn_ThemTuDV.Enabled = false;
            }
            else //gộp đơn vị
            {
                lb_TimNV.Enabled = groupBox4.Enabled = false;
            }
        }

        #endregion

        #region Khang
        #region Code giao diện

        /// <summary>
        /// Add combo box vao tableLP Tu Don Vi
        /// </summary>
        private void GenUI_TuDonVi(int row)
        {
            #region layout code
            ComboBox com = new ComboBox();
            com.Anchor = AnchorStyles.None;
            com.DropDownStyle = ComboBoxStyle.DropDownList;
            com.Width = 500;
            com.Name = "comB_TuDV_" + row.ToString();

            //load data for combo box
            DataTable dt_temp = dtDonVi.Copy();
            com.DataSource = dt_temp;
            com.DisplayMember = "ten_don_vi";
            com.ValueMember = "id";

            Label lb_ten_xoa = new Label();
            lb_ten_xoa.Anchor = AnchorStyles.Right;
            lb_ten_xoa.MouseClick += new MouseEventHandler(lb_ten_xoa_MouseClick);
            lb_ten_xoa.Text = "Xoá";
            lb_ten_xoa.Cursor = Cursors.Hand;
            lb_ten_xoa.Font = new Font(lb_ten_xoa.Font.Name, lb_ten_xoa.Font.Size, FontStyle.Underline);
            lb_ten_xoa.ForeColor = Color.Blue;
            lb_ten_xoa.Name = "txt_Xoa_Ten_" + row.ToString();

            tableLP_ComboTuDV.Controls.Add(com, 0, row);
            tableLP_ComboTuDV.Controls.Add(lb_ten_xoa, 1, row);

            #endregion
        }

        void lb_ten_xoa_MouseClick(object sender, MouseEventArgs e)
        {
            Label lb = ((Label)(sender));
            int TLPRows = tableLP_ComboTuDV.RowCount;
            int lbRow = tableLP_ComboTuDV.GetRow(lb);
            int lbCol = tableLP_ComboTuDV.GetColumn(lb);


            if (TLPRows > 1)   // khong duoc xoa dong cuoi cung
            {
                AddRemoveRow(tableLP_ComboTuDV, "Remove", lbRow);
                MoveUp(tableLP_ComboTuDV, lbRow);
            }

        }

        /// <summary>
        /// move up controls sau khi xoá
        /// </summary>
        /// <param name="TLP"></param>
        private void MoveUp(TableLayoutPanel TLP, int DelRow)
        {
            for (int i = ++DelRow; i <= TLP.RowCount; i++)
            {
                int BackRow = i - 1;
                for (int y = 0; y < TLP.ColumnCount; y++)
                {
                    Control c = TLP.Controls[BackRow * TLP.ColumnCount + y];
                    TLP.SetRow(c, BackRow);


                }
            }

        }

        /// <summary>
        /// thêm xoá dòng tương ứng trong TLP
        /// dịch chuyển các control
        /// </summary>
        /// <param name="tableLP">ten TLP muốn thêm / xoá dòng</param>
        /// <param name="Action" value="Add/Remove">"Add","Remove"</param>
        /// <param name="row">index của dòng</param>
        private void AddRemoveRow(TableLayoutPanel tableLP, string Action, int row)
        {
            if (Action == "Add")
            {
                tableLP.RowStyles.Insert(row, new RowStyle(SizeType.Absolute));
                tableLP.RowCount++;
                CalculateHeight(tableLP);

                GenUI_TuDonVi(row);
            }
            else if (Action == "Remove")
            {
                tableLP.RowStyles.RemoveAt(row);
                tableLP.RowCount--;
                CalculateHeight(tableLP);
                RemoveControlsFromTLP(tableLP, row);
            }
        }

        /// <summary>
        /// Dùng khi xoá 1 dòng trong TLP
        /// </summary>
        /// <param name="TLP"></param>
        /// <param name="Controls"></param>
        private void RemoveControlsFromTLP(TableLayoutPanel TLP, int row)
        {
            for (int i = 0; i < TLP.ColumnCount; i++)
            {
                Control c = TLP.Controls[row * TLP.ColumnCount];    // do khi remove, thứ tự index sẽ bị đôn lên
                TLP.Controls.Remove(c);
            }
        }

        private void CalculateHeight(TableLayoutPanel TLP)
        {
            for (int i = 0; i < TLP.RowCount; i++)
            {
                TLP.RowStyles[i].Height = TLP.Height / TLP.RowCount;
            }
        }

        #endregion

        private void btn_ThemTuDV_Click(object sender, EventArgs e)
        {
            int TLPRows = tableLP_ComboTuDV.RowCount;
            int lbRow = tableLP_ComboTuDV.RowCount;


            if (TLPRows < 10)    // gioi han 10 dong
            {
                AddRemoveRow(tableLP_ComboTuDV, "Add", lbRow);
            }
            else
            {
                MessageBox.Show("Số lượng dòng vượt quá giới hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        #endregion

        private void btn_ThemSangDV_Click(object sender, EventArgs e)
        {
            
            if (is_Tach_DV == false) //gộp đơn vị
            {
                int count = listB_SangDV.Items.Count;
                if (count > 0)
                {
                    MessageBox.Show("Chỉ được tồn tại duy nhất một đơn vị được gộp. \r\nVui lòng xóa đơn vị cũ trước khi thêm đơn vị mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    EnableControls(false);
            }
            else
                EnableControls(false);
        }

        private void btn_HuyThongTin_Click(object sender, EventArgs e)
        {
            EnableControls(true);
        }

        private void btn_LuuThongTin_Click(object sender, EventArgs e)
        {
            if (txt_TenDV.Text != null && dTP_NgayHieuLuc.Checked == true)
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

                //Xử lý chuỗi mã nhân viên
                string ma_nv_arr = "";
                string ten_nv_arr = "";
                //foreach (string item in m_ma_nv)
                //{
                //    ma_nv_arr = ma_nv_arr + "'" + item + "', ";

                //}
                if (m_ma_nv != null && m_ma_nv.Length > 0)
                {
                    for (int y = 0; y < m_ma_nv.Length; y++)
                    {
                        ma_nv_arr = ma_nv_arr + "'" + m_ma_nv[y] + "', ";
                        ten_nv_arr = ten_nv_arr + m_ho_ten[y] + ";";
                    }

                    ma_nv_arr = ma_nv_arr.Remove(ma_nv_arr.Length - 2);
                    ten_nv_arr = ten_nv_arr.Remove(ten_nv_arr.Length - 1);
                }
                int i = listB_SangDV.Items.Count;
                dsDonVi_new.Insert(i, dv);
                dsCNVC.Insert(i, ma_nv_arr);
                ds_tenCNVC.Insert(i, ten_nv_arr);

                listB_SangDV.Items.Add(txt_TenDV.Text);

                EnableControls(true);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lb_TimNV_Click(object sender, EventArgs e)
        {
            hitOK = false;
            m_ma_nv = new string[0];
            m_ho_ten = new string[0];

            int dv_id = 0;
            for (int i = 0; i < tableLP_ComboTuDV.RowCount; i++)
            {
                ComboBox cbo_DonVi = (ComboBox)tableLP_ComboTuDV.Controls[i];
                if (cbo_DonVi.Text != "")
                    dv_id = Convert.ToInt16(cbo_DonVi.SelectedValue);
                else
                {
                    MessageBox.Show("Vui lòng chọn một đơn vị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (dv_id != 0)
            {
                DataTable dtCNVC = oCNVC.Search_CNVC_by_DonVi(dv_id);

                Forms.Popup frPopup = new Forms.Popup(new UCs.DSCNVC(dtCNVC), "QUẢN LÝ NHÂN SỰ - DANH SÁCH CNVC");
                HDQD.UCs.DSCNVC.eParentUC = DSCNVC.ParentUC.MA;
                frPopup.ShowDialog();
            }
            if (hitOK)
            {
                listB_DSNV.Items.Clear();

                //Set_CNVCs_to_LB(m_ma_nv, m_ho_ten, row_count);
                foreach (string item in m_ho_ten)
                {
                    listB_DSNV.Items.Add(item);
                }
            }

        }

        private void Set_CNVCs_to_LB(string[] p_ma_nv, string[] p_ho_ten, int num)
        {
            foreach (string item in p_ho_ten)
            {
                listB_DSNV.Items.Add(item);
            }
        }

        private void btn_XoaSangDV_Click(object sender, EventArgs e)
        {
            int index = listB_SangDV.SelectedIndex;
            dsDonVi_new.RemoveAt(index);
            dsCNVC.RemoveAt(index);
            ds_tenCNVC.RemoveAt(index);

            listB_SangDV.Items.RemoveAt(index);
        }

        private void listB_SangDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listB_SangDV.SelectedIndex != -1)
            {
                int index = listB_SangDV.SelectedIndex;
                DonVi dv = new DonVi();
                dv = dsDonVi_new[index];
                txt_TenDV.Text = dv.TenDonVi;
                txt_TenDVTat.Text = dv.TenDVVietTat;
                if (dv.DVChaID != null)
                    comb_DVTrucThuoc.SelectedValue = dv.DVChaID;
                else
                    comb_DVTrucThuoc.SelectedValue = 0;
                if (dv.TuNgay != null)
                    dTP_NgayHieuLuc.Value = dv.TuNgay.Value;
                else
                    dTP_NgayHieuLuc.Checked = false;
                rTB_GhiChu.Text = dv.GhiChu;

                string ho_ten_nv = ds_tenCNVC[index];
                string[] nv_arr = ho_ten_nv.Split(';');
                listB_DSNV.Items.Clear();
                foreach (string item in nv_arr)
                {
                    listB_DSNV.Items.Add(item);
                }
            }
        }

        private void btn_Nhap_Click(object sender, EventArgs e)
        {
            if (thongTinQuyetDinh1.txt_MaQD.Text != "")
            {
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

                if (is_Tach_DV == true) // tach don vi
                {
                    #region Tách đơn vị
                    try
                    {
                        int count = dsDonVi_new.Count;
                        string[] ten_don_vi_moi = new string[count];
                        string[] ten_dv_viet_tat = new string[count];
                        int[] dv_cha_id = new int[count];
                        string[] tu_ngay = new string[count];
                        string[] ghi_chu = new string[count];
                        string[] ma_nv = new string[count];

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
                            tu_ngay[i] = dv.TuNgay.Value.ToShortDateString();

                            ma_nv[i] = dsCNVC[i];

                        }

                        int[] tu_don_vi = new int[1];
                        ComboBox cbo_DonVi = (ComboBox)tableLP_ComboTuDV.Controls[0];
                        if (cbo_DonVi.Text != "")
                            tu_don_vi[0] = Convert.ToInt16(cbo_DonVi.SelectedValue);
                        else
                        {
                            MessageBox.Show("Vui lòng chọn một đơn vị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        bool result = quyetdinh.MA_Tach_DonVi(tu_don_vi, ten_don_vi_moi, ten_dv_viet_tat, dv_cha_id, tu_ngay, ghi_chu, ma_nv);
                        if (result == true)
                            MessageBox.Show("Nhập quyết định tách đơn vị thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Nhập quyết định tách đơn vị không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nhập quyết định tách đơn vị không thành công.\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    #endregion
                }
                else // gộp đơn vị
                {
                    #region Gộp đơn vị
                    try
                    {
                        int[] tu_don_vi_id = new int[tableLP_ComboTuDV.RowCount];
                        for (int i = 0; i < tableLP_ComboTuDV.RowCount; i++)
                        {
                            tu_don_vi_id[i] = Convert.ToInt16(((ComboBox)tableLP_ComboTuDV.Controls[i * 2]).SelectedValue);
                        }

                        DonVi dv = new DonVi();
                        dv = dsDonVi_new[0];

                        string ten_dv_moi = dv.TenDonVi;
                        string ten_dv_viet_tat = dv.TenDVVietTat;
                        int? dv_cha_id = dv.DVChaID;
                        //if (comb_DVTrucThuoc.Text != "")
                        //    dv_cha_id = Convert.ToInt16(comb_DVTrucThuoc.SelectedValue);
                        string tu_ngay = dv.TuNgay.Value.ToShortDateString();
                        string ghi_chu = dv.GhiChu;

                        bool result = quyetdinh.MA_Gop_DonVi(tu_don_vi_id, ten_dv_moi, ten_dv_viet_tat, dv_cha_id, tu_ngay, ghi_chu);
                        if (result == true)
                            MessageBox.Show("Nhập quyết định gộp đơn vị thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Nhập quyết định gộp đơn vị không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nhập quyết định gộp đơn vị không thành công.\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    #endregion

                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
    }
}
