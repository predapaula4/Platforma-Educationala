using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Online_Platform.Models.DataAccess
{
    class UserDA
    {

        public User GetUser(User user)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            SqlDataReader reader = null;
            try
            {

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[UserGet]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.CommandText = "select * from [dbo].[User] where username = @username and user_password = @password";
                cmd.Parameters.Add("@username", SqlDbType.NVarChar);
                cmd.Parameters.Add("@password", SqlDbType.NVarChar);
                cmd.Parameters["@username"].Value = user.UserName;
                cmd.Parameters["@password"].Value = user.Password;
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows == false)
                {
                    return new User()
                    { User_Role = "-1" };
                }

                return new User()
                {
                    User_Id = int.Parse(reader[0].ToString()),
                    UserName = reader[1].ToString(),
                    Password = reader[2].ToString(),
                    User_Role = reader[3].ToString()
                };



            }
            catch
            {
                MessageBox.Show("db error");
                return null;
            }
            finally
            {
                reader.Close();
            }
        }

        public void AddUser(string username, string user_password, int user_role)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[UserCreate]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.CommandText = "insert into [dbo].[User] values (@username, @user_password, @user_role)";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@user_password", user_password);
                cmd.Parameters.AddWithValue("@user_role", user_role);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");
            }
        }

        internal void Modify_User(int user_id)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[UserUpdate]", sqlConnection); 
                cmd.CommandType = CommandType.StoredProcedure;
               // cmd.CommandText = "update [dbo].[User] set user_role=@user_role where user_id=@user_id";
                cmd.Parameters.AddWithValue("@user_role", 2);
                cmd.Parameters.AddWithValue("@user_id", user_id);

                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");

            }
        }
    }
}
