using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM.UC
{
    public partial class UC_CHART : UserControl
    {
        public UC_CHART(string title)
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
                
            }
            catch { }
        }

        
    }
}
