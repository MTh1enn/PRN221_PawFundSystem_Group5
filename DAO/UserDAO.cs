using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UserDAO
    {
        public PawFundContext dbContext;
        public static UserDAO instance;
        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }
        public UserDAO()
        {
            dbContext = new PawFundContext();
        }

        public User GetUserByEmail(string email)
        {
            return dbContext.Users.SingleOrDefault(m => m.Email.Equals(email));
        }
        public User GetUserById(int id)
        {
            return dbContext.Users.SingleOrDefault(m => m.Id.Equals(id));
        }
        public List<User> GetUsers()
        {
            return dbContext.Users.ToList();
        }
        public bool AddUser(User user)
        {
            bool isSuccess = false;
            var checkUser = GetUserById(user.Id);
            try
            {
                if (checkUser == null)
                {
                    int maxId = dbContext.Users.ToList().Count;
                    user.Id = maxId + 1;
                    user.CreatedAt = DateTime.Now;
                    user.UpdatedAt = DateTime.Now;
                    user.Status = "ACTIVE";
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message); // Kiểm tra thông tin lỗi chi tiết
                throw;
            }
        }
        public bool UpdateUser(User user)
        {
            bool isSuccess = false;
            var checkUser = GetUserById(user.Id);
            try
            {
                if (checkUser != null)
                {
                    user.UpdatedAt = DateTime.Now;
                    user.CreatedAt = checkUser.CreatedAt;
                    dbContext.Entry(checkUser).State = EntityState.Detached;
                    dbContext.Users.Attach(user);
                    dbContext.Entry(user).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool RemoveUser(User user)
        {
            bool isSuccess = false;
            var checkUser = GetUserById(user.Id);
            try
            {
                if (checkUser != null)
                {
                    dbContext.Users.Remove(user);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
