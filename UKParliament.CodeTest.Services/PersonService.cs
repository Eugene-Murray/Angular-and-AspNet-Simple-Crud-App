using System;
using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.Repositories;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services.Mappers;

namespace UKParliament.CodeTest.Services;

public class PersonService : IPersonService
{
    private IPersonRepository _personRepository;
    private IPersonMapper _mapper;

    public PersonService(IPersonRepository personRepository, IPersonMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public void Delete(int id)
    {
        _personRepository.Delete(id);
    }

    public List<PersonViewModel> Get()
    {
        var personList = _personRepository.Get();
        return _mapper.Map(personList);
    }

    public PersonViewModel Get(int id)
    {
        var person = _personRepository.Get(id);
        if (person != null)
        {
            return _mapper.Map(person);
        }
        return null;
    }

    public PersonViewModel Add(PersonViewModel person)
    {
        var newPerson = _personRepository.Create(_mapper.Map(person));

        return _mapper.Map(newPerson);
    }

    public void Edit(int id, PersonViewModel person)
    {
        _personRepository.Edit(id, _mapper.Map(person));
    }
}
