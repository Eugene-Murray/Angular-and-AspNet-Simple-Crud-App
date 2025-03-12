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
            if (id == 1)
            {
                return new Person { Id = 1, FirstName = "Test Name" };
            }
            return null;
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

        [Fact]
        public void Should_Get_Person()
        {
            // Arrange
            var service = new PersonService(new MockPersonRepository(), new PersonMapper());
            var id = 1;

            // Act
            var result = service.Get(id);

            // Assert
            Assert.Equal(1, result?.Id);
            Assert.Equal("Test Name", result?.FirstName);
        }


        [Fact]
        public void Should_Not_Get_Person()
        {
            // Arrange
            var service = new PersonService(new MockPersonRepository(), new PersonMapper());
            var id = 2;

            // Act
            var result = service.Get(id);

            // Assert
            Assert.Equal(null, result);
        }
    }
}