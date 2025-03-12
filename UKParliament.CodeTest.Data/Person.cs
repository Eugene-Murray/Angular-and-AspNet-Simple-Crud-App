using System.ComponentModel.DataAnnotations;

namespace UKParliament.CodeTest.Data;

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
    public string DOB { get; set; }

    [Required]
    public int DepartmentId { get; set; }
}
