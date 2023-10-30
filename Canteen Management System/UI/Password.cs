using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canteen_Management_System.UI
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordButton_Click(object sender, EventArgs e)
        {
            string registration = RegistrationBox1.Text;
            string current = CurrentBox.Text;
            string new1 = NewBox.Text;
            string myconnstrng = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

            SqlConnection conn = new SqlConnection(myconnstrng);
            conn.Open();
            string sql = "Select Password from Users where RegistrationNumber=@number ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@number", registration);
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            if(rd["Password"].ToString() == current)
            {
                rd.Close();
                string sql1 = "Update Users set Password=@password where RegistrationNUmber=@registration";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@registration", registration);
                cmd1.Parameters.AddWithValue("@password", new1);
                int rows = cmd1.ExecuteNonQuery();
                if (rows > 0)
                {
                    this.Close();
                    MessageBox.Show("Password Changed");
                }
                else
                {
                    this.Close();
                    MessageBox.Show("Failed To Change");
                }
            }
            else
            {
                MessageBox.Show("Current Password Incorrect");
            }

        }
    }
}
