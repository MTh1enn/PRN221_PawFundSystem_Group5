using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ShelterDAO
    {

        public PawFundContext dbContext;
        public static ShelterDAO instance;

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


        public ShelterDAO()
        {

            dbContext = new PawFundContext();
        }

        public List<Shelter> GetShelters()
        {
            return dbContext.Shelters.ToList();
        }

        


        public Shelter GetShelterById(int shelterId)
        {
            return dbContext.Shelters.SingleOrDefault(m => m.Id.Equals(shelterId));
        }
        public bool AddShelter(Shelter shelter)
        {
            bool isSuccess = false;
            try
            {
                var checkShelter = GetShelterById(shelter.Id);
                if (checkShelter == null)
                {
                    int maxId = dbContext.Shelters.ToList().Count;
                    shelter.Id = maxId + 1;

                    var random = new Random();
                    string shelterCode;
                    bool isUnique;
                    do
                    {
                        int randomNumber = random.Next(1, 1000);
                        shelterCode = $"S{randomNumber:D3}";
                        isUnique = !dbContext.Shelters.Any(s => s.ShelterCode == shelterCode);
                    } while (!isUnique);
                    shelter.ShelterCode = shelterCode;

                    dbContext.Add(shelter);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateShelter(Shelter shelter)
        {
            try
            {
                bool isSuccess = false;
                var checkShelter = GetShelterById(shelter.Id);
                if (checkShelter != null)
                {
                    shelter.ShelterCode = checkShelter.ShelterCode;
                    dbContext.Entry(checkShelter).State = EntityState.Detached;
                    dbContext.Shelters.Attach(shelter);
                    dbContext.Entry(shelter).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool RemoveShelter(Shelter shelter)
        {
            bool isSuccess = false;
            try
            {
                var checkShelter = GetShelterById(shelter.Id);
                if (checkShelter != null)
                {
                    dbContext.Remove(shelter);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

