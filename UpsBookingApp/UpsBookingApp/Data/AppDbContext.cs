using Microsoft.EntityFrameworkCore;
using UpsBookingApp.Client.Models;

namespace UPSBookingApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Desk> Desks => Set<Desk>();
    public DbSet<Booking> Bookings => Set<Booking>();

    public DbSet<User> Users { get; set; }
}
