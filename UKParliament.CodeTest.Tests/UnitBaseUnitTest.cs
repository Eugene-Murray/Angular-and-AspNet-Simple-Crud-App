using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Tests
{
    public class UnitBaseUnitTest
    {
        public DbContextOptions<PersonManagerContext> GetInMemoryDbContextOptions()
        {
            var options = new DbContextOptionsBuilder<PersonManagerContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            return options;
        }
    }
}
