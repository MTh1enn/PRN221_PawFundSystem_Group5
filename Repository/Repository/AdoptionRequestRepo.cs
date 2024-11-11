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
    public class AdoptionRequestRepo : IAdoptionRequestRepo
    {
        public Task CreateAdoptionRequestAsync(AdoptionRequest adoptionRequest)
        => AdoptionRequestDAO.Instance.CreateAdoptionRequestAsync(adoptionRequest);

        public async Task<List<AdoptionRequest>> GetAll()
        {
           return await AdoptionRequestDAO.Instance.GetAll();
        }

        public async Task<AdoptionRequest> GetById(int id)
        {
            return await AdoptionRequestDAO.Instance.GetById(id);
        }

        public bool Update(AdoptionRequest request)
        {
            return AdoptionRequestDAO.Instance.Update(request);
        }
    }
}
