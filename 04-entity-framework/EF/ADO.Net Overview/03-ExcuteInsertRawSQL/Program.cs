using _02_ExcuteRawSQL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExcuteInsertRawSQL
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
            //read from user 
            var InsertToWallet = new Wallet
            {
                Holder = "Hamza",
                Balance = 6000
            };
            var sqlQuery = "INSERT INTO WALLETS (Holder, Balance) VALUES " +
                $"(@Holder, @Balance)" +
                $"SELECT CAST(scope_identity() AS int)";
            SqlParameter holderParameter = new SqlParameter
            {
                ParameterName = "@Holder",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = InsertToWallet.Holder
            };
            SqlParameter balanceParameter = new SqlParameter
            {
                ParameterName = "@Balance",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                Value = InsertToWallet.Balance
            };
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.Parameters.Add(holderParameter);
            sqlCommand.Parameters.Add(balanceParameter);
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();
            InsertToWallet.Id = (int)sqlCommand.ExecuteScalar();
            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($"wallet for {InsertToWallet.Id} {InsertToWallet.Holder} added successully");
            }
            else
            {
                Console.WriteLine($"ERROR: wallet for {InsertToWallet.Holder} was not added");
            }

            sqlConnection.Close();
        }
    }
}