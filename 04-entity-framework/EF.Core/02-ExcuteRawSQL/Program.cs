using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace _02_ExcuteRawSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            SqlConnection sqlConnection = new SqlConnection(configuration.GetSection("DefaultConnection").Value);

            var sqlQuery = "SELECT * FROM WALLETS";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery,sqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            Wallet wallet;
            while (reader.Read()) {
                wallet = new Wallet
                {
                    Id = reader.GetInt32("Id"),
                    Holder = reader.GetString("Holder"),
                    Balance = reader.GetDecimal("Balance")
                };

                Console.WriteLine(wallet);

            }

            sqlConnection.Close();
            Console.ReadKey();
        }
    }
}
