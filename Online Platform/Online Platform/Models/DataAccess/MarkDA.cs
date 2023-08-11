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
    class MarksDA
    {
        public Dictionary<string, List<Mark>> GetMarks(int student_id, List<Subject> subjects)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {

                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [dbo].[Mark] where student_id = @student_id and subject_id = @subject_id";
                cmd.Parameters.Add("@student_id", SqlDbType.Int);
                cmd.Parameters.Add("@subject_id", SqlDbType.Int);
                cmd.Parameters["@student_id"].Value = student_id;
                Dictionary<string, List<Mark>> grades = new Dictionary<string, List<Mark>>();
                foreach (var subject in subjects)
                {

                    cmd.Parameters["@subject_id"].Value = subject.Subject_id;
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Mark> gradeList = new List<Mark>();
                    while (reader.Read())
                    {
                        var grade = new Mark() { 
                            Mark_Id = int.Parse(reader[0].ToString()),
                            Subject_Id = int.Parse(reader[1].ToString()),
                            Student_id = int.Parse(reader[2].ToString()),
                            Grade = float.Parse(reader[3].ToString()),
                            Semester = int.Parse(reader[4].ToString()),
                            IsThesisMark = bool.Parse(reader[5].ToString())
                        };
                        gradeList.Add(grade);
                    }
                    grades.Add(subject.Name, gradeList);
                    reader.Close();
                }
                return grades;

            }
            catch
            {
                MessageBox.Show("db error");
                return null;
            }
        }

        internal void AddGrade(int student_id, int subject_id, int semester, int grade, bool isThesisMark = false)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into [dbo].[Mark] values (@subject_id, @student_id, @grade, @semester, @isThesisMark)";
                cmd.Parameters.AddWithValue("@subject_id", student_id);
                cmd.Parameters.AddWithValue("@student_id", subject_id);
                cmd.Parameters.AddWithValue("@grade", grade);
                cmd.Parameters.AddWithValue("@semester", semester);
                cmd.Parameters.AddWithValue("@isThesisMark", isThesisMark);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");
            }
        }

        internal void DeleteMark(int mark_id)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from [dbo].[Mark] where mark_id=@mark_id";
                cmd.Parameters.AddWithValue("@mark_id", mark_id);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");
            }
        }
    }
}
