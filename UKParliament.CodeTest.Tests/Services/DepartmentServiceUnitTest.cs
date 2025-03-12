using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.Repositories;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Services.Mappers;

namespace UKParliament.CodeTest.Tests.Services
{
    public class MockDepartmentRepository : IDepartmentRepository
    {
       
        public List<Department> Get()
        {
            return new List<Department> { new Department(), new Department(), new Department(), new Department(), new Department() }
            ;
        }
    }


    public class DepartmentServiceUnitTest
    {

        [Fact]
        public void Should_GetList()
        {
            // Arrange
            var service = new DepartmentService(new MockDepartmentRepository(), new DepartmentMapper());

            // Act
            var result = service.Get();

            // Assert
            Assert.Equal(result?.Count, 5);
        }
    }
}