using GestaoOcorrencias.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddHttpClient<IClienteService, ClienteService>((provider, client) =>
{
    var url = builder.Configuration.GetSection("WebApi").GetValue<string>("Url");
    client.BaseAddress = new Uri(url);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
