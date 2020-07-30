using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data.Utils;
using System.Data.OracleClient;
using DevExpress.XtraCharts;
using System.Runtime.InteropServices;

namespace FORM
{
    public partial class FORM_QUALITY_RATE_YEAR : Form
    {
        int cnt = 0;
        string sLineCD = "014";
        string sMLineCD = "001";
        const int AW_SLIDE = 0X40000;
         [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
        public FORM_QUALITY_RATE_YEAR()
        {
            InitializeComponent();

        }

        public FORM_QUALITY_RATE_YEAR(string title)
        {
            InitializeComponent();
            lblTitle.Text = title;

        }
        int indexScreen;
        public FORM_QUALITY_RATE_YEAR(string title, int _indexScreen)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
            lblTitle.Text = title;
        }
        public FORM_QUALITY_RATE_YEAR(string title, int _indexScreen, string _line_cd)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
            lblTitle.Text = title;
            sLineCD = _line_cd;            
        }
        public FORM_QUALITY_RATE_YEAR(string title, int _indexScreen, string _line_cd, string _mline_cd)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
            lblTitle.Text = title;
            sLineCD = _line_cd;
            sMLineCD = _mline_cd;
        }

        public FORM_QUALITY_RATE_YEAR(string title, int _indexScreen, string _line_cd, string _mline_cd, string _lang)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
            lblTitle.Text = title;
            sLineCD = _line_cd;
            sMLineCD = _mline_cd;
        }



        private void FORM_SMT_FTT_DAILY_Load(object sender, EventArgs e)
        {
            //ClassLib.ComCtl.Form_Maximized(this, indexScreen); //2 man hinh tro len
            //SearchData();
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            btnMonth.Enabled = true;
            timer1.Interval = 1000;
            timer1.Start();
            setConfigForm();
        }
                
        
        
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            cnt++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cnt >= 15)
            {
                showAnimation(axfpSpread1);
                
                cnt = 0;
            }
        }
        private void showAnimation(Control flg)
        {
            flg.Hide();
            this.Cursor = Cursors.WaitCursor;
            SearchData();
            AnimateWindow(flg.Handle, 300, AW_SLIDE | 0X4); //IPEX_Monitor.ClassLib.WinAPI.getSlidType("2")
            flg.Show();
            this.Cursor = Cursors.Default;
        }
        private void SearchData()
        {
            string Now = UC_YEAR.GetValue().ToString();
            DataTable dt = SP_SMT_FTT_YEARLY("Q", Now, sLineCD, sMLineCD);
            double d = 0;
            int iIndex = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    iIndex = 0;
                    axfpSpread1.set_RowHeight(i + 2, 22);
                    axfpSpread1.RowsFrozen = 2;
                    axfpSpread1.SetText(1, i + 2, dt.Rows[i]["DIV"].ToString());
                    axfpSpread1.SetText(2, i + 2, dt.Rows[i]["NAME"].ToString());
                    for (int iCol = 3; iCol < dt.Columns.Count - 1; iCol++)
                    {
                        d = 0;
                        if (dt.Rows[i][dt.Columns[iCol].Caption.ToString()].ToString() != "")                        {

                            d = Convert.ToDouble(dt.Rows[i][dt.Columns[iCol].Caption.ToString()].ToString());
                        }
                        if (d != 0)
                        {
                            axfpSpread1.SetText(iCol , i + 2, d.ToString("#,###.##"));
                            iIndex++;
                        }
                        else
                        {
                            axfpSpread1.SetText(iCol , i + 2, "");
                        }
                    }
                    if (dt.Rows[i]["FLAG"].ToString() == "0")
                    {
                        d = 0;
                        d = Convert.ToDouble(dt.Rows[i]["TOTAL"].ToString());
                        axfpSpread1.SetText(15, i + 2, d.ToString("#,###.##"));
                        for (int iCol = 3; iCol < dt.Columns.Count; iCol++)
                        {
                            if (UC_YEAR.GetValue() == DateTime.Now.Year)
                            {
                                setBackColor(dt, i, iCol);
                            }
                        }
                       
                    } else
                    {
                        d = 0;
                        d = Math.Round(Convert.ToDouble(dt.Rows[i]["TOTAL"].ToString())/iIndex,0);
                        axfpSpread1.SetText(15, i + 2, d.ToString("#,###.##"));
                    }


                     if (dt.Rows[i]["FLAG"].ToString() == "3")
                    {
                      
                        for (int iCol = 1; iCol < dt.Columns.Count; iCol++)
                        {
                            axfpSpread1.Col = iCol;
                            axfpSpread1.Row = i + 2;
                            axfpSpread1.BackColor = Color.LightBlue;
                           
                        }

                    }
                    else if (dt.Rows[i]["FLAG"].ToString() == "1")
                    {

                        for (int iCol = 1; iCol < dt.Columns.Count; iCol++)
                        {
                            axfpSpread1.Col = iCol;
                            axfpSpread1.Row = i + 2;
                            axfpSpread1.BackColor = Color.Cornsilk;

                        }

                    }  
                }
                int iCurrent = getCurrentMonth();
                for (int iCol = 3; iCol < dt.Columns.Count -1; iCol++)
                {
                    if (iCurrent == iCol - 2 && UC_YEAR.GetValue() == DateTime.Now.Year)
                    {
                        axfpSpread1.Col = iCol;
                        axfpSpread1.Row = 1;
                        axfpSpread1.BackColor = Color.Salmon;
                    }
                    else
                    {
                        axfpSpread1.Col = iCol;
                        axfpSpread1.Row = 1;
                        axfpSpread1.BackColor = Color.FromArgb(0, 128, 128);
                    }
                }
                for (int i = dt.Rows.Count; i < axfpSpread1.MaxRows; i++)
                    axfpSpread1.set_RowHeight(i + 2, 0);

                MergeCol(axfpSpread1, 0, 1);
                
                
                CreatChart();
            }
           
        }

        private void MergeCol(AxFPUSpreadADO.AxfpSpread gridObject, int iStartRow, int iCol)
        {
            try
            {
                string sTemp1 = "";
                string sTemp2 = "";
                int iRow = iStartRow;
                gridObject.Row = iStartRow;
                gridObject.Col = iCol;
                sTemp1 = gridObject.Value;
                for (int i = iStartRow; i < gridObject.MaxRows + 4; i++)
                {
                    gridObject.Row = i;
                    gridObject.Col = iCol;
                    sTemp2 = gridObject.Value;
                    if (sTemp1 != sTemp2)
                    {
                        gridObject.AddCellSpan(iCol, iRow, 1, i - iRow);
                        sTemp1 = sTemp2;
                        sTemp2 = "";
                        iRow = i;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private int getCurrentMonth()
        {
            int iTime = Convert.ToInt32(DateTime.Now.Month.ToString());

            return iTime;
        }

        private void CreatChart()
        {
            string Now = DateTime.Now.ToString("yyyyMMdd");
            DataTable dt = SP_SMT_FTT_YEARLY("P", Now, sLineCD, sMLineCD);
            if (dt != null && dt.Rows.Count > 0)
            {
                BindingPareto(chartControl1, dt, 1, 3, 4);
            }
            else
            {
                chartControl1.Series.Clear();
            }
            dt = null;
            dt = SP_SMT_FTT_YEARLY("H", Now, sLineCD, sMLineCD);
            if (dt != null && dt.Rows.Count > 0)
            {
                BindingPareto(chartControl2, dt, 1, 3, 4);
            }
            else
            {
                chartControl2.Series.Clear();
            }

        }
        private void setBackColor(DataTable dt,int iRow, int iCol)
        {
            int iMonth = getCurrentMonth();
            if (iMonth < iCol - 2 && iCol != dt.Columns.Count - 1)
            {
                return;
            }
            if (Convert.ToDouble(dt.Rows[iRow][iCol].ToString()) < 95)
            {
                axfpSpread1.Col = iCol ;
                axfpSpread1.Row = iRow + 2;
                axfpSpread1.BackColor = Color.Red;
            }
            else if ( Convert.ToDouble(dt.Rows[iRow][iCol].ToString()) < 98)
            {
                axfpSpread1.Col = iCol;
                axfpSpread1.Row = iRow + 2;
                axfpSpread1.BackColor = Color.Yellow;
            }
            else if (Convert.ToDouble(dt.Rows[iRow][iCol].ToString()) >= 98)
            {
                axfpSpread1.Col = iCol;
                axfpSpread1.Row = iRow + 2;
                axfpSpread1.BackColor = Color.Green;

            }
            else
            {
                axfpSpread1.Col = iCol;
                axfpSpread1.Row = iRow + 2;
                axfpSpread1.BackColor = Color.White;
            }
           
        }

        private void BindingPareto(DevExpress.XtraCharts.ChartControl charControl, DataTable dt, int iColPoint, int iColValue, int iColPercent)
        {
            try
            {

                ((XYDiagram)charControl.Diagram).AxisX.NumericScaleOptions.AutoGrid = true;
                ((XYDiagram)charControl.Diagram).AxisX.Title.TextColor = Color.DarkOrange;
                ((XYDiagram)charControl.Diagram).AxisY.Title.TextColor = Color.DarkOrange;
                ((XYDiagram)charControl.Diagram).AxisX.Title.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ((XYDiagram)charControl.Diagram).AxisX.Label.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ((XYDiagram)charControl.Diagram).AxisY.Title.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ((XYDiagram)charControl.Diagram).AxisY.Label.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
                DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
                DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
                DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesSlideAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
               

                sideBySideBarSeriesView1.ColorEach = true;

                charControl.Series.Clear();
                charControl.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
                
                //charControl.SeriesSorting = SortingMode.Descending;

                Series series1 = new Series("Rework", ViewType.Bar);
                Series series2 = new Series("%", ViewType.Spline);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    series1.Points.Add(new SeriesPoint(dt.Rows[i][iColPoint].ToString(), dt.Rows[i][iColValue].ToString()));
                    series2.Points.Add(new SeriesPoint(dt.Rows[i][iColPoint].ToString(), dt.Rows[i][iColPercent].ToString()));


                }
       

                series1.ArgumentScaleType = ScaleType.Qualitative;
                series2.ArgumentScaleType = ScaleType.Qualitative;
                series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                sideBySideBarSeriesView1.ColorEach = false;
                series1.View = sideBySideBarSeriesView1;
                series1.Label.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                splineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                splineSeriesView1.LineStyle.Thickness = 2;
                splineSeriesView1.SeriesAnimation = xySeriesSlideAnimation1;
                splineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                splineSeriesView1.LineMarkerOptions.Size = 15;
                splineSeriesView1.LineMarkerOptions.Color = Color.DodgerBlue;
                series2.Label.BackColor = Color.White;
                series2.Label.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                series2.Label.TextPattern = "{V:###.##}%";
                series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
                series2.View = splineSeriesView1;               
            

                charControl.Series.AddRange(new Series[] { series1, series2 });


                //((XYDiagram)charControl.Diagram).AxisY.VisualRange.SideMarginsValue = 1;

                SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");
                ((XYDiagram)charControl.Diagram).SecondaryAxesY.Clear();
                ((XYDiagram)charControl.Diagram).SecondaryAxesY.Add(myAxisY);
                myAxisY.VisualRange.SetMinMaxValues(0, 95);
                myAxisY.Title.Text = "%";
                myAxisY.Tickmarks.MinorVisible = false;                
               
                //((XYDiagram)barChartControl.Diagram).AxisY.WholeRange.SetMinMaxValues(90, 100);
                myAxisY.Label.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                myAxisY.Title.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                myAxisY.Label.TextPattern = "{V:###.##}";
                myAxisY.Title.TextColor = Color.DarkOrange;
                myAxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;

                ((SplineSeriesView)series2.View).AxisY = myAxisY;   
            }
            catch 
            {
            }
         

        }

        private void BindingStacked(DevExpress.XtraCharts.ChartControl charControl, DataTable dt)
        {
                      
            charControl.Series.Clear();      
            charControl.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;

            DevExpress.XtraCharts.LineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesSlideAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
           

            Series series1 = new Series("Prod", ViewType.StackedBar);
            Series series2 = new Series("B", ViewType.StackedBar);
            Series series3 = new Series("C", ViewType.StackedBar);
            Series series4 = new Series("Rework", ViewType.StackedBar);
            Series series5 = new Series("%", ViewType.Line);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                series1.Points.Add(new SeriesPoint(dt.Rows[i]["THEDATE"].ToString(), dt.Rows[i]["PROD"]));
                series2.Points.Add(new SeriesPoint(dt.Rows[i]["THEDATE"].ToString(), dt.Rows[i]["B_QTY"]));
                series3.Points.Add(new SeriesPoint(dt.Rows[i]["THEDATE"].ToString(), dt.Rows[i]["C_QTY"]));
                series4.Points.Add(new SeriesPoint(dt.Rows[i]["THEDATE"].ToString(), dt.Rows[i]["R_QTY"]));
                series5.Points.Add(new SeriesPoint(dt.Rows[i]["THEDATE"].ToString(), dt.Rows[i]["PERCENT"]));
            }
            series1.ArgumentScaleType = ScaleType.Qualitative;
            series2.ArgumentScaleType = ScaleType.Qualitative;
            series3.ArgumentScaleType = ScaleType.Qualitative;
            series4.ArgumentScaleType = ScaleType.Qualitative;
            series5.ArgumentScaleType = ScaleType.Qualitative;

            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series4.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            series1.Label.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Label.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.Label.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.Label.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Label.TextPattern = "{V:#,###}";
            series2.Label.TextPattern = "{V:#,###}";
            series3.Label.TextPattern = "{V:#,###}";
            series4.Label.TextPattern = "{V:#,###}";

            splineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            splineSeriesView1.LineStyle.Thickness = 7;
            splineSeriesView1.SeriesAnimation = xySeriesSlideAnimation1;
            splineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            splineSeriesView1.LineMarkerOptions.Size = 15;
            splineSeriesView1.LineMarkerOptions.Color = Color.DodgerBlue;

            series5.Label.BackColor = Color.DodgerBlue;
            series5.Label.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series5.Label.TextPattern = "{V:###.##}%";
            series5.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series5.View = splineSeriesView1; 

            charControl.Series.AddRange(new Series[] { series1, series2, series3, series4, series5 });

            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");
            ((XYDiagram)charControl.Diagram).SecondaryAxesY.Clear();
            ((XYDiagram)charControl.Diagram).SecondaryAxesY.Add(myAxisY);
            myAxisY.VisualRange.SetMinMaxValues(0.4, 5);
            myAxisY.Title.Text = "%";
            myAxisY.Tickmarks.MinorVisible = false;

            //((XYDiagram)barChartControl.Diagram).AxisY.WholeRange.SetMinMaxValues(90, 100);
            myAxisY.Label.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            myAxisY.Title.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            myAxisY.Label.TextPattern = "{V:0.##}";
            myAxisY.Title.TextColor = Color.DarkOrange;
            
            myAxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;

            ((LineSeriesView)series5.View).AxisY = myAxisY; 

            
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
            circularGauge.Scales[0].Value = 0;           

            circularGauge.Labels[0].Text = "0";
            if (circularGauge.Scales[0].Ranges.Count >= 3)
            {
                circularGauge.Scales[0].Ranges[0].StartValue = (float) 75;
                circularGauge.Scales[0].Ranges[0].EndValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].StartValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].EndValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].StartValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].EndValue = (float)100;
               
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

                
                if (circularGauge.Labels.Count > 0)
                {
                    circularGauge.Scales[0].Value = (float)num;
                    circularGauge.Labels[0].Text = num.ToString();
                }
                //labelGauges.Text = num.ToString();
            }
            catch 
            { }
            // }
        }

        public DataTable SP_SMT_FTT_YEARLY(string ARG_QTYPE, string ARG_MONTH, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_FTT_DAILY.SP_SMT_FTT_YEARLY";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_MONTH";
                MyOraDB.Parameter_Name[2] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[3] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_MONTH;
                MyOraDB.Parameter_Values[2] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[3] = ARG_MLINE_CD;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
           
        }

        private void FORM_SMT_FTT_DAILY_NEW_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cmdBack.Tag = ComVar.Var._Frm_Back;
                setConfigForm();
                initForm();
                cnt = 14;
                timer1.Start();
            }
            else
                timer1.Stop();
        }


        private void UC_YEAR_ValueChangeEvent(object sender, EventArgs e)
        {
            showAnimation(axfpSpread1);
            cnt = 0;
        }


        private void initForm()
        {

            sLineCD = ComVar.Var._strValue1;
            sMLineCD = ComVar.Var._strValue2;
           // Lang = ComVar.Var._strValue3;
            if (ComVar.Var._strValue3 == "Vn")
            {
                lblTitle.Text = "Tỉ lệ chất lượng theo năm";
                btnDay.Text = "Ngày";
                btnMonth.Text = "Tháng";
                btnWeek.Text = "Tuần";
                btnYear.Text = "Năm";
            }
            else
            {
                lblTitle.Text = "QR Status by Year";
                btnDay.Text = "Day";
                btnMonth.Text = "Month";
                btnWeek.Text = "Week";
                btnYear.Text = "Year";
            }
        }

        private void menu_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            ComVar.Var.callForm = cnt.Tag == null ? "" : cnt.Tag.ToString();
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {          
            ComVar.Var.callForm = "back";
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
