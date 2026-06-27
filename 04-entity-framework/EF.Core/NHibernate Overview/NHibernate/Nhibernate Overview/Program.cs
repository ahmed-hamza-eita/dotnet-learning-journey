using Shared.Session;
namespace Nhibernate_Overview
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(  var session = CreateSession._CreateSession()) {
                Console.WriteLine(session.IsConnected);
            }
        }
    }
}
