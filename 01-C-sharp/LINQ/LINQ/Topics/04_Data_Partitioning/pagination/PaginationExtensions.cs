static class PaginationExtensions
{
    public static PagedResult<T> Paginate<T>(
        this IEnumerable<T> source,
         int page = 1,
        int size = 10)
    {
        if (page <= 0)
            page = 1;

        if (size <= 0)
            size = 10;

        var totalItems = source.Count();
        var totalPages = (int)(Math.Ceiling((decimal)totalItems / size));

        var data = source
            .Skip((page - 1) * size)
            .Take(size)
            .ToList();

        return new PagedResult<T>
        {
            Data = data,
            CurrentPage = page,
            PageSize = size,
            TotalItems = totalItems,
            TotalPages = totalPages
        };
    }
}