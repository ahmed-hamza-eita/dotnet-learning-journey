
using _18_SaveData.Data;
using _18_SaveData.Entities;
using _18_SaveData.Utils;
using Microsoft.EntityFrameworkCore;

namespace _18_SaveData.Topics
{
    public static class CascadeDelete
    {
        public static void CascadeDeleteScenario(AppDbContext context)
        {
            DbHelper.RecreateCleanDB();
            DbHelper.PopulateDatabase();

            var author = context.Authors.Include(x => x.Books).First();

            context.Remove(author);
            context.SaveChanges();
        }
    }
}
