using System.ComponentModel.DataAnnotations;
using Task_1.Models;

namespace Tasks.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public List<Book> Books { get; set; } = new();
    }
}

