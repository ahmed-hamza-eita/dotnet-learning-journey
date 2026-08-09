namespace ECommerce.Core.DTO
{
    public record ProductDTO(
        int Id,
        string Name,
        string Description,
        decimal Price,
        int CategoryId,
        string CategoryName,
        List<PhotoDTO> Photos
    );
 
}
