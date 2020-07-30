using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Drawing.Drawing2D;
using DevExpress.XtraCharts;
using DevExpress.XtraGauges.Core.Model;
//using Microsoft.VisualBasic.PowerPacks;
//using C1.Win.C1FlexGrid;

namespace FORM
{
    public partial class FORM_SMT_PRODUCTIVITY_WEEK : Form
    {



        public FORM_SMT_PRODUCTIVITY_WEEK()
        {
            InitializeComponent();
        }

        string _wh_cd, _mline_cd,Lang;
       int indexScreen;
       Form[] arrForm = new Form[3];
       public FORM_SMT_PRODUCTIVITY_WEEK(string Title, int _indexScreen, string wh_cd, string mline_cd,string _Lang)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
            _wh_cd = wh_cd;
            _mline_cd = mline_cd;
            Lang = _Lang;
            lblTitle.Text = Title;
        }
        //public FORM_PRODUCTIONTIVITY_DAILY(string aaa)
        //{
        //    InitializeComponent();
        //}
        #region Variable
        
     
        int icount = 0;

        #endregion
     
        #region Func

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

        private void CreateChartLine(ChartControl arg_chart, DataTable arg_dt, string arg_name)
        {
            if (arg_dt == null || arg_dt.Rows.Count == 0) return;

            //----------create--------------------
            arg_chart.Series.Clear();
            arg_chart.Titles.Clear();

            Series series2 = new Series("POD", ViewType.Spline);

            DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
            //DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            //DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            //DevExpress.XtraCharts.BarWidenAnimation barWidenAnimation1 = new DevExpress.XtraCharts.BarWidenAnimation();
            //DevExpress.XtraCharts.ElasticEasingFunction elasticEasingFunction1 = new DevExpress.XtraCharts.ElasticEasingFunction();
            //DevExpress.XtraCharts.XYSeriesBlowUpAnimation xySeriesBlowUpAnimation1 = new DevExpress.XtraCharts.XYSeriesBlowUpAnimation();
            DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
            //DevExpress.XtraCharts.XYSeriesUnwrapAnimation xySeriesUnwrapAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwrapAnimation();

            //DevExpress.XtraCharts.PowerEasingFunction powerEasingFunction1 = new DevExpress.XtraCharts.PowerEasingFunction();
            DevExpress.XtraCharts.SineEasingFunction sineEasingFunction1 = new DevExpress.XtraCharts.SineEasingFunction();
            DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();


            //--------- Add data Point------------
            if (arg_dt != null && arg_dt.Rows.Count > 0)
            {

                for (int i = 0; i < arg_dt.Rows.Count; i++)
                {
                    if (arg_dt.Rows[i]["POD"] == null || arg_dt.Rows[i]["POD"].ToString() == "")
                        series2.Points.Add(new SeriesPoint(arg_dt.Rows[i]["DD"].ToString() + "\n" + arg_dt.Rows[i]["DY"].ToString()));
                    else
                        series2.Points.Add(new SeriesPoint(arg_dt.Rows[i]["DD"].ToString() + "\n" + arg_dt.Rows[i]["DY"].ToString(),
                                    arg_dt.Rows[i]["POD"] == null || arg_dt.Rows[i]["POD"].ToString() == "" ? 0 : arg_dt.Rows[i]["POD"]));
                }
                
            }
            arg_chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series2 };

