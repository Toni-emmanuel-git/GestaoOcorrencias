using GestaoOcorrencias.WebApi;
using GestaoOcorrencias.WebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IOcorrenciaService, OcorrenciaService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<GestaoOcorrenciasDbContext>(opt =>
 {
     var connectionString = builder.Configuration
         .GetSection("Database")
         .GetValue<string>("ConnectionString");
     opt.UseSqlServer(connectionString);
 });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
