using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class FORM_MARKET_QUALITY : Form
    {
        public FORM_MARKET_QUALITY()
        {
            InitializeComponent();
        }

        int int_count = 0;
        int indexScreen;
        string line, mline,Lang;
       // init strinit = new init();
        public FORM_MARKET_QUALITY(string title, int _indexScreen, string _line, string _mline,string _Lang)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
            line = _line;
            mline = _mline;
            Lang = _Lang;
            timer1.Stop();
            timer2.Stop();
            lbltitle.Text = title;
        }


        public DataTable SEL_SMT_DEFECTIVE_RETURN(string ARG_QTYPE, string ARG_LINE, string ARG_MLINE, string ARG_DATE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_PROD.SP_SMT_DEFECTIVE_RETURN";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_LINE";
                MyOraDB.Parameter_Name[2] = "V_P_MLINE";
                MyOraDB.Parameter_Name[3] = "V_P_DATE";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ComVar.Var._strValue1;
                MyOraDB.Parameter_Values[2] = ComVar.Var._strValue2;
                MyOraDB.Parameter_Values[3] = ARG_DATE;
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
        private void load_data()
        {
            try
            {
                DataTable dt = SEL_SMT_DEFECTIVE_RETURN("Q4", line, mline, UC_YEAR.GetValue().ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i_row = 0; i_row < dt.Rows.Count; i_row++)
                    {
                        for (int i_col = 0; i_col < dt.Columns.Count; i_col++)
                        {
                            if (i_col > 0 && dt.Rows[i_row][i_col].ToString()!="")
                            {
                                if (i_col % 2 == 0)
                                {
                                    axfpSpread.SetText(i_col + 1, i_row + 2, Convert.ToDouble( dt.Rows[i_row][i_col].ToString()).ToString("#,0.0")+"%");
                                }
                                else
                                {
                                    axfpSpread.SetText(i_col + 1, i_row + 2, Convert.ToDouble(dt.Rows[i_row][i_col].ToString()).ToString("#,0.#"));
                                }
                            }
                            else
                            {
                                axfpSpread.SetText(i_col + 1, i_row + 2, dt.Rows[i_row][i_col].ToString());
                            }
                        }
                    }
                }
                else
                {
                    
                }
            }
            catch
            {
            }
        }

        private void bindingchart()
        {
            try
            {
                DataTable dt = SEL_SMT_DEFECTIVE_RETURN("Q5", line, mline, UC_YEAR.GetValue().ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
                    chartControl1.DataSource = dt;
                    chartControl1.Series[0].ArgumentDataMember = "GR";
                    chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                    chartControl1.Titles.Clear();
                    switch (Lang)
                    { 
                        case "Vn":
                            chartTitle1.Text = "Hàng C trả về (tháng)";
                            break;
                        case "En":
                            chartTitle1.Text = "Defective Return (Monthly)";
                            break;
                    }
                   
                    this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
                }
                else
                {
                    chartControl2.DataSource = null;
                }
            }
            catch
            {
            }
        }

        private void bindingchart2()
        {
            try
            {
                DataTable dt = SEL_SMT_DEFECTIVE_RETURN("Q6", line, mline, UC_YEAR.GetValue().ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
                    chartControl2.DataSource = dt;
                    chartControl2.Series[0].ArgumentDataMember = "MODEL_NAME";
                    chartControl2.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                    chartControl2.Series[1].ArgumentDataMember = "MODEL_NAME";
                    chartControl2.Series[1].ValueDataMembers.AddRange(new string[] { "RATE" });

                    chartControl2.Titles.Clear();
                    switch (Lang)
                    {
                        case "Vn":
                            chartTitle1.Text = "Model tiêu biểu";
                            break;
                        case "En":
                            chartTitle1.Text = "Top Model";
                            break;
                    }

                    this.chartControl2.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
                }
                else
                {
                    chartControl2.DataSource = null;
                }
            }
            catch
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (int_count < 30)
                    int_count++;
                else
                {
                    int_count = 0;
                    load_data();
                    bindingchart();
                    bindingchart2();
                }
            }
            catch
            {
            }
        }

        private void FRM_SMT_MARKET_QUALITY_Load(object sender, EventArgs e)
        {
            setConfigForm();
            //load_data();
            //bindingchart();
            //bindingchart2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FRM_SMT_MARKET_QUALITY_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cmdBack.Tag = ComVar.Var._Frm_Back;
                initForm();
                int_count = 30;
                timer1.Start();
                timer2.Start();
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
            }
               
        }

        private void axfpSpread_Advance(object sender, AxFPSpreadADO._DSpreadEvents_AdvanceEvent e)
        {

        }

        private void UC_YEAR_ValueChangeEvent(object sender, EventArgs e)
        {
            int_count = 0;
            load_data();
            bindingchart();
            bindingchart2();
        }
        private void initForm()
        {
            line = ComVar.Var._strValue1;
            mline = ComVar.Var._strValue2;
            Lang = ComVar.Var._strValue3;
            if (Lang=="Vn")
                lbltitle.Text = "Hàng C trả về theo Tháng";
            else
                lbltitle.Text = "Market Quality by Month";
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            
            ComVar.Var.callForm =  "back";
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
