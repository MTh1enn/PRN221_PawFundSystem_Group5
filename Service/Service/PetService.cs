﻿using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using Repository.IRepository.Repository.IRepository;
using Repository.Repository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class PetService : IPetService
    {
        private readonly IPetRepo _petRepository;

        public PetService()
        {
            _petRepository = new PetRepo();
        }

        public async Task<List<Pet>> GetAllPetsAsync()
        {
            return await _petRepository.GetAllPetsAsync();
        }

        public bool AddPet(Pet pet)
        {
            return _petRepository.AddPet(pet);
        }
    }
}
