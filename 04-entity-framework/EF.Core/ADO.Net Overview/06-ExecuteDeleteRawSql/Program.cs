using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace _06_ExecuteDeleteRawSql
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Connection String 
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            SqlConnection sqlConnection = new SqlConnection(configuration.GetSection("DefaultConnection").Value);

            var sqlQuery = "DELETE FROM  Wallets " +
                $"WHERE Id = @Id";

            SqlParameter idParameter = new SqlParameter
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = 1
            };

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlCommand.Parameters.Add(idParameter);
           

            sqlCommand.CommandType = CommandType.Text;

            sqlConnection.Open();

            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($"wallet Updated successfully");
            }
            else
            {
                Console.WriteLine($"ERROR");
            }
        }
    }
}
