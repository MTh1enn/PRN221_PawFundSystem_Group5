using BusinessObjects.Models;
using DAO;
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
    }
}