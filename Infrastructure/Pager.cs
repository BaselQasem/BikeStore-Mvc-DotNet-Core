using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Pager<T>
    {

       public static async Task<Tuple<List<T>, int>> buildPaging(TableQuery tableQuery,IQueryable<T> res) 
        {
            int PagesCount = ((res.Count() - 1) / tableQuery.PageSize);
            int result_1;
            Math.DivRem(res.Count(), tableQuery.PageSize, out result_1);
            if (result_1 > 0)
            {
                PagesCount = PagesCount + 1;
            }
            return Tuple.Create(await res.Skip((tableQuery.PageNumber - 1) * tableQuery.PageSize)
                  .Take(tableQuery.PageSize).ToListAsync(), PagesCount);
           
        }
    }
}
