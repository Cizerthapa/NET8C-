using WebApplication1.Entities;

namespace WebApplication1.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new();

    public UserService()
    {
    }

    public List<User> GetAllUsers() => _users;
    public User? GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public User? GetUserById(Guid id) => _users.FirstOrDefault(u => u.Id == id);

    public User CreateUser(User user)
    {
        user.Id = Guid.NewGuid(); // Ensure a new Guid is generated for the user
        _users.Add(user);
        return user;
    }

    public User? UpdateUser(int id, User updatedUser)
    {
        throw new NotImplementedException();
    }

    public bool DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public User? UpdateUser(Guid id, User updatedUser)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is null) return null;

        user.FirstName = updatedUser.FirstName;
        user.LastName = updatedUser.LastName;
        user.Gender = updatedUser.Gender;
        user.ImageURL = updatedUser.ImageURL;
        user.RegisterDate = updatedUser.RegisterDate;
        user.IsActive = updatedUser.IsActive;
        return user;
    }

    public bool DeleteUser(Guid id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is null) return false;

        _users.Remove(user);
        return true;
    }
}