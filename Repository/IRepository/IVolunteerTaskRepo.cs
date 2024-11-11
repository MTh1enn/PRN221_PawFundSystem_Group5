using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IVolunteerTaskRepo
    {
        VolunteerTask GetVolunteerTaskById(int id);
        List<VolunteerTask> GetVolunteerTasks();
        bool AddVolunteerTask(VolunteerTask task);
        bool UpdateVolunteerTask(VolunteerTask task);
        bool RemoveVolunteerTask(VolunteerTask task);
    }
}
