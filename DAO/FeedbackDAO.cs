using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAO
{
    public class FeedbackDAO
    {
        private PawFundContext dbContext;
        private static FeedbackDAO instance;

        public static FeedbackDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FeedbackDAO();
                }
                return instance;
            }
        }

        public FeedbackDAO()
        {
            dbContext = new PawFundContext();
        }

        public List<Feedback> GetFeedbacks()
        {
            return dbContext.Feedbacks.Include(f => f.Pet).Include(f => f.User).ToList();
        }

        public Feedback GetFeedbackById(int id)
        {
            return dbContext.Feedbacks.Include(f => f.Pet).Include(f => f.User)
                .SingleOrDefault(f => f.Id == id);
        }

        public bool AddFeedback(Feedback feedback)
        {
            try
            {
                dbContext.Feedbacks.Add(feedback);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding feedback: {ex.Message}");
                return false;
            }
        }

        public bool UpdateFeedback(Feedback feedback)
        {
            try
            {
                dbContext.Entry(feedback).State = EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating feedback: {ex.Message}");
                return false;
            }
        }
    }
}