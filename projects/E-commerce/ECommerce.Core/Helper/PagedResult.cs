namespace ECommerce.Core.Helper
{
    public class PagedResult<T> where T : class
    {
        public IReadOnlyList<T> Data { set; get; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }


    }
}
