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

                    // retrieveData(session);
                    retrieveDataById(session, 1005);
                }
            }
        }


        public static void retrieveData(ISession session) {

            var getWalletsData = session.Query<Wallet>();

            foreach (var w in getWalletsData) {
                Console.WriteLine(w);
            }
        }

        public static void retrieveDataById(ISession session,int id)
        {

            var getWalletsData = session.Query<Wallet>().FirstOrDefault(x=>x.Id == id);

            Console.WriteLine(getWalletsData);
        }
    }
}
