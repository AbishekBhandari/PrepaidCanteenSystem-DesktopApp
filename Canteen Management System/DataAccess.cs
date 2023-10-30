using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace Canteen_Management_System
{
    internal class DataAccess
    {
        string myconnStrng = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        //ADD CATEGORY TO DATABASE
        public bool AddNewCategoryToDatabase(string CategoryName, string CategoryDescription, PictureBox CategoryPictureBox,string active)
        {
            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                connection.Open();

                /*Start a local transaction*/
                SqlTransaction sqlTran = connection.BeginTransaction();

                /*Enlist a command in the current transaction*/
                SqlCommand command = connection.CreateCommand();
                command.Transaction = sqlTran;

                /*THIS IS THE MAIN CODE FOR HASHING*/

                /*initializing memory stream class for creating a stream of binary numbers*/
                MemoryStream ms = new MemoryStream();

                /*saving the image in raw format from picture box*/
                CategoryPictureBox.Image.Save(ms, CategoryPictureBox.Image.RawFormat);

                /*Array of Binary numbers that have been converted*/
                byte[] CategoryPicture = ms.GetBuffer();

                /*closing the memory stream*/
                ms.Close();

                /*HASHING END HERE*/

                /*now we will save this array into our database*/

                try
                {
                    // Execute separate commands.
                    command.Parameters.AddWithValue("@CategoryName", CategoryName);
                    command.Parameters.AddWithValue("@CategoryDescription", CategoryDescription);
                    command.Parameters.AddWithValue("@CategoryPicture", CategoryPicture);
                    command.Parameters.AddWithValue("@Active", active);

                    command.CommandText =
                       "Insert into Categories (CategoryName, CategoryDescription, CategoryPicture,Active) values (@CategoryName, @CategoryDescription, @CategoryPicture,@Active)";
                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    sqlTran.Commit();

                    connection.Close();

                    return true;
                }
                catch (Exception ee)
                {
                    connection.Close();
                    return false;
                }
            }
        }


        //RETRIEVE ALL CATEGORIES FROM DATABASE
        public ArrayList RetreiveAllCategoriesFromDatabase()
        {
            ArrayList CategoriesList = new ArrayList();

            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                SqlCommand command = new SqlCommand("SELECT ID, CategoryName, CategoryPicture, CategoryDescription, Active FROM Categories ;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string Active1 = "null";
                        int CategoryID = reader.GetInt32(0);
                        string CategoryName = reader.GetString(1);
                        byte[] CategoryPicture = (byte[])reader[2];
                        string CategoryDescription = reader.GetString(3);
                         Active1 = reader.GetString(4);

                        CategoriesList.Add(new Details() { ID = CategoryID, Name = CategoryName, Picture = CategoryPicture, Description = CategoryDescription, Active = Active1 });
                    }
                }
                reader.Close();

                return CategoriesList;
            }
        }

        public ArrayList RetreiveAllCategoriesFromDatabase1()
        {
            ArrayList CategoriesList = new ArrayList();

            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                SqlCommand command = new SqlCommand("SELECT ID, CategoryName, CategoryPicture, CategoryDescription, Active FROM Categories where Active='Yes' ;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string Active1 = "null";
                        int CategoryID = reader.GetInt32(0);
                        string CategoryName = reader.GetString(1);
                        byte[] CategoryPicture = (byte[])reader[2];
                        string CategoryDescription = reader.GetString(3);
                        Active1 = reader.GetString(4);

                        CategoriesList.Add(new Details() { ID = CategoryID, Name = CategoryName, Picture = CategoryPicture, Description = CategoryDescription, Active = Active1 });
                    }
                }
                reader.Close();

                return CategoriesList;
            }
        }

        //ADD PRODUCTS TO DATABASE
        public bool AddNewProductToDatabase(string ProductName, decimal ProductPrice, int ProductCategoryID, string ProductDescription,string Active, byte[] ProductPicture)
        {
            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                connection.Open();

                /*Start a local transaction*/
                SqlTransaction sqlTran = connection.BeginTransaction();

                /*Enlist a command in the current transaction*/
                SqlCommand command = connection.CreateCommand();
                command.Transaction = sqlTran;

                try
                {
                    // Execute separate commands.
                    command.Parameters.AddWithValue("@ProductName", ProductName);
                    command.Parameters.AddWithValue("@ProductPrice", ProductPrice);
                    command.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
                    command.Parameters.AddWithValue("@ProductDescription", ProductDescription);
                    command.Parameters.AddWithValue("@ProductImage", ProductPicture);
                    command.Parameters.AddWithValue("@Active", Active);
                    command.CommandText =
                       "Insert into Products (ProductName, ProductPrice, ProductCategoryID, ProductDescription, ProductImage,Active) values (@ProductName, @ProductPrice, @ProductCategoryID, @ProductDescription, @ProductImage,@Active)";
                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    sqlTran.Commit();

                    connection.Close();

                    return true;
                }
                catch (Exception ee)
                {
                    connection.Close();
                    return false;
                }
            }
        }

        //RETRIEVE ALL PRODUCTS FROM DATABASE
        public ArrayList RetreiveAllProducts()
        {
            ArrayList ProductsList = new ArrayList();

            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                SqlCommand command = new SqlCommand("SELECT ID, ProductName, ProductPrice, ProductCategoryID, ProductDescription, ProductImage,Active FROM Products;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ProductID = reader.GetInt32(0);
                        string ProductName = reader.GetString(1);
                        decimal ProductPrice = reader.GetDecimal(2);
                        int ProductCategoryID = reader.GetInt32(3);
                        string ProductCategoryName = ReturnCategoryName(ProductCategoryID);
                        string ProductDescription = reader.GetString(4);
                        byte[] ProductPicture = (byte[])reader[5];
                        string Active1 = reader.GetString(6);

                        ProductsList.Add(new Details() { Name = ProductName, Price = ProductPrice, Category = ProductCategoryName, Description = ProductDescription, Picture = ProductPicture, ID = ProductID,Active= Active1});
                    }
                }
                reader.Close();

                return ProductsList;
            }
        }

        //RETRIEVE PRODUCTS FROM CATEGORIES
        public ArrayList RetreiveProductsFromCategory(int CategoryID)
        {
            ArrayList ProductsList = new ArrayList();

            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                SqlCommand command = new SqlCommand("SELECT ID, ProductName, ProductPrice, ProductDescription, ProductImage,Active FROM Products where ProductCategoryID = '" + CategoryID + "';", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ProductID = reader.GetInt32(0);
                        string ProductName = reader.GetString(1);
                        decimal ProductPrice = reader.GetDecimal(2);
                        string ProductDescription = reader.GetString(3);
                        byte[] ProductPicture = (byte[])reader[4];
                        string Active1 = reader.GetString(5);
                        ProductsList.Add(new Details() { ID = ProductID, Name = ProductName, Price = ProductPrice, Picture = ProductPicture, Description = ProductDescription ,Active=Active1});
                    }
                }
                reader.Close();

                return ProductsList;
            }
        }

        public ArrayList RetreiveProductsFromCategory1(int CategoryID)
        {
            ArrayList ProductsList = new ArrayList();

            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                SqlCommand command = new SqlCommand("SELECT ID, ProductName, ProductPrice, ProductDescription, ProductImage FROM Products where ProductCategoryID = '" + CategoryID + "' and Active='Yes';", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ProductID = reader.GetInt32(0);
                        string ProductName = reader.GetString(1);
                        decimal ProductPrice = reader.GetDecimal(2);
                        string ProductDescription = reader.GetString(3);
                        byte[] ProductPicture = (byte[])reader[4];
                        
                        ProductsList.Add(new Details() { ID = ProductID, Name = ProductName, Price = ProductPrice, Picture = ProductPicture, Description = ProductDescription, });
                    }
                }
                reader.Close();

                return ProductsList;
            }
        }

        //RETURN CATEGORY ID
        public int ReturnCategoryID(string CategoryName)
        {
            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                SqlCommand command = new SqlCommand("SELECT ID FROM Categories where CategoryName = '" + CategoryName + "';", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                int CategoryID = 0;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CategoryID = reader.GetInt32(0);
                    }
                }
                reader.Close();

                return CategoryID;
            }
        }


        //RETURN CATEGORY NAME
        public string ReturnCategoryName(int CategoryID)
        {
            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName FROM Categories where ID = '" + CategoryID + "';", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                string CategoryName = string.Empty;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CategoryName = reader.GetString(0);
                    }
                }
                reader.Close();

                return CategoryName;
            }
        }

        //RETRIEVE PRODUCT DETAILS
        public Details RetreiveProductDetails(int ProductID)
        {
            Details ProductDetails = new Details();

            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                SqlCommand command = new SqlCommand("SELECT ProductName, ProductPrice, ProductCategoryID, ProductDescription, ProductImage,Active FROM Products where ID = '" + ProductID + "';", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductDetails.Name = reader.GetString(0);
                        ProductDetails.Price = reader.GetDecimal(1);
                        int ProductCategoryID = reader.GetInt32(2);
                        ProductDetails.Category = ReturnCategoryName(ProductCategoryID);
                        ProductDetails.Description = reader.GetString(3);
                        ProductDetails.Picture = (byte[])reader[4];
                        ProductDetails.Active = reader.GetString(5);
                    }
                }
                reader.Close();

                return ProductDetails;
            }
        }

        //RECORD A SALE




        //RETURN A USERNAME
        public string ReturnUserName(int UserID)
        {
            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                SqlCommand command = new SqlCommand("SELECT Name FROM Users where ID = '" + UserID + "';", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                string UserName = string.Empty;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserName = reader.GetString(0);
                    }
                }
                reader.Close();

                return UserName;
            }
        }

        //RETURN USERID
        public int ReturnUserID(string UserEmail)
        {
            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                SqlCommand command = new SqlCommand("SELECT ID FROM Users where Email = '" + UserEmail + "';", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                int UserID = 0;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserID = reader.GetInt32(0);
                    }
                }
                reader.Close();

                return UserID;
            }
        }

        //Confirm users

        //DELETE PRODUCT
        public bool DeleteProduct(int ProductID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(myconnStrng))
                {
                    SqlCommand command = new SqlCommand("Delete from Products where ID = '" + ProductID + "'", connection);
                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProductWithCategoryID(int CategoryID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(myconnStrng))
                {
                    SqlCommand command = new SqlCommand("Delete from Products where ProductCategoryID = '" + CategoryID + "'", connection);
                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        public bool DeleteCategory(int ProductID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(myconnStrng))
                {
                    SqlCommand command = new SqlCommand("Delete from Categories where ID = '" + ProductID + "'", connection);
                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Update product

        public bool UpdateProduct(int ProductID, string ProductName, decimal ProductPrice, int ProductCategoryID, string ProductDescription, byte[] ProductPicture,string Active)
        {
            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                connection.Open();

                /*Start a local transaction*/
                SqlTransaction sqlTran = connection.BeginTransaction();

                /*Enlist a command in the current transaction*/
                SqlCommand command = connection.CreateCommand();
                command.Transaction = sqlTran;

                try
                {
                    // Execute separate commands.
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@ProductName", ProductName);
                    command.Parameters.AddWithValue("@ProductPrice", ProductPrice);
                    command.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
                    command.Parameters.AddWithValue("@ProductDescription", ProductDescription);
                    command.Parameters.AddWithValue("@ProductImage", ProductPicture);
                    command.Parameters.AddWithValue("@Active", Active);

                    command.CommandText =
                       "Update Products set ProductName = @ProductName, ProductPrice = @ProductPrice, ProductCategoryID = @ProductCategoryID, ProductDescription = @ProductDescription, ProductImage=@ProductImage, Active=@Active where ID = @ProductID";
                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    sqlTran.Commit();

                    connection.Close();

                    return true;
                }
                catch (Exception ee)
                {
                    connection.Close();
                    return false;
                }
            }
        }

        public bool UpdateCategory(int ProductID, string ProductName,string ProductDescription, byte[] ProductPicture,string Active)
        {
            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                connection.Open();

                /*Start a local transaction*/
                SqlTransaction sqlTran = connection.BeginTransaction();

                /*Enlist a command in the current transaction*/
                SqlCommand command = connection.CreateCommand();
                command.Transaction = sqlTran;

                try
                {
                    // Execute separate commands.
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@ProductName", ProductName);
                   
                    command.Parameters.AddWithValue("@ProductDescription", ProductDescription);
                    command.Parameters.AddWithValue("@ProductImage", ProductPicture);
                    command.Parameters.AddWithValue("@Active", Active);

                    command.CommandText =
                       "Update Categories set CategoryName = @ProductName,CategoryDescription = @ProductDescription, CategoryPicture=@ProductImage, Active=@Active where ID = @ProductID";
                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    sqlTran.Commit();

                    connection.Close();

                    return true;
                }
                catch (Exception ee)
                {
                    connection.Close();
                    return false;
                }
            }
        }

        public bool Login(string username, string password)
        {
            MyConnection db = new MyConnection();
            try
            {
                using (db.con)
                {

                    SqlCommand cmd = new SqlCommand("Select * from Users where RegistrationNumber = @username and Password=@password ", db.con);
                    db.con.Open();
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        if (rd["Role"].ToString() == "Admin")
                        {
                            MyConnection.role = "A";

                        }
                        else if (rd["Role"].ToString() == "User")
                        {
                            MyConnection.role = "U";
                        }
                        MyConnection.username = rd["UserName"].ToString();
                        MyConnection.registration = rd["RegistrationNumber"].ToString();
                        MyConnection.balance = rd["Balance"].ToString();
                        MyConnection.ID = Convert.ToInt16(rd["ID"]);

                        return true;
                    }
                    else
                    {
                        return false;
                        
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            return true;
        }
         
        public decimal returnBalance()
        {
            decimal balance = 0;
            
            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                SqlCommand cmd = new SqlCommand("Select * from Users where ID=@ID ", connection);
                
                cmd.Parameters.AddWithValue("@ID", MyConnection.ID);
                connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                balance = Convert.ToDecimal(rd["Balance"]);


            }

            return balance;
        }

     

        public int ReturnSaleID()
        {
            int SaleID = 1;
            try
            {

                using (SqlConnection connection = new SqlConnection(myconnStrng))
                {
                    SqlCommand command = new SqlCommand("SELECT MAX(ID) FROM Sales;", connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SaleID = reader.GetInt32(0);
                        }
                    }
                    reader.Close();

                    SaleID = SaleID + 1;

                    return SaleID;
                }
            }
            catch (Exception)
            {
                return SaleID;
            }
        }


        public bool insertSales(string name,decimal total,DateTime time)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(myconnStrng))
            {
                SqlCommand command = new SqlCommand("Insert into Sales values(@name,@total,@time)", connection);
                connection.Open();
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@total", total);
                command.Parameters.AddWithValue("@time", time.ToShortDateString());

                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    success = true;
                    return true;
                }
                else
                {
                    return success;
                }
            }


          
        }

       






    }
}
