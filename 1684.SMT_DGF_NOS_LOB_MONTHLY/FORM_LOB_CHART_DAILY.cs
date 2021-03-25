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
    public partial class FORM_LOB_CHART_DAILY : Form
    {
        public FORM_LOB_CHART_DAILY()
        {
            InitializeComponent();
        }
          int indexScreen;
        string _line, _mLine, _lang;
        int cCount = 0;
        Form[] arrForm = new Form[3];
       
        

        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }



        private void loadData()
        {
            try
            {
                DataTable dtData1 = new DataTable();
                DataTable dtData2 = new DataTable();
                string YM = dtpDate.DateTime.ToString("yyyyMM");
               // System.Data.DataSet ds = null ;

                dtData1 = GET_DATA("Q",_line, _mLine, "001",YM );
                if (dtData1 == null) return;
                else
                {
                    SetChart1(dtData1);
                }
                dtData2 = GET_DATA("Q",_line, _mLine, "002",YM);
                if (dtData2 == null) return;
                else
                {
                    SetChart2(dtData2);
                }
            }
            catch 
            {}
            
            
        }
        private void SetChart1(DataTable argDtChart)
        {

            try
            {

            

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[0].ArgumentScaleType = ScaleType.Qualitative;
             chart1.Series[1].ArgumentScaleType = ScaleType.Qualitative;
            if (argDtChart == null) return;
            for (int i = 0; i <= argDtChart.Rows.Count - 1; i++)
            {
                chart1.Series[0].Points.Add(new SeriesPoint(argDtChart.Rows[i]["YMD"].ToString(), argDtChart.Rows[i]["LOB_RESULT"]));
                chart1.Series[1].Points.Add(new SeriesPoint(argDtChart.Rows[i]["YMD"].ToString(), argDtChart.Rows[i]["LOB_TAR"]));

                double lob;
                double.TryParse(argDtChart.Rows[i]["LOB_RESULT"].ToString(), out lob); //out

                if (lob > 85)
                {
                    chart1.Series[0].Points[i].Color = Color.Green;
                }
                else if ((lob >= 75) && (lob <= 85))
                {
                    chart1.Series[0].Points[i].Color = Color.Yellow;
                }
                else if (lob < 75)
                {
                    chart1.Series[0].Points[i].Color = Color.Red;
                }
            }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(ex);
                //throw;
            }
        }

        private void SetChart2(DataTable argDtChart)
        {


            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart2.Series[0].ArgumentScaleType = ScaleType.Qualitative;
            chart2.Series[1].ArgumentScaleType = ScaleType.Qualitative;
            if (argDtChart == null) return;
            for (int i = 0; i <= argDtChart.Rows.Count - 1; i++)
            {
                chart2.Series[0].Points.Add(new SeriesPoint(argDtChart.Rows[i]["YMD"].ToString(), argDtChart.Rows[i]["LOB_RESULT"]));
                chart2.Series[1].Points.Add(new SeriesPoint(argDtChart.Rows[i]["YMD"].ToString(), argDtChart.Rows[i]["LOB_TAR"]));

                double lob;
                double.TryParse(argDtChart.Rows[i]["LOB_RESULT"].ToString(), out lob); //out

                if (lob > 85)
                {
                    chart2.Series[0].Points[i].Color = Color.Green;
                }
                else if ((lob >= 75) && (lob <= 85))
                {
                    chart2.Series[0].Points[i].Color = Color.Yellow;
                }
                else if (lob < 75)
                {
                    chart2.Series[0].Points[i].Color = Color.Red;
                }
            }
        }

        private void getDataByThread()
        {
            //DataSet ds = GET_DATA();

        }

        #region DB
       // private System.Data.DataSet GET_DATA(string Type, string FGA_Mline, string UPS_Mline)
        public DataTable GET_DATA(string Type, string Plant, string FGA_Mline, string UPS_Mline,string YM) 
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
          
           // MyOraDB.ShowErr = true;

            try
            {
                string process_name = "MES.PKG_SMT_PROD.SP_SMT_LOB_CHART_DAILY";

                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_QTYPE";
                MyOraDB.Parameter_Name[1] = "V_P_PLANT";
                MyOraDB.Parameter_Name[2] = "V_P_LINE";
                MyOraDB.Parameter_Name[3] = "V_P_MLINE";
                MyOraDB.Parameter_Name[4] = "V_P_YM";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";
              

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;
               
                MyOraDB.Parameter_Values[0] = Type;
                MyOraDB.Parameter_Values[1] = Plant;
                MyOraDB.Parameter_Values[2] = FGA_Mline;
                MyOraDB.Parameter_Values[3] = UPS_Mline;
                MyOraDB.Parameter_Values[4] = YM;
              
                MyOraDB.Parameter_Values[5] = "";
               
                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
              
               // return ds_ret;
                return ds_ret.Tables[process_name];
            
            }
            catch(Exception ex)
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
            if (cCount >= 20)
            {

                loadData();
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

        

        private void FORM_LOB_CHART_DAILY_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cmdBack.Tag = ComVar.Var._Frm_Back;

                _mLine = ComVar.Var._strValue2;
                _line = ComVar.Var._strValue1;//014
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                dtpDate.EditValue = DateTime.Now.ToString("yyyy-MM");
                //lblFGALine.Text = _mLine;
            }
            else
            {
                //timer1.Stop();
                //timer2.Stop();
            }
        }

        private void FORM_LOB_CHART_DAILY_Load(object sender, EventArgs e)
        {
            simpleButton1.Enabled = true;
            simpleButton2.Enabled = false;
            simpleButton3.Enabled = false;
            simpleButton4.Enabled = false;
            _mLine = ComVar.Var._strValue2;
            _line = ComVar.Var._strValue1;//014
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //lblFGALine.Text = _mLine;

        }

        private void dtpDate_EditValueChanged(object sender, EventArgs e)
        {
            loadData();
        }
        private void menu_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            ComVar.Var.callForm = cnt.Tag == null ? "" : cnt.Tag.ToString();
        }
    }
}
