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
    public class PetRepo : IPetRepo
    {
        private readonly PetDAO _petDao;

        public PetRepo(PetDAO petDao)
        {
            _petDao = petDao;
        }

        public async Task<List<Pet>> GetAllPetsAsync()
        {
            return await _petDao.GetAllPetsAsync();
        }
    }
}
