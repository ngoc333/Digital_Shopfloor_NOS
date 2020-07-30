using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace FORM.UC
{
    public partial class UC_CHART_TOTAL : UserControl
    {
        public UC_CHART_TOTAL(string title)
        {
            InitializeComponent();
            Chart1.Titles[0].Text = title;
        }


        private void load_chart()
        {
            //chartTitle1.Text = "1233";
            Chart1.Titles[0].Text = "123456";
        }

        public void BindingData(DataTable dt, string title)
        {
            try
            {
                
                Chart1.DataSource = dt;
                Chart1.Series[0].ArgumentDataMember = "DIV";
                Chart1.Series[0].ValueDataMembers.AddRange(new string[] { title+"_TO" });

                Chart1.Series[1].ArgumentDataMember = "DIV";
                Chart1.Series[1].ValueDataMembers.AddRange(new string[] { title + "_PO" });

                //if (title.Equals("TOTAL"))
                //{
                //    Chart1.BackColor = Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(213)))), ((int)(((byte)(181)))));
                //    Chart1.Legend.BackColor = Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(213)))), ((int)(((byte)(181)))));
                //    ((XYDiagram)Chart1.Diagram).DefaultPane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(213)))), ((int)(((byte)(181)))));
                //}
                
            }
            catch { }
        }

        
    }
}
