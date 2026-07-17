

using _18_SaveData.Data;
using _18_SaveData.Entities;
using Microsoft.EntityFrameworkCore;

namespace _18_SaveData.Utils
{
    public static class DbHelper
    {
        public static void RecreateCleanDB()
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
        public static Book? GetDisconnectedBook()
        {
            using var tempContext = new AppDbContext();
            return tempContext.Books.Find(2);
        }

        public static Author GetDisconnectedAuthorAndBooks()
        {
            using var tempContext = new AppDbContext();
            return tempContext.Authors.Include(x => x.Books).Single();
        }

        public static void PopulateDatabase()
        {
            using (var context = new AppDbContext())
            {
                context.Add(
                    new Author
                    {
                        Id = 1,
                        FName = "Eric",
                        LName = "Evans",
                        NationalId = "29001011234567",
                        Books = new List<Book>
                        {
                          new Book
                          {
                              Id = 1,
                              Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software",
                              Price=50
                          },
                          new Book
                          {
                              Id = 2,
                              Title = "Domain-Driven Design Reference: Definitions and Pattern Summaries",
                              Price=50
                          }
                        }
                    });

                context.Add(
                 new AuthorV2
                 {
                     Id = 1,
                     FName = "Eric",
                     LName = "Evans",
                     BooksV2 = new List<BookV2>
                     {
                          new BookV2
                          {
                              Id = 1,
                              Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software"
                          },
                          new BookV2
                          {
                              Id = 2,
                              Title = "Domain-Driven Design Reference: Definitions and Pattern Summaries"
                          }
                     }
                 });

                context.SaveChanges();
            }
        }
    }

}

