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
    public class AdoptionRequestService : IAdoptionRequestService
    {
        private readonly IAdoptionRequestRepo adoptionRequestRepo;

        public AdoptionRequestService()
        {
            adoptionRequestRepo = new AdoptionRequestRepo();
        }

        public async Task CreateAdoptionRequestAsync(AdoptionRequest adoptionRequest)
        {
            await adoptionRequestRepo.CreateAdoptionRequestAsync(adoptionRequest);
        }
    }
}
