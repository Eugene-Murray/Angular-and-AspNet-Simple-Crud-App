using System.ComponentModel.DataAnnotations;

namespace UKParliament.CodeTest.Server.ViewModels;

    public class PersonViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "DOB is required")]

        public DateOnly DOB { get; set; }

        [Required(ErrorMessage = "DepartmentId is required")]

        public int DepartmentId { get; set; }
    }

