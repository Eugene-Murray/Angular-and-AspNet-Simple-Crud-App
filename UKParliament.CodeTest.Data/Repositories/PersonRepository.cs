using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data.Entities;

namespace UKParliament.CodeTest.Data.Repositories
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

        public Person Create(Person person)
        {
            var newPerson = _db.People.Add(person);
            _db.SaveChanges();

            return newPerson.Entity;
        }

        public void Edit(int id, Person personUpdate)
        {
            var person = _db.People.FirstOrDefault(p => p.Id == id);

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
