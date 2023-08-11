using Online_Platform.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Online_Platform.Models.DataAccess
{
    class SubjectDA
    {

        public List<Subject> GetSubjects(int classid)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                TSCDA tsc = new TSCDA();
                List<TSC> tscList = tsc.GetTSC(classid);
                List<Subject> subjects = new List<Subject>();
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SubjectInsertUpdateDelete]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.CommandText = "select * from [dbo].[Subject] where subject_id = @subjectid";
                cmd.Parameters.AddWithValue("@StatementType", "Select");
                cmd.Parameters.AddWithValue("@name", "Select");
                cmd.Parameters.AddWithValue("@have_thesis", true);
                cmd.Parameters.AddWithValue("@materials", "Select");
                cmd.Parameters.Add("@subject_id", SqlDbType.Int);
                foreach (var tscelem in tscList)
                {
                    cmd.Parameters["@subject_id"].Value = tscelem.Subject_Id;
                  
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var subject = new Subject()
                        {
                            Subject_id = int.Parse(reader[0].ToString()),
                            Name = reader[1].ToString(),
                            Materials = reader[2].ToString()
                        };
                        subjects.Add(subject);
                    }
                    reader.Close();
                }
                return subjects;
            }
            catch
            {
                MessageBox.Show("db error");
                return null;
            }
        }

        internal Subject GetSubjectByName(string subject_name)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            SqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [dbo].[Subject] where name = @name";
                cmd.Parameters.Add("@name", SqlDbType.NVarChar);
                cmd.Parameters["@name"].Value = subject_name;
                reader = cmd.ExecuteReader();
                reader.Read();
                return new Subject()
                {
                    Subject_id = int.Parse(reader[0].ToString()),
                    Name = reader[1].ToString(),
                    Materials = reader[2].ToString()

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

        internal void ModifySubject(int subject_id, string material)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update [dbo].[Subject] set materials=@material where subject_id=@subject_id";
                cmd.Parameters.AddWithValue("@subject_id", subject_id);
                cmd.Parameters.AddWithValue("@material", material);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");

            }
        }

        internal void AddSubject(string name, string materials)
        {
           
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into [dbo].[Subject] values (@name, @materials)";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@materials", materials);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");

            }
        }

        public List<Subject> GetAllSubjects()
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            SqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SubjectGet]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.CommandText = "select * from [dbo].[Subject]";
                reader = cmd.ExecuteReader();
                List<Subject> subjects = new List<Subject>();
                while (reader.Read())
                {
                    var subject = new Subject()
                    {
                        Subject_id = int.Parse(reader[0].ToString()),
                        Name = reader[1].ToString(),
                        Materials = reader[2].ToString()

                    };
                    subjects.Add(subject);
                }
                return subjects;

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

        internal void DeleteSubject(int subject_id)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from [dbo].[Subject] where subject_id=@subject_id";
                cmd.Parameters.AddWithValue("@subject_id", subject_id);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");
            }
        }
    }
}
