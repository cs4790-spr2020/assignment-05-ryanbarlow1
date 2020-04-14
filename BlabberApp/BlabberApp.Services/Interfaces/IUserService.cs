using BlabberApp.Domain;
using System.Collections;

namespace BlabberApp.Services
{
    public interface IUserService
    {
       void AddUser(User user);

       User GetUserByEmail(string email);

       IEnumerable GetAll(); 
    }
}