

using UpsBookingApp.Client.Models;

namespace UPSBookingApp.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (!db.Desks.Any())
        {
            var desks = new List<Desk>
            {
                new() { Name = "Desk A1", Location = "C-8C-117", Description = "Near to Cafeteria", Floor = "Floor 1", IsAvailable = true },
                new() { Name = "Desk A2", Location = "C-8C-118", Description = "Beside ATS seatings", Floor = "Floor 1", IsAvailable = true },
                new() { Name = "Desk B1", Location = "C-8C-119", Description = "Campus 30 beside pantry 1", Floor = "Floor 2",  IsAvailable = true },
                new() { Name = "Desk B2", Location = "C-8C-122", Description = "Near to game room", Floor = "Floor 2", IsAvailable = true },
            };

            db.Desks.AddRange(desks);
            db.SaveChanges();
        }

        if (!db.Users.Any())
        {
            var users = new List<User>
            {
                new() { UserId = "8258251", Name = "Dhilip", Role = "Admin" },
                new() { UserId = "8240087", Name = "Siva", Role = "User" },
                new() { UserId = "8529559", Name = "Pavan", Role = "User" },
                new() { UserId = "123456", Name = "Nabarup", Role = "User" },
                new() { UserId = "8254964", Name = "Guru", Role = "User" },

            };

            db.Users.AddRange(users);
        }

    }
}
