using System.Data.SqlClient;
using System.Data;
using CLASS_MANAGER.Models;
using System.Security.Cryptography.X509Certificates;
using Microsoft.CodeAnalysis;
using System.Reflection.Metadata;

namespace CLASS_MANAGER.Data
{
    public class UsersData
    {

        public UserModel ValidateUser (UserModel oUser)
        {
            UserModel isUser = new UserModel();

            try
            {
                var connection = new DataConnection();


                using(var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    SqlCommand sqlCmd= new SqlCommand("sp_Validate",conn);
                    sqlCmd.Parameters.AddWithValue("UserName", oUser.UserName);
                    sqlCmd.Parameters.AddWithValue("UserPassword", oUser.UserPassword);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    using (var dReader = sqlCmd.ExecuteReader())
                    {
                        if (dReader.Read()){

                            isUser.UserName = dReader["UserName"].ToString();
                            isUser.Email = dReader["Email"].ToString();
                            isUser.UserRole = dReader["UserRole"].ToString();
                            conn.Close();
                        }                                            
                                                                 
                    }                    
                 
                }
            }
            catch(Exception ex)
            {
                string err = ex.Message;
                 
            }

            return isUser;
            
            
        }

        public UserModel GetUser(int userID)
        {
            UserModel oUser = new UserModel();

            try
            {
                var connection = new DataConnection();

                using(var conn= new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_GetUser", conn);
                    sqlCmd.Parameters.AddWithValue("UserID",userID);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    using (var dReader = sqlCmd.ExecuteReader())
                    {
                        while (dReader.Read())
                        {
                            oUser.UserID = Convert.ToInt32(dReader["UserID"]);
                            oUser.UserName = dReader["UserName"].ToString();
                            oUser.UserPassword = dReader["UserPassword"].ToString();
                            oUser.UserRole = dReader["UserRole"].ToString();
                            oUser.Name = dReader["Name"].ToString();
                            oUser.Lastname = dReader["Lastname"].ToString();
                            oUser.Age = dReader["Age"].ToString();
                            oUser.Cedula = dReader["Cedula"].ToString();
                            oUser.Address = dReader["Address"].ToString();
                            oUser.Email = dReader["Email"].ToString();
                            oUser.Telephone = dReader["Telephone"].ToString();
                            oUser.Shift = dReader["Shift"].ToString();
                            oUser.Center = dReader["Center"].ToString();

                        }
                    }
                }
            }catch (Exception ex)
            {
                string err = ex.Message;                             
                
            }
            return oUser;

        }

        public bool DeleteUser(UserModel oUser)
        {
            bool ans;

            try
            {
                var connection = new DataConnection();
                using (var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_DeleteUser", conn);
                    sqlCmd.Parameters.AddWithValue("UserID", oUser.UserID);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();

                }
                ans = true;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                ans = false;
            }

            return ans;
        }
        
        public bool SoftDelete(int userID)
        {
            bool ans;

            try
            {
                var connection = new DataConnection();

                using (var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_SoftDeleteUser", conn);
                    sqlCmd.Parameters.AddWithValue("UserID", userID);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                }
                ans = true;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                ans = false;
            }

            return ans;
        }

        public bool SaveUser(UserModel oUser)
        {
            bool ans;

            try
            {
                var connection = new DataConnection();

                using (var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_SaveUser", conn);
                    sqlCmd.Parameters.AddWithValue("UserName", oUser.UserName);
                    sqlCmd.Parameters.AddWithValue("UserPassword", oUser.UserPassword);
                    sqlCmd.Parameters.AddWithValue("UserRole", oUser.UserRole);
                    sqlCmd.Parameters.AddWithValue("Name", oUser.Name);
                    sqlCmd.Parameters.AddWithValue("Lastname", oUser.Lastname);
                    sqlCmd.Parameters.AddWithValue("Age", oUser.Age);
                    sqlCmd.Parameters.AddWithValue("Cedula", oUser.Cedula);
                    sqlCmd.Parameters.AddWithValue("Address", oUser.Address);
                    sqlCmd.Parameters.AddWithValue("Email", oUser.Email);
                    sqlCmd.Parameters.AddWithValue("Telephone", oUser.Telephone);
                    sqlCmd.Parameters.AddWithValue("Shift", oUser.Shift);
                    sqlCmd.Parameters.AddWithValue("Center", oUser.Center);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();

                }
                ans = true;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                ans = false;
            }
            return ans;
        }

