using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Core.Entities.Products
{
    public class Product : BaseEntity<int>
    {
        public string Name { set; get; } = string.Empty;
        public string Description { set; get; } = string.Empty;
        public decimal NewPrice { set; get; }
        public decimal OldPrice { set; get; }
        public virtual List<Photo> Photos { set; get; } = new List<Photo>();

        public int CategoryId { set; get; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { set; get; } = null!;

    }
}
