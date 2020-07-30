namespace FORM
{
    partial class FORM_SMT_BTS_YEAR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_SMT_BTS_YEAR));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Legend legend1 = new DevExpress.XtraCharts.Legend();
            DevExpress.XtraCharts.CustomLegendItem customLegendItem1 = new DevExpress.XtraCharts.CustomLegendItem();
            DevExpress.XtraCharts.CustomLegendItem customLegendItem2 = new DevExpress.XtraCharts.CustomLegendItem();
            DevExpress.XtraCharts.CustomLegendItem customLegendItem3 = new DevExpress.XtraCharts.CustomLegendItem();
            DevExpress.XtraCharts.CustomLegendItem customLegendItem4 = new DevExpress.XtraCharts.CustomLegendItem();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnWeek = new DevExpress.XtraEditors.SimpleButton();
            this.btnDay = new DevExpress.XtraEditors.SimpleButton();
            this.btnYear = new DevExpress.XtraEditors.SimpleButton();
            this.btnMonth = new DevExpress.XtraEditors.SimpleButton();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.axfpSpread = new AxFPSpreadADO.AxfpSpread();
            this.chartBTS = new DevExpress.XtraCharts.ChartControl();
            this.timer1 = new System.Windows.Forms.Timer();
            this.timer2 = new System.Windows.Forms.Timer();
            this.UC_YEAR = new FORM.UC.UC_YEAR_SELECTION();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.btnWeek);
            this.panel1.Controls.Add(this.btnDay);
            this.panel1.Controls.Add(this.btnYear);
            this.panel1.Controls.Add(this.btnMonth);
            this.panel1.Controls.Add(this.cmdBack);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(1920, 109);
            this.panel1.MinimumSize = new System.Drawing.Size(1920, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 109);
            this.panel1.TabIndex = 4;
            // 
            // btnWeek
            // 
            this.btnWeek.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWeek.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWeek.Appearance.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeek.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnWeek.Appearance.Options.UseBackColor = true;
            this.btnWeek.Appearance.Options.UseFont = true;
            this.btnWeek.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnWeek.Enabled = false;
            this.btnWeek.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnWeek.ImageOptions.Image")));
            this.btnWeek.Location = new System.Drawing.Point(1277, 58);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(175, 48);
            this.btnWeek.TabIndex = 60;
            this.btnWeek.Text = "Week";
            // 
            // btnDay
            // 
            this.btnDay.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDay.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDay.Appearance.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDay.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnDay.Appearance.Options.UseBackColor = true;
            this.btnDay.Appearance.Options.UseFont = true;
            this.btnDay.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnDay.Enabled = false;
            this.btnDay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDay.ImageOptions.Image")));
            this.btnDay.Location = new System.Drawing.Point(1277, 4);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(175, 48);
            this.btnDay.TabIndex = 59;
            this.btnDay.Text = "Day";
            // 
            // btnYear
            // 
            this.btnYear.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnYear.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnYear.Appearance.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYear.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnYear.Appearance.Options.UseBackColor = true;
            this.btnYear.Appearance.Options.UseFont = true;
            this.btnYear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnYear.Enabled = false;
            this.btnYear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYear.ImageOptions.Image")));
            this.btnYear.Location = new System.Drawing.Point(1458, 58);
            this.btnYear.Name = "btnYear";
            this.btnYear.Size = new System.Drawing.Size(175, 48);
            this.btnYear.TabIndex = 56;
            this.btnYear.Text = "Year";
            // 
            // btnMonth
            // 
            this.btnMonth.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMonth.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMonth.Appearance.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonth.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnMonth.Appearance.Options.UseBackColor = true;
            this.btnMonth.Appearance.Options.UseFont = true;
            this.btnMonth.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnMonth.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMonth.ImageOptions.Image")));
            this.btnMonth.Location = new System.Drawing.Point(1458, 3);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(175, 48);
            this.btnMonth.TabIndex = 55;
            this.btnMonth.Tag = "87";
            this.btnMonth.Text = "Month";
            this.btnMonth.Click += new System.EventHandler(this.menu_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.BackColor = System.Drawing.Color.Transparent;
            this.cmdBack.BackgroundImage = global::FORM.Properties.Resources.Back_Icon;
            this.cmdBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdBack.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.cmdBack.FlatAppearance.BorderSize = 0;
            this.cmdBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBack.Location = new System.Drawing.Point(1163, 3);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(108, 101);
            this.cmdBack.TabIndex = 51;
            this.cmdBack.Tag = "69";
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.DarkTurquoise;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblDate.Location = new System.Drawing.Point(1639, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(281, 109);
            this.lblDate.TabIndex = 49;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.DarkTurquoise;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 62.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1920, 109);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Tag = "Minimized";
            this.lblTitle.Text = "BTS Tracking by Year";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.DoubleClick += new System.EventHandler(this.menu_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Enabled = false;
            this.splitContainer1.Location = new System.Drawing.Point(0, 160);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.axfpSpread);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chartBTS);
            this.splitContainer1.Size = new System.Drawing.Size(1920, 908);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 5;
            // 
            // axfpSpread
            // 
            this.axfpSpread.DataSource = null;
            this.axfpSpread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axfpSpread.Location = new System.Drawing.Point(0, 0);
            this.axfpSpread.Name = "axfpSpread";
            this.axfpSpread.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpSpread.OcxState")));
            this.axfpSpread.Size = new System.Drawing.Size(1920, 220);
            this.axfpSpread.TabIndex = 0;
            // 
            // chartBTS
            // 
            this.chartBTS.AppearanceNameSerializable = "Chameleon";
            this.chartBTS.DataBindings = null;
            xyDiagram1.AxisX.Label.Font = new System.Drawing.Font("Tahoma", 14F);
            xyDiagram1.AxisX.Title.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            xyDiagram1.AxisX.Title.Text = "Month";
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Label.Font = new System.Drawing.Font("Tahoma", 14F);
            xyDiagram1.AxisY.Title.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram1.AxisY.Title.Text = "(%)";
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartBTS.Diagram = xyDiagram1;
            this.chartBTS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartBTS.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left;
            this.chartBTS.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.chartBTS.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartBTS.Legend.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartBTS.Legend.Name = "Default Legend";
            legend1.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
            legend1.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            customLegendItem1.MarkerColor = System.Drawing.Color.LimeGreen;
            customLegendItem1.Name = "BTS >=72%";
            customLegendItem2.MarkerColor = System.Drawing.Color.Yellow;
            customLegendItem2.Name = "70% <=BTS <72%";
            customLegendItem3.MarkerColor = System.Drawing.Color.Red;
            customLegendItem3.Name = "68% <=BTS <70%";
            customLegendItem4.MarkerColor = System.Drawing.Color.Black;
            customLegendItem4.Name = " BTS < 68%";
            legend1.CustomItems.AddRange(new DevExpress.XtraCharts.CustomLegendItem[] {
            customLegendItem1,
            customLegendItem2,
            customLegendItem3,
            customLegendItem4});
            legend1.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            legend1.Font = new System.Drawing.Font("Tahoma", 12F);
            legend1.Name = "Legend1";
            this.chartBTS.Legends.AddRange(new DevExpress.XtraCharts.Legend[] {
            legend1});
            this.chartBTS.Location = new System.Drawing.Point(0, 0);
            this.chartBTS.Name = "chartBTS";
            this.chartBTS.PaletteName = "Chameleon";
            sideBySideBarSeriesLabel1.TextPattern = "{V:%}";
            series1.Label = sideBySideBarSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "BTS";
            sideBySideBarSeriesView1.Color = System.Drawing.Color.DodgerBlue;
            sideBySideBarSeriesView1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
            series1.View = sideBySideBarSeriesView1;
            series2.Name = "Target";
            lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.View = lineSeriesView1;
            this.chartBTS.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chartBTS.Size = new System.Drawing.Size(1920, 684);
            this.chartBTS.TabIndex = 0;
            this.chartBTS.CustomDrawAxisLabel += new DevExpress.XtraCharts.CustomDrawAxisLabelEventHandler(this.chartBTS_CustomDrawAxisLabel);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // UC_YEAR
            // 
            this.UC_YEAR.AutoSize = true;
            this.UC_YEAR.Location = new System.Drawing.Point(3, 113);
            this.UC_YEAR.Name = "UC_YEAR";
            this.UC_YEAR.Size = new System.Drawing.Size(229, 47);
            this.UC_YEAR.TabIndex = 6;
            this.UC_YEAR.ValueChangeEvent += new System.EventHandler(this.UC_YEAR_ValueChangeEvent);
            // 
            // FORM_SMT_BTS_YEAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.UC_YEAR);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FORM_SMT_BTS_YEAR";
            this.Text = "FRM_SMT_BTS";
            this.Load += new System.EventHandler(this.FRM_SMT_BTS_YEAR_Load);
            this.VisibleChanged += new System.EventHandler(this.FRM_SMT_BTS_YEAR_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBTS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraCharts.ChartControl chartBTS;
        private AxFPSpreadADO.AxfpSpread axfpSpread;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button cmdBack;
        private DevExpress.XtraEditors.SimpleButton btnYear;
        private DevExpress.XtraEditors.SimpleButton btnMonth;
        private DevExpress.XtraEditors.SimpleButton btnWeek;
        private DevExpress.XtraEditors.SimpleButton btnDay;
        private UC.UC_YEAR_SELECTION UC_YEAR;
    }
}