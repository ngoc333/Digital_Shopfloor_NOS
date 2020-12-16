using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace FORM
{
    public partial class FORM_MAIN_8_LINE : Form
    {
        public FORM_MAIN_8_LINE()
        {
            InitializeComponent();
            // this.Text = "Insole";
            Init_Form();
        }

        #region Variant Global
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool turnon);

        readonly MODEL_LINE lineInstance = new MODEL_LINE();

        public string sLine = ComVar.Var._strValue1, sMline = ComVar.Var._strValue2, lang = ComVar.Var._strValue3;
        int ccountN = 0;

        //int ccount = 0;
        // bool _fac = true;
        readonly DataTable dtModel = null;
        private const int SW_MAXIMIZE = 3;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        DataTable _dtGMES = null;
      //  string Lang = "En", LangTemp = null;
        //rivate Database _db = new Database();
       // DataTable _dtXML = null;
        int _iCount = 0;

        //int _iStartText = 0;
        //Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        //int lockTimerCounter;
        readonly int lockTimerCounterN =0;
        bool _IsMain = true;
        #endregion

        #region Load/ Visible Change/ Close/ Minimized/ Timer Load
        private void DIGITAL_SHOP_FLOOR_OS_Load(object sender, EventArgs e)
        {
            try
            {
                if (ComVar.Var._Frm_Back == null || ComVar.Var._Frm_Back == "")
                {
                    _IsMain = true;
                   // _dtnInit = ComVar.Func.getInitForm(this.GetType().Assembly.GetName().Name, this.GetType().Name);
                    _dtGMES = ComVar.Func.ReadXML(Application.StartupPath + @"\Config.xml", "GMES");

                    //if (ComVar.Var._strValue4 != null && ComVar.Var._strValue4 != "")
                    //{
                    //    cmdBack.Visible = true;
                    //}
                    //else
                    //    ComVar.Var._strValue4 = "N";
                    cmdMGL.Visible = false;
                }
                else
                {
                    _IsMain = false;
                    cmdMGL.Visible = true;
                    cmdBack.Visible = ComVar.Var._Frm_Back=="900";
                    cmdTMS.Visible = !(ComVar.Var._Frm_Back=="900");
                    cmdQMS.Visible = !(ComVar.Var._Frm_Back=="900");
                    cmdMGL.Visible = !(ComVar.Var._Frm_Back=="900");
                }
                // add_Event_Click_Menu_Line();
                //set_Header_Menu_And_Text();
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + "/Form_Load  :   " + ex.ToString());
            }
        }

        private void SMT_B_INSOLE_MAIN_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                ComVar.Var._strValue3 = "En";
                if (_IsMain)
                {
                    SetConfigForm();
                }

                loadLinePicture();
                timer1.Start();
                _iCount = 0;
            }
            else
            {
                timer1.Stop();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDateTime.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
                _iCount++;
                if (_iCount >= 30)
                {
                    //  Thread t = new Thread(new ThreadStart(getDataUC));
                    //  t.Start();
                    ////loadDataUC();
                    DataTable dt = dtPUPLayout();
                    lang = ComVar.Var._strValue3;
                    //DataTable dtModel = SEL_MODEL_NAME("Q", dt.Rows[iLine]["LINE_CD"].ToString(), dt.Rows[iLine]["LINE_CD1"].ToString());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int iLine = 0;
                        foreach (UserControl c in this.tblMain2.Controls)
                        {
                            DataTable dtOS = SEL_PROD_MDI(dt.Rows[iLine]["LINE_CD"].ToString(), dt.Rows[iLine]["LINE_CD1"].ToString());
                            UC.UC_MENU_DSF_2 MENU_WS = null;
                            MENU_WS = (UC.UC_MENU_DSF_2)c;
                            MENU_WS.BindingData(dtOS, iLine, dtModel);
                            // MENU_WS.Animation("En", c);
                            iLine++;
                        }
                        _iCount = 0;
                    }



                    _iCount = 0;
                }


            }
            catch
            { //splashScreenManager1.CloseWaitForm(); 
            }
        }

        private void lblDateTime_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion Load/ Visible Change/ Close/ Minimized


        #region DB
        private DataTable SEL_PROD_MDI(string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_DSF_NOS.SP_SMT_PROD_MDI";

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[1] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[1] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[2] = "";


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

        

        public DataTable SEL_MODEL_NAME(string ARG_QTYPE, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PHUOC.SP_SMT_TEST";

                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[2] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[3] = "";


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

        public DataTable SEL_IMG()
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "SEPHIROTH.PROC_STB_GET_IMG";

                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_CLASS_NM";
                MyOraDB.Parameter_Name[1] = "ARG_LINE";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = this.GetType().Name;
                MyOraDB.Parameter_Values[1] = ComVar.Var._strValue1;
                MyOraDB.Parameter_Values[2] = "";
                MyOraDB.Parameter_Values[3] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->DB-->SEL_MODEL_NAME -->Err: " + ex.ToString());
                return null;
            }
        }
        #endregion

        #region Func
        /// <summary>
        /// Init form lúc ban đầu khởi động form
        /// </summary>
        private void Init_Form()
        {
            ComVar.Var._strValue1 = "099";
            ComVar.Var._strValue3 = "En";
            // lblTitle.Text = _dtnInit["Title"];

            //  lbl_Line.Text = "Nos N";
            DataTable dt = dtPUPLayout();
            DataTable dtModel = SEL_MODEL_NAME("Q", "099", "099");
            if (ccountN == 0)
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataTable dtOS = SEL_PROD_MDI(dt.Rows[i]["LINE_CD"].ToString(), dt.Rows[i]["LINE_CD1"].ToString());
                        UC.UC_MENU_DSF_2 MENU_WS = new UC.UC_MENU_DSF_2(dt.Rows[i]["LINE_NM"].ToString(), dt.Rows[i]["LINE_CD"].ToString(), dt.Rows[i]["LINE_CD1"].ToString());

                        tblMain2.Controls.Add(MENU_WS, Convert.ToInt32(dt.Rows[i]["LOC_COL"]), Convert.ToInt32(dt.Rows[i]["LOC_ROW"]));
                        MENU_WS.BindingData(dtOS, i, dtModel);
                        dtOS = null;
                        MENU_WS.OnMenuClick += MenuOnClick;
                        MENU_WS.MoveLeave += MoveLeaveClick;
                        MENU_WS.Dock = DockStyle.Fill;
                        //MENU_WS.GetImage(dt, i);
                        // MENU_WS.Animation("En", tblMain2);
                        //MENU_WS.changeColor();
                        //MENU_WS.UpdateText(i);


                    }
                }
            }

            ccountN++;
            // selectNos();
        }

        private DataTable dtPUPLayout()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("LINE_CD");
            dt.Columns.Add("LINE_CD1");
            dt.Columns.Add("LINE_NM");
            dt.Columns.Add("LOC_ROW");
            dt.Columns.Add("LOC_COL");

            dt.Rows.Add("099", "001", "Line 1", "0", "0");
            dt.Rows.Add("099", "002", "Line 2", "0", "1");
            dt.Rows.Add("099", "003", "Line 3", "0", "2");
            dt.Rows.Add("099", "004", "Line 4", "0", "3");
            dt.Rows.Add("099", "005", "Line 5", "1", "0");
            dt.Rows.Add("099", "006", "Line 6", "1", "1");
            dt.Rows.Add("099", "007", "Line 7", "1", "2");
            dt.Rows.Add("099", "008", "Line 8", "1", "3");


            return dt;
        }

        /// <summary>
        /// Load picture PIC of Line
        /// </summary>
        private void loadLinePicture()
        {
            try
            {
                DataTable dt = SEL_IMG();
                if (dt == null || dt.Rows.Count == 0) return;
                Control cnt = null;
                string strConName = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        strConName = dt.Rows[i]["CNTR_NAME"].ToString();
                        cnt = this.Controls.Find(strConName, true).FirstOrDefault();
                        cnt.BackgroundImage = (Bitmap)((new ImageConverter()).ConvertFrom((byte[])dt.Rows[i]["IMG"]));
                        cnt.BackgroundImageLayout = ImageLayout.Stretch;

                        cnt = this.Controls.Find(strConName.Replace("pic", "lbl"), true).FirstOrDefault();
                        cnt.Text = dt.Rows[i]["NAME"].ToString();
                    }
                    catch (Exception ex)
                    {
                        ComVar.Var.writeToLog(this.GetType().Name + "-->loadLinePicture" + strConName + "-->Err: " + ex.ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->loadLinePicture-->Err: " + ex.ToString());
            }

        }
        #endregion





        /// <summary>
        /// menu ở phía trong từn line
        /// </summary>
        #region Menu Line Click




        void MenuOnClick(string MenuName, string BtnName)
        {
            try
            {
                if (BtnName == "0")
                {
                    pic_under.Visible = true;
                    pic_under.BringToFront();
                }
                else if (BtnName == "cmdQP")
                {
                    string Caption = "Performance Dashboard";
                    switch (ComVar.Var._strValue3)
                    {
                        case "Vn":
                            Caption = "Bảng hiệu suất";
                            break;
                        default:
                            Caption = "Performance Dashboard";
                            break;
                    }
                    Form fc = Application.OpenForms["FRM_PERFORMANCE_DASHBOARD"];
                    if (fc != null)
                        fc.Close();

                    FRM_PERFORMANCE_DASHBOARD f = new FRM_PERFORMANCE_DASHBOARD(Caption, 1, lineInstance.Line_cd, MenuName, ComVar.Var._strValue3);
                    f.Show();
                }
                else
                {
                    ComVar.Var._Frm_Back = "140";
                    ComVar.Var._IsBack = true;
                    ComVar.Var.callForm = BtnName;
                }



            }

            catch (Exception ex)
            { ComVar.Var.writeToLog(this.Name + "/call_Form  :   " + ex.ToString()); }
        }

        void MoveLeaveClick(string MenuName, string BtnCD)
        {
            if (pic_under.Visible == true)
            {
                pic_under.SendToBack();
                pic_under.Visible = false;
            }
        }

        #endregion Menu Line Click

        /// <summary>
        /// những control ở phía trên header
        /// </summary>
        #region Menu Header
        //private void set_Header_Menu_And_Text()
        //{           
        //    lblTitle.Text = _dtnInit["frmTitle"];        
        //    cmdBack.Visible = Boolean.Parse(_dtnInit["cmdBack"]);
        //    cmdBack.FlatStyle = FlatStyle.Flat;
        //}

        private void cmdBack_Click(object sender, EventArgs e)
        {
            try
            {
                // ComVar.Var._IsBack = true;
                ComVar.Var.callForm = "back";
                //lblTitle.Text = "Digital Shop Floor For Long Thanh";
                //ComVar.Var._strValue1 = "000";
                //ComVar.Var._strValue3 = "En";
                //btnLang.BackgroundImage = Properties.Resources.enSel;


                //selectNos();

                // System.Diagnostics.Process result = System.Diagnostics.Process.GetProcessesByName("B1_DASHBOARD").FirstOrDefault();
                // SwitchToThisWindow(result.MainWindowHandle, true);
            }
            catch
            {

            }
        }

        #endregion Menu Header

        #region Timer


        #endregion Timer




        //Click Andon button 
        private void btn_WS1_Click(object sender, EventArgs e)
        {
            // string Caption = "Andon by Day";
            ComVar.Var._IsBack = true;
            ComVar.Var.callForm = "89";
        }


        private void btn_WS3_Click(object sender, EventArgs e)
        {
            //  ComVar.Var.callForm = _dtnInit["frmYear"];
            pic_under.BringToFront();
            pic_under.Visible = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (lockTimerCounterN == 0)
                {
                    int iLine = 0;
                    foreach (UserControl c in this.tblMain2.Controls)
                    {
                        UC.UC_MENU_DSF_2 MENU_WS = null;
                        MENU_WS = (UC.UC_MENU_DSF_2)c;
                        MENU_WS.changeColor();
                        MENU_WS.UpdateText(iLine);
                        
                        iLine++;

                    }
                }
            }
            catch
            {
            }
        }

        private void btn_WS3_MouseLeave(object sender, EventArgs e)
        {
            pic_under.SendToBack();
            pic_under.Visible = false;
        }
        //==============================================================================================================
        private void btn_WS2_Click(object sender, EventArgs e)
        {
            //pic_under.BringToFront();
            //pic_under.Visible = true;
            string path = _dtGMES.Rows[0]["path"].ToString();
            string str_ProcessName = _dtGMES.Rows[0]["PROCESS_NAME"].ToString();

            if (!ProgramIsRunning(path))
            //Process.Start(patch);
            {
                Process p = Process.Start(path);
                p.WaitForInputIdle();
                Thread.Sleep(2000);
                SendKeys.SendWait("1{enter}"); //VJIT{tab}
            }
            else
            {
                var ipex = Process.GetProcesses().Where(pr => pr.ProcessName == str_ProcessName);
                foreach (var process in ipex)
                {
                    //process.Kill();
                    var p = System.Diagnostics.Process.GetProcessesByName(str_ProcessName).FirstOrDefault();
                    ShowWindow(p.MainWindowHandle, SW_MAXIMIZE);
                }
                //Process.Start(patch);
                //Process p = Process.Start(@"C:/JihooSoft/JBrowser5/JBrowser5.exe");
                //p.WaitForInputIdle();
                //Thread.Sleep(2000);
                //SendKeys.SendWait("mes{tab}mes{enter}");
            }
        }

        private bool ProgramIsRunning(string FullPath)
        {
            string FilePath = Path.GetDirectoryName(FullPath);
            string FileName = Path.GetFileNameWithoutExtension(FullPath).ToLower();
            bool isRunning = false;

            Process[] pList = Process.GetProcessesByName(FileName);
            foreach (Process p in pList)
                if (p.MainModule.FileName.StartsWith(FilePath, StringComparison.InvariantCultureIgnoreCase))
                {
                    isRunning = true;
                    break;
                }

            return isRunning;
        }

        //=====================================================================================================================
        private void btn_WS2_MouseLeave(object sender, EventArgs e)
        {
            pic_under.SendToBack();
            pic_under.Visible = false;
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "Minimized";
        }
        
        private void btnLang_Click(object sender, EventArgs e)
        {
            if (ComVar.Var._strValue3 == "Vi")
            {
                btnLang.BackgroundImage = Properties.Resources.enSel;
               
                ComVar.Var._strValue3 = "En";
               foreach(UserControl c in this.tblMain2.Controls)
                    {
                    UC.UC_MENU_DSF_2 MENU_WS = (UC.UC_MENU_DSF_2)c;
                    MENU_WS.Animation("En", c);

                }

            }
            else
            {
                // btnLangClick = 1;
                btnLang.BackgroundImage = Properties.Resources.VieSel;
                ComVar.Var._strValue3 = "Vi";
                foreach (UserControl c in this.tblMain2.Controls)
                {
                    UC.UC_MENU_DSF_2 MENU_WS = (UC.UC_MENU_DSF_2)c;
                    MENU_WS.Animation("Vi", c);
                }


            }
        }

        private void cmd_EMD_MouseHover(object sender, EventArgs e)
        {
            //cmd_EMD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        }

        private void cmd_EMD_Click(object sender, EventArgs e)
        {
            pic_under.BringToFront();
            pic_under.Visible = true;
        }

        private void cmd_EMD_MouseLeave(object sender, EventArgs e)
        {

        }

        private void simpleButton29_Click(object sender, EventArgs e)
        {
            string path;
            string str_ProcessName = "FlexQuality";
            if (ComVar.Var._strValue3 == "Vi")
            {
                path = Application.StartupPath + @"\WH\IPEX_Monitor_Vn.exe";
            }
            else
            {
                path = Application.StartupPath + @"\WH\IPEX_Monitor_En.exe";
            }


            // string patch = @"C:\\Program Files\\CSI\\QCS\\FlexQuality.exe";

            if (!ProgramIsRunning(path))
                Process.Start(path);
            else
            {
                var ipex = Process.GetProcesses().
                                  Where(pr => pr.ProcessName == str_ProcessName);
                foreach (var process in ipex)
                {
                    process.Kill();
                }
                Process.Start(path);
            }

            //pic_under.BringToFront();
            //pic_under.Visible = true;
        }

        private void simpleButton29_MouseLeave(object sender, EventArgs e)
        {
            if (pic_under.Visible == true)
            {
                pic_under.SendToBack();
                pic_under.Visible = false;
            }
        }

        private void cmdQMS_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\QCS\FlexQuality.exe";
            string str_ProcessName = "FlexQuality";

            // string patch = @"C:\\Program Files\\CSI\\QCS\\FlexQuality.exe";

            if (!ProgramIsRunning(path))
                Process.Start(path);
            else
            {
                var ipex = Process.GetProcesses().
                                  Where(pr => pr.ProcessName == str_ProcessName);
                foreach (var process in ipex)
                {
                    process.Kill();
                }
                Process.Start(path);
            }
        }

        #region  Get Config Data From Database
        /// <summary>
        /// Declare _dtnInit
        /// Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        /// </summary>
        private void SetConfigForm()
        {
            try
            {
                System.Collections.Generic.Dictionary<string, string> dtnInit = new System.Collections.Generic.Dictionary<string, string>();
                dtnInit = ComVar.Func.getInitForm("NOS." + this.GetType().Assembly.GetName().Name, this.GetType().Name);

                for (int i = 0; i < dtnInit.Count; i++)
                {
                    SetComValue(dtnInit.ElementAt(i).Key, dtnInit.ElementAt(i).Value);
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setConfigForm-->Err:    " + ex.ToString());
            }
        }

        private void SetComValue(string obj, string obj_value)
        {
            try
            {
                if (obj.Contains('.'))
                {
                    string[] strSplit = obj.Split('.');
                    Control[] cnt = this.Controls.Find(strSplit[0], true);

                    if (strSplit[0] == "cmdInv6")
                    { }

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

        private void btnMoldWH_Click(object sender, EventArgs e)
        {
            ComVar.Var._Frm_Call = "3";


        }

        private void cmd_FGWH_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var.callForm = "215";
        }

        private void cmdTMS_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var.callForm = "641";
        }

        private void cmdMGL_Click(object sender, EventArgs e)
        {
            if (_IsMain)
            {
                ComVar.Var._IsBack = true;
                ComVar.Var.callForm = "3";
            }
            else
            {
                ComVar.Var.callForm = "back";
            }
        }

        private void btn_WS4_Click(object sender, EventArgs e)
        {
            //Control cnt = (Control)sender;
            //  ComVar.Var._strValue2 = getMline(cnt.Name, "000");
            if (ComVar.Var._strValue1 == "009" && ComVar.Var._strValue2 == "004")
            {
                ComVar.Var._strValue2 = "T01";
            }
            // ComVar.Var._Frm_Back = "69";

            ComVar.Var._IsBack = true;
            ComVar.Var.callForm = "189";
        }



    }
}
