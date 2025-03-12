using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.ViewModels;

namespace UKParliament.CodeTest.Services.Mappers
{
    public class DepartmentMapper : IDepartmentMapper
    {
        public List<DepartmentViewModel> Map(List<Department> departments)
        {
            return departments.Select(p => new DepartmentViewModel()
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();
        }
    }
}
