

using Microsoft.EntityFrameworkCore;
using UpsBookingApp.Client.Models;

namespace UPSBookingApp.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        //Remove existing DB values 

        var existingWorkspaces = db.Workspaces.ToList();
        if (existingWorkspaces.Any())
        {
            db.Workspaces.RemoveRange(existingWorkspaces);
            db.SaveChangesAsync();
        }

        var exitingdesk = db.Desks.ToList();
        if (exitingdesk.Any())
        {
            db.Desks.RemoveRange(exitingdesk);
            db.SaveChangesAsync();
        }

        var exitingBookings = db.Bookings.ToList();
        if (exitingBookings.Any())
        {
            db.Bookings.RemoveRange(exitingBookings);
            db.SaveChangesAsync();
        }



        if (!db.Desks.Any())
        {
            var desks = new List<Desk>
            {
                new() { Name = "Chennai", Location = "C-8C-117", Description = "Near to Cafeteria", Capacity = 10, Floor = "Floor 1", IsAvailable = true },
                new() { Name = "Kolkata", Location = "C-8C-118", Description = "Beside ATS seatings", Capacity = 20, Floor = "Floor 1", IsAvailable = true },
                new() { Name = "Mumbai", Location = "C-8C-118", Description = "Near Campus 20 Entrance", Capacity = 20, Floor = "Floor 1", IsAvailable = true },
                new() { Name = "Goa", Location = "C-8C-119", Description = "Campus 30 beside pantry 1", Capacity = 15, Floor = "Floor 2",  IsAvailable = true },
                new() { Name = "London", Location = "C-8C-122", Description = "Near to game room", Capacity = 10, Floor = "Floor 2", IsAvailable = true },
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
            db.SaveChanges();
        }

        if (!db.Workspaces.Any())
        {
            var list = new List<Workspace>();
            for (int i = 1; i <= 100; i++)
            {
                list.Add(new Workspace
                {
                    SeatNumber = i,
                    Floor = i <= 50 ? "Floor 1" : "Floor 2",
                    Department = i <= 50 ? "ATS" : "OPT",
                    IsAvailable = true
                });
            }
            db.Workspaces.AddRange(list);
            db.SaveChanges();
        }

    }
}
