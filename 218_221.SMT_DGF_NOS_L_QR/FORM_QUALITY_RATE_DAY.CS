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
    public partial class FORM_QUALITY_RATE_DAY : Form
    {
        int cnt = 0;
        string sLineCD = "014";
        string sMLineCD = "001";
        string Lang;
        string sReworkTitle = "";
        string sHITitle = "";
        string sIssues = "";
        string sDIVColumn = "";
        string sNameColumn = "";
        string sReworkPareto = "";
        string sReworkIssues = "";
        string sReworkPercent = "";
        string sHIPareto = "";
        string sHIIssues = "";
        string sHIPercent = "";
       // init strinit = new init();
        const int AW_SLIDE = 0X40000;
         [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
        public FORM_QUALITY_RATE_DAY()
        {
            InitializeComponent();

        }

        public FORM_QUALITY_RATE_DAY(string title)
        {
            InitializeComponent();
            

        }

        private void initForm()
        {
            switch (ComVar.Var._strValue3)
            {
                case "Vn":
                    btnDay.Text = "Ngày";
                    btnMonth.Text = "Tháng";
                    btnWeek.Text = "Tuần";
                    btnYear.Text = "Năm";
                    axfpSpread1.SetText(1, 1, "Giờ");
                    axfpSpread1.SetText(19, 1, "Tổng cộng");
                    sReworkTitle = "Hàng sửa";
                    sHITitle = "HI";
                    sIssues = "Vấn đề";
                    sDIVColumn = "DIV_VN";
                    sNameColumn = "NAME_VN";
                    sReworkPareto = "R_QTY";
                    sReworkPercent = "QR";
                    sHIPareto = "R_QTY";
                    sHIPercent = "QR";
                    sReworkIssues = "DEF_NAME";
                    sHIIssues = "DEF_NAME";
                    lblTitle.Text = "Tỉ lệ chất lượng theo ngày";
                    for (int i = 3; i < 20; i++)
                    {
                        if (i % 2 != 0)
                        {
                            axfpSpread1.SetText(i, 2, sReworkTitle);
                        }
                    }
                    break;
                case "En":
                    btnDay.Text = "Day";
                    btnMonth.Text = "Month";
                    btnWeek.Text = "Week";
                    btnYear.Text = "Year";
                    axfpSpread1.SetText(1, 1, "Time");
                    axfpSpread1.SetText(19, 1, "Total");
                    sReworkTitle = "Rework";
                    sHITitle = "HI";
                    sIssues = "Issues";
                    sDIVColumn = "DIV";
                    sNameColumn = "NAME";
                    sReworkPareto = "R_QTY";
                    sReworkPercent = "QR";
                    sHIPareto = "R_QTY";
                    sHIPercent = "QR";
                    sReworkIssues = "DEF_NAME_V";
                    sHIIssues = "DEF_NAME_V";
                    lblTitle.Text = "QR Status by Day";
                    for (int i = 3; i < 20; i++)
                    {
                        if (i % 2 != 0)
                        {
                            axfpSpread1.SetText(i, 2, sReworkTitle);
                        }
                    }
                    break;
                default:
                    btnDay.Text = "Day";
                    btnMonth.Text = "Month";
                    btnWeek.Text = "Week";
                    btnYear.Text = "Year";
                    axfpSpread1.SetText(1, 1, "Time");
                    axfpSpread1.SetText(19, 1, "Total");
                    sReworkTitle = "Rework";
                    sHITitle = "HI";
                    sIssues = "Issues";
                    sDIVColumn = "DIV";
                    sNameColumn = "NAME";
                    sReworkPareto = "R_QTY";
                    sReworkPercent = "QR";
                    sHIPareto = "R_QTY";
                    sHIPercent = "QR";
                    sReworkIssues = "DEF_NAME_V";
                    sHIIssues = "DEF_NAME_V";
                    lblTitle.Text = "QR Status by Day";
                    break;

                // timer1.Start();


            }
        }

        private void FORM_SMT_FTT_DAILY_Load(object sender, EventArgs e)
        {
            //ClassLib.ComCtl.Form_Maximized(this, indexScreen); //2 man hinh tro len
            //SearchData();
            
            try
            {
                timer1.Interval = 1000;
                btnDay.ForeColor = Color.FromArgb(32, 31, 53);
                btnDay.Enabled = false;
                btnMonth.Enabled = true;
                setConfigForm();
              //  this.Name = "FORM_SMT_FTT_DAILY_NEW_" + sMLineCD;
              //  this.Text = "FORM_SMT_FTT_DAILY_NEW_" + sMLineCD;
               // MessageBox.Show(this.Name.ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
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
            string Now = DateTime.Now.ToString("yyyyMMdd");
            DataTable dt = SP_SMT_FTT_DAILY_NEW_V2("C", Now, sLineCD, sMLineCD);
            double d = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    axfpSpread1.set_RowHeight(i + 2, 22);

                    axfpSpread1.SetText(1, i + 3, dt.Rows[i][sDIVColumn].ToString());
                    axfpSpread1.SetText(2, i + 3, dt.Rows[i][sNameColumn].ToString());
                    //for (int iCol = 3; iCol < dt.Columns.Count; iCol++)
                    //{
                    //    d = 0;
                    //    d = Convert.ToDouble(dt.Rows[i][iCol].ToString());
                    //    if (d != 0)
                    //    {
                    //        axfpSpread1.SetText(iCol, i + 3, d.ToString("#,###.##"));
                    //    }
                    //    else
                    //    {
                    //        axfpSpread1.SetText(iCol, i + 3, "");
                    //    }
                    //}



                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL11"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(3, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(3, i + 3, "");
                    }

                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL21"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(4, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(4, i + 3, "");
                    }



                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL12"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(5, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(5, i + 3, "");
                    }

                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL22"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(6, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(6, i + 3, "");
                    }



                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL13"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(7, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(7, i + 3, "");
                    }

                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL23"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(8, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(8, i + 3, "");
                    }



                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL14"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(9, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(9, i + 3, "");
                    }

                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL24"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(10, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(10, i + 3, "");
                    }



                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL15"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(11, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(11, i + 3, "");
                    }

                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL25"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(12, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(12, i + 3, "");
                    }



                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL16"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(13, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(13, i + 3, "");
                    }

                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL26"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(14, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(14, i + 3, "");
                    }



                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL17"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(15, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(15, i + 3, "");
                    }

                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL27"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(16, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(16, i + 3, "");
                    }


                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL18"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(17, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(17, i + 3, "");
                    }

                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["COL28"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(18, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(18, i + 3, "");
                    }



                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["TOTAL1"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(19, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(19, i + 3, "");
                    }

                    d = 0;
                    d = Convert.ToDouble(dt.Rows[i]["TOTAL2"].ToString());
                    if (d != 0)
                    {
                        axfpSpread1.SetText(20, i + 3, d.ToString("#,###.##"));
                    }
                    else
                    {
                        axfpSpread1.SetText(20, i + 3, "");
                    }


                    if (dt.Rows[i]["FLAG"].ToString() == "4")
                    {

                        for (int iCol = 3; iCol < axfpSpread1.MaxCols; iCol++)
                        {
                            setBackColor(i + 3, iCol);
                        }

                    }


                    for (int iCol = 1; iCol < axfpSpread1.MaxCols; iCol++)
                    {
                        axfpSpread1.Row = i + 3;
                        axfpSpread1.Col = iCol;
                        if (dt.Rows[i]["FLAG"].ToString() == "2")
                        {
                            axfpSpread1.BackColor = Color.PaleGreen;

                        }
                        if (dt.Rows[i]["FLAG"].ToString() == "3")
                        {
                            axfpSpread1.BackColor = Color.Gray;

                        }
                    }


                    
                    
                }
                int iCurrent = getCurrentTime();
                for (int iCol = 3; iCol < dt.Columns.Count - 2; iCol+=2)
                {
                    if (iCurrent == iCol - 1)
                    {
                        axfpSpread1.Col = iCol;
                        axfpSpread1.Row = 1;
                        axfpSpread1.BackColor = Color.Salmon;
                        axfpSpread1.Col = iCol;
                        axfpSpread1.Row = 2;
                        axfpSpread1.BackColor = Color.Salmon;
                        axfpSpread1.Col = iCol + 1;
                        axfpSpread1.Row = 2;
                        axfpSpread1.BackColor = Color.Salmon;
                    }
                    else
                    {
                        axfpSpread1.Col = iCol;
                        axfpSpread1.Row = 1;
                        axfpSpread1.BackColor = Color.FromArgb(0, 128, 128);
                        axfpSpread1.Col = iCol;
                        axfpSpread1.Row = 2;
                        axfpSpread1.BackColor = Color.FromArgb(0, 128, 128);
                        axfpSpread1.Col = iCol + 1;
                        axfpSpread1.Row = 2;
                        axfpSpread1.BackColor = Color.FromArgb(0, 128, 128);
                    }
                }

                for (int i = dt.Rows.Count; i < axfpSpread1.MaxRows; i++)
                    axfpSpread1.set_RowHeight(i + 3, 0);

                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {
                    if( dt.Rows[iRow]["FLAG"].ToString() == "2")
                    {
                        axfpSpread1.AddCellSpan(1, iRow + 3, 2, 1);
                    }

                    if (dt.Rows[iRow]["FLAG"].ToString() == "3" || dt.Rows[iRow]["FLAG"].ToString() == "4")
                    {
                        for (int iCol = 1; iCol < dt.Columns.Count; iCol+= 2)
                        {
                            axfpSpread1.AddCellSpan(iCol, iRow + 3, 2, 1);
                            axfpSpread1.Row = iRow + 3;
                            axfpSpread1.Col = iCol;
                            axfpSpread1.CellType = FPUSpreadADO.CellTypeConstants.CellTypeStaticText;
                            axfpSpread1.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                            axfpSpread1.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                            
                            
                        }
                    }

                }

                MergeCol(axfpSpread1, 3, 1, dt.Rows.Count + 1);         
                
                CreatChart();
            }
           
        }

        private void MergeCol(AxFPUSpreadADO.AxfpSpread gridObject, int iStartRow, int iCol, int iEndRow)
        {
            try
            {
                string sTemp1 = "";
                string sTemp2 = "";
                int iRow = iStartRow;
                gridObject.Row = iStartRow;
                gridObject.Col = iCol;
                sTemp1 = gridObject.Value;
                for (int i = iStartRow; i < iEndRow; i++)
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
        private void MergeRowGroupCol(AxFPUSpreadADO.AxfpSpread gridObject, int iStartCol, int iRow, int iNumCol)
        {
            try
            {
                
                for (int i = iStartCol; i < gridObject.MaxCols + 4; i++)
                {

                    gridObject.AddCellSpan(iStartCol, iRow, 1, iNumCol);

                    i += iNumCol;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private int getCurrentTime()
        {
            int iTime = Convert.ToInt32(DateTime.Now.Hour.ToString());
            if (iTime >= 16)
            {
                return 16;
            }
            else if (iTime >= 15)
            {
                return 14;
            }
            else if (iTime >= 14)
            {
                return 12;
            }
            else if (iTime >= 12)
            {
                return 10;
            }
            else if (iTime >= 11)
            {
                return 8;
            }
            else if (iTime >= 10)
            {
                return 6;
            }
            else if (iTime >= 9)
            {
                return 4;
            }
            else if (iTime >= 7)
            {
                return 2;
            }
            return 0;
        }

        private void CreatChart()
        {
            string Now = DateTime.Now.ToString("yyyyMMdd");
            DataTable dt = SP_SMT_FTT_DAILY_NEW_V2("P", Now, sLineCD, sMLineCD);
            if (dt != null && dt.Rows.Count > 0)
            {
                BindingPareto(chartControl1, dt, sReworkIssues, sReworkPareto, sReworkPercent, sReworkTitle, sReworkTitle + " (Prs)", sIssues);
            }
            else
            {
                chartControl1.DataSource = null;
                //chartControl1.Series.Clear();
            }
            dt = null;
            dt = SP_SMT_FTT_DAILY_NEW_V2("H", Now, sLineCD, sMLineCD);
            if (dt != null && dt.Rows.Count > 0)
            {
                BindingPareto(chartControl2, dt, sHIIssues, sHIPareto, sHIPercent, sHITitle, sHITitle + " (Prs)", sIssues);
            }
            else
            {
                chartControl2.DataSource = null;
              //  chartControl2.Series.Clear();
            }

        }
        private void setBackColor(int iRow, int iCol)
        {
            int iHH = getCurrentTime();
            string sValue = "0";
            if (iHH < iCol - 2 && iCol != axfpSpread1.MaxCols - 1 && iCol != axfpSpread1.MaxCols - 2)
            {
                return;
            }
            axfpSpread1.Col = iCol;
            axfpSpread1.Row = iRow;
            //axfpSpread1.GetText(iCol, iRow, ref sValue);
            if (axfpSpread1.Value.ToString() != "")
                sValue = axfpSpread1.Value.ToString();
            else
                return;
            
            if (Convert.ToDouble(sValue) < 95)
            {
                axfpSpread1.Col = iCol;
                axfpSpread1.Row = iRow;
                axfpSpread1.BackColor = Color.Red;
            }
            else if (Convert.ToDouble(sValue) < 98)
            {
                axfpSpread1.Col = iCol;
                axfpSpread1.Row = iRow;
                axfpSpread1.BackColor = Color.Yellow;
            }
            else if (Convert.ToDouble(sValue) >= 98)
            {
                axfpSpread1.Col = iCol;
                axfpSpread1.Row = iRow;
                axfpSpread1.BackColor = Color.Green;

            }
            else
            {
                axfpSpread1.Col = iCol;
                axfpSpread1.Row = iRow;
                axfpSpread1.BackColor = Color.White;
            }
           
        }

        private void BindingPareto(DevExpress.XtraCharts.ChartControl charControl, DataTable dt, string iColPoint, string iColValue, string iColPercent, string _ChartTitle, string _sYTitle, string _sXTitle)
        {
            try
            {

                ((XYDiagram)charControl.Diagram).AxisX.NumericScaleOptions.AutoGrid = true;
                ((XYDiagram)charControl.Diagram).AxisX.Title.TextColor = Color.DarkOrange;
                ((XYDiagram)charControl.Diagram).AxisX.Title.Text = _sXTitle;
                ((XYDiagram)charControl.Diagram).AxisY.Title.TextColor = Color.DarkOrange;
                ((XYDiagram)charControl.Diagram).AxisY.Title.Text = _sYTitle;
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


                Series series1 = new Series(_ChartTitle, ViewType.Bar);
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
                series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                series2.View = splineSeriesView1;               
            

                charControl.Series.AddRange(new Series[] { series1, series2 });


                //((XYDiagram)charControl.Diagram).AxisY.VisualRange.SideMarginsValue = 1;

                charControl.Titles[0].Text = _ChartTitle;

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
            catch (Exception ex)
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
            catch (Exception ex)
            { }
            // }
        }

        public DataTable SP_SMT_FTT_DAILY_NEW_V2(string ARG_QTYPE, string ARG_YMD, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_FTT_DAILY.SP_SMT_FTT_DAILY_CHART_NEW_V2";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_YMD";
                MyOraDB.Parameter_Name[2] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[3] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_YMD;
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

        private void cmdBack_Click(object sender, EventArgs e)
        {
            //Control cnt = (Control)sender;
            ComVar.Var.callForm = "back";
           // this.Hide();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
           
        }

        private void FORM_SMT_FTT_DAILY_NEW_VisibleChanged(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (this.Visible)
            {
                cmdBack.Tag = ComVar.Var._Frm_Back;
                sLineCD = ComVar.Var._strValue1;
                sMLineCD = ComVar.Var._strValue2;
                Lang = ComVar.Var._strValue3;
                
                initForm();
                cnt = 15;
                timer1.Start();
            }
            else
                timer1.Stop();
        }



        


        private void cmdWeekly_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            ComVar.Var.callForm = cnt.Tag == null ? "" : cnt.Tag.ToString();
        }

        private void cmdMonthly_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            ComVar.Var.callForm = cnt.Tag == null ? "" : cnt.Tag.ToString();
        }

        private void cmdYearly_Click(object sender, EventArgs e)
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
