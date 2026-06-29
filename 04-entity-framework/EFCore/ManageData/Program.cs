using Shared.DBConfiguration;
using Shared.Models;

namespace ManageData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                //Retrieve data (select statement)
                //getData(context);
                //Retrieve specific data (select statement)
                //getDataById(context, 1022);

                //insert
                //insertData(context, new Wallet { Holder = "Fettouh", Balance = 10m });

                //update
                //updateData(context, 1005);

                //Delete
                //deleteData(context, 1005);

                queryData(context);
            }

        }

        public static void getData(AppDbContext context)
        {

            foreach (var wallet in context.Wallets)
            {
                Console.WriteLine(wallet);
            }
        }

        public static void getDataById(AppDbContext context, int id)
        {

            var item = context.Wallets.FirstOrDefault(x => x.Id == id);
            Console.WriteLine(item);
        }

        public static void insertData(AppDbContext context, Wallet wallet)
        {
            context.Wallets.Add(wallet);
            context.SaveChanges();
        }

        public static void updateData(AppDbContext context, int id)
        {

            var updateWallet = context.Wallets.SingleOrDefault(x => x.Id == id);
            updateWallet.Balance += 10000;
            updateWallet.Holder = "Ali";
            context.SaveChanges();
        }

        public static void deleteData(AppDbContext context, int id)
        {
            var getWalletToRemove = context.Wallets.Single(X => X.Id == id);
            context.Remove(getWalletToRemove);
            context.SaveChanges();
        }

        public static void queryData(AppDbContext context) {
            var result = context.Wallets.Where(x=>x.Balance >=500000);

            foreach (var i in result) {
                Console.WriteLine(i);
            }
        }
    }
}
