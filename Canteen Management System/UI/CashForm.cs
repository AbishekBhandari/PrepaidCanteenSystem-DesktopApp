using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canteen_Management_System.UI
{
    public partial class CashForm : Form
    {
        public CashForm()
        {
            InitializeComponent();
        }

        private void CurrentBalanceBox_TextChanged(object sender, EventArgs e)
        {
            RemainingBalanceBox.Text = (Convert.ToDecimal(CurrentBalanceBox.Text) - Convert.ToDecimal(TotalBillBox.Text)).ToString();
        }
    }
}
