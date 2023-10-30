using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canteen_Management_System.UI
{
    public partial class Login : Form
    {
        MyConnection db = new MyConnection();
        public Login()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {

            DataAccess da = new DataAccess();
            bool state = da.Login(EmailBox.Text,PasswordBox.Text);
            if(state == true)
            {
              
                frmMenu menu = new frmMenu();
                menu.Show();
                
            }
            else
            {
                MessageBox.Show("Please login to continue");
            }
           
        }
    }
}
