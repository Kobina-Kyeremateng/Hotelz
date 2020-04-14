using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Hotelz.Winforms.Hotelz.HR.HRForms
{
    public partial class DashboardHR : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DashboardHR()
        {
            InitializeComponent();
        }

        private void barBtnAddBank_ItemClick(object sender, ItemClickEventArgs e)
        {
            var bank = new frmBank();
            bank.Show();
            bank.Activate();
        }
    }
}