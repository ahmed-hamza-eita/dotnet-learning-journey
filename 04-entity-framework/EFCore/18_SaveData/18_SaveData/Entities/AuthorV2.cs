using System;
using System.Collections.Generic;
using System.Text;

namespace _18_SaveData.Entities
{
    public class AuthorV2
    {
        public int Id { set; get; }
        public string FName { set; get; }
        public string LName { set; get; }
        public string FullName => FName + LName;
        
        //Optional
        public List<BookV2> BooksV2 { get; set; } = new();
    }
}
