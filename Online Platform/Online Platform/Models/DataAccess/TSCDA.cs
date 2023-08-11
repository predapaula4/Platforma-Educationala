using Online_Platform.Models.Entity;
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
    class TSCDA
    {
        public List<TSC> GetTSC(int classid)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {

                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [dbo].[TSC] where class_id = @classid";
                cmd.Parameters.Add("@classid", SqlDbType.Int);
                cmd.Parameters["@classid"].Value = classid;
                SqlDataReader reader = cmd.ExecuteReader();
                List<TSC> tscList = new List<TSC>();
                while (reader.Read())
                {
                    var tsc = new TSC()
                    {
                       TSC_Id= int.Parse(reader[0].ToString()),
                       Teacher_Id= int.Parse(reader[1].ToString()),
                       Class_Id= int.Parse(reader[2].ToString()),
                       Subject_Id= int.Parse(reader[3].ToString()),
                       Is_Head_Teacher= bool.Parse(reader[4].ToString()),
                       Have_Thesis= bool.Parse(reader[5].ToString()),
                      
                    };
                    tscList.Add(tsc);
                }
                reader.Close();
                return tscList;
            }
            catch
            {
                MessageBox.Show("db error");
                return null;
            }
        }

        public int GetClassIDHead(int head_teacher_id)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [dbo].[TSC] where teacher_id = @teacher_id and is_head_teacher=@is_head_teacher";
                cmd.Parameters.AddWithValue("@teacher_id", head_teacher_id);
                cmd.Parameters.AddWithValue("@is_head_teacher", true);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                return int.Parse(reader[2].ToString());
            }
            catch
            {
                MessageBox.Show("db error");
                return -1;
            }
        }

        public void ADDTsc(int teacher_id, int class_id, int subject_id, bool isHeadTeacher, bool have_thesis)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;

            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into [dbo].[TSC] Values(@teacher_id, @class_id, @subject_id, @is_head_teacher, @have_thesis)";
                cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                cmd.Parameters.AddWithValue("@class_id", class_id);
                cmd.Parameters.AddWithValue("@subject_id", subject_id);
                cmd.Parameters.AddWithValue("@is_head_teacher", isHeadTeacher);
                cmd.Parameters.AddWithValue("@have_thesis", have_thesis);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("db error");
            }
        }

        internal void ModifyTSC(int teacher_id, int class_id, int subject_id)
        {
            SqlConnection sqlConnection = Open_Connection.Connection;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update [dbo].[TSC] set teacher_id=@teacher_id where class_id=@class_id and subject_id=@subject_id";
                cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                cmd.Parameters.AddWithValue("@class_id", class_id);
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
