using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;

namespace QLNS.UCs
{
    public partial class QLNS_DonVi : UserControl
    {
        Business.DonVi donvi;

        bool AddFlag;   // xac dinh thao tac add hay edit

        public QLNS_DonVi()
        {
            InitializeComponent();
            donvi = new DonVi();
        }

        private void QLNS_DonVi_Load(object sender, EventArgs e)
        {
            DataTable dt = donvi.GetDonViDetailList();
            if (dt != null)
            {
                PrepareDataSource(dt);
                EditDtgInterface();
            }

            ResetInterface(true);

        }

        #region Ham phu
        private void PrepareDataSource(DataTable dt)
        {
            LoadCboDonViTrucThuoc();
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dtgv_DSDonVi.DataSource = bs;
        }

        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtgv_DSDonVi.Columns[1].HeaderText = "Tên ĐV viết tắt";
            dtgv_DSDonVi.Columns[2].HeaderText = "Tên đơn vị";
            dtgv_DSDonVi.Columns[2].Width = 150;
            dtgv_DSDonVi.Columns[4].HeaderText = "Tên đơn vị trực thuộc";
            dtgv_DSDonVi.Columns[4].Width = 200;
            dtgv_DSDonVi.Columns[5].HeaderText = "Từ ngày";
            dtgv_DSDonVi.Columns[6].HeaderText = "Đến ngày";
            dtgv_DSDonVi.Columns[7].HeaderText = "Hoạt động";
            dtgv_DSDonVi.Columns[8].HeaderText = "Ghi chú";

            // An cac cot ID
            dtgv_DSDonVi.Columns[0].Visible = false;
            dtgv_DSDonVi.Columns[3].Visible = false;
        }

        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_TenVietTat.Text = row.Cells[1].Value.ToString();
                txt_Ten.Text = row.Cells[2].Value.ToString();
                rTB_GhiChu.Text = row.Cells[8].Value.ToString();
                comB_TrucThuoc.Text = row.Cells[4].Value.ToString();

                if (Convert.ToBoolean(row.Cells[7].Value) == true)
                    cb_HoatDong.Checked = true;
                else
                    cb_HoatDong.Checked = false;

                if (row.Cells[5].Value.ToString() == "")
                    dTP_TuNgay.Checked = false;
                else
                {
                    dTP_TuNgay.Checked = true;
                    dTP_TuNgay.Value = Convert.ToDateTime(row.Cells[5].Value.ToString());
                    
                }

                if (row.Cells[6].Value.ToString() == "")
                    dTP_DenNgay.Checked = false;
                else
                {
                    dTP_DenNgay.Checked = true;
                    dTP_DenNgay.Value = Convert.ToDateTime(row.Cells[6].Value.ToString());

                }

