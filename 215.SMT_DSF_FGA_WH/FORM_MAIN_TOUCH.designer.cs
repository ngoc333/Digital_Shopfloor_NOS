namespace FORM
{
    partial class FORM_MAIN_TOUCH
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
            this.pn_main = new System.Windows.Forms.Panel();
            this.pn_footer = new System.Windows.Forms.Panel();
            this.cmd_Inventory = new System.Windows.Forms.Button();
            this.cmd_incoming_status = new System.Windows.Forms.Button();
            this.cmd_Delivery = new System.Windows.Forms.Button();
            this.cmd_shipping_sche = new System.Windows.Forms.Button();
            this.cmd_wh_location = new System.Windows.Forms.Button();
            this.pn_footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_main
            // 
            this.pn_main.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_main.Location = new System.Drawing.Point(0, 0);
            this.pn_main.Name = "pn_main";
            this.pn_main.Size = new System.Drawing.Size(1916, 1000);
            this.pn_main.TabIndex = 2;
            this.pn_main.Layout += new System.Windows.Forms.LayoutEventHandler(this.pn_main_Layout);
            // 
            // pn_footer
            // 
            this.pn_footer.Controls.Add(this.cmd_Inventory);
            this.pn_footer.Controls.Add(this.cmd_incoming_status);
            this.pn_footer.Controls.Add(this.cmd_Delivery);
            this.pn_footer.Controls.Add(this.cmd_shipping_sche);
            this.pn_footer.Controls.Add(this.cmd_wh_location);
            this.pn_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_footer.Location = new System.Drawing.Point(0, 978);
            this.pn_footer.Name = "pn_footer";
            this.pn_footer.Size = new System.Drawing.Size(1916, 76);
            this.pn_footer.TabIndex = 3;
            // 
            // cmd_Inventory
            // 
            this.cmd_Inventory.BackColor = System.Drawing.Color.DodgerBlue;
            this.cmd_Inventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_Inventory.Font = new System.Drawing.Font("Calibri", 30.75F, System.Drawing.FontStyle.Bold);
            this.cmd_Inventory.ForeColor = System.Drawing.Color.White;
            this.cmd_Inventory.Location = new System.Drawing.Point(1554, 3);
            this.cmd_Inventory.Name = "cmd_Inventory";
            this.cmd_Inventory.Size = new System.Drawing.Size(350, 70);
            this.cmd_Inventory.TabIndex = 2;
            this.cmd_Inventory.Text = "F/G Inventory";
            this.cmd_Inventory.UseVisualStyleBackColor = false;
            this.cmd_Inventory.Click += new System.EventHandler(this.cmd_Inventory_Click);
            // 
            // cmd_incoming_status
            // 
            this.cmd_incoming_status.BackColor = System.Drawing.Color.DodgerBlue;
            this.cmd_incoming_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_incoming_status.Font = new System.Drawing.Font("Calibri", 30.75F, System.Drawing.FontStyle.Bold);
            this.cmd_incoming_status.ForeColor = System.Drawing.Color.White;
            this.cmd_incoming_status.Location = new System.Drawing.Point(392, 3);
            this.cmd_incoming_status.Name = "cmd_incoming_status";
            this.cmd_incoming_status.Size = new System.Drawing.Size(350, 70);
            this.cmd_incoming_status.TabIndex = 4;
            this.cmd_incoming_status.Text = "Hourly Incoming";
            this.cmd_incoming_status.UseVisualStyleBackColor = false;
            this.cmd_incoming_status.Click += new System.EventHandler(this.cmd_incoming_status_Click);
            // 
            // cmd_Delivery
            // 
            this.cmd_Delivery.BackColor = System.Drawing.Color.DodgerBlue;
            this.cmd_Delivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_Delivery.Font = new System.Drawing.Font("Calibri", 30.75F, System.Drawing.FontStyle.Bold);
            this.cmd_Delivery.ForeColor = System.Drawing.Color.White;
            this.cmd_Delivery.Location = new System.Drawing.Point(1172, 3);
            this.cmd_Delivery.Name = "cmd_Delivery";
            this.cmd_Delivery.Size = new System.Drawing.Size(350, 70);
            this.cmd_Delivery.TabIndex = 3;
            this.cmd_Delivery.Text = "Delivery Tracking";
            this.cmd_Delivery.UseVisualStyleBackColor = false;
            this.cmd_Delivery.Click += new System.EventHandler(this.cmd_Delivery_Click);
            // 
            // cmd_shipping_sche
            // 
            this.cmd_shipping_sche.BackColor = System.Drawing.Color.DodgerBlue;
            this.cmd_shipping_sche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_shipping_sche.Font = new System.Drawing.Font("Calibri", 30.75F, System.Drawing.FontStyle.Bold);
            this.cmd_shipping_sche.ForeColor = System.Drawing.Color.White;
            this.cmd_shipping_sche.Location = new System.Drawing.Point(785, 3);
            this.cmd_shipping_sche.Name = "cmd_shipping_sche";
            this.cmd_shipping_sche.Size = new System.Drawing.Size(350, 70);
            this.cmd_shipping_sche.TabIndex = 1;
            this.cmd_shipping_sche.Text = "Shipping Schedule";
            this.cmd_shipping_sche.UseVisualStyleBackColor = false;
            this.cmd_shipping_sche.Click += new System.EventHandler(this.cmd_shipping_sche_Click);
            // 
            // cmd_wh_location
            // 
            this.cmd_wh_location.BackColor = System.Drawing.Color.DodgerBlue;
            this.cmd_wh_location.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_wh_location.Font = new System.Drawing.Font("Calibri", 30.75F, System.Drawing.FontStyle.Bold);
            this.cmd_wh_location.ForeColor = System.Drawing.Color.White;
            this.cmd_wh_location.Location = new System.Drawing.Point(5, 3);
            this.cmd_wh_location.Name = "cmd_wh_location";
            this.cmd_wh_location.Size = new System.Drawing.Size(350, 70);
            this.cmd_wh_location.TabIndex = 0;
            this.cmd_wh_location.Text = "F/G Location";
            this.cmd_wh_location.UseVisualStyleBackColor = false;
            this.cmd_wh_location.Click += new System.EventHandler(this.cmd_wh_location_Click);
            // 
            // Form_Main_Touch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1916, 1054);
            this.Controls.Add(this.pn_footer);
            this.Controls.Add(this.pn_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Main_Touch";
            this.Text = "F/G Warehouse ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Main_Touch_Load);
            this.pn_footer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_main;
        private System.Windows.Forms.Panel pn_footer;
        private System.Windows.Forms.Button cmd_wh_location;
        private System.Windows.Forms.Button cmd_shipping_sche;
        private System.Windows.Forms.Button cmd_Delivery;
        private System.Windows.Forms.Button cmd_Inventory;
        private System.Windows.Forms.Button cmd_incoming_status;
    }
}