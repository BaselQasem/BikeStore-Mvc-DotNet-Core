using Core.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Specifications;

namespace Infrastructure.ServiceClass
{
    public class StaffService : IStaff
    {
        IGenericRepository<Staff> _repository;
        public StaffService(IGenericRepository<Staff> repository)
        {
            _repository = repository;

        }
        public void DeleteStaff(Staff staff)
        {
            if (staff != null)
            {

                 _repository.Delete(staff);

            }
        }

        public async Task<Staff> GetStaffById(int id)
        {
            var specification = new StaffByIdSpecification(id);
            var Staff = await _repository.FindWithSpecificationPattern(specification).SingleOrDefaultAsync();
            //var ordersGroup = await _repository.GetEntity().Include(c => c.Customer).Include(b => b.Store)
            //    .Include(s => s.Staff).Include(itm => itm.OrderItems).Where(o => o.OrderId == id).SingleOrDefaultAsync();
            return Staff;
        }

        public async Task<Staff> GetStaff(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Tuple<List<Staff>, int>> GetStaffFilter(TableQuery tableQuery)
        {
            var res = _repository.FindWithSpecificationPattern(new StaffFilterSpecification(tableQuery));
            return await Pager<Staff>.buildPaging(tableQuery, res);
        }



        public async Task<int> GetStaffRowCount()
        {
          return await  _repository.CountAsync();
        }

        public async Task<IEnumerable<Staff>> GetStaffs()
        {

            return await _repository.GetAllAsync();
        }

        public async Task InserStaff(Staff staff)
        {
            if (staff != null)
            {
                await _repository.AddAsync(staff);
            }
        }

        public void UpdateStaff(Staff staff)
        {
             _repository.Update(staff);
        }


        //public async Task<ICollection<Staff>> FindAllAsync(Expression<Func<Staff, object>> match)
        //{

        //    return await FindAllAsync(match);
        //}

        //public async Task<ICollection<Staff>> FindStaffInclude()
        //{
        //    var o = _repository.GetEntity().Include(s =>s.Store ).Include(m => m.Manager);
        //    return await o.ToListAsync();
        //}
    }
}
