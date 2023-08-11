using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Online_Platform.Models.DataAccess
{
    class ClassDA
    {
        public int GetClassByName(string name, int number)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            SqlDataReader reader = null;
            try
            {

                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [dbo].[Class] where name = @name and number = @number";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@number", number);
                reader = cmd.ExecuteReader();
                reader.Read();
                return int.Parse(reader[0].ToString());          
               
            }
            catch
            {
                MessageBox.Show("db error");
                return -1;
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
