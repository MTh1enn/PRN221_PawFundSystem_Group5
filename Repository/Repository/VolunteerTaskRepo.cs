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
    public class VolunteerTaskRepo : IVolunteerTaskRepo
    {
        public bool AddVolunteerTask(VolunteerTask task) => VolunteerTaskDAO.Instance.AddVolunteerTask(task);


        public VolunteerTask GetVolunteerTaskById(int id)=> VolunteerTaskDAO.Instance.GetVolunteerTaskById(id);

        public List<VolunteerTask> GetVolunteerTasks()=> VolunteerTaskDAO.Instance.GetVolunteerTasks();

        public bool RemoveVolunteerTask(VolunteerTask task)=> VolunteerTaskDAO.Instance.RemoveVolunteerTask(task);

        public bool UpdateVolunteerTask(VolunteerTask task) => VolunteerTaskDAO.Instance.UpdateVolunteerTask(task);
    }
}
