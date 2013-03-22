using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;

namespace QLNS.UCs.DanhMucThongTin
{
    public partial class QLNS_DienBienSK : UserControl
    {
        Business.CNVC.CNVC_DienBienSK suckhoe;
        public DataTable dtDienBienSK;
        bool AddFlag;   // xac dinh thao tac add hay edit
        string ma_nv = "";

        public QLNS_DienBienSK()
        {
            InitializeComponent();
            suckhoe = new Business.CNVC.CNVC_DienBienSK();
            dtDienBienSK = new DataTable();
        }

        public QLNS_DienBienSK(string p_ma_nv)
        {
            InitializeComponent();
            suckhoe = new Business.CNVC.CNVC_DienBienSK();
            ma_nv = p_ma_nv;
            suckhoe.MaNV = p_ma_nv;
        }

        private void QLNS_DienBienSK_Load(object sender, EventArgs e)
        {
            ResetInterface(true);
        }

        #region Hàm phụ

        public void GetData(string p_ma_nv)
        {
            suckhoe.MaNV = p_ma_nv;
            dtDienBienSK = suckhoe.GetData();
            if (dtDienBienSK.Rows.Count > 0)
            {
                PrepareDataSource(dtDienBienSK.Copy());
                EditDtgInterface();
            }
        }

        private void PrepareDataSource(DataTable dt)
        {
            //LoadCboDonViTrucThuoc();
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dtgv_DienBienSK.DataSource = bs;
        }

        private void EditDtgInterface()
        {
            //// Dat ten cho cac cot
            dtgv_DienBienSK.Columns["thoi_diem"].HeaderText = "Thời điểm";
            //dtgv_DienBienSK.Columns[3].HeaderText = "Tình trạng";
            //dtgv_DienBienSK.Columns[2].Width = 150;
            dtgv_DienBienSK.Columns["can_nang"].HeaderText = "Cân nặng";
            //dtgv_DienBienSK.Columns[4].Width = 200;
            dtgv_DienBienSK.Columns["bo_mo"].HeaderText = "Bộ mỡ";
            dtgv_DienBienSK.Columns["cngan_sgot"].HeaderText = "CNGAN_SGOT";
            dtgv_DienBienSK.Columns["cngan_sgpt"].HeaderText = "CNGAN_SGPT";
            dtgv_DienBienSK.Columns["viemgan_hbsag"].HeaderText = "VIEMGAN_HBSAG";
            dtgv_DienBienSK.Columns["viemgan_hbsab"].HeaderText = "VIEMGAN_HBSAB";
            dtgv_DienBienSK.Columns["viemgan_hcvab"].HeaderText = "VIEMGAN_HCVAB";
            dtgv_DienBienSK.Columns["tsh"].HeaderText = "TSH";
            dtgv_DienBienSK.Columns["ft4"].HeaderText = "FT4";
            dtgv_DienBienSK.Columns["afp"].HeaderText = "AFP";
            dtgv_DienBienSK.Columns["cea"].HeaderText = "CEA";
            dtgv_DienBienSK.Columns["psa"].HeaderText = "PSA";
            dtgv_DienBienSK.Columns["hp_dinh_luong"].HeaderText = "HP Định lượng";
            dtgv_DienBienSK.Columns["tptnt"].HeaderText = "TPTNT";
            dtgv_DienBienSK.Columns["phan_loai"].HeaderText = "Phân loại";
            dtgv_DienBienSK.Columns["ket_luan"].HeaderText = "Kết luận";
            dtgv_DienBienSK.Columns["de_nghi"].HeaderText = "Đề nghị";


            // An cac cot ID
            dtgv_DienBienSK.Columns["id"].Visible = false;
            dtgv_DienBienSK.Columns["ma_nv"].Visible = false;

        }

        private void ResetInterface(bool init)
        {
            if (init)
            {
                Program.DkButton(new Button[] { btn_Them, btn_Sua, btn_Xoa }, new Button[] { btn_Luu, btn_Huy });
                Program.DkControl(new Object[] { txt_BoMo, txt_SGOT, txt_SGPT, txt_HBsAG, txt_HbsAb, txt_HCVAb, txt_TSH, txt_FT4, txt_AFP, txt_CEA, txt_PSA, txt_HPDinhLuong, txt_TPTNT, txt_CanNang, rtb_KetLuan, rtb_DeNghi, dTP_ThoiDiem, txt_PhanLoai }, false, "Enable");
                dtgv_DienBienSK.Enabled = true;
                if (dtgv_DienBienSK.CurrentRow != null)
                    DisplayInfo(dtgv_DienBienSK.CurrentRow);
            }
            else
            {
                Program.DkControl(new Object[] { txt_BoMo, txt_SGOT, txt_SGPT, txt_HBsAG, txt_HbsAb, txt_HCVAb, txt_TSH, txt_FT4, txt_AFP, txt_CEA, txt_PSA, txt_HPDinhLuong, txt_TPTNT, txt_CanNang, rtb_KetLuan, rtb_DeNghi, dTP_ThoiDiem, txt_PhanLoai }, true, "Enable");
                Program.DkButton(new Button[] { btn_Luu, btn_Huy }, new Button[] { btn_Them, btn_Sua, btn_Xoa });
                //txt_Ten.Focus();
                dtgv_DienBienSK.Enabled = false;
                if (AddFlag) // thao tac them moi xoa rong cac field
                {
                    //txt_TenVietTat.Text = txt_Ten.Text = comB_TrucThuoc.Text = rTB_GhiChu.Text = "";
                    //cb_HoatDong.Checked = false;
                    txt_BoMo.Text = txt_SGOT.Text = txt_SGPT.Text = txt_HBsAG.Text = txt_HbsAb.Text = txt_HCVAb.Text = txt_TSH.Text = txt_FT4.Text = txt_AFP.Text = txt_CEA.Text = txt_PSA.Text = txt_HPDinhLuong.Text = txt_TPTNT.Text = txt_CanNang.Text = rtb_KetLuan.Text = rtb_DeNghi.Text = txt_PhanLoai.Text = "";
                    dTP_ThoiDiem.Checked = true;
                    dTP_ThoiDiem.Value = DateTime.Now;

                }
            }
        }

        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                if (row.Cells["thoi_diem"].Value.ToString() != "")
                {
                    DateTime dt = Convert.ToDateTime(row.Cells["thoi_diem"].Value.ToString());
                    dTP_ThoiDiem.Value = dt;
                    dTP_ThoiDiem.Checked = true;
                }
                else
                {
                    dTP_ThoiDiem.Checked = false;
                }
                
