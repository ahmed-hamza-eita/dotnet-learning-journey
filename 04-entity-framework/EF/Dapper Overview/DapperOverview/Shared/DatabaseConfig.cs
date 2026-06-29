using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
     public class DatabaseConfig
    {
        public static SqlConnection CreateConnection()
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();

            return new SqlConnection(configuration.GetSection("DefaultConnection").Value);
        }
         

    }
}
