

using _18_SaveData.Data;
using Microsoft.EntityFrameworkCore;

namespace _18_SaveData.Topics
{
    public static class EfficientUpdating
    {
        public static void IncreasePriceWithBadScenario(AppDbContext context)
        {
            var books = context.Books.Where(x => x.AuthorId == 1);
            //bad scenario
            foreach (var i in books) //Excute update statement based on nomber of books => if books=50 excute update statement 50 times
            {
                i.Price *= 1.5m;
            }
            context.SaveChanges();
        }

        public static void IncreasePriceWithBestScenario(AppDbContext context)
        {
            context.Books.Where(x => x.AuthorId == 1)
                .ExecuteUpdate(s => s.SetProperty(p => p.Price, p => p.Price * 1.5m));
        }
    }
}
