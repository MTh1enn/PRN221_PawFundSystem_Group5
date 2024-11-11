using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IUserService
    {
        public User GetUserByEmail(string email);
        public User GetUserById(int id);
        public List<User> GetUsers();
        public void AddUser(User user);
        public void UpdateUser(User user);
        public void RemoveUser(User user);
    }
}
