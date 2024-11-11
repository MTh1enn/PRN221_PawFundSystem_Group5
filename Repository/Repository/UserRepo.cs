using BusinessObjects.Models;
using DAO;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UserRepo : IUserRepo
    {
        public User GetUserByEmail(string email) => UserDAO.Instance.GetUserByEmail(email);
        public bool AddUser(User user)
        => UserDAO.Instance.AddUser(user);

        public User GetUserById(int id)
        => UserDAO.Instance.GetUserById(id);

        public List<User> GetUsers()
        => UserDAO.Instance.GetUsers();

        public bool RemoveUser(User user)
        => UserDAO.Instance.RemoveUser(user);

        public bool UpdateUser(User user)
        => UserDAO.Instance.UpdateUser(user);
    }
}
