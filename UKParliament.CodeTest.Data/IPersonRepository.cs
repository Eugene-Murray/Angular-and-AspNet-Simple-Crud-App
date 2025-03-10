using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKParliament.CodeTest.Data
{
    public interface IPersonRepository
    {
        List<Person> Get();
        Person Get(int id);
        void Create(Person person);
        void Edit(int id, Person person);
        void Delete(int id);
    }
}
