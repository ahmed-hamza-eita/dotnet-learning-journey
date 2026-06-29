using Microsoft.Extensions.Configuration;

namespace _01_ConfigureConnection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            Console.WriteLine(configuration.GetSection("DefaultConnection").Value);
        }
    }
}
 