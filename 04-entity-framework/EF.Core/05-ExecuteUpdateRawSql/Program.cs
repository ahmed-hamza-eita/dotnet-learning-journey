using _02_ExcuteRawSQL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace _05_ExecuteUpdateRawSql
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
             
            var sqlQuery = "UPDATE Wallets SET Holder = @Holder, Balance = @Balance " +
                $"WHERE Id = @Id";

            SqlParameter idParameter = new SqlParameter
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = 1
            };

            SqlParameter holderParameter = new SqlParameter
            {
                ParameterName = "@Holder",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = "Hakim"
            };
            

            SqlParameter balanceParameter = new SqlParameter
            {
                ParameterName = "@Balance",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                Value = 7500
            };

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlCommand.Parameters.Add(idParameter);
            sqlCommand.Parameters.Add(holderParameter);
            sqlCommand.Parameters.Add(balanceParameter);

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
