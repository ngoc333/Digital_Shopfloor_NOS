using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class FORM_DSF_JOB_ROTATION : Form
    {
        public FORM_DSF_JOB_ROTATION()
        {
            InitializeComponent();
            tmrDate.Stop();
        }
        int iDx = 0, cCount = 0;

        public DataTable GET_DATA(string Type)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            // MyOraDB.ShowErr = true;

            try
            {
                string process_name = "MES.PKG_SMT_PROD.SP_SMT_JOB_ROTATION";

                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_QTYPE";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";


                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = Type;
                MyOraDB.Parameter_Values[1] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;

                // return ds_ret;
                return ds_ret.Tables[process_name];

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void sbtNav_Click(object sender, EventArgs e)
        {
            SimpleButton sbtn = ((SimpleButton)sender);
            switch (sbtn.Tag.ToString())
            {
                case "prev":
                    if (iDx <= 0)
                        iDx = 3;
                    else
                        iDx--;
                    break;
                case "next":
                    if (iDx >= 3)
                        iDx = 0;
                    else
                        iDx++;
                    break;
            }
            switch (iDx)
            {
                case 0:
                    navigationFrame1.SelectedPage = navigationPage1;
                    break;
                case 1:
                    navigationFrame1.SelectedPage = navigationPage2;
                    break;
                case 2:
                    navigationFrame1.SelectedPage = navigationPage3;
                    break;
                case 3:
                    navigationFrame1.SelectedPage = navigationPage4;
                    break;
            }

            lblPage.Text = "Page: "+ (iDx + 1).ToString();
            
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
            tmrDate.Stop();
        }

        private void FORM_DSF_JOB_ROTATION_Load(object sender, EventArgs e)
        {

            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        }

       private void LoadingImages()
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            string strLine = ComVar.Var._strValue2;
            string path1 = @"C:\\JOB_ROTATION\LINE_" + strLine + "\\FILE1";
            string path2 = @"C:\\JOB_ROTATION\LINE_" + strLine + "\\FILE2";
            if (!Directory.Exists(path1))
            {
                Directory.CreateDirectory(path1);
            }
            if (!Directory.Exists(path2))
            {
                Directory.CreateDirectory(path2);
            }
            try
            {
                DataTable dt = GET_DATA("Q");
                if (dt.Rows.Count > 0)
                {
                    switch (dt.Rows[0]["FILE_FOLDER"].ToString())
                    {
                        case "1":
                            if (File.Exists(path1 + "\\1.png"))
                                pictureBox1.Image = Image.FromFile(path1 + "\\1.png");
                            if (File.Exists(path1 + "\\2.png"))
                                pictureBox2.Image = Image.FromFile(path1 + "\\2.png");
                            if (File.Exists(path1 + "\\3.png"))
                                pictureBox3.Image = Image.FromFile(path1 + "\\3.png");
                            if (File.Exists(path1 + "\\4.png"))
                                pictureBox4.Image = Image.FromFile(path1 + "\\4.png");

                            break;
                        case "2":
                            if (File.Exists(path2 + "\\1.png"))
                            pictureBox1.Image = Image.FromFile(path2 + "\\1.png");
                            if (File.Exists(path2 + "\\2.png"))
                                pictureBox2.Image = Image.FromFile(path2 + "\\2.png");
                            if (File.Exists(path2 + "\\3.png"))
                                pictureBox3.Image = Image.FromFile(path2 + "\\3.png");
                            if (File.Exists(path2 + "\\4.png"))
                                pictureBox4.Image = Image.FromFile(path2 + "\\4.png");
                            break;
                    }

                }
            }
            catch(Exception ex) {
                MessageBox.Show("Không tìm thấy file ảnh, kiểm tra lại đường dẫn! Error: " + ex.Message);
            }
        }

        private void FORM_DSF_JOB_ROTATION_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    cCount = 60;
                    tmrDate.Start();
                }
                else
                    tmrDate.Stop();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (cCount >= 60)
            {
                cCount = 0;
                LoadingImages();
            }
        }
    }
}
