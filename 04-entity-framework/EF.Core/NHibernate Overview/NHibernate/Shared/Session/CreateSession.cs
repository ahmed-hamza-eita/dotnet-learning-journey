using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using Shared.Models;


namespace Shared.Session
{
    public class CreateSession
    {
        public static ISession _CreateSession()
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();

            var connectionString = configuration.GetSection("DefaultConnection").Value;


            var mapper = new ModelMapper();

            mapper.AddMappings(typeof(Wallet).Assembly.ExportedTypes);

            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var hbConfig = new Configuration();

            hbConfig.DataBaseIntegration(c =>
            {
                c.Driver<MicrosoftDataSqlClientDriver>();
                c.Dialect<MsSql2012Dialect>();
                c.ConnectionString = connectionString;
                c.LogSqlInConsole = true;
                c.LogFormattedSql = true;
            });

            hbConfig.AddMapping(domainMapping);

            var sessionFactory = hbConfig.BuildSessionFactory();
            var openSession = sessionFactory.OpenSession();

            return openSession;
        }
    }
}
