using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Shared;
using System.Data;
namespace _01_ExcuteRawSql
{
    internal class Program
    {
        static void Main(string[] args)
        {

            {
                //create connection
                var sqlConnection = DatabaseConfig.CreateConnection();

                //Excute Raw Sql
                rawSql(sqlConnection);

               

            }

        }

        public static void rawSql(SqlConnection sqlConnection) {
            //select query
            var sqlQuery = "SELECT * FROM WALLETS";
            //excute query
            var wallets = sqlConnection.Query<Wallet>(sqlQuery);
            //show resulys
            foreach (var item in wallets)
            {
                Console.WriteLine(item);
            }
        }

    }
}
