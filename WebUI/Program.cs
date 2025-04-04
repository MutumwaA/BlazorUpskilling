using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NetcodeHub.Packages.Components.Toast;
using WebUI;
using Application.DependencyInjection;
using NetcodeHub.Packages.Components;
using WebUI.SignalRConnection;
using Domain.Entity.Authentication;
using Microsoft.AspNetCore.Identity;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddApplicationService();
builder.Services.AddScoped<ToastService>();
builder.Services.AddScoped<SignalRConnection>();
builder.Services.AddVirtualizationService();
await builder.Build().RunAsync();