                //txt_Department.Enabled = false;  // khong hieu sao no tu dong true???, nen phai set cho no false
            }
        }

        private void ResetInterface(bool init)
        {
            if (init)
            {
                Program.DkButton(new Button[] { btn_Them, btn_Sua, btn_Xoa }, new Button[] { btn_Luu, btn_Huy });
                Program.DkControl(new Object[] { txt_TenVietTat, txt_Ten, comB_TrucThuoc, cb_HoatDong, dTP_TuNgay, dTP_DenNgay, rTB_GhiChu}, false, "Enable");
                dtgv_DSDonVi.Enabled = true;
                if (dtgv_DSDonVi.CurrentRow != null)
                    DisplayInfo(dtgv_DSDonVi.CurrentRow);
            }
            else
            {
                Program.DkControl(new Object[] { txt_TenVietTat, txt_Ten, comB_TrucThuoc, cb_HoatDong, dTP_TuNgay, dTP_DenNgay, rTB_GhiChu }, true, "Enable");
                Program.DkButton(new Button[] { btn_Luu, btn_Huy }, new Button[] { btn_Them, btn_Sua, btn_Xoa });
                txt_Ten.Focus();
                dtgv_DSDonVi.Enabled = false;
                if (AddFlag) // thao tac them moi xoa rong cac field
                {
                    txt_TenVietTat.Text = txt_Ten.Text = comB_TrucThuoc.Text = rTB_GhiChu.Text = "";
                    cb_HoatDong.Checked = false;
                }
            }
        }

        private void LoadCboDonViTrucThuoc()
        {
            DataTable dvlist = donvi.GetActiveDonVi();
            BindingSource bs = new BindingSource();
            bs.DataSource = dvlist;
            bs.AddNew();
            comB_TrucThuoc.DataSource = bs;
            comB_TrucThuoc.DisplayMember = "ten_don_vi";
            comB_TrucThuoc.ValueMember = "id";
        }

        private void RefreshDataSource()
        {
            donvi = new DonVi();
            DataTable dt = donvi.GetDonViDetailList();
            if (dt != null)
            {
                PrepareDataSource(dt);
                EditDtgInterface();
            }
        }

        #endregion

        private void dtgv_DSDonVi_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSDonVi.CurrentRow != null)
                DisplayInfo(dtgv_DSDonVi.CurrentRow);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            AddFlag = true;
            ResetInterface(false);
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            AddFlag = false;
            ResetInterface(false);
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ResetInterface(true);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgv_DSDonVi.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá ngành này? TOÀN BỘ CÁC SINH VIÊN THUỘC NGÀNH NÀY SẼ BỊ XOÁ THEO.", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //vanbang = ToDepartmentObject(dtg_DepartmentList.CurrentRow);
                    donvi = new DonVi(Convert.ToInt16(dtgv_DSDonVi.CurrentRow.Cells[0].Value.ToString()));
                    try
                    {
                        donvi.Delete();
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

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (txt_Ten.Text != "" && (txt_Ten.Text != comB_TrucThuoc.Text))
            {
                #region thao tac them
                if (AddFlag)
                {
                    if (MessageBox.Show("Bạn thực sự muốn thêm ngành này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Department = ToDepartmentObject();
                        int? id = null;
                        string tendvviettat = txt_TenVietTat.Text;
                        string tendv = txt_Ten.Text;
                        string ghichu = rTB_GhiChu.Text;
                        
                        int? dvtructhuoc = null;
                        if (comB_TrucThuoc.SelectedValue.ToString() != "")
                        {
                            dvtructhuoc = Convert.ToInt16(comB_TrucThuoc.SelectedValue);
                        }

                        DateTime? tungay = null;
                        if (dTP_TuNgay.Checked == true)
                            tungay = dTP_TuNgay.Value;

                        DateTime? denngay = null;
                        if (dTP_DenNgay.Checked == true)
                            denngay = dTP_DenNgay.Value;

                        bool hoatdong = false;
                        if (cb_HoatDong.Checked == true)
                            hoatdong = true;

                        donvi = new DonVi(id, tendvviettat, tendv, dvtructhuoc, tungay, denngay, hoatdong, ghichu);
                        try
                        {
                            donvi.Add();
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
                    if (MessageBox.Show("Bạn thực sự muốn sửa ngành này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int? id = Convert.ToInt16(dtgv_DSDonVi.CurrentRow.Cells[0].Value.ToString());
                        string tendvviettat = txt_TenVietTat.Text;
                        string tendv = txt_Ten.Text;
                        string ghichu = rTB_GhiChu.Text;

                        int? dvtructhuoc = null;
                        if (comB_TrucThuoc.SelectedValue.ToString() != "")
                        {
                            dvtructhuoc = Convert.ToInt16(comB_TrucThuoc.SelectedValue);
                        }

                        DateTime? tungay = null;
                        if (dTP_TuNgay.Checked == true)
                            tungay = dTP_TuNgay.Value;

                        DateTime? denngay = null;
                        if (dTP_DenNgay.Checked == true)
                            denngay = dTP_DenNgay.Value;

                        bool hoatdong = false;
                        if (cb_HoatDong.Checked == true)
                            hoatdong = true;

                        donvi = new DonVi(id, tendvviettat, tendv, dvtructhuoc, tungay, denngay, hoatdong, ghichu);
                        if (id != dvtructhuoc)
                        {
                            try
                            {
                                donvi.Update();
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
                        else
                            MessageBox.Show("Đơn vị cập nhật và đơn vị trực thuộc là một. Vui lòng chọn lại đơn vị trực thuộc khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                #endregion
            }
            else
                MessageBox.Show("Tên ngành không được rỗng, xin vui lòng cung cấp tên ngành", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
