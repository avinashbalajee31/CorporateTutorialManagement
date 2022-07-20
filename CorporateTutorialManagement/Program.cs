using CorporateTutorialManagement.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var connectionString = "server=localhost;port=3306;user=root;password=avib3131@SQL;database=corporatetutorialmanagement";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));

// Add services to the container.

builder.Services.AddDbContext<corporatetutorialmanagementContext>(options =>
{
    // options. (builder.Configuration.GetConnectionString("Mysql"));
    object value = options.UseMySql(connectionString, serverVersion);
}); ;

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
