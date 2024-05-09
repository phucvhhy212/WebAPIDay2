using System.ComponentModel.DataAnnotations;
using Infrastructure;

namespace WebAPI.Models
{
    public class PersonRequestModel
    {
        [MaxLength(40)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(40)]
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public GenderType Gender { get; set; }
        [Required]
        public string BirthPlace { get; set; }
    }
}
