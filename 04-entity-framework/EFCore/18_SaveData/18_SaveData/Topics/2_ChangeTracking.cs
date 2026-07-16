using _18_SaveData.Data;
using _18_SaveData.Entities;


namespace _18_SaveData.Topics
{
    public static class ChangeTracking
    {
        public static void AddState(AppDbContext context)
        {
            var book = new Book { Id = 10, Title = "Clean Architecture", AuthorId = 2 };
            Console.WriteLine(context.Entry(book).State); //Deattach

            context.Books.Add(book); // Added
            Console.WriteLine(context.Entry(book).State);

            context.SaveChanges();
            Console.WriteLine(context.Entry(book).State); //Unchanged
        }

        public static void ModifyState(AppDbContext context)
        {
            var getBook = context.Books.Find(10);
            Console.WriteLine(context.Entry(getBook).State); //Unchanged

            getBook.Title = "Updated title";
            Console.WriteLine(context.Entry(getBook).State); //Modified

            context.SaveChanges();
            Console.WriteLine(context.Entry(getBook).State); //Unchanged
        }

        public static void DeleteState(AppDbContext context)
        {
            var getBook = context.Books.Find(10);
            Console.WriteLine(context.Entry(getBook).State); //Unchanged

            context.Remove(getBook);
            Console.WriteLine(context.Entry(getBook).State); //Deleted

            context.SaveChanges();
            Console.WriteLine(context.Entry(getBook).State); //Deattach
        }

    }
}