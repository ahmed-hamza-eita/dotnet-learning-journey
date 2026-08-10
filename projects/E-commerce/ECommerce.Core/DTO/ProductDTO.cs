namespace ECommerce.Core.DTO
{
    public record ProductDTO(
        int Id,
        string Name,
        string Description,
        decimal NewPrice,
        decimal OldPrice,
        int CategoryId,
        string CategoryName,
        List<PhotoDTO> Photos
    );
  
}
