using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.Repositories;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Services.Mappers;

namespace UKParliament.CodeTest.Tests.Services
{
    public class MockPersonRepository : IPersonRepository
    {
        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
        public void Edit(int id, Person person)
        {
            throw new System.NotImplementedException();
        }
        public Person Get(int id)
        {
            throw new System.NotImplementedException();
        }
        public List<Person> Get()
        {
            return new List<Person> { new Person(), new Person(), new Person(), new Person(), new Person() }
            ;
        }
        public Person Create(Person person)
        {
            throw new System.NotImplementedException();
        }
    }


    public class PersonServiceUnitTest
    {

        [Fact]
        public void Should_GetList()
        {
            // Arrange
            var service = new PersonService(new MockPersonRepository(), new PersonMapper());

            // Act
            var result = service.Get();

            // Assert
            Assert.Equal(result?.Count, 5);
        }
    }
}