using InitialMigration.Data;
using InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;

namespace InitialMigration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var participant1 = new Individual
            {
                Id = 3,
                FName = "Ahmad",
                LName = "Ali",
                University = "JUST",
                YearOfGraduation = 2024,
                IsIntern = false
            };

            var participant2 = new Coporate
            {
                Id = 4,
                FName = "Ahmad",
                LName = "Ali",
                Company = "Metigator",
                JobTitle = "Developer"
            };

            using (var context = new AppDbContext())
            {

                context.Participants.Add(participant1);
                context.Participants.Add(participant2);
                context.SaveChanges();
            }
        }
    }
}
