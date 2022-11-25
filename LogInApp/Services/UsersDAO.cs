using static System.Net.Mime.MediaTypeNames;
using System;
using LogInApp.Models;
using System.Data.SqlClient;

namespace LogInApp.Services
{
    public class UsersDAO
    {

        string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Test; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    
        public bool FindUser(UserModel user)
        {
            bool sucess = false;

            string sqlStatement = "SELECT * FROM dbo.Users WHERE USERNAME = @username AND PASSWORD = @password";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        sucess = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return sucess;
        }
    
    }
}
