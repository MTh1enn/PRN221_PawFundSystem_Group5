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
    }
}
