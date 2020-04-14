using BlabberApp.DataStore;
using BlabberApp.Domain;
using System.Collections;
using System.Linq;

namespace BlabberApp.Services
{
    public class UserService : IUserService
    {
        private MySqlRepository<User> _repository;

        public UserService()
        {
            //_repository = new MySqlRepository<User>();
        }

        public void AddUser(User user)
        {
            _repository.Insert(user);
        }

        public User GetUserByEmail(string email)
        {
            var users = _repository.GetAll().Cast<User>().ToList();;
            return users.First(u => u.Email == email);
        }

        public IEnumerable GetAll()
        {
            return _repository.GetAll();
        }
    }
}