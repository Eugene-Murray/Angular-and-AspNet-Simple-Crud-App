using System.ComponentModel.DataAnnotations;

namespace UKParliament.CodeTest.Data.ViewModels;

    public class PersonViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "DOB is required")]
        public required DateOnly DOB { get; set; }

        [Required(ErrorMessage = "DepartmentId is required")]
        public required int DepartmentId { get; set; }
    }

