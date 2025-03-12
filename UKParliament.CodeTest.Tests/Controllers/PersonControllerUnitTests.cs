using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.Repositories;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Server.Controllers;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Services.Mappers;

namespace UKParliament.CodeTest.Tests.Controllers
{
    public class PersonControllerUnitTests : UnitBaseUnitTest
    {

        [Fact]
        public void GetPersons_ShouldReturnAllPersons()
        {
            // Arrange
            var options = GetInMemoryDbContextOptions();
            using (var context = new PersonManagerContext(options))
            {
                context.People.Add(new Person { FirstName = "John", LastName = "Doe", DOB = new DateOnly(2004, 1, 1), DepartmentId = 1 });
                context.People.Add(new Person { FirstName = "Jane", LastName = "Smith", DOB = new DateOnly(2001, 1, 1), DepartmentId = 2 });
                context.SaveChanges();
            }

            using (var context = new PersonManagerContext(options))
            {
                var controller = new PersonController(new PersonService(new PersonRepository(context), new PersonMapper()));

                // Act
                var result = controller.Get();

                // Assert
                Assert.IsType<ActionResult<List<PersonViewModel>>>(result);
            }
        }
    }
}
