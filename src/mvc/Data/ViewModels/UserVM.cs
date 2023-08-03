namespace mvc.Data.ViewModels
{
    public class UserVM
    {
        public required string Id { get; set; } 
        public required string Email { get; set; } 
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
