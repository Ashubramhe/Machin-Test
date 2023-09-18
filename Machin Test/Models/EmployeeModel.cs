using System.ComponentModel.DataAnnotations;

namespace Machin_Test.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string MobileNumber { get; set; }
        [Required]
        public string Gender { get; set; }

        public string Address { get; set; }

    }
}
