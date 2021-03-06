namespace FORM
{
    partial class FRM_SMT_FEMS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_SMT_FEMS));
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY3 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY4 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel3 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView3 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series6 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel4 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView4 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series7 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel3 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series8 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel4 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView4 = new DevExpress.XtraCharts.LineSeriesView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDay = new DevExpress.XtraEditors.SimpleButton();
            this.btnMonth = new DevExpress.XtraEditors.SimpleButton();
            this.btnWeek = new DevExpress.XtraEditors.SimpleButton();
            this.btnYear = new DevExpress.XtraEditors.SimpleButton();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lbltitle = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.axfpSpread = new AxFPSpreadADO.AxfpSpread();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.UC_MONTH = new FORM.UC.UC_MONTH_SELECTION();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.btnDay);
            this.panel1.Controls.Add(this.btnMonth);
            this.panel1.Controls.Add(this.btnWeek);
            this.panel1.Controls.Add(this.btnYear);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lbltitle);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(1920, 109);
            this.panel1.MinimumSize = new System.Drawing.Size(1920, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 109);
            this.panel1.TabIndex = 4;
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
            this.btnDay.Location = new System.Drawing.Point(1266, 4);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(175, 48);
            this.btnDay.TabIndex = 67;
            this.btnDay.Text = "Day";
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
            this.btnMonth.Location = new System.Drawing.Point(1449, 4);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(175, 48);
            this.btnMonth.TabIndex = 66;
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
            this.btnWeek.Location = new System.Drawing.Point(1266, 55);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(175, 48);
            this.btnWeek.TabIndex = 65;
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
            this.btnYear.Enabled = false;
            this.btnYear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYear.ImageOptions.Image")));
            this.btnYear.Location = new System.Drawing.Point(1449, 55);
            this.btnYear.Name = "btnYear";
            this.btnYear.Size = new System.Drawing.Size(175, 48);
            this.btnYear.TabIndex = 64;
            this.btnYear.Text = "Year";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::FORM.Properties.Resources.Back_Icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1152, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 101);
            this.button1.TabIndex = 51;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.lblDate.TabIndex = 48;
            this.lblDate.Text = "lblDate";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbltitle
            // 
            this.lbltitle.BackColor = System.Drawing.Color.DarkTurquoise;
            this.lbltitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbltitle.Font = new System.Drawing.Font("Calibri", 62F, System.Drawing.FontStyle.Bold);
            this.lbltitle.ForeColor = System.Drawing.Color.White;
            this.lbltitle.Location = new System.Drawing.Point(0, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(1920, 109);
            this.lbltitle.TabIndex = 0;
            this.lbltitle.Text = "Electric Analysis by Month";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // axfpSpread
            // 
            this.axfpSpread.DataSource = null;
            this.axfpSpread.Location = new System.Drawing.Point(0, 163);
            this.axfpSpread.Name = "axfpSpread";
            this.axfpSpread.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpSpread.OcxState")));
            this.axfpSpread.Size = new System.Drawing.Size(1920, 971);
            this.axfpSpread.TabIndex = 5;
            // 
            // chartControl1
            // 
            this.chartControl1.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartControl1.DataBindings = null;
            xyDiagram2.AxisX.Label.Font = new System.Drawing.Font("Tahoma", 11F);
            xyDiagram2.AxisX.Title.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram2.AxisX.Title.Text = "Date";
            xyDiagram2.AxisX.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            xyDiagram2.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.Label.Font = new System.Drawing.Font("Tahoma", 11F);
            xyDiagram2.AxisY.Label.TextPattern = "{V:#,#}";
            xyDiagram2.AxisY.Title.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram2.AxisY.Title.Text = "kWh";
            xyDiagram2.AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            xyDiagram2.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            secondaryAxisY3.AxisID = 0;
            secondaryAxisY3.Label.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            secondaryAxisY3.Name = "Secondary AxisY 1";
            secondaryAxisY3.Title.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            secondaryAxisY3.Title.Text = "kWh/Pairs";
            secondaryAxisY3.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            secondaryAxisY3.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY3.VisibleInPanesSerializable = "-1";
            secondaryAxisY4.AxisID = 1;
            secondaryAxisY4.Label.Font = new System.Drawing.Font("Tahoma", 11.25F);
            secondaryAxisY4.Name = "Secondary AxisY 2";
            secondaryAxisY4.Title.Font = new System.Drawing.Font("Tahoma", 15.75F);
            secondaryAxisY4.Title.Text = "Cost (USD)";
            secondaryAxisY4.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            secondaryAxisY4.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            secondaryAxisY4.VisibleInPanesSerializable = "-1";
            xyDiagram2.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SecondaryAxisY[] {
            secondaryAxisY3,
            secondaryAxisY4});
            this.chartControl1.Diagram = xyDiagram2;
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl1.Legend.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(0, 426);
            this.chartControl1.Name = "chartControl1";
            sideBySideBarSeriesLabel3.Font = new System.Drawing.Font("Tahoma", 10F);
            sideBySideBarSeriesLabel3.TextOrientation = DevExpress.XtraCharts.TextOrientation.BottomToTop;
            sideBySideBarSeriesLabel3.TextPattern = "{V:#,#}";
            series5.Label = sideBySideBarSeriesLabel3;
            series5.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series5.Name = "Active Power";
            sideBySideBarSeriesView3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(133)))), ((int)(((byte)(155)))));
            series5.View = sideBySideBarSeriesView3;
            sideBySideBarSeriesLabel4.Font = new System.Drawing.Font("Tahoma", 10F);
            sideBySideBarSeriesLabel4.TextOrientation = DevExpress.XtraCharts.TextOrientation.BottomToTop;
            sideBySideBarSeriesLabel4.TextPattern = "{V:#,#}";
            series6.Label = sideBySideBarSeriesLabel4;
            series6.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series6.Name = "Reactive Power";
            sideBySideBarSeriesView4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(187)))), ((int)(((byte)(89)))));
            series6.View = sideBySideBarSeriesView4;
            pointSeriesLabel3.Font = new System.Drawing.Font("Tahoma", 10F);
            series7.Label = pointSeriesLabel3;
            series7.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series7.Name = "KW/Pairs";
            lineSeriesView3.AxisYName = "Secondary AxisY 1";
            lineSeriesView3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(108)))), ((int)(((byte)(9)))));
            lineSeriesView3.LineMarkerOptions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            lineSeriesView3.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(172)))), ((int)(((byte)(198)))));
            lineSeriesView3.LineStyle.Thickness = 3;
            lineSeriesView3.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series7.View = lineSeriesView3;
            pointSeriesLabel4.Font = new System.Drawing.Font("Tahoma", 10F);
            series8.Label = pointSeriesLabel4;
            series8.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series8.Name = "Cost";
            lineSeriesView4.AxisYName = "Secondary AxisY 2";
            lineSeriesView4.Color = System.Drawing.Color.Black;
            lineSeriesView4.LineStyle.Thickness = 3;
            lineSeriesView4.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series8.View = lineSeriesView4;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series5,
        series6,
        series7,
        series8};
            this.chartControl1.Size = new System.Drawing.Size(1920, 654);
            this.chartControl1.TabIndex = 6;
            this.chartControl1.CustomDrawAxisLabel += new DevExpress.XtraCharts.CustomDrawAxisLabelEventHandler(this.chartControl1_CustomDrawAxisLabel);
            // 
            // UC_MONTH
            // 
            this.UC_MONTH.AutoSize = true;
            this.UC_MONTH.Location = new System.Drawing.Point(2, 112);
            this.UC_MONTH.Name = "UC_MONTH";
            this.UC_MONTH.Size = new System.Drawing.Size(472, 46);
            this.UC_MONTH.TabIndex = 7;
            this.UC_MONTH.ValueChangeEvent += new System.EventHandler(this.UC_MONTH_ValueChangeEvent);
            // 
            // FRM_SMT_FEMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.UC_MONTH);
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.axfpSpread);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_SMT_FEMS";
            this.Text = "FRM_SMT_FEMS";
            this.Load += new System.EventHandler(this.FRM_SMT_FEMS_Load);
            this.VisibleChanged += new System.EventHandler(this.FRM_SMT_FEMS_VisibleChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
        private AxFPSpreadADO.AxfpSpread axfpSpread;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraEditors.SimpleButton btnDay;
        private DevExpress.XtraEditors.SimpleButton btnMonth;
        private DevExpress.XtraEditors.SimpleButton btnWeek;
        private DevExpress.XtraEditors.SimpleButton btnYear;
        private UC.UC_MONTH_SELECTION UC_MONTH;
    }
}