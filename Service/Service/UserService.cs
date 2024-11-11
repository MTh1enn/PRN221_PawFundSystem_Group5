using BusinessObjects.Models;
using Repository.IRepository;
using Repository.Repository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class UserService: IUserService
    {
        private IUserRepo userRepo;
        public UserService()
        {
            userRepo = new UserRepo();
        }

        public User GetUserByEmail(string email)
        {
           return userRepo.GetUserByEmail(email);
        }

        public bool AddUser(User user)
        {
            return userRepo.AddUser(user);
        }

        public User GetUserById(int id)
        {
           return userRepo.GetUserById(id);
        }

        public List<User> GetUsers()
        {
            return userRepo.GetUsers();
        }

        public bool RemoveUser(User user)
        {
            return userRepo.RemoveUser(user);
        }

        public bool UpdateUser(User user)
        {
            return userRepo.UpdateUser(user);
        }
    }
}
