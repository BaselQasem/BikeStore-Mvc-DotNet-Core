using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStaff
    {
       public Task<IEnumerable<Staff>> GetStaffs();
        public Task<Staff> GetStaff(int id);
        public Task InserStaff(Staff Staff);
        public void UpdateStaff(Staff staff);
        public void DeleteStaff(Staff staff);
        public Task<Tuple<List<Staff>, int>> GetStaffFilter(TableQuery tableQuery);

        public Task<Staff> GetStaffById(int id);
        public Task<int> GetStaffRowCount();
    }
}
