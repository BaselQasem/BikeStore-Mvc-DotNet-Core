using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStore
    {
        public Task<IEnumerable<Store>> GetStores();
        public Task<Store> GetStore(int id);
        public Task InserStore(Store store);
        public void UpdateStore(Store store);
        public void DeleteStore(Store store);

        public  Task<Tuple<List<Store>, int>> GetStoresFilter(TableQuery storeFiltered);

        
        }
}
