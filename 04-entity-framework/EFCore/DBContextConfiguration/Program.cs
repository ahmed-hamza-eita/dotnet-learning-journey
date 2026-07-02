using DBContextConfiguration.Configuration;
using DBContextConfiguration.Configuration.ExternalConfiguration;
using DBContextConfiguration.Configuration.UsingDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Shared;
using Shared.Models;
namespace DBContextConfiguration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //InternalConfiguration
            //   InternalConfiguration();

            //ExternalConfiguration
            //  ExternalConfiguration();

            //use DI
            DIConfiguration();
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

        public static void ExternalConfiguration()
        {
            var dbOptions = Builder.Build();
            using (var context = new ExternalConfiguration(dbOptions))
            {
                foreach (var w in context.wallets)
                {

                    Console.WriteLine(w);
                }
            }
        }

        public static void DIConfiguration()
        {
            var container = Services.BuildServiceProvider<AppDbContext>();

            using (var context = container.GetService<AppDbContext>())
            {
                foreach (var w in context.wallets)
                {
                    Console.WriteLine(w);
                }
            }
        }
    }
}
