namespace FORM
{
    partial class FORM_SMT_PRODUCTIVITY_WEEK_8
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange1 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange2 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange3 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_SMT_PRODUCTIVITY_WEEK_8));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.pn_body = new System.Windows.Forms.Panel();
            this.gaugeControl2 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cGauge1 = new DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge();
            this.arcScaleBackgroundLayerComponent3 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent();
            this.arcScaleTrucks = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
            this.lblGaugesValue = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.arcScaleNeedleComponent3 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent();
            this.arcScaleSpindleCapComponent2 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent();
            this.Chart4 = new DevExpress.XtraCharts.ChartControl();
            this.Chart5 = new DevExpress.XtraCharts.ChartControl();
            this.axGrid = new AxFPUSpreadADO.AxfpSpread();
            this.btnWeek = new DevExpress.XtraEditors.SimpleButton();
            this.btnMonth = new DevExpress.XtraEditors.SimpleButton();
            this.btnYear = new DevExpress.XtraEditors.SimpleButton();
            this.btnDay = new DevExpress.XtraEditors.SimpleButton();
            this.cmdBack = new System.Windows.Forms.Button();
            this.pn_body.SuspendLayout();
            this.gaugeControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleTrucks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGaugesValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 65.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1916, 109);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Tag = "Minimized";
            this.lblTitle.Text = "Productivity Status by Week";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.DoubleClick += new System.EventHandler(this.menu_Click);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblDate.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblDate.Location = new System.Drawing.Point(1662, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(255, 109);
            this.lblDate.TabIndex = 47;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pn_body
            // 
            this.pn_body.BackColor = System.Drawing.Color.Transparent;
            this.pn_body.Controls.Add(this.gaugeControl2);
            this.pn_body.Controls.Add(this.Chart4);
            this.pn_body.Controls.Add(this.Chart5);
            this.pn_body.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_body.Location = new System.Drawing.Point(0, 109);
            this.pn_body.Name = "pn_body";
            this.pn_body.Size = new System.Drawing.Size(1916, 1036);
            this.pn_body.TabIndex = 48;
            // 
            // gaugeControl2
            // 
            this.gaugeControl2.AutoLayout = false;
            this.gaugeControl2.Controls.Add(this.label1);
            this.gaugeControl2.Controls.Add(this.label2);
            this.gaugeControl2.Controls.Add(this.label3);
            this.gaugeControl2.Controls.Add(this.label4);
            this.gaugeControl2.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.cGauge1});
            this.gaugeControl2.Location = new System.Drawing.Point(619, 483);
            this.gaugeControl2.Name = "gaugeControl2";
            this.gaugeControl2.Size = new System.Drawing.Size(645, 461);
            this.gaugeControl2.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 39);
            this.label1.TabIndex = 76;
            this.label1.Text = "POD";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(486, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 74;
            this.label2.Text = "8~9";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Green;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(560, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 23);
            this.label3.TabIndex = 75;
            this.label3.Text = ">9";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Red;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(427, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 23);
            this.label4.TabIndex = 73;
            this.label4.Text = "<8";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cGauge1
            // 
            this.cGauge1.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent[] {
            this.arcScaleBackgroundLayerComponent3});
            this.cGauge1.Bounds = new System.Drawing.Rectangle(10, 54, 625, 403);
            this.cGauge1.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.lblGaugesValue});
            this.cGauge1.Name = "cGauge1";
            this.cGauge1.Needles.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent[] {
            this.arcScaleNeedleComponent3});
            this.cGauge1.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent[] {
            this.arcScaleTrucks});
            this.cGauge1.SpindleCaps.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent[] {
            this.arcScaleSpindleCapComponent2});
            // 
            // arcScaleBackgroundLayerComponent3
            // 
            this.arcScaleBackgroundLayerComponent3.ArcScale = this.arcScaleTrucks;
            this.arcScaleBackgroundLayerComponent3.Name = "bg1";
            this.arcScaleBackgroundLayerComponent3.ScaleCenterPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.71F);
            this.arcScaleBackgroundLayerComponent3.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.CircularHalf_Style4;
            this.arcScaleBackgroundLayerComponent3.Size = new System.Drawing.SizeF(250F, 176F);
            this.arcScaleBackgroundLayerComponent3.ZOrder = 1000;
            // 
            // arcScaleTrucks
            // 
            this.arcScaleTrucks.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleTrucks.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleTrucks.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleTrucks.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleTrucks.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 12F);
            this.arcScaleTrucks.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.arcScaleTrucks.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 165F);
            this.arcScaleTrucks.EndAngle = 0F;
            this.arcScaleTrucks.MajorTickCount = 7;
            this.arcScaleTrucks.MajorTickmark.FormatString = "{0:F0}";
            this.arcScaleTrucks.MajorTickmark.ShapeOffset = -14F;
            this.arcScaleTrucks.MajorTickmark.ShapeScale = new DevExpress.XtraGauges.Core.Base.FactorF2D(0.6F, 0.8F);
            this.arcScaleTrucks.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style4_2;
            this.arcScaleTrucks.MajorTickmark.TextOffset = -27F;
            this.arcScaleTrucks.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.arcScaleTrucks.MaxValue = 6F;
            this.arcScaleTrucks.MinorTickCount = 4;
            this.arcScaleTrucks.MinorTickmark.ShapeOffset = -7F;
            this.arcScaleTrucks.MinorTickmark.ShapeScale = new DevExpress.XtraGauges.Core.Base.FactorF2D(0.6F, 1F);
            this.arcScaleTrucks.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style4_1;
            this.arcScaleTrucks.Name = "scale1";
            this.arcScaleTrucks.RadiusX = 123F;
            this.arcScaleTrucks.RadiusY = 123F;
            arcScaleRange1.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
            arcScaleRange1.EndThickness = 12F;
            arcScaleRange1.EndValue = 1.5F;
            arcScaleRange1.Name = "Range0";
            arcScaleRange1.ShapeOffset = -3F;
            arcScaleRange1.StartThickness = 12F;
            arcScaleRange2.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
            arcScaleRange2.EndThickness = 12F;
            arcScaleRange2.EndValue = 4F;
            arcScaleRange2.Name = "Range1";
            arcScaleRange2.ShapeOffset = -3F;
            arcScaleRange2.StartThickness = 12F;
            arcScaleRange2.StartValue = 1.5F;
            arcScaleRange3.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Green");
            arcScaleRange3.EndThickness = 12F;
            arcScaleRange3.EndValue = 6F;
            arcScaleRange3.Name = "Range2";
            arcScaleRange3.ShapeOffset = -4F;
            arcScaleRange3.StartThickness = 12F;
            arcScaleRange3.StartValue = 4F;
            this.arcScaleTrucks.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            arcScaleRange1,
            arcScaleRange2,
            arcScaleRange3});
            this.arcScaleTrucks.StartAngle = -180F;
            this.arcScaleTrucks.Value = 6F;
            // 
            // lblGaugesValue
            // 
            this.lblGaugesValue.AppearanceText.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGaugesValue.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.lblGaugesValue.Name = "cGauge1_Label1";
            this.lblGaugesValue.Text = "";
            this.lblGaugesValue.ZOrder = -1001;
            // 
            // arcScaleNeedleComponent3
            // 
            this.arcScaleNeedleComponent3.ArcScale = this.arcScaleTrucks;
            this.arcScaleNeedleComponent3.EndOffset = 5F;
            this.arcScaleNeedleComponent3.Name = "needle1";
            this.arcScaleNeedleComponent3.ShapeType = DevExpress.XtraGauges.Core.Model.NeedleShapeType.CircularFull_Style4;
            this.arcScaleNeedleComponent3.StartOffset = -21F;
            this.arcScaleNeedleComponent3.ZOrder = -50;
            // 
            // arcScaleSpindleCapComponent2
            // 
            this.arcScaleSpindleCapComponent2.ArcScale = this.arcScaleTrucks;
            this.arcScaleSpindleCapComponent2.Name = "cap1";
            this.arcScaleSpindleCapComponent2.ShapeType = DevExpress.XtraGauges.Core.Model.SpindleCapShapeType.CircularFull_Style4;
            this.arcScaleSpindleCapComponent2.Size = new System.Drawing.SizeF(16F, 16F);
            this.arcScaleSpindleCapComponent2.ZOrder = -100;
            // 
            // Chart4
            // 
            this.Chart4.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.Chart4.DataBindings = null;
            xyDiagram1.AxisX.GridLines.Visible = true;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.Chart4.Diagram = xyDiagram1;
            this.Chart4.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.Chart4.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.Chart4.Legend.Name = "Default Legend";
            this.Chart4.Location = new System.Drawing.Point(12, 12);
            this.Chart4.Name = "Chart4";
            sideBySideBarSeriesLabel1.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
            series1.Label = sideBySideBarSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Series 1";
            this.Chart4.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.Chart4.Size = new System.Drawing.Size(921, 465);
            this.Chart4.TabIndex = 17;
            chartTitle1.Alignment = System.Drawing.StringAlignment.Near;
            chartTitle1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold);
            chartTitle1.Text = "Stockfit";
            chartTitle1.TextColor = System.Drawing.Color.Blue;
            this.Chart4.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // Chart5
            // 
            this.Chart5.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.Chart5.DataBindings = null;
            xyDiagram2.AxisX.GridLines.Visible = true;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            this.Chart5.Diagram = xyDiagram2;
            this.Chart5.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.Chart5.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.Chart5.Legend.Name = "Default Legend";
            this.Chart5.Location = new System.Drawing.Point(949, 12);
            this.Chart5.Name = "Chart5";
            sideBySideBarSeriesLabel2.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
            series2.Label = sideBySideBarSeriesLabel2;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "Series 1";
            this.Chart5.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.Chart5.Size = new System.Drawing.Size(967, 464);
            this.Chart5.TabIndex = 15;
            chartTitle2.Alignment = System.Drawing.StringAlignment.Near;
            chartTitle2.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold);
            chartTitle2.Text = "Assembly";
            chartTitle2.TextColor = System.Drawing.Color.Blue;
            this.Chart5.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle2});
            // 
            // axGrid
            // 
            this.axGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axGrid.DataSource = null;
            this.axGrid.Location = new System.Drawing.Point(0, 4);
            this.axGrid.Name = "axGrid";
            this.axGrid.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGrid.OcxState")));
            this.axGrid.Size = new System.Drawing.Size(75, 63);
            this.axGrid.TabIndex = 0;
            this.axGrid.Visible = false;
            // 
            // btnWeek
            // 
            this.btnWeek.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWeek.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWeek.Appearance.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold);
            this.btnWeek.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnWeek.Appearance.Options.UseBackColor = true;
            this.btnWeek.Appearance.Options.UseFont = true;
            this.btnWeek.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnWeek.Enabled = false;
            this.btnWeek.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnWeek.ImageOptions.Image")));
            this.btnWeek.Location = new System.Drawing.Point(1300, 58);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(175, 48);
            this.btnWeek.TabIndex = 55;
            this.btnWeek.Text = "Week";
            // 
            // btnMonth
            // 
            this.btnMonth.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMonth.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMonth.Appearance.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold);
            this.btnMonth.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnMonth.Appearance.Options.UseBackColor = true;
            this.btnMonth.Appearance.Options.UseFont = true;
            this.btnMonth.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnMonth.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMonth.ImageOptions.Image")));
            this.btnMonth.Location = new System.Drawing.Point(1481, 5);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(175, 48);
            this.btnMonth.TabIndex = 55;
            this.btnMonth.Text = "Month";
            this.btnMonth.Click += new System.EventHandler(this.menu_Click);
            // 
            // btnYear
            // 
            this.btnYear.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnYear.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnYear.Appearance.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold);
            this.btnYear.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnYear.Appearance.Options.UseBackColor = true;
            this.btnYear.Appearance.Options.UseFont = true;
            this.btnYear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnYear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYear.ImageOptions.Image")));
            this.btnYear.Location = new System.Drawing.Point(1481, 58);
            this.btnYear.Name = "btnYear";
            this.btnYear.Size = new System.Drawing.Size(175, 48);
            this.btnYear.TabIndex = 54;
            this.btnYear.Text = "Year";
            this.btnYear.Click += new System.EventHandler(this.menu_Click);
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
            this.btnDay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDay.ImageOptions.Image")));
            this.btnDay.Location = new System.Drawing.Point(1300, 5);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(175, 48);
            this.btnDay.TabIndex = 53;
            this.btnDay.Text = "Day";
            this.btnDay.Click += new System.EventHandler(this.menu_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cmdBack.BackgroundImage = global::FORM.Properties.Resources.Back_Icon;
            this.cmdBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdBack.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.cmdBack.FlatAppearance.BorderSize = 0;
            this.cmdBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBack.Location = new System.Drawing.Point(1192, 5);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(108, 101);
            this.cmdBack.TabIndex = 52;
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // FORM_SMT_PRODUCTIVITY_WEEK_8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1916, 1054);
            this.Controls.Add(this.btnWeek);
            this.Controls.Add(this.btnMonth);
            this.Controls.Add(this.btnYear);
            this.Controls.Add(this.btnDay);
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.pn_body);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTitle);
            this.Name = "FORM_SMT_PRODUCTIVITY_WEEK_8";
            this.Text = "PR";
            this.Load += new System.EventHandler(this.FORM_IPEX3_LOGISTIC_Load);
            this.VisibleChanged += new System.EventHandler(this.FORM_IPEX3_LOGISTIC_VisibleChanged);
            this.pn_body.ResumeLayout(false);
            this.gaugeControl2.ResumeLayout(false);
            this.gaugeControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleTrucks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGaugesValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pn_body;
        private AxFPUSpreadADO.AxfpSpread axGrid;
        private System.Windows.Forms.Button cmdBack;
        private DevExpress.XtraEditors.SimpleButton btnMonth;
        private DevExpress.XtraEditors.SimpleButton btnYear;
        private DevExpress.XtraEditors.SimpleButton btnDay;
        private DevExpress.XtraCharts.ChartControl Chart4;
        private DevExpress.XtraCharts.ChartControl Chart5;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl2;
        private DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge cGauge1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent arcScaleBackgroundLayerComponent3;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcScaleTrucks;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent arcScaleNeedleComponent3;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent arcScaleSpindleCapComponent2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGauges.Win.Base.LabelComponent lblGaugesValue;
        private DevExpress.XtraEditors.SimpleButton btnWeek;
       // private ClassLib.TransparentPanel panel2;
       
    }
}