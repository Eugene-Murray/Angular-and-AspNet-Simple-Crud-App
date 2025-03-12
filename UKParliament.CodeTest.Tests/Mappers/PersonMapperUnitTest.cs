using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.Repositories;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Services.Mappers;

namespace UKParliament.CodeTest.Tests.Services
{

    public class PersonMapperUnitTest
    {
        [Fact]
        public void Should_Map_PersonViewModel_To_Person()
        {
            // Arrange
            var mapper = new PersonMapper();
            var personViewModel = new PersonViewModel
            {
                Id = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                DOB = DateOnly.FromDateTime(DateTime.Now),
                DepartmentId = 1
            };

            // Act
            var result = mapper.Map(personViewModel);

            // Assert
            Assert.Equal(result.GetType(), typeof(Person));
        }
    }
}