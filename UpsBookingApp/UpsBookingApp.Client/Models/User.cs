namespace UpsBookingApp.Client.Models
{
    public class User
    {
        public int Id { get; set; }           // Primary key
        public string UserId { get; set; } = "";  
        public string Name { get; set; } = "";
        public string Role { get; set; } = "User";
    }
}
