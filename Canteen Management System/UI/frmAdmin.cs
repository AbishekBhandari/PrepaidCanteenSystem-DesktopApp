using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canteen_Management_System.UI
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
            
        }
        public int SalesmanID = 0;
        public string Username = string.Empty;

        public int RowIndex = 0;

        //AFTER LOADING OF ADMIN PANEL WHAT TO DISPLAY IN CATEGORY PANEL
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            DataAccess _DataAccess = new DataAccess();

            ArrayList AllCategories = _DataAccess.RetreiveAllCategoriesFromDatabase1();

            foreach (Details Category in AllCategories)
            {
                Button btn = new Button();
                btn.Text = Category.Name;
                
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

        //ON CLICKING A CATEGORY
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

                

            }
        }

        //ON CLICKING A PRODUCT IT SHOULD APPEAR ON THE BILL





        //ON CLICKING ON MENUSTRIP OPTIONS LIKE ADD CATEGORY ,ADD PRODUCT,All PRODUCTS,VIEW SALES


        private void ClosePictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMenu menu = new frmMenu();
            menu.Show();
        }

       

        private void RefeshPictureBox_Click(object sender, EventArgs e)
        {
            CategoriesFlowPanel.Controls.Clear();
            ProductsFlowPanel.Controls.Clear();

            DataAccess _DataAccess = new DataAccess();

            ArrayList AllCategories = _DataAccess.RetreiveAllCategoriesFromDatabase1();

            foreach (Details Category in AllCategories)
            {
                Button btn = new Button();
                btn.Text = Category.Name;
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

   
        private void viewAllCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAllCategories _ViewAllCategories = new ViewAllCategories();
            _ViewAllCategories.ShowDialog();
        }

      

        private void registerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Register _Register = new Register();
            _Register.ShowDialog();
        }

        private void addCategoryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddCategory _AddCategory = new AddCategory();
            if (_AddCategory.ShowDialog() == DialogResult.OK)
            {
                CategoriesFlowPanel.Controls.Clear();

                DataAccess _DataAccess = new DataAccess();

                ArrayList AllCategories = _DataAccess.RetreiveAllCategoriesFromDatabase1();

                foreach (Details Category in AllCategories)
                {
                    Button btn = new Button();
                    btn.Text = Category.Name;
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

        private void addProductsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddProduct _AddProduct = new AddProduct();
            _AddProduct.ShowDialog();
        }

        private void viewAllProductsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new ViewAllProducts().ShowDialog();
        }

        private void viewCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ViewAllCategories().ShowDialog();
        }

        public void refresh()
        {
            CategoriesFlowPanel.Controls.Clear();
            ProductsFlowPanel.Controls.Clear();

            DataAccess _DataAccess = new DataAccess();

            ArrayList AllCategories = _DataAccess.RetreiveAllCategoriesFromDatabase1();

            foreach (Details Category in AllCategories)
            {
                Button btn = new Button();
                btn.Text = Category.Name;
                btn.Size = new System.Drawing.Size(80, 80);
                btn.ForeColor = Color.White;

                MemoryStream ms = new MemoryStream(Category.Picture);
                btn.Image = Image.FromStream(ms);
                btn.Image = new Bitmap(btn.Image, btn.Size);

                btn.Tag = Category.ID;

                CategoriesFlowPanel.Controls.Add(btn);

                btn.Click += CategoryButtonClick;
            }
        }

        private void viewSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ViewAllSales().ShowDialog();
        }
    }
}
