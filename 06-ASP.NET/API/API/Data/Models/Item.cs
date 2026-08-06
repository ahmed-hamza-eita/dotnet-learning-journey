using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Models
{
    public class Item
    {
        [Key]
        public int Id { set; get; }

        [MaxLength(50)]
        public string? Name { set; get; }

        public decimal Price { set; get; }

        [MaxLength(50)]
        public string? Note { set; get; }

        public byte[]? Image { set; get; }

        //Relation with category
        [ForeignKey(nameof(category))]
        public int categoryId { set; get; }
        public Category category { set; get; }
    }
}
