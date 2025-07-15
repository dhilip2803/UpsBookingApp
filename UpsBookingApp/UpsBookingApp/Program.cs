using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using UpsBookingApp.Client.Pages;
using UpsBookingApp.Components;
using UPSBookingApp.Client.Services;
using UPSBookingApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add EF Core with SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=booking.db"));

// Register backend services
builder.Services.AddControllers();
builder.Services.AddSingleton<BookingService>();
builder.Services.AddSingleton<UserContext>();

builder.Services.AddScoped(sp =>
{
    var nav = sp.GetRequiredService<NavigationManager>();
    return new HttpClient { BaseAddress = new Uri(nav.BaseUri) };
});

// Add Razor Components (Blazor WebAssembly mode)
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddScoped<UserContext>();
var app = builder.Build();

// Apply DB migration and seed
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    DbSeeder.Seed(db);
}

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(UpsBookingApp.Client._Imports).Assembly);

app.Run();
