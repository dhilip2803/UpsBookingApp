using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UPSBookingApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<BookingService>();

await builder.Build().RunAsync();
