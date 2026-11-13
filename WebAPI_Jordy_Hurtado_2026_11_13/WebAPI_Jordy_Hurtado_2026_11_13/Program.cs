using WebAPI_Jordy_Hurtado_2026_11_13.Data;
using WebAPI_Jordy_Hurtado_2026_11_13.Models;
using WebAPI_Jordy_Hurtado_2026_11_13.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddSingleton<DataDapper>();

builder.Services.AddScoped<EventosService>();
builder.Services.AddScoped<RegistrarEventosService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
