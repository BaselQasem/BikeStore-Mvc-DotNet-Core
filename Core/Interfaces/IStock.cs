using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStock
    {
        public Task<IEnumerable<Stock>> GetStocks();

        public Task<Tuple<List<Stock>, int>> geStockFiltered(TableQuery tableOperation);

        public Task<IEnumerable<Stock>> GetStockByProductId(int ProductId);
        public Task AddRange(IEnumerable<Stock> list);
        public Task<Stock> GetStock(int id);
        public Task<Stock> getStockByID(int StockId,int ProductId);
        public Task InserStock(Stock stock);
        public void UpdateStock(Stock stock);
        public void DeleteStock(Stock stock);
        public void RemoveRange(IEnumerable<Stock> list);
        public Task<int> GetStockRowCount();
    }
}
