namespace BuildingBlocks.Pagination;

public class PaginationRequest
{
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}
