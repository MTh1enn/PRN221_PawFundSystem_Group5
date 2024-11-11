using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ShelterDAO
    {
        private PawFundContext  context;
        private static ShelterDAO instance =null;
        public static ShelterDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShelterDAO();
                }
                return instance;
            }
        }

        public ShelterDAO() { 
        
            context = new PawFundContext();
        }

        public List<Shelter> getShelters()
        {
            return context.Shelters.ToList();
        }
    }
}
