using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IFeedbackService
    {
        public List<Feedback> GetFeedbacks();
        public Feedback GetFeedbackById(int id);

        public bool AddFeedback(Feedback feedback);

        public bool UpdateFeedback(Feedback feedback);
    }
}
