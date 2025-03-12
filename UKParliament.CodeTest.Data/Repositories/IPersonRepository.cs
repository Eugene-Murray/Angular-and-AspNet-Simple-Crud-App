using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.ViewModels;

namespace UKParliament.CodeTest.Data.Repositories
{
    public interface IPersonRepository
    {
        List<Person> Get();
        Person Get(int id);
        Person Create(Person person);
        void Edit(int id, Person person);
        void Delete(int id);
    }
}
