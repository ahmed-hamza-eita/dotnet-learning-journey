using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq.Expressions;
using System.Transactions;

namespace _08_ExecuteTransaction
{
    internal class Program
    {
        static void Main(string[] args)
        {
             var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            using var  sqlConnection = new SqlConnection(configuration.GetSection("DefaultConnection").Value);

            using var sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;

            sqlConnection.Open();
            
            using var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            try
            {
                sqlCommand.CommandText = "UPDATE Wallets Set Balance = Balance - 1000 Where Id = 2";
                sqlCommand.ExecuteNonQuery();


                sqlCommand.CommandText = "UPDATE Wallets Set Balance = Balance + 1000 Where Id = 3";
                sqlCommand.ExecuteNonQuery();

                sqlTransaction.Commit();

                Console.WriteLine("Transaction of transfer completed successfully");

            }
            catch
            {
                try
                {
                    sqlTransaction.Rollback();
                }
                catch
                {
                    // log errors
                }
            }
            finally
            {

                try
                {
                    sqlConnection.Close();
                }
                catch
                {
                    // log errors

                }
            }


        }
    }
}
