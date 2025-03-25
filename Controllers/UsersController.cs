using WebApplication1.Entities;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

public static class UserController
{
    public static void MapUserRoutes(this WebApplication app)
    {
        var userService = app.Services.GetRequiredService<IUserService>();

        // Create User
        app.MapPost("/users", (User user) =>
            {
                var createdUser = userService.CreateUser(user);
                return Results.Created($"/users/{createdUser.Id}", createdUser);
            })
            .WithName("CreateUser")
            .WithOpenApi();

        // Get All Users
        app.MapGet("/users", () => Results.Ok(userService.GetAllUsers()))
            .WithName("GetUsers")
            .WithOpenApi();

        // Get User by ID
        app.MapGet("/users/{id:int}", (int id) =>
            {
                var user = userService.GetUserById(id);
                return user is not null ? Results.Ok(user) : Results.NotFound("User not found");
            })
            .WithName("GetUserById")
            .WithOpenApi();

        // Update User
        app.MapPut("/users/{id:int}", (int id, User updatedUser) =>
            {
                var user = userService.UpdateUser(id, updatedUser);
                return user is not null ? Results.Ok(user) : Results.NotFound("User not found");
            })
            .WithName("UpdateUser")
            .WithOpenApi();

        // Delete User
        app.MapDelete("/users/{id:int}", (int id) =>
            {
                var deleted = userService.DeleteUser(id);
                return deleted ? Results.Ok($"User with ID {id} deleted") : Results.NotFound("User not found");
            })
            .WithName("DeleteUser")
            .WithOpenApi();
    }
}