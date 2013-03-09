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
        bool AddFlag;   // xac dinh thao tac add hay edit
        string ma_nv = "";

        public QLNS_DienBienSK()
        {
            InitializeComponent();
            suckhoe = new Business.CNVC.CNVC_DienBienSK();
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
            //suckhoe.MaNV = "1";
            DataTable dt = suckhoe.GetData();
            if (dt != null)
            {
                PrepareDataSource(dt);
                EditDtgInterface();
            }

            ResetInterface(true);
        }

        #region Hàm phụ

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
            dtgv_DienBienSK.Columns[2].HeaderText = "Thời điểm";
            //dtgv_DienBienSK.Columns[3].HeaderText = "Tình trạng";
            //dtgv_DienBienSK.Columns[2].Width = 150;
            dtgv_DienBienSK.Columns[3].HeaderText = "Cân nặng";
            //dtgv_DienBienSK.Columns[4].Width = 200;
            dtgv_DienBienSK.Columns[4].HeaderText = "Bộ mỡ";
            dtgv_DienBienSK.Columns[5].HeaderText = "CNGAN_SGOT";
            dtgv_DienBienSK.Columns[6].HeaderText = "CNGAN_SGPT";
            dtgv_DienBienSK.Columns[7].HeaderText = "VIEMGAN_HBSAG";
            dtgv_DienBienSK.Columns[8].HeaderText = "VIEMGAN_HBSAB";
            dtgv_DienBienSK.Columns[9].HeaderText = "VIEMGAN_HCVAB";
            dtgv_DienBienSK.Columns[10].HeaderText = "TSH";
            dtgv_DienBienSK.Columns[11].HeaderText = "FT4";
            dtgv_DienBienSK.Columns[12].HeaderText = "AFP";
            dtgv_DienBienSK.Columns[13].HeaderText = "CEA";
            dtgv_DienBienSK.Columns[14].HeaderText = "PSA";
            dtgv_DienBienSK.Columns[15].HeaderText = "HP Định lượng";
            dtgv_DienBienSK.Columns[16].HeaderText = "TPTNT";
            dtgv_DienBienSK.Columns[17].HeaderText = "Phân loại";
            dtgv_DienBienSK.Columns[18].HeaderText = "Kết luận";
            dtgv_DienBienSK.Columns[19].HeaderText = "Đề nghị";


            // An cac cot ID
            dtgv_DienBienSK.Columns[0].Visible = false;
            dtgv_DienBienSK.Columns[1].Visible = false;

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
                DateTime dt = Convert.ToDateTime(row.Cells[2].Value.ToString());
                dTP_ThoiDiem.Value = dt;
                txt_CanNang.Text = row.Cells[3].Value.ToString();
                txt_BoMo.Text = row.Cells[4].Value.ToString();
                txt_SGOT.Text = row.Cells[5].Value.ToString();
                txt_SGPT.Text = row.Cells[6].Value.ToString();
                txt_HBsAG.Text = row.Cells[7].Value.ToString();
                txt_HbsAb.Text = row.Cells[8].Value.ToString();
                txt_HCVAb.Text = row.Cells[9].Value.ToString();
                txt_TSH.Text = row.Cells[10].Value.ToString();
                txt_FT4.Text = row.Cells[11].Value.ToString();
                txt_AFP.Text = row.Cells[12].Value.ToString();
                txt_CEA.Text = row.Cells[13].Value.ToString();
                txt_PSA.Text = row.Cells[14].Value.ToString();
                txt_HPDinhLuong.Text = row.Cells[15].Value.ToString();
                txt_TPTNT.Text = row.Cells[16].Value.ToString();
                txt_PhanLoai.Text = row.Cells[17].Value.ToString();
                rtb_KetLuan.Text = row.Cells[18].Value.ToString();
                rtb_DeNghi.Text = row.Cells[19].Value.ToString();
            }
        }

        private void RefreshDataSource()
        {
            suckhoe = new Business.CNVC.CNVC_DienBienSK();
            suckhoe.MaNV = ma_nv;
            DataTable dt = suckhoe.GetData();
            if (dt != null)
            {
                PrepareDataSource(dt);
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
                if (MessageBox.Show("Bạn thực sự muốn xoá ngành này? TOÀN BỘ CÁC SINH VIÊN THUỘC NGÀNH NÀY SẼ BỊ XOÁ THEO.", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                if (MessageBox.Show("Bạn thực sự muốn thêm diễn biến sức khỏe của nhân viên này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
