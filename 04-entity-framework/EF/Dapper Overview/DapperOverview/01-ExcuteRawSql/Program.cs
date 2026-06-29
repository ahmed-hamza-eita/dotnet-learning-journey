using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens.Experimental;
using Shared;
using System.Data;
using System.Transactions;
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
                // rawSql(sqlConnection);

                //Insert Statement
                //insertStatement(sqlConnection, new Wallet {Holder = "Waleed" , Balance = 45000m });

                //Insert Statement with id
                // insertStatementReturnedId(sqlConnection, new Wallet {Holder = "hamo" , Balance = 450000m });

                //Update Statement
                //updateStatement(sqlConnection, new Wallet { Id = 1020, Holder = "ZZZZZZZz", Balance = 102031m });

                //Delete Statement
                //deleteStatement(sqlConnection,new Wallet {Id=1020 });

                //Excute Multi statements (Single Batch)
                // multiStatements(sqlConnection);


                //Transaction
                transaction(sqlConnection);
 
            }

        }

        public static void rawSql(SqlConnection sqlConnection)
        {
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
        public static void insertStatement(SqlConnection sqlConnection, Wallet wallet)
        {
            var sqlQuery = "INSERT INTO Wallets (Holder,Balance) " +
                "VALUES (@Holder , @Balance)";

            sqlConnection.Execute(sqlQuery, new
            {
                Holder = wallet.Holder,
                Balance = wallet.Balance
            });
        }


        public static void insertStatementReturnedId(SqlConnection sqlConnection, Wallet wallet)
        {
            var sqlQuery = "INSERT INTO Wallets (Holder,Balance) " +
                "VALUES (@Holder , @Balance)" +
                "SELECT CAST(SCOPE_IDENTITY() AS INT)";

            var parmeters = new
            {
                Holder = wallet.Holder,
                Balance = wallet.Balance
            };

            wallet.Id = sqlConnection.Query<int>(sqlQuery, parmeters).Single();
            Console.WriteLine(wallet);
        }

        public static void updateStatement(SqlConnection sqlConnection, Wallet wallet)
        {

            var sqlQuery = "UPDATE WALLETS SET Holder=@Holder , Balance=@Balance " +
                "WHERE Id=@Id";

            var parameters = new
            {
                Id = wallet.Id,
                Holder = wallet.Holder,
                Balance = wallet.Balance
            };

            sqlConnection.Execute(sqlQuery, parameters);

        }

        public static void deleteStatement(SqlConnection sqlConnection, Wallet wallet)
        {

            var sqlQuery = "DELETE FROM WALLETS WHERE Id=@Id ";

            var parameters = new
            {
                Id = wallet.Id
            };

            sqlConnection.Execute(sqlQuery, parameters);
        }

        public static void multiStatements(SqlConnection sqlConnection)
        {
            var sqlQuery = "SELECT MIN(Balance) FROM WALLETS " +
                "SELECT MAX(Balance) FROM WALLETS ";

            var result = sqlConnection.QueryMultiple(sqlQuery);

            Console.WriteLine($"Min= {result.Read<Decimal>().Single()}" + $"\nMax= {result.Read<Decimal>().Single()}");


        }

        public static void transaction(SqlConnection sqlConnection)
        {
            //transfer  from 1002 to 1005 amount 2000m

            decimal amount = 2000m;
            using (var transactionScope = new TransactionScope())
            {
                //from 
                var transferFrom = sqlConnection.QuerySingle("Select * From Wallets Where Id=@ID", new { Id = 1002 });
                //to
                var transferTo = sqlConnection.QuerySingle("Select * From Wallets Where Id=@Id", new { Id = 1005 });


                sqlConnection.Execute("Update Wallets Set Balance = @Balance Where Id =@Id", new
                {
                    Id = transferFrom.Id,
                    Balance = transferFrom.Balance - amount
                });

                sqlConnection.Execute("Update Wallets Set Balance = @Balance Where Id =@Id", new
                {
                    Id = transferTo.Id,
                    Balance = transferTo.Balance + amount
                });
                transactionScope.Complete();
            }
        }
    }
}
