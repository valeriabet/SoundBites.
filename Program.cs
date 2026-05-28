using Microsoft.EntityFrameworkCore;
using SoundBitesAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionDB"))
     );
// Add services to the container.

builder.Services.AddControllers();

// Conexion con React

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirReact", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://localhost:5025", "https://localhost:7117")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
var app = builder.Build();

/*
 * app.MapGet("/" , (HttpContext context) => {
    context.Response.Redirect("swagger/index,html", permanent: false);
    });
*/


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //   app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PermitirReact");

app.UseAuthorization();

app.MapControllers();

app.Run();
