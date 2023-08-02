using Core.Interfaces;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Infrastructure.ServiceClass
{
    public class StoreService : IStore
    {
        IGenericRepository<Core.Entities.Store> _repository;
        public StoreService(IGenericRepository<Core.Entities.Store> repository)
        {
            _repository = repository;

        }
        public void DeleteStore(Store store)
        {
            if (store != null)
            {

                 _repository.Delete(store);

            }
        }


        public async Task<Core.Entities.Store> GetStore(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Tuple<List<Store>, int>> GetStoresFilter(TableQuery tableQuery)
        {
            var res = _repository.FindWithSpecificationPattern(new StoreFilterSpecification(tableQuery));
            return await Pager<Store>.buildPaging(tableQuery, res);

            // return await _repository.GetAll();
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            return await _repository.GetAllAsync();
        }
        public async Task InserStore(Core.Entities.Store store)
        {
            if (store != null)
            {
                await _repository.AddAsync(store);
            }
        }

        public void UpdateStore(Core.Entities.Store store)
        {
             _repository.Update(store);
        }

    }
}
