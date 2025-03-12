using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.ViewModels;

namespace UKParliament.CodeTest.Services.Mappers
{
    public interface IPersonMapper
    {
        List<PersonViewModel> Map(List<Person> person);
        PersonViewModel Map(Person person);
        Person Map(PersonViewModel person);
    }
}
