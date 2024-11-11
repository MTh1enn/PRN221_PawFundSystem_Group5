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
    public class ShelterService: IShelterService
    {
        private IShelterRepo shelterRepo;
        public ShelterService()
        {
            shelterRepo = new ShelterRepo();
        }

        public bool AddShelter(Shelter shelter)
        {
            return shelterRepo.AddShelter(shelter);
        }

        public Shelter GetShelterById(int shelterId)
        {
            return shelterRepo.GetShelterById(shelterId);
        }

        public List<Shelter> GetShelters()
        {
            return shelterRepo.GetShelters();
        }

        public bool RemoveShelter(Shelter shelter)
        {
            return shelterRepo.RemoveShelter(shelter);
        }

        public bool UpdateShelter(Shelter shelter)
        {
            return shelterRepo.UpdateShelter(shelter);
        }
    }
}
