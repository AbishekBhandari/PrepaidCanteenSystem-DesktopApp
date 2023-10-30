using Canteen_Management_System.UI;
using DGVPrinterHelper;
using System;
using System.Collections;
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

namespace Canteen_Management_System
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

      

       

     
        private void AdminButton_Click(object sender, EventArgs e)
        {
            this.Close();
            frmAdmin admin = new frmAdmin();
            admin.Show();
            
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
           
        }

     

        public int SalesmanID = 0;
        public string Username = string.Empty;

        public int RowIndex = 0;

        private void frmMenu_Load(object sender, EventArgs e)
        {
            
            if (MyConnection.role == "A")
            {
                AdminButton.Visible = true;
            }
            if (MyConnection.role == "U")
            {
                AdminButton.Visible = false;
            }
            DataAccess da = new DataAccess();
            txtUsername.Text = MyConnection.username;
            txtRegistration.Text = MyConnection.registration.ToString();
            
            decimal balance = da.returnBalance();
            txtCurrentBalance.Text = balance.ToString();
            TotalBillBox.Text = 0.ToString();

            DataAccess _DataAccess = new DataAccess();

            ArrayList AllCategories = _DataAccess.RetreiveAllCategoriesFromDatabase1();

            foreach (Details Category in AllCategories)
            {
                Button btn = new Button();
                btn.Text = Category.Name;
                btn.TextAlign = ContentAlignment.BottomCenter;
                btn.FlatStyle = FlatStyle.Standard;
                btn.Size = new System.Drawing.Size(80, 80);
                btn.ForeColor = Color.Black;

                MemoryStream ms = new MemoryStream(Category.Picture);
                btn.Image = Image.FromStream(ms);
                btn.Image = new Bitmap(btn.Image, btn.Size);

                btn.Tag = Category.ID;

                CategoriesFlowPanel.Controls.Add(btn);

                btn.Click += CategoryButtonClick;
            }

        }

        public void CategoryButtonClick(object sender, EventArgs e)
        {
            ProductsFlowPanel.Controls.Clear();

            Button btn = (Button)sender;

            int CategoryID = Convert.ToInt32(btn.Tag);

            DataAccess _DataAccess = new DataAccess();

            foreach (Details Product in _DataAccess.RetreiveProductsFromCategory1(CategoryID))
            {
                Button ProductButton = new Button();
                ProductButton.Text = Product.Name + "\nRs." + Product.Price.ToString();
                ProductButton.TextAlign = ContentAlignment.BottomCenter;
                ProductButton.Size = new System.Drawing.Size(80, 80);
                ProductButton.ForeColor = Color.Black;

                MemoryStream ms = new MemoryStream(Product.Picture);
                ProductButton.Image = Image.FromStream(ms);
                ProductButton.Image = new Bitmap(ProductButton.Image, ProductButton.Size);

                ProductButton.Tag = Product.ID;

                ProductsFlowPanel.Controls.Add(ProductButton);



                ProductButton.Click += ProductButton_Click;
            }
        }

        //ON CLICKING A PRODUCT IT SHOULD APPEAR ON THE BILL

        void ProductButton_Click(object sender, EventArgs e)
        {
            Button ProductButton = sender as Button;

            DataAccess _DataAccess = new DataAccess();

            int ProductID = Convert.ToInt32(ProductButton.Tag);

            Details ProductDetails = _DataAccess.RetreiveProductDetails(ProductID);

            if (CheckProductAlreadyAdded(ProductID))
            {
                // MessageBox.Show("Product Already Exists in Datagrid view at Index : " + RowIndex);
                int Quantity = Convert.ToInt32(ProductsGridView.Rows[RowIndex].Cells["ProductQuantityColumn"].Value);
                decimal Price = Convert.ToInt32(ProductsGridView.Rows[RowIndex].Cells["ProductPriceColumn"].Value);

                Quantity++;

                /////////////< decimal part in the total price>
                double TotalPrice = Convert.ToDouble(Quantity * Price);

                ProductsGridView.Rows[RowIndex].Cells["ProductQuantityColumn"].Value = Quantity;
                ProductsGridView.Rows[RowIndex].Cells["TotalPriceColumn"].Value = TotalPrice;

                TotalBillBox.Text = CalculateTotalBill(ProductsGridView).ToString();
                txtBill.Text = CalculateTotalBill(ProductsGridView).ToString();
                txtRemainingBalance.Text = (Convert.ToDecimal(txtCurrentBalance.Text) - Convert.ToDecimal(TotalBillBox.Text)).ToString();
            }
            else
            {
                ProductsGridView.Rows.Add(ProductID, ProductDetails.Name, ProductDetails.Price, 1, ProductDetails.Price * 1);

                TotalBillBox.Text = CalculateTotalBill(ProductsGridView).ToString();
                txtBill.Text = CalculateTotalBill(ProductsGridView).ToString();
                txtRemainingBalance.Text = (Convert.ToDecimal(txtCurrentBalance.Text) - Convert.ToDecimal(TotalBillBox.Text)).ToString();
            }
        }

        public bool CheckProductAlreadyAdded(int ProductID)
        {
            foreach (DataGridViewRow Row in ProductsGridView.Rows)
            {
                if (Convert.ToInt32(Row.Cells["ProductIDColumn"].Value) == ProductID)
                {
                    RowIndex = Row.Index;
                    return true;
                }
            }
            return false;
        }

        public decimal CalculateTotalBill(DataGridView ProductsGridView)
        {
            decimal TotalBill = 0;

            foreach (DataGridViewRow Row in ProductsGridView.Rows)
            {
                decimal ProductTotal = Convert.ToDecimal(Row.Cells["TotalPriceColumn"].Value);

                TotalBill = TotalBill + ProductTotal;
            }

            return TotalBill;
        }

       

        private void ProductsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int Quantity = Convert.ToInt32(ProductsGridView.Rows[e.RowIndex].Cells["ProductQuantityColumn"].Value);

                

                if (ProductsGridView.Columns[e.ColumnIndex].Name == "DeleteColumn" && Quantity > 0)
                {

                    Quantity--;

                    decimal Price = Convert.ToInt32(ProductsGridView.Rows[e.RowIndex].Cells["ProductPriceColumn"].Value);

                   

                    /////////////<Do thisssss...... Important.. Have decimal part in the total price>
                    double TotalPrice = Convert.ToDouble(Quantity * Price);

                    ProductsGridView.Rows[e.RowIndex].Cells["ProductQuantityColumn"].Value = Quantity;
                    ProductsGridView.Rows[e.RowIndex].Cells["TotalPriceColumn"].Value = TotalPrice;

                    TotalBillBox.Text = CalculateTotalBill(ProductsGridView).ToString();
                    txtBill.Text = CalculateTotalBill(ProductsGridView).ToString();
                    txtRemainingBalance.Text = (Convert.ToDecimal(txtCurrentBalance.Text) - Convert.ToDecimal(TotalBillBox.Text)).ToString();
                }
               if (Quantity == 0)
                {
                    ProductsGridView.Rows.RemoveAt(e.RowIndex);
                }
              



            }
        }



        private void btnPay_Click(object sender, EventArgs e)
        {
            decimal totalBill = 0;
            decimal currentBalance = Convert.ToDecimal(txtCurrentBalance.Text);
            totalBill = Convert.ToDecimal(TotalBillBox.Text);
            if (currentBalance >= totalBill && totalBill!=0)
            {
                CashForm _CashForm = new CashForm();
                _CashForm.TotalBillBox.Text = TotalBillBox.Text;
                _CashForm.CurrentBalanceBox.Text = txtCurrentBalance.Text;
                if (_CashForm.ShowDialog() == DialogResult.OK)
                {

                    string myconnstrng = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                    bool success = false;
                    SqlConnection conn = new SqlConnection(myconnstrng);
                    
                   
                        string sql = "Update Users set Balance=@Balance where RegistrationNumber=@RegistrationNumber ";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@RegistrationNumber", MyConnection.registration);
                        decimal remaining = Convert.ToDecimal(_CashForm.RemainingBalanceBox.Text);
                        cmd.Parameters.AddWithValue("@Balance",remaining);
                       
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            success = true;
                        }
                        else
                        {
                            success = false;
                        }
                        if (success == true)
                        {
                            DataAccess da = new DataAccess();
                            decimal balance = da.returnBalance();
                            txtCurrentBalance.Text = balance.ToString();
                            
                            DGVPrinter printer = new DGVPrinter();
                            printer.Title = "\r\n\r\n\r\n Canteen Management System \r\n\r\n";
                            printer.SubTitle = "Pokhara, Nepal \r\n Phone: 061-****** \r\n\r\n";
                            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                            printer.PageNumbers = true;
                            printer.PageNumberInHeader = false;
                            printer.PorportionalColumns = true;
                            printer.HeaderCellAlignment = StringAlignment.Near;
                            printer.Footer = "Total Amount: " + TotalBillBox.Text + " \r\n" + "Remaining Balance: " + txtRemainingBalance.Text + " \r\n"  + "Thank you for doing business with us.";
                            printer.FooterSpacing = 15;
                            printer.PrintDataGridView(ProductsGridView);

                        
                       bool success1 =  da.insertSales(txtUsername.Text.ToString(), Convert.ToDecimal(TotalBillBox.Text), DateTime.Now);
                        if (success1 == true)
                        {
                            MessageBox.Show("Sales Added");
                        }
                            MessageBox.Show("Transaction Completed");
                            this.Close();
                          
                        }
 
                        conn.Close();

                }
                
            }

           

            else if(currentBalance > totalBill && totalBill == 0)
            {
                MessageBox.Show("Please select items first");
            }
            else
            {
                MessageBox.Show("Please recharge your card");
            }

            frmMenu menu = new frmMenu();
            menu.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CategoriesFlowPanel.Controls.Clear();

            DataAccess _DataAccess = new DataAccess();

            ArrayList AllCategories = _DataAccess.RetreiveAllCategoriesFromDatabase1();

            foreach (Details Category in AllCategories)
            {
                Button btn = new Button();
                btn.Text = Category.Name;
                btn.TextAlign = ContentAlignment.BottomCenter;
                btn.FlatStyle = FlatStyle.Standard;
                btn.Size = new System.Drawing.Size(80, 80);
                btn.ForeColor = Color.Black;

                MemoryStream ms = new MemoryStream(Category.Picture);
                btn.Image = Image.FromStream(ms);
                btn.Image = new Bitmap(btn.Image, btn.Size);

                btn.Tag = Category.ID;

                CategoriesFlowPanel.Controls.Add(btn);

                btn.Click += CategoryButtonClick;
            }
        }
    }
}
