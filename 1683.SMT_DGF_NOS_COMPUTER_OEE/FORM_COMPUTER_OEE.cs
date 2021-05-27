using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using DevExpress.XtraGauges.Core.Model;
using System.Threading;
using System.Diagnostics;
using DevExpress.XtraCharts;

namespace FORM
{
    public partial class FORM_COMPUTER_OEE : Form
    {
        public FORM_COMPUTER_OEE()
        {
            InitializeComponent();
        }
          int indexScreen;
        string plant_code, line_code, mline_code;
        int cCount = 0;
        Form[] arrForm = new Form[3];
        string plant = ComVar.Var._strValue1;
        string line = ComVar.Var._strValue2;



        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }



        private void loadData(string type, string ymdF, string ymdT, string plant, string line, string mline)
        {
            try
            {
                chart.DataSource = null;
                chart1.DataSource = null;
                chart2.DataSource = null;
                chart3.DataSource = null;
                chart4.DataSource = null;
                DataTable dtChart = null;
                DataTable dtChart1 = null;
                ymdF = dtpDateF.DateTime.ToString("yyyyMMdd");
                ymdT = dtpDateT.DateTime.ToString("yyyyMMdd");

                dtChart = GET_DATA1(type, ymdF,ymdT, plant, line, "001");

                if (dtChart.Select("MACHINE = '001'", "MACHINE").Count() > 0) 
                {
                    dtChart1 = dtChart.Select("MACHINE = '001'", "MACHINE").CopyToDataTable();
                    chart.DataSource = dtChart1;
                    chart.Series[0].ArgumentDataMember = "COL";
                    chart.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                    chart.Series[0].LegendTextPattern = "{A}";
                    


                   lbl_W1.Text ="MC Work: " + dtChart1.Rows[0]["MC_W_PER"] + "%" ;
                   lbl_Idle1.Text = "MC Idle: " + dtChart1.Rows[0]["MC_I_PER"] + "%";

                   if (double.Parse(dtChart1.Rows[0]["MC_W_PER"].ToString()) < 90)
                   {
                       lbl_W1.BackColor = Color.Red;
                       lbl_W1.ForeColor = Color.White;
                   }
                   else
                   {
                       lbl_W1.BackColor = Color.Green;
                       lbl_W1.ForeColor = Color.White;
                   }


                }
                if (dtChart.Select("MACHINE = '002'", "MACHINE").Count() > 0)
                {
                    dtChart1 = dtChart.Select("MACHINE = '002'", "MACHINE").CopyToDataTable();
                    chart1.DataSource = dtChart1;
                    chart1.Series[0].ArgumentDataMember = "COL";
                    chart1.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                    chart1.Series[0].LegendTextPattern = "{A}";



                    lbl_W2.Text = "MC Work: " + dtChart1.Rows[0]["MC_W_PER"] + "%";
                    lbl_Idle2.Text = "MC Idle: " + dtChart1.Rows[0]["MC_I_PER"] + "%";

                    if (double.Parse(dtChart1.Rows[0]["MC_W_PER"].ToString()) < 90)
                    {
                        lbl_W2.BackColor = Color.Red;
                        lbl_W2.ForeColor = Color.White;
                    }
                    else
                    {
                        lbl_W2.BackColor = Color.Green;
                        lbl_W2.ForeColor = Color.White;
                    }



                }
                if (dtChart.Select("MACHINE = '003'", "MACHINE").Count() > 0)
                {
                    dtChart1 = dtChart.Select("MACHINE = '003'", "MACHINE").CopyToDataTable();
                    chart2.DataSource = dtChart1;
                    chart2.Series[0].ArgumentDataMember = "COL";
                    chart2.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                    chart2.Series[0].LegendTextPattern = "{A}";


                    lbl_W3.Text = "MC Work: " + dtChart1.Rows[0]["MC_W_PER"] + "%";
                    lbl_Idle3.Text = "MC Idle: " + dtChart1.Rows[0]["MC_I_PER"] + "%";

                    if (double.Parse(dtChart1.Rows[0]["MC_W_PER"].ToString()) < 90)
                    {
                        lbl_W3.BackColor = Color.Red;
                        lbl_W3.ForeColor = Color.White;
                    }
                    else
                    {
                        lbl_W3.BackColor = Color.Green;
                        lbl_W3.ForeColor = Color.White;
                    }


                }
                if (dtChart.Select("MACHINE = '004'", "MACHINE").Count() > 0)
                {
                    dtChart1 = dtChart.Select("MACHINE = '004'", "MACHINE").CopyToDataTable();
                    chart3.DataSource = dtChart1;
                    chart3.Series[0].ArgumentDataMember = "COL";
                    chart3.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                    chart3.Series[0].LegendTextPattern = "{A}";


                    lbl_W4.Text = "MC Work: " + dtChart1.Rows[0]["MC_W_PER"] + "%";
                    lbl_Idle4.Text = "MC Idle: " + dtChart1.Rows[0]["MC_I_PER"] + "%";

                    if (double.Parse(dtChart1.Rows[0]["MC_W_PER"].ToString()) < 90)
                    {
                        lbl_W4.BackColor = Color.Red;
                        lbl_W4.ForeColor = Color.White;
                    }
                    else
                    {
                        lbl_W4.BackColor = Color.Green;
                        lbl_W4.ForeColor = Color.White;
                    }


                }
                if (dtChart.Select("MACHINE = '005'", "MACHINE").Count() > 0)
                {
                    dtChart1 = dtChart.Select("MACHINE = '005'", "MACHINE").CopyToDataTable();
                    chart4.DataSource = dtChart1;
                    chart4.Series[0].ArgumentDataMember = "COL";
                    chart4.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                    chart4.Series[0].LegendTextPattern = "{A}";



                    lbl_W5.Text = "MC Work: " + dtChart1.Rows[0]["MC_W_PER"] + "%";
                    lbl_Idle5.Text = "MC Idle: " + dtChart1.Rows[0]["MC_I_PER"] + "%";

                    if (double.Parse(dtChart1.Rows[0]["MC_W_PER"].ToString()) < 90)
                    {
                        lbl_W5.BackColor = Color.Red;
                        lbl_W5.ForeColor = Color.White;
                    }
                    else
                    {
                        lbl_W5.BackColor = Color.Green;
                        lbl_W5.ForeColor = Color.White;
                    }



                }
                if (dtChart.Select("MACHINE = '006'", "MACHINE").Count() > 0)
                {
                    dtChart1 = dtChart.Select("MACHINE = '006'", "MACHINE").CopyToDataTable();
                    chart5.DataSource = dtChart1;
                    chart5.Series[0].ArgumentDataMember = "COL";
                    chart5.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                    chart5.Series[0].LegendTextPattern = "{A}";


                    lbl_W6.Text = "MC Work: " + dtChart1.Rows[0]["MC_W_PER"] + "%";
                    lbl_Idle6.Text = "MC Idle: " + dtChart1.Rows[0]["MC_I_PER"] + "%";

                    if (double.Parse(dtChart1.Rows[0]["MC_W_PER"].ToString()) < 90)
                    {
                        lbl_W6.BackColor = Color.Red;
                        lbl_W6.ForeColor = Color.White;
                    }
                    else
                    {
                        lbl_W6.BackColor = Color.Green;
                        lbl_W6.ForeColor = Color.White;
                    }



                }
                if (dtChart.Select("MACHINE = '007'", "MACHINE").Count() > 0)
                {
                    dtChart1 = dtChart.Select("MACHINE = '007'", "MACHINE").CopyToDataTable();
                    chart6.DataSource = dtChart1;
                    chart6.Series[0].ArgumentDataMember = "COL";
                    chart6.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                    chart6.Series[0].LegendTextPattern = "{A}";


                    lbl_W7.Text = "MC Work: " + dtChart1.Rows[0]["MC_W_PER"] + "%";
                    lbl_Idle7.Text = "MC Idle: " + dtChart1.Rows[0]["MC_I_PER"] + "%";

                    if (double.Parse(dtChart1.Rows[0]["MC_W_PER"].ToString()) < 90)
                    {
                        lbl_W7.BackColor = Color.Red;
                        lbl_W7.ForeColor = Color.White;
                    }
                    else
                    {
                        lbl_W7.BackColor = Color.Green;
                        lbl_W7.ForeColor = Color.White;
                    }

                }
                if (dtChart.Select("MACHINE = '008'", "MACHINE").Count() > 0)
                {
                    dtChart1 = dtChart.Select("MACHINE = '008'", "MACHINE").CopyToDataTable();
                    chart7.DataSource = dtChart1;
                    chart7.Series[0].ArgumentDataMember = "COL";
                    chart7.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                    chart7.Series[0].LegendTextPattern = "{A}";



                    lbl_W8.Text = "MC Work: " + dtChart1.Rows[0]["MC_W_PER"] + "%";
                    lbl_Idle8.Text = "MC Idle: " + dtChart1.Rows[0]["MC_I_PER"] + "%";

                    if (double.Parse(dtChart1.Rows[0]["MC_W_PER"].ToString()) < 90)
                    {
                        lbl_W8.BackColor = Color.Red;
                        lbl_W8.ForeColor = Color.White;
                    }
                    else
                    {
                        lbl_W8.BackColor = Color.Green;
                        lbl_W8.ForeColor = Color.White;
                    }


                }
                if (dtChart.Select("MACHINE = '009'", "MACHINE").Count() > 0)
                {
                    dtChart1 = dtChart.Select("MACHINE = '009'", "MACHINE").CopyToDataTable();
                    chart8.DataSource = dtChart1;
                    chart8.Series[0].ArgumentDataMember = "COL";
                    chart8.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                    chart8.Series[0].LegendTextPattern = "{A}";




                    lbl_W9.Text = "MC Work: " + dtChart1.Rows[0]["MC_W_PER"] + "%";
                    lbl_Idle9.Text = "MC Idle: " + dtChart1.Rows[0]["MC_I_PER"] + "%";

                    if (double.Parse(dtChart1.Rows[0]["MC_W_PER"].ToString()) < 90)
                    {
                        lbl_W9.BackColor = Color.Red;
                        lbl_W9.ForeColor = Color.White;
                    }
                    else
                    {
                        lbl_W9.BackColor = Color.Green;
                        lbl_W9.ForeColor = Color.White;
                    }


                }
                if (dtChart.Select("MACHINE = '010'", "MACHINE").Count() > 0)
                {
                    dtChart1 = dtChart.Select("MACHINE = '010'", "MACHINE").CopyToDataTable();
                    chart9.DataSource = dtChart1;
                    chart9.Series[0].ArgumentDataMember = "COL";
                    chart9.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                    chart9.Series[0].LegendTextPattern = "{A}";



                    lbl_W10.Text = "MC Work: " + dtChart1.Rows[0]["MC_W_PER"] + "%";
                    lbl_Idle10.Text = "MC Idle: " + dtChart1.Rows[0]["MC_I_PER"] + "%";

                    if (double.Parse(dtChart1.Rows[0]["MC_W_PER"].ToString()) < 90)
                    {
                        lbl_W10.BackColor = Color.Red;
                        lbl_W10.ForeColor = Color.White;
                    }
                    else
                    {
                        lbl_W10.BackColor = Color.Green;
                        lbl_W10.ForeColor = Color.White;
                    }


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


       

        private void getDataByThread()
        {
            //DataSet ds = GET_DATA();

        }

        #region DB
       // private System.Data.DataSet GET_DATA(string Type, string FGA_Mline, string UPS_Mline)
        public DataTable GET_DATA(string Type, string YM, string Plant, string FGA_Mline, string UPS_Mline) 
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PROD.SP_SMT_COMPUTER_OEE";

                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_QTYPE";
                MyOraDB.Parameter_Name[1] = "V_P_YMD";
                MyOraDB.Parameter_Name[2] = "V_P_LINE";
                MyOraDB.Parameter_Name[3] = "V_P_MLINE";
                MyOraDB.Parameter_Name[4] = "V_P_UPS_MLINE";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";
              

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;
               
                MyOraDB.Parameter_Values[0] = Type;
                MyOraDB.Parameter_Values[1] = YM;
                MyOraDB.Parameter_Values[2] = Plant;
                MyOraDB.Parameter_Values[3] = FGA_Mline;
                MyOraDB.Parameter_Values[4] = UPS_Mline;
                MyOraDB.Parameter_Values[5] = "";
               
                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }
        public DataTable GET_DATA1(string Type, string YMD1,string YMD2, string Plant, string FGA_Mline, string UPS_Mline)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PROD.SP_SMT_COMPUTER_OEE1";

                MyOraDB.ReDim_Parameter(7);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_QTYPE";
                MyOraDB.Parameter_Name[1] = "V_P_YMDF";
                MyOraDB.Parameter_Name[2] = "V_P_YMDT";
                MyOraDB.Parameter_Name[3] = "V_P_LINE";
                MyOraDB.Parameter_Name[4] = "V_P_MLINE";
                MyOraDB.Parameter_Name[5] = "V_P_UPS_MLINE";
                MyOraDB.Parameter_Name[6] = "OUT_CURSOR";


                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[6] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = Type;
                MyOraDB.Parameter_Values[1] = YMD1;
                MyOraDB.Parameter_Values[2] = YMD2;
                MyOraDB.Parameter_Values[3] = Plant;
                MyOraDB.Parameter_Values[4] = FGA_Mline;
                MyOraDB.Parameter_Values[5] = UPS_Mline;
                MyOraDB.Parameter_Values[6] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }
        #endregion DB

     
       
        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            string ymdF = dtpDateF.DateTime.ToString("yyyyMMdd");
            string ymdT = dtpDateF.DateTime.ToString("yyyyMMdd");
            if (cCount >= 20)
            {

                loadData("OEE", ymdF,ymdT, plant, line, "001");
                Thread t = new Thread(new ThreadStart(getDataByThread));
                t.Start();
                
                cCount = 0;
            }

        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void uc_month_ValueChangeEvent(object sender, EventArgs e)
        {
           // loadData();
        }
        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

      

        #region  Get Config Data From Database
        /// <summary>
        /// Declare _dtnInit
        /// Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        /// </summary>
        private void setConfigForm()
        {
            try
            {
                System.Collections.Generic.Dictionary<string, string> dtnInit = new System.Collections.Generic.Dictionary<string, string>();
                dtnInit = ComVar.Func.getInitForm(ComVar.Var._Area + this.GetType().Assembly.GetName().Name, this.GetType().Name);

                for (int i = 0; i < dtnInit.Count; i++)
                {
                    setComValue(dtnInit.ElementAt(i).Key, dtnInit.ElementAt(i).Value);
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setConfigForm-->Err:    " + ex.ToString());
            }
        }

        private void setComValue(string obj, string obj_value)
        {
            try
            {
                if (obj.Contains('.'))
                {
                    string[] strSplit = obj.Split('.');
                    Control[] cnt = this.Controls.Find(strSplit[0], true);

                    for (int i = 0; i < cnt.Length; i++)
                    {
                        System.Reflection.PropertyInfo propertyInfo = cnt[i].GetType().GetProperty(strSplit[1]);
                        propertyInfo.SetValue(cnt[i], Convert.ChangeType(obj_value, propertyInfo.PropertyType), null);
                    }
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setComValue (" + obj + ", " + obj_value + ") Err:    " + ex.ToString());
            }

        }
        #endregion 

        

        private void FORM_COMPUTER_OEE_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cmdBack.Tag = ComVar.Var._Frm_Back;
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                dtpDateF.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                dtpDateT.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                simpleButton1.Enabled = true;
                simpleButton2.Enabled = false;
                simpleButton3.Enabled = false;
                simpleButton4.Enabled = false;
            }
            else
            {
                //timer1.Stop();
                //timer2.Stop();
            }
        }

       

        private void chart_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            PieDrawOptions drawOptions = e.SeriesDrawOptions as PieDrawOptions;
            if (drawOptions == null)
                return;
            string sRating = e.SeriesPoint.Argument;
            if (sRating.Contains("MACHINE WORKING"))
            {
               // drawOptions.Color = Color.FromArgb(91,155,213);
                drawOptions.Color = Color.Green;
               // chart.Series[0].Legend.Border.Color = System.Drawing.Color.Green;
               //chart.PaletteName = 
            }
            else
            {
                drawOptions.Color = Color.FromArgb(237, 125, 49);
                //drawOptions.Color = Color.Orange;
            }
        }

