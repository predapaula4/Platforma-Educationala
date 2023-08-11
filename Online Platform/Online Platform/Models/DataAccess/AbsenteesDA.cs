using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Online_Platform.Models.DataAccess
{
    class AbsenteesDA
    {
        public Dictionary<string, List<Absentees>> GetAbsentees(int student_id, List<Subject> subjects)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {

                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [dbo].[Absentees] where student_id = @student_id and subject_id = @subject_id";
                cmd.Parameters.Add("@student_id", SqlDbType.Int);
                cmd.Parameters.Add("@subject_id", SqlDbType.Int);
                cmd.Parameters["@student_id"].Value = student_id;
                var absentees = new Dictionary<string, List<Absentees>>();
                foreach (var subject in subjects)
                {

                    cmd.Parameters["@subject_id"].Value = subject.Subject_id;
                    SqlDataReader reader = cmd.ExecuteReader();
                    var absList = new List<Absentees>();
                    while (reader.Read())
                    {
                        var absentee = new Absentees()
                        {
                            Absentee_Id = int.Parse(reader[0].ToString()),
                            Subject_Id = int.Parse(reader[1].ToString()),
                            Student_id = int.Parse(reader[2].ToString()),
                            Absentee_Date = DateTime.Parse(reader[3].ToString()),
                            Is_Motivated = bool.Parse(reader[4].ToString()),
                            Semester = int.Parse(reader[5].ToString())
                        };
                        absList.Add(absentee);
                    }
                    reader.Close();
                    absentees.Add(subject.Name, absList);
                }
                return absentees;

            }
            catch
            {
                MessageBox.Show("db error");
                return null;
            }
        }

        public void AddAbsentee(int student_id, int subject_id, int semester, DateTime date)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into [dbo].[Absentees] values (@subject_id, @student_id, @absentee_date, @is_motivated, @semester)";
                cmd.Parameters.AddWithValue("@subject_id", subject_id);
                cmd.Parameters.AddWithValue("@student_id", student_id);
                cmd.Parameters.AddWithValue("@absentee_date", date.ToString().Split(' ')[0]);
                cmd.Parameters.AddWithValue("@is_motivated", false);
                cmd.Parameters.AddWithValue("@semester", semester);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");

            }
        }

        internal void ModifyAbsentee(int absentee_id)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update [dbo].[Absentees] set is_motivated=@is_motivated where absentees_id=@absentee_id";
                cmd.Parameters.AddWithValue("@absentee_id", absentee_id);
                cmd.Parameters.AddWithValue("@is_motivated", 1);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");

            }
        }

        public List<Absentees> GetAbsenteesForStudents(List<Student> students)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {

                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [dbo].[Absentees] where student_id = @student_id";
                cmd.Parameters.Add("@student_id", SqlDbType.Int);
                var absentees = new  List<Absentees>();
                foreach (var student in students)
                {
                    cmd.Parameters["@student_id"].Value = student.Student_id;
                    SqlDataReader reader = cmd.ExecuteReader();                   
                    while (reader.Read())
                    {
                        var absentee = new Absentees()
                        {
                            Absentee_Id = int.Parse(reader[0].ToString()),
                            Subject_Id = int.Parse(reader[1].ToString()),
                            Student_id = int.Parse(reader[2].ToString()),
                            Absentee_Date = DateTime.Parse(reader[3].ToString()),
                            Is_Motivated = bool.Parse(reader[4].ToString()),
                            Semester = int.Parse(reader[5].ToString())
                        };
                        absentees.Add(absentee);
                    }
                    reader.Close();
                    
                }
                return absentees;

            }
            catch
            {
                MessageBox.Show("db error");
                return null;
            }
        }
    }
}
