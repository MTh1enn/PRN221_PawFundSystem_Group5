﻿using BusinessObjects.Models;
using DAO;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class AdoptionRequestRepo : IAdoptionRequestRepo
    {
        public Task CreateAdoptionRequestAsync(AdoptionRequest adoptionRequest)
        => AdoptionRequestDAO.Instance.CreateAdoptionRequestAsync(adoptionRequest);
    }
}
