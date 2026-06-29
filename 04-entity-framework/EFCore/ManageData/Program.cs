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
    }
}
