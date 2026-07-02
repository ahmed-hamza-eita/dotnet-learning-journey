using DBContextConfiguration.Configuration;
using Shared;
using Shared.Models;
namespace DBContextConfiguration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //InternalConfiguration
            InternalConfiguration();
        }

        public static void InternalConfiguration()
        {
            using (var context = new InternalConfiguration())
            {
                foreach (var w in context.wallets)
                {

                    Console.WriteLine(w);
                }
            }
        }
    }
}
