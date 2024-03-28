using Microsoft.EntityFrameworkCore;
using Serilog;
using StudentsPortal_API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Logs Config
//Log.Logger=new LoggerConfiguration().MinimumLevel.Debug().
//    WriteTo.File("logs/StudentsLogs.txt",rollingInterval:RollingInterval.Day).CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ConnectionStr")
    ));

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
