using System.ComponentModel.DataAnnotations;

namespace mvc.Data.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(32, ErrorMessage = "First name can't be more than 32 character"),
            MinLength(3, ErrorMessage = "First name can't be less than 3 characters")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(32, ErrorMessage = "Last name can't be more than 32 character"),
            MinLength(3, ErrorMessage = "Last name can't be less than 3 characters")]
        public string LastName { get; set; } = "";
        
        [Required(ErrorMessage = "This field is required")]
        public string UserName { get; set; } = "";

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
            ErrorMessage = "Password must have at least 1 Uppercase, 1 Lowercase, 1 number, 1 non alphanumeric and at least 6 characters")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "This field is required")]
        [Compare(nameof(Password), ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; } = "";
    }
}
