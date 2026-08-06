using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;


    }
}

