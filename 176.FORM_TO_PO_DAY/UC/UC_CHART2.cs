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
    public partial class UC_CHART2 : UserControl
    {
        public UC_CHART2(string title)
        {
            InitializeComponent();
            Chart1.Titles[0].Text = title;
        }

        internal void BindingData(DataTable dtchart, string p)
        {
            Chart1.DataSource = dtchart;
            Chart1.Series[0].ArgumentDataMember = "DEPT_NM";
            Chart1.Series[0].ValueDataMembers.AddRange(new string[] { "PO" });
        }
    }
}
