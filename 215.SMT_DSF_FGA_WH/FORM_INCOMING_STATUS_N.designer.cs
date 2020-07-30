namespace FORM
{
    partial class FORM_INCOMING_STATUS_N
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_INCOMING_STATUS_N));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pn_body = new System.Windows.Forms.Panel();
            this.dtpDate = new DevExpress.XtraEditors.DateEdit();
            this.lbl_DateText = new System.Windows.Forms.Label();
            this.cmd_back = new System.Windows.Forms.Button();
            this.axSpear = new AxFPUSpreadADO.AxfpSpread();
            this.pn_body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSpear)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(213)))), ((int)(((byte)(244)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1914, 83);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Hourly Incoming By Mini Line";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(213)))), ((int)(((byte)(244)))));
            this.lblDate.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblDate.Location = new System.Drawing.Point(1662, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(253, 83);
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
            this.pn_body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pn_body.BackColor = System.Drawing.Color.Transparent;
            this.pn_body.Controls.Add(this.axSpear);
            this.pn_body.Location = new System.Drawing.Point(0, 106);
            this.pn_body.Name = "pn_body";
            this.pn_body.Size = new System.Drawing.Size(1914, 874);
            this.pn_body.TabIndex = 48;
            // 
            // dtpDate
            // 
            this.dtpDate.EditValue = "";
            this.dtpDate.Location = new System.Drawing.Point(79, 91);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 18.25F, System.Drawing.FontStyle.Bold);
            this.dtpDate.Properties.Appearance.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate.Size = new System.Drawing.Size(203, 36);
            this.dtpDate.TabIndex = 50;
            this.dtpDate.Visible = false;
            this.dtpDate.EditValueChanged += new System.EventHandler(this.dtpDate_EditValueChanged);
            // 
            // lbl_DateText
            // 
            this.lbl_DateText.AutoSize = true;
            this.lbl_DateText.Font = new System.Drawing.Font("Calibri", 18.25F, System.Drawing.FontStyle.Bold);
            this.lbl_DateText.Location = new System.Drawing.Point(12, 94);
            this.lbl_DateText.Name = "lbl_DateText";
            this.lbl_DateText.Size = new System.Drawing.Size(64, 31);
            this.lbl_DateText.TabIndex = 51;
            this.lbl_DateText.Text = "Date";
            this.lbl_DateText.Visible = false;
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
            // axSpear
            // 
            this.axSpear.DataSource = null;
            this.axSpear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axSpear.Location = new System.Drawing.Point(0, 0);
            this.axSpear.Name = "axSpear";
            this.axSpear.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSpear.OcxState")));
            this.axSpear.Size = new System.Drawing.Size(1914, 874);
            this.axSpear.TabIndex = 20;
            this.axSpear.BeforeEditMode += new AxFPUSpreadADO._DSpreadEvents_BeforeEditModeEventHandler(this.axSpear_BeforeEditMode);
            // 
            // FORM_INCOMING_STATUS_N
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1914, 1000);
            this.Controls.Add(this.cmd_back);
            this.Controls.Add(this.lbl_DateText);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.pn_body);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTitle);
            this.Name = "FORM_INCOMING_STATUS_N";
            this.Text = "Incoming Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FORM_SMF_SHIP_SCHEDULE_FormClosing);
            this.Load += new System.EventHandler(this.FORM_IPEX3_LOGISTIC_Load);
            this.VisibleChanged += new System.EventHandler(this.FORM_IPEX3_LOGISTIC_VisibleChanged);
            this.pn_body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSpear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pn_body;
        private AxFPUSpreadADO.AxfpSpread axSpear;
        private DevExpress.XtraEditors.DateEdit dtpDate;
        private System.Windows.Forms.Label lbl_DateText;
        private System.Windows.Forms.Button cmd_back;
       
    }
}