using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_Management_System
{
    internal class RegisterClass
    {
        public string OldPassword{ get; set; }
        public string NewPassword { get; set; }
        public int ID { get; set; }
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }

        public string Role { get; set; }

       

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from Users";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        //inseting data into database
        public bool insert(RegisterClass r) 
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "Insert into Users values(@RegistrationNumber,@UserName,@Email,@PhoneNumber,@Password,@Balance,@Role)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@RegistrationNumber", r.RegistrationNumber);
                cmd.Parameters.AddWithValue("@UserName", r.Name);
                cmd.Parameters.AddWithValue("@Email", r.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", r.PhoneNumber);
                cmd.Parameters.AddWithValue("@Password", r.Password);
                cmd.Parameters.AddWithValue("@Balance", r.Balance);
                cmd.Parameters.AddWithValue("@Role", r.Role);
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
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return success;
        }

        public bool update(RegisterClass r)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "Update Users set RegistrationNumber=@RegistrationNumber,UserName=@UserName,Email=@Email,PhoneNumber=@PhoneNUmber," +
                    "Password=@Password,Balance=@Balance,Role=@Role where ID=@ID ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@RegistrationNumber",r.RegistrationNumber);
                cmd.Parameters.AddWithValue("@UserName",r.Name);
                cmd.Parameters.AddWithValue("@Email",r.Email);
                cmd.Parameters.AddWithValue("@PhoneNUmber",r.PhoneNumber);
                cmd.Parameters.AddWithValue("@Password",r.Password);
                cmd.Parameters.AddWithValue("@Balance",r.Balance);
                cmd.Parameters.AddWithValue("@Role",r.Role);
                cmd.Parameters.AddWithValue("@ID",r.ID);
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
            }
            catch(Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return success;
        }

        public bool delete(RegisterClass r)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "Delete from Users where ID=@ID";
                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("@ID", r.ID);
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

            }
            catch(Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return success;
        }

        public bool changePassword(RegisterClass r)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "Select Password from Users where RegistrationNumber=@Registration";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Registration", r.RegistrationNumber);
                conn.Open();
                cmd.ExecuteNonQuery();
                if (Password == r.Password)
                {

                }

            }
            catch(Exception e)
            {

            }
            finally
            {
                conn.Close();
            }


            return success;
        }


    }
}
