using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.Repositories;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Services.Mappers;

namespace UKParliament.CodeTest.Tests.Services
{

    public class DepartmentMapperUnitTest
    {
        [Fact]
        public void Should_Map_Department_To_DepartmentViewModel()
        {
            // Arrange
            var mapper = new DepartmentMapper();
            var departments = new List<Department>
                {
                    new Department { Id = 1, Name = "FirstName" },
                    new Department { Id = 2, Name = "SecondName" },
                    new Department { Id = 3, Name = "ThirdName" },
                    new Department { Id = 4, Name = "FourthName" },
                    new Department { Id = 5, Name = "FifthName" }
                };

            // Act
            var result = mapper.Map(departments);

            // Assert
            Assert.Equal(result?.Count, 5);
            Assert.Equal(result?.GetType(), typeof(List<DepartmentViewModel>));
        }
    }
}