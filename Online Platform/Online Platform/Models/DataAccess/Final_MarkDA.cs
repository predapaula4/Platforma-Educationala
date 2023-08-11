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
    class FinalMarkDA
    {
        public Dictionary<string, float> GetMarks(int student_id, List<Subject> subjects)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {

                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [dbo].[Final_Mark] where student_id = @student_id and subject_id = @subject_id";
                cmd.Parameters.Add("@student_id", SqlDbType.Int);
                cmd.Parameters.Add("@subject_id", SqlDbType.Int);
                cmd.Parameters["@student_id"].Value = student_id;
                Dictionary<string, float> grades = new Dictionary<string, float>();
                foreach (var subject in subjects)
                {

                    cmd.Parameters["@subject_id"].Value = subject.Subject_id;
                    SqlDataReader reader = cmd.ExecuteReader();
                    float finalGrade = 0;
                    while (reader.Read())
                    {
                        finalGrade = float.Parse(reader[3].ToString());
                    }
                    reader.Close();
                    grades.Add(subject.Name, finalGrade);
                }
                return grades;

            }
            catch
            {
                MessageBox.Show("db error");
                return null;
            }
        }

        public List<Final_Mark> GetFinalMarksClass(int student_id, List<Subject> subjects)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {

                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [dbo].[Final_Mark] where student_id = @student_id and subject_id = @subject_id";
                cmd.Parameters.Add("@student_id", SqlDbType.Int);
                cmd.Parameters.Add("@subject_id", SqlDbType.Int);
                cmd.Parameters["@student_id"].Value = student_id;
                List<Final_Mark> grades = new List<Final_Mark>();
                foreach (var subject in subjects)
                {
                    Final_Mark aux = new Final_Mark();
                    cmd.Parameters["@subject_id"].Value = subject.Subject_id;
                    SqlDataReader reader = cmd.ExecuteReader();
                    float finalGrade = 0;
                    while (reader.Read())
                    {
                        aux.Final_Mark_Id = int.Parse(reader[0].ToString());
                        aux.Student_id = int.Parse(reader[1].ToString());
                        aux.Subject_Id = int.Parse(reader[2].ToString());
                        aux.FinalGrade = float.Parse(reader[3].ToString());
                        aux.Semester = int.Parse(reader[4].ToString());
                    }
                    reader.Close();
                    grades.Add(aux);
                }
                return grades;

            }
            catch
            {
                MessageBox.Show("db error");
                return null;
            }
        }

        public void AddFinalMark(int subject_id, int student_id, float final_grade, int semester)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into [dbo].[Final_Mark] values (@subject_id, @student_id, @final_grade, @semester)";
                cmd.Parameters.AddWithValue("@subject_id", student_id);
                cmd.Parameters.AddWithValue("@student_id", subject_id);
                cmd.Parameters.AddWithValue("@final_grade", final_grade);
                cmd.Parameters.AddWithValue("@semester", semester);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");

            }
        }
    }
}