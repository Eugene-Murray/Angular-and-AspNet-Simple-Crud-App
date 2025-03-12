﻿using System.ComponentModel.DataAnnotations;

namespace UKParliament.CodeTest.Data.Entities;

public class Person
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    //public DateTime DOB { get; set; }
    [Required]
    public DateOnly DOB { get; set; }

    [Required]
    public int DepartmentId { get; set; }
}
