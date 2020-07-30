namespace FORM
{
    partial class FORM_SMF_PROD_WH_LOCATION
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_SMF_PROD_WH_LOCATION));
            this.lblTitle = new System.Windows.Forms.Label();
            this.pn_search = new System.Windows.Forms.Panel();
            this.txt_obsnu = new System.Windows.Forms.TextBox();
            this.cbo_style = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbo_item = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_style = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_seq = new System.Windows.Forms.ComboBox();
            this.cbo_size = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pn_body = new System.Windows.Forms.Panel();
            this.pn_loc_wh = new System.Windows.Forms.Panel();
            this.axSpreadTail = new AxFPUSpreadADO.AxfpSpread();
            this.axSpreadHead = new AxFPUSpreadADO.AxfpSpread();
            this.axfpSpread2 = new AxFPUSpreadADO.AxfpSpread();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lbl_Remain = new System.Windows.Forms.Label();
            this.lbl_Actual = new System.Windows.Forms.Label();
            this.lbl_Capa = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.cmd_back = new System.Windows.Forms.Button();
            this.pn_search.SuspendLayout();
            this.pn_body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axSpreadTail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSpreadHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(213)))), ((int)(((byte)(244)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1916, 83);
            this.lblTitle.TabIndex = 645;
            this.lblTitle.Text = "F/G Warehouse Location";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pn_search
            // 
            this.pn_search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pn_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pn_search.Controls.Add(this.txt_obsnu);
            this.pn_search.Controls.Add(this.cbo_style);
            this.pn_search.Controls.Add(this.label7);
            this.pn_search.Controls.Add(this.cbo_item);
            this.pn_search.Controls.Add(this.label6);
            this.pn_search.Controls.Add(this.txt_style);
            this.pn_search.Controls.Add(this.label2);
            this.pn_search.Controls.Add(this.label1);
            this.pn_search.Controls.Add(this.cbo_seq);
            this.pn_search.Controls.Add(this.cbo_size);
            this.pn_search.Location = new System.Drawing.Point(0, 84);
            this.pn_search.Name = "pn_search";
            this.pn_search.Size = new System.Drawing.Size(1915, 30);
            this.pn_search.TabIndex = 646;
            this.pn_search.Visible = false;
            this.pn_search.Click += new System.EventHandler(this.pn_search_Click);
            // 
            // txt_obsnu
            // 
            this.txt_obsnu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_obsnu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_obsnu.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_obsnu.Location = new System.Drawing.Point(164, 8);
            this.txt_obsnu.Name = "txt_obsnu";
            this.txt_obsnu.Size = new System.Drawing.Size(280, 40);
            this.txt_obsnu.TabIndex = 14;
            this.txt_obsnu.Click += new System.EventHandler(this.txt_obsnu_Click);
            this.txt_obsnu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_obsnu_KeyDown);
            // 
            // cbo_style
            // 
            this.cbo_style.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_style.DropDownWidth = 500;
            this.cbo_style.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_style.FormattingEnabled = true;
            this.cbo_style.Location = new System.Drawing.Point(1449, 10);
            this.cbo_style.Name = "cbo_style";
            this.cbo_style.Size = new System.Drawing.Size(215, 41);
            this.cbo_style.TabIndex = 13;
            this.cbo_style.Visible = false;
            this.cbo_style.SelectionChangeCommitted += new System.EventHandler(this.cbo_model_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 33);
            this.label7.TabIndex = 12;
            this.label7.Text = "PO Number";
            // 
            // cbo_item
            // 
            this.cbo_item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_item.DropDownWidth = 191;
            this.cbo_item.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_item.FormattingEnabled = true;
            this.cbo_item.Location = new System.Drawing.Point(565, 5);
            this.cbo_item.Name = "cbo_item";
            this.cbo_item.Size = new System.Drawing.Size(191, 41);
            this.cbo_item.TabIndex = 11;
            this.cbo_item.SelectionChangeCommitted += new System.EventHandler(this.cbo_item_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(1687, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 33);
            this.label6.TabIndex = 10;
            this.label6.Text = "SEQ";
            this.label6.Visible = false;
            // 
            // txt_style
            // 
            this.txt_style.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_style.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_style.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_style.Location = new System.Drawing.Point(1247, 11);
            this.txt_style.Name = "txt_style";
            this.txt_style.Size = new System.Drawing.Size(202, 40);
            this.txt_style.TabIndex = 9;
            this.txt_style.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(479, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 33);
            this.label2.TabIndex = 8;
            this.label2.Text = "Item #";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1136, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "Style CD";
            this.label1.Visible = false;
            // 
            // cbo_seq
            // 
            this.cbo_seq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_seq.DropDownWidth = 80;
            this.cbo_seq.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_seq.FormattingEnabled = true;
            this.cbo_seq.Location = new System.Drawing.Point(1753, 10);
            this.cbo_seq.Name = "cbo_seq";
            this.cbo_seq.Size = new System.Drawing.Size(80, 41);
            this.cbo_seq.TabIndex = 6;
            this.cbo_seq.Visible = false;
            // 
            // cbo_size
            // 
            this.cbo_size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_size.DropDownWidth = 98;
            this.cbo_size.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_size.FormattingEnabled = true;
            this.cbo_size.Location = new System.Drawing.Point(1839, 11);
            this.cbo_size.Name = "cbo_size";
            this.cbo_size.Size = new System.Drawing.Size(37, 41);
            this.cbo_size.TabIndex = 5;
            this.cbo_size.Visible = false;
            this.cbo_size.SelectionChangeCommitted += new System.EventHandler(this.cbo_size_SelectionChangeCommitted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1183, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(213)))), ((int)(((byte)(244)))));
            this.lblDate.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblDate.Location = new System.Drawing.Point(1693, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(220, 83);
            this.lblDate.TabIndex = 654;
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
            this.pn_body.Controls.Add(this.pn_loc_wh);
            this.pn_body.Controls.Add(this.axSpreadTail);
            this.pn_body.Controls.Add(this.axSpreadHead);
            this.pn_body.Controls.Add(this.axfpSpread2);
            this.pn_body.Location = new System.Drawing.Point(0, 120);
            this.pn_body.Name = "pn_body";
            this.pn_body.Size = new System.Drawing.Size(1915, 931);
            this.pn_body.TabIndex = 655;
            // 
            // pn_loc_wh
            // 
            this.pn_loc_wh.Location = new System.Drawing.Point(147, 2);
            this.pn_loc_wh.Name = "pn_loc_wh";
            this.pn_loc_wh.Size = new System.Drawing.Size(1765, 595);
            this.pn_loc_wh.TabIndex = 4;
            this.pn_loc_wh.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_loc_wh_Paint);
            // 
            // axSpreadTail
            // 
            this.axSpreadTail.DataSource = null;
            this.axSpreadTail.Location = new System.Drawing.Point(48, 792);
            this.axSpreadTail.Name = "axSpreadTail";
            this.axSpreadTail.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSpreadTail.OcxState")));
            this.axSpreadTail.Size = new System.Drawing.Size(1849, 67);
            this.axSpreadTail.TabIndex = 3;
            this.axSpreadTail.Visible = false;
            // 
            // axSpreadHead
            // 
            this.axSpreadHead.DataSource = null;
            this.axSpreadHead.Location = new System.Drawing.Point(48, 602);
            this.axSpreadHead.Name = "axSpreadHead";
            this.axSpreadHead.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSpreadHead.OcxState")));
            this.axSpreadHead.Size = new System.Drawing.Size(1849, 189);
            this.axSpreadHead.TabIndex = 2;
            this.axSpreadHead.Visible = false;
            this.axSpreadHead.ClickEvent += new AxFPUSpreadADO._DSpreadEvents_ClickEventHandler(this.axSpreadHead_ClickEvent);
            // 
            // axfpSpread2
            // 
            this.axfpSpread2.DataSource = null;
            this.axfpSpread2.Location = new System.Drawing.Point(75, 4);
            this.axfpSpread2.Name = "axfpSpread2";
            this.axfpSpread2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpSpread2.OcxState")));
            this.axfpSpread2.Size = new System.Drawing.Size(66, 591);
            this.axfpSpread2.TabIndex = 1;
            this.axfpSpread2.BeforeEditMode += new AxFPUSpreadADO._DSpreadEvents_BeforeEditModeEventHandler(this.axfpSpread2_BeforeEditMode);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1102, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 656;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(213)))), ((int)(((byte)(244)))));
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Location = new System.Drawing.Point(1242, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(469, 79);
            this.panel2.TabIndex = 657;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 16.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(326, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 27);
            this.label9.TabIndex = 16;
            this.label9.Text = "(Unit: Carton)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 16.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(220, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 27);
            this.label8.TabIndex = 7;
            this.label8.Text = "Empty";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 16.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(220, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 27);
            this.label5.TabIndex = 6;
            this.label5.Text = ">=95% And <=100%";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(159, 40);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(55, 33);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 16.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(75, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 27);
            this.label4.TabIndex = 4;
            this.label4.Text = ">100%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 16.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(75, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 27);
            this.label3.TabIndex = 3;
            this.label3.Text = "<95%";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Yellow;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(159, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(55, 33);
            this.button5.TabIndex = 2;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(9, 40);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 33);
            this.button4.TabIndex = 1;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Green;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(9, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 33);
            this.button3.TabIndex = 0;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // lbl_Remain
            // 
            this.lbl_Remain.AutoSize = true;
            this.lbl_Remain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(213)))), ((int)(((byte)(244)))));
            this.lbl_Remain.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Remain.ForeColor = System.Drawing.Color.Black;
            this.lbl_Remain.Location = new System.Drawing.Point(946, 42);
            this.lbl_Remain.Name = "lbl_Remain";
            this.lbl_Remain.Size = new System.Drawing.Size(75, 33);
            this.lbl_Remain.TabIndex = 664;
            this.lbl_Remain.Text = "          ";
            // 
            // lbl_Actual
            // 
            this.lbl_Actual.AutoSize = true;
            this.lbl_Actual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(213)))), ((int)(((byte)(244)))));
            this.lbl_Actual.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Actual.ForeColor = System.Drawing.Color.Black;
            this.lbl_Actual.Location = new System.Drawing.Point(730, 41);
            this.lbl_Actual.Name = "lbl_Actual";
            this.lbl_Actual.Size = new System.Drawing.Size(51, 33);
            this.lbl_Actual.TabIndex = 663;
            this.lbl_Actual.Text = "      ";
            // 
            // lbl_Capa
            // 
            this.lbl_Capa.AutoSize = true;
            this.lbl_Capa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(213)))), ((int)(((byte)(244)))));
            this.lbl_Capa.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Capa.ForeColor = System.Drawing.Color.Black;
            this.lbl_Capa.Location = new System.Drawing.Point(730, 5);
            this.lbl_Capa.Name = "lbl_Capa";
            this.lbl_Capa.Size = new System.Drawing.Size(51, 33);
            this.lbl_Capa.TabIndex = 662;
            this.lbl_Capa.Text = "      ";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // cmd_back
            // 
            this.cmd_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(213)))), ((int)(((byte)(244)))));
            this.cmd_back.BackgroundImage = global::FORM.Properties.Resources.Back_Icon;
            this.cmd_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmd_back.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.cmd_back.FlatAppearance.BorderSize = 0;
            this.cmd_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_back.Location = new System.Drawing.Point(1149, 0);
            this.cmd_back.Name = "cmd_back";
            this.cmd_back.Size = new System.Drawing.Size(91, 83);
            this.cmd_back.TabIndex = 665;
            this.cmd_back.UseVisualStyleBackColor = false;
            this.cmd_back.Click += new System.EventHandler(this.cmd_back_Click);
            // 
            // FORM_SMF_PROD_WH_LOCATION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1916, 1054);
            this.Controls.Add(this.cmd_back);
            this.Controls.Add(this.lbl_Remain);
            this.Controls.Add(this.lbl_Actual);
            this.Controls.Add(this.lbl_Capa);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pn_body);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.pn_search);
            this.Controls.Add(this.lblTitle);
            this.Name = "FORM_SMF_PROD_WH_LOCATION";
            this.Text = "Location_IP_Mold";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Test_Location_IP_Mold_Load);
            this.VisibleChanged += new System.EventHandler(this.FORM_MOLD_LOCATION_VisibleChanged);
            this.pn_search.ResumeLayout(false);
            this.pn_search.PerformLayout();
            this.pn_body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axSpreadTail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSpreadHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pn_search;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pn_body;
        private System.Windows.Forms.ComboBox cbo_seq;
        private System.Windows.Forms.ComboBox cbo_size;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_style;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_item;
        private System.Windows.Forms.ComboBox cbo_style;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_obsnu;
        private AxFPUSpreadADO.AxfpSpread axfpSpread2;
        private AxFPUSpreadADO.AxfpSpread axSpreadHead;
        private AxFPUSpreadADO.AxfpSpread axSpreadTail;
        private System.Windows.Forms.Panel pn_loc_wh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbl_Remain;
        private System.Windows.Forms.Label lbl_Actual;
        private System.Windows.Forms.Label lbl_Capa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button cmd_back;

    }
}