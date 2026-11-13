using WebAPI_Jordy_Hurtado_2026_11_13.Data;
using WebAPI_Jordy_Hurtado_2026_11_13.Models;
using WebAPI_Jordy_Hurtado_2026_11_13.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddSingleton<DataDapper>();

builder.Services.AddScoped<EventosService>();
builder.Services.AddScoped<RegistrarEventosService>();



// CORS para Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

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

app.UseCors("AngularPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
