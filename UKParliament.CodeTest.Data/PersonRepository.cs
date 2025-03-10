using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKParliament.CodeTest.Data
{
    public class PersonRepository : IPersonRepository
    {
        PersonManagerContext _db;
        public PersonRepository(PersonManagerContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            _db.People.Remove(_db.People.Find(id));
            _db.SaveChanges();
        }

        public List<Person> Get()
        {
            return _db.People.ToList();
        }

        public Person Get(int id) => _db.People.Find(id);

        public void Create(Person person)
        {
            _db.People.Add(person);
            _db.SaveChanges();
        }

        public void Edit(int id, Person personUpdate)
        {
            var person = _db.People.FirstOrDefault(p => p.Id == 1);

            if (person != null)
            {
                person.FirstName = personUpdate.FirstName;
                person.LastName = personUpdate.LastName;
                person.DOB = personUpdate.DOB;
                person.DepartmentId = personUpdate.DepartmentId;

                _db.SaveChanges();
            }
        }
    }
}
