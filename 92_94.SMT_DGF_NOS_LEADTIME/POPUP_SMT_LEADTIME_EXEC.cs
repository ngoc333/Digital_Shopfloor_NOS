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
    public partial class POPUP_SMT_LEADTIME_EXEC : Form
    {
        public POPUP_SMT_LEADTIME_EXEC()
        {
            InitializeComponent();
        }

        public bool rtnStatus = false;
        public DataTable _dt;
        public string _wh_cd, _mline_cd;

        private DataTable EXEC_DATA()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_SMT_PROD_SHOW.SEL_EXEC_LEAD_TIME";
                //ARGMODE
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_WH_CD";
                MyOraDB.Parameter_Name[1] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = _wh_cd;
                MyOraDB.Parameter_Values[1] = _mline_cd;
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

        private void POPUP_SMT_LEADTIME_EXEC_Load(object sender, EventArgs e)
        {
            rtnStatus = true;
            try
            {
                _dt = EXEC_DATA();
                this.Close();
            }
            catch (Exception)
            {
                _dt = null;
            }
            
        }
    }
}