            //title
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            chartTitle2.Alignment = System.Drawing.StringAlignment.Near;
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            chartTitle2.Text = arg_name;
            chartTitle2.TextColor = System.Drawing.Color.Blue;
            arg_chart.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {chartTitle2});

            //Constant line
            //constantLine1.ShowInLegend = false;
            constantLine1.AxisValueSerializable = arg_dt.Rows[0]["TARGET"].ToString();
            constantLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            constantLine1.Name = "Target";
            // constantLine1.ShowBehind = false;
            constantLine1.Title.Visible = false;
            constantLine1.Title.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //constantLine1.Title.Text = "Target";
            constantLine1.LineStyle.Thickness = 2;
            // constantLine1.Title.Alignment = DevExpress.XtraCharts.ConstantLineTitleAlignment.Far;
            ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.Clear();
            ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1 });


            // format Series 
            splineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            splineSeriesView1.Color = System.Drawing.Color.DodgerBlue;
            splineSeriesView1.LineMarkerOptions.BorderColor = System.Drawing.Color.DodgerBlue;
            splineSeriesView1.LineMarkerOptions.BorderVisible = false;
            splineSeriesView1.LineMarkerOptions.Kind = DevExpress.XtraCharts.MarkerKind.Circle;
            splineSeriesView1.LineMarkerOptions.Color = System.Drawing.Color.DodgerBlue;
            splineSeriesView1.LineMarkerOptions.Size = 15;
            splineSeriesView1.LineStyle.Thickness = 3;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;           
            //series2.Label.TextPattern = "{V:#,#}";
            series2.View = splineSeriesView1;
            
            xySeriesUnwindAnimation1.EasingFunction = sineEasingFunction1;
            splineSeriesView1.SeriesAnimation = xySeriesUnwindAnimation1;
         
            ((XYDiagram)arg_chart.Diagram).AxisX.VisualRange.Auto = false;
            ((XYDiagram)arg_chart.Diagram).AxisX.VisualRange.AutoSideMargins = false;
            ((XYDiagram)arg_chart.Diagram).AxisX.VisualRange.SideMarginsValue = 2;
            ((XYDiagram)arg_chart.Diagram).AxisX.Label.Angle = 0;
            ((XYDiagram)arg_chart.Diagram).AxisX.Label.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
            ((XYDiagram)arg_chart.Diagram).AxisX.NumericScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Continuous;
            ((XYDiagram)arg_chart.Diagram).AxisY.Label.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
            ((XYDiagram)arg_chart.Diagram).AxisX.Title.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((XYDiagram)arg_chart.Diagram).AxisY.Title.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            

            //--------Text AxisX/ AxisY
            ((XYDiagram)arg_chart.Diagram).AxisY.Title.Text = "POD";
            ((XYDiagram)arg_chart.Diagram).AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            ((XYDiagram)arg_chart.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            ((XYDiagram)arg_chart.Diagram).AxisX.Title.Text = "Date";
            ((XYDiagram)arg_chart.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            ((XYDiagram)arg_chart.Diagram).AxisX.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));


            //---------------add chart in panel
            pn_body.Controls.Add(arg_chart);



        }

        private void CreateChartBar(ChartControl arg_chart, DataTable arg_dt, string arg_name)
        {

            if (arg_dt == null || arg_dt.Rows.Count == 0) return;
            arg_chart.Series.Clear();
            arg_chart.Titles.Clear();
            arg_chart.Legend.CustomItems.Clear();
            Series series2 = new Series("POD", ViewType.Bar);

            //DevExpress.XtraCharts.XYSeriesBlowUpAnimation xySeriesBlowUpAnimation1 = new DevExpress.XtraCharts.XYSeriesBlowUpAnimation();
            DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
            //DevExpress.XtraCharts.XYSeriesUnwrapAnimation xySeriesUnwrapAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwrapAnimation();

            //DevExpress.XtraCharts.PowerEasingFunction powerEasingFunction1 = new DevExpress.XtraCharts.PowerEasingFunction();
            DevExpress.XtraCharts.SineEasingFunction sineEasingFunction1 = new DevExpress.XtraCharts.SineEasingFunction();
            DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();

            DevExpress.XtraCharts.CustomLegendItem customLegendItem1 = new DevExpress.XtraCharts.CustomLegendItem();
            DevExpress.XtraCharts.CustomLegendItem customLegendItem2 = new DevExpress.XtraCharts.CustomLegendItem();
            DevExpress.XtraCharts.CustomLegendItem customLegendItem3 = new DevExpress.XtraCharts.CustomLegendItem();
            DevExpress.XtraCharts.CustomLegendItem customLegendItem4 = new DevExpress.XtraCharts.CustomLegendItem();

            


            // Add points to them, with their arguments different.

            for (int i = 0; i < arg_dt.Rows.Count; i++)
            {
                //series1.Points.Add(new SeriesPoint(dt.Rows[i]["HMS"].ToString(), dt.Rows[i]["QTY"])); //GetRandomNumber(10, 50)
                series2.Points.Add(new SeriesPoint(arg_dt.Rows[i]["DD"].ToString() + "\n" + arg_dt.Rows[i]["DY"].ToString(),
                                arg_dt.Rows[i]["POD"] == null || arg_dt.Rows[i]["POD"].ToString() == "" ? 0 : arg_dt.Rows[i]["POD"]));


                if (arg_dt.Rows[i]["POD"] != null && arg_dt.Rows[i]["POD"].ToString() != "")
                    series2.Points[i].Color = Color.FromName(arg_dt.Rows[i]["COLOR"].ToString());
                else
                    series2.Points[i].Color = Color.Empty;
            }

            series2.Points.Add(new SeriesPoint(" "));
            

            arg_chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series2 };
            ((XYDiagram)arg_chart.Diagram).AxisY.Title.Text = "POD";
            ((XYDiagram)arg_chart.Diagram).AxisY.Title.TextColor = System.Drawing.Color.Orange;
            ((XYDiagram)arg_chart.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            ((XYDiagram)arg_chart.Diagram).AxisX.Title.Text = "Date";
            ((XYDiagram)arg_chart.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            ((XYDiagram)arg_chart.Diagram).AxisX.Title.TextColor = System.Drawing.Color.Orange;
            ((XYDiagram)arg_chart.Diagram).AxisX.Tickmarks.MinorVisible = false;

            //title
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            chartTitle2.Alignment = System.Drawing.StringAlignment.Near;
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            chartTitle2.Text = arg_name;
            chartTitle2.TextColor = System.Drawing.Color.Black;
            arg_chart.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle2 });

            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //series2.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAllAroundPoint;
            xySeriesUnwindAnimation1.EasingFunction = sineEasingFunction1; //powerEasingFunction1;

            //arg_chart.Legend.CustomItems.AddRange(new DevExpress.XtraCharts.CustomLegendItem[] {
            //customLegendItem1,
            //customLegendItem2,
            //customLegendItem3});


           // arg_chart.Legend.CustomItems[0].Text = "<8.0";
            series2.ShowInLegend = false;
            arg_chart.Legend.Direction = LegendDirection.LeftToRight;
            
            //Constant line
            //constantLine1.ShowInLegend = false;
            constantLine1.AxisValueSerializable = arg_dt.Rows[0]["TAR_GREEN"].ToString();
            constantLine1.Color = Color.DodgerBlue;
            constantLine1.Name = "Target";
            constantLine1.ShowBehind = false;
            constantLine1.Title.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            constantLine1.Title.Text =  arg_dt.Rows[0]["TAR_GREEN"].ToString();
            constantLine1.Title.Visible = true;
            constantLine1.LineStyle.Thickness = 2;
            constantLine1.Title.Alignment = DevExpress.XtraCharts.ConstantLineTitleAlignment.Far;


            //Legend
            customLegendItem1.MarkerColor = System.Drawing.Color.Red;
            customLegendItem1.Text = "<" + arg_dt.Rows[0]["TAR_YELLOW"].ToString();            
            customLegendItem2.MarkerColor = System.Drawing.Color.Yellow;
            customLegendItem2.Text = arg_dt.Rows[0]["TAR_YELLOW"].ToString() + " ~ " + arg_dt.Rows[0]["TAR_GREEN"].ToString(); 
            customLegendItem3.MarkerColor = System.Drawing.Color.Green;
            customLegendItem3.Text = ">" + arg_dt.Rows[0]["TAR_GREEN"].ToString();
            customLegendItem4.MarkerColor = System.Drawing.Color.DodgerBlue;
            customLegendItem4.Text = "Target";

            arg_chart.Legend.CustomItems.AddRange(new DevExpress.XtraCharts.CustomLegendItem[] {
            customLegendItem1,
            customLegendItem2,
            customLegendItem3,
            customLegendItem4});


            //((XYDiagram)arg_chart.Diagram).AxisY.WholeRange.MinValue = 0; 
            //((XYDiagram)arg_chart.Diagram).AxisY.WholeRange.MaxValue = arg_dt.Rows[0]["TARGET"].ToString() + 10; 
            ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.Clear();
            ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1 });
           // ((XYDiagram)arg_chart.Diagram).AxisX.VisualRange.Auto = true;
            ((XYDiagram)arg_chart.Diagram).AxisX.VisualRange.AutoSideMargins = false;
            ((XYDiagram)arg_chart.Diagram).AxisX.VisualRange.SideMarginsValue = 2;
            ((XYDiagram)arg_chart.Diagram).AxisX.Label.Angle = 0;
            ((XYDiagram)arg_chart.Diagram).AxisX.Label.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
            ((XYDiagram)arg_chart.Diagram).AxisX.NumericScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Continuous;
            //((XYDiagram)_chartControl1.Diagram).AxisY.NumericScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Automatic;
            ((XYDiagram)arg_chart.Diagram).AxisY.Label.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);

            ((XYDiagram)arg_chart.Diagram).AxisX.Title.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((XYDiagram)arg_chart.Diagram).AxisY.Title.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            pn_body.Controls.Add(arg_chart);
        }

        private void BindingPOD(DataTable arg_dt)
        {

            arcScaleTrucks.EnableAnimation = false;
            arcScaleTrucks.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseIn;
            arcScaleTrucks.EasingFunction = new BackEase();
            //  arcScaleTrucks.MinValue = 0;
            // arcScaleTrucks.MaxValue = 20;
            //arcScaleTrucks.Ranges[0].EndValue = arcScaleTrucks.Ranges[1].StartValue = Convert.ToSingle(10);
            //arcScaleTrucks.Ranges[1].EndValue = arcScaleTrucks.Ranges[2].StartValue = Convert.ToSingle(15);
            //arcScaleTrucks.Ranges[2].EndValue = Convert.ToSingle(20);
            arcScaleTrucks.Value = 0;
            // lblGaugesValue.Text = "0";
            if (arg_dt != null && arg_dt.Rows.Count > 0)
            {
                try
                {
                    DevExpress.XtraCharts.CustomLegendItem customLegendItem1 = new DevExpress.XtraCharts.CustomLegendItem();
                    DevExpress.XtraCharts.CustomLegendItem customLegendItem2 = new DevExpress.XtraCharts.CustomLegendItem();
                    DevExpress.XtraCharts.CustomLegendItem customLegendItem3 = new DevExpress.XtraCharts.CustomLegendItem();

                    arcScaleTrucks.MinValue = Convert.ToSingle(arg_dt.Rows[0]["MIN_VALUE"]);
                    arcScaleTrucks.MaxValue = Convert.ToSingle(arg_dt.Rows[0]["MAX_VALUE"]);
                    //arcScaleTrucks.Ranges[0].StartValue = Convert.ToSingle(arg_dt.Rows[0]["MIN_VALUE"]);
                    //arcScaleTrucks.Ranges[0].EndValue = arcScaleTrucks.Ranges[1].StartValue = Convert.ToSingle(arg_dt.Rows[0]["YELLOW_VALUE"]); ;
                    //arcScaleTrucks.Ranges[1].EndValue = arcScaleTrucks.Ranges[2].StartValue = Convert.ToSingle(arg_dt.Rows[0]["GREEN_VALUE"]); ;
                    //arcScaleTrucks.Ranges[2].EndValue = Convert.ToSingle(arg_dt.Rows[0]["MAX_VALUE"]); 
                   // arcScaleTrucks.Ranges[0].AppearanceRange.Content

                    arcScaleTrucks.Ranges[0].StartValue = Convert.ToSingle(arg_dt.Rows[0]["MIN_VALUE"]);
                    arcScaleTrucks.Ranges[0].EndValue = arcScaleTrucks.Ranges[1].StartValue = Convert.ToSingle(arg_dt.Rows[0]["YELLOW_VALUE"]); ;
                    arcScaleTrucks.Ranges[1].EndValue = arcScaleTrucks.Ranges[2].StartValue = Convert.ToSingle(arg_dt.Rows[0]["GREEN_VALUE"]); ;
                    arcScaleTrucks.Ranges[2].EndValue = Convert.ToSingle(arg_dt.Rows[0]["MAX_VALUE"]); 

                    arcScaleTrucks.EnableAnimation = true;
                    arcScaleTrucks.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                    arcScaleTrucks.EasingFunction = new BackEase();
                    double num = Convert.ToDouble(arg_dt.Rows[0]["POD"]); //GetRandomNumber(20, 90);
                    arcScaleTrucks.Value = (float)num;
                    //if (num < Convert.ToDouble(arg_dt.Rows[0]["YELLOW_VALUE"]))
                    //{
                    //    lblGaugesValue.ForeColor = Color.Red;
                    //}
                    //else if (num >= Convert.ToDouble(arg_dt.Rows[0]["YELLOW_VALUE"]) && num < Convert.ToDouble(arg_dt.Rows[0]["GREEN_VALUE"]))
                    //{
                    //    lblGaugesValue.ForeColor = Color.Yellow;
                    //}
                    //else if (num >= Convert.ToDouble(arg_dt.Rows[0]["GREEN_VALUE"]))
                    //{
                    //    lblGaugesValue.ForeColor = Color.Green;
                    //}
                    
                    

                    lblGaugesValue.Text = arg_dt.Rows[0]["POD"].ToString();
                   // lbl_POD.Text = arg_dt.Rows[0]["TITLE"].ToString();

                    lblRed.Text = "<" + arg_dt.Rows[0]["YELLOW_VALUE"].ToString();
                    lblYellow.Text = arg_dt.Rows[0]["YELLOW_VALUE"].ToString() + " ~ " + arg_dt.Rows[0]["GREEN_VALUE"].ToString();
                    lblGreen.Text = ">" + arg_dt.Rows[0]["GREEN_VALUE"].ToString();

                }
                catch
                { }
            }
        }

        private void load_data_grid(DataTable arg_dt)
        {
            try
            {
                if (arg_dt != null && arg_dt.Rows.Count > 0)
                {
                    axGrid.MaxCols = arg_dt.Rows.Count + 1;
                    axGrid.SetText(1, 1, "MAR");
                    double dColWidth = Convert.ToDouble(arg_dt.Rows[0]["col_width"]);
                    int icol;
                    for (int i = 0; i < arg_dt.Rows.Count; i++)
                    {
                        icol = i+2;                        
                        axGrid.SetText(icol, 1, arg_dt.Rows[i]["DD"].ToString());
                        axGrid.SetText(icol, 2, arg_dt.Rows[i]["DY"].ToString());
                        axGrid.SetText(icol, 3, arg_dt.Rows[i]["ACT_QTY"].ToString());
                        axGrid.SetText(icol, 4, arg_dt.Rows[i]["TOT_MAN"].ToString());
                        axGrid.SetText(icol, 5, arg_dt.Rows[i]["TOT_ATTN"].ToString());
                        axGrid.SetText(icol, 6, arg_dt.Rows[i]["TOT_ABSENT"].ToString());
                        axGrid.SetText(icol, 7, arg_dt.Rows[i]["TOT_RELIEF"].ToString());
                        axGrid.SetText(icol, 8, arg_dt.Rows[i]["TOT_INDIRECT"].ToString());
                        axGrid.SetText(icol, 9, arg_dt.Rows[i]["PER_ABSENT"].ToString());
                        axGrid.SetText(icol, 10, arg_dt.Rows[i]["POD"].ToString());
                       // axGrid.SetText(icol, 11, arg_dt.Rows[i]["POH"].ToString());
                        axGrid.set_ColWidth(icol, dColWidth);
                    }
                }

                

            }
            catch (Exception)
            {
            }
           
        }




        #endregion Func


        #region DB
        private DataTable LOAD_DATA()
        {           
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "SEPHIROTH.PKG_DMC.SEL_PROD_SET_STATUS";
                //ARGMODE
                MyOraDB.ReDim_Parameter(1);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = "";
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


        public System.Data.DataSet LOAD_DATA_v2()
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            System.Data.DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PROD_SHOW.SEL_PRODUCTIVITY_WEEKLY";

                MyOraDB.ReDim_Parameter(9);
                MyOraDB.Process_Name = process_name;


                MyOraDB.Parameter_Name[0] = "OUT_CURSOR";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR1";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR2";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR3";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR4";
                MyOraDB.Parameter_Name[5] = "ARG_WH_CD";
                MyOraDB.Parameter_Name[6] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[7] = "OUT_CURSOR5";
                MyOraDB.Parameter_Name[8] = "OUT_CURSOR6";

                MyOraDB.Parameter_Type[0] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[5] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[6] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[7] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[8] = (int)OracleType.Cursor;


                MyOraDB.Parameter_Values[0] = "";
                MyOraDB.Parameter_Values[1] = "";
                MyOraDB.Parameter_Values[2] = "";
                MyOraDB.Parameter_Values[3] = "";
                MyOraDB.Parameter_Values[4] = "";
                MyOraDB.Parameter_Values[5] = _wh_cd;
                MyOraDB.Parameter_Values[6] = _mline_cd;
                MyOraDB.Parameter_Values[7] = "";
                MyOraDB.Parameter_Values[8] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret;
            }
            catch
            {
                return null;
            }
        }

        #endregion DB

        #region event
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                icount++;
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
                if (icount >= 30)
                {
                    icount = 0;
                    load_data();                    
                }
               
            }
            catch (Exception)
            {} 
        }


        private void load_data()
        {
            
            System.Data.DataSet ds = LOAD_DATA_v2();
            // load_data(ds.Tables[0]);
            pn_body.Visible = true;

            switch (Lang)
            {
                case "Vn":
                    CreateChartBar(Chart1, ds.Tables[1], "Cắt");
                    CreateChartBar(Chart2, ds.Tables[3], "May 1");
                    CreateChartBar(Chart3, ds.Tables[5], "May 2");
                    CreateChartBar(Chart4, ds.Tables[2], "Chuẩn bị");           
                    CreateChartBar(Chart5, ds.Tables[4], "Lắp ráp");
                    break;
                default:

                    CreateChartBar(Chart1, ds.Tables[1], "Cutting");
                    CreateChartBar(Chart2, ds.Tables[3], "Stitching 1");
                    CreateChartBar(Chart3, ds.Tables[5], "Stitching 2");
                    CreateChartBar(Chart4, ds.Tables[2], "Stockfit");           
                    CreateChartBar(Chart5, ds.Tables[4], "Assembly");
                    break;
            }


            
           
            BindingPOD(ds.Tables[6]);
            
        }
      


        private void FORM_IPEX3_LOGISTIC_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                  //  icount = 0;
                  //  _load = true;
                  
                    //panel2.BringToFront();
                    
                   // load_data();
                    //GoFullscreen(true);
                    cmdBack.Tag = ComVar.Var._Frm_Back;
                    initForm();
                    icount = 29;
                    timer1.Start();
                }
                else
                {
                    timer1.Stop();
                }
            }
            catch (Exception)
            {}
                
        }

       

        private void FORM_IPEX3_LOGISTIC_Load(object sender, EventArgs e)
        {
            try
            {
                GoFullscreen(true);
               // ClassLib.ComCtl.Form_Maximized(this, indexScreen); //2 man hinh tro len
                pn_body.Visible = true;
                setConfigForm();
                //switch (Lang)
                //{
                //    case "Vn":
                //        btnDay.Text = "Ngày";
                //        btnMonth.Text = "Tháng";
                //        btnWeek.Text = "Tuần";
                //        btnYear.Text = "Năm";
                //        lblTitle.Text = "Trạng thái năng suất theo tuần";
                //        break;
                //    case "En":
                //        btnDay.Text = "Day";
                //        btnMonth.Text = "Month";
                //        btnWeek.Text = "Week";
                //        btnYear.Text = "Year";
                //        lblTitle.Text = "Productivity Status by Week";
                //        break;
                //}
               // CreateChartLine(Chart1, ds.Tables[1], "Cutting", 0,0);
                
                //createChart1(chart_1, "Cutting");
                //createChart2(chart_2, "Stockfit");
                //createChart3(chart_3, "Stitching");
                //createChart4(chart_4, "Assembly");




              //  load_data();
            }
            catch (Exception)
            {}
            
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion event

        private void initForm()
        {
            _wh_cd = ComVar.Var._strValue1;
            _mline_cd = ComVar.Var._strValue2;
            Lang = ComVar.Var._strValue3;

            switch (Lang)
            {
                case "Vn":
                    btnDay.Text = "Ngày";
                    btnMonth.Text = "Tháng";
                    btnWeek.Text = "Tuần";
                    btnYear.Text = "Năm";
                    lblTitle.Text = "Trạng thái năng suất theo tuần";
                    break;
                case "En":
                    btnDay.Text = "Day";
                    btnMonth.Text = "Month";
                    btnWeek.Text = "Week";
                    btnYear.Text = "Year";
                    lblTitle.Text = "Productivity Status by Week";
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
