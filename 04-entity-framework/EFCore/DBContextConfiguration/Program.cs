using DBContextConfiguration.Configuration;
using DBContextConfiguration.Configuration.ExternalConfiguration;
using DBContextConfiguration.Configuration.UsingContextFactory;
using DBContextConfiguration.Configuration.UsingDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared;
using Shared.Models;
namespace DBContextConfiguration
{
    class Program
    {
        private static IDbContextFactory<Configuration.UsingContextFactory.AppDbContext> _factory;
        static async Task Main(string[] args)
        {
            //InternalConfiguration
            //   InternalConfiguration();

            //ExternalConfiguration
            //  ExternalConfiguration();

            //use DI
            // DIConfiguration();

            //Use ContextFactory 
            // ContextFactoryConfiguration();

            //DBContext and concurrency
            _factory = DbContextFactoryProvider.CreateFactory<Configuration.UsingContextFactory.AppDbContext>();
            await DBContextAndConcurrency();

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
            var container = DIService.BuildDIServive<Configuration.UsingDependencyInjection.AppDbContext>();

            using (var context = container.GetService<Configuration.UsingDependencyInjection.AppDbContext>())
            {
                foreach (var w in context!.wallets)
                {
                    Console.WriteLine(w);
                }
            }
        }

        public static void ContextFactoryConfiguration()
        {
            var factory = DbContextFactoryProvider.CreateFactory<Configuration.UsingContextFactory.AppDbContext>();
            using (var context = factory.CreateDbContext())
            {
                foreach (var w in context.wallets)
                {
                    Console.WriteLine(w);
                }
            }
        }

        public static async Task DBContextAndConcurrency()
        {
            var tasks = new[] {
            Task.Run(()=>job1()),
            Task.Run(()=>job2()),
            Task.Run(()=>job3())
            };

            await Task.WhenAll(tasks);

            Console.WriteLine("job1, job2 and job3 are excuted");

        }
        public static async Task job1()
        {
            using (var context = _factory.CreateDbContext())
            {
                var w1 = new Wallet { Holder = "AAAA", Balance = 50m };
                context.wallets.Add(w1);
                await context.SaveChangesAsync();
            }
        }
        public static async Task job2()
        {
            using (var context = _factory.CreateDbContext())
            {
                var w2 = new Wallet { Holder = "sssss", Balance = 590m };
                context.wallets.Add(w2);
                await context.SaveChangesAsync();
            }
        }
        public static async Task job3()
        {
            using (var context = _factory.CreateDbContext())
            {
                foreach (var i in context.wallets)
                {
                    Console.WriteLine(i);
                }

            }
        }

    }
}
