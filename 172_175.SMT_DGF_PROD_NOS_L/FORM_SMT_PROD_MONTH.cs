﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using System.Data.OracleClient;
using System.Runtime.InteropServices;

namespace FORM
{
    public partial class FORM_SMT_PROD_MONTH : Form
    {
        public FORM_SMT_PROD_MONTH()
        {
            InitializeComponent();
        }
        int indexScreen;
        string line, mline,Lang;
        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
        const int AW_SLIDE = 0X40000;
        const int AW_HOR_POSITIVE = 0X4;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;
        const int AW_HIDE = 0x00010000;
        public FORM_SMT_PROD_MONTH(string title, int _indexScreen, string _line, string _mline,string _Lang)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
            line = _line;
            mline = _mline;
            Lang = _Lang;
            switch (Lang)
            {
                case "Vn":
                    btnDay.Text = "Ngày";
                    btnMonth.Text = "Tháng";
                    btnWeek.Text = "Tuần";
                    btnYear.Text = "Năm";
                    break;
                case "En":
                    btnDay.Text = "Day";
                    btnMonth.Text = "Month";
                    btnWeek.Text = "Week";
                    btnYear.Text = "Year";
                    break;
            }
            lblTitle.Text = title;
        }

        int int_count = 0;
        int i_col_cur = 0;
        Color BackColor1 = Color.FromArgb(232, 246, 247);
        Color BackColor2 = Color.White;

        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }
        private void FRM_SMT_MON_PROD_STATUS_Load(object sender, EventArgs e)
        {
            //ClassLib.ComCtl.Form_Maximized(this, indexScreen); //2 man hinh tro len
            GoFullscreen(true);
            setConfigForm();
           // axfpSpread.SetText(1, 1, "Month");
          //  axfpSpread.Hide();
            //load_data();
           // ClearGrid(axfpSpread);
           //showAnimation(axfpSpread);
            //CreateChart();
        }
                
        //private void CreateChart()
        //{
        //    try
        //    {
        //        stackedBarChart.Series.Clear();
        //        stackedBarChart.Titles.Clear();

        //        DevExpress.XtraCharts.RectangleGradientFillOptions rectangleGradientFillOptions1 = new DevExpress.XtraCharts.RectangleGradientFillOptions();
        //        DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView1 = new DevExpress.XtraCharts.StackedBarSeriesView();
        //        DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView2 = new DevExpress.XtraCharts.StackedBarSeriesView();
        //        DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView3 = new DevExpress.XtraCharts.StackedBarSeriesView();
        //        DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView4 = new DevExpress.XtraCharts.StackedBarSeriesView();
        //        DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView5 = new DevExpress.XtraCharts.StackedBarSeriesView();
        //        DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
        //        DevExpress.XtraCharts.StackedBarSeriesLabel stackedBarSeriesLabel1 = new DevExpress.XtraCharts.StackedBarSeriesLabel();
        //        DevExpress.XtraCharts.StackedBarSeriesLabel stackedBarSeriesLabel2 = new DevExpress.XtraCharts.StackedBarSeriesLabel();
        //        DevExpress.XtraCharts.StackedBarSeriesLabel stackedBarSeriesLabel3 = new DevExpress.XtraCharts.StackedBarSeriesLabel();
        //        DevExpress.XtraCharts.StackedBarSeriesLabel stackedBarSeriesLabel4 = new DevExpress.XtraCharts.StackedBarSeriesLabel();
        //        DevExpress.XtraCharts.StackedBarSeriesLabel stackedBarSeriesLabel5 = new DevExpress.XtraCharts.StackedBarSeriesLabel();
        //        //Animation
        //        DevExpress.XtraCharts.BarGrowUpAnimation barWidenAnimation1 = new DevExpress.XtraCharts.BarGrowUpAnimation();
        //        Series series1 = new Series("Cutting", ViewType.StackedBar);
        //        //Series series2 = new Series("No-Sew", ViewType.StackedBar);
        //        Series series3 = new Series("Stitching", ViewType.StackedBar);
        //        Series series4 = new Series("Stockfit", ViewType.StackedBar);
        //        Series series5 = new Series("Assembly", ViewType.StackedBar);

        //        DataTable dt = SEL_SMT_MON_PROD_STATUS("C",line,mline,"");
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                double D = dt.Rows[i]["UPC"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[i]["UPC"].ToString());
        //                series1.Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString(), D));

        //                //series2.Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString(), dt.Rows[i]["UPA"].ToString()));

        //                series3.Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString(), dt.Rows[i]["UPS"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[i]["UPS"].ToString())));

        //                series4.Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString(), dt.Rows[i]["FSS"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[i]["FSS"].ToString())));

        //                series5.Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString(), dt.Rows[i]["FGA"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[i]["FGA"].ToString())));


        //            }
        //            //stackedBarChart.DataSource = dt;
        //            //stackedBarChart.SeriesDataMember = "OP_CD";
        //            //stackedBarChart.SeriesTemplate.ArgumentDataMember = "YMD";
        //            //stackedBarChart.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "QTY" });
        //            //stackedBarChart.SeriesTemplate.View = new StackedBarSeriesView();                    
        //        }

        //       stackedBarChart.AppearanceNameSerializable = "Light";
        //       stackedBarChart.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.False;
        //       //stackedBarChart.AppearanceName = "do";

        //       stackedBarSeriesView1.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        //       stackedBarSeriesView1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
        //       stackedBarSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
        //       stackedBarSeriesView1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
        //       stackedBarSeriesView1.BarWidth = 0.6D;

        //       series1.Label.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //       series1.Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        //       series1.Label.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
        //       series1.Label.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
        //       stackedBarSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
        //       stackedBarSeriesLabel1.TextColor = Color.Black;
        //       series1.View = stackedBarSeriesView1;
        //       series1.Label.TextPattern = "{V:#,#}";
        //       series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

        //       stackedBarSeriesView3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
        //       stackedBarSeriesView3.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
        //       stackedBarSeriesView3.BarWidth = 0.6D;
        //       series3.View = stackedBarSeriesView3;
        //       series3.Label.TextPattern = "{V:#,#}";
        //       series3.Label.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));               
        //       series3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

        //       stackedBarSeriesView4.Animation = barWidenAnimation1;
        //       stackedBarSeriesView4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        //       stackedBarSeriesView4.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
        //       stackedBarSeriesView4.BarWidth = 0.6D;
        //       series4.View = stackedBarSeriesView4;
        //       series4.Label.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //       series4.Label.TextPattern = "{V:#,#}";
        //       series4.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

        //       stackedBarSeriesView5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
        //       stackedBarSeriesView5.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
        //       stackedBarSeriesView5.BarWidth = 0.6D;
        //       series5.View = stackedBarSeriesView5;
        //       series5.Label.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //       series5.Label.TextPattern = "{V:#,#}";
        //       series5.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                
        //        //// Add both series to the chart.
        //        stackedBarChart.Series.AddRange(new Series[] { series1, series3, series4, series5 });

        //        //Contanst Line
                
        //        //((XYDiagram)stackedBarChart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1 });
        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        //title
        //        ((XYDiagram)stackedBarChart.Diagram).AxisY.Label.TextPattern = "{V:#,#}";
        //        ((XYDiagram)stackedBarChart.Diagram).AxisY.Title.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        ((XYDiagram)stackedBarChart.Diagram).AxisY.Title.Text = "Production (Prs)";
        //        ((XYDiagram)stackedBarChart.Diagram).AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
        //        ((XYDiagram)stackedBarChart.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Title.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Title.Text = "Date";
        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

        //        //Angle
        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Label.Angle = 0;
        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
                                
        //        //legend
        //        stackedBarChart.Legend.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        stackedBarChart.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
        //        stackedBarChart.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
        //        stackedBarChart.Legend.Border.Color = System.Drawing.Color.Black;
        //        stackedBarChart.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
        //        stackedBarChart.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
        //        stackedBarChart.Legend.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;                
        //        stackedBarChart.Legend.MarkerOffset = 3;
        //        stackedBarChart.Legend.Name = "Default Legend";
        //        stackedBarChart.Legend.Shadow.Visible = true;
        //        stackedBarChart.Location = new System.Drawing.Point(0, 0);
        //        stackedBarChart.Name = "stackedBarChart";
        //        stackedBarChart.PaletteName = "Flow";

        //        ((XYDiagram)stackedBarChart.Diagram).EnableAxisXZooming = true;
        //        stackedBarChart.Dock = DockStyle.Fill;

        //    }
        //    catch(Exception EX )
        //    {                
        //    }
        //}
        
        private void ClearGrid(AxFPSpreadADO.AxfpSpread Grid)
        {
            for (int irow = 3; irow <= Grid.MaxRows; irow++)
            {
                Grid.Row = irow;
                for (int icol = 1; icol <= Grid.MaxCols; icol++)
                {
                    Grid.Col = icol;
                    //Grid.SetText(icol, irow, "");
                    switch (irow % 2)
                    {
                        case 0:
                            Grid.BackColor = BackColor1;
                            Grid.ForeColor = Color.Black;
                            break;
                        case 1:
                            Grid.BackColor = BackColor2;
                            Grid.ForeColor = Color.Black;
                            break;
                    }
                    Grid.Font = new Font("Calibri", 14, FontStyle.Regular);
                }

             //   axfpSpread.set_RowHeight(irow, 30);
            }
            axfpSpread.RowsFrozen = 2;
        }

        private void bindingdatachart(DevExpress.XtraCharts.ChartControl _chart, DataTable dt, string col1, string col2)
        {
            _chart.DataSource = dt;
            _chart.Series[0].ArgumentDataMember = "DAY";
            _chart.Series[0].ValueDataMembers.AddRange(new string[] { col1 });
            //chartControl1.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            _chart.Series[1].ArgumentDataMember = "DAY";
            _chart.Series[1].ValueDataMembers.AddRange(new string[] { col2 });
            //chartControl1.Series[1].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
        }


        private void BindingGauges(DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGauge, double num, int iMin, int iMax, double iRangeMin, double iRangeMax)
        {
            // DataTable dt = SEL_POD("014", "001");
            if (circularGauge.Scales.Count <= 0)
            {
                return;
            }
            circularGauge.Scales[0].EnableAnimation = false;
            //arcScaleGauges.EasingFunction = new BackEase();
            circularGauge.Scales[0].MinValue = iMin;
            circularGauge.Scales[0].MaxValue = iMax;
            //arcScaleGauges.Ranges[0].EndValue = arcScaleGauges.Ranges[1].StartValue = Convert.ToSingle(10);
            //arcScaleGauges.Ranges[1].EndValue = arcScaleGauges.Ranges[2].StartValue = Convert.ToSingle(15);
            //arcScaleGauges.Ranges[2].EndValue = Convert.ToSingle(20);
            circularGauge.Scales[0].Value = 90;

            //circularGauge.Labels[0].Text = "90";
            if (circularGauge.Scales[0].Ranges.Count >= 3)
            {
                circularGauge.Scales[0].Ranges[0].StartValue = (float)(iMin);
                circularGauge.Scales[0].Ranges[0].EndValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].StartValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].EndValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].StartValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].EndValue = (float)(iMax);
                //circularGauge.Scales[0].Ranges[0].AppearanceRange.ContentBrush.

            }
            //labelGauges.Text = "0";
            //if (dt != null && dt.Rows.Count > 0)
            //{
            try
            {

                circularGauge.Scales[0].MinValue = iMin;
                circularGauge.Scales[0].MaxValue = iMax;
                //arcScaleGauges.Ranges[0].EndValue = arcScaleGauges.Ranges[1].StartValue = Convert.ToSingle(Convert.ToSingle(dt.Rows[0][0]) - 2);
                //arcScaleGauges.Ranges[1].EndValue = arcScaleGauges.Ranges[2].StartValue = Convert.ToSingle(Convert.ToSingle(dt.Rows[0][0]) + 2);
                //arcScaleGauges.Ranges[2].EndValue = Convert.ToSingle(Convert.ToSingle(dt.Rows[0][0]) + 5);

                circularGauge.Scales[0].EnableAnimation = true;
                circularGauge.Scales[0].EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                //arcScaleGauges.EasingFunction = new BackEase();

                circularGauge.Scales[0].Value = (float)num;
                //circularGauge.Labels[0].Text = num.ToString();

            }
            catch (Exception ex)
            { }
            // }
        }

        private string GetText(AxFPSpreadADO.AxfpSpread spread, int col, int row)
        {
            try
            {
                object data = null;
                spread.GetText(col, row, ref data);
                return data.ToString();
            }
            catch (Exception ex)
            {
                //return "";
                //log.Error(ex);
                return null;
            }

        }

        private void showAnimation(Control flg)
        {
            flg.Hide();
            timer2.Stop();
            this.Cursor = Cursors.WaitCursor;
            load_data();
            AnimateWindow(flg.Handle, 300, AW_SLIDE | 0X4); //IPEX_Monitor.ClassLib.WinAPI.getSlidType("2")
            flg.Show();
            timer2.Interval = 1000;
            timer2.Start();
            this.Cursor = Cursors.Default;
        }
        private void load_data()
        {
            try
            {
                //axfpSpread.Hide();
                load_head();
                DataTable dt = SEL_SMT_MON_PROD_STATUS("Q", line, mline, UC_MONTH.GetValue());
                DataTable dt_chart = SEL_SMT_MON_PROD_STATUS("C", line, mline, UC_MONTH.GetValue());
                DataTable dt1 = SEL_SMT_MON_PROD_STATUS("C1", line, mline, UC_MONTH.GetValue());
                if (dt != null && dt.Rows.Count > 0)
                {

                    axfpSpread.MaxRows = dt.Rows.Count + 2;
                    ClearGrid(axfpSpread);
                    //axfpSpread.SetCellBorder(1, 1, axfpSpread.MaxCols, axfpSpread.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                    //axfpSpread.SetCellBorder(1, 1, axfpSpread.MaxCols, axfpSpread.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                    //axfpSpread.SetCellBorder(1, 1, axfpSpread.MaxCols, axfpSpread.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                    //axfpSpread.SetCellBorder(1, 1, axfpSpread.MaxCols, axfpSpread.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexRight, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 2; j < dt.Columns.Count; j++)
                        {
                            if (dt.Columns[j].ColumnName.Replace("'","") == "RATE")
                                axfpSpread.SetText(j, i + 3, dt.Rows[i][j].ToString().Trim() == "" ? "" : Convert.ToDouble(dt.Rows[i][j].ToString()).ToString() + "%");
                            else
                                axfpSpread.SetText(j, i + 3, dt.Rows[i][j].ToString().Trim() == "" ? "" : Convert.ToDouble(dt.Rows[i][j].ToString()).ToString("###,###,###"));
                            //axfpSpread.SetText(j, i + 3, "2,999");
                            if (j==dt.Columns.Count-1)
                            {
                                axfpSpread.Row = i + 3;
                                axfpSpread.Col = j;
                                if (GetText(axfpSpread, j, i + 3) != "")
                                {
                                    if (Convert.ToDouble(GetText(axfpSpread, j, i + 3).Replace("%", "").Trim()) < 95)
                                    {
                                        axfpSpread.BackColor = Color.Red;
                                        axfpSpread.ForeColor = Color.White;
                                    }
                                    else if (Convert.ToDouble(GetText(axfpSpread, j, i + 3).Replace("%", "").Trim()) > 98)
                                    {
                                        axfpSpread.BackColor = Color.Green;
                                        axfpSpread.ForeColor = Color.White;
                                    }
                                    else
                                    {
                                        axfpSpread.BackColor = Color.Yellow;
                                        axfpSpread.ForeColor = Color.Black;
                                    }
                                }

                            }
                        }
                     //   axfpSpread.set_RowHeight(i + 3, 27);
                    }
                    
                }
                bindingdatachart(chartControl1, dt_chart,  "UPC_QTY","UPC_TAR");
                bindingdatachart(chartControl2, dt_chart, "UPS1_QTY", "UPS1_TAR");
                bindingdatachart(chartControl3, dt_chart, "UPS2_QTY", "UPS2_TAR");
                bindingdatachart(chartControl4, dt_chart, "FSS_QTY", "FSS_TAR");
                bindingdatachart(chartControl5, dt_chart, "FGA_QTY", "FGA_TAR");
                //if (dt1 != null && dt1.Rows.Count > 0)
                //{
                //    BindingGauges(circularGauge, Convert.ToDouble(dt1.Rows[0]["RATE"]), Convert.ToInt32(dt1.Rows[0]["V_MIN"]), Convert.ToInt32(dt1.Rows[0]["V_MAX"]), Convert.ToInt32(dt1.Rows[0]["R_MIN"]), Convert.ToInt32(dt1.Rows[0]["R_MAX"]));
                //    lblR.Text = "<" + dt1.Rows[0]["R_MIN"].ToString() + "%";
                //    lblY.Text = ">=" + dt1.Rows[0]["R_MIN"].ToString() + "% && <=" + dt1.Rows[0]["R_MAX"].ToString() + "%";
                //    lblG.Text = ">" + dt1.Rows[0]["R_MAX"].ToString() + "%";
                //    lblRPlan.Text = "R.Plan: " + Convert.ToDouble(dt1.Rows[0]["RPLAN"]).ToString("#,#") + "Prs";
                //    lblProd.Text = "Prod: " + Convert.ToDouble(dt1.Rows[0]["PROD"]).ToString("#,#") + "Prs";
                //    lblRate.Text = "Rate: " + Convert.ToDouble(dt1.Rows[0]["RATE"]).ToString("#,#.0") + "%";
                //    labelRate.Text = Convert.ToDouble(dt1.Rows[0]["RATE"]).ToString("#,0.0") + "%";
                //}  
                int i_min = 0, i_max = 100;
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (GetText(axfpSpread, dt.Columns.Count - 1, axfpSpread.MaxRows).Replace("%", "").Trim() != "")
                    {
                        
                        if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, axfpSpread.MaxRows).Replace("%", "").Trim()) > 90 && Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, axfpSpread.MaxRows).Replace("%", "").Trim())<100)
                        {
                            i_min = 90;
                            i_max = 100;
                        }
                        else if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, axfpSpread.MaxRows).Replace("%", "").Trim()) < 90)
                        {
                            i_min = 90 - 3;
                            i_max = 100;
                        }
                        else if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, axfpSpread.MaxRows).Replace("%", "").Trim()) > 100)
                        {
                            i_min = 90;
                            i_max = 100 + 3;
                        }
                        else if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, axfpSpread.MaxRows).Replace("%", "").Trim())  == 0)
                        {
                            i_min = 0;
                            i_max = 100;
                        }
                        BindingGauges(circularGauge, Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, axfpSpread.MaxRows).Replace("%", "").Trim()), i_min, i_max, 95, 98);
                        labelRate.Text = Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, axfpSpread.MaxRows).Replace("%", "").Trim()) + "%";
                    }
                }
                else
                {
                    BindingGauges(circularGauge, 0, 0, 100, 95, 98);
                    labelRate.Text = "0%";
                }

                //axfpSpread.Show();
            }
            catch (Exception ex)
            {
                
            }
        }
        private void load_head()
        {
            try
            {
                DataTable dt = SEL_SMT_MON_PROD_STATUS("H",line,mline,UC_MONTH.GetValue());
                int i;
                if (dt != null && dt.Rows.Count > 0)
                {                    
                    axfpSpread.SetText(1, 1, dt.Rows[0]["MON"].ToString());
                    axfpSpread.set_ColWidth(1, 16.5);
                  //  axfpSpread.set_ColWidth(2, 226);
                    for (i = 0; i < dt.Rows.Count; i++)
                    {

                        if (dt.Rows[i]["CUR"].ToString() == "1")
                        {
                            axfpSpread.Row = 1;
                            axfpSpread.Col = i + 2;
                            axfpSpread.BackColor = Color.Salmon;
                            axfpSpread.Row = 2;
                            axfpSpread.Col = i + 2;
                            axfpSpread.BackColor = Color.Salmon;
                            
                        }
                        axfpSpread.AddCellSpan(i + 2, 1, 1, 1);
                        axfpSpread.SetText(i + 2, 1, dt.Rows[i]["DAY"].ToString());
                        axfpSpread.SetText(i + 2, 2, dt.Rows[i]["DAY1"].ToString());
                        axfpSpread.set_ColWidth(i + 2, (double)221 / (double)(dt.Rows.Count));
                        //axfpSpread.set_ColWidth(i + 2, 240 / 27 + 0.3);
                        //axfpSpread.set_ColWidth(i + 2, (axfpSpread.Width-axfpSpread.get_ColWidth(1))/dt.Rows.Count);
                    }
                    axfpSpread.set_ColWidth(1, 16.3 + 220 - axfpSpread.get_ColWidth(i + 1) * dt.Rows.Count);
                    axfpSpread.AddCellSpan(dt.Rows.Count + 1, 1, 1, 2);
                    axfpSpread.AddCellSpan(dt.Rows.Count, 1, 1, 2);
                    axfpSpread.AddCellSpan(dt.Rows.Count - 1, 1, 1, 2);
                    //axfpSpread.set_ColWidth(1, 16.4 + 0.1 * 25 / dt.Rows.Count ); 
                    for ( int j = i + 2; j<= axfpSpread.MaxCols;j++)
                    {
                        axfpSpread.set_ColWidth(j,0);
                    }
                }
                
            }
            catch
            {
            }
        }

        public DataTable SEL_SMT_MON_PROD_STATUS(string ARG_QTYPE, string ARG_LINE, string ARG_MLINE, string ARG_DATE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_PROD.SP_SMT_MONTHLY_PROD_STATUS_L";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_LINE";
                MyOraDB.Parameter_Name[2] = "V_P_MLINE";
                MyOraDB.Parameter_Name[3] = "V_P_DATE";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE;
                MyOraDB.Parameter_Values[2] = ARG_MLINE;
                MyOraDB.Parameter_Values[3] = ARG_DATE;
                MyOraDB.Parameter_Values[4] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void stackedBarChart_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {
            try
            {
                if (e.Item.Axis is AxisX)
                {                    
                    e.Item.Text = e.Item.Text.Replace("_", "\n"); 
                }
            }
            catch
            {

            }
        }

        
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (int_count < 30)
                    int_count++;
                else
                {
                    int_count = 0;
                    showAnimation(axfpSpread);
                }
            }
            catch
            {
            }
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FRM_SMT_MON_PROD_STATUS_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cmdBack.Tag = ComVar.Var._Frm_Back;
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                int_count = 29;
                initForm();
                timer1.Start();
                timer2.Start();
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
            }
        }

        private void UC_MONTH_ValueChangeEvent(object sender, EventArgs e)
        {
            int_count = 0;
            showAnimation(axfpSpread);
        }

        private void initForm()
        {
            line = ComVar.Var._strValue1;
            mline = ComVar.Var._strValue2;
            Lang = ComVar.Var._strValue3;
            switch (Lang)
            {
                case "Vn":
                    btnDay.Text = "Ngày";
                    btnMonth.Text = "Tháng";
                    btnWeek.Text = "Tuần";
                    btnYear.Text = "Năm";
                    lblTitle.Text = "Trạng thái sản xuất theo Tháng";
                    break;
                case "En":
                    btnDay.Text = "Day";
                    btnMonth.Text = "Month";
                    btnWeek.Text = "Week";
                    btnYear.Text = "Year";
                    lblTitle.Text = "Production Status by Month";
                    break;
            }
            
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {

            ComVar.Var.callForm = "back";
        }

        private void menu_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            ComVar.Var.callForm = cnt.Tag == null ? "" : cnt.Tag.ToString();
        }

        #region  Get Config Data From Database
        /// <summary>
        /// Declare _dtnInit
        /// Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        /// </summary>
        private void setConfigForm()
        {
            try
            {
                System.Collections.Generic.Dictionary<string, string> dtnInit = new System.Collections.Generic.Dictionary<string, string>();
                dtnInit = ComVar.Func.getInitForm(ComVar.Var._Area + this.GetType().Assembly.GetName().Name, this.GetType().Name);

                for (int i = 0; i < dtnInit.Count; i++)
                {
                    setComValue(dtnInit.ElementAt(i).Key, dtnInit.ElementAt(i).Value);
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setConfigForm-->Err:    " + ex.ToString());
            }
        }

        private void setComValue(string obj, string obj_value)
        {
            try
            {
                if (obj.Contains('.'))
                {
                    string[] strSplit = obj.Split('.');
                    Control[] cnt = this.Controls.Find(strSplit[0], true);

                    for (int i = 0; i < cnt.Length; i++)
                    {
                        System.Reflection.PropertyInfo propertyInfo = cnt[i].GetType().GetProperty(strSplit[1]);
                        propertyInfo.SetValue(cnt[i], Convert.ChangeType(obj_value, propertyInfo.PropertyType), null);
                    }
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setComValue (" + obj + ", " + obj_value + ") Err:    " + ex.ToString());
            }

        }
        #endregion 
    }
}
