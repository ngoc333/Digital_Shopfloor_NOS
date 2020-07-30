namespace FORM
{
    partial class FRM_DVR_FC_TRACKING_DASHBOARD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_DVR_FC_TRACKING_DASHBOARD));
            this.pnHeader = new System.Windows.Forms.Panel();
            this.cmd_back = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.tmr_Reload = new System.Windows.Forms.Timer(this.components);
            this.bgw_Loading = new System.ComponentModel.BackgroundWorker();
            this.pnBody = new System.Windows.Forms.Panel();
            this.cmd_chk1 = new System.Windows.Forms.Button();
            this.cmd_chk2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate2 = new DevExpress.XtraEditors.DateEdit();
            this.lbl_DateText = new System.Windows.Forms.Label();
            this.dtpDate1 = new DevExpress.XtraEditors.DateEdit();
            this.tmr_Blinking = new System.Windows.Forms.Timer(this.components);
            this.axfpView = new AxFPUSpreadADO.AxfpSpread();
            this.pnHeader.SuspendLayout();
            this.pnBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(213)))), ((int)(((byte)(244)))));
            this.pnHeader.Controls.Add(this.cmd_back);
            this.pnHeader.Controls.Add(this.lblDate);
            this.pnHeader.Controls.Add(this.lblTitle);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1904, 83);
            this.pnHeader.TabIndex = 0;
            // 
            // cmd_back
            // 
            this.cmd_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(213)))), ((int)(((byte)(244)))));
            this.cmd_back.BackgroundImage = global::FORM.Properties.Resources.Back_Icon;
            this.cmd_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmd_back.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.cmd_back.FlatAppearance.BorderSize = 0;
            this.cmd_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_back.Location = new System.Drawing.Point(1122, 0);
            this.cmd_back.Name = "cmd_back";
            this.cmd_back.Size = new System.Drawing.Size(102, 83);
            this.cmd_back.TabIndex = 666;
            this.cmd_back.UseVisualStyleBackColor = false;
            this.cmd_back.Click += new System.EventHandler(this.cmd_back_Click);
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(213)))), ((int)(((byte)(244)))));
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblDate.Location = new System.Drawing.Point(1651, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(253, 83);
            this.lblDate.TabIndex = 48;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.DoubleClick += new System.EventHandler(this.lblDate_DoubleClick);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(213)))), ((int)(((byte)(244)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(897, 83);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Delivery Focus Tracking";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 16.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1731, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 27);
            this.label4.TabIndex = 50;
            this.label4.Tag = "Red";
            this.label4.Text = "Invetory < Order";
            this.label4.Click += new System.EventHandler(this.Click_Check_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(1672, 9);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(57, 31);
            this.button4.TabIndex = 49;
            this.button4.Tag = "Red";
            this.button4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Click_Check_Click);
            // 
            // tmr_Reload
            // 
            this.tmr_Reload.Enabled = true;
            this.tmr_Reload.Interval = 1000;
            this.tmr_Reload.Tick += new System.EventHandler(this.tmr_Reload_Tick);
            // 
            // bgw_Loading
            // 
            this.bgw_Loading.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_Loading_DoWork);
            // 
            // pnBody
            // 
            this.pnBody.Controls.Add(this.cmd_chk1);
            this.pnBody.Controls.Add(this.cmd_chk2);
            this.pnBody.Controls.Add(this.label2);
            this.pnBody.Controls.Add(this.label1);
            this.pnBody.Controls.Add(this.label4);
            this.pnBody.Controls.Add(this.button4);
            this.pnBody.Controls.Add(this.dtpDate2);
            this.pnBody.Controls.Add(this.lbl_DateText);
            this.pnBody.Controls.Add(this.dtpDate1);
            this.pnBody.Controls.Add(this.axfpView);
            this.pnBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBody.Location = new System.Drawing.Point(0, 83);
            this.pnBody.Name = "pnBody";
            this.pnBody.Size = new System.Drawing.Size(1904, 959);
            this.pnBody.TabIndex = 1;
            // 
            // cmd_chk1
            // 
            this.cmd_chk1.BackColor = System.Drawing.Color.Transparent;
            this.cmd_chk1.FlatAppearance.BorderSize = 0;
            this.cmd_chk1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_chk1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.cmd_chk1.ForeColor = System.Drawing.Color.Black;
            this.cmd_chk1.Location = new System.Drawing.Point(1554, 8);
            this.cmd_chk1.Name = "cmd_chk1";
            this.cmd_chk1.Size = new System.Drawing.Size(26, 31);
            this.cmd_chk1.TabIndex = 59;
            this.cmd_chk1.Text = "✓";
            this.cmd_chk1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmd_chk1.UseVisualStyleBackColor = false;
            // 
            // cmd_chk2
            // 
            this.cmd_chk2.BackColor = System.Drawing.Color.Transparent;
            this.cmd_chk2.FlatAppearance.BorderSize = 0;
            this.cmd_chk2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_chk2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.cmd_chk2.ForeColor = System.Drawing.Color.Black;
            this.cmd_chk2.Location = new System.Drawing.Point(1643, 8);
            this.cmd_chk2.Name = "cmd_chk2";
            this.cmd_chk2.Size = new System.Drawing.Size(26, 31);
            this.cmd_chk2.TabIndex = 58;
            this.cmd_chk2.Text = "✓";
            this.cmd_chk2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmd_chk2.UseVisualStyleBackColor = false;
            this.cmd_chk2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 16.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1577, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 27);
            this.label2.TabIndex = 57;
            this.label2.Tag = "All";
            this.label2.Text = "All";
            this.label2.Click += new System.EventHandler(this.Click_Check_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 34F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(310, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 35);
            this.label1.TabIndex = 55;
            this.label1.Text = "~";
            // 
            // dtpDate2
            // 
            this.dtpDate2.EditValue = "";
            this.dtpDate2.Location = new System.Drawing.Point(359, 6);
            this.dtpDate2.Name = "dtpDate2";
            this.dtpDate2.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 18.25F, System.Drawing.FontStyle.Bold);
            this.dtpDate2.Properties.Appearance.Options.UseFont = true;
            this.dtpDate2.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.dtpDate2.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpDate2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpDate2.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.dtpDate2.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.dtpDate2.Properties.AppearanceDropDownHeaderHighlight.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.dtpDate2.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = true;
            this.dtpDate2.Properties.AppearanceDropDownHighlight.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.dtpDate2.Properties.AppearanceDropDownHighlight.Options.UseFont = true;
            this.dtpDate2.Properties.AppearanceFocused.Font = new System.Drawing.Font("Calibri", 18.25F, System.Drawing.FontStyle.Bold);
            this.dtpDate2.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpDate2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate2.Size = new System.Drawing.Size(203, 36);
            this.dtpDate2.TabIndex = 54;
            // 
            // lbl_DateText
            // 
            this.lbl_DateText.AutoSize = true;
            this.lbl_DateText.Font = new System.Drawing.Font("Calibri", 18.25F, System.Drawing.FontStyle.Bold);
            this.lbl_DateText.Location = new System.Drawing.Point(21, 9);
            this.lbl_DateText.Name = "lbl_DateText";
            this.lbl_DateText.Size = new System.Drawing.Size(79, 31);
            this.lbl_DateText.TabIndex = 53;
            this.lbl_DateText.Text = "C-GAC";
            // 
            // dtpDate1
            // 
            this.dtpDate1.EditValue = "";
            this.dtpDate1.Location = new System.Drawing.Point(106, 6);
            this.dtpDate1.Name = "dtpDate1";
            this.dtpDate1.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 18.25F, System.Drawing.FontStyle.Bold);
            this.dtpDate1.Properties.Appearance.Options.UseFont = true;
            this.dtpDate1.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.dtpDate1.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpDate1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpDate1.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.dtpDate1.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.dtpDate1.Properties.AppearanceDropDownHeaderHighlight.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.dtpDate1.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = true;
            this.dtpDate1.Properties.AppearanceDropDownHighlight.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.dtpDate1.Properties.AppearanceDropDownHighlight.Options.UseFont = true;
            this.dtpDate1.Properties.AppearanceFocused.Font = new System.Drawing.Font("Calibri", 18.25F, System.Drawing.FontStyle.Bold);
            this.dtpDate1.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate1.Size = new System.Drawing.Size(203, 36);
            this.dtpDate1.TabIndex = 52;
            // 
            // tmr_Blinking
            // 
            this.tmr_Blinking.Interval = 500;
            this.tmr_Blinking.Tick += new System.EventHandler(this.tmr_Blinking_Tick);
            // 
            // axfpView
            // 
            this.axfpView.DataSource = null;
            this.axfpView.Location = new System.Drawing.Point(0, 53);
            this.axfpView.Name = "axfpView";
            this.axfpView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpView.OcxState")));
            this.axfpView.Size = new System.Drawing.Size(1904, 854);
            this.axfpView.TabIndex = 0;
            this.axfpView.ClickEvent += new AxFPUSpreadADO._DSpreadEvents_ClickEventHandler(this.axfpView_ClickEvent);
            // 
            // FRM_DVR_FC_TRACKING_DASHBOARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1042);
            this.Controls.Add(this.pnBody);
            this.Controls.Add(this.pnHeader);
            this.Name = "FRM_DVR_FC_TRACKING_DASHBOARD";
            this.Text = "Delivery Focus Tracking";
            this.Load += new System.EventHandler(this.FRM_DVR_FC_TRACKING_DASHBOARD_Load);
            this.VisibleChanged += new System.EventHandler(this.FRM_DVR_FC_TRACKING_DASHBOARD_VisibleChanged);
            this.pnHeader.ResumeLayout(false);
            this.pnBody.ResumeLayout(false);
            this.pnBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer tmr_Reload;
        private System.ComponentModel.BackgroundWorker bgw_Loading;
        private System.Windows.Forms.Panel pnBody;
        private AxFPUSpreadADO.AxfpSpread axfpView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer tmr_Blinking;
        private System.Windows.Forms.Button cmd_back;
        private System.Windows.Forms.Label lbl_DateText;
        private DevExpress.XtraEditors.DateEdit dtpDate1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dtpDate2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmd_chk1;
        private System.Windows.Forms.Button cmd_chk2;
    }
}

