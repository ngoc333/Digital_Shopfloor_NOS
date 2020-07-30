namespace FORM.Popup
{
    partial class FRM_SMT_EXTERNAL_POPUP_1
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
            this.grdBase = new DevExpress.XtraGrid.GridControl();
            this.bgGrdView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.OSD_DATE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.TIME = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COMP = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.MODEL_NAME = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.STYLE_CODE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.REASON = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.CS_SIZE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.LR = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.C_QTY = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.R_QTY = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgGrdView)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBase
            // 
            this.grdBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBase.Location = new System.Drawing.Point(0, 0);
            this.grdBase.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdBase.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdBase.MainView = this.bgGrdView;
            this.grdBase.Name = "grdBase";
            this.grdBase.Size = new System.Drawing.Size(1393, 661);
            this.grdBase.TabIndex = 0;
            this.grdBase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgGrdView});
            // 
            // bgGrdView
            // 
            this.bgGrdView.Appearance.Row.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bgGrdView.Appearance.Row.Options.UseFont = true;
            this.bgGrdView.BandPanelRowHeight = 60;
            this.bgGrdView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand10,
            this.gridBand5,
            this.gridBand6,
            this.gridBand7,
            this.gridBand8,
            this.gridBand9,
            this.gridBand11,
            this.gridBand12});
            this.bgGrdView.ColumnPanelRowHeight = 30;
            this.bgGrdView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.OSD_DATE,
            this.TIME,
            this.COMP,
            this.MODEL_NAME,
            this.STYLE_CODE,
            this.REASON,
            this.CS_SIZE,
            this.LR,
            this.C_QTY,
            this.R_QTY});
            this.bgGrdView.GridControl = this.grdBase;
            this.bgGrdView.Name = "bgGrdView";
            this.bgGrdView.OptionsBehavior.Editable = false;
            this.bgGrdView.OptionsBehavior.ReadOnly = true;
            this.bgGrdView.OptionsView.AllowCellMerge = true;
            this.bgGrdView.OptionsView.ShowColumnHeaders = false;
            this.bgGrdView.OptionsView.ShowGroupPanel = false;
            this.bgGrdView.OptionsView.ShowIndicator = false;
            this.bgGrdView.PaintStyleName = "Flat";
            this.bgGrdView.RowHeight = 40;
            this.bgGrdView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.bgGrdView_RowCellStyle);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.gridBand1.AppearanceHeader.BackColor2 = System.Drawing.Color.RoyalBlue;
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand1.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand1.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand1.Caption = "DATE";
            this.gridBand1.Columns.Add(this.OSD_DATE);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 110;
            // 
            // OSD_DATE
            // 
            this.OSD_DATE.Caption = "OSD_DATE";
            this.OSD_DATE.FieldName = "OSD_DATE";
            this.OSD_DATE.Name = "OSD_DATE";
            this.OSD_DATE.Visible = true;
            this.OSD_DATE.Width = 110;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.gridBand2.AppearanceHeader.BackColor2 = System.Drawing.Color.RoyalBlue;
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand2.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand2.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand2.Caption = "TIME";
            this.gridBand2.Columns.Add(this.TIME);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 119;
            // 
            // TIME
            // 
            this.TIME.Caption = "TIME";
            this.TIME.FieldName = "TIMER";
            this.TIME.Name = "TIME";
            this.TIME.Visible = true;
            this.TIME.Width = 119;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.gridBand3.AppearanceHeader.BackColor2 = System.Drawing.Color.RoyalBlue;
            this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand3.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand3.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand3.AppearanceHeader.Options.UseFont = true;
            this.gridBand3.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand3.Caption = "COMPONENT";
            this.gridBand3.Columns.Add(this.COMP);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 145;
            // 
            // COMP
            // 
            this.COMP.Caption = "COMP";
            this.COMP.FieldName = "COMP";
            this.COMP.Name = "COMP";
            this.COMP.Visible = true;
            this.COMP.Width = 145;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.gridBand4.AppearanceHeader.BackColor2 = System.Drawing.Color.RoyalBlue;
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand4.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand4.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand4.Caption = "STYLE NAME";
            this.gridBand4.Columns.Add(this.MODEL_NAME);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 3;
            this.gridBand4.Width = 227;
            // 
            // MODEL_NAME
            // 
            this.MODEL_NAME.Caption = "MODEL_NAME";
            this.MODEL_NAME.FieldName = "MODEL_NAME";
            this.MODEL_NAME.Name = "MODEL_NAME";
            this.MODEL_NAME.Visible = true;
            this.MODEL_NAME.Width = 227;
            // 
            // gridBand10
            // 
            this.gridBand10.Caption = "Process Name";
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.Visible = false;
            this.gridBand10.VisibleIndex = -1;
            this.gridBand10.Width = 96;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.gridBand5.AppearanceHeader.BackColor2 = System.Drawing.Color.RoyalBlue;
            this.gridBand5.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand5.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand5.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand5.AppearanceHeader.Options.UseFont = true;
            this.gridBand5.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand5.Caption = "STYLE CODE";
            this.gridBand5.Columns.Add(this.STYLE_CODE);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 4;
            this.gridBand5.Width = 196;
            // 
            // STYLE_CODE
            // 
            this.STYLE_CODE.Caption = "STYLE_CODE";
            this.STYLE_CODE.FieldName = "STYLE_CODE";
            this.STYLE_CODE.Name = "STYLE_CODE";
            this.STYLE_CODE.Visible = true;
            this.STYLE_CODE.Width = 196;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.gridBand6.AppearanceHeader.BackColor2 = System.Drawing.Color.RoyalBlue;
            this.gridBand6.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand6.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand6.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand6.AppearanceHeader.Options.UseFont = true;
            this.gridBand6.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand6.Caption = "REASON";
            this.gridBand6.Columns.Add(this.REASON);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 5;
            this.gridBand6.Width = 196;
            // 
            // REASON
            // 
            this.REASON.Caption = "REASON";
            this.REASON.FieldName = "REASON";
            this.REASON.Name = "REASON";
            this.REASON.Visible = true;
            this.REASON.Width = 196;
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand7.AppearanceHeader.Options.UseFont = true;
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand7.Caption = "Division";
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.Visible = false;
            this.gridBand7.VisibleIndex = -1;
            this.gridBand7.Width = 101;
            // 
            // gridBand8
            // 
            this.gridBand8.AppearanceHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.gridBand8.AppearanceHeader.BackColor2 = System.Drawing.Color.RoyalBlue;
            this.gridBand8.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand8.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand8.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand8.AppearanceHeader.Options.UseFont = true;
            this.gridBand8.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand8.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand8.Caption = "SIZE";
            this.gridBand8.Columns.Add(this.CS_SIZE);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.VisibleIndex = 6;
            this.gridBand8.Width = 110;
            // 
            // CS_SIZE
            // 
            this.CS_SIZE.Caption = "CS_SIZE";
            this.CS_SIZE.FieldName = "CS_SIZE";
            this.CS_SIZE.Name = "CS_SIZE";
            this.CS_SIZE.Visible = true;
            this.CS_SIZE.Width = 110;
            // 
            // gridBand9
            // 
            this.gridBand9.AppearanceHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.gridBand9.AppearanceHeader.BackColor2 = System.Drawing.Color.RoyalBlue;
            this.gridBand9.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand9.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand9.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand9.AppearanceHeader.Options.UseFont = true;
            this.gridBand9.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand9.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand9.Caption = "DIV";
            this.gridBand9.Columns.Add(this.LR);
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.VisibleIndex = 7;
            this.gridBand9.Width = 67;
            // 
            // LR
            // 
            this.LR.Caption = "LR";
            this.LR.FieldName = "LR";
            this.LR.Name = "LR";
            this.LR.Visible = true;
            this.LR.Width = 67;
            // 
            // gridBand11
            // 
            this.gridBand11.AppearanceHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.gridBand11.AppearanceHeader.BackColor2 = System.Drawing.Color.RoyalBlue;
            this.gridBand11.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand11.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand11.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand11.AppearanceHeader.Options.UseFont = true;
            this.gridBand11.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand11.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand11.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridBand11.Caption = "OS&D QTY (Pcs)";
            this.gridBand11.Columns.Add(this.C_QTY);
            this.gridBand11.Name = "gridBand11";
            this.gridBand11.VisibleIndex = 8;
            this.gridBand11.Width = 107;
            // 
            // C_QTY
            // 
            this.C_QTY.Caption = "C_QTY";
            this.C_QTY.FieldName = "C_QTY";
            this.C_QTY.Name = "C_QTY";
            this.C_QTY.Visible = true;
            this.C_QTY.Width = 107;
            // 
            // gridBand12
            // 
            this.gridBand12.AppearanceHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.gridBand12.AppearanceHeader.BackColor2 = System.Drawing.Color.RoyalBlue;
            this.gridBand12.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand12.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand12.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand12.AppearanceHeader.Options.UseFont = true;
            this.gridBand12.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand12.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand12.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridBand12.Caption = "RE QTY (Pcs)";
            this.gridBand12.Columns.Add(this.R_QTY);
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.VisibleIndex = 9;
            this.gridBand12.Width = 112;
            // 
            // R_QTY
            // 
            this.R_QTY.Caption = "R_QTY";
            this.R_QTY.FieldName = "RE_QTY";
            this.R_QTY.Name = "R_QTY";
            this.R_QTY.Visible = true;
            this.R_QTY.Width = 112;
            // 
            // FRM_SMT_EXTERNAL_POPUP_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 661);
            this.Controls.Add(this.grdBase);
            this.Name = "FRM_SMT_EXTERNAL_POPUP_1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRM_SMT_INTERNAL_POPUP_1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgGrdView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdBase;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bgGrdView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn OSD_DATE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TIME;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COMP;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn MODEL_NAME;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn CS_SIZE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn REASON;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn STYLE_CODE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn LR;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn C_QTY;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn R_QTY;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand10;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand11;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand12;
    }
}