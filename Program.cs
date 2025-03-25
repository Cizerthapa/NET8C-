using WebApplication1.Controllers;
using Microsoft.EntityFrameworkCore;
using WebApplication1.data;

var builder = WebApplication.CreateBuilder(args);

// Add API Explorer for Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure PostgreSQL DbContext
builder.Services.AddDbContext<ApplicationDbContext>(d =>
    d.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Register UserService
// builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

// Enable Swagger in Development Environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "User CRUD API v1");
    });
}

app.UseAuthentication();

app.UseHttpsRedirection();

// Map User Routes
app.MapUserRoutes();

app.Run();