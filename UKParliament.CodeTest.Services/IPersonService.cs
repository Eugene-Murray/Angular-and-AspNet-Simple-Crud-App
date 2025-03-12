using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.ViewModels;

namespace UKParliament.CodeTest.Services;

public interface IPersonService
{
    List<PersonViewModel> Get();
    PersonViewModel Get(int id);
    PersonViewModel Add(PersonViewModel person);
    void Edit(int id, PersonViewModel person);
    void Delete(int id);
}
