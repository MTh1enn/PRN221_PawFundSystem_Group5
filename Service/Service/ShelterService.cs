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
    public class ShelterService : IShelterService
    {
        private readonly IShelterRepo shelterRepo;
        public ShelterService(ShelterRepo shelter) { 
            shelterRepo = shelter;
        }

        public List<Shelter> GetShelters()
        {
           return shelterRepo.getShelters();
        }
    }
}
