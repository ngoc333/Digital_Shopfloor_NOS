using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using DevExpress.XtraCharts;
using System.Runtime.InteropServices;

namespace FORM
{
    public partial class FORM_SMT_PROD_DAY_8 : Form
    {
        
        // init strinit = new init();
        #region Windows Form Designer generated code
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_SMT_PROD_DAY_8));
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange1 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange2 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange3 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY1 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.XYSeriesSlideAnimation xySeriesSlideAnimation1 = new DevExpress.XtraCharts.XYSeriesSlideAnimation();
            DevExpress.XtraCharts.SineEasingFunction sineEasingFunction1 = new DevExpress.XtraCharts.SineEasingFunction();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY2 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel2 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.XYSeriesSlideAnimation xySeriesSlideAnimation2 = new DevExpress.XtraCharts.XYSeriesSlideAnimation();
            DevExpress.XtraCharts.SineEasingFunction sineEasingFunction2 = new DevExpress.XtraCharts.SineEasingFunction();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDay = new DevExpress.XtraEditors.SimpleButton();
            this.btnYear = new DevExpress.XtraEditors.SimpleButton();
            this.btnMonth = new DevExpress.XtraEditors.SimpleButton();
            this.btnWeek = new DevExpress.XtraEditors.SimpleButton();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.axfpView = new AxFPUSpreadADO.AxfpSpread();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAssemblyProd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblProd = new System.Windows.Forms.Label();
            this.lblRPlan = new System.Windows.Forms.Label();
            this.circularRealTime = new DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge();
            this.arcScaleBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent();
            this.arcScaleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
            this.arcScaleNeedleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent();
            this.chartControl4 = new DevExpress.XtraCharts.ChartControl();
            this.chartControl2 = new DevExpress.XtraCharts.ChartControl();
            this.tmr_Date = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axfpView)).BeginInit();
            this.gaugeControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circularRealTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.btnDay);
            this.panel1.Controls.Add(this.btnYear);
            this.panel1.Controls.Add(this.btnMonth);
            this.panel1.Controls.Add(this.btnWeek);
            this.panel1.Controls.Add(this.cmdBack);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(1920, 109);
            this.panel1.MinimumSize = new System.Drawing.Size(1920, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 109);
            this.panel1.TabIndex = 1;
            // 
            // btnDay
            // 
            this.btnDay.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDay.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDay.Appearance.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold);
            this.btnDay.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnDay.Appearance.Options.UseBackColor = true;
            this.btnDay.Appearance.Options.UseFont = true;
            this.btnDay.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnDay.Enabled = false;
            this.btnDay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDay.ImageOptions.Image")));
            this.btnDay.Location = new System.Drawing.Point(1282, 2);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(175, 48);
            this.btnDay.TabIndex = 63;
            this.btnDay.Text = "Day";
            // 
            // btnYear
            // 
            this.btnYear.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnYear.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnYear.Appearance.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYear.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnYear.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnYear.Appearance.Options.UseBackColor = true;
            this.btnYear.Appearance.Options.UseFont = true;
            this.btnYear.Appearance.Options.UseForeColor = true;
            this.btnYear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnYear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYear.ImageOptions.Image")));
            this.btnYear.Location = new System.Drawing.Point(1462, 56);
            this.btnYear.Name = "btnYear";
            this.btnYear.Size = new System.Drawing.Size(175, 48);
            this.btnYear.TabIndex = 61;
            this.btnYear.Text = "Yearly";
            this.btnYear.Click += new System.EventHandler(this.menu_Click);
            // 
            // btnMonth
            // 
            this.btnMonth.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMonth.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMonth.Appearance.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonth.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnMonth.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnMonth.Appearance.Options.UseBackColor = true;
            this.btnMonth.Appearance.Options.UseFont = true;
            this.btnMonth.Appearance.Options.UseForeColor = true;
            this.btnMonth.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnMonth.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMonth.ImageOptions.Image")));
            this.btnMonth.Location = new System.Drawing.Point(1462, 3);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(175, 48);
            this.btnMonth.TabIndex = 60;
            this.btnMonth.Text = "Monthly";
            this.btnMonth.Click += new System.EventHandler(this.menu_Click);
            // 
            // btnWeek
            // 
            this.btnWeek.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWeek.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWeek.Appearance.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeek.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnWeek.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnWeek.Appearance.Options.UseBackColor = true;
            this.btnWeek.Appearance.Options.UseFont = true;
            this.btnWeek.Appearance.Options.UseForeColor = true;
            this.btnWeek.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnWeek.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnWeek.ImageOptions.Image")));
            this.btnWeek.Location = new System.Drawing.Point(1282, 56);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(175, 48);
            this.btnWeek.TabIndex = 59;
            this.btnWeek.Text = "Weekly";
            this.btnWeek.Click += new System.EventHandler(this.menu_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cmdBack.BackgroundImage = global::FORM.Properties.Resources.Back_Icon;
            this.cmdBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdBack.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.cmdBack.FlatAppearance.BorderSize = 0;
            this.cmdBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBack.Location = new System.Drawing.Point(1167, 5);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(108, 101);
            this.cmdBack.TabIndex = 52;
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblDate.Location = new System.Drawing.Point(1639, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(281, 109);
            this.lblDate.TabIndex = 46;
            this.lblDate.Text = "lblDate";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1081, 103);
            this.lblTitle.TabIndex = 47;
            this.lblTitle.Tag = "Minimized";
            this.lblTitle.Text = "Daily Production Status";
            this.lblTitle.DoubleClick += new System.EventHandler(this.menu_Click);
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 109);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.axfpView);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.gaugeControl1);
            this.splitMain.Panel2.Controls.Add(this.chartControl4);
            this.splitMain.Panel2.Controls.Add(this.chartControl2);
            this.splitMain.Size = new System.Drawing.Size(1916, 933);
            this.splitMain.SplitterDistance = 422;
            this.splitMain.TabIndex = 2;
            // 
            // axfpView
            // 
            this.axfpView.DataSource = null;
            this.axfpView.Location = new System.Drawing.Point(3, 6);
            this.axfpView.Name = "axfpView";
            this.axfpView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpView.OcxState")));
            this.axfpView.Size = new System.Drawing.Size(1910, 407);
            this.axfpView.TabIndex = 0;
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.AutoLayout = false;
            this.gaugeControl1.Controls.Add(this.label5);
            this.gaugeControl1.Controls.Add(this.label4);
            this.gaugeControl1.Controls.Add(this.label3);
            this.gaugeControl1.Controls.Add(this.lblAssemblyProd);
            this.gaugeControl1.Controls.Add(this.label1);
            this.gaugeControl1.Controls.Add(this.lblRate);
            this.gaugeControl1.Controls.Add(this.lblProd);
            this.gaugeControl1.Controls.Add(this.lblRPlan);
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.circularRealTime});
            this.gaugeControl1.Location = new System.Drawing.Point(1278, 6);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(638, 498);
            this.gaugeControl1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Green;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(569, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 24);
            this.label5.TabIndex = 66;
            this.label5.Text = ">98%";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(464, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 24);
            this.label4.TabIndex = 65;
            this.label4.Text = ">= 95% && <98%";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(400, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 64;
            this.label3.Text = "<95%";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAssemblyProd
            // 
            this.lblAssemblyProd.BackColor = System.Drawing.Color.Transparent;
            this.lblAssemblyProd.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.lblAssemblyProd.ForeColor = System.Drawing.Color.Black;
            this.lblAssemblyProd.Location = new System.Drawing.Point(6, 6);
            this.lblAssemblyProd.Name = "lblAssemblyProd";
            this.lblAssemblyProd.Size = new System.Drawing.Size(274, 39);
            this.lblAssemblyProd.TabIndex = 63;
            this.lblAssemblyProd.Text = "Assemly Production";
            this.lblAssemblyProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 18.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(246, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 51);
            this.label1.TabIndex = 62;
            this.label1.Text = "%";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // lblRate
            // 
            this.lblRate.BackColor = System.Drawing.Color.DarkTurquoise;
            this.lblRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRate.ForeColor = System.Drawing.Color.White;
            this.lblRate.Location = new System.Drawing.Point(366, 52);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(167, 39);
            this.lblRate.TabIndex = 61;
            this.lblRate.Text = "Rate:";
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProd
            // 
            this.lblProd.BackColor = System.Drawing.Color.DarkTurquoise;
            this.lblProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProd.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProd.ForeColor = System.Drawing.Color.White;
            this.lblProd.Location = new System.Drawing.Point(188, 52);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(167, 39);
            this.lblProd.TabIndex = 60;
            this.lblProd.Text = "Prod:";
            this.lblProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRPlan
            // 
            this.lblRPlan.BackColor = System.Drawing.Color.DarkTurquoise;
            this.lblRPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRPlan.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRPlan.ForeColor = System.Drawing.Color.White;
            this.lblRPlan.Location = new System.Drawing.Point(10, 52);
            this.lblRPlan.Name = "lblRPlan";
            this.lblRPlan.Size = new System.Drawing.Size(167, 39);
            this.lblRPlan.TabIndex = 59;
            this.lblRPlan.Text = "R.Plan";
            this.lblRPlan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // circularRealTime
            // 
            this.circularRealTime.AutoSize = DevExpress.Utils.DefaultBoolean.True;
            this.circularRealTime.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent[] {
            this.arcScaleBackgroundLayerComponent1});
            this.circularRealTime.Bounds = new System.Drawing.Rectangle(7, 98, 619, 394);
            this.circularRealTime.Name = "circularRealTime";
            this.circularRealTime.Needles.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent[] {
            this.arcScaleNeedleComponent1});
            this.circularRealTime.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent[] {
            this.arcScaleComponent1});
            // 
            // arcScaleBackgroundLayerComponent1
            // 
            this.arcScaleBackgroundLayerComponent1.ArcScale = this.arcScaleComponent1;
            this.arcScaleBackgroundLayerComponent1.Name = "bg";
            this.arcScaleBackgroundLayerComponent1.ScaleCenterPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.71F);
            this.arcScaleBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.CircularHalf_Style4;
            this.arcScaleBackgroundLayerComponent1.Size = new System.Drawing.SizeF(250F, 176F);
            this.arcScaleBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // arcScaleComponent1
            // 
            this.arcScaleComponent1.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent1.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent1.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent1.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent1.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 12F);
            this.arcScaleComponent1.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.arcScaleComponent1.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 165F);
            this.arcScaleComponent1.EndAngle = 0F;
            this.arcScaleComponent1.MajorTickCount = 6;
            this.arcScaleComponent1.MajorTickmark.FormatString = "{0:F0}";
            this.arcScaleComponent1.MajorTickmark.ShapeOffset = -14F;
            this.arcScaleComponent1.MajorTickmark.ShapeScale = new DevExpress.XtraGauges.Core.Base.FactorF2D(0.6F, 0.8F);
            this.arcScaleComponent1.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style4_2;
            this.arcScaleComponent1.MajorTickmark.TextOffset = -27F;
            this.arcScaleComponent1.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.arcScaleComponent1.MaxValue = 100F;
            this.arcScaleComponent1.MinorTickCount = 4;
            this.arcScaleComponent1.MinorTickmark.ShapeOffset = -7F;
            this.arcScaleComponent1.MinorTickmark.ShapeScale = new DevExpress.XtraGauges.Core.Base.FactorF2D(0.6F, 1F);
            this.arcScaleComponent1.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style4_1;
            this.arcScaleComponent1.Name = "scale1";
            this.arcScaleComponent1.RadiusX = 123F;
            this.arcScaleComponent1.RadiusY = 123F;
            arcScaleRange1.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
            arcScaleRange1.EndThickness = 12F;
            arcScaleRange1.EndValue = 33F;
            arcScaleRange1.Name = "Range0";
            arcScaleRange1.ShapeOffset = -3F;
            arcScaleRange1.StartThickness = 12F;
            arcScaleRange1.StartValue = -0.3F;
            arcScaleRange2.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
            arcScaleRange2.EndThickness = 12F;
            arcScaleRange2.EndValue = 66F;
            arcScaleRange2.Name = "Range1";
            arcScaleRange2.ShapeOffset = -3F;
            arcScaleRange2.StartThickness = 12F;
            arcScaleRange2.StartValue = 33F;
            arcScaleRange3.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Green");
            arcScaleRange3.EndThickness = 12F;
            arcScaleRange3.EndValue = 100.3F;
            arcScaleRange3.Name = "Range2";
            arcScaleRange3.ShapeOffset = -3F;
            arcScaleRange3.StartThickness = 12F;
            arcScaleRange3.StartValue = 66F;
            this.arcScaleComponent1.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            arcScaleRange1,
            arcScaleRange2,
            arcScaleRange3});
            this.arcScaleComponent1.StartAngle = -180F;
            this.arcScaleComponent1.Value = 80F;
            // 
            // arcScaleNeedleComponent1
            // 
            this.arcScaleNeedleComponent1.ArcScale = this.arcScaleComponent1;
            this.arcScaleNeedleComponent1.EndOffset = 5F;
            this.arcScaleNeedleComponent1.Name = "needle";
            this.arcScaleNeedleComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.NeedleShapeType.CircularFull_Style4;
            this.arcScaleNeedleComponent1.StartOffset = -21F;
            this.arcScaleNeedleComponent1.ZOrder = -50;
            // 
            // chartControl4
            // 
            this.chartControl4.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartControl4.DataBindings = null;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Title.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram1.AxisY.Title.Text = "Production";
            xyDiagram1.AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            secondaryAxisY1.AxisID = 0;
            secondaryAxisY1.Name = "Secondary AxisY 1";
            secondaryAxisY1.Visibility = DevExpress.Utils.DefaultBoolean.False;
            secondaryAxisY1.VisibleInPanesSerializable = "-1";
            xyDiagram1.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SecondaryAxisY[] {
            secondaryAxisY1});
            this.chartControl4.Diagram = xyDiagram1;
            this.chartControl4.EmptyChartText.Font = new System.Drawing.Font("Tahoma", 30F);
            this.chartControl4.EmptyChartText.Text = "No Data";
            this.chartControl4.EmptyChartText.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chartControl4.Legend.Name = "Default Legend";
            this.chartControl4.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartControl4.Location = new System.Drawing.Point(636, 7);
            this.chartControl4.Name = "chartControl4";
            pointSeriesLabel1.TextPattern = "{V:#,#}";
            series1.Label = pointSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Series 2";
            splineSeriesView1.Color = System.Drawing.Color.Blue;
            splineSeriesView1.LineMarkerOptions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            splineSeriesView1.LineMarkerOptions.BorderVisible = false;
            splineSeriesView1.LineMarkerOptions.Color = System.Drawing.Color.DodgerBlue;
            splineSeriesView1.LineMarkerOptions.Size = 15;
            splineSeriesView1.LineStyle.Thickness = 3;
            splineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            xySeriesSlideAnimation1.EasingFunction = sineEasingFunction1;
            splineSeriesView1.SeriesAnimation = xySeriesSlideAnimation1;
            splineSeriesView1.Shadow.Visible = true;
            series1.View = splineSeriesView1;
            this.chartControl4.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl4.Size = new System.Drawing.Size(637, 496);
            this.chartControl4.TabIndex = 3;
            chartTitle1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            chartTitle1.Text = "Assembly";
            this.chartControl4.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // chartControl2
            // 
            this.chartControl2.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartControl2.DataBindings = null;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.Title.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram2.AxisY.Title.Text = "Production";
            xyDiagram2.AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            xyDiagram2.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            secondaryAxisY2.AxisID = 0;
            secondaryAxisY2.Name = "Secondary AxisY 1";
            secondaryAxisY2.Visibility = DevExpress.Utils.DefaultBoolean.False;
            secondaryAxisY2.VisibleInPanesSerializable = "-1";
            xyDiagram2.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SecondaryAxisY[] {
            secondaryAxisY2});
            this.chartControl2.Diagram = xyDiagram2;
            this.chartControl2.EmptyChartText.Font = new System.Drawing.Font("Tahoma", 30F);
            this.chartControl2.EmptyChartText.Text = "No Data";
            this.chartControl2.EmptyChartText.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chartControl2.Legend.Name = "Default Legend";
            this.chartControl2.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartControl2.Location = new System.Drawing.Point(4, 8);
            this.chartControl2.Name = "chartControl2";
            pointSeriesLabel2.TextPattern = "{V:#,#}";
            series2.Label = pointSeriesLabel2;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "Series 2";
            splineSeriesView2.Color = System.Drawing.Color.Blue;
            splineSeriesView2.LineMarkerOptions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            splineSeriesView2.LineMarkerOptions.BorderVisible = false;
            splineSeriesView2.LineMarkerOptions.Color = System.Drawing.Color.DodgerBlue;
            splineSeriesView2.LineMarkerOptions.Size = 15;
            splineSeriesView2.LineStyle.Thickness = 3;
            splineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            xySeriesSlideAnimation2.EasingFunction = sineEasingFunction2;
            splineSeriesView2.SeriesAnimation = xySeriesSlideAnimation2;
            splineSeriesView2.Shadow.Visible = true;
            series2.View = splineSeriesView2;
            this.chartControl2.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.chartControl2.Size = new System.Drawing.Size(627, 495);
            this.chartControl2.TabIndex = 1;
            chartTitle2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            chartTitle2.Text = "Stockfit";
            this.chartControl2.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle2});
            // 
            // tmr_Date
            // 
            this.tmr_Date.Interval = 1000;
            this.tmr_Date.Tick += new System.EventHandler(this.tmr_Date_Tick);
            // 
            // FORM_SMT_PROD_DAY_8
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1916, 1042);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.panel1);
            this.Name = "FORM_SMT_PROD_DAY_8";
            this.Text = "FORM_SMT_PROD_DAILY";
            this.Load += new System.EventHandler(this.FORM_SMT_PROD_DAILY_Load);
            this.VisibleChanged += new System.EventHandler(this.FORM_SMT_PROD_DAILY_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axfpView)).EndInit();
            this.gaugeControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.circularRealTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).EndInit();
            this.ResumeLayout(false);

        }

        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        public System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Label lblTitle;
        private AxFPUSpreadADO.AxfpSpread axfpView;
        private System.Windows.Forms.Timer tmr_Date;
        //private AxFPUSpreadADO.AxfpSpread axfpView;
        private DevExpress.XtraCharts.ChartControl chartControl4;
        private DevExpress.XtraCharts.ChartControl chartControl2;
        private System.Windows.Forms.Button cmdBack;
        private DevExpress.XtraEditors.SimpleButton btnMonth;
        private DevExpress.XtraEditors.SimpleButton btnWeek;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularRealTime;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent arcScaleBackgroundLayerComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcScaleComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent arcScaleNeedleComponent1;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.Label lblRPlan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAssemblyProd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnYear;
        #endregion


        string sLineCD = "014";
        string sMLineCD = "001";
        string Lang;
        string sTimeTitle = "Time";
       // string sCuttingTitle = "Cutting (Start 07:30)";
        //string sStitching1Title = "Stitching 1 (Start 07:30)";
        //string sStitching2Title = "Stitching 2 (Start 07:30)";
        string sStitching1TitleEn = "Stitching 1 (Start 07:30)";
        string sStitching2TitleEn = "Stitching 2 (Start 07:30)";
        string sStitching1TitleVn = "Stitching 1 (Start 07:30 ~ 08:30)";
        string sStitching2TitleVn = "Stitching 2 (Start 07:30)";
        string sStockfitTitle = "Stockfit (Start 08:00 )";
        string sAssemblyTitle = "Assembly (Start 08:00 )";
        string sTarget = "Target";
        string sActual = "Actual";
        string sProducQty = "Product Qty (Prs)";
        string sHour = "Hour";
        string sChartTarget = "Target Qty";
        string sChartActual = "Actual Qty";
        string sAssemblyProduct = "Assembly Production";
        
       
        string sRate = "Rate";

        public FORM_SMT_PROD_DAY_8()
        {
            InitializeComponent();
        }
        
        const int AW_SLIDE = 0X40000;
        const int AW_HOR_POSITIVE = 0X4;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;
        const int AW_HIDE = 0x00010000;
       
        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
        DataTable dt = null;
        int CreLoad = 0;
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }
        // SEL_DMC_SUMPROD_BY_CELL
        public DataTable SP_SMT_PROD_DAILY_NEW(string ARG_DATE, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PROD_DAILY.SP_SMT_PROD_DAILY_NEW";

                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_DATE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[3] = "CV_1";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_DATE;
                MyOraDB.Parameter_Values[1] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[2] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[3] = "";


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

        public DataTable SP_SMT_GET_CURRENT_HH()
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PROD_DAILY.SP_SMT_GET_CURRENT_HH";

                MyOraDB.ReDim_Parameter(1);
                MyOraDB.Process_Name = process_name;
             
                MyOraDB.Parameter_Name[0] = "CV_1";

               
                MyOraDB.Parameter_Type[0] = (int)OracleType.Cursor;

            
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

        //SELECT_DMC_INVENTORY_CHART
        public DataTable SP_SMT_PROD_DAILY_BY_OP_NEW(string ARG_DATE, string ARG_LINE_CD, string ARG_MLINE_CD, string ARG_OP_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PROD_DAILY.SP_SMT_PROD_DAILY_BY_OP_NEW";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_DATE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[3] = "ARG_OP_CD";
                MyOraDB.Parameter_Name[4] = "CV_1";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_DATE;
                MyOraDB.Parameter_Values[1] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[2] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[3] = ARG_OP_CD;
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

        public DataTable SP_SMT_PROD_DAILY_REALTIME(string ARG_DATE, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PROD_DAILY.SP_SMT_PROD_DAILY_REALTIME";

                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_DATE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE_CD";              
                MyOraDB.Parameter_Name[3] = "CV_1";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;                
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_DATE;
                MyOraDB.Parameter_Values[1] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[2] = ARG_MLINE_CD;               
                MyOraDB.Parameter_Values[3] = "";


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

        private DataTable Get_Master()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "SP_SMT_GET_MASTER";
                //ARGMODE
                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE";
                MyOraDB.Parameter_Name[3] = "ARG_PROCESS";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = "DSF_PROD";
                MyOraDB.Parameter_Values[1] = ComVar.Var._strValue1;
                MyOraDB.Parameter_Values[2] = ComVar.Var._strValue2 == "" ? "000" : ComVar.Var._strValue2;
                MyOraDB.Parameter_Values[3] = "";
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


        //FullScreen
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
        private void showAnimation(Control flg)
        {
            flg.Hide();
            this.Cursor = Cursors.WaitCursor;
            BindingData();
            AnimateWindow(flg.Handle, 300, AW_SLIDE | 0X4); //IPEX_Monitor.ClassLib.WinAPI.getSlidType("2")
            flg.Show();
            this.Cursor = Cursors.Default;
        }

        //Clear Data & set default Color for Grid
        Color BackColor1 = Color.FromArgb(232, 246, 247);
        Color BackColor2 = Color.White;
        private void ClearGrid(AxFPUSpreadADO.AxfpSpread Grid)
        {
            for (int irow = 3; irow <= Grid.MaxRows; irow++)
            {
                Grid.Row = irow;
                for (int icol = 1; icol <= Grid.MaxCols; icol++)
                {
                    Grid.Col = icol;
                    Grid.SetText(icol, irow, "");
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
                    Grid.Font = new Font("Calibri", 20, FontStyle.Regular);
                }
               
                axfpView.set_RowHeight(irow, 25);
            }
            axfpView.RowsFrozen = 3;         

           
        }
        private void CreateChart()
        {
            try
            {
                //CreateChart(sLineCD, sMLineCD, "UPC", chartControl1, sCuttingTitle);
                CreateChart(sLineCD, sMLineCD, "FSS", chartControl2, sStockfitTitle);
                //  CreateChart(sLineCD, sMLineCD, "UPS1", chartControl3,sStitching1Title);
                CreateChart(sLineCD, sMLineCD, "FGA", chartControl4, sAssemblyTitle);
                //  CreateChart(sLineCD, sMLineCD, "UPS2", chartControl5, sStitching2Title);
                string Now = DateTime.Now.ToString("yyyyMMdd");
                DataTable dt = SP_SMT_PROD_DAILY_REALTIME(Now, sLineCD, sMLineCD);
                double num = 0; double iMin = 0; double iMax = 100; double iRangeMin = 95; double iRangeMax = 98;
                if (dt != null && dt.Rows.Count > 0)
                {
                    num = Convert.ToDouble(dt.Rows[0]["RATE"].ToString());
                    if (num > 3)
                    {
                        if (num < 92)
                        {
                            iMin = Math.Round(num, 0) - 3;
                            //iMax = 98;
                        }
                        else
                        {
                            iMin = 92;
                            //iMax = Math.Round(num, 0) + 3;
                        }
                        if (num > 101)
                        {
                            iMax = Math.Round(num, 0) + 3;

                        }
                        else
                        {
                            iMax = 101;
                        }

                        //iMin = Math.Round(num, 0) - 3;
                        //iMax = Math.Round(num, 0) + 3;
                    }
                    else
                    {
                        iMin = 0;
                        iMax = 100;
                    }
                    //iMax = Math.Round(num,0) + 3;
                    iRangeMin = 95;
                    iRangeMax = 98;
                    lblAssemblyProd.Text = sAssemblyProduct;
                    lblRPlan.Text = sTarget + ": " + Convert.ToDouble(dt.Rows[0]["TARGET"].ToString()).ToString("#,###") + "Prs";
                    lblProd.Text = sActual + " : " + Convert.ToDouble(dt.Rows[0]["QTY"].ToString()).ToString("#,###") + "Prs";
                    lblRate.Text = sRate + " : " + Convert.ToDouble(dt.Rows[0]["RATE"].ToString()).ToString("#,###.##") + "%";
                    if (Convert.ToDouble(dt.Rows[0]["RATE"].ToString()) > 98)
                    {
                        lblRate.BackColor = Color.Green;

                    }
                    else if (Convert.ToDouble(dt.Rows[0]["RATE"].ToString()) > 95)
                    {
                        lblRate.BackColor = Color.Yellow;

                    }
                    else
                    {
                        lblRate.BackColor = Color.Red;
                    }

                }
                BindingGauges(circularRealTime, num, iMin, iMax, iRangeMin, iRangeMax);
            }
            catch 
            {}
            
            
        }

        private void CreateChart(string line_cd, string mline_cd, string op_cd, DevExpress.XtraCharts.ChartControl _chartControl, string _title)
        {
            try
            {
                // Create a new chart.
                _chartControl.Series.Clear();
                _chartControl.Titles[0].Text = _title;
                //DataSource
                string Now = DateTime.Now.ToString("yyyyMMdd");
                DataTable dt = SP_SMT_PROD_DAILY_BY_OP_NEW(Now, line_cd, mline_cd, op_cd);

                // Create two series.
                Series series1 = new Series(sChartTarget, ViewType.Line);
                Series series2 = new Series(sChartActual, ViewType.Spline);

                DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
                DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();
                DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
                DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
                DevExpress.XtraCharts.BarWidenAnimation barWidenAnimation1 = new DevExpress.XtraCharts.BarWidenAnimation();
                DevExpress.XtraCharts.ElasticEasingFunction elasticEasingFunction1 = new DevExpress.XtraCharts.ElasticEasingFunction();


                DevExpress.XtraCharts.XYSeriesBlowUpAnimation xySeriesBlowUpAnimation2 = new DevExpress.XtraCharts.XYSeriesBlowUpAnimation();
                DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation2 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
                DevExpress.XtraCharts.XYSeriesUnwrapAnimation xySeriesUnwrapAnimation2 = new DevExpress.XtraCharts.XYSeriesUnwrapAnimation();

                DevExpress.XtraCharts.PowerEasingFunction powerEasingFunction2 = new DevExpress.XtraCharts.PowerEasingFunction();
                DevExpress.XtraCharts.SineEasingFunction sineEasingFunction2 = new DevExpress.XtraCharts.SineEasingFunction();
                // Add points to them, with their arguments different.
                if (dt != null && dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        series1.Points.Add(new SeriesPoint(dt.Rows[i]["HMS"].ToString(), dt.Rows[i]["TARGET"])); //GetRandomNumber(10, 50)
                        series2.Points.Add(new SeriesPoint(dt.Rows[i]["HMS"].ToString(), dt.Rows[i]["QTY"])); //dt.Rows[i]["HMS"]
                    }
                    //_chartControl1.Series[0].ArgumentScaleType = ScaleType.Qualitative;
                }
                else
                {
                    for (int i = 1; i < 9; i++)
                    {
                        //series1.Points.Add(new SeriesPoint(dt.Rows[i]["HMS"].ToString(), dt.Rows[i]["QTY"])); //GetRandomNumber(10, 50)
                        series1.Points.Add(new SeriesPoint(i + "H", 0));
                        series2.Points.Add(new SeriesPoint(i + "H", 0)); //dt.Rows[i]["HMS"]
                    }
                }

                // series2 = splineSeriesView1;
                // Add both series to the chart.
                //chartControl1.Series.AddRange(new Series[] { series1, series2 });


                _chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1, series2 };
                ((XYDiagram)_chartControl.Diagram).AxisY.Title.Text = sProducQty;
                ((XYDiagram)_chartControl.Diagram).AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
                ((XYDiagram)_chartControl.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
                ((XYDiagram)_chartControl.Diagram).AxisX.Title.Text = sHour;
                ((XYDiagram)_chartControl.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
                ((XYDiagram)_chartControl.Diagram).AxisX.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));



                // Create two secondary axes, and add them to the chart's Diagram.



                //Series 1
                //barSlideAnimation1.EasingFunction = bounceEasingFunction1;
                //sideBySideBarSeriesView1.Animation = barWidenAnimation1;
                //series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                //sideBySideBarSeriesView1.ColorEach = false;
                //sideBySideBarSeriesView1.Shadow.Visible = false;
                //sideBySideBarSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(241)))), ((int)(((byte)(6)))));
                //series1.View = sideBySideBarSeriesView1;

                // Series 2
                //splineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(21)))), ((int)(((byte)(203)))));


                splineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                splineSeriesView1.Shadow.Visible = false;
                splineSeriesView1.Color = System.Drawing.Color.Green;
                splineSeriesView1.LineMarkerOptions.BorderColor = System.Drawing.Color.DodgerBlue;
                splineSeriesView1.LineMarkerOptions.BorderVisible = false;

                splineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                splineSeriesView2.Shadow.Visible = false;
                splineSeriesView2.Color = System.Drawing.Color.DodgerBlue;
                splineSeriesView2.LineMarkerOptions.BorderColor = System.Drawing.Color.DodgerBlue;
                splineSeriesView2.LineMarkerOptions.BorderVisible = false;

                //splineSeriesView1.LineMarkerOptions.Color = System.Drawing.Color.Red;
                splineSeriesView2.LineMarkerOptions.Kind = DevExpress.XtraCharts.MarkerKind.Circle;
                splineSeriesView2.LineMarkerOptions.Color = System.Drawing.Color.DodgerBlue;
                splineSeriesView2.LineMarkerOptions.Size = 15;
                splineSeriesView2.LineStyle.Thickness = 3;
                series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                //pointSeriesLabel1.TextPattern = "{V:#,#}";

                series1.View = splineSeriesView1;

                series2.Label.TextPattern = "{V:#,#}";
                series2.View = splineSeriesView2;
                //((LineSeriesView)series2.View).AxisY = myAxisY;
                xySeriesUnwindAnimation2.EasingFunction = sineEasingFunction2; //powerEasingFunction1;
                splineSeriesView2.SeriesAnimation = xySeriesUnwindAnimation2;//xySeriesBlowUpAnimation1;//xySeriesUnwindAnimation1; // xySeriesUnwrapAnimation1;
                //Legend
                //_chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
                //_chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
                //_chartControl1.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBoxAndMarker;
                //_chartControl1.Legend.Name = "Phuoc's Legend";
                ((XYDiagram)_chartControl.Diagram).AxisX.VisualRange.Auto = true;
                ((XYDiagram)_chartControl.Diagram).AxisX.VisualRange.AutoSideMargins = false;
                ((XYDiagram)_chartControl.Diagram).AxisX.VisualRange.SideMarginsValue = 2;
                ((XYDiagram)_chartControl.Diagram).AxisX.Label.Angle = 0;
                ((XYDiagram)_chartControl.Diagram).AxisX.Label.Font = new System.Drawing.Font("Calibri", 12, System.Drawing.FontStyle.Bold);
                ((XYDiagram)_chartControl.Diagram).AxisX.NumericScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Automatic;
                //((XYDiagram)_chartControl1.Diagram).AxisY.NumericScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Automatic;
                ((XYDiagram)_chartControl.Diagram).AxisY.Label.Font = new System.Drawing.Font("Calibri", 12, System.Drawing.FontStyle.Bold);

                ((XYDiagram)_chartControl.Diagram).AxisX.Title.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ((XYDiagram)_chartControl.Diagram).AxisY.Title.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ((XYDiagram)_chartControl.Diagram).AxisY.Title.TextColor = Color.DarkOrange;
                ((XYDiagram)_chartControl.Diagram).AxisX.Title.TextColor = Color.DarkOrange;

                //myAxisY.Title.Text = "Inventory (Prs)";
                //myAxisY.Label.TextColor = Color.Blue;
                //myAxisY.Color = Color.Magenta;
                //this.splitMain.Panel2.Controls.Add(_chartControl);
            }
            catch 
            {}
            
        }

        private void BindingGauges(DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGauge, double num, double iMin, double iMax, double iRangeMin, double iRangeMax)
        {
            
            if (circularGauge.Scales.Count <= 0)
            {
                return;
            }
            circularGauge.Scales[0].EnableAnimation = false;
          
            circularGauge.Scales[0].MinValue = (int)iMin;
            circularGauge.Scales[0].MaxValue = (int)iMax;
      
            circularGauge.Scales[0].Value = 0;
           
            if (circularGauge.Scales[0].Ranges.Count >= 3)
            {
                circularGauge.Scales[0].Ranges[0].StartValue = (float)iMin;
                circularGauge.Scales[0].Ranges[0].EndValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].StartValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].EndValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].StartValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].EndValue = (float)iMax;

            }
         
            try
            {

                circularGauge.Scales[0].MinValue = (int)iMin;
                circularGauge.Scales[0].MaxValue = (int)iMax;
           

                circularGauge.Scales[0].EnableAnimation = true;
                circularGauge.Scales[0].EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
              

                
               circularGauge.Scales[0].Value = (float)num;
                 
               
            }
            catch 
            { }
            // }
        }

        private string getCurrentTime()
        {
            string iTime = "0";
            DataTable dt = null;
            dt = SP_SMT_GET_CURRENT_HH();
            if (dt != null && dt.Rows.Count > 0)
                iTime = dt.Rows[0][0].ToString();
            return iTime;
        }

        private void BindingData()
        {
            try
            {
                string iCurent = getCurrentTime();
                string Now = DateTime.Now.ToString("yyyyMMdd");
                dt = SP_SMT_PROD_DAILY_NEW(Now, sLineCD, sMLineCD);
                int irow = 3;

                if (dt != null && dt.Rows.Count > 0)
                {
                    axfpView.MaxRows = dt.Rows.Count + 2;
                    ClearGrid(axfpView);
                    //AxFPUSpreadADO.AxfpSpread
                    //axfpView.SetCellBorder(1, 1, axfpView.MaxCols, axfpView.MaxRows, AxFPUSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, AxFPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                    //axfpView.SetCellBorder(1, 1, axfpView.MaxCols, axfpView.MaxRows, AxFPUSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0, AxFPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                    //axfpView.SetCellBorder(1, 1, axfpView.MaxCols, axfpView.MaxRows, AxFPUSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, AxFPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                    //axfpView.SetCellBorder(1, 1, axfpView.MaxCols, axfpView.MaxRows, AxFPUSpreadADO.CellBorderIndexConstants.CellBorderIndexRight, 0, AxFPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                    foreach (DataRow dr in dt.Rows)
                    {
                        axfpView.SetText(1, irow, dr["HMS"].ToString());
                        /*
                        
                        if (dr["UPC_TARGET"].ToString() != "0")
                        {
                            axfpView.SetText(2, irow, dr["UPC_TARGET"].ToString());
                        }
                        else
                        {
                            axfpView.SetText(2, irow, "");
                        }

                        if (dr["UPC_ACT"].ToString() != "0")
                        {
                            axfpView.SetText(3, irow, dr["UPC_ACT"].ToString());
                        }
                        else
                        {
                            axfpView.SetText(3, irow, "");
                        }

                        if (dr["UPC_RATE"].ToString() != "0")
                        {
                            axfpView.SetText(4, irow, dr["UPC_RATE"].ToString());
                            if (irow < Convert.ToInt32(iCurent) + 2)
                            {
                                if (Convert.ToDouble(dr["UPC_RATE"].ToString()) > 98)
                                {
                                    axfpView.Row = irow;
                                    axfpView.Col = 4;
                                    axfpView.BackColor = Color.Green;
                                }
                                else if (Convert.ToDouble(dr["UPC_RATE"].ToString()) > 95)
                                {
                                    axfpView.Row = irow;
                                    axfpView.Col = 4;
                                    axfpView.BackColor = Color.Yellow;
                                }
                                else
                                {
                                    axfpView.Row = irow;
                                    axfpView.Col = 4;
                                    axfpView.BackColor = Color.Red;
                                }
                            }
                        }
                        else
                        {
                            axfpView.SetText(4, irow, "");
                            if (irow < Convert.ToInt32(iCurent) + 2 && dr["UPC_TARGET"].ToString() != "0")
                            {
                                axfpView.Row = irow;
                                axfpView.Col = 4;
                                axfpView.BackColor = Color.Red;
                            }

                        }

                        if (dr["UPS_TARGET1"].ToString() != "0")
                        {
                            axfpView.SetText(5, irow, dr["UPS_TARGET1"].ToString());
                        }
                        else
                        {
                            axfpView.SetText(5, irow, "");
                        }

                        if (dr["UPS_ACT1"].ToString() != "0")
                        {
                            axfpView.SetText(6, irow, dr["UPS_ACT1"].ToString());
                        }
                        else
                        {
                            axfpView.SetText(6, irow, "");
                        }

                        if (dr["UPS_RATE1"].ToString() != "0")
                        {
                            axfpView.SetText(7, irow, dr["UPS_RATE1"].ToString());

                            if (irow < Convert.ToInt32(iCurent) + 2)
                            {
                                if (Convert.ToDouble(dr["UPS_RATE1"].ToString()) > 98)
                                {
                                    axfpView.Row = irow;
                                    axfpView.Col = 7;
                                    axfpView.BackColor = Color.Green;
                                }
                                else if (Convert.ToDouble(dr["UPS_RATE1"].ToString()) > 95)
                                {
                                    axfpView.Row = irow;
                                    axfpView.Col = 7;
                                    axfpView.BackColor = Color.Yellow;
                                }
                                else
                                {
                                    axfpView.Row = irow;
                                    axfpView.Col = 7;
                                    axfpView.BackColor = Color.Red;
                                }
                            }
                        }
                        else
                        {
                            axfpView.SetText(7, irow, "");
                            if (irow < Convert.ToInt32(iCurent) + 2 && dr["UPS_TARGET1"].ToString() != "0")
                            {
                                axfpView.Row = irow;
                                axfpView.Col = 7;
                                axfpView.BackColor = Color.Red;
                            }
                        }


                        if (dr["UPS_TARGET2"].ToString() != "0")
                        {
                            axfpView.SetText(8, irow, dr["UPS_TARGET2"].ToString());
                        }
                        else
                        {
                            axfpView.SetText(8, irow, "");
                        }

                        if (dr["UPS_ACT2"].ToString() != "0")
                        {
                            axfpView.SetText(9, irow, dr["UPS_ACT2"].ToString());
                        }
                        else
                        {
                            axfpView.SetText(9, irow, "");
                        }

                        if (dr["UPS_RATE2"].ToString() != "0")
                        {
                            axfpView.SetText(10, irow, dr["UPS_RATE2"].ToString());

                            if (irow < Convert.ToInt32(iCurent) + 2)
                            {
                                if (Convert.ToDouble(dr["UPS_RATE2"].ToString()) > 98)
                                {
                                    axfpView.Row = irow;
                                    axfpView.Col = 10;
                                    axfpView.BackColor = Color.Green;
                                }
                                else if (Convert.ToDouble(dr["UPS_RATE2"].ToString()) > 95)
                                {
                                    axfpView.Row = irow;
                                    axfpView.Col = 10;
                                    axfpView.BackColor = Color.Yellow;
                                }
                                else
                                {
                                    axfpView.Row = irow;
                                    axfpView.Col = 10;
                                    axfpView.BackColor = Color.Red;
                                }
                            }
                        }
                        else
                        {
                            axfpView.SetText(10, irow, "");
                            if (irow < Convert.ToInt32(iCurent) + 2 && dr["UPS_TARGET2"].ToString() != "0")
                            {
                                axfpView.Row = irow;
                                axfpView.Col = 10;
                                axfpView.BackColor = Color.Red;
                            }
                        }
                        */

                        //FSS
                        if (dr["FSS_TARGET"].ToString() != "0")
                        {
                            axfpView.SetText(2, irow, dr["FSS_TARGET"].ToString());
                        }
                        else
                        {
                            axfpView.SetText(2, irow, "");
                        }
                        if (dr["FSS_ACT"].ToString() != "0")
                        {
                            axfpView.SetText(3, irow, dr["FSS_ACT"].ToString());
                        }
                        else
                        {
                            axfpView.SetText(3, irow, "");
                        }
                        if (dr["FSS_RATE"].ToString() != "0")
                        {
                            axfpView.SetText(4, irow, dr["FSS_RATE"].ToString());
                            if (irow < Convert.ToInt32(iCurent) + 2)
                            {
                                if (Convert.ToDouble(dr["FSS_RATE"].ToString()) > 98)
                                {
                                    axfpView.Row = irow;
                                    axfpView.Col = 4;
                                    axfpView.BackColor = Color.Green;
                                }
                                else if (Convert.ToDouble(dr["FSS_RATE"].ToString()) > 95)
                                {
                                    axfpView.Row = irow;
                                    axfpView.Col = 4;
                                    axfpView.BackColor = Color.Yellow;
                                }
                                else
                                {
                                    axfpView.Row = irow;
                                    axfpView.Col = 4;
                                    axfpView.BackColor = Color.Red;
                                }
                            }
                        }
                        else
                        {
                            axfpView.SetText(13, irow, "");
                            if (irow < Convert.ToInt32(iCurent) + 2 && dr["FSS_TARGET"].ToString() != "0")
                            {
                                axfpView.Row = irow;
                                axfpView.Col = 4;
                                axfpView.BackColor = Color.Red;
                            }
                        }

                        //FGA
                        if (dr["FGA_TARGET"].ToString() != "0")
                        {
                            axfpView.SetText(5, irow, dr["FGA_TARGET"].ToString());
                        }
                        else
                        {
                            axfpView.SetText(5, irow, "");
                        }
                        if (dr["FGA_ACT"].ToString() != "0")
                        {
                            axfpView.SetText(6, irow, dr["FGA_ACT"].ToString());
                        }
                        else
                        {
                            axfpView.SetText(6, irow, "");
                        }
                        if (dr["FGA_RATE"].ToString() != "0")
                        {
                            axfpView.SetText(7, irow, dr["FGA_RATE"].ToString());
                            if (irow < Convert.ToInt32(iCurent) + 2)
                            {
                                if (Convert.ToDouble(dr["FGA_RATE"].ToString()) > 98)
                                {
                                    axfpView.Row = irow;
                                    axfpView.Col = 7;
                                    axfpView.BackColor = Color.Green;
                                }
                                else if (Convert.ToDouble(dr["FGA_RATE"].ToString()) > 95)
                                {
                                    axfpView.Row = irow;
                                    axfpView.Col = 7;
                                    axfpView.BackColor = Color.Yellow;
                                } 
                                else
                                {
                                    axfpView.Row = irow;
                                    axfpView.Col = 7;
                                    axfpView.BackColor = Color.Red;
                                }
                            }
                        }
                        else
                        {
                            axfpView.SetText(16, irow, "");
                            if (irow < Convert.ToInt32(iCurent) + 2 && dr["FGA_TARGET"].ToString() != "0")
                            {
                                axfpView.Row = irow;
                                axfpView.Col = 7;
                                axfpView.BackColor = Color.Red;
                            }
                        }


                        if (dr["HMS"].ToString() == "TOTAL")
                        {
                            for (int i = 0; i < dt.Columns.Count-1; i++)
                            {
                                axfpView.Row = irow;
                                axfpView.Col = i + 1;
                                axfpView.BackColor = Color.Orange;

                            }

                        }
                        irow++;
                    }
                    
                    if (iCurent != "0")
                    {
                        
                        for (int i = 0; i < dt.Columns.Count-1; i++)
                        {
                            axfpView.Col = i + 1;
                            axfpView.Row = Convert.ToInt32(iCurent) + 2;
                            axfpView.BackColor = Color.Salmon;
                        }


                    }
                }
                
                
            }
            catch
            {
               // MessageBox.Show(ex.ToString());
            }
        }


        private void FORM_SMT_PROD_DAILY_Load(object sender, EventArgs e)
        {
            setConfigForm();


            
           
        }
        private void Init_Lang()
        {
            axfpView.SetText(1, 1, sTimeTitle);

            axfpView.SetText(2, 1, sStockfitTitle);
            axfpView.SetText(5, 1, sAssemblyTitle);


            axfpView.SetText(2, 2, sTarget);
            axfpView.SetText(3, 2, sActual);
            axfpView.SetText(5, 2, sTarget);
            axfpView.SetText(6, 2, sActual);

            //axfpView.SetText(8, 2, sTarget);
            //axfpView.SetText(9, 2, sActual);
            //axfpView.SetText(11, 2, sTarget);
            //axfpView.SetText(12, 2, sActual);
            //axfpView.SetText(14, 2, sTarget);
            //axfpView.SetText(15, 2, sActual);
        }
              

        

        private void tmr_Date_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            CreLoad++;
            if (CreLoad >= 30)
            {
                CreLoad = 0;
                showAnimation(axfpView);
                CreateChart();
              
                
            }
        }


        private void FORM_SMT_PROD_DAILY_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cmdBack.Tag = ComVar.Var._Frm_Back;
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                initForm();

            }
            else
            {
                tmr_Date.Stop();
            }
        }


        private void initForm()
        {
            try
            {
                DataTable dt = Get_Master();
                sLineCD = ComVar.Var._strValue1;
                sMLineCD = ComVar.Var._strValue2;
                Lang = ComVar.Var._strValue3;

                CreLoad = 29;
                tmr_Date.Start();

                if (this.sMLineCD == "001")
                {
                    sStitching1TitleEn = "Stitching 1(Start " + dt.Rows[0]["UPS"].ToString() + ")";
                    sStitching2TitleEn = "Stitching 2(Start " + dt.Rows[0]["UPS"].ToString() + ")";
                    sStitching1TitleVn = "May 1(Từ " + dt.Rows[0]["UPS"].ToString() + ")";
                    sStitching1TitleVn = "May 2(Từ " + dt.Rows[0]["UPS"].ToString() + ")";
                }
                if (this.sMLineCD == "002")
                {
                    sStitching1TitleEn = "Stitching 3(Start " + dt.Rows[0]["UPS"].ToString() + ")";
                    sStitching2TitleEn = "Stitching 4(Start " + dt.Rows[0]["UPS"].ToString() + ")";
                    sStitching1TitleVn = "May 3(Từ " + dt.Rows[0]["UPS"].ToString() + ")";
                    sStitching2TitleVn = "May 4(Từ " + dt.Rows[0]["UPS"].ToString() + ")";
                }
                else if (this.sMLineCD == "003")
                {
                    sStitching1TitleEn = "Stitching 5(Start " + dt.Rows[0]["UPS"].ToString() + ")";
                    sStitching2TitleEn = "Stitching 6(Start " + dt.Rows[0]["UPS"].ToString() + ")";
                    sStitching1TitleVn = "May 5(Từ " + dt.Rows[0]["UPS"].ToString() + ")";
                    sStitching1TitleVn = "May 6(Từ " + dt.Rows[0]["UPS"].ToString() + ")";
                }
                else if (this.sMLineCD == "004")
                {
                    sStitching1TitleEn = "Stitching 7(Start " + dt.Rows[0]["UPS"].ToString() + ")";
                    sStitching2TitleEn = "Stitching 8(Start " + dt.Rows[0]["UPS"].ToString() + ")";
                    sStitching1TitleVn = "May 7(Từ " + dt.Rows[0]["UPS"].ToString() + ")";
                    sStitching1TitleVn = "May 8(Từ " + dt.Rows[0]["UPS"].ToString() + ")";
                }

                switch (Lang)
                {
                    case "Vn":
                        lblTitle.Text = "Tình Trạng Sản Xuất Theo Ngày";
                        btnDay.Text = "Ngày";
                        btnMonth.Text = "Tháng";
                        btnWeek.Text = "Tuần";
                        btnYear.Text = "Năm";
                        sTimeTitle = "Giờ";
                       // sCuttingTitle = "Cắt(Từ 07:30)";
                       // sStitching1Title = sStitching1TitleVn;
                       // sStitching2Title = sStitching2TitleVn;
                        sStockfitTitle = "Chuẩn bị(Từ 08:00)";
                        sAssemblyTitle = "Lắp ráp(Từ 08:00)";
                        sTarget = "Mục tiêu";
                        sActual = "Thực tế";
                        sProducQty = "Sản xuất (Prs)";
                        sHour = "Giờ";
                        sChartTarget = "Mục tiêu";
                        sChartActual = "Thực tế";
                        sAssemblyProduct = "Sản xuất lắp ráp";
                        sRate = "Tỷ lệ";
                        break;
                    case "En":
                        lblTitle.Text = "Production Status By Day";
                        btnDay.Text = "Day";
                        btnMonth.Text = "Month";
                        btnWeek.Text = "Week";
                        btnYear.Text = "Year";

                        sTimeTitle = "Time";
                       // sCuttingTitle = "Cutting(Start 07:30)";
                      //  sStitching1Title = sStitching1TitleEn;
                       // sStitching2Title = sStitching2TitleEn;
                        sStockfitTitle = "Stockfit(Start " + dt.Rows[0]["FSS"].ToString() + ")";
                        sAssemblyTitle = "Assembly(Start " + dt.Rows[0]["FGA"].ToString() + ")";
                        sTarget = "Target";
                        sActual = "Actual";
                        sProducQty = "Product Qty(Prs)";
                        sHour = "Hour";
                        sChartTarget = "Target Qty";
                        sChartActual = "Actual Qty";
                        sAssemblyProduct = "Assembly Production";
                        sRate = "Rate";
                        break;

                }

                Init_Lang();
            }
            catch 
            {
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
