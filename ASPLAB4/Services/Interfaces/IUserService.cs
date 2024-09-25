using ASPLAB4.Models;

namespace ASPLAB4.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUserById(int id);
    }
}
