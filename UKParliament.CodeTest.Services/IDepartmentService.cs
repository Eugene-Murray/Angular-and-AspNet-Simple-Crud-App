using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data.Entities;

namespace UKParliament.CodeTest.Services
{
    public interface IDepartmentService
    {
        List<Department> Get();
    }
}
