using Shared.DBConfiguration;

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
                getDataById(context,1022);
            }

        }

        public static void getData(AppDbContext context)
        {

            foreach (var wallet in context.Wallets)
            {
                Console.WriteLine(wallet);
            }
        }

        public static void getDataById(AppDbContext context,int id)
        {

            var item = context.Wallets.FirstOrDefault(x=>x.Id == id);
            Console.WriteLine(item);
        }
    }
}
