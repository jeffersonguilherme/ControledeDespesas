namespace ControleDeDespesas.Application.Responses;

public class PagedResponse<T>
{
    public IEnumerable<T>? Dados { get; set; } = Enumerable.Empty<T>();
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public bool HasNextPage => PageNumber < TotalPages;
    public bool HasPreviousPage => PageNumber > 1;

    public PagedResponse(){}

    public PagedResponse(IEnumerable<T> dados, int pageNumber, int pageSize, int totalItems)
    {
        Dados = dados;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalItems = totalItems;
        TotalPages = (int)Math.Ceiling(totalItems/(double)pageSize);
    }
}