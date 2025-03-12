using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data.Entities;

namespace UKParliament.CodeTest.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        PersonManagerContext _db;
        public DepartmentRepository(PersonManagerContext db)
        {
            _db = db;
        }

        public List<Department> Get()
        {
            return _db.Department.ToList();
        }
    }
}
