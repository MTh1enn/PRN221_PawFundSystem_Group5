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
    public class VolunteerTaskService : IVolunteerTaskService
    {
        private IVolunteerTaskRepo VolunteerTaskRepo;
        public VolunteerTaskService()
        {
            VolunteerTaskRepo = new VolunteerTaskRepo();
        }
        public bool AddVolunteerTask(VolunteerTask task)
        {
            return VolunteerTaskRepo.AddVolunteerTask(task);
        }

        public VolunteerTask GetVolunteerTaskById(int id)
        {
            return VolunteerTaskRepo.GetVolunteerTaskById(id);
        }

        public List<VolunteerTask> GetVolunteerTasks()
        {
            return VolunteerTaskRepo.GetVolunteerTasks();
        }

        public bool RemoveVolunteerTask(VolunteerTask task)
        {
            return VolunteerTaskRepo.RemoveVolunteerTask(task);
        }

        public bool UpdateVolunteerTask(VolunteerTask task)
        {
            return VolunteerTaskRepo.UpdateVolunteerTask(task);
        }
    }
}
