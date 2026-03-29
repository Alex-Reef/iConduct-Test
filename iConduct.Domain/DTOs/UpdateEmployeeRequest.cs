using System.ComponentModel.DataAnnotations;

namespace iConduct.Domain.DTOs
{
    public class UpdateEmployeeRequest
    {
        [Required(ErrorMessage = "Enable flag is required.")]
        public required bool Enable { get; set; }
    }
}