using System.ComponentModel.DataAnnotations;

namespace Infrastructure
{
    public enum GenderType
    {
        [Display(Name = "Male")]
        Male = 0,
        [Display(Name = "Female")]
        Female = 1
    }
}
