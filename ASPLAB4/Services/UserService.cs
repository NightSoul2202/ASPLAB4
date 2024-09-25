using ASPLAB4.Models;
using ASPLAB4.Services.Interfaces;
using Newtonsoft.Json;

namespace ASPLAB4.Services
{
    public class UserService : IUserService
    {
        private readonly string _usersFilePath = "users.json";

        public List<User> GetUsers()
        {
            if (File.Exists(_usersFilePath))
            {
                var jsonData = File.ReadAllText(_usersFilePath);
                return JsonConvert.DeserializeObject<List<User>>(jsonData);
            }
            return new List<User>();
        }

        public User GetUserById(int id)
        {
            var users = GetUsers();
            return users.Find(u => u.Id == id);
        }
    }
}
