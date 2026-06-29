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
                getDataById(context, 1022);

                //insert
                insertData(context, new Wallet { Holder = "Fettouh", Balance = 10m });
                getData(context);

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
    }
}
