using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerqTime.EasyTimeZone
{
    public partial class frmTimeByZone : Form
    {
        public frmTimeByZone()
        {
            InitializeComponent();
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            TimeZoneInfo destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(cbTimeZone.SelectedItem.ToString());
            DateTime destinationTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, destinationTimeZone);
            txtTime.Text = destinationTime.ToString();
        }

        private void frmTimeByZone_Load(object sender, EventArgs e)
        {
            foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
            {
                cbTimeZone.Items.Add(z.Id);
            }
            cbTimeZone.SelectedItem = TimeZoneInfo.Local.StandardName; //  TimeZone.CurrentTimeZone.StandardName also works.
            tmrTime.Start();
        }
    }
}
