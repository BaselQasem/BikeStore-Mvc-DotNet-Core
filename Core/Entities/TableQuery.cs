namespace Core.Entities
{
    public class TableQuery
    {
        public string? Filter { get; set; }
        public int Sorting { get; set; }

        public int PagesCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int otherFilters { get; set; }
        public int RowNumberStart { get; set; }

    }
}
