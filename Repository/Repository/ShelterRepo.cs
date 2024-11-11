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
    public class ShelterRepo : IShelterRepo
    {
        public bool AddShelter(Shelter shelter)
        => ShelterDAO.Instance.AddShelter(shelter);

        public Shelter GetShelterById(int shelterId)
        => ShelterDAO.Instance.GetShelterById(shelterId);

        public List<Shelter> GetShelters()
        => ShelterDAO.Instance.GetShelters();

        public bool RemoveShelter(Shelter shelter)
        => ShelterDAO.Instance.RemoveShelter(shelter);

        public bool UpdateShelter(Shelter shelter)
        => ShelterDAO.Instance.UpdateShelter(shelter);
    }
}