        public bool EditUser(UserModel oUser)
        {
            bool ans;
            try
            {
                var connection = new DataConnection();
                using (var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_EditUser", conn);
                    sqlCmd.Parameters.AddWithValue("UserID", oUser.UserID);
                    sqlCmd.Parameters.AddWithValue("UserName", oUser.UserName);
                    sqlCmd.Parameters.AddWithValue("UserPassword", oUser.UserPassword);
                    sqlCmd.Parameters.AddWithValue("UserRole", oUser.UserRole);
                    sqlCmd.Parameters.AddWithValue("Name", oUser.Name);
                    sqlCmd.Parameters.AddWithValue("Lastname", oUser.Lastname);
                    sqlCmd.Parameters.AddWithValue("Age", oUser.Age);
                    sqlCmd.Parameters.AddWithValue("Cedula", oUser.Cedula);
                    sqlCmd.Parameters.AddWithValue("Address", oUser.Address);
                    sqlCmd.Parameters.AddWithValue("Email", oUser.Email);
                    sqlCmd.Parameters.AddWithValue("Telephone", oUser.Telephone);
                    sqlCmd.Parameters.AddWithValue("Shift", oUser.Shift);
                    sqlCmd.Parameters.AddWithValue("Center", oUser.Center);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                }
                ans = true;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                ans = false;
            }

            return ans;
        }
        public List<UserModel> ListUsers()
        {
            var oUser = new List<UserModel>();

            var connection = new DataConnection();

            using (var conn = new SqlConnection(connection.GetString()))
            {
                conn.Open();
                var sqlCmd = new SqlCommand("sp_ListUser", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                using (var dReader = sqlCmd.ExecuteReader())
                {
                    while (dReader.Read())
                    {
                        oUser.Add(new UserModel()
                        {
                            UserID = Convert.ToInt32(dReader["UserID"]),
                            UserName = dReader["UserName"].ToString(),
                            UserPassword = dReader["UserPassword"].ToString(),
                            UserRole = dReader["UserRole"].ToString(),
                            Name = dReader["Name"].ToString(),
                            Lastname = dReader["Lastname"].ToString(),
                            Age = dReader["Age"].ToString(),
                            Cedula = dReader["Cedula"].ToString(),
                            Address = dReader["Address"].ToString(),
                            Email = dReader["Email"].ToString(),
                            Telephone = dReader["Telephone"].ToString(),
                            Shift = dReader["Shift"].ToString(),
                            Center = dReader["Center"].ToString()
                        });
                    }
                }

            }
            return oUser;
        }
    
    ///==========THESE METHODS ARE TO HANDLE TO LIST AND EDIT TEACHERS LIMITEDLY===========>>>>>>>>>>
    public List<UserModel> ListTeachers()
        {
            var oUser = new List<UserModel>();

            var connection = new DataConnection();

            using (var conn = new SqlConnection(connection.GetString()))
            {
                conn.Open();
                var sqlCmd = new SqlCommand("sp_ListTeachers", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                using(var dReader = sqlCmd.ExecuteReader())
                {
                    while (dReader.Read())
                    {
                        oUser.Add(new UserModel
                        {
                            UserID =Convert.ToInt32 (dReader["UserID"]),
                            UserName = dReader["UserName"].ToString(),
                            Name = dReader["Name"].ToString(),
                            Lastname = dReader["Lastname"].ToString(),
                            Age = dReader["Age"].ToString(),
                            Cedula = dReader["Cedula"].ToString(),
                            Address = dReader["Address"].ToString(),
                            Email = dReader["Email"].ToString(),
                            Telephone = dReader["Telephone"].ToString(),
                            Shift = dReader["Shift"].ToString(),
                            Center = dReader["Center"].ToString()
                        }) ;
                    }
                }
            }
            return oUser;

        }        

    public bool EditTeacher(UserModel oTeacher)
        {
            bool ans;

            var connection = new DataConnection();

            try
            {
                using(var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();

                    var sqlCmd = new SqlCommand("sp_EditTeacher", conn);
                    sqlCmd.Parameters.AddWithValue("UserID", oTeacher.UserID);
                    sqlCmd.Parameters.AddWithValue("UserName", oTeacher.UserName);
                    sqlCmd.Parameters.AddWithValue("Name", oTeacher.Name);
                    sqlCmd.Parameters.AddWithValue("Lastname", oTeacher.Lastname);
                    sqlCmd.Parameters.AddWithValue("Age", oTeacher.Age);
                    sqlCmd.Parameters.AddWithValue("Cedula", oTeacher.Cedula);
                    sqlCmd.Parameters.AddWithValue("Address", oTeacher.Address);
                    sqlCmd.Parameters.AddWithValue("Email", oTeacher.Email);
                    sqlCmd.Parameters.AddWithValue("Telephone", oTeacher.Telephone);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                } 

                ans = true;
            }catch(Exception ex)
            {
                string err = ex.Message;
                ans = false;
            }

            return ans;
        }            
    } 
}
