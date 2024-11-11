using BusinessObjects.Models;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class AdoptionRequestService : IAdoptionRequestService
    {
        private readonly PawFundContext _context;

        public AdoptionRequestService(PawFundContext context)
        {
            _context = context;
        }

        public async Task CreateAdoptionRequestAsync(AdoptionRequest adoptionRequest)
        {
            _context.AdoptionRequests.Add(adoptionRequest);
            await _context.SaveChangesAsync();
        }
    }
}
