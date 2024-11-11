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
        private readonly PawFundContext _context;

        public PetDAO(PawFundContext context)
        {
            _context = context;
        }

        public async Task<List<Pet>> GetAllPetsAsync()
        {
            return await _context.Pets.ToListAsync();
        }
    }
}
