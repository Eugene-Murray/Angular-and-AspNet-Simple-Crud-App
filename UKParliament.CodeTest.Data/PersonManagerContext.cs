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
            new Person { Id = 1, FirstName = "Stevie", LastName = "Wonder", DOB = "1999-1-1", DepartmentId = 1 },
            new Person { Id = 2, FirstName = "Aretha", LastName = "Franklin", DOB = "2000-2-2", DepartmentId = 2 },
            new Person { Id = 3, FirstName = "Ray", LastName = "Charles", DOB = "2001-3-3", DepartmentId = 3 },
            new Person { Id = 4, FirstName = "James", LastName = "Brown", DOB = "2003-4-4", DepartmentId = 4 }
        );

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Sales" },
            new Department { Id = 2, Name = "Marketing" },
            new Department { Id = 3, Name = "Finance" },
            new Department { Id = 4, Name = "HR" }
        );
    }

    public DbSet<Person> People { get; set; }
    public DbSet<Department> Department { get; set; }

}

