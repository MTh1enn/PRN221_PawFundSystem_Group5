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

        public void AddUser(User user)
        {
            userRepo.AddUser(user);
        }

        public User GetUserById(int id)
        {
           return userRepo.GetUserById(id);
        }

        public List<User> GetUsers()
        {
            return userRepo.GetUsers();
        }

        public void RemoveUser(User user)
        {
            userRepo.RemoveUser(user);
        }

        public void UpdateUser(User user)
        {
            userRepo.UpdateUser(user);
        }
    }
}
