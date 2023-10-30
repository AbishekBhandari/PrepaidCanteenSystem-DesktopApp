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
    public partial class ViewAllSales : Form
    {
        public ViewAllSales()
        {
            InitializeComponent();
        }

        private void ViewAllSales_Load(object sender, EventArgs e)
        {

            string myconnStrng = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
            SqlConnection conn = new SqlConnection(myconnStrng);
            conn.Open();
            string sql = "Select * from Sales";
            SqlCommand command = new SqlCommand(sql, conn);
            

                   SqlDataReader reader = command.ExecuteReader();
            decimal total = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    SalesGridView.Rows.Add(reader["ID"].ToString(), reader["CustomerName"].ToString(), reader["Total"].ToString(), reader["Time"].ToString());
                    total = total + Convert.ToDecimal(reader["Total"]);

                }
            }
            reader.Close();
            TotalBox.Text = total.ToString();



        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            string myconnStrng = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
            SqlConnection conn = new SqlConnection(myconnStrng);
            conn.Open();
            string sql = "Select * from Sales where Time between @fromDate and @toDate";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@fromDate",FromDate.Value);
            command.Parameters.AddWithValue("@toDate",ToDate.Value);
            SqlDataReader reader = command.ExecuteReader();
            decimal total = 0;
            SalesGridView.Rows.Clear();
            if (reader.HasRows)
            {
               
                while (reader.Read())
                {

                    SalesGridView.Rows.Add(reader["ID"].ToString(), reader["CustomerName"].ToString(), reader["Total"].ToString(), reader["Time"].ToString());
                    total = total + Convert.ToDecimal(reader["Total"]);

                }
            }
            reader.Close();
            TotalBox.Text = total.ToString();
        }
    }
}
