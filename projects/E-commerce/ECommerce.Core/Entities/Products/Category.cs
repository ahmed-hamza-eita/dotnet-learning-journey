namespace ECommerce.Core.Entities.Products
{
    public class Category : BaseEntity<int>
    {
        public string Name { set; get; } = string.Empty;
        public string Description { set; get; } = string.Empty;

        public ICollection<Product> Products { set; get; } = new HashSet<Product>();
    }
}
