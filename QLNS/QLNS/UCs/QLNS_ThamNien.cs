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
    public partial class QLNS_ThamNien : UserControl
    {
        DataTable dt_original, dt_binding, dt_TimeFilter, dt_CateFilter;
        DateTime? dOldFrom, dOldTo;
        enum DTPs_State { Both, One, None };
        DTPs_State dtp_state;
        Business.CNVC.CNVC oCNVC;
        bool bAddFlag;
        HitTestResult result;
        bool bNhaGiaoChecked, bCongTacChecked, bNangBacChecked; // bien giu gia tri filter cũ

        public QLNS_ThamNien(string p_manv)
        {
            InitializeComponent();
            
            dtp_state = DTPs_State.None;
            oCNVC = new Business.CNVC.CNVC();
            oCNVC.MaNV = p_manv;
            dOldFrom = dOldTo = null;
            InitTable();
            RegenerateChart();
        }

        private void GetTable()
        {

        }

        private void InitTable()
        {
            dt_original = new DataTable();
            dt_binding = new DataTable();
            dt_TimeFilter = new DataTable();
            dt_CateFilter = new DataTable();

            //dt_original.Columns.AddRange(new DataColumn[] { new DataColumn("ma",typeof(string)) ,
            //                                        new DataColumn("ten",typeof(string)) ,
            //new DataColumn("loai",typeof(string)) ,
            //new DataColumn("batdau",typeof(DateTime)) ,
            //new DataColumn("ketthuc",typeof(DateTime)),
            //new DataColumn("bind",typeof(Boolean)) });

            //dt_original.Rows.Add(new object[] { "QDBN1", "Quyết định bo nhiem 1", "Bổ nhiệm", new DateTime(2013, 01, 01), new DateTime(2013, 06, 01), true });
            //dt_original.Rows.Add(new object[] { "QDBN2", "Quyết định bo nhiem 2", "Bổ nhiệm", new DateTime(2013, 03, 01), new DateTime(2013, 07, 01), true });
            //dt_original.Rows.Add(new object[] { "HD2", "Hợp đồng 2", "Hợp đồng", new DateTime(2013, 01, 01), new DateTime(2013, 12, 31), true });
            //dt_original.Rows.Add(new object[] { "HD1", "Hợp đồng 1", "Hợp đồng", new DateTime(2012, 01, 01), new DateTime(2012, 12, 31), true });
            //dt_original.Rows.Add(new object[] { "DH1", "Du học 1", "Du học", new DateTime(2012, 01, 01), new DateTime(2012, 4, 1), true });
            dt_binding = dt_original.Copy();
            dt_CateFilter = dt_original.Copy();
            dt_TimeFilter = dt_original.Copy();
            GetThamNienData();
            
        }

        private void GetThamNienData()
        {
            dt_original = oCNVC.GetThamNienDT();
            //dt_original = dt_original.AsEnumerable().OrderBy(a => a.Field<DateTime>("tu_ngay")).CopyToDataTable();
            if (dt_original.Rows.Count > 0)
            {
                txt_MaNV.Text = dt_original.AsEnumerable().Select(b => b.Field<string>("ma_nv")).First().ToString();
                txt_HoTen.Text = dt_original.AsEnumerable().Select(b => b.Field<string>("ten_nv")).First().ToString();
                dt_binding = dt_original.Copy();
                dt_CateFilter = dt_original.Copy();
                dt_TimeFilter = dt_original.Copy();
            }
            else
            {
                txt_MaNV.Text = "";
                 txt_HoTen.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bNhaGiaoChecked = bCongTacChecked = bNangBacChecked = true;
            //chart_ThamNien.ChartAreas[0].AxisX.RoundAxisValues();
        }

        private void AddSeries()
        {
            int n = chart_ThamNien.Series.Count;
            for (int i = 0; i < n; i++)
            {
                chart_ThamNien.Series.RemoveAt(0);
            }

            //for (int i = 0; i < dt_binding.Rows.Count; i++)
            //{
            //    if (Convert.ToBoolean(dt_binding.Rows[i]["bind"]))
            //    {
            //        chart_ThamNien.Series.Add(dt_binding.Rows[i]["ten"].ToString());
            //    }
            //}

            if(cb_NangBac_filter.Checked)
                chart_ThamNien.Series.Add("Nâng bậc (NB)");

            if(cb_CongTac_filter.Checked)
                chart_ThamNien.Series.Add("Công tác (CT)");

            if(cb_NhaGiao_filter.Checked)
                chart_ThamNien.Series.Add("Nhà giáo (NG)");
        }

        private void SetSeriesDataTypes()
        {
            for (int i = 0; i < chart_ThamNien.Series.Count; i++)
            {
                DataTable dttt = new DataTable();
                chart_ThamNien.Series[i].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
                chart_ThamNien.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart_ThamNien.Series[i].ChartArea = "ChartArea1";
                chart_ThamNien.Series[i].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                chart_ThamNien.Series[i].BorderWidth = 3;
                //chart_ThamNien.Series[i].IsXValueIndexed = true;
                chart_ThamNien.Series[i].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;

                //chart_ThamNien.Series[i].Label = dt_binding.AsEnumerable().Where(a => a.Field<string>("ten") == chart_ThamNien.Series[i].Name).Select(b => b.Field<string>("ma")).First().ToString();
                switch (chart_ThamNien.Series[i].Name)
                {
                    case "Nhà giáo (NG)":
                        chart_ThamNien.Series[i].Label = "NG";
                        break;
                    case "Công tác (CT)":
                        chart_ThamNien.Series[i].Label = "CT";
                        break;
                    case "Nâng bậc (NB)":
                        chart_ThamNien.Series[i].Label = "NB";
                        break;
                    default:
                        break;
                }
            }
        }

        private void ClearThongTin()
        {
            cb_CongTac.Checked = cb_NangBac.Checked = cb_NhaGiao.Checked = cb_TrongNganhGD.Checked = false;
            dtp_DenNgay.Checked = dtp_TuNgay.Checked = false;
            rtb_GhiChu.Text = "";
        }

        private void AddDataPoint()
        {
            //chart_ThamNien.Series["Nhà giáo (NG)"].EmptyPointStyle.BorderWidth = 1;
            //chart_ThamNien.Series["Nhà giáo (NG)"].EmptyPointStyle.BorderColor = Color.Black;
            //chart_ThamNien.Series["Nhà giáo (NG)"].EmptyPointStyle.MarkerColor = Color.Red;
            //chart_ThamNien.Series["Nhà giáo (NG)"].EmptyPointStyle.MarkerSize = 15;
            //chart_ThamNien.Series["Nhà giáo (NG)"].EmptyPointStyle.MarkerStyle = MarkerStyle.Cross;

            for (int i = 0; i < dt_binding.Rows.Count; i++)
			{
                DateTime dFrom = Convert.ToDateTime(dt_binding.Rows[i]["tu_ngay"]);
                DateTime dTo = Convert.ToDateTime(dt_binding.Rows[i]["den_ngay"]);
                int id = Convert.ToInt32(dt_binding.Rows[i]["id"]);
			    if (Convert.ToBoolean(dt_binding.Rows[i]["tham_nien_nha_giao"]))
                {
                    if (IsSeriesExists("Nhà giáo (NG)"))
                    {
                        if (chart_ThamNien.Series["Nhà giáo (NG)"].Points.Count > 1)
                        {
                            chart_ThamNien.Series["Nhà giáo (NG)"].Points.AddXY(0, 0);
                            chart_ThamNien.Series["Nhà giáo (NG)"].Points[chart_ThamNien.Series["Nhà giáo (NG)"].Points.Count - 1].IsEmpty = true;
                        }
                        chart_ThamNien.Series["Nhà giáo (NG)"].Points.AddXY(dFrom, 1);
                        chart_ThamNien.Series["Nhà giáo (NG)"].Points[chart_ThamNien.Series["Nhà giáo (NG)"].Points.Count - 1].Tag = id.ToString();
                        chart_ThamNien.Series["Nhà giáo (NG)"].Points.AddXY(dTo, 1);
                        chart_ThamNien.Series["Nhà giáo (NG)"].Points[chart_ThamNien.Series["Nhà giáo (NG)"].Points.Count - 1].Tag = id.ToString();
                    }
                    

                }

                if (IsSeriesExists("Nâng bậc (NB)"))
                {
                    if (Convert.ToBoolean(dt_binding.Rows[i]["tham_nien_nang_bac"]))
                    {

                        if (chart_ThamNien.Series["Nâng bậc (NB)"] != null && chart_ThamNien.Series["Nâng bậc (NB)"].Points.Count > 1)
                        {
                            chart_ThamNien.Series["Nâng bậc (NB)"].Points.AddXY(0, 0);
                            chart_ThamNien.Series["Nâng bậc (NB)"].Points[chart_ThamNien.Series["Nâng bậc (NB)"].Points.Count - 1].IsEmpty = true;
                        }
                        chart_ThamNien.Series["Nâng bậc (NB)"].Points.AddXY(dFrom, 2);
                        chart_ThamNien.Series["Nâng bậc (NB)"].Points[chart_ThamNien.Series["Nâng bậc (NB)"].Points.Count - 1].Tag = id.ToString();
                        chart_ThamNien.Series["Nâng bậc (NB)"].Points.AddXY(dTo, 2);
                        chart_ThamNien.Series["Nâng bậc (NB)"].Points[chart_ThamNien.Series["Nâng bậc (NB)"].Points.Count - 1].Tag = id.ToString();
                    }

                }

                if (IsSeriesExists("Công tác (CT)"))
                {
                    if (Convert.ToBoolean(dt_binding.Rows[i]["tham_nien_cong_tac_ou"]))
                    {

                        if (chart_ThamNien.Series["Công tác (CT)"] != null && chart_ThamNien.Series["Công tác (CT)"].Points.Count > 1)
                        {
                            chart_ThamNien.Series["Công tác (CT)"].Points.AddXY(0, 0);
                            chart_ThamNien.Series["Công tác (CT)"].Points[chart_ThamNien.Series["Công tác (CT)"].Points.Count - 1].IsEmpty = true;
                        }
                        chart_ThamNien.Series["Công tác (CT)"].Points.AddXY(dFrom, 3);
                        chart_ThamNien.Series["Công tác (CT)"].Points[chart_ThamNien.Series["Công tác (CT)"].Points.Count - 1].Tag = id.ToString();
                        chart_ThamNien.Series["Công tác (CT)"].Points.AddXY(dTo, 3);
                        chart_ThamNien.Series["Công tác (CT)"].Points[chart_ThamNien.Series["Công tác (CT)"].Points.Count - 1].Tag = id.ToString();
                    }
                }
                
			}
        }

        private bool IsSeriesExists(string sSeriesName)
        {
            for (int i = 0; i < chart_ThamNien.Series.Count; i++)
            {
                if (chart_ThamNien.Series[i].Name == sSeriesName)
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
                DateTime dmax = dt_binding.AsEnumerable().Where(a => a.Field<Boolean>("bind") == true).Select(a => a.Field<DateTime>("den_ngay")).Max();
                DateTime dmin = dt_binding.AsEnumerable().Where(a => a.Field<Boolean>("bind") == true).Select(a => a.Field<DateTime>("tu_ngay")).Min();
                chart_ThamNien.ChartAreas[0].AxisX.Maximum = (dmax.AddMonths(1)).ToOADate();
                chart_ThamNien.ChartAreas[0].AxisX.Minimum = (dmin.AddMonths(-1)).ToOADate();
            }

        }

        private void cb_HD_CheckedChanged(object sender, EventArgs e)
        {

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

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            bool bTimeFilter = false;
            bool bCateFilter = false;
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
                bTimeFilter = true;
                
            }
            else
            {
                bTimeFilter = false;
            }

            if (bCongTacChecked != cb_CongTac_filter.Checked || bNangBacChecked != cb_NangBac_filter.Checked || bNhaGiaoChecked != cb_NhaGiao_filter.Checked)
            {
                bCongTacChecked = cb_CongTac_filter.Checked;
                bNangBacChecked = cb_NangBac_filter.Checked;
                bNhaGiaoChecked = cb_NhaGiao_filter.Checked;

                //FilterByCategory();
                bCateFilter = true;
            }
            else
            {
                bCateFilter = false;
            }

            if (bCateFilter || bTimeFilter)
            {
                JoinFilter();
                RegenerateChart(); 
            }
            
        }

        private void FilterByCategory()
        {
            //for (int i = 0; i < dt_CateFilter.Rows.Count; i++)
            //{
            //    bool bRowNhaGiao = Convert.ToBoolean(dt_CateFilter.Rows[i]["tham_nien_nha_giao"]);
            //    bool bRowNangBac = Convert.ToBoolean(dt_CateFilter.Rows[i]["tham_nien_nang_bac"]);
            //    bool bRowCongTac = Convert.ToBoolean(dt_CateFilter.Rows[i]["tham_nien_cong_tac_ou"]);

            //    if (!cb_NhaGiao_filter.Checked && bRowNhaGiao)
            //    {
            //        dt_CateFilter.Rows[i]["bind"] = false;
            //    }
            //    else if (cb_NhaGiao_filter.Checked && bRowNhaGiao)
            //    {
            //        dt_CateFilter.Rows[i]["bind"] = true;
            //    }
            //}
        }

        private void FilterByTime()
        {
            switch (dtp_state)
            {
                case DTPs_State.Both:
                    for (int i = 0; i < dt_TimeFilter.Rows.Count; i++)
                    {
                        if (Convert.ToDateTime(dt_TimeFilter.Rows[i]["tu_ngay"]).Date < dtp_TuNgay_filter.Value.Date
                            || Convert.ToDateTime(dt_TimeFilter.Rows[i]["den_ngay"]).Date > dtp_DenNgay_filter.Value.Date)
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
                            if (Convert.ToDateTime(dt_TimeFilter.Rows[i]["tu_ngay"]).Date < dtp_TuNgay_filter.Value.Date)
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
                            if (Convert.ToDateTime(dt_TimeFilter.Rows[i]["den_ngay"]).Date > dtp_DenNgay_filter.Value.Date)
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

        private void chart_ThamNien_MouseMove(object sender, MouseEventArgs e)
        {
            // Call Hit Test Method
            HitTestResult result = chart_ThamNien.HitTest(e.X, e.Y);

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

        private void chart_ThamNien_MouseDown(object sender, MouseEventArgs e)
        {
            // Call Hit Test Method
            result = chart_ThamNien.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.DataPointLabel)
            {
                
                ClearThongTin();
                // Show dialog
                //MessageBox.Show(DateTime.FromOADate(chart_ThamNien.Series[result.Series.Name].Points[result.PointIndex].XValue).ToString());

                int? id = Convert.ToInt32(chart_ThamNien.Series[result.Series.Name].Points[result.PointIndex].Tag);
                DataRow r = dt_original.AsEnumerable().Where(a => a.Field<int?>("id") == id).CopyToDataTable().Rows[0];
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
            if (r["tu_ngay"].ToString() != "")
            {
                dtp_TuNgay.Checked = true;
                dtp_TuNgay.Value = Convert.ToDateTime(r["tu_ngay"]);
            }
            else
            {
                dtp_TuNgay.Checked = false;
            }

            if (r["den_ngay"].ToString() != "")
            {
                dtp_DenNgay.Checked = true;
                dtp_DenNgay.Value = Convert.ToDateTime(r["den_ngay"]);
            }
            else
            {
                dtp_DenNgay.Checked = false;
            }

            rtb_GhiChu.Text = r["ghi_chu"].ToString();

            cb_CongTac.Checked = Convert.ToBoolean(r["tham_nien_cong_tac_ou"]);
            cb_NangBac.Checked = Convert.ToBoolean(r["tham_nien_nang_bac"]);
            cb_NhaGiao.Checked = Convert.ToBoolean(r["tham_nien_nha_giao"]);
            cb_TrongNganhGD.Checked = Convert.ToBoolean(r["trong_nganh_gd"]);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            bAddFlag = true;
            ClearThongTin();
        }

        private void EnableControls(bool Init)
        {
            dtp_DenNgay_filter.Enabled = dtp_TuNgay_filter.Enabled = cb_CongTac_filter.Enabled =
                cb_NangBac_filter.Enabled = cb_NhaGiao_filter.Enabled = btn_Apply.Enabled = chart_ThamNien.Enabled =
                 btn_Them.Visible = btn_Sua.Visible = btn_Xoa.Visible = Init;

            cb_NhaGiao.Enabled = cb_CongTac.Enabled = cb_NangBac.Enabled = cb_TrongNganhGD.Enabled =
                dtp_TuNgay.Enabled = dtp_DenNgay.Enabled = rtb_GhiChu.Enabled = 
                btn_Luu.Visible = btn_Huy.Visible = !Init;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (result != null && (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.DataPointLabel ))
            {
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
            if ( (cb_CongTac.Checked || cb_NangBac.Checked || cb_NangBac.Checked))
            {
                
                bool bNangBac = cb_NangBac.Checked;
                bool bCongTac = cb_CongTac.Checked;
                bool bNhaGiao = cb_NhaGiao.Checked;
                bool bTrongGD = cb_TrongNganhGD.Checked;
                DateTime dtTuNgay = dtp_TuNgay.Value;
                DateTime? dtDenNgay;
                if (dtp_DenNgay.Checked) dtDenNgay = dtp_DenNgay.Value;
                else dtDenNgay = null;
                string sGhiChu = rtb_GhiChu.Text;

                if (bAddFlag)       // thêm
                {
                    try
                    {
                        if (MessageBox.Show("Bạn muốn thêm thâm niên này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            oCNVC.AddThamNien(null, null, null, bTrongGD, bNhaGiao, bNangBac, bCongTac, dtTuNgay, dtDenNgay, sGhiChu);
                            EnableControls(true);
                            // load lai chart
                            GetThamNienData();
                            RegenerateChart();

                            MessageBox.Show("Thêm thâm niên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thêm không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                    }
                }
                else        // sửa
                {
                    try
                    {
                        if (MessageBox.Show("Bạn muốn sửa thâm niên này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int id = Convert.ToInt32(chart_ThamNien.Series[result.Series.Name].Points[result.PointIndex].Tag);
                            oCNVC.UpdateThamNien(id, bTrongGD, bNhaGiao, bNangBac, bCongTac, dtTuNgay, dtDenNgay, sGhiChu);
                            EnableControls(true);
                            // load lai chart
                            GetThamNienData();
                            RegenerateChart();

                            MessageBox.Show("Sửa thâm niên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sửa không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
            else
            {
                MessageBox.Show("Xin chọn loại thâm niên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (result != null && (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.DataPointLabel))
            {
                try
                {
                    if (MessageBox.Show("Bạn muốn xoá thâm niên này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(chart_ThamNien.Series[result.Series.Name].Points[result.PointIndex].Tag);
                        oCNVC.DeleteThamNien(id);
                        MessageBox.Show("Xoá thâm niên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetThamNienData();
                        RegenerateChart();
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Xoá thâm niên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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



    }
}
