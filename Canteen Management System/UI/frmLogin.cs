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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtRegistration.Text=="1234" && txtPassword.Text == "abishek")
            {
                frmAdmin admin = new frmAdmin();
                admin.Show();
            }
            else
            {
                MessageBox.Show("Please enter correct credentials");
            }

         

        }
            

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
