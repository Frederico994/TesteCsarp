var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddRazorPages();

/** pedaço de codigo inicio */
//builder.Services.AddHttpClient();

builder.Services.AddHttpClient("RestCountries", c =>
{
    c.BaseAddress = new Uri("https://restcountries.com/");
})
.ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler
    {
        SslProtocols = System.Security.Authentication.SslProtocols.Tls12
    };
});
/** pedaço de codigo fim*/

var app = builder.Build();