using System.ComponentModel.DataAnnotations.Schema;


namespace ECommerce.Core.Entities.Products
{
    public class Photo : BaseEntity<int>
    {
        public string Name { set; get; } = string.Empty;

        public int ProductId { set; get; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { set; get; } = null;
    }
}
