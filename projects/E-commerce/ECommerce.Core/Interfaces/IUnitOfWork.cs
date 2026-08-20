namespace ECommerce.Core.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        ICustomerBasketRepository CustomerBasketRepository { get; }
        Task<bool> SaveChangesAsync();
    }
}
