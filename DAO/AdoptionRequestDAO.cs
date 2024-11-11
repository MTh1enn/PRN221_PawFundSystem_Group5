using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AdoptionRequestDAO
    {
        public PawFundContext dbContext;
        public static AdoptionRequestDAO instance;
        public static AdoptionRequestDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdoptionRequestDAO();
                }
                return instance;
            }
        }
        public AdoptionRequestDAO()
        {
            dbContext = new PawFundContext();
        }

        public async Task CreateAdoptionRequestAsync(AdoptionRequest adoptionRequest)
        {
            int maxId = dbContext.AdoptionRequests.ToList().Count;
            adoptionRequest.Id = maxId + 1;
            dbContext.AdoptionRequests.Add(adoptionRequest);
            await dbContext.SaveChangesAsync();
        }
        public async Task<List<AdoptionRequest>> GetAll()
        {
            return await dbContext.AdoptionRequests
                .Include(a => a.Pet)
                .Include(a => a.ReviewedByNavigation)
                .Include(a => a.User).ToListAsync();
        }
        public async Task<AdoptionRequest> GetById(int id)
        {
            return await dbContext.AdoptionRequests.FirstOrDefaultAsync(m => m.Id == id);
        }
        public bool Update(AdoptionRequest request)
        {
            var existing = dbContext.AdoptionRequests.Find(request.Id);

            if (existing == null)
            {
                return false;
            }

            request.Id = existing.Id;
            request.UserId = existing.UserId;
            request.RequestDate = existing.RequestDate;
            request.ReviewDate = DateTime.Now;
            dbContext.Entry(existing).CurrentValues.SetValues(request);

            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
