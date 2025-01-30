using AirCesiFrontWeb.Components;
using AirCesiFrontWeb.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Ajout du service client de l'API avec pré-authentification
var apiService = new ApiService("https://localhost:44373/");
var loginResponse = await apiService.Login("nclavere@adista.fr", "aZ123456@");
if (!loginResponse)
{
    throw new Exception("Authentication failed");
}
builder.Services.AddScoped<ApiService>(_ => apiService);

//Ajout des composants Razor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
