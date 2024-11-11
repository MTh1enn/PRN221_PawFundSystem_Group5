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
    public class FeedbackRepo : IFeebackService
    {
        public List<Feedback> GetFeedbacks() => FeedbackDAO.Instance.GetFeedbacks();

        public Feedback GetFeedbackById(int id) => FeedbackDAO.Instance.GetFeedbackById(id);

        public bool AddFeedback(Feedback feedback) => FeedbackDAO.Instance.AddFeedback(feedback);

        public bool UpdateFeedback(Feedback feedback) => FeedbackDAO.Instance.UpdateFeedback(feedback);
    }
}
