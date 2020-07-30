namespace FORM
{
    partial class POP_SHIP_SCHEDULE
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
            this.cmd_text = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmd_text
            // 
            this.cmd_text.BackColor = System.Drawing.SystemColors.Control;
            this.cmd_text.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmd_text.FlatAppearance.BorderSize = 0;
            this.cmd_text.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_text.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_text.ForeColor = System.Drawing.Color.Blue;
            this.cmd_text.Location = new System.Drawing.Point(0, 92);
            this.cmd_text.Name = "cmd_text";
            this.cmd_text.Size = new System.Drawing.Size(411, 113);
            this.cmd_text.TabIndex = 0;
            this.cmd_text.Text = "Can Not Shiping";
            this.cmd_text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmd_text.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(322, -3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 75);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // POP_SHIP_SCHEDULE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(411, 205);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmd_text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "POP_SHIP_SCHEDULE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pop_Shipping_Schedual";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmd_text;
        private System.Windows.Forms.Button button1;
    }
}