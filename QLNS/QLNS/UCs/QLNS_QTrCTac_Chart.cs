using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLNS.UCs
{
    public partial class QLNS_QTrCTac_Chart : UserControl
    {
        DataTable dt_original, dt_binding, dt_TimeFilter, dt_CateFilter;
        DataTable dt_DonVi, dt_ChucVu, dt_ChucDanh;
        DateTime? dOldFrom, dOldTo;
        //int nOld_DonViID = 0, nOld_ChucDanhID = 0, nOld_ChucVuID = 0; // id cũ để dùng khi check cần fải filter mới hay o
        //enum RDs_State { All, Active, InActive }; 
        int nSelectedID, nOldDonViID;
        enum DTPs_State { Both, One, None };
        DTPs_State dtp_state;
        //RDs_State rd_state;
        Business.CNVC.CNVC oCNVC;
        Business.DonVi oDonVi;
        Business.ChucDanh oChucDanh;
        Business.ChucVu oChucVu;
        Business.CNVC.CNVC_QTr_CongTac_OU oCNVC_QTr_CongTac_OU;
        bool bAddFlag;
        HitTestResult result;

        private void InitObject(string p_manv = null)
        {
            dtp_state = DTPs_State.None;
            //rd_state = RDs_State.All;
            oCNVC = new Business.CNVC.CNVC();
            oChucDanh = new Business.ChucDanh();
            oCNVC_QTr_CongTac_OU = new Business.CNVC.CNVC_QTr_CongTac_OU();
            oChucVu = new Business.ChucVu();
            oDonVi = new Business.DonVi();
            oCNVC.MaNV = p_manv;
            dOldFrom = dOldTo = null;
            dt_original = new DataTable();
            dt_binding = new DataTable();
            dt_TimeFilter = new DataTable();
            dt_CateFilter = new DataTable();
            dt_DonVi = new DataTable();
            dt_ChucDanh = new DataTable();
            dt_ChucVu = new DataTable();
        }

        public QLNS_QTrCTac_Chart(string p_manv)
        {
            InitializeComponent();
            InitObject(p_manv);

        }

        public QLNS_QTrCTac_Chart()
        {
            InitializeComponent();
            InitObject();

        }

        private void QLNS_QTrCTac_Chart_Load(object sender, EventArgs e)
        {
           

            GetDataSourceForCombo();
            BindDataForCombo();

            if (oCNVC.MaNV != null)
            {
                GetData_QtrCTac();
                RegenerateChart();
            }
            
        }





        private void GetData_QtrCTac()
        {
            try
            {
                dt_original = oCNVC.GetQtrCtacOUDT();
                if (dt_original.Rows.Count > 0)
                {
                    txt_MaNV.Text = dt_original.AsEnumerable().Select(b => b.Field<string>("ma_nv")).First().ToString();
                    txt_Ho.Text = dt_original.AsEnumerable().Select(b => b.Field<string>("ho")).First().ToString();
                    txt_Ten.Text = dt_original.AsEnumerable().Select(b => b.Field<string>("ten")).First().ToString();
                    dt_binding = dt_original.Copy();
                    dt_CateFilter = dt_original.Copy();
                    dt_TimeFilter = dt_original.Copy();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void GetDataSourceForCombo()
        {
            try
            {
                dt_ChucVu = oChucVu.GetList();
                dt_DonVi = oDonVi.GetDonViList();
                dt_ChucDanh = oChucDanh.GetList();
            }
            catch (Exception)
            {
                
            }
        }

        private void BindDataForCombo()
        {
            if (dt_ChucDanh.Rows.Count > 0)
            {
                DataTable dt = dt_ChucDanh.Copy();
                cb_ChucDanh.DataSource = dt;
                cb_ChucDanh.DisplayMember = "ten_chuc_danh";
                cb_ChucDanh.ValueMember = "id";
                cb_ChucDanh.SelectedValue = -1;

                DataTable dt2 = dt_ChucDanh.Copy();
                dt2.Rows[0]["id"] = 0;
                dt2.Rows[0]["ten_chuc_danh"] = "Tất cả";
                cb_ChucDanh_Filter.DataSource = dt2;
                cb_ChucDanh_Filter.DisplayMember = "ten_chuc_danh";
                cb_ChucDanh_Filter.ValueMember = "id";
                cb_ChucDanh.SelectedValue = 0;
            }

            if (dt_ChucVu.Rows.Count > 0)
            {
                DataTable dt = dt_ChucVu.Copy();
                cb_ChucVu.DataSource = dt;
                cb_ChucVu.DisplayMember = "ten_chuc_vu";
                cb_ChucVu.ValueMember = "id";
                cb_ChucVu.SelectedValue = -1;

                DataTable dt2 = dt_ChucVu.Copy();
                dt2.Rows[0]["id"] = 0;
                dt2.Rows[0]["ten_chuc_vu"] = "Tất cả";
                cb_ChucVu_Filter.DataSource = dt2;
                cb_ChucVu_Filter.DisplayMember = "ten_chuc_vu";
                cb_ChucVu_Filter.ValueMember = "id";
                cb_ChucVu_Filter.SelectedValue = 0;
            }

            if (dt_DonVi.Rows.Count > 0)
            {
                DataTable dt = dt_DonVi.Copy();
                cb_DonVi.DataSource = dt;
                cb_DonVi.DisplayMember = "ten_don_vi";
                cb_DonVi.ValueMember = "id";

                DataTable dt2 = dt_DonVi.Copy();
                DataRow dr = dt2.NewRow();
                dr["ten_don_vi"] = "Tất cả";
                dr["id"] = 0;
                dt2.Rows.InsertAt(dr, 0);

                cb_DonVi_Filter.DataSource = dt2;
                cb_DonVi_Filter.DisplayMember = "ten_don_vi";
                cb_DonVi_Filter.ValueMember = "id";
                cb_DonVi_Filter.SelectedValue = 0;

            }
            


        }

     
        private void AddSeries()
        {
            int n = chart_QtrCTac.Series.Count;
            for (int i = 0; i < n; i++) 
            {
                chart_QtrCTac.Series.RemoveAt(0);
            }

            var distinct_donvi = (from DataRow dr in dt_binding.Rows
                                  where Convert.ToBoolean(dr["bind"])  == true
                                  select new { ten_don_vi = dr["ten_don_vi"], ten_don_vi_viet_tat = dr["ten_don_vi_viet_tat"] }).Distinct();

            foreach (var r in distinct_donvi)
            {
                chart_QtrCTac.Series.Add(r.ten_don_vi.ToString() + "(" + r.ten_don_vi_viet_tat.ToString() + ")");
                chart_QtrCTac.Series[chart_QtrCTac.Series.Count - 1].Label = r.ten_don_vi_viet_tat.ToString();
            }
        }



        private void SetSeriesDataTypes()
        {
            for (int i = 0; i < chart_QtrCTac.Series.Count; i++)
            {
                chart_QtrCTac.Series[i].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
                chart_QtrCTac.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart_QtrCTac.Series[i].ChartArea = "ChartArea1";
                chart_QtrCTac.Series[i].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                chart_QtrCTac.Series[i].BorderWidth = 3;
                chart_QtrCTac.Series[i].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;

                chart_QtrCTac.Series[i].EmptyPointStyle.BorderWidth = 1;
                chart_QtrCTac.Series[i].EmptyPointStyle.BorderColor = Color.Black;
                chart_QtrCTac.Series[i].EmptyPointStyle.MarkerColor = Color.Red;
                chart_QtrCTac.Series[i].EmptyPointStyle.MarkerSize = 15;
                chart_QtrCTac.Series[i].EmptyPointStyle.MarkerStyle = MarkerStyle.Cross;
                
            }
        }

        private void ClearThongTin()
        {
            cb_ConHD.Checked =  false;
            dtp_DenNgay.Checked = dtp_TuNgay.Checked = false;
            cb_ChucDanh.SelectedValue = cb_ChucVu.SelectedValue
                = cb_DonVi.SelectedValue = -1;

            txt_MaHD.Text = txt_MaQD.Text = "";
        }

        private void AddDataPoint()
        {
            

            for (int i = 0; i < dt_binding.Rows.Count; i++)
            {
                DateTime dFrom = Convert.ToDateTime(dt_binding.Rows[i]["tu_thoi_gian"]);
                DateTime dTo;
                if (dt_binding.Rows[i]["den_thoi_gian"].ToString() == "")
                {
                    dTo = DateTime.Now;
                }
                else
                {
                     dTo = Convert.ToDateTime(dt_binding.Rows[i]["den_thoi_gian"]);
                }
                
                int id = Convert.ToInt32(dt_binding.Rows[i]["id"]);

                string ten_don_vi = dt_binding.Rows[i]["ten_don_vi"].ToString();
                string ten_don_vi_viet_tat = dt_binding.Rows[i]["ten_don_vi_viet_tat"].ToString();
                string ten_series = ten_don_vi + "(" + ten_don_vi_viet_tat + ")";
                
                if (IsSeriesExists(ten_series))
                {
                    if (chart_QtrCTac.Series[ten_series].Points.Count > 1)
                    {
                        chart_QtrCTac.Series[ten_series].Points.AddXY(0, 0);
                        chart_QtrCTac.Series[ten_series].Points[chart_QtrCTac.Series[ten_series].Points.Count - 1].IsEmpty = true;
                    }
                    chart_QtrCTac.Series[ten_series].Points.AddXY(dFrom, chart_QtrCTac.Series.IndexOf(ten_series) + 1);
                    chart_QtrCTac.Series[ten_series].Points[chart_QtrCTac.Series[ten_series].Points.Count - 1].Tag = id.ToString();
                    chart_QtrCTac.Series[ten_series].Points.AddXY(dTo, chart_QtrCTac.Series.IndexOf(ten_series) + 1);
                    chart_QtrCTac.Series[ten_series].Points[chart_QtrCTac.Series[ten_series].Points.Count - 1].Tag = id.ToString();
                }
            }
        }

        private bool IsSeriesExists(string sSeriesName)
        {
            for (int i = 0; i < chart_QtrCTac.Series.Count; i++)
            {
                if (chart_QtrCTac.Series[i].Name == sSeriesName)
                {
                    return true;
                }
            }

            return false;
        }

        private void SetChartXLimit()
        {
            if (dt_binding.AsEnumerable().Where(a => a.Field<Boolean>("bind") == true).Count() > 0)
            {
                DateTime dmax = DateTime.Now;
                if (dt_binding.AsEnumerable().Where(a => a.Field<Boolean>("bind") == true && Convert.ToString(a.Field<DateTime?>("den_thoi_gian")) != "").Count() > 0)
                {
                     dmax = dt_binding.AsEnumerable().Where(a => a.Field<Boolean>("bind") == true && Convert.ToString(a.Field<DateTime?>("den_thoi_gian")) != "").Select(a => a.Field<DateTime>("den_thoi_gian")).Max();
                }



                DateTime dmin = dt_binding.AsEnumerable().Where(a => a.Field<Boolean>("bind") == true).Select(a => a.Field<DateTime>("tu_thoi_gian")).Min();
                chart_QtrCTac.ChartAreas[0].AxisX.Maximum = (dmax.AddMonths(1)).ToOADate();
                chart_QtrCTac.ChartAreas[0].AxisX.Minimum = (dmin.AddMonths(-1)).ToOADate();
            }
        }

        private void JoinFilter()
        {
            for (int i = 0; i < dt_binding.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dt_CateFilter.Rows[i]["bind"]) && Convert.ToBoolean(dt_TimeFilter.Rows[i]["bind"]))
                {
                    dt_binding.Rows[i]["bind"] = true;
                }
                else
                {
                    dt_binding.Rows[i]["bind"] = false;
                }
            }
        }

        private void RegenerateChart()
        {
            AddSeries();
            SetSeriesDataTypes();
            AddDataPoint();
            SetChartXLimit();
        }

        private void chart_QtrCTac_MouseMove(object sender, MouseEventArgs e)
        {
            // Call Hit Test Method
            HitTestResult result = chart_QtrCTac.HitTest(e.X, e.Y);

            // If a Data Point or a Legend item is selected.
            if (result.ChartElementType == ChartElementType.DataPoint ||
                result.ChartElementType == ChartElementType.DataPointLabel)
            {
                // Set cursor type 
                this.Cursor = Cursors.Hand;
            }
            //else if (result.ChartElementType != ChartElementType.Nothing &&
            //    result.ChartElementType != ChartElementType.PlottingArea)
            //{
            //    // Set cursor type 
            //    this.Cursor = Cursors.Hand;
            //}
            else
            {
                // Set default cursor
                this.Cursor = Cursors.Default;
            }
        }

        private void chart_QtrCTac_MouseDown(object sender, MouseEventArgs e)
        {
            // Call Hit Test Method
            result = chart_QtrCTac.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.DataPointLabel)
            {

                ClearThongTin();
                // Show dialog
                //MessageBox.Show(DateTime.FromOADate(chart_QtrCTac.Series[result.Series.Name].Points[result.PointIndex].XValue).ToString());

                nSelectedID = Convert.ToInt32(chart_QtrCTac.Series[result.Series.Name].Points[result.PointIndex].Tag);
                DataRow r = dt_original.AsEnumerable().Where(a => a.Field<int?>("id") == nSelectedID).CopyToDataTable().Rows[0];
                BindThongTin(r);

            }
            //else if (result.ChartElementType != ChartElementType.Nothing)
            //{
            //    string elementType = result.ChartElementType.ToString();
            //    MessageBox.Show(this, "Selected Element is: " + elementType);
            //}
        }

        private void BindThongTin(DataRow r)
        {
            if (r["tu_thoi_gian"].ToString() != "")
            {
                dtp_TuNgay.Checked = true;
                dtp_TuNgay.Value = Convert.ToDateTime(r["tu_thoi_gian"]);
            }
            else
            {
                dtp_TuNgay.Checked = false;
            }

            if (r["den_thoi_gian"].ToString() != "")
            {
                dtp_DenNgay.Checked = true;
                dtp_DenNgay.Value = Convert.ToDateTime(r["den_thoi_gian"]);
            }
            else
            {
                dtp_DenNgay.Checked = false;
            }

            cb_ConHD.Checked = Convert.ToBoolean(r["tinh_trang"]);
            if (r["ma_hop_dong"].ToString() != "")
                txt_MaHD.Text = r["ma_hop_dong"].ToString();
            else
                txt_MaHD.Text = "";

            if (r["ma_quyet_dinh"].ToString() != "")
                txt_MaQD.Text = r["ma_quyet_dinh"].ToString();
            else
                txt_MaQD.Text = "";

            if (r["don_vi_id"].ToString() == "")
                cb_DonVi.SelectedValue = -1;
            else
            {

                cb_DonVi.SelectedValue = nOldDonViID = Convert.ToInt32(r["don_vi_id"].ToString());

                var vDonViDT = from DataRow row in dt_DonVi.Rows
                               where Convert.ToInt32(row["id"]) == Convert.ToInt32(r["don_vi_id"].ToString())
                               select row["tu_ngay"];


                foreach (var d in vDonViDT)
                {
                    if (d != null && d != DBNull.Value)
                        txt_NgayThanhLap.Text = Convert.ToDateTime(d).ToShortDateString();
                }
            }
            if (r["chuc_danh_id"].ToString() == "")
                cb_ChucDanh.SelectedValue = -1;
            else
                cb_ChucDanh.SelectedValue = Convert.ToInt32(r["chuc_danh_id"].ToString());

            if (r["chuc_vu_id"].ToString() == "")
                cb_ChucVu.SelectedValue = -1;
            else
                cb_ChucVu.SelectedValue = Convert.ToInt32(r["chuc_vu_id"].ToString());


            if (r["tinh_tham_nien_nha_giao"].ToString() != "")
            {
                cb_ThamNienNhaGiao.Visible = true;
                cb_ThamNienNhaGiao.Checked = Convert.ToBoolean(r["tinh_tham_nien_nha_giao"]);
            }
            else
                cb_ThamNienNhaGiao.Visible = false;

            if (r["tinh_tham_nien_nang_bac"].ToString() != "")
            {
                cb_ThamNienNangBac.Visible = true;
                cb_ThamNienNangBac.Checked = Convert.ToBoolean(r["tinh_tham_nien_nang_bac"]);
            }
            else
                cb_ThamNienNangBac.Visible = false;

            if (r["trong_nganh_gd"].ToString() != "")
            {
                cb_TrongNganhGD.Visible = true;
                cb_TrongNganhGD.Checked = Convert.ToBoolean(r["trong_nganh_gd"]);
            }
            else
                cb_TrongNganhGD.Visible = false;

            

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            bAddFlag = true;
            ClearThongTin();
        }

        private void EnableControls(bool Init)
        {
            dtp_DenNgay_filter.Enabled = dtp_TuNgay_filter.Enabled =
                cb_DonVi_Filter.Enabled = cb_ChucDanh_Filter.Enabled = cb_ChucVu_Filter.Enabled = 
                TLP_TinhTrang_Filter.Enabled = chart_QtrCTac.Enabled = 
                 btn_Them.Visible = btn_Sua.Visible = btn_Xoa.Visible = Init;

            cb_ThamNienNangBac.Visible = cb_ThamNienNhaGiao.Visible = cb_TrongNganhGD.Visible = true;

            cb_ConHD.Enabled = cb_DonVi.Enabled = cb_ChucVu.Enabled = cb_ChucDanh.Enabled =
                dtp_TuNgay.Enabled = dtp_DenNgay.Enabled =
                cb_ThamNienNangBac.Enabled = cb_ThamNienNhaGiao.Enabled = cb_TrongNganhGD.Enabled =    
                btn_Luu.Visible = btn_Huy.Visible = !Init;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (result != null && (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.DataPointLabel))
            {
                oCNVC_QTr_CongTac_OU.ID = nSelectedID;
 
                EnableControls(false);
                bAddFlag = false;
            }
            else
            {
                MessageBox.Show("Xin chọn giai đoạn muốn sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            #region MyRegion
            if (true)
            {
                bool bConHD = cb_ConHD.Checked;
                DateTime dtTuNgay = dtp_TuNgay.Value;
                DateTime? dtDenNgay;
                if (dtp_DenNgay.Checked) dtDenNgay = dtp_DenNgay.Value;
                else dtDenNgay = null;

                int nDonViID = Convert.ToInt32(cb_DonVi.SelectedValue);

                int? nChucDanhID = Convert.ToInt32(cb_ChucDanh.SelectedValue);
                if (nChucDanhID == -1) nChucDanhID = null;

                int? nChucVuID = Convert.ToInt32(cb_ChucVu.SelectedValue);
                if (nChucVuID == -1) nChucVuID = null;

                bool bTinhThamNienNhaGiao = cb_ThamNienNhaGiao.Checked;
                bool bTinhThamNienNangBac = cb_ThamNienNangBac.Checked;

                #region ADD
                if (bAddFlag)       // thêm
                {
                    try
                    {
                        if (MessageBox.Show("Bạn muốn thêm quá trình công tác này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            oCNVC.AddQtrCTacOU_FromChart(nDonViID, nChucDanhID, nChucVuID, dtTuNgay, dtDenNgay, bConHD, bTinhThamNienNhaGiao, bTinhThamNienNangBac, cb_TrongNganhGD.Checked);
                            EnableControls(true);
                            // load lai chart
                            GetData_QtrCTac();
                            RegenerateChart();

                            MessageBox.Show("Thêm thêm quá trình công tác thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thêm không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                } 
                #endregion
                #region EDIT

                else        // sửa
                {

                    if (nOldDonViID == nDonViID || oCNVC_QTr_CongTac_OU.CheckLatestQtrCtac())  // don vi nhu cu HOAC qtr ctac la moi nhat thi dc update
                    {
                        try
                        {
                            if (MessageBox.Show("Bạn muốn sửa quá trình công tác này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                int id = Convert.ToInt32(chart_QtrCTac.Series[result.Series.Name].Points[result.PointIndex].Tag);
                                bool check = oCNVC.UpdateQtrCTacOU_Chart(id, nDonViID, nChucDanhID, nChucVuID, dtTuNgay, dtDenNgay, bConHD, nOldDonViID != nDonViID,
                                                        bTinhThamNienNangBac,cb_TrongNganhGD.Checked,bTinhThamNienNhaGiao);

                                if (check)
                                {
                                    EnableControls(true);
                                    // load lai chart
                                    GetData_QtrCTac();
                                    RegenerateChart();

                                    MessageBox.Show("Sửa quá trình công tác thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Sửa không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Sửa không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    else // neu don vi nhu cũ thì update thoải mái
                    {
                        MessageBox.Show("Quá trình công tác này không thể sửa được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    
                } 
                #endregion
            }
            else
            {
                MessageBox.Show("Xin chọn loại thâm niên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            #endregion
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            oCNVC_QTr_CongTac_OU.ID = nSelectedID;
            if (nSelectedID != null && oCNVC_QTr_CongTac_OU.CheckLatestQtrCtac()
                && result != null && (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.DataPointLabel))
            {
                try
                {
                    if (MessageBox.Show("Bạn muốn xoá quá trình công tác này ?\n Mọi thông tin liên quan đến quá trình công tác này của nhân viên sẽ bị xoá.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                        oCNVC_QTr_CongTac_OU.MaNV = txt_MaNV.Text.Trim();
                        oCNVC_QTr_CongTac_OU.DeleteFromChart();
                        MessageBox.Show("Xoá thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetData_QtrCTac();
                        RegenerateChart();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Xoá không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearThongTin();
                EnableControls(true);
            }
            else
            {
                MessageBox.Show("Xin chọn giai đoạn muốn xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ClearThongTin();
            EnableControls(true);
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            //bool bTimeFilter = false;
            //bool bCateFilter = false;

            #region Thong tin cong tac filter
            int nDonViID = Convert.ToInt32(cb_DonVi_Filter.SelectedValue);
            int nChucDanhID = Convert.ToInt32(cb_ChucDanh_Filter.SelectedValue);
            int nChucVuID = Convert.ToInt32(cb_ChucVu_Filter.SelectedValue);

            for (int i = 0; i < dt_CateFilter.Rows.Count; i++)
            {
                dt_CateFilter.Rows[i]["bind"] = true;
            }

            if (nDonViID != 0)  // khong phai select all
            {
                for (int i = 0; i < dt_CateFilter.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt_CateFilter.Rows[i]["don_vi_id"]) != nDonViID)
                    {
                        dt_CateFilter.Rows[i]["bind"] = false;
                    }
                }
            }

            if (nChucDanhID != 0)  // khong phai select all
            {
                for (int i = 0; i < dt_CateFilter.Rows.Count; i++)
                {
                    if (dt_CateFilter.Rows[i]["chuc_danh_id"].ToString() == "" ||
                            Convert.ToInt32(dt_CateFilter.Rows[i]["chuc_danh_id"]) != nChucDanhID) // chuc danh rỗng hoac khong dung chuc danh id da chon deu bi set = false
                    {
                        dt_CateFilter.Rows[i]["bind"] = false;
                    }
                }
            }

            if (nChucVuID != 0)  // khong phai select all
            {
                for (int i = 0; i < dt_CateFilter.Rows.Count; i++)
                {
                    if (dt_CateFilter.Rows[i]["chuc_vu_id"].ToString() == "" ||
                            Convert.ToInt32(dt_CateFilter.Rows[i]["chuc_vu_id"]) != nChucVuID) // chuc vu rỗng hoac khong dung chuc vu id da chon deu bi set = false
                    {
                        dt_CateFilter.Rows[i]["bind"] = false;
                    }
                }
            }

            if (rb_HetHD.Checked)
            {
                for (int i = 0; i < dt_CateFilter.Rows.Count; i++)
                {
                        dt_CateFilter.Rows[i]["bind"] = !Convert.ToBoolean(dt_CateFilter.Rows[i]["tinh_trang"]);
                    
                }
            }
            else if (rb_ConHD.Checked)
            {
                for (int i = 0; i < dt_CateFilter.Rows.Count; i++)
                {
                    dt_CateFilter.Rows[i]["bind"] = Convert.ToBoolean(dt_CateFilter.Rows[i]["tinh_trang"]);

                }
            }

            #endregion

            #region Time filter
            
            DateTime? dNewFrom, dNewTo;
            if (dtp_TuNgay_filter.Checked)
            {
                dNewFrom = dtp_TuNgay_filter.Value;
            }
            else
            {
                dNewFrom = null;
            }

            if (dtp_DenNgay_filter.Checked)
            {
                dNewTo = dtp_DenNgay_filter.Value;
            }
            else
            {
                dNewTo = null;
            }

            if (dOldFrom != dNewFrom || dOldTo != dNewTo) // value khac moi filter moi
            {
                if (dtp_TuNgay_filter.Checked && dtp_DenNgay_filter.Checked) // 1.both check
                {
                    dtp_state = DTPs_State.Both;
                }
                else
                {
                    if (dtp_TuNgay_filter.Checked || dtp_DenNgay_filter.Checked) // 2.1 check
                    {
                        dtp_state = DTPs_State.One;
                    }
                    else // 3.none check
                    {
                        dtp_state = DTPs_State.None;
                    }
                }
                dOldFrom = dNewFrom;
                dOldTo = dNewTo;
                FilterByTime();
                //bTimeFilter = true;

            }
            else
            {
               // bTimeFilter = false;
            }

            #endregion

            //if (bTimeFilter || bCateFilter)
            //{
                JoinFilter();
                RegenerateChart();
                ClearThongTin();
           // }
            

        }

        private void FilterByTime()
        {
            DateTime dtDenTG;
            switch (dtp_state)
            {
                    
                case DTPs_State.Both:
                    for (int i = 0; i < dt_TimeFilter.Rows.Count; i++)
                    {

                        if (dt_TimeFilter.Rows[i]["den_thoi_gian"].ToString() == "") dtDenTG = DateTime.Now;
                        else dtDenTG = Convert.ToDateTime(dt_TimeFilter.Rows[i]["den_thoi_gian"]);

                        if ((Convert.ToDateTime(dt_TimeFilter.Rows[i]["tu_thoi_gian"]).Date < dtp_TuNgay_filter.Value.Date
                            && dtDenTG < dtp_TuNgay_filter.Value.Date) ||
                            (Convert.ToDateTime(dt_TimeFilter.Rows[i]["tu_thoi_gian"]).Date > dtp_DenNgay_filter.Value.Date
                            && dtDenTG > dtp_DenNgay_filter.Value.Date))
                        {
                            dt_TimeFilter.Rows[i]["bind"] = false;
                        }
                        else
                        {
                            dt_TimeFilter.Rows[i]["bind"] = true;
                        }

                    }
                    break;
                case DTPs_State.One:
                    if (dtp_TuNgay_filter.Checked)
                    {
                        for (int i = 0; i < dt_TimeFilter.Rows.Count; i++)
                        {
                            if (dt_TimeFilter.Rows[i]["den_thoi_gian"].ToString() == "") dtDenTG = DateTime.Now;
                            else dtDenTG = Convert.ToDateTime(dt_TimeFilter.Rows[i]["den_thoi_gian"]);

                            if (Convert.ToDateTime(dt_TimeFilter.Rows[i]["tu_thoi_gian"]).Date < dtp_TuNgay_filter.Value.Date 
                                 && dtDenTG < dtp_TuNgay_filter.Value.Date)
                            {
                                dt_TimeFilter.Rows[i]["bind"] = false;
                            }
                            else
                            {
                                dt_TimeFilter.Rows[i]["bind"] = true;
                            }

                        }
                    }
                    else
                    {
                        for (int i = 0; i < dt_TimeFilter.Rows.Count; i++)
                        {
                            if (dt_TimeFilter.Rows[i]["den_thoi_gian"].ToString() == "") dtDenTG = DateTime.Now;
                            else dtDenTG = Convert.ToDateTime(dt_TimeFilter.Rows[i]["den_thoi_gian"]);

                            if (Convert.ToDateTime(dt_TimeFilter.Rows[i]["tu_thoi_gian"]).Date > dtp_TuNgay_filter.Value.Date 
                                && dtDenTG > dtp_DenNgay_filter.Value.Date)
                            {
                                dt_TimeFilter.Rows[i]["bind"] = false;
                            }
                            else
                            {
                                dt_TimeFilter.Rows[i]["bind"] = true;
                            }

                        }
                    }
                    break;
                case DTPs_State.None:
                    for (int i = 0; i < dt_TimeFilter.Rows.Count; i++)
                    {
                        dt_TimeFilter.Rows[i]["bind"] = true;
                    }
                    break;
                default:
                    break;
            }

        }

        private void cb_DonVi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cb_DonVi.SelectedIndex != -1)
            {
                var vDonViDT = from DataRow row in dt_DonVi.Rows
                               where Convert.ToInt32(row["id"]) == Convert.ToInt32(cb_DonVi.SelectedValue)
                               select  row["tu_ngay"] ;

                
                foreach (var d in vDonViDT)
                {
                    if(d != null && d != DBNull.Value)
                    txt_NgayThanhLap.Text = Convert.ToDateTime(d).ToShortDateString();
                }
                    

            }
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txt_MaNV.Text) ||( !string.IsNullOrWhiteSpace(txt_Ho.Text) && !string.IsNullOrWhiteSpace(txt_Ten.Text)))
            {
                oCNVC.Ho = txt_Ho.Text.Trim();
                oCNVC.Ten = txt_Ten.Text.Trim();
                oCNVC.MaNV = string.IsNullOrWhiteSpace(txt_MaNV.Text.Trim()) ? null : txt_MaNV.Text.Trim();
                DataTable dt;
  
                    dt = oCNVC.SearchDataForQD(true);
              
                if (dt.Rows.Count > 0)
                {

                    Forms.Popup frPopup = new Forms.Popup("QUẢN LÝ NHÂN SỰ - DANH SÁCH CNVC", new HDQD.UCs.DSCNVC(dt));
                    frPopup.ShowDialog();
                    if (HDQD.Program.ma_nv  != "")
                    {
                        gb_Filter.Enabled = gb_Info.Enabled = true;
                        oCNVC.MaNV =  txt_MaNV.Text = HDQD.Program.ma_nv;
                        txt_Ho.Text = HDQD.Program.ho;
                        txt_Ten.Text = HDQD.Program.ten;

                        GetData_QtrCTac();
                        RegenerateChart();
                    }
                }
                else
                {
                    MessageBox.Show("Nhân viên này khòng còn hợp đồng hoặc không tồn tại trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Xin vui lòng cung cấp mã nhân viên hoặc họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}
