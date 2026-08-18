using ECommerce.Core.Helper;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Helper
{
    public static class PaginationExtensions
    {
        public static async Task<PagedResult<T>> PaginateAsync<T>(
            this IQueryable<T> source,
            int? page,
            int? size) where T:class
        {
            if (!page.HasValue)
                page = 1;

            if (!size.HasValue)
                size = 10;

            /* 
            page ??= 1;
            size ??= 10;
            */


            var totalItems = await source.CountAsync();
            var totalPages = (int)(Math.Ceiling((decimal)totalItems / size.Value));

            var data = await source
                .Skip((page.Value - 1) * size.Value)
                .Take(size.Value).ToListAsync();


            return new PagedResult<T>
            {
                Data = data,
                CurrentPage = page.Value,
                PageSize = size.Value,
                TotalItems = totalItems,
                TotalPages = totalPages
            };
        }


    }
}
