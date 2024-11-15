﻿using BusinessObjects.Models;
using DAO;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using Repository.IRepository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PetRepo : IPetRepo
    {
        public async Task<List<Pet>> GetAllPetsAsync()
        {
            return await PetDAO.Instance.GetAllPetsAsync();
        }

        public List<Pet> GetAllPets() { 
            return PetDAO.Instance.GetPets();
        }
        public bool AddPet(Pet pet)
        {
            return PetDAO.Instance.AddPet(pet);
        }

        public async Task<bool> UpdatePetHealthStatusAsync(int petId, string healthStatus)
        {
            return await PetDAO.Instance.UpdatePetHealthStatusAsync(petId, healthStatus);
        }
        public async Task<List<Pet>> GetAdoptedPetsByUserIdAsync(int userId)
        {
            return await PetDAO.Instance.GetAdoptedPetsByUserIdAsync(userId);

        }

        public async Task<Pet> GetPetById(int id)
        {
            return PetDAO.Instance.GetPetById(id);
        }

        public bool UpdatePet(Pet pet)
        {
            return PetDAO.Instance.UpdatePet(pet);
        }
    }
}