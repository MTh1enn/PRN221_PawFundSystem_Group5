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

        public async Task<List<AdoptionRequest>> GetAll()
        {
            return await adoptionRequestRepo.GetAll();
        }

        public async Task<AdoptionRequest> GetById(int id)
        {
            return await adoptionRequestRepo.GetById(id);
        }

        public bool Update(AdoptionRequest request)
        {
            return adoptionRequestRepo.Update(request);
        }
    }
}
