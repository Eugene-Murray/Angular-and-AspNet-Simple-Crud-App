using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.Repositories;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services.Mappers;

namespace UKParliament.CodeTest.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _departmentRepository;
        private IDepartmentMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IDepartmentMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public List<DepartmentViewModel> Get()
        {
            var departments = _departmentRepository.Get();

            return _mapper.Map(departments);
        }
    }
}
