
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


        //For Optional Relations
        public static void SetNullDelete(AppDbContext context)
        {
            DbHelper.RecreateCleanDB();
            DbHelper.PopulateDatabase();

            //remove parent only
            var author = context.AuthorsV2.First();
            context.AuthorsV2.Remove(author);

            //remove child
            var book = context.BooksV2.First();
            // context.BooksV2.Remove(book);

            context.SaveChanges();
        }

        public static void ClearRelationships(AppDbContext context)
        {
            DbHelper.RecreateCleanDB();
            DbHelper.PopulateDatabase();

            var author = context.AuthorsV2.Include(x => x.BooksV2).First();

            author.BooksV2.Clear();
            context.SaveChanges();

        }
    }
}