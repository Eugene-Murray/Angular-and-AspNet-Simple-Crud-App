using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services;

public interface IPersonService
{
    List<Person> Get();
    Person Get(int id);
    Person Post(Person person);
    void Put(int id, Person person);
    void Delete(int id);
}
