namespace FORM.UC
{
    partial class UC_CHART2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.SimpleDiagram3D simpleDiagram3D1 = new DevExpress.XtraCharts.SimpleDiagram3D();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Pie3DSeriesLabel pie3DSeriesLabel1 = new DevExpress.XtraCharts.Pie3DSeriesLabel();
            DevExpress.XtraCharts.Pie3DSeriesView pie3DSeriesView1 = new DevExpress.XtraCharts.Pie3DSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.Chart1 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram3D1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pie3DSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pie3DSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Chart1
            // 
            this.Chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(213)))), ((int)(((byte)(181)))));
            this.Chart1.BorderOptions.Thickness = 2;
            this.Chart1.DataBindings = null;
            simpleDiagram3D1.LabelsResolveOverlappingMinIndent = 20;
            simpleDiagram3D1.RotationMatrixSerializable = "-0.960014645438722;0.122455857552925;-0.25174678447629;0;-0.274674730333571;-0.58" +
    "5764386921153;0.762518114887168;0;-0.054089491209978;0.801177037842372;0.5959779" +
    "19871855;0;0;0;0;1";
            simpleDiagram3D1.ZoomPercent = 97;
            this.Chart1.Diagram = simpleDiagram3D1;
            this.Chart1.Legend.Name = "Default Legend";
            this.Chart1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.Chart1.Location = new System.Drawing.Point(4, 4);
            this.Chart1.Name = "Chart1";
            pie3DSeriesLabel1.Font = new System.Drawing.Font("Tahoma", 10F);
            pie3DSeriesLabel1.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns;
            pie3DSeriesLabel1.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
            pie3DSeriesLabel1.TextPattern = "{A}\n{VP:0.00%}";
            series1.Label = pie3DSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Series 1";
            series1.View = pie3DSeriesView1;
            this.Chart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.Chart1.Size = new System.Drawing.Size(378, 347);
            this.Chart1.TabIndex = 1;
            chartTitle1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle1.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.Chart1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // UC_CHART2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Chart1);
            this.Name = "UC_CHART2";
            this.Size = new System.Drawing.Size(386, 355);
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram3D1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pie3DSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pie3DSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl Chart1;
    }
}
