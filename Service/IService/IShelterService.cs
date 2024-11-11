using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IShelterService
    {
        public List<Shelter> GetShelters();
        public Shelter GetShelterById(int shelterId);
        public bool AddShelter(Shelter shelter);
        public bool UpdateShelter(Shelter shelter);

        public bool RemoveShelter(Shelter shelter);

    }
}
