using NHibernate;
using Shared.Models;
using Shared.Session;
namespace Nhibernate_Overview
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var session = CreateSession._CreateSession())
            {
                Console.WriteLine($"Conntected: {session.IsConnected}");
                using (var transaction = session.BeginTransaction())
                {
                    //excute select statement
                    retrieveData(session);
                }
            }
        }


        public static void retrieveData(ISession session) {

            var getWalletsData = session.Query<Wallet>();

            foreach (var w in getWalletsData) {
                Console.WriteLine(w);
            }
        }
    }
}
