using System.Data.SqlClient;
using System.Data;
using CLASS_MANAGER.Models;
using CLASS_MANAGER.Data;
using System.Formats.Asn1;

namespace CLASS_MANAGER.Data
{
    public class TeachersData
    {
        public List<TeachersModel> ListTeacher()
        {
            var oTeacher = new List<TeachersModel>();

            var connection = new DataConnection();

            using (var conn = new SqlConnection(connection.GetString()))
            {
                conn.Open();
                var sqlCmd = new SqlCommand("sp_ListTeacher", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                using(var dReader = sqlCmd.ExecuteReader())
                {
                    while (dReader.Read())
                    {
                        oTeacher.Add(new TeachersModel()
                        {
                            tchID = Convert.ToInt32(dReader["tchID"]),
                            tchName = dReader["tchName"].ToString(),
                            tchLastname = dReader["tchLastname"].ToString(),
                            tchAge = dReader["tchAge"].ToString(),
                            tchCed = dReader["tchCed"].ToString(),
                            tchAddress = dReader["tchAddress"].ToString(),
                            tchTel = dReader["tchTel"].ToString(),
                            tchClass = dReader["tchClass"].ToString(),
                            tchCenter = dReader["tchCenter"].ToString(),
                        });
                    }
                }
            }
            return oTeacher;
        }

        public TeachersModel GetTeacher(int teacherID)
        {

            var oTeacher = new TeachersModel();

            var connection = new DataConnection();

            using(var conn = new SqlConnection(connection.GetString()))
            {
                conn.Open();
                var sqlCmd = new SqlCommand("sp_GetTeacher", conn);
                sqlCmd.Parameters.AddWithValue("tchID", teacherID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                    
                using(var dReader = sqlCmd.ExecuteReader())
                {
                    while (dReader.Read())
                    {
                        oTeacher.tchID = Convert.ToInt32(dReader["tchID"]);
                        oTeacher.tchName = dReader["tchName"].ToString();
                        oTeacher.tchLastname = dReader["tchLastname"].ToString();
                        oTeacher.tchAge = dReader["tchAge"].ToString();
                        oTeacher.tchCed = dReader["tchCed"].ToString();
                        oTeacher.tchAddress = dReader["tchAddress"].ToString();
                        oTeacher.tchTel = dReader["tchTel"].ToString();
                        oTeacher.tchClass = dReader["tchClass"].ToString();
                        oTeacher.tchCenter = dReader["tchCenter"].ToString();
                    }
                } 
            }
            return oTeacher;
        }

        public bool SaveTeacher(TeachersModel oTeacher)
        {
            bool ans;

            try
            {
                var connection = new DataConnection();
                using(var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_SaveTeacher", conn);
                    sqlCmd.Parameters.AddWithValue("tchName", oTeacher.tchName);
                    sqlCmd.Parameters.AddWithValue("tchLastname", oTeacher.tchLastname);
                    sqlCmd.Parameters.AddWithValue("tchAge", oTeacher.tchAge);
                    sqlCmd.Parameters.AddWithValue("tchCed", oTeacher.tchCed);
                    sqlCmd.Parameters.AddWithValue("tchAddress", oTeacher.tchAddress);
                    sqlCmd.Parameters.AddWithValue("tchTel", oTeacher.tchTel);
                    sqlCmd.Parameters.AddWithValue("tchClass", oTeacher.tchClass);
                    sqlCmd.Parameters.AddWithValue("tchCenter", oTeacher.tchCenter);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                }

                ans = true;
            }
            catch(Exception ex)
            {
                string err = ex.Message;
                return ans = false;
            }

            return ans;

        }

        public bool EditTeacher(TeachersModel oTeacher)
        {
            bool ans;

            try
            {
                var connection = new DataConnection();
                using (var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_EditTeacher", conn);
                    sqlCmd.Parameters.AddWithValue("tchID", oTeacher.tchID);
                    sqlCmd.Parameters.AddWithValue("tchName", oTeacher.tchName);
                    sqlCmd.Parameters.AddWithValue("tchLastname", oTeacher.tchLastname);
                    sqlCmd.Parameters.AddWithValue("tchAge", oTeacher.tchAge);
                    sqlCmd.Parameters.AddWithValue("tchCed", oTeacher.tchCed);
                    sqlCmd.Parameters.AddWithValue("tchAddress", oTeacher.tchAddress);
                    sqlCmd.Parameters.AddWithValue("tchTel", oTeacher.tchTel);
                    sqlCmd.Parameters.AddWithValue("tchClass", oTeacher.tchClass);
                    sqlCmd.Parameters.AddWithValue("tchCenter", oTeacher.tchCenter);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                }

                ans = true;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return ans = false;
            }

            return ans;
        
        }

        public bool DeleteTeacher (int teacherID)
        {

            bool ans;

            try
            {
                var connection = new DataConnection();
                using (var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_DeleteTeacher", conn);
                    sqlCmd.Parameters.AddWithValue("tchID",teacherID);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                }

                ans = true;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return ans = false;
            }

            return ans;


        }

    }
}
