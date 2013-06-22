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
    public partial class LoaiPhuCap : UserControl
    {
        bool? bAddLoaiPCFlag , bAddCachTinhFlag;
        Business.HDQD.LoaiPhuCap oLoaiPhuCap;
        DataTable dtDSLoaiPhuCap,dtDSCachTinhDetail;


        public LoaiPhuCap()
        {
            InitializeComponent();
            oLoaiPhuCap = new Business.HDQD.LoaiPhuCap();
        }

        private void LoaiPhuCap_Load(object sender, EventArgs e)
        {
            dtDSLoaiPhuCap = oLoaiPhuCap.GetList();
            dtDSCachTinhDetail = oLoaiPhuCap.GetListCachTinhDetail();
            
            

            if (dtDSLoaiPhuCap != null)
            {
                PrepareDataSource();
                //EditDtgInterface();
                
            }
        }

        #region Private methods
        
        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtDSLoaiPhuCap;
            //dtgv_DSLoaiPC.DataSource = bs;
            //lbl_SoLoaiPC.Text = dtgv_DSLoaiPC.Rows.Count.ToString();
            if (dtDSLoaiPhuCap != null)
            {
                btn_Sua.Visible = btn_Xoa.Visible = true;
            }
            BindLoaiPCToLstB();
        }

        /// <summary>
        /// Sua ten, an  cac cot cua dtg cho phu hop
        /// </summary>
        private void BindLoaiPCToLstB()
        {
            lstb_DS.DataSource = dtDSLoaiPhuCap;
            lstb_DS.DisplayMember = "ten_loai";
            lstb_DS.ValueMember = "id";
            lstb_DS.ClearSelected();
        }

        /// <summary>
        /// Su dung thong tin row dang chon de hien thi len txt, comb,..
        /// </summary>
        /// <param name="row"></param>
        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_Ten.Text = row.Cells[1].Value.ToString();
                txt_TenVietTat.Text = row.Cells[2].Value.ToString();
                rTB_MoTa.Text = row.Cells[3].Value.ToString();
            }
        }

        /// <summary>
        /// Refresh Data Source cho dtg sau moi lan thao tac
        /// </summary>
        private void RefreshDataSource()
        {
            Business.HDQD.LoaiPhuCap loaipc = new Business.HDQD.LoaiPhuCap();    
            dtDSLoaiPhuCap = loaipc.GetList();
            PrepareDataSource();

        }

        #endregion

        

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            bAddLoaiPCFlag = false;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ButtonControl(true);
            LoaiPCControls(false);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (bAddLoaiPCFlag == true)
            {
                if (!string.IsNullOrWhiteSpace(txt_Ten.Text))
                {
                    #region thao tac them loai pc
                        if (MessageBox.Show("Bạn thực sự muốn thêm loại phụ cấp này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            oLoaiPhuCap.TenLoaiPhuCap = txt_Ten.Text.Trim();
                            oLoaiPhuCap.TenLoaiPC_Viettat = txt_TenVietTat.Text.Trim();
                            oLoaiPhuCap.MoTa = rTB_MoTa.Text.Trim();
                            try
                            {
                                if (oLoaiPhuCap.Add())
                                {
                                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                RefreshDataSource();
                                ButtonControl(true);
                                LoaiPCControls(false);
                                CachTinhControls(false);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Thao tác thêm thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    
                    #endregion
                    
                }
                else
                    MessageBox.Show("Tên loại phụ cấp không được rỗng, xin vui lòng cung cấp tên loại phụ cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (bAddLoaiPCFlag == false)
            {
                #region thao tac sua loai pc
                if (MessageBox.Show("Bạn thực sự muốn sửa loại phụ cấp này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oLoaiPhuCap.ID = Convert.ToInt16(lstb_DS.SelectedValue);
                    oLoaiPhuCap.TenLoaiPhuCap = txt_Ten.Text.Trim();
                    oLoaiPhuCap.TenLoaiPC_Viettat = txt_TenVietTat.Text.Trim();
                    oLoaiPhuCap.MoTa = rTB_MoTa.Text.Trim();
                    try
                    {
                        if (oLoaiPhuCap.Update())
                        {
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                        RefreshDataSource();
                        ButtonControl(true);
                        LoaiPCControls(false);
                        CachTinhControls(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thao tác sửa thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                #endregion
            }
                    
           
            

            if (bAddCachTinhFlag == true)
            {

            }
            else if (bAddCachTinhFlag == false)
            {

            }

            
        }

        private void rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Enabled)
            {
                switch (((RadioButton)sender).Name)
                {
                    case "rdb_Khoan":
                        ChangeCachTinhInterface(1);
                        break;
                    case "rdb_HeSo":
                        ChangeCachTinhInterface(2);
                        break;

                    case "rdb_CongThuc":
                        ChangeCachTinhInterface(3);
                        break;
                    default:
                        break;
                }
            }
            
        }

        private void btn_ThietLap_Click(object sender, EventArgs e)
        {
            Forms.Popup frPopup = new Forms.Popup(new UCs.DinhNghiaCT(), "QUẢN LÝ NHÂN SỰ - ĐỊNH NGHĨA CÔNG THỨC TÍNH PHỤ CẤP");
            frPopup.ShowDialog();
        }


        private void rtb_CongThuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearUICachTinh();
            try
            {
                if (lstb_DS.SelectedItem != null)
                {
                    int n = Convert.ToInt16(lstb_DS.SelectedValue.ToString());
                    txt_Ten.Text = dtDSLoaiPhuCap.AsEnumerable().Where(a => a.Field<int>("id") == n).Select(a => a.Field<string>("ten_loai")).First();
                    txt_TenVietTat.Text = dtDSLoaiPhuCap.AsEnumerable().Where(a => a.Field<int>("id") == n).Select(a => a.Field<string>("ten_viet_tat")).First();
                    rTB_MoTa.Text = dtDSLoaiPhuCap.AsEnumerable().Where(a => a.Field<int>("id") == n).Select(a => a.Field<string>("mo_ta")).First();
                }

                if (dtDSCachTinhDetail != null && dtDSCachTinhDetail.AsEnumerable().Where(a => a.Field<int>("loai_pc_id") == Convert.ToInt16(lstb_DS.SelectedValue)).Count() > 0)
                {
                    BindDataForDTGV(dtDSCachTinhDetail.AsEnumerable().Where(a => a.Field<int>("loai_pc_id") == Convert.ToInt16(lstb_DS.SelectedValue)).CopyToDataTable());
                    if (dtgv_DS.DataSource != null)
                        SetupDTGV();
                }
                else
                {
                    dtgv_DS.DataSource = null;
                }
            }
            catch (Exception)
            {
            }
            
        }

        private void BindDataForDTGV(DataTable dt)
        {
            dtgv_DS.DataSource = dt;
            dtgv_DS.ClearSelection();
        }

        private void SetupDTGV()
        {
            dtgv_DS.Columns["chuoi_cong_thuc"].Visible = dtgv_DS.Columns["cach_tinh"].Visible = dtgv_DS.Columns["loai_pc_id"].Visible = false;
            dtgv_DS.Columns["id"].Visible = false;

            dtgv_DS.Columns["cach_tinh_text"].HeaderText = "Cách tính";
            dtgv_DS.Columns["cach_tinh_text"].Width = 250;
            dtgv_DS.Columns["tu_ngay"].HeaderText = "Từ ngày";
            dtgv_DS.Columns["tu_ngay"].Width = 100;
            dtgv_DS.Columns["den_ngay"].HeaderText = "Đến ngày";
            dtgv_DS.Columns["den_ngay"].Width = 100;
            dtgv_DS.Columns["ghi_chu"].HeaderText = "Ghi chú";
            dtgv_DS.Columns["ghi_chu"].Width = 300;
            dtgv_DS.Columns["ngay_tao"].HeaderText = "Ngày tạo";
            dtgv_DS.Columns["ngay_tao"].Width = 100;
        }

        private void ChangeCachTinhInterface(int nCachTinh)
        {
            switch (nCachTinh)
            {
                case 1:
                    TLP_CachTinh.Visible = false;
                    rdb_Khoan.Checked = true;
                    break;
                case 2:
                    TLP_CachTinh.Visible = true;
                    lb_HeSo.Visible = comb_Luong.Visible = true;
                    TLP_CachTinh.RowStyles[1].SizeType = TLP_CachTinh.RowStyles[0].SizeType = SizeType.Percent;
                    TLP_CachTinh.RowStyles[1].Height = 1;
                    comb_Luong.Text = "Lương cơ bản";
                    TLP_CachTinh.RowStyles[0].Height = 99;
                    rdb_HeSo.Checked = true;
                    break;

                case 3:
                    TLP_CachTinh.Visible = true;
                    lb_HeSo.Visible = comb_Luong.Visible = true;
                    TLP_CachTinh.RowStyles[1].SizeType = TLP_CachTinh.RowStyles[0].SizeType = SizeType.Percent;
                    TLP_CachTinh.RowStyles[1].Height = 1;
                    TLP_CachTinh.RowStyles[0].Height = 99;
                    comb_Luong.Text = "Lương tối thiểu";
                    rdb_HeSo.Checked = true;
                    break;

                case 4:
                    TLP_CachTinh.Visible = true;
                    lb_HeSo.Visible = comb_Luong.Visible = false;
                    TLP_CachTinh.RowStyles[0].SizeType = TLP_CachTinh.RowStyles[1].SizeType = SizeType.Percent;
                    TLP_CachTinh.RowStyles[0].Height = 1;
                    TLP_CachTinh.RowStyles[1].Height = 99;
                    rdb_CongThuc.Checked = true;
                    
                    break;
            }
        }

        private void dtgv_DS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ClearUILoaiPC();
            try
            {
                if (dtgv_DS.SelectedRows != null)
                {
                    DataRow dr = dtDSCachTinhDetail.AsEnumerable().Where(a => a.Field<int>("id") == Convert.ToInt16(dtgv_DS.SelectedRows[0].Cells["id"].Value)).First();

                    dTP_TuNgay.Value = Convert.ToDateTime(dr["tu_ngay"]);

                    if (dr["den_ngay"].ToString() != "")
                    {
                        dtp_DenNgay.Checked = true;
                        dtp_DenNgay.Value = Convert.ToDateTime(dr["den_ngay"].ToString());
                    }
                    else
                    {
                        dtp_DenNgay.Checked = false;
                    }

                    rtb_GhiChu.Text = Convert.ToString(dr["ghi_chu"]);
                    rtb_CongThuc.Text = Convert.ToString(dr["chuoi_cong_thuc"]);

                    switch (Convert.ToInt16(dr["cach_tinh"]))
                    {
                        case 1:
                            ChangeCachTinhInterface(1);
                            break;
                        case 2:
                            ChangeCachTinhInterface(2);
                            break;
                        case 3:
                            ChangeCachTinhInterface(3);
                            break;
                        case 4:
                            ChangeCachTinhInterface(4);
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TSMI_ThemLoaiPC_Click(object sender, EventArgs e)
        {
            bAddLoaiPCFlag = true;
            bAddCachTinhFlag = null;

            LoaiPCControls(true);
            ButtonControl(false);
            CachTinhControls(false);
            ClearUICachTinh();
            ClearUILoaiPC();
        }

        private void LoaiPCControls(bool bEnable)
        {
            txt_Ten.Enabled = txt_TenVietTat.Enabled = rTB_MoTa.Enabled = bEnable;
            lstb_DS.Enabled = !bEnable;
        }

        private void CachTinhControls(bool bEnable)
        {
            gb_CachTinh.Enabled = bEnable;
        }

        private void ButtonControl(bool Init)
        {
            splitButton1.Visible = btn_Sua.Visible = btn_Xoa.Visible = Init;
            btn_Luu.Visible = btn_Huy.Visible = !Init;
        }

        private void ClearUILoaiPC()
        {
            txt_Ten.Text = txt_TenVietTat.Text = rTB_MoTa.Text = "";
            lstb_DS.ClearSelected();
        }

        private void ClearUICachTinh()
        {
            dtp_DenNgay.Checked = false;
            rtb_GhiChu.Text = "";
            rdb_Khoan.Checked = true;
            ChangeCachTinhInterface(1);
            rtb_CongThuc.Text = "";
            dtgv_DS.ClearSelection();
        }

        private void TSMI_SuaLoaiPC_Click(object sender, EventArgs e)
        {
            bAddLoaiPCFlag = false;
            bAddCachTinhFlag = null;
            LoaiPCControls(true);
            ButtonControl(false);
            CachTinhControls(false);
            //ClearUICachTinh();
            //ClearUILoaiPC();

        }

        private void TSMI_SuaCachTinh_Click(object sender, EventArgs e)
        {
            bAddLoaiPCFlag = true;
            bAddCachTinhFlag = null;
        }

        private void TSMI_XoaLoaiPC_Click(object sender, EventArgs e)
        {
            if (lstb_DS.SelectedItem != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá loại phụ cấp \"" + lstb_DS.Text.ToString() + "\" ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oLoaiPhuCap.ID = Convert.ToInt16(lstb_DS.SelectedValue);
                        if (oLoaiPhuCap.Delete())
                        {
                            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        RefreshDataSource();
                        ClearUILoaiPC();
                        ClearUICachTinh();
                        dtgv_DS.DataSource = null;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xóa không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
