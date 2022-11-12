using System.Data.SqlClient;

namespace CLASS_MANAGER.Data
{
    public class DataConnection
    {
       private string sqlString = String.Empty;

        public DataConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            sqlString = builder.GetSection("ConnectionStrings:SqlString").Value;
        }

        public string GetString()
        {
            return sqlString;
        }
    }
}
