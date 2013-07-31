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
        DataTable dt_original, dt_binding, dt_TimeFilter, dt_EventFilter;
        DateTime? dOldFrom, dOldTo;
        enum DTPs_State { Both, One, None };
        DTPs_State dtp_state;
        Business.CNVC.CNVC oCNVC;

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
            dt_EventFilter = new DataTable();

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
            //dt_binding = dt_original.Copy();
            //dt_EventFilter = dt_original.Copy();
            //dt_TimeFilter = dt_original.Copy();

            dt_original = oCNVC.GetThamNienDT();
            //dt_original = dt_original.AsEnumerable().OrderBy(a => a.Field<DateTime>("tu_ngay")).CopyToDataTable();
            if (dt_original.Rows.Count >0)
            {
                txt_MaNV.Text = dt_original.AsEnumerable().Select(b => b.Field<string>("ma_nv")).First().ToString();
                txt_HoTen.Text = dt_original.AsEnumerable().Select(b => b.Field<string>("ten_nv")).First().ToString();
                dt_binding = dt_original.Copy();
                dt_EventFilter = dt_original.Copy();
                dt_TimeFilter = dt_original.Copy();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

            chart_ThamNien.Series.Add("Nâng bậc (NB)");
            chart_ThamNien.Series.Add("Công tác (CT)");
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
            chart_ThamNien.Series["Nhà giáo (NG)"].EmptyPointStyle.BorderWidth = 1;
            chart_ThamNien.Series["Nhà giáo (NG)"].EmptyPointStyle.BorderColor = Color.Black;
            chart_ThamNien.Series["Nhà giáo (NG)"].EmptyPointStyle.MarkerColor = Color.Red;
            chart_ThamNien.Series["Nhà giáo (NG)"].EmptyPointStyle.MarkerSize = 15;
            chart_ThamNien.Series["Nhà giáo (NG)"].EmptyPointStyle.MarkerStyle = MarkerStyle.Cross;
            for (int i = 0; i < dt_binding.Rows.Count; i++)
			{
                DateTime dFrom = Convert.ToDateTime(dt_binding.Rows[i]["tu_ngay"]);
                DateTime dTo = Convert.ToDateTime(dt_binding.Rows[i]["den_ngay"]);
                int id = Convert.ToInt32(dt_binding.Rows[i]["id"]);
			    if (Convert.ToBoolean(dt_binding.Rows[i]["tham_nien_nha_giao"]))
                {
                    
                    if (chart_ThamNien.Series["Nhà giáo (NG)"].Points.Count > 1)
                    {
                        chart_ThamNien.Series["Nhà giáo (NG)"].Points.AddXY(0, 0);
                        chart_ThamNien.Series["Nhà giáo (NG)"].Points[chart_ThamNien.Series["Nhà giáo (NG)"].Points.Count - 1].IsEmpty = true;
                    }
                    chart_ThamNien.Series["Nhà giáo (NG)"].Points.AddXY(dFrom, 1);
                    chart_ThamNien.Series["Nhà giáo (NG)"].Points[chart_ThamNien.Series["Nhà giáo (NG)"].Points.Count - 1].Tag= id.ToString();
                    chart_ThamNien.Series["Nhà giáo (NG)"].Points.AddXY(dTo,  1);
                    chart_ThamNien.Series["Nhà giáo (NG)"].Points[chart_ThamNien.Series["Nhà giáo (NG)"].Points.Count - 1].Tag = id.ToString();

                }
                else if (Convert.ToBoolean(dt_binding.Rows[i]["tham_nien_nang_bac"]))
                {
                    
                    if (chart_ThamNien.Series["Nâng bậc (NB)"].Points.Count > 1)
                    {
                        chart_ThamNien.Series["Nâng bậc (NB)"].Points.AddXY(0, 0);
                        chart_ThamNien.Series["Nâng bậc (NB)"].Points[chart_ThamNien.Series["Nâng bậc (NB)"].Points.Count - 1].IsEmpty = true;
                    }
                    chart_ThamNien.Series["Nâng bậc (NB)"].Points.AddXY(dFrom, 2);
                    chart_ThamNien.Series["Nâng bậc (NB)"].Points[chart_ThamNien.Series["Nâng bậc (NB)"].Points.Count - 1].Tag = id.ToString();
                    chart_ThamNien.Series["Nâng bậc (NB)"].Points.AddXY(dTo, 2);
                    chart_ThamNien.Series["Nâng bậc (NB)"].Points[chart_ThamNien.Series["Nâng bậc (NB)"].Points.Count - 1].Tag = id.ToString();
                }
                else if (Convert.ToBoolean(dt_binding.Rows[i]["tham_nien_cong_tac_ou"]))
                {
                  
                    if (chart_ThamNien.Series["Công tác (CT)"].Points.Count > 1)
                    {
                        chart_ThamNien.Series["Công tác (CT)"].Points.AddXY(0, 0);
                        chart_ThamNien.Series["Công tác (CT)"].Points[chart_ThamNien.Series["Công tác (CT)"].Points.Count - 1].IsEmpty = true;
                    }
                    chart_ThamNien.Series["Công tác (CT)"].Points.AddXY(dFrom, 3);
                    chart_ThamNien.Series["Công tác (CT)"].Points[chart_ThamNien.Series["Công tác (CT)"].Points.Count - 1].Tag = id.ToString();
                    chart_ThamNien.Series["Công tác (CT)"].Points.AddXY(dTo,3);
                    chart_ThamNien.Series["Công tác (CT)"].Points[chart_ThamNien.Series["Công tác (CT)"].Points.Count - 1].Tag = id.ToString();
                }
			}
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
                if (Convert.ToBoolean(dt_EventFilter.Rows[i]["bind"]) && Convert.ToBoolean(dt_TimeFilter.Rows[i]["bind"]))
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

        }

        private void FilterByTime()
        {
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dt.Rows[i]["bind"] = true;
            //}

            switch (dtp_state)
            {
                case DTPs_State.Both:
                    for (int i = 0; i < dt_TimeFilter.Rows.Count; i++)
                    {
                        if (Convert.ToDateTime(dt_TimeFilter.Rows[i]["batdau"]).Date < dtp_TuNgay_filter.Value.Date
                            || Convert.ToDateTime(dt_TimeFilter.Rows[i]["ketthuc"]).Date > dtp_DenNgay_filter.Value.Date)
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
                            if (Convert.ToDateTime(dt_TimeFilter.Rows[i]["batdau"]).Date < dtp_TuNgay_filter.Value.Date)
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
                            if (Convert.ToDateTime(dt_TimeFilter.Rows[i]["ketthuc"]).Date > dtp_DenNgay_filter.Value.Date)
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
            //if (dt_TimeFilter.AsEnumerable().Where(a => a.Field<Boolean>("bind") == true).Count() > 0)
            //{
            //    dt_binding = dt_original.AsEnumerable().Where(a => a.Field<Boolean>("bind") == true).CopyToDataTable();    
            //}

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
            HitTestResult result = chart_ThamNien.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
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

    }
}
