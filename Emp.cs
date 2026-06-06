using System.ComponentModel.DataAnnotations;

namespace EmsPotral.Models
{
    public class Emp
    {
        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Student Name is required")]
        [StringLength(15, MinimumLength = 3,
            ErrorMessage = "Name must be between 3 and 15 characters")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string EmailID { get; set; }

        public int Age { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phoneno { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [StringLength(50)]
        public string Role { get; set; }

        public string MrgName { get; set; }

        public decimal Salary { get; set; }

        public DateTime JoiningDate { get; set; } = DateTime.UtcNow;
    }
}
   
