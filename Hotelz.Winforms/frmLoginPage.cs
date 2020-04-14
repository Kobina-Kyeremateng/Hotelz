using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Hotelz.Winforms.Hotelz.HR;
using Hotelz.Winforms.Hotelz.HR.HRForms;

namespace Hotelz.Winforms
{
    public partial class frmLoginPage : DevExpress.XtraEditors.XtraForm
    {
        public frmLoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DashboardHR dh = new DashboardHR();
            dh.Show();
        }
    }
}