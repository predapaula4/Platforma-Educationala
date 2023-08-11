using Online_Platform.Models.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Online_Platform.Models.DataAccess
{
    class StudentDA
    {
        public Student GetStudent(User user)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            SqlDataReader reader = null;
            try
            {

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[StudentGet]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.CommandText = "select * from [dbo].[Student] where user_id = @userid";
                cmd.Parameters.Add("@userid", SqlDbType.Int);
                cmd.Parameters["@userid"].Value = user.User_Id;
                reader = cmd.ExecuteReader();
                reader.Read();
                return new Student()
                {
                    Student_id = int.Parse(reader[0].ToString()),
                    Class_id = int.Parse(reader[1].ToString()),
                    User_id = user.User_Id

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

        public void ModifyStudent(string student_name)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update [dbo].[Student] set class_id=@class_id where name=@name";
                cmd.Parameters.AddWithValue("@name", student_name);
                cmd.Parameters.AddWithValue("@class_id", 2);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");

            }
        }

        public List<Student> GetStudentFromClass(int class_id)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            SqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [dbo].[Student] where class_id = @class_id";
                cmd.Parameters.AddWithValue("@class_id", class_id);
                reader = cmd.ExecuteReader();
                List<Student> students = new List<Student>();
                while (reader.Read())
                {
                    var student = new Student()
                    {
                        Student_id = int.Parse(reader[0].ToString()),
                        Class_id = int.Parse(reader[1].ToString()),
                        User_id = int.Parse(reader[2].ToString()),
                        Name = reader[3].ToString()
                    };
                    students.Add(student);
                }
                return students;

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

        public List<Student> GetAllStudents()
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            SqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [dbo].[Student]";                
                reader = cmd.ExecuteReader();
                List<Student> students = new List<Student>();
                while (reader.Read())
                {
                    var student = new Student()
                    {
                        Student_id = int.Parse(reader[0].ToString()),
                        Class_id = int.Parse(reader[1].ToString()),
                        User_id = int.Parse(reader[2].ToString()),
                        Name = reader[3].ToString()
                    };
                    students.Add(student);
                }
                return students;

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

        public Student GetStudentByName(string student_name)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            SqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [dbo].[Student] where name = @name";
                cmd.Parameters.Add("@name", SqlDbType.NVarChar);
                cmd.Parameters["@name"].Value = student_name;
                reader = cmd.ExecuteReader();
                reader.Read();
                return new Student()
                {
                    Student_id = int.Parse(reader[0].ToString()),
                    Class_id = int.Parse(reader[1].ToString()),
                    User_id = int.Parse(reader[2].ToString()),
                    Name = reader[3].ToString()
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

        public void AddStudent(int class_id, int user_id, string name)
        {

            SqlConnection sqlConnection = Open_Connection.Connection;

            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into [dbo].[Student] Values(@class_id, @user_id, @name)";
                cmd.Parameters.AddWithValue("@class_id", class_id);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");
            }

        }

        internal void DeleteStudent(int student_id)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[StudentDelete]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "delete from [dbo].[Student] where student_id=@student_id";
                cmd.Parameters.AddWithValue("@student_id", student_id);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");
            }
        }

    }
}
