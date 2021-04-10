using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class FORM_MAIN_TOUCH : Form
    {
        public FORM_MAIN_TOUCH()
        {
            InitializeComponent();
         //   IPEX_Monitor.ClassLib.ComVar._Show_back_icon = false;
        }

        FORM_SMF_PROD_WH_LOCATION mold_prod = new FORM_SMF_PROD_WH_LOCATION();
        FORM_SMF_SHIP_SCHEDULE shipping_sche = new FORM_SMF_SHIP_SCHEDULE();
        FRM_DVR_FC_TRACKING_DASHBOARD delivery_tracking = new FRM_DVR_FC_TRACKING_DASHBOARD();
        FORM_SMF_FGWH_INVENOTRY inventory = new FORM_SMF_FGWH_INVENOTRY();
        FORM_INCOMING_STATUS incoming_status = new FORM_INCOMING_STATUS();
        FORM_INCOMING_STATUS_N incoming_status_N = new FORM_INCOMING_STATUS_N();
        string _frm_cur = "", _cmd_cur = "";


        #region Func
        private void initForm()
        {
            if (ComVar.Var._strValue1 == null || ComVar.Var._strValue1 == "")
            {
                DataTable dtXML = ComVar.Func.ReadXML(Application.StartupPath + "\\Config.XML", "MAIN");
                ComVar.Var._strValue1 = dtXML.Rows[0]["WH_CD"].ToString();

            }
            insert_from(mold_prod);
            if (ComVar.Var._strValue1 == "099" || ComVar.Var._strValue1 == "202" || ComVar.Var._iValue4 == 8)
                insert_from(incoming_status_N);
            else
                insert_from(incoming_status);
            insert_from(shipping_sche);
            insert_from(inventory);
            insert_from(delivery_tracking);
        }

        private void clickButton(Button arg_cmd)
        {
            if (_cmd_cur != "")
            {
                Control con = pn_footer.Controls.Find(_cmd_cur, false).FirstOrDefault();
                con.BackColor = Color.DodgerBlue;
                con.ForeColor = Color.White;
            }


            arg_cmd.BackColor = Color.Orange;
            arg_cmd.ForeColor = Color.White;

            _cmd_cur = arg_cmd.Name;
            //foreach (Control con in pn_footer.Controls)
            //{
            //    if (con.Name == arg_cmd.Name)
            //    {
            //        con.BackColor = Color.Orange;
            //        con.ForeColor = Color.White;
                    

            //    }
            //    else
            //    {
            //        con.BackColor = Color.DodgerBlue;
            //        con.ForeColor = Color.White;
            //    }
            //}
        }

        private void insert_from(Form arg_form)
        {
            try
            {
                arg_form.FormBorderStyle = FormBorderStyle.None;
                arg_form.TopLevel = false;
                arg_form.AutoScroll = false;
                arg_form.Dock = DockStyle.Fill;
                pn_main.Controls.Add(arg_form);

            }
            catch (Exception)
            {
            }
        }


        public void showform(string form_load)
        {
            try
            {
                if (_frm_cur == form_load) return;

                for (int i = 0; i < pn_main.Controls.Count; i++)
                {
                    if (pn_main.Controls[i].Name == form_load)
                    {
                        
                        pn_main.Controls[i].Show();
                       // break;
                    }
                    else
                        pn_main.Controls[i].Hide();
                }
                //for (int i = 0; i < pn_main.Controls.Count; i++)
                //{
                //    if (pn_main.Controls[i].Name == _frm_cur)
                //    {
                //        pn_main.Controls[i].Hide();
                //        break;
                //    }
                //}
                _frm_cur = form_load;

            }
            catch (Exception)
            {
            }
        }

        private void GoFullscreen(bool fullscreen)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;

            }
            catch
            { }
        }

        #endregion Func

        #region Event
        private void Form_Main_Touch_Load(object sender, EventArgs e)
        {
           // Com_Base.Variables.Master = Com_Base.Functions.Init_Computer(AppDomain.CurrentDomain.BaseDirectory + "App.xml", "master");
            FORM.Var._Show_back_icon = ComVar.Var._IsBack;
           // GoFullscreen(true);
            initForm();
            cmd_incoming_status_Click(cmd_incoming_status, null);
        }

        private void cmd_wh_location_Click(object sender, EventArgs e)
        {
            clickButton(cmd_wh_location);
            showform("FORM_SMF_PROD_WH_LOCATION");
        }

        private void cmd_shipping_sche_Click(object sender, EventArgs e)
        {
            clickButton(cmd_shipping_sche);
            showform("FORM_SMF_SHIP_SCHEDULE");
        }

        private void cmd_Inventory_Click(object sender, EventArgs e)
        {
            clickButton(cmd_Inventory);
            showform("FORM_SMF_FGWH_INVENOTRY");
        }

        private void cmd_Delivery_Click(object sender, EventArgs e)
        {

            clickButton(cmd_Delivery);
            showform("FRM_DVR_FC_TRACKING_DASHBOARD");
        }

        private void cmd_incoming_status_Click(object sender, EventArgs e)
        {
            clickButton(cmd_incoming_status);
            if (ComVar.Var._strValue1 == "099" || ComVar.Var._iValue4 == 8)
                showform("FORM_INCOMING_STATUS_N");
            else
                showform("FORM_INCOMING_STATUS");

        }

        #endregion Event

        private void pn_main_Layout(object sender, LayoutEventArgs e)
        {
            if (Var._Form_status)
            {
                cmd_wh_location_Click(cmd_wh_location, null);
               // clickButton(cmd_wh_location);
               // IPEX_Monitor.ClassLib.ComVar._Type_form = "FORM_SMF_PROD_WH_LOCATION";
            }
        }

        

        

        

        

        
    }
}
