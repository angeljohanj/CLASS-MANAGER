using System.Data.SqlClient;
using System.Data;
using CLASS_MANAGER.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using CLASS_MANAGER.Controllers;

namespace CLASS_MANAGER.Data
{
    public class StudentsData
    {
         
        public List<StudentsModel> StuList()
        {
            var oStu = new List<StudentsModel>();

            var connection = new DataConnection();

            using (var conn = new SqlConnection(connection.GetString()))
            {
                conn.Open();

                var sqlCmd = new SqlCommand("sp_ListStu", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                using (var dReader = sqlCmd.ExecuteReader())
                {
                    while (dReader.Read())
                    {
                        oStu.Add(new StudentsModel()
                        {
                            StudentID = Convert.ToInt32(dReader["StudentID"]),
                            StuName = dReader["StuName"].ToString(),
                            StuLast = dReader["StuLast"].ToString(),
                            StuMail = dReader["StuMail"].ToString(),
                            StuCed = dReader["StuCed"].ToString(),
                        }) ;
                    }
                    conn.Close();
                }
            }

            return oStu;

        }

        

        public StudentsModel GetStu(int studentID)
        {
            var oStu = new StudentsModel();

            var connection = new DataConnection();
            using(var conn =new SqlConnection(connection.GetString()))
            {
                conn.Open();
                var sqlCmd = new SqlCommand("sp_GetStu", conn);
                sqlCmd.Parameters.AddWithValue("StudentID", studentID);
                sqlCmd.CommandType= CommandType.StoredProcedure;

                using (var dReader = sqlCmd.ExecuteReader())
                {
                    while (dReader.Read())
                    {
                        oStu.StudentID = Convert.ToInt32(dReader["StudentID"]);
                        oStu.StuName = dReader["StuName"].ToString();
                        oStu.StuLast = dReader["StuLAst"].ToString();
                        oStu.StuMail = dReader["StuMail"].ToString();
                        oStu.StuCed = dReader["StuCed"].ToString();
                    }
                }
            }
            return oStu;
        }

        public bool SaveStu(StudentsModel oStu)
        {
            bool ans;

            try
            {
                var connection = new DataConnection();

                using(var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();

                    var sqlCmd = new SqlCommand("sp_SaveStu", conn);
                    sqlCmd.Parameters.AddWithValue("StuName", oStu.StuName);
                    sqlCmd.Parameters.AddWithValue("StuLast", oStu.StuLast);
                    sqlCmd.Parameters.AddWithValue("StuMail", oStu.StuMail);
                    sqlCmd.Parameters.AddWithValue("StuCed", oStu.StuCed);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();

                    ans = true;
                }
            }catch(Exception ex)
            {
                string err = ex.Message;
                ans = false;

            }
            return ans;


        }

        public bool EditStu (StudentsModel oStu)
        {
            bool ans;

            try
            {
                var connection = new DataConnection();
                using (var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_StuEdit", conn);
                    sqlCmd.Parameters.AddWithValue("StudentID", oStu.StudentID);
                    sqlCmd.Parameters.AddWithValue("stuName", oStu.StuName);
                    sqlCmd.Parameters.AddWithValue("StuLast", oStu.StuLast);
                    sqlCmd.Parameters.AddWithValue("StuMail", oStu.StuMail);
                    sqlCmd.Parameters.AddWithValue("StuCed", oStu.StuCed);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery ();

                }

                ans = true;                
            }
            catch(Exception ex)
            {
                string err = ex.Message;
                ans = false;
            }
            return ans;

        }
        public bool StuDel(int studentID) { 
       
            bool ans;

            try
            {
                var connection = new DataConnection();
                using (var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_DelStu", conn);
                    sqlCmd.Parameters.AddWithValue("StudentID",studentID);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                    ans = true;
                }
                               
            }
            catch(Exception ex)
            {
                string err= ex.Message;
                ans=false;
            }
            return ans;
        }

    }
}
