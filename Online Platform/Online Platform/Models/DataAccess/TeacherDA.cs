using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Online_Platform.Models.DataAccess
{
    class TeacherDA
    {
        public Teacher GetTeacher(User user)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            SqlDataReader reader = null;
            try
            {

                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [dbo].[Teacher] where user_id = @userid";
                cmd.Parameters.Add("@userid", SqlDbType.Int);
                cmd.Parameters["@userid"].Value = user.User_Id;
                reader = cmd.ExecuteReader();
                reader.Read();
                return new Teacher()
                {
                    Teacher_id = int.Parse(reader[0].ToString()),
                    User_Id = user.User_Id,
                    Name = reader[2].ToString()
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

        internal bool CheckTeacherClass(int class_id, int subject_id, int teacher_id)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            SqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [dbo].[TSC] where class_id = @class_id and subject_id = @subject_id and teacher_id = @teacher_id";
                cmd.Parameters.Add("@subject_id", SqlDbType.Int);
                cmd.Parameters.Add("@teacher_id", SqlDbType.Int);
                cmd.Parameters.Add("@class_id", SqlDbType.Int);
                cmd.Parameters["@subject_id"].Value = subject_id;
                cmd.Parameters["@class_id"].Value = class_id;
                cmd.Parameters["@teacher_id"].Value = teacher_id;
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                    return true;
                else
                    return false;

            }
            catch
            {
                MessageBox.Show("db error");
                return false;
            }
            finally
            {
                reader.Close();
            }
        }

        internal bool CheckTeacherSubject(int subject_id, int teacher_id)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            SqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[TSCGetST]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "select * from [dbo].[TSC] where subject_id = @subject_id and teacher_id = @teacher_id";
                cmd.Parameters.Add("@subject_id", SqlDbType.Int);
                cmd.Parameters.Add("@teacher_id", SqlDbType.Int);
                cmd.Parameters["@subject_id"].Value = subject_id;
                cmd.Parameters["@teacher_id"].Value = teacher_id;
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                    return true;
                else
                    return false;
            }
            catch
            {
                MessageBox.Show("db error");
                return false;
            }
            finally
            {
                reader.Close();
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            SqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[TeacherGet]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.CommandText = "select * from [dbo].[Teacher]";
                reader = cmd.ExecuteReader();
                List<Teacher> teachers = new List<Teacher>();
                while (reader.Read())
                {
                    var teacher = new Teacher()
                    {
                        Teacher_id = int.Parse(reader[0].ToString()),
                        User_Id = int.Parse(reader[1].ToString()),
                        Name = reader[2].ToString()
                    };
                    teachers.Add(teacher);
                }
                return teachers;

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

        public void AddTeacher(int user_id, string name)
        {

            SqlConnection sqlConnection = Open_Connection.Connection;

            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into [dbo].[Teacher] Values(@user_id, @name)";
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");
            }

        }

        internal void DeleteTeacher(int teacher_id)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from [dbo].[Teacher] where teacher_id=@teacher_id";
                cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");
            }
        }

        public Teacher GetTeacherByName(string name)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            SqlDataReader reader = null;
            try
            {

                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [dbo].[Teacher] where name = @name";
                cmd.Parameters.AddWithValue("@name", name);
                reader = cmd.ExecuteReader();
                reader.Read();
                return new Teacher()
                {
                    Teacher_id = int.Parse(reader[0].ToString()),
                    User_Id = int.Parse(reader[1].ToString()),
                    Name = reader[2].ToString()
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

        
    }
}
