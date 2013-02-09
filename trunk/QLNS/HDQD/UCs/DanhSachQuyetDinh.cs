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
    public partial class DanhSachQuyetDinh : UserControl
    {
        Business.HDQD.QuyetDinh oQuyetDinh;
        DataTable dtDSQuyetDinh;
        Business.HDQD.LoaiQuyetDinh oLoaiQuyetDinh;
        DataTable dtDSLoaiQuyetDinh;

        public DanhSachQuyetDinh()
        {
            InitializeComponent();
            oQuyetDinh = new Business.HDQD.QuyetDinh();
            oLoaiQuyetDinh = new Business.HDQD.LoaiQuyetDinh();
        }

        private void DanhSachQuyetDinh_Load(object sender, EventArgs e)
        {
            dtDSLoaiQuyetDinh = oLoaiQuyetDinh.GetList_Compact();
            PrepareCboLoaiQD();
        }
        #region Methods
        private void PrepareCboLoaiQD()
        {
            DataRow row = dtDSLoaiQuyetDinh.NewRow();
            dtDSLoaiQuyetDinh.Rows.InsertAt(row, 0);
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dtDSLoaiQuyetDinh;
            comB_Loai.DataSource = dtDSLoaiQuyetDinh;
            comB_Loai.DisplayMember = "ten_loai";
            comB_Loai.ValueMember = "id";

        }

        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtDSQuyetDinh;
            dtgv_DSQD.DataSource = bs;
            //lbl_SoLoaiPC.Text = dtgv_DSLoaiPC.Rows.Count.ToString();
            if (dtDSQuyetDinh != null)
            {
                btn_TaiFile.Visible = btn_Xoa.Visible = true;
            }
        }

        /// <summary>
        /// Sua ten, an  cac cot cua dtg cho phu hop
        /// </summary>
        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtgv_DSQD.Columns[0].HeaderText = "Mã quyết định";
            dtgv_DSQD.Columns[0].Width = 100;
            dtgv_DSQD.Columns[1].HeaderText = "Tên quyết định";
            dtgv_DSQD.Columns[1].Width = 200;
            dtgv_DSQD.Columns[2].HeaderText = "Loại qd ID";
            dtgv_DSQD.Columns[3].HeaderText = "Tên loại quyết định";
            dtgv_DSQD.Columns[3].Width = 200;
            dtgv_DSQD.Columns[4].HeaderText = "Mô tả";
            dtgv_DSQD.Columns[4].Width = 300;
            dtgv_DSQD.Columns[5].HeaderText = "Path";
            dtgv_DSQD.Columns[6].HeaderText = "Ngày ký";
            dtgv_DSQD.Columns[6].Width = 100;
            dtgv_DSQD.Columns[7].HeaderText = "Ngày hiệu lực";
            dtgv_DSQD.Columns[7].Width = 100;
            dtgv_DSQD.Columns[8].HeaderText = "Ngày hết hạn";
            dtgv_DSQD.Columns[8].Width = 100;
            // An cot ID
            dtgv_DSQD.Columns[2].Visible = false;
            dtgv_DSQD.Columns[5].Visible = false;
        }

        /// <summary>
        /// Su dung thong tin row dang chon de hien thi len txt, comb,..
        /// </summary>
        /// <param name="row"></param>
        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_Ma2.Text = row.Cells[0].Value.ToString();
                txt_Ten2.Text = row.Cells[1].Value.ToString();
                txt_Loai.Text = row.Cells[3].Value.ToString();
                txt_NgayKy.Text = row.Cells[6].Value.ToString() == "" ? "" : Convert.ToDateTime(row.Cells[6].Value.ToString()).ToShortDateString();
                txt_NgayHieuLuc.Text = row.Cells[7].Value.ToString() == "" ? "" : Convert.ToDateTime(row.Cells[7].Value.ToString()).ToShortDateString();
                txt_NgayHetHan.Text = row.Cells[8].Value.ToString() == "" ? "" : Convert.ToDateTime(row.Cells[8].Value.ToString()).ToShortDateString();
            }
        }

        private void ResetInterface(bool init)
        {
            btn_Xoa.Enabled = init;
            btn_TaiFile.Enabled = init;
        }

        /// <summary>
        /// Refresh Data Source cho dtg sau moi lan thao tac
        /// </summary>
        private void RefreshDataSource()
        {
            Business.HDQD.QuyetDinh quyetdinh = new Business.HDQD.QuyetDinh();    // khong dung chung oChucVu duoc ???
            dtDSQuyetDinh = quyetdinh.Search_QD();
            PrepareDataSource();

        }
        #endregion

        private void dTP_TuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dTP_TuNgay.Checked == true)
            {
                dTP_DenNgay.Enabled = true;
            }
            else
                dTP_DenNgay.Enabled = false;
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            oQuyetDinh.Ma_Quyet_Dinh = txt_Ma.Text == "" ? null : txt_Ma.Text;
            oQuyetDinh.Ten_Quyet_Dinh = txt_Ten.Text == "" ? null : txt_Ten.Text;
            
            oQuyetDinh.Loai_QuyetDinh_ID = null;
            if (comB_Loai.Text != "")
                oQuyetDinh.Loai_QuyetDinh_ID = Convert.ToInt16(comB_Loai.SelectedValue);

            oQuyetDinh.Ngay_Ky_Tu = null;
            oQuyetDinh.Ngay_Ky_Den = null;
            if (dTP_TuNgay.Checked == true)
            {
                oQuyetDinh.Ngay_Ky_Tu = dTP_TuNgay.Value;
                oQuyetDinh.Ngay_Ky_Den = dTP_DenNgay.Value;
            }
            try
            {
                dtDSQuyetDinh = oQuyetDinh.Search_QD();
                //dtgv_DSQD.DataSource = dtDSQuyetDinh;
                if (dtDSQuyetDinh != null)
                {
                    PrepareDataSource();
                    EditDtgInterface();
                    if (dtDSQuyetDinh.Rows.Count != 0)
                        ResetInterface(true);
                    else
                        ResetInterface(false);
                }
            }
            catch { }
        }

        private void dtgv_DSQD_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSQD.CurrentRow != null)
            {
                DisplayInfo(dtgv_DSQD.CurrentRow);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgv_DSQD.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá quyết định này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oQuyetDinh.Ma_Quyet_Dinh = dtgv_DSQD.CurrentRow.Cells[0].Value.ToString();
                        if (oQuyetDinh.Delete())
                        {
                            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        RefreshDataSource();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {

        }
    }
}
