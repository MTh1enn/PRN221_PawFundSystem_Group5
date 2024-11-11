using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IUserRepo
    {
        public User GetUserByEmail(string email);
        public User GetUserById(int id);
        public List<User> GetUsers();
        public bool AddUser(User user);
        public bool UpdateUser(User user);
        public bool RemoveUser(User user);
    }
}
