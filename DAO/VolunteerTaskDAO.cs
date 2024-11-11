using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class VolunteerTaskDAO
    {
        private PawFundContext dbContext;
        private static VolunteerTaskDAO instance;


        public static VolunteerTaskDAO Instance {
            
            get{
                if (instance == null)
                {
                    instance = new VolunteerTaskDAO();
                }
                return instance;
            }
        }

        public VolunteerTaskDAO()
        {
            dbContext = new PawFundContext();
        }


        public VolunteerTask GetVolunteerTaskById(int id)
        {
            return dbContext.VolunteerTasks.SingleOrDefault(v => v.Id == id);
        }

        public List<VolunteerTask> GetVolunteerTasks()
        {
            return dbContext.VolunteerTasks.ToList();
        }

        public bool AddVolunteerTask(VolunteerTask task)
        {
            bool isSuccess = false;
            var checkTask = GetVolunteerTaskById(task.Id);

            try
            {
                if (checkTask == null)
                {
                    dbContext.VolunteerTasks.Add(task);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message); // Log detailed error info
                throw;
            }
        }

        public bool UpdateVolunteerTask(VolunteerTask task)
        {
            bool isSuccess = false;
            var checkTask = GetVolunteerTaskById(task.Id);

            try
            {
                if (checkTask != null)
                {
                    dbContext.Entry(checkTask).State = EntityState.Detached;
                    dbContext.VolunteerTasks.Attach(task);
                    dbContext.Entry(task).State = EntityState.Modified;
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

        public bool RemoveVolunteerTask(VolunteerTask task)
        {
            bool isSuccess = false;
            var checkTask = GetVolunteerTaskById(task.Id);

            try
            {
                if (checkTask != null)
                {
                    dbContext.VolunteerTasks.Remove(task);
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
