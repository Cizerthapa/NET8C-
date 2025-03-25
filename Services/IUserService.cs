using WebApplication1.Entities;

namespace WebApplication1.Services;

    public interface IUserService
    {
        List<User> GetAllUsers();
        User? GetUserById(int id);
        User CreateUser(User user);
        User? UpdateUser(int id, User updatedUser);
        bool DeleteUser(int id);
    }
