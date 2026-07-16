using _18_SaveData.Data;
using _18_SaveData.Entities;
using _18_SaveData.Utils;

namespace _18_SaveData.Topics
{
    public static class  BasicSave
    {
        public static void RunBasicSave(AppDbContext context)
        {
            DbHelper.RecreateCleanDB();
            var newAuthor = new Author { Id = 1, FName = "ahmed", LName = "Hamza" };
            context.Authors.Add(newAuthor);
            context.SaveChanges();
        }

        public static void RunBasicUpdate(AppDbContext context)
        {
            var updateAuthor = context.Authors.FirstOrDefault(x => x.Id == 1);
            updateAuthor.FName = "AHMED";
            context.SaveChanges();
        }
        public static void RunBasicDelete(AppDbContext context)
        {
            var deleteAuthor = context.Authors.FirstOrDefault(x => x.Id == 1);
            context.Remove(deleteAuthor);
            context.SaveChanges();
        }
        public static void RunMultipleOperationsWithSingleSave(AppDbContext context)
        {
            var au1 = new Author { Id = 1, FName = "Ahmed", LName = "Hamza" };
            context.Authors.Add(au1);
            var au2 = new Author { Id = 2, FName = "Walid", LName = "Mohamed" };
            context.Authors.Add(au2);
            var au3 = new Author { Id = 3, FName = "Hakim", LName = "Ali" };
            context.Authors.Add(au3);

            context.SaveChanges();
        }
       public static void RunAddRelatedEntities(AppDbContext context)
        {
            var author1 = context.Authors.FirstOrDefault(x => x.Id == 1);
            author1.Books.Add(new Book
            {
                Id = 1,
                Title = "New Book"
            });
            context.SaveChanges();
        }
    }
}
