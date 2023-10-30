using System;
using System.Collections;
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
    public partial class ViewAllCategories : Form
    {
        public ViewAllCategories()
        {
            InitializeComponent();
        }

        private void ViewAllCategories_Load(object sender, EventArgs e)
        {
            DataAccess _DataAccess = new DataAccess();

            foreach (Details CategoryDetail in _DataAccess.RetreiveAllCategoriesFromDatabase())
            {
                CategoriesGridView.Rows.Add(CategoryDetail.ID, CategoryDetail.Name, CategoryDetail.Description,CategoryDetail.Picture,CategoryDetail.Active);
            }
        }

        private void CategoriesGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (CategoriesGridView.Columns[e.ColumnIndex].Name == "DeleteColumn")
                {
                    if (MessageBox.Show("Are You Sure You Want to Delete this Category\nfrom Database", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int CategoryID = Convert.ToInt32(CategoriesGridView.Rows[e.RowIndex].Cells["CategoryIDColumn"].Value);

                        DataAccess _DataAccess = new DataAccess();

                        if (_DataAccess.DeleteCategory(CategoryID))
                        {
                            _DataAccess.DeleteProductWithCategoryID(CategoryID);
                            CategoriesGridView.Rows.RemoveAt(e.RowIndex);
                            frmAdmin admin = new frmAdmin();
                            admin.refresh();
                            
                        }
                        else if (!_DataAccess.DeleteCategory(CategoryID))
                        {
                            MessageBox.Show("Product Not Deleted");
                        }
                    }
                }
                else if (CategoriesGridView.Columns[e.ColumnIndex].Name == "EditColumn")
                {
                    int ProductID = Convert.ToInt32(CategoriesGridView.Rows[e.RowIndex].Cells["CategoryIDColumn"].Value);

                    string ProductName = CategoriesGridView.Rows[e.RowIndex].Cells["CategoryNameColumn"].Value.ToString();


                    string ProductDescription = CategoriesGridView.Rows[e.RowIndex].Cells["CategoryDescriptionColumn"].Value.ToString();

                    byte[] ProductPicture = (byte[])CategoriesGridView.Rows[e.RowIndex].Cells["ImageColumn"].Value;

                    string Active = CategoriesGridView.Rows[e.RowIndex].Cells["Active"].Value.ToString(); 

                    UpdateCategory updateForm = new UpdateCategory(ProductID, ProductName, ProductDescription, ProductPicture,Active);
                    updateForm.ShowDialog();



                    string myconnStrng = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                    ArrayList CategoriesList = new ArrayList();

                    using (SqlConnection connection = new SqlConnection(myconnStrng))
                    {
                        SqlCommand command = new SqlCommand("SELECT ID, CategoryName, CategoryPicture, CategoryDescription,Active FROM Categories where ID=@CategoryID", connection);
                        connection.Open();
                        command.Parameters.AddWithValue("@CategoryID", ProductID);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int CategoryID = reader.GetInt32(0);
                                string CategoryName = reader.GetString(1);
                                byte[] CategoryPicture = (byte[])reader[2];
                                string CategoryDescription = reader.GetString(3);
                                string Active2 = reader.GetString(4);

                                CategoriesGridView.Rows[e.RowIndex].Cells["CategoryNameColumn"].Value = CategoryName;

                                CategoriesGridView.Rows[e.RowIndex].Cells["CategoryDescriptionColumn"].Value = CategoryDescription;
                                CategoriesGridView.Rows[e.RowIndex].Cells["ImageColumn"].Value = CategoryPicture;
                                CategoriesGridView.Rows[e.RowIndex].Cells["Active"].Value = Active2;
                                

                            }
                        }
                        reader.Close();
                    }


                  

                    


                }
            }
        }

    }
   
    }
