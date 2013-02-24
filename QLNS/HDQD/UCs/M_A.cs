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
        DataTable dtDonVi;

        public static string[] m_ma_nv;
        public static string[] m_ho_ten;
        public static int row_count;
        public static bool hitOK;
        
        public M_A()
        {
            InitializeComponent();
            oDonvi = new DonVi();
            oCNVC = new Business.CNVC.CNVC();
            dsDonVi_new = new List<DonVi>();
            dsCNVC = new List<string>();

            dtDonVi = new DataTable();
        }

        private void M_A_Load(object sender, EventArgs e)
        {
            PreapreDataSource();
            GenUI_TuDonVi(0);

            
        }

        #region Private Methods
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

                //thongTinQuyetDinh1.txt_MaQD.Enabled = thongTinQuyetDinh1.txt_TenQD.Enabled = thongTinQuyetDinh1.comB_Loai.Enabled =
                //    thongTinQuyetDinh1.dTP_NgayKy.Enabled = thongTinQuyetDinh1.dTP_NgayHieuLuc.Enabled = thongTinQuyetDinh1.dTP_NgayHetHan.Enabled = 
                //    thongTinQuyetDinh1.rTB_MoTa.Enabled = 
                thongTinQuyetDinh1.Enabled = false;

                listB_SangDV.Enabled = tableLP_ComboTuDV.Enabled = false;
            }
            else
            {
                btn_LuuThongTin.Enabled = btn_HuyThongTin.Enabled = lb_TimNV.Enabled = txt_TenDV.Enabled = txt_TenDVTat.Enabled =
                    comb_DVTrucThuoc.Enabled = dTP_NgayHieuLuc.Enabled = rTB_GhiChu.Enabled = false;
                btn_ThemTuDV.Enabled = btn_ThemSangDV.Enabled = btn_XoaSangDV.Enabled = btn_Nhap.Enabled = btn_Huy.Enabled = true;

                txt_TenDV.Text = txt_TenDVTat.Text = rTB_GhiChu.Text = "";
                //txt_TenDV.Focus();

                //thongTinQuyetDinh1.txt_MaQD.Enabled = thongTinQuyetDinh1.txt_TenQD.Enabled = thongTinQuyetDinh1.comB_Loai.Enabled =
                //    thongTinQuyetDinh1.dTP_NgayKy.Enabled = thongTinQuyetDinh1.dTP_NgayHieuLuc.Enabled = thongTinQuyetDinh1.dTP_NgayHetHan.Enabled = 
                //    thongTinQuyetDinh1.rTB_MoTa.Enabled = 
                thongTinQuyetDinh1.Enabled = true;

                listB_SangDV.Enabled = tableLP_ComboTuDV.Enabled = true;
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
                foreach (string item in m_ma_nv)
                {
                    ma_nv_arr = ma_nv_arr + "'" + item + "', ";
                }
                ma_nv_arr = ma_nv_arr.Remove(ma_nv_arr.Length - 2);

                int i = listB_SangDV.Items.Count + 1;
                dsDonVi_new.Insert(i, dv);
                dsCNVC.Insert(i, ma_nv_arr);

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

                Forms.Popup frPopup = new Forms.Popup(new UCs.DSCNVC(dtCNVC));
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

        }
        
    }
}
