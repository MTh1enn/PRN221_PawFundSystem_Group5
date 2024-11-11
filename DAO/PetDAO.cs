using BusinessObjects.Models;
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
       
    }
}
