using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace FORM
{
    public partial class FORM_TO_PO_WEEK_CHART : Form
    {
        public FORM_TO_PO_WEEK_CHART()
        {
            InitializeComponent();
            addUC();
        }

        int cnt = 0;
        string str_op = "";
        public delegate void MenuHandler();
        public MenuHandler OnClick = null;
        public DataTable _dt = null;
        public DataTable _dtTotal = null;
        #region db
        Database db = new Database();
        DataTable _dtXML = null;
        /// <summary>
        /// Khai báo biến toàn cục kiểu từ điển, sử dụng để gán 1 số giá trị mặc định cho form
        /// </summary>
        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        #endregion
        #region UC
        UC.UC_DWMY uc = new UC.UC_DWMY(3);

        UC.UC_CHART_TOTAL UC_TOTAL = new UC.UC_CHART_TOTAL("Total");
       
        UC.UC_CHART UC_CUT = new UC.UC_CHART("Cutting");
        UC.UC_CHART UC_HF = new UC.UC_CHART("H/F");
        UC.UC_CHART UC_HP = new UC.UC_CHART("H/P");
        UC.UC_CHART UC_NOSEW = new UC.UC_CHART("NOSEW");

        UC.UC_CHART_PO_TO UC_PO = new UC.UC_CHART_PO_TO("PO ratio");
        UC.UC_CHART UC_ASSE = new UC.UC_CHART("Assembly");
        UC.UC_CHART UC_STOCK = new UC.UC_CHART("Stock-fit");
        UC.UC_CHART UC_SIT1 = new UC.UC_CHART("Stitching 1");
        UC.UC_CHART UC_SIT2 = new UC.UC_CHART("Stitching 2");
        #endregion

        private void addUC()
        {
            tbl_main.Controls.Add(UC_TOTAL, 0, 0);           
            tbl_main.Controls.Add(UC_CUT, 1, 0);
            tbl_main.Controls.Add(UC_HF, 2, 0);
            tbl_main.Controls.Add(UC_HP, 3, 0);
            tbl_main.Controls.Add(UC_NOSEW, 4, 0);

            tbl_main.Controls.Add(UC_PO, 0, 1);
            tbl_main.Controls.Add(UC_SIT1, 1, 1);
            tbl_main.Controls.Add(UC_SIT2, 2, 1);            
            tbl_main.Controls.Add(UC_STOCK, 3, 1);
            tbl_main.Controls.Add(UC_ASSE, 4, 1);

        }

        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }

        private void FRM_ROLL_SLABTEST_MON_Load(object sender, EventArgs e)
        {
            //_dtnInit = getInitForm(this.GetType().Assembly.GetName().Name, this.GetType().Name);
           // _dtXML = ComVar.Func.ReadXML(Application.StartupPath + @"\InitForm.xml", this.GetType().Name);
            //_dtnInit = ComVar.Func.getInitForm(this.GetType().Assembly.GetName().Name, this.GetType().Name);
            GoFullscreen();
            timer2.Enabled = true;
            timer2.Start();
            timer2.Interval = 1000;
           // lblTitle1.Text = _dtnInit["Title"];
            //pnYMD.Controls.Add(uc);
            //uc.OnDWMYClick += DWMYClick;
            //uc.YMD_Change(1);
        }

        private void setComValue()
        {
            Dictionary<string, string> dtn = new Dictionary<string, string>();
            dtn = ComVar.Func.getInitForm(ComVar.Var._Frm_Call + "." + this.GetType().Assembly.GetName().Name, this.GetType().Name);
            if (dtn == null || dtn.Count == 0)
            {
                ComVar.Var.writeToLog(this.GetType().Name + " --> No Data");
                return;
            }

            _dtnInit = dtn;
            for (int i = 0; i < _dtnInit.Count; i++)
            {
                try
                {
                    if (_dtnInit.ElementAt(i).Key.Contains('.'))
                    {
                        string[] strSplit = _dtnInit.ElementAt(i).Key.Split('.');
                        Control cnt = this.Controls.Find(strSplit[0], true).FirstOrDefault();

                        System.Reflection.PropertyInfo propertyInfo = cnt.GetType().GetProperty(strSplit[1]);
                        propertyInfo.SetValue(cnt, Convert.ChangeType(_dtnInit.ElementAt(i).Value, propertyInfo.PropertyType), null);
                    }
                }
                catch (Exception ex)
                {
                    ComVar.Var.writeToLog(this.GetType().Name + " --> Void setComValue --> " + _dtnInit.ElementAt(i).Key + " :    " + ex.ToString());
                }
            }
            if (_dtnInit.ContainsKey("FRM_CALL"))
            {
                ComVar.Var._Frm_Call = _dtnInit["FRM_CALL"];
            }
        }
        

        void DWMYClick(string ButtonCap, string ButtonCD)
        {
            if (ButtonCap == "btnClose")
                ComVar.Var.callForm = ComVar.Var._Frm_Back;
            else
                ComVar.Var.callForm = ButtonCD;
           
        }


        public DataSet SEL_TOPO_DAY(string ARG_LINE, string ARG_MLINE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            System.Data.DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_TO_PO.SEL_TO_PO_DAY";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_LINE";
                MyOraDB.Parameter_Name[1] = "ARG_MLINE";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR2";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR3";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_LINE;
                MyOraDB.Parameter_Values[1] = ARG_MLINE;
                MyOraDB.Parameter_Values[2] = "";
                MyOraDB.Parameter_Values[3] = "";
                MyOraDB.Parameter_Values[4] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret;
            }
            catch
            {
                return null;
            }
        }
        private DataTable getData(string area)
        {
            DataTable dt = null;

            if (area == "9")
                dt = _dt.Select("ord =" + area ).CopyToDataTable();
            else
                dt = _dt.Select("ord =" + area + "and div in ('Indirect','Direct')").CopyToDataTable();

            return dt;
        }

        private void BindingData(string arg_QType, string arg_op)
        {
          //  grdView.Refresh();
            //DataSet ds = null;
            //DataTable dtsource = null;
            //DataTable dtchart = null;
            //DataTable dtchart2 = null;
            //dtsource = db.SEL_OS_PROD_MONTH(arg_QType, "", arg_op);

            //ds = SEL_TOPO_DAY(ComVar.Var._strValue4, ComVar.Var._strValue2.Substring(2,1));
            //dtsource = ds.Tables[0];
            //dtchart = ds.Tables[1];
            //dtchart2 = ds.Tables[2];


            UC_PO.BindingData(_dtTotal, "PO");
            UC_TOTAL.BindingData(getData("9"), "AVG");
            UC_CUT.BindingData(getData("1"), "AVG");
            UC_HF.BindingData(getData("2"), "AVG");
            UC_HP.BindingData(getData("3"), "AVG");
            UC_NOSEW.BindingData(getData("4"), "AVG");
           // UC_TOTAL.BindingData(dtchart, "TOTAL");
            UC_ASSE.BindingData(getData("8"), "AVG");
            UC_STOCK.BindingData(getData("7"), "AVG");
            UC_SIT1.BindingData(getData("5"), "AVG");
            UC_SIT2.BindingData(getData("6"), "AVG");
            


            /*
            formatband();
            grdView.DataSource = dtsource;
            if (dtsource != null && dtsource.Rows.Count > 0)
            {
                
                for (int i = 0; i < gvwView.Columns.Count; i++)
                {
                    gvwView.Columns[i].OptionsColumn.ReadOnly = true;
                    gvwView.Columns[i].OptionsColumn.AllowEdit = false;
                    gvwView.Columns[i].OptionsFilter.AllowFilter = false;
                    gvwView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwView.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gvwView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 18, FontStyle.Bold);
                    //if (i>0)
                    //{
                    //    gvwView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 15, FontStyle.Bold);
                    //}

                }
                gvwView.Columns[0].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            }
            */
        }

        private void bindingdatachart(string arg_QType, string arg_op)
        {
            DataTable dt = null;
            
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (cnt < 40)
            {
                cnt++;                
            }
            else
            {
                
                cnt = 0;
                BindingData("Q", "EMB");
                bindingdatachart("C", "EMB");
            }
        }

        private void FRM_ROLL_SLABTEST_MON_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    timer2.Start();
                    cnt = 40;
                   // setComValue();
                }
                else
                    timer2.Stop();
            }
            catch
            {

            }
        }

        private void chartSlabtest_CustomDrawAxisLabel(object sender, DevExpress.XtraCharts.CustomDrawAxisLabelEventArgs e)
        {
            try
            {
                if (e.Item.Axis is AxisX)
                {
                    e.Item.Text = e.Item.Text.Replace("_", "\n");
                }
            }
            catch
            {

            }
        }

        private void uc_month_ValueChangeEvent(object sender, EventArgs e)
        {
            try
            {
                BindingData("Q", "EMB");
                bindingdatachart("C", "EMB");
            }
            catch
            {

            }
        }

        private void lblDateTime_DoubleClick(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "exit";
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "177";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        

        
    }
}
