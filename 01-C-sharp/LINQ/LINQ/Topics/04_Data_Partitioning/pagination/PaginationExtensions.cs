static class PaginationExtensions
{
    public static PagedResult<T> Paginate<T>(
        this IEnumerable<T> source,
         int? page,
        int? size)
    {
        if (!page.HasValue)
            page = 1;

        if (!size.HasValue)
            size = 10;

        /* 
        page ??= 1;
        size ??= 10;
        */ 


        var totalItems = source.Count();
        var totalPages = (int)(Math.Ceiling((decimal)totalItems / size.Value));

        var data = source
            .Skip((page.Value - 1) * size.Value)
            .Take(size.Value).ToList();


        return new PagedResult<T>
        {
            Data = data,
            CurrentPage = page.Value,
            PageSize = size.Value,
            TotalItems = totalItems,
            TotalPages = totalPages
        };
    }

    public static PagedResult<T> PaginateWithCondition<T>(
       this IEnumerable<T> source,
       Func<T, bool> predicate,
        int? page,
       int? size)
    {

        return source.Where(predicate).Paginate(page, size);
    }
}