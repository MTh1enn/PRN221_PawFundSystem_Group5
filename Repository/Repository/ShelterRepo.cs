using BusinessObjects.Models;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace Repository.Repository
{
    public class ShelterRepo : IShelterRepo
    {
        public List<Shelter> getShelters() => ShelterDAO.Instance.getShelters();
        
    }
}
