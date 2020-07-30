using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace FORM
{
    public partial class FORM_SMT_ANDON_ANALYSIS_DAY : Form
    {
        public FORM_SMT_ANDON_ANALYSIS_DAY()
        {
            InitializeComponent();
        }
        #region Ora

        public DataTable SEL_DATA_ANDON(string Qtype, string ARG_LINE_CD, string ARG_MLINE_CD, string ARG_PROCESS_NAME)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PHUOC.SP_SMT_ANDON_ANALISYS_Q1"; //SP_SMT_ANDON_DAILY

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[3] = "ARG_PROCESS";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = Qtype;
                MyOraDB.Parameter_Values[1] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[2] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[3] = ARG_PROCESS_NAME;
                MyOraDB.Parameter_Values[4] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }

        #endregion

        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }

       // int indexScreen;
        string sLine, sMline;
        DataTable dtA = null, dtB = null, dtC = null;
        int  cCount = 0;
      //  init strinit = new init();
       
        private void FRM_ANDON_ANALYSIS_Load(object sender, EventArgs e)
        {
            GoFullscreen();
            setConfigForm();
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void BindingChart(DevExpress.XtraCharts.ChartControl sChart, DataTable dt, string Arg_Member, string Arg_ValueData)
        {
            sChart.DataSource = dt;
            sChart.Series[0].ArgumentDataMember = Arg_Member;
            sChart.Series[0].ValueDataMembers.AddRange(new string[] { Arg_ValueData });
            sChart.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            //DevExpress.XtraCharts.ConstantLine TargetLine = new DevExpress.XtraCharts.ConstantLine();
            //TargetLine.AxisValueSerializable = "1";
            //TargetLine.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            //TargetLine.Name = "Target: " + dt.Rows[0]["TARGET"].ToString();
            //((DevExpress.XtraCharts.XYDiagram)sChart.Diagram).AxisY.ConstantLines.Clear();
            //TargetLine.AxisValue = dt.Rows[0]["TARGET"];

            //((DevExpress.XtraCharts.XYDiagram)sChart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] {
            //TargetLine});
        }

        private void GetDataMiddle()
        {

        }


        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (cCount >= 30)
            {
                try
                {
                    dtB = SEL_DATA_ANDON("B2", sLine, sMline, null);
                    if (dtB != null && dtB.Rows.Count > 0)
                    {
                        BindingChart(chartQual, dtB, "STATION", "QUAL");
                        BindingChart(chartMa, dtB, "STATION", "MA");
                        BindingChart(chartProd, dtB, "STATION", "PROD");
                    }

                    dtA = SEL_DATA_ANDON("A2", sLine, sMline, null);
                    if (dtA != null && dtA.Rows.Count > 0)
                    {
                       // cProd = 0; cQual = 0; cMachine = 0;
                        tmrCount.Start();
                    }
                    else
                    {
                        tmrCount.Stop();
                        lblQual_DT.Text = "0";
                        lblMa_DT.Text = "0";
                        lblProd_DT.Text = "0";
                    }

                    dtC = SEL_DATA_ANDON("C2", sLine, sMline, "LA");
                    BindingChart(chartSumQual, dtC, "HH", "DT");
                    dtC = SEL_DATA_ANDON("C2", sLine, sMline, "LB");
                    BindingChart(chartSumMa, dtC, "HH", "DT");
                    dtC = SEL_DATA_ANDON("C2", sLine, sMline, "LC");
                    BindingChart(chartSumProd, dtC, "HH", "DT");
                }
                catch 
                { }
                
                cCount = 0;
            }
        }

        private void tmrCount_Tick(object sender, EventArgs e)
        {
            //if (cQual <= Convert.ToInt32(dtA.Rows[0]["DT"]) - 1)
            //{
            //    cQual++;
            //    lblQual_DT.Text = cQual.ToString();
            //}



            //if (cMachine <= Convert.ToInt32(dtA.Rows[1]["DT"]) - 1)
            //{
            //    cMachine++; lblMa_DT.Text = cMachine.ToString();
            //}


            //if (cProd <= Convert.ToInt32(dtA.Rows[2]["DT"]) - 1)
            //{
            //    cProd++; lblProd_DT.Text = cProd.ToString();
            //}





            //if (cMachine + cQual + cProd - 3 >= Convert.ToInt32(dtA.Rows[0]["DT"]) - 1 + Convert.ToInt32(dtA.Rows[1]["DT"]) - 1 + Convert.ToInt32(dtA.Rows[2]["DT"]) - 1)
            //{
            //    tmrCount.Stop();
            //}
            lblQual_DT.Text = Convert.ToDouble(dtA.Rows[0]["DT"]).ToString();
            lblMa_DT.Text = Convert.ToDouble(dtA.Rows[1]["DT"]).ToString();
            lblProd_DT.Text = Convert.ToDouble(dtA.Rows[2]["DT"]).ToString();
            tmrCount.Stop();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void FRM_ANDON_ANALYSIS_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cmdBack.Tag = ComVar.Var._Frm_Back;
                initForm();
                cCount = 30;
                tmrDate.Start();
            }
            else
                tmrDate.Stop();
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            cCount = 29;
        }





        private void initForm()
        {

            sLine = ComVar.Var._strValue1;
            sMline = ComVar.Var._strValue2;
           // Lang = ComVar.Var._strValue3;

            switch (ComVar.Var._strValue3)
            {
                case "Vn":
                    btnDay.Text = "Ngày";
                    btnMonth.Text = "Tháng";
                    btnWeek.Text = "Tuần";
                    btnYear.Text = "Năm";
                    lblTitle.Text = "Phân tích dữ liệu andon theo ngày";
                    break;
                case "En":
                    btnDay.Text = "Day";
                    btnMonth.Text = "Month";
                    btnWeek.Text = "Week";
                    btnYear.Text = "Year";
                    lblTitle.Text = "Andon Data Analysis by Day";
                    break;
            }

        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void menu_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            ComVar.Var.callForm = cnt.Tag == null ? "" : cnt.Tag.ToString();
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
    }
}
