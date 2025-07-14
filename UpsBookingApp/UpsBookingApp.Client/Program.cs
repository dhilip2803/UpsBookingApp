using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UPSBookingApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.RootComponents.Add<App>("#app");
builder.Services.AddSingleton<BookingService>();
builder.Services.AddSingleton<UserContext>();

await builder.Build().RunAsync();
