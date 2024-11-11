using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IAdoptionRequestRepo
    {
        public Task CreateAdoptionRequestAsync(AdoptionRequest adoptionRequest);
        public Task<List<AdoptionRequest>> GetAll();
        public Task<AdoptionRequest> GetById(int id);
        public bool Update(AdoptionRequest request);
    }
}
