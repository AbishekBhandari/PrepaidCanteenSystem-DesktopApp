using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canteen_Management_System.UI
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        RegisterClass c = new RegisterClass();


        private void AddButton_Click(object sender, EventArgs e)
        {
            c.RegistrationNumber = RegistrationBox.Text;
            c.Name = NameBox.Text;
            c.Email = EmailBox.Text;
            c.PhoneNumber = PhoneBox.Text;
            c.Password = PasswordBox.Text;
            c.Balance = Convert.ToDouble(BalanceBox.Text);
            c.Role = RoleComboBox.Text;
            bool success = c.insert(c);
            if (success == true)
            {

                MessageBox.Show("New user added");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to Add");

            }
            DataTable dt = c.Select();
            UserDataGridView.DataSource = dt;

        }

        private void Register_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            UserDataGridView.DataSource = dt;
        }

        public void clear()
        {
            RegistrationBox.Text="";
            NameBox.Text= "";
            EmailBox.Text= "";
           PhoneBox.Text= "";
            PasswordBox.Text= "";
           BalanceBox.Text="";
           RoleComboBox.Text= "";
            pictureBox.Image = null;
           
        }

        private void UserDataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            IDBox.Text = UserDataGridView.Rows[rowIndex].Cells[0].Value.ToString();
            RegistrationBox.Text = UserDataGridView.Rows[rowIndex].Cells[1].Value.ToString();
            NameBox.Text = UserDataGridView.Rows[rowIndex].Cells[2].Value.ToString();
            EmailBox.Text = UserDataGridView.Rows[rowIndex].Cells[3].Value.ToString();
            PhoneBox.Text = UserDataGridView.Rows[rowIndex].Cells[4].Value.ToString();
            PasswordBox.Text = UserDataGridView.Rows[rowIndex].Cells[5].Value.ToString();
            BalanceBox.Text = UserDataGridView.Rows[rowIndex].Cells[6].Value.ToString();
            RoleComboBox.Text = UserDataGridView.Rows[rowIndex].Cells[7].Value.ToString();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            c.ID = int.Parse(IDBox.Text);
            c.RegistrationNumber = RegistrationBox.Text;
            c.Name = NameBox.Text;
            c.Email = EmailBox.Text;
            c.PhoneNumber = PhoneBox.Text;
            c.Password = PasswordBox.Text;
            c.Balance = Convert.ToDouble(BalanceBox.Text);
            c.Role = RoleComboBox.Text;

            bool success = c.update(c);
            if(success == true)
            {
                MessageBox.Show("Updated Successfully");
                DataTable dt = c.Select();
                UserDataGridView.DataSource = dt;
                clear();
            }
            else
            {
                MessageBox.Show("Update failed");
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            clear();   
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            c.ID = Convert.ToInt32(IDBox.Text);
            bool success = c.delete(c);
            if (success == true)
            {
                MessageBox.Show("Deleted Successfully");
                clear();
                DataTable dt = c.Select();
                UserDataGridView.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed To Delete");
            }

        }
        
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(RegistrationBox.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            var bmp = code.GetGraphic(5);
            saveQR(bmp);
            
            
        }
      

       public void saveQR(Bitmap bitmap) {

           
            var directoryPath = Application.StartupPath + "\\Images";
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var fileName = "QR_" + c.Name + ".jpg";
            fileName = directoryPath + "\\" + fileName;
            if (MessageBox.Show("Are You Sure You Want to save?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                pictureBox.Image = bitmap;
            }
            

        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string myconnstrng = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
            string keyword = SearchBox.Text;

            SqlConnection conn = new SqlConnection(myconnstrng);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Users WHERE RegistrationNumber LIKE '%" + keyword + "%' OR UserName LIKE '%" + keyword + "%' OR Email LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            UserDataGridView.DataSource = dt;
        }
    }
}
