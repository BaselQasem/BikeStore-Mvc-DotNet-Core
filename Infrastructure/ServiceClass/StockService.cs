using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ServiceClass
{
    public class StockService : IStock
    {

        IGenericRepository<Stock> _repository;
        public StockService(IGenericRepository<Stock> repository)
        {
            _repository = repository;

        }
        public void DeleteStock(Stock stock)
        {
            if (stock != null)
            {

                 _repository.Delete(stock);

            }
        }

        public async Task<Stock> GetStock(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Stock>> GetStocks()
        {

            return await _repository.GetAllAsync();
        }

        public async Task InserStock(Stock product)
        {
            if (product != null)
            {
                await _repository.AddAsync(product);
            }
        }

        public async Task AddRange(IEnumerable<Stock> list)
        {
            await _repository.AddRangeAsync(list);
        }

        public void RemoveRange(IEnumerable<Stock> list)
        {
             _repository.DeleteRange(list);
        }
        public void UpdateStock(Stock product)
        {
             _repository.Update(product);
        }

        public async Task<IEnumerable<Stock>> GetStockByProductId(int id)
        {
            var specification = new StocksByProductIdSpesification(id);
            return await _repository.FindWithSpecificationPattern(specification).ToListAsync();
        }

        public async Task<Tuple<List<Stock>, int>> geStockFiltered(TableQuery tableQuery)
        {
            var res = _repository.FindWithSpecificationPattern(new StockFilterSpesification(tableQuery));
            return await Pager<Stock>.buildPaging(tableQuery, res);
        }

        public async Task<Stock> getStockByID(int StockId,int ProductId)
        {
           var specification=new StockByIdSpecification(StockId, ProductId);
            var StocksGroup = await _repository.FindWithSpecificationPattern(specification).SingleOrDefaultAsync();
            return StocksGroup;
        }

        public async Task<int> GetStockRowCount()
        {
            return await _repository.CountAsync();
        }




        //public async Task<ICollection<Stock>> FindAllAsync(Expression<Func<Stock, Boolean>> match)
        //{
        //    var o = _repository.GetEntity().Where(match);
        //    return await o.ToListAsync();
        //}

        //public async Task<ICollection<Stock>> FindStockInclude(int s_id, int p_id)
        //{
        //    if (s_id == 0 || p_id == 0)
        //    {
        //        var o = _repository.GetEntity().Include(p => p.Product).Include(s => s.Store);
        //        return await o.ToListAsync();
        //    }
        //    else
        //    {
        //        var o = _repository.GetEntity().Include(p => p.Product).Include(s => s.Store)
        //        .Where(p => p.ProductId == p_id && p.StoreId == s_id);
        //        return await o.ToListAsync();
        //    }

        //}
    }
}

