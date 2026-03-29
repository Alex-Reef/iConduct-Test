using System.ComponentModel.DataAnnotations;

namespace iConduct.Domain.DTOs
{
    public class EmployeeDto
    {
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 255 characters.")]
        public required string Name { get; set; }

        public int? ManagerID { get; set; }

        [Required]
        public bool Enable { get; set; }
    }
}
