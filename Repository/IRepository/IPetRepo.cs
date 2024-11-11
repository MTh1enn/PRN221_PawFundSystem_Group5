﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    using BusinessObjects.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Repository.IRepository
    {
        public interface IPetRepo
        {
            Task<List<Pet>> GetAllPetsAsync();

            public bool AddPet(Pet pet);
        }
    }
}
