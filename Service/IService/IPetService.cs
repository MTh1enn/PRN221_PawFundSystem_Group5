using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IPetService
    {
        public Task<List<Pet>> GetAllPetsAsync();

        public bool AddPet(Pet pet);

        public Task<bool> UpdatePetHealthStatusAsync(int petId, string healthStatus);

        public Task<List<Pet>> GetAdoptedPetsByUserIdAsync(int userId);

    }
}
