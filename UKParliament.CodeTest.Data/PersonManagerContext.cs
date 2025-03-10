using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKParliament.CodeTest.Data;

public class PersonManagerContext : DbContext
{
    public PersonManagerContext(DbContextOptions<PersonManagerContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Person>().HasData(
            new Person { Id = 1, FirstName = "Stevie", LastName = "Wonder", DOB = new DateTime(2000, 5, 2), DepartmentId = 1 },
            new Person { Id = 2, FirstName = "Aretha", LastName = "Franklin", DOB = new DateTime(1999, 3, 20), DepartmentId = 2 },
            new Person { Id = 3, FirstName = "Ray", LastName = "Charles", DOB = new DateTime(1978, 10, 2), DepartmentId = 3 },
            new Person { Id = 4, FirstName = "James", LastName = "Brown", DOB = new DateTime(2002, 7, 22), DepartmentId = 4 }
        );

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Sales" },
            new Department { Id = 2, Name = "Marketing" },
            new Department { Id = 3, Name = "Finance" },
            new Department { Id = 4, Name = "HR" }
        );
    }

    public DbSet<Person> People { get; set; }
    public DbSet<Department> DepartmentSet { get; set; }

}

