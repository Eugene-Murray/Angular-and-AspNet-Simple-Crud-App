using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.Repositories;


namespace UKParliament.CodeTest.Tests.Services
{

    public class PersonRepoUnitTest : UnitBaseUnitTest
    {
        [Fact]
        public void Should_CreatePerson_Entity_List()
        {
            // Arrange
            var options = base.GetInMemoryDbContextOptions();
            var repo = new PersonRepository(new PersonManagerContext(options));

            // Act
            var result = repo.Create(new Person { FirstName = "Test Name", LastName = "", DepartmentId = 2, DOB = new DateOnly(2000, 1, 1) });

            // Assert
            Assert.Equal(result.FirstName, "Test Name");
        }
    }
}