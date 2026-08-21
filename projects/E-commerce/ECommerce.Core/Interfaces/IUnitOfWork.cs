namespace ECommerce.Core.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        ICustomerBasketRepository CustomerBasketRepository { get; }
        IAuthRepository AuthRepository { get; }
        Task<bool> SaveChangesAsync();
    }
}
