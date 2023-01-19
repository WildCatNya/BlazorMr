namespace BlazorMr;

public class PaginatedList<T> : List<T>
{
    public int CurrentPage { get; private set; }

    public int TotalPages { get; private set; }

    public PaginatedList(IEnumerable<T> items, double count, int currentPage, double pageSize)
    {
        CurrentPage = currentPage;
        TotalPages = (int)Math.Ceiling(count / pageSize);
        AddRange(items);
    }

    public bool HasPrevPage => CurrentPage > 1;

    public bool HasNextPage => CurrentPage < TotalPages;

    public static PaginatedList<T> Create(List<T> source, int currentPage, int pageSize)
    {
        int count = source.Count;
        IEnumerable<T> itemsByPage = source.Skip((currentPage - 1) * pageSize).Take(pageSize);
        return new(itemsByPage, count, currentPage, pageSize);
    }
}