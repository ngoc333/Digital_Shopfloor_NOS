namespace FORM
{
    partial class FORM_SMT_DTD_MONTH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_SMT_DTD_MONTH));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btnDay = new DevExpress.XtraEditors.SimpleButton();
            this.btnMonth = new DevExpress.XtraEditors.SimpleButton();
            this.btnWeek = new DevExpress.XtraEditors.SimpleButton();
            this.btnYear = new DevExpress.XtraEditors.SimpleButton();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.tmrDate = new System.Windows.Forms.Timer();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.axfpDTD = new AxFPUSpreadADO.AxfpSpread();
            this.splitChart = new System.Windows.Forms.SplitContainer();
            this.chartWIP = new DevExpress.XtraCharts.ChartControl();
            this.chartLT = new DevExpress.XtraCharts.ChartControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picDocument = new System.Windows.Forms.PictureBox();
            this.UC_MONTH = new FORM.UC.UC_MONTH_SELECTION();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axfpDTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitChart)).BeginInit();
            this.splitChart.Panel1.SuspendLayout();
            this.splitChart.Panel2.SuspendLayout();
            this.splitChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartWIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDocument)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnHeader.Controls.Add(this.btnDay);
            this.pnHeader.Controls.Add(this.btnMonth);
            this.pnHeader.Controls.Add(this.btnWeek);
            this.pnHeader.Controls.Add(this.btnYear);
            this.pnHeader.Controls.Add(this.cmdBack);
            this.pnHeader.Controls.Add(this.lblDate);
            this.pnHeader.Controls.Add(this.lblTitle);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1904, 110);
            this.pnHeader.TabIndex = 13;
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
            this.btnDay.Location = new System.Drawing.Point(1296, 6);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(175, 48);
            this.btnDay.TabIndex = 63;
            this.btnDay.Text = "Day";
            this.btnDay.Click += new System.EventHandler(this.menu_Click);
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
            this.btnMonth.Enabled = false;
            this.btnMonth.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMonth.ImageOptions.Image")));
            this.btnMonth.Location = new System.Drawing.Point(1479, 6);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(175, 48);
            this.btnMonth.TabIndex = 62;
            this.btnMonth.Text = "Month";
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
            this.btnWeek.Location = new System.Drawing.Point(1296, 57);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(175, 48);
            this.btnWeek.TabIndex = 61;
            this.btnWeek.Text = "Week";
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
            this.btnYear.Location = new System.Drawing.Point(1479, 57);
            this.btnYear.Name = "btnYear";
            this.btnYear.Size = new System.Drawing.Size(175, 48);
            this.btnYear.TabIndex = 60;
            this.btnYear.Text = "Year";
            this.btnYear.Click += new System.EventHandler(this.menu_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.BackColor = System.Drawing.Color.Transparent;
            this.cmdBack.BackgroundImage = global::FORM.Properties.Resources.Back_Icon;
            this.cmdBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdBack.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.cmdBack.FlatAppearance.BorderSize = 0;
            this.cmdBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBack.Location = new System.Drawing.Point(1171, 6);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(108, 101);
            this.cmdBack.TabIndex = 50;
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblDate.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblDate.Location = new System.Drawing.Point(1660, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(253, 106);
            this.lblDate.TabIndex = 49;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Calibri", 62F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTitle.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblTitle.LineVisible = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1122, 107);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Dock To Dock (DTD) By Month";
            this.lblTitle.DoubleClick += new System.EventHandler(this.menu_Click);
            this.lblTitle.MouseEnter += new System.EventHandler(this.lblTitle_MouseEnter);
            this.lblTitle.MouseLeave += new System.EventHandler(this.lblTitle_MouseLeave);
            this.lblTitle.MouseHover += new System.EventHandler(this.lblTitle_MouseHover);
            // 
            // tmrDate
            // 
            this.tmrDate.Enabled = true;
            this.tmrDate.Interval = 1000;
            this.tmrDate.Tick += new System.EventHandler(this.tmrDate_Tick);
            // 
            // splitMain
            // 
            this.splitMain.Location = new System.Drawing.Point(0, 160);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.axfpDTD);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.splitChart);
            this.splitMain.Size = new System.Drawing.Size(1904, 890);
            this.splitMain.SplitterDistance = 359;
            this.splitMain.TabIndex = 14;
            // 
            // axfpDTD
            // 
            this.axfpDTD.DataSource = null;
            this.axfpDTD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axfpDTD.Location = new System.Drawing.Point(0, 0);
            this.axfpDTD.Name = "axfpDTD";
            this.axfpDTD.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpDTD.OcxState")));
            this.axfpDTD.Size = new System.Drawing.Size(1904, 359);
            this.axfpDTD.TabIndex = 0;
            // 
            // splitChart
            // 
            this.splitChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitChart.Location = new System.Drawing.Point(0, 0);
            this.splitChart.Name = "splitChart";
            // 
            // splitChart.Panel1
            // 
            this.splitChart.Panel1.Controls.Add(this.chartWIP);
            // 
            // splitChart.Panel2
            // 
            this.splitChart.Panel2.Controls.Add(this.chartLT);
            this.splitChart.Size = new System.Drawing.Size(1904, 527);
            this.splitChart.SplitterDistance = 934;
            this.splitChart.TabIndex = 0;
            // 
            // chartWIP
            // 
            this.chartWIP.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartWIP.DataBindings = null;
            xyDiagram1.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
            xyDiagram1.AxisX.Label.ResolveOverlappingOptions.MinIndent = 1;
            xyDiagram1.AxisX.MinorCount = 1;
            xyDiagram1.AxisX.Title.Text = "Date";
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Title.Text = "Days";
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartWIP.Diagram = xyDiagram1;
            this.chartWIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartWIP.Legend.Name = "Default Legend";
            this.chartWIP.Location = new System.Drawing.Point(0, 0);
            this.chartWIP.Name = "chartWIP";
            pointSeriesLabel1.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.JustifyAroundPoint;
            series1.Label = pointSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Days";
            lineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            lineSeriesView1.LineMarkerOptions.Kind = DevExpress.XtraCharts.MarkerKind.Star;
            lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.View = lineSeriesView1;
            this.chartWIP.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartWIP.Size = new System.Drawing.Size(934, 527);
            this.chartWIP.TabIndex = 0;
            chartTitle1.Text = "WIP";
            this.chartWIP.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            this.chartWIP.CustomDrawAxisLabel += new DevExpress.XtraCharts.CustomDrawAxisLabelEventHandler(this.CustomDrawAxisLabel);
            // 
            // chartLT
            // 
            this.chartLT.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartLT.DataBindings = null;
            xyDiagram2.AxisX.Title.Text = "True";
            xyDiagram2.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.Title.Text = "Days";
            xyDiagram2.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            this.chartLT.Diagram = xyDiagram2;
            this.chartLT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartLT.Legend.Name = "Default Legend";
            this.chartLT.Location = new System.Drawing.Point(0, 0);
            this.chartLT.Name = "chartLT";
            sideBySideBarSeriesLabel1.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
            sideBySideBarSeriesLabel1.TextOrientation = DevExpress.XtraCharts.TextOrientation.TopToBottom;
            series2.Label = sideBySideBarSeriesLabel1;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "LeadTime";
            this.chartLT.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.chartLT.Size = new System.Drawing.Size(966, 527);
            this.chartLT.TabIndex = 0;
            chartTitle2.Text = "DTD (Dock To Dock)";
            chartTitle2.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartLT.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle2});
            this.chartLT.CustomDrawAxisLabel += new DevExpress.XtraCharts.CustomDrawAxisLabelEventHandler(this.CustomDrawAxisLabel);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picDocument);
            this.panel1.Location = new System.Drawing.Point(541, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 592);
            this.panel1.TabIndex = 65;
            // 
            // picDocument
            // 
            this.picDocument.Location = new System.Drawing.Point(0, 2);
            this.picDocument.Name = "picDocument";
            this.picDocument.Size = new System.Drawing.Size(783, 588);
            this.picDocument.TabIndex = 1;
            this.picDocument.TabStop = false;
            // 
            // UC_MONTH
            // 
            this.UC_MONTH.AutoSize = true;
            this.UC_MONTH.Location = new System.Drawing.Point(3, 112);
            this.UC_MONTH.Name = "UC_MONTH";
            this.UC_MONTH.Size = new System.Drawing.Size(472, 46);
            this.UC_MONTH.TabIndex = 66;
            this.UC_MONTH.ValueChangeEvent += new System.EventHandler(this.UC_MONTH_ValueChangeEvent);
            // 
            // FORM_SMT_DTD_MONTH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1042);
            this.Controls.Add(this.UC_MONTH);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnHeader);
            this.Name = "FORM_SMT_DTD_MONTH";
            this.Text = "FRM_SMT_DTD_MONTH";
            this.Load += new System.EventHandler(this.FRM_SMT_DTD_MONTH_Load);
            this.VisibleChanged += new System.EventHandler(this.FRM_SMT_DTD_MONTH_VisibleChanged);
            this.pnHeader.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axfpDTD)).EndInit();
            this.splitChart.Panel1.ResumeLayout(false);
            this.splitChart.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitChart)).EndInit();
            this.splitChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartWIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLT)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDocument)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private DevExpress.XtraEditors.SimpleButton btnDay;
        private DevExpress.XtraEditors.SimpleButton btnMonth;
        private DevExpress.XtraEditors.SimpleButton btnWeek;
        private DevExpress.XtraEditors.SimpleButton btnYear;
        private System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private System.Windows.Forms.Timer tmrDate;
        private System.Windows.Forms.SplitContainer splitMain;
        private AxFPUSpreadADO.AxfpSpread axfpDTD;
        private System.Windows.Forms.SplitContainer splitChart;
        private DevExpress.XtraCharts.ChartControl chartWIP;
        private DevExpress.XtraCharts.ChartControl chartLT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picDocument;
        private UC.UC_MONTH_SELECTION UC_MONTH;
    }
}