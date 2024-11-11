using BusinessObjects.Models;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IFeebackService
    {
        public List<Feedback> GetFeedbacks();
        public Feedback GetFeedbackById(int id);

        public bool AddFeedback(Feedback feedback);

        public bool UpdateFeedback(Feedback feedback);
    }
}
