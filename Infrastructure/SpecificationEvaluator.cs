
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure
{
    public class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Wheres.Count>0)
            {
                
                
                foreach(var item in spec.Wheres)
                {
                    query = query.Where(item);
                   // query = spec.Wheres.Aggregate(query, (current, where) => current.Include(where));

                }

            }
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}