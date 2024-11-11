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
            dbContext.AdoptionRequests.Add(adoptionRequest);
            await dbContext.SaveChangesAsync();
        }
    }
}
