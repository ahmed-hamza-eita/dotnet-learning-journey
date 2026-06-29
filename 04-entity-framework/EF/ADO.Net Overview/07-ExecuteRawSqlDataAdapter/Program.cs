using _02_ExcuteRawSQL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace _07_ExecuteRawSqlDataAdapter
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

            var sqlQuery = "SELECT * FROM WALLETS";

            sqlConnection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery,sqlConnection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            sqlConnection.Close();
            foreach (DataRow dt in dataTable.Rows) {
                var wallet = new Wallet
                {
                    Id = Convert.ToInt32(dt["Id"]),
                    Holder = Convert.ToString(dt["Holder"]),
                    Balance = Convert.ToDecimal(dt["Balance"])

                };

                Console.WriteLine(wallet);
            }

            Console.ReadKey();
        }
    }
}
