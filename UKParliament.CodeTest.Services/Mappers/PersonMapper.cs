using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.ViewModels;

namespace UKParliament.CodeTest.Services.Mappers
{
    public class PersonMapper : IPersonMapper
    {
        public PersonViewModel Map(Person person)
        {
            return new PersonViewModel()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DOB = person.DOB,
                DepartmentId = person.DepartmentId
            };
        }

        public Person Map(PersonViewModel person)
        {
            return new Person()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DOB = person.DOB,
                DepartmentId = person.DepartmentId
            };
        }

        public List<PersonViewModel> Map(List<Person> people)
        {
            return people.Select(p => new PersonViewModel()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DepartmentId = p.DepartmentId,
                DOB = p.DOB,
            }).ToList();
        }
    }
}