        private void chart1_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            PieDrawOptions drawOptions = e.SeriesDrawOptions as PieDrawOptions;
            if (drawOptions == null)
                return;
            string sRating = e.SeriesPoint.Argument;
            if (sRating.Contains("MACHINE WORKING"))
            {
                drawOptions.Color = Color.FromArgb(91, 155, 213);
            }
            else
            {
                drawOptions.Color = Color.FromArgb(237, 125, 49);
            }
        }

        private void chart2_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            PieDrawOptions drawOptions = e.SeriesDrawOptions as PieDrawOptions;
            if (drawOptions == null)
                return;
            string sRating = e.SeriesPoint.Argument;
            if (sRating.Contains("MACHINE WORKING"))
            {
                drawOptions.Color = Color.FromArgb(91, 155, 213);
            }
            else
            {
                drawOptions.Color = Color.FromArgb(237, 125, 49);
            }
        }

        private void chart3_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            PieDrawOptions drawOptions = e.SeriesDrawOptions as PieDrawOptions;
            if (drawOptions == null)
                return;
            string sRating = e.SeriesPoint.Argument;
            if (sRating.Contains("MACHINE WORKING"))
            {
                drawOptions.Color = Color.FromArgb(91, 155, 213);
            }
            else
            {
                drawOptions.Color = Color.FromArgb(237, 125, 49);
            }
        }

        private void chart4_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            PieDrawOptions drawOptions = e.SeriesDrawOptions as PieDrawOptions;
            if (drawOptions == null)
                return;
            string sRating = e.SeriesPoint.Argument;
            if (sRating.Contains("MACHINE WORKING"))
            {
                drawOptions.Color = Color.FromArgb(91, 155, 213);
            }
            else
            {
                drawOptions.Color = Color.FromArgb(237, 125, 49);
            }
        }

        private void chart5_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            PieDrawOptions drawOptions = e.SeriesDrawOptions as PieDrawOptions;
            if (drawOptions == null)
                return;
            string sRating = e.SeriesPoint.Argument;
            if (sRating.Contains("MACHINE WORKING"))
            {
                drawOptions.Color = Color.FromArgb(91, 155, 213);
            }
            else
            {
                drawOptions.Color = Color.FromArgb(237, 125, 49);
            }
        }

        private void chart6_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            PieDrawOptions drawOptions = e.SeriesDrawOptions as PieDrawOptions;
            if (drawOptions == null)
                return;
            string sRating = e.SeriesPoint.Argument;
            if (sRating.Contains("MACHINE WORKING"))
            {
                drawOptions.Color = Color.FromArgb(91, 155, 213);
            }
            else
            {
                drawOptions.Color = Color.FromArgb(237, 125, 49);
            }
        }

        private void chart7_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            PieDrawOptions drawOptions = e.SeriesDrawOptions as PieDrawOptions;
            if (drawOptions == null)
                return;
            string sRating = e.SeriesPoint.Argument;
            if (sRating.Contains("MACHINE WORKING"))
            {
                drawOptions.Color = Color.FromArgb(91, 155, 213);
            }
            else
            {
                drawOptions.Color = Color.FromArgb(237, 125, 49);
            }
        }

        private void chart8_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            PieDrawOptions drawOptions = e.SeriesDrawOptions as PieDrawOptions;
            if (drawOptions == null)
                return;
            string sRating = e.SeriesPoint.Argument;
            if (sRating.Contains("MACHINE WORKING"))
            {
                drawOptions.Color = Color.FromArgb(91, 155, 213);
            }
            else
            {
                drawOptions.Color = Color.FromArgb(237, 125, 49);
            }
        }

        private void chart9_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            PieDrawOptions drawOptions = e.SeriesDrawOptions as PieDrawOptions;
            if (drawOptions == null)
                return;
            string sRating = e.SeriesPoint.Argument;
            if (sRating.Contains("MACHINE WORKING"))
            {
                drawOptions.Color = Color.FromArgb(91, 155, 213);
            }
            else
            {
                drawOptions.Color = Color.FromArgb(237, 125, 49);
            }
        }

        private void FORM_COMPUTER_OEE_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //lblFGALine.Text = line;

            dtpDateF.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            dtpDateT.EditValue=DateTime.Now.ToString("yyyy-MM-dd");

            string ymdF = dtpDateF.DateTime.ToString("yyyyMMdd");
            string ymdT = dtpDateF.DateTime.ToString("yyyyMMdd");

            loadData("OEE", ymdF,ymdT, plant, line, "001");

        }

      

        private void dtpDateT_EditValueChanged(object sender, EventArgs e)
        {
            string ymdF = dtpDateF.DateTime.ToString("yyyyMMdd");
            string ymdT = dtpDateF.DateTime.ToString("yyyyMMdd");
            loadData("OEE", ymdF, ymdT, plant, line, "001");
        }

        private void dtpDateF_EditValueChanged(object sender, EventArgs e)
        {
            string ymdF = dtpDateF.DateTime.ToString("yyyyMMdd");
            string ymdT = dtpDateF.DateTime.ToString("yyyyMMdd");
            loadData("OEE", ymdF, ymdT, plant, line, "001");
        }
    }
}
