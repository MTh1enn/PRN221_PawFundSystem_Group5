using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
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

        public PetService(IPetRepo petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<List<Pet>> GetAllPetsAsync()
        {
            return await _petRepository.GetAllPetsAsync();
        }
    }
}
