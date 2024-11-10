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
        public User GetUserById(int id)
        {
            return dbContext.Users.SingleOrDefault(m => m.Id.Equals(id));
        }
        public List<User> GetUsers()
        {
            return dbContext.Users.ToList();
        }
        public void AddUser(User user)
        {
            var checkUser = GetUserById(user.Id);
            try
            {
                if (checkUser == null)
                {
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message); // Kiểm tra thông tin lỗi chi tiết
                throw;
            }
        }
        public void UpdateUser(User user)
        {
            var checkUser = GetUserById(user.Id);
            try
            {
                if (checkUser != null)
                {
                    dbContext.Entry(checkUser).State = EntityState.Detached;
                    dbContext.Users.Attach(user);
                    dbContext.Entry(user).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RemoveUser(User user)
        {
            var checkUser = GetUserById(user.Id);
            try
            {
                if (checkUser != null)
                {
                    dbContext.Users.Remove(user);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
