using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    using BusinessObjects.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Repository.IRepository
    {
        public interface IPetRepo
        {
            Task<List<Pet>> GetAllPetsAsync();

            public bool AddPet(Pet pet);
            public bool UpdatePet(Pet pet);
            Task<bool> UpdatePetHealthStatusAsync(int petId, string healthStatus);

            Task<List<Pet>> GetAdoptedPetsByUserIdAsync(int userId);

            public Task<Pet> GetPetById(int id);

        }
    }
}
