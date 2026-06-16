class PagedResult<T>
{
    public List<T> Data { set; get; } = new();

    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public int TotalItems { get; set; }

    public int TotalPages { get; set; }

}