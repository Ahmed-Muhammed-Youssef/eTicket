using Microsoft.AspNetCore.Identity;

namespace mvc.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        // Navigation properties
        public List<Order> Orders { get; set; } = new List<Order>();
        public Cart? Cart { get; set; }
        public string GetFullName() => FirstName + (string.IsNullOrEmpty(LastName) ? "" : " " + LastName);
    }
}
