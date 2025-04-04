using Microsoft.EntityFrameworkCore;
using TestApp.API.Middlewares;
using TestApp.API.Extensions;
using TestApp.API.Middlewares;
using TestApp.Application;
using TestApp.Infrastructure;
using TestApp.Infrastructure.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<LoggerDbContext>(options => {
//    options.UseSqlServer(builder.Configuration.GetConnectionString("LoggerConn"));
//});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddSwagger();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddApplication();

var app = builder.Build();


app.UseMiddleware<ExceptionMiddleware>();
// app.UseExceptionHandler();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger(); 
app.UseSwaggerUI();
app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
