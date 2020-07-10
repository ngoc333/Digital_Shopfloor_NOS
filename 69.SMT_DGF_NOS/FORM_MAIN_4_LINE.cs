using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace FORM
{
    public partial class FORM_MAIN_4_LINE : Form
    {

        /// <summary>
        /// ComVar.Var._strValue1 : Line Code
        /// ComVar.Var._strValue2 : Mini Line Code
        /// ComVar.Var._strValue3 : Language
        /// ComVar.Var._strValue4 : Line Name
        /// ComVar.Var._Frm_Call :
        /// </summary>
        public FORM_MAIN_4_LINE()
        {
            InitializeComponent();
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }




        #region Global Variant
        //int _iStartText = 0;

        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool turnon);

        //bool bSetTopFrom = true;
        // Form_SMT_NPI frm_npi = null;
        //init strline = new init();

        readonly MODEL_LINE lineInstance = new MODEL_LINE(); 
        //MAIN_PRODUCTION_RESULT _Popup_Production = new MAIN_PRODUCTION_RESULT();


        private const int SW_MAXIMIZE = 3;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int AW_SLIDE = 0X40000;
        //const int AW_HOR_POSITIVE = 0X4;
        //const int AW_HOR_NEGATIVE = 0X2;
        //const int AW_BLEND = 0X80000;
        //const int AW_HIDE = 0x00010000;
        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);

        DataTable _dtGMES = null, _dtModel = null;
        int cCount = 0;
        DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge[] _arrGaugeText;
        readonly int[] _arrNumText = {0, 0, 0, 0} ;
        private string _Lang = "En";
      //  string _Line = "";
        bool _IsMain = true;
        bool _FirstFrom = false;
       // Dictionary<string, string> _dtnInit = new Dictionary<string, string>();

        #endregion


        #region Load/Visible/Timer
        private void  FORM_MAIN_Load(object sender, EventArgs e)
        {
            _arrGaugeText = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge[4];
            _arrGaugeText[0] = digitalGaugeLine1;
            _arrGaugeText[1] = digitalGaugeLine2;
            _arrGaugeText[2] = digitalGaugeLine3;
            _arrGaugeText[3] = digitalGaugeLine4;
            if (ComVar.Var._Frm_Back == null || ComVar.Var._Frm_Back == "")
            {
                ComVar.Var._bValue5 = true;
                _FirstFrom = true;
                ComVar.Var._strValue3 = "En";
                bstLine1_Qual.Selected = true;
                bstLine2_Qual.Selected = true;
                bstLine3_Qual.Selected = true;
                bstLine4_Qual.Selected = true;

                

                //_IsMain = true;
              //  formFullScreen();
                getConfigInfor();
                //setConfigForm();
                //initDefault();

                //loadLinePicture();
                //digitalGaugeLine1.Text = "";
                //digitalGaugeLine2.Text = "";
                //digitalGaugeLine3.Text = "";
                //digitalGaugeLine4.Text = "";
                
            }
            else
                ComVar.Var._bValue5 = false;
            
           // tmrText.Enabled = true;
           // cmdMGL.Visible = false;
        }

        private void HOMEPAGE_V4_VN_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                

                
                if (ComVar.Var._IsBack)
                {
                    _IsMain = false;         
                    
                }
                else _IsMain = true;

                

               // getConfigInfor();
                setConfigForm();
                initDataModel();
                loadLinePicture();
                digitalGaugeLine1.Text = "";
                digitalGaugeLine2.Text = "";
                digitalGaugeLine3.Text = "";
                digitalGaugeLine4.Text = "";
                _arrNumText[0] = 0;
                _arrNumText[1] = 0;
                _arrNumText[2] = 0;
                _arrNumText[3] = 0;
                cCount = 58;

                if (_FirstFrom && ComVar.Var._strValue1 == "014") cmdEMD.Visible = true;
                else cmdEMD.Visible = false;

                tmrText.Start();
                tmrDate.Start();
            }
            else
            {
               // ComVar.Var._strValue1 = _Line;
                tmrText.Stop();
                tmrDate.Stop();
                _IsMain = ComVar.Var._bValue5;
            }
        }


        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            BlindRateColor();

            if (cCount >= 60)
            {
                bindingDataLabel();
                setRateColor();
                cCount = 0;
            }
        }

        private void tmrText_Tick(object sender, EventArgs e)
        {
            runTextModel();
        }

        #endregion

        #region DB
        public DataTable SEL_MODEL_NAME(string ARG_QTYPE)
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
                MyOraDB.Parameter_Values[1] =  ComVar.Var._strValue1;
                MyOraDB.Parameter_Values[2] = ComVar.Var._Area == "NOS_L2." ? (1 + Convert.ToInt16("004")).ToString("000") : ComVar.Var._strValue2;
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

        private DataTable SEL_PROD_MDI()
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PHUOC.SP_SMT_PROD_MDI";

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[1] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ComVar.Var._strValue1;
                MyOraDB.Parameter_Values[1] = ComVar.Var._Area == "NOS_L2." ? (1 + Convert.ToInt16("004")).ToString("000") : ComVar.Var._strValue2;
                MyOraDB.Parameter_Values[2] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->DB-->SEL_PROD_MDI -->Err: " + ex.ToString());
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
                MyOraDB.Parameter_Values[1] = ComVar.Var._Area == "NOS_L2." ? ComVar.Var._strValue1 + "_2" : ComVar.Var._strValue1;
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

        #endregion DB

        #region Function

        

        private void initDataModel()
        {
            try
            {
                

                _dtModel = SEL_MODEL_NAME("Q");

                if (ComVar.Var._strValue1 == "009" )
                    groupBox4.Text = "T Line";
                else if (ComVar.Var._Area == "NOS_L2.")
                {
                    groupBox1.Text = "Line 5";
                    groupBox2.Text = "Line 6";
                    groupBox3.Text = "Line 7";
                    groupBox4.Text = "Line 8";
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->initDefault-->Err: " + ex.ToString());
            }
            

        }
    
        //private void formFullScreen()
        //{
        //    this.WindowState = FormWindowState.Normal;
        //    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        //    this.Bounds = Screen.PrimaryScreen.Bounds;
        //}

        private void bindingDataLabel()
        {
            try
            {
                DataTable dt = SEL_PROD_MDI();
                if (dt != null && dt.Rows.Count > 0)
                {
                    int iArr = 0;
                    Control[] lbl = new Control[] {
                        lblPlan_Line1,lblRPlan_Line1, lblProd_line1,lblRate_line1,
                        lblPlan_Line2,lblRPlan_Line2,lblProd_line2,lblRate_line2,
                        lblPlan_Line3,lblRPlan_Line3,lblProd_line3,lblRate_line3,
                        lblPlan_Line4,lblRPlan_Line4,lblProd_line4,lblRate_line4,
                    };
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 1; j < dt.Columns.Count; j++)
                        {

                            lbl[iArr].Text = dt.Rows[i][j].ToString();
                            iArr++;
                        }
                    }


                }

                setRateColor();
            }
            catch (Exception ex)
            { 
                ComVar.Var.writeToLog( this.GetType().Name + "-->BindingDataLabel -->Err: " + ex.ToString());
            }
        }

        private void getConfigInfor()
        {
            try
            {
              //  _Line = ComVar.Var._strValue1;
                if (_IsMain)
                {
                    //_dtXML = ComVar.Func.ReadXML(Application.StartupPath + @"\Config.xml", this.GetType().Name);
                   // _dtQMS = ComVar.Func.ReadXML(Application.StartupPath + @"\Config.xml", "QMS");
                    _dtGMES = ComVar.Func.ReadXML(Application.StartupPath + @"\Config.xml", "GMES");

                    CXMLConfig conFig = new CXMLConfig(Application.StartupPath + @"\Config.xml");
                    lineInstance.Line_cd = conFig.XmlReadValue("LINE_CD");
                    ComVar.Var._strValue1 = conFig.XmlReadValue("LINE_CD");
                    lineInstance.Line_Name = conFig.XmlReadValue("LINE_NAME");
                    ComVar.Var._strValue4 = conFig.XmlReadValue("LINE_NAME");
                    //lineInstance.NumberMline = Convert.ToInt32(conFig.XmlReadValue("NUMBER_MLINE"));
                    //for (int indexMLine = 1; indexMLine <= lineInstance.NumberMline; indexMLine++)
                    //{
                    //    lineInstance.setMLineName(indexMLine.ToString("000"), conFig.XmlReadValue("MLINE_CD_" + indexMLine, "NAME"));
                    //    lineInstance.setMLinePicture(indexMLine.ToString("000"), conFig.XmlReadValue("MLINE_CD_" + indexMLine, "PICTURE"));
                    //}
                    lineInstance.buttonVisibleConfig = conFig.XmlReadValue("MENU_BUTTON");
                    lineInstance.setButtonVisibleConfig();
                    Button[] arrButton = new Button[10];
                    arrButton[0] = cmdSmartAndon;
                    arrButton[1] = cmdGMES;
                    arrButton[2] = cmdCMMS;
                    arrButton[3] = cmdFEMS;
                    arrButton[4] = cmdQMS;
                    arrButton[5] = cmdMGL;
                    arrButton[6] = cmdEMD;
                    for (int i = 0; i < lineInstance.getNumberButton(); i++)
                    {
                        if (arrButton[i] != null)
                        {
                            arrButton[i].Visible = lineInstance.getButtonVisible(i);
                        }
                    }
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->getConfigInfor-->Err: " + ex.ToString());
            }          
        }

        private void loadLinePicture()
        {
            try
            {
                picLine01.BackgroundImage = null;
                picLine02.BackgroundImage = null;
                picLine03.BackgroundImage = null;
                picLine04.BackgroundImage = null;

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


        #region Set Color Production Rate and Blink
        private void setRateColor()
        {
            colorLabelbyVal(lblRate_line1);
            colorLabelbyVal(lblRate_line2);
            colorLabelbyVal(lblRate_line3);
            colorLabelbyVal(lblRate_line4);
        }

        private void colorLabelbyVal(Label lbl)
        {
            double val = Convert.ToDouble(lbl.Text.ToString().Replace("%", ""));
            if (val < 95)
            {
                lbl.BackColor = Color.Red;
                lbl.ForeColor = Color.White;
            }
            else if (val < 98)
            {
                lbl.BackColor = Color.Yellow;
                lbl.ForeColor = Color.Black;
            }
            else
            {
                lbl.BackColor = Color.Green;
                lbl.ForeColor = Color.Black;
            }

        }

        private void BlindRateColor()
        {
            BlindLabelbyVal(lblRate_line1);
            BlindLabelbyVal(lblRate_line2);
            BlindLabelbyVal(lblRate_line3);
            BlindLabelbyVal(lblRate_line4);
        }

        private void BlindLabelbyVal(Label lbl)
        {
            double val = Convert.ToDouble(lbl.Text.ToString().Replace("%", ""));
            if (val < 95)
            {
                if (lbl.BackColor == Color.Black)
                {
                    lbl.BackColor = Color.Red;
                    lbl.ForeColor = Color.White;
                }
                else
                {
                    lbl.BackColor = Color.Black;
                    lbl.ForeColor = Color.White;
                }

            }
            else if (val < 98)
            {
                if (lbl.BackColor == Color.Black)
                {
                    lbl.BackColor = Color.Yellow;
                    lbl.ForeColor = Color.Black;
                }
                else
                {
                    lbl.BackColor = Color.Black;
                    lbl.ForeColor = Color.White;
                }
            }
        }
        #endregion

        #region Run Text Model
        private void runTextModel()
        {
            try
            {
                for (int i = 0; i < _dtModel.Rows.Count; i++)
                {
                    int.TryParse(_dtModel.Rows[i]["LINE"].ToString(), out int iNum);
                    addTextGauge(_dtModel.Rows[i]["MODEL"].ToString(), _arrGaugeText[iNum - 1], i);
                    _arrNumText[i] = _arrNumText[i] + 1;
                }

                // addTextGauge(_dtModel.Rows[0]["MODEL"].ToString(), _arrGaugeText[0]);

            }
            catch (Exception ex )
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->runTextModel-->Err: " + ex.ToString());
            }
            
        }
        private void addTextGauge(string arg_str, DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge gauge, int arg_i)
        {
            try
            {
                if (arg_str.Length < 25)
                {
                    arg_str = arg_str.PadRight(25, ' ');
                }

                if (_arrNumText[arg_i] + 1 > arg_str.Length)
                {
                    _arrNumText[arg_i] = 0;
                    gauge.Text += "    ";
                }

                gauge.Text += arg_str.Substring(_arrNumText[arg_i], 1);
            }
            catch (Exception ex )
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->addTextGauge-->Err: " + ex.ToString());
            }

            
        }

        #endregion 

        //Set Language Change
        private void Animation(string Qtype, Control Grid)
        {
            string[] EN = new string[] { "Quality", "Production", "Equipment", "Inventory", "Human Resource",
                                          "Quality", "Production", "Equipment", "Inventory", "Human Resource",
                                           "Quality", "Production", "Equipment", "Inventory", "Human Resource",
                                             "Quality", "Production", "Equipment", "Inventory", "Human Resource"};
            string[] VIE = new string[] { "Chất lượng", "Sản Xuất", "Thiết bị", "Tồn kho", "Nguồn nhân lực",
                                          "Chất lượng", "Sản Xuất", "Thiết bị", "Tồn kho", "Nguồn nhân lực",
                                          "Chất lượng", "Sản Xuất", "Thiết bị", "Tồn kho", "Nguồn nhân lực",
                                          "Chất lượng", "Sản Xuất", "Thiết bị", "Tồn kho", "Nguồn nhân lực"};
            string[] GbEx_VIE = new string[] { "Tình trạng sản xuất", "Tình trạng sản xuất", "Tình trạng sản xuất", "Tình trạng sản xuất" };
            string[] GbEx_EN = new string[] { "Production Status", "Production Status", "Production Status", "Production Status" };

            string[] btn_VIE = new string[]{
            "PFC",
            "NPI",
            "Tỉ Lệ Chất Lượng",
            "Hàng Hư Trả Về",
            "Chất Lượng Thị Trường",
            "Kết Quả Sản Xuất",
            "Năng Suất",
            "BTS",
            "Lead Time",
            "Tồn Kho Thành Phẩm",
            "Vắng Mặt",
            "Đa Kỹ Năng",
            "Tỉ lệ ĐKN",
            "PFC",
            "NPI",
            "Tỉ Lệ Chất Lượng",
            "Hàng Hư Trả Về",
            "Chất Lượng Thị Trường",
            "Kết Quả Sản Xuất",
            "Năng Suất",
            "BTS",
            "Lead Time",
            "Tồn Kho Thành Phẩm",
            "Vắng Mặt",
            "Đa Kỹ Năng",
            "Tỉ lệ ĐKN",
               "PFC",
            "NPI",
            "Tỉ Lệ Chất Lượng",
            "Hàng Hư Trả Về",
            "Chất Lượng Thị Trường",
            "Kết Quả Sản Xuất",
            "Năng Suất",
            "BTS",
            "Lead Time",
            "Tồn Kho Thành Phẩm",
            "Vắng Mặt",
            "Đa Kỹ Năng",
            "Tỉ lệ ĐKN",
           "PFC",
            "NPI",
            "Tỉ Lệ Chất Lượng",
            "Hàng Hư Trả Về",
            "Chất Lượng Thị Trường",
            "Kết Quả Sản Xuất",
            "Năng Suất",
            "BTS",
            "Lead Time",
            "Tồn Kho Thành Phẩm",
            "Vắng Mặt",
            "Đa Kỹ Năng",
            "Tỉ lệ ĐKN"

            };
            string[] btn_EN = new string[]{
            "PFC",
            "NPI",
            "Quality Rate",
            "External OS&&D",
            "Market Quality",
            "Prod. Result",
            "Productivity",
            "BTS",
            "Lead Time",
            "FG Inventory",
            "Absenteeism",
            "Multi Skill",
            "Multi Skill Ratio",
            "PFC",
            "NPI",
            "Quality Rate",
            "External OS&&D",
            "Market Quality",
            "Prod. Result",
            "Productivity",
            "BTS",
            "Lead Time",
            "FG Inventory",
            "Absenteeism",
            "Multi Skill",
            "Multi Skill Ratio",
            "PFC",
            "NPI",
            "Quality Rate",
            "External OS&&D",
            "Market Quality",
            "Prod. Result",
            "Productivity",
            "BTS",
            "Lead Time",
            "FG Inventory",
            "Absenteeism",
            "Multi Skill",
            "Multi Skill Ratio",
            "PFC",
            "NPI",
            "Quality Rate",
            "External OS&&D",
            "Market Quality",
            "Prod. Result",
            "Productivity",
            "BTS",
            "Lead Time",
            "FG Inventory",
            "Absenteeism",
            "Multi Skill",
            "Multi Skill Ratio"
            };

            DevExpress.XtraEditors.SimpleButton[] btn = new DevExpress.XtraEditors.SimpleButton[] { 
            cmdQua1_Line1,cmdQua2_Line1,cmdQua3_Line1,cmdQua4_Line1,cmdQua5_Line1,cmdPro1_Line1,cmdPro2_Line1,cmdPro3_Line1,cmdInv1_Line1,cmdInv2_Line1,cmdHrm1_Line1,cmdHrm2_Line1,cmdHrm3_Line1,
cmdQua1_Line2,cmdQua2_Line2,cmdQua3_Line2,cmdQua4_Line2,cmdQua5_Line2,cmdPro1_Line2,cmdPro2_Line2,cmdPro3_Line2,cmdInv1_Line2,cmdInv2_Line2,cmdHrm1_Line2,cmdHrm2_Line2,cmdHrm3_Line2 ,cmdQua1_Line3,cmdQua2_Line3,cmdQua3_Line3,cmdQua4_Line3,cmdQua5_Line3,cmdPro1_Line3,cmdPro2_Line3,cmdPro3_Line3,cmdInv1_Line3,cmdInv2_Line3,cmdHrm1_Line3,cmdHrm2_Line3,cmdHrm3_Line3 ,cmdQua1_Line4,cmdQua2_Line4,cmdQua3_Line4,cmdQua4_Line4,cmdQua5_Line4,cmdPro1_Line4,cmdPro2_Line4,cmdPro3_Line4,cmdInv1_Line4,cmdInv2_Line4,cmdHrm1_Line4,cmdHrm2_Line4 ,cmdHrm3_Line4         
            };
            DevExpress.XtraBars.Ribbon.BackstageViewTabItem[] tabItem = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem[]
            {
                bstLine1_Qual,bstLine1_Prod,bstLine1_Equip,bstLine1_Inventory, bstLine1_HR,
                bstLine2_Qual,bstLine2_Prod,bstLine2_Equip,bstLine2_Inventory,bstLine2_HR,
                bstLine3_Qual,bstLine3_Prod,bstLine3_Equip,bstLine3_Inventory,bstLine3_HR,
                bstLine4_Qual,bstLine4_Prod,bstLine4_Equip,bstLine4_Inventory,bstLine4_HR
            };
            ClassLib.GroupBoxEx[] gbEX = new ClassLib.GroupBoxEx[] { gbExLine1, groupBoxEx1, groupBoxEx2, groupBoxEx3 };
            Grid.Hide();
            this.Cursor = Cursors.WaitCursor;
            AnimateWindow(Grid.Handle, 400, AW_SLIDE | 0X4); //IPEX_Monitor.ClassLib.WinAPI.getSlidType("2")
            //BindingGrid(dt);
            switch (Qtype)
            {
                case "Vn":
                    for (int i = 0; i < tabItem.Length; i++)
                    {
                        tabItem[i].Caption = VIE[i];
                    }
                    for (int j = 0; j < gbEX.Length; j++)
                    {
                        gbEX[j].Text = GbEx_VIE[j];
                    }
                    for (int k = 0; k < btn.Length; k++)
                    {
                        btn[k].Text = btn_VIE[k];
                    }
                    break;
                default:
                    for (int i = 0; i < tabItem.Length; i++)
                    {
                        tabItem[i].Caption = EN[i];
                    }
                    for (int j = 0; j < gbEX.Length; j++)
                    {
                        gbEX[j].Text = GbEx_EN[j];
                    }
                    for (int k = 0; k < btn.Length; k++)
                    {
                        btn[k].Text = btn_EN[k];
                    }
                    break;
               
            }


            Grid.Show();
            this.Cursor = Cursors.Default;

        }

        private string getMline(string argButtonName, string argFormat)
        {
            try
            {
                 

                string[] str = argButtonName.Split('_');
                if (ComVar.Var._Area == "NOS_L2.")
                    if (argFormat == "000")
                        return (Convert.ToInt16(str[1].Replace("Line", "")) + 4).ToString().PadLeft(3, '0');
                    else
                        return (Convert.ToInt16(str[1].Replace("Line", "")) + 4).ToString().Replace("Line", "");
                else
                    if (argFormat == "000")
                        return str[1].Replace("Line", "").PadLeft(3, '0');
                    else
                        return str[1].Replace("Line","");
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->getMline-->" + argButtonName + " -->Err: " + ex.ToString());
                return "";
            }
            
        }


        //Check program Running
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
               // dtnInit = ComVar.Func.getInitForm(ComVar.Var._Area + this.GetType().Assembly.GetName().Name, this.GetType().Name);
               if (_IsMain)
                    dtnInit = ComVar.Func.getInitForm(ComVar.Var._Area + this.GetType().Assembly.GetName().Name, this.GetType().Name);
                else
                {
                    switch (ComVar.Var._strValue1)
                    {
                        case "018":
                            dtnInit = ComVar.Func.getInitForm("NOS_L." + this.GetType().Assembly.GetName().Name, this.GetType().Name);
                            break;
                        default:
                            dtnInit = ComVar.Func.getInitForm("NOS." + this.GetType().Assembly.GetName().Name, this.GetType().Name);
                            break;
                    }
                }
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
      
        #endregion

        #region Event

        //Open GMES Program
        private void cmdGMESProgram_Click(object sender, EventArgs e)
        {
            try
            {
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
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->FORM_MAIN-Load-->Err: " + ex.ToString());
            }
        }

        //Open QMS Program
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

        //Click Button PFC
        private void cmdPFC_Click(object sender, EventArgs e)
        {
            string strLine = getMline(((Control)sender).Name,"");
            if (!Directory.Exists(@"C:\\PFC_LINE" + strLine))
            {
                DialogResult dl = MessageBox.Show(this, "Can't find this folder, would you like to create folder PFC (Không tìm thấy thư mục PFC, Tạo            mới?)", "Warring!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                    Directory.CreateDirectory(@"C:\\PFC_LINE" + strLine);
            }

            OpenFileDialog theDialog = new OpenFileDialog
            {
                Title = "Open PFC File",
                Filter = "PDF files|*.pdf",
                InitialDirectory = @"C:\PFC_LINE" + strLine
            };

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                if (!theDialog.FileName.ToString().Equals(""))
                {
                    var process = new System.Diagnostics.Process
                    {
                        StartInfo = new System.Diagnostics.ProcessStartInfo(theDialog.FileName)
                    };
                    process.Start();
                }
            }
        }

        //Click En-Vi
        private void btnLang_Click(object sender, EventArgs e)
        {
            if (_Lang == "En")
            {
                _Lang = "Vn";
                ComVar.Var._strValue3 = "Vn";
                btnLang.BackgroundImage = Properties.Resources.VieSel;
                bstLine1_HR.Appearance.Font = new Font("Tahoma", 23, FontStyle.Bold);
                bstLine2_HR.Appearance.Font = new Font("Tahoma", 23, FontStyle.Bold);
                bstLine3_HR.Appearance.Font = new Font("Tahoma", 23, FontStyle.Bold);
                bstLine4_HR.Appearance.Font = new Font("Tahoma", 23, FontStyle.Bold);
                Animation("Vn", backstageViewControl1);
                Animation("Vn", backstageViewControl2);
                Animation("Vn", backstageViewControl3);
                Animation("Vn", backstageViewControl4);

            }
            else
            {               
                btnLang.BackgroundImage = Properties.Resources.enSel;                
                _Lang = "En";
                ComVar.Var._strValue3 = "En";
                bstLine1_HR.Appearance.Font = new Font("Tahoma", 22, FontStyle.Bold);
                bstLine2_HR.Appearance.Font = new Font("Tahoma", 22, FontStyle.Bold);
                bstLine3_HR.Appearance.Font = new Font("Tahoma", 22, FontStyle.Bold);
                bstLine4_HR.Appearance.Font = new Font("Tahoma", 22, FontStyle.Bold);
                Animation("En", backstageViewControl1);
                Animation("En", backstageViewControl2);
                Animation("En", backstageViewControl3);
                Animation("En", backstageViewControl4);              
            }

            bstLine1_Qual.Selected = true;
            bstLine2_Qual.Selected = true;
            bstLine3_Qual.Selected = true;
            bstLine4_Qual.Selected = true;
            
        }

        //Menu Click
        
        private void cmdMenu_Click(object sender, EventArgs e)
        {
            
            Control cnt = (Control)sender;

            ComVar.Var._strValue2 = getMline(cnt.Name, "000");

            if ((ComVar.Var._strValue1 == "009" && ComVar.Var._strValue2 == "004") || ComVar.Var._strValue2 == "T01")
                ComVar.Var._strValue2 = "T01";

            // ComVar.Var._Frm_Back = "69";

            ComVar.Var._IsBack = true;
            ComVar.Var.callForm = cnt.Tag == null ? "" : cnt.Tag.ToString();
           
           // ComVar.Var.callForm = "back";
        }
        private void cmdFGWH_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var.callForm = "215";
            /*
            string path;
            string str_ProcessName = "IPEX_Monitor";
            if (ComVar.Var._strValue3 == "Vi")
            {
                path = Application.StartupPath + @"\WH\IPEX_Monitor_Vn.exe";
            }
            else
            {
                path = Application.StartupPath + @"\WH\IPEX_Monitor_En.exe";
            }

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
            */
        }

        #endregion Event

        private void gaugeText_Click(object sender, EventArgs e)
        {
            try
            {
                Form fc = Application.OpenForms["FRM_MODEL_DETAIL_LW"];
                if (fc != null)
                    fc.Close();
                FRM_MODEL_DETAIL_LW f = new FRM_MODEL_DETAIL_LW(ComVar.Var._strValue1, ((Control)sender).Tag.ToString());

                f.ShowDialog();
            }
            catch
            {}
            
        }

        private void cmdQuaPer_Click(object sender, EventArgs e)
        {
            string Caption;
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

            FRM_PERFORMANCE_DASHBOARD f = new FRM_PERFORMANCE_DASHBOARD(Caption, lineInstance.Line_cd, ((Control)sender).Tag.ToString(), ComVar.Var._strValue3);
            f.Show();
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            if (_FirstFrom) Application.Exit();
        }

        private void cmdMGL_Click(object sender, EventArgs e)
        {
            if (_FirstFrom)
            {
                
                switch (ComVar.Var._strValue1)
                {
                    case "001":
                    case "002":
                    case "003":
                    case "004":
                    case "005":
                    case "006":
                        ComVar.Var._IsBack = true;
                        ComVar.Var.callForm = "5";
                        break;
                    case "007":
                    case "008":
                    case "010":
                        ComVar.Var._IsBack = true;
                        ComVar.Var.callForm = "4";
                        break;
                    case "011":
                    case "012":
                    case "099":
                        ComVar.Var._IsBack = true;
                        ComVar.Var.callForm = "3";
                        break;
                    case "009":
                    case "013":
                    case "014":
                    case "015":
                    case "016":
                    case "017":
                        ComVar.Var._IsBack = true;
                        ComVar.Var.callForm = "2";
                        break;
                    case "018":
                        ComVar.Var._IsBack = true;
                        ComVar.Var.callForm = "204";
                        break;
                }
            }
            else
            {
                ComVar.Var.callForm = "back";
            }
        }

        private void cmdEMD_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var._bValue1 = true;
            ComVar.Var.callForm = "1";
        }

        

        

        





    }
}
