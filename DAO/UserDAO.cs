using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UserDAO
    {
        private PawFundContext _context;
        private static UserDAO instance = null;

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
            _context = new PawFundContext();
        }

        public User? getUserByEmail(string email) { 
            return _context.Users.SingleOrDefault(u => u.Email.Equals( email));
        }

    }
}
