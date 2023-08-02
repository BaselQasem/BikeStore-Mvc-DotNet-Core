using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BikeStore.Models
{
    public class TableViewModel
    {
      public int    pageNumber { get; set; } = 0;
      public  int pagesCount { get; set; } = 1;
      public  int pageSize { get; set; } = 10;
        public string searchPattern { get; set; } = "";
        public int sorting { get; set; } = 0;
    }
}
