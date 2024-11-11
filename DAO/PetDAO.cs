using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PetDAO
    {
        private PawFundContext context;
        private static PetDAO instance = null;

        public static PetDAO Instance {  
            get 
            { 
                if(instance == null)
                {
                    instance= new PetDAO();
                } 
                return instance; 
            }
        }
        public PetDAO()
        {
            context = new PawFundContext();
        }

        public List<Pet> GetPets()
        {

            return context.Pets.ToList();
        }
        public Pet GetPetById(int id)
        {
            return context.Pets.SingleOrDefault(m => m.Id.Equals(id));
        }
        public bool AddPet(Pet pet)
        {
            bool result = false;
            Pet petExisted = GetPetById(pet.Id);
            try
            {
                if (petExisted == null)
                {
                    context.Pets.Add(pet);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
        public async Task<List<Pet>> GetAllPetsAsync()
        {
            return await context.Pets.ToListAsync();
        }
        public async Task<bool> UpdatePetHealthStatusAsync(int petId, string healthStatus)
        {
            var pet = await context.Pets.FindAsync(petId);
            if (pet == null) return false;

            pet.HealthStatus = healthStatus;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Pet>> GetAdoptedPetsByUserIdAsync(int userId)
        {
            return await context.Pets.Where(p => p.OwnerId == userId && p.IsAdopted == true).ToListAsync();
        }
    }
}