                txt_CanNang.Text = row.Cells["can_nang"].Value.ToString();
                txt_BoMo.Text = row.Cells["bo_mo"].Value.ToString();
                txt_SGOT.Text = row.Cells["cngan_sgot"].Value.ToString();
                txt_SGPT.Text = row.Cells["cngan_sgpt"].Value.ToString();
                txt_HBsAG.Text = row.Cells["viemgan_hbsag"].Value.ToString();
                txt_HbsAb.Text = row.Cells["viemgan_hbsab"].Value.ToString();
                txt_HCVAb.Text = row.Cells["viemgan_hcvab"].Value.ToString();
                txt_TSH.Text = row.Cells["tsh"].Value.ToString();
                txt_FT4.Text = row.Cells["ft4"].Value.ToString();
                txt_AFP.Text = row.Cells["afp"].Value.ToString();
                txt_CEA.Text = row.Cells["cea"].Value.ToString();
                txt_PSA.Text = row.Cells["psa"].Value.ToString();
                txt_HPDinhLuong.Text = row.Cells["hp_dinh_luong"].Value.ToString();
                txt_TPTNT.Text = row.Cells["tptnt"].Value.ToString();
                txt_PhanLoai.Text = row.Cells["phan_loai"].Value.ToString();
                rtb_KetLuan.Text = row.Cells["ket_luan"].Value.ToString();
                rtb_DeNghi.Text = row.Cells["de_nghi"].Value.ToString();
            }
        }

        private void RefreshDataSource()
        {
            //suckhoe = new Business.CNVC.CNVC_DienBienSK();
            suckhoe.MaNV = Program.selected_ma_nv;
            dtDienBienSK = suckhoe.GetData();
            if (dtDienBienSK.Rows.Count > 0)
            {
                PrepareDataSource(dtDienBienSK.Copy());
                EditDtgInterface();
            }
        }

        #endregion

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

        private void dtgv_DienBienSK_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DienBienSK.CurrentRow != null)
                DisplayInfo(dtgv_DienBienSK.CurrentRow);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgv_DienBienSK.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá thông tin diễn biến sức khỏe này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //vanbang = ToDepartmentObject(dtg_DepartmentList.CurrentRow);
                    suckhoe = new Business.CNVC.CNVC_DienBienSK(Convert.ToInt16(dtgv_DienBienSK.CurrentRow.Cells[0].Value.ToString()));
                    try
                    {
                        suckhoe.Delete();
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
            #region thao tac them
            if (AddFlag)
            {
                if (MessageBox.Show("Bạn thực sự muốn thêm diễn biến sức khỏe của nhân viên?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    suckhoe.MaNV = Program.selected_ma_nv;
                    suckhoe.BoMo = txt_BoMo.Text;
                    suckhoe.CNGAN_SGPT = txt_SGPT.Text;
                    suckhoe.CNGAN_SGOT = txt_SGOT.Text;
                    suckhoe.ViemGan_HBSAB = txt_HbsAb.Text;
                    suckhoe.ViemGan_HBSAG = txt_HBsAG.Text;
                    suckhoe.ViemGan_HCVAB = txt_HCVAb.Text;
                    suckhoe.TSH = txt_TSH.Text;
                    suckhoe.FT4 = txt_FT4.Text;
                    suckhoe.AFP = txt_AFP.Text;
                    suckhoe.CEA = txt_CEA.Text;
                    suckhoe.PSA = txt_PSA.Text;
                    suckhoe.HP_Dinh_Luong = txt_HPDinhLuong.Text;
                    suckhoe.TPTNT = txt_TPTNT.Text;
                    suckhoe.PhanLoai = txt_PhanLoai.Text;
                    suckhoe.CanNang = txt_CanNang.Text;
                    if (dTP_ThoiDiem.Checked)
                        suckhoe.ThoiDiem = Convert.ToDateTime(dTP_ThoiDiem.Value.ToShortDateString());
                    else
                        suckhoe.ThoiDiem = null;
                    suckhoe.DeNghi = rtb_DeNghi.Text;
                    suckhoe.KetLuan = rtb_KetLuan.Text;

                    suckhoe.Add();
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetInterface(true);
                    RefreshDataSource();
                }

            }
            #endregion

            #region thao tac sua
            else                // thao tac sua
            {
                if (MessageBox.Show("Bạn thực sự muốn sửa diễn biến sức khỏe này của nhân viên?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    suckhoe = new Business.CNVC.CNVC_DienBienSK();
                    suckhoe.MaNV = ma_nv;
                    suckhoe.BoMo = txt_BoMo.Text;
                    suckhoe.CNGAN_SGPT = txt_SGPT.Text;
                    suckhoe.CNGAN_SGOT = txt_SGOT.Text;
                    suckhoe.ViemGan_HBSAB = txt_HbsAb.Text;
                    suckhoe.ViemGan_HBSAG = txt_HBsAG.Text;
                    suckhoe.ViemGan_HCVAB = txt_HCVAb.Text;
                    suckhoe.TSH = txt_TSH.Text;
                    suckhoe.FT4 = txt_FT4.Text;
                    suckhoe.AFP = txt_AFP.Text;
                    suckhoe.CEA = txt_CEA.Text;
                    suckhoe.PSA = txt_PSA.Text;
                    suckhoe.HP_Dinh_Luong = txt_HPDinhLuong.Text;
                    suckhoe.TPTNT = txt_TPTNT.Text;
                    suckhoe.PhanLoai = txt_PhanLoai.Text;
                    suckhoe.CanNang = txt_CanNang.Text;
                    suckhoe.ThoiDiem = Convert.ToDateTime(dTP_ThoiDiem.Value.ToShortDateString());
                    suckhoe.DeNghi = rtb_DeNghi.Text;
                    suckhoe.KetLuan = rtb_KetLuan.Text;

                    suckhoe.ID = Convert.ToInt16(dtgv_DienBienSK.CurrentRow.Cells[0].Value.ToString());
                    suckhoe.Update();

                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetInterface(true);
                    RefreshDataSource();
                }
            }
            #endregion
        }
    }
}
