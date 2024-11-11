using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HealthCheckDAO
    {
        private PawFundContext dbContext;
        private static HealthCheckDAO instance = null;
        public static HealthCheckDAO Instance { 
            get { 
                if(instance == null)
                {
                    instance = new HealthCheckDAO();
                }
                return instance;
            }
        }
        public HealthCheckDAO()
        {
            dbContext = new PawFundContext();
        }

        public List<HealthCheck> GetHealthChecks()
        {
            return dbContext.HealthChecks.ToList();
        }

        public HealthCheck GetHealthCheck(int id)
        {
            return dbContext.HealthChecks.SingleOrDefault(m => m.Id.Equals(id));
        }

        public bool AddHealthCheck(HealthCheck healthCheck)
        {
           bool result = false;
           HealthCheck? check= GetHealthCheck(healthCheck.Id);
            try
            {
                if (check == null)
                {
                    dbContext.HealthChecks.Add(healthCheck);
                    dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }
        public bool RemoveHealthCheck(HealthCheck healthCheck)
        {
            bool result = false;
            HealthCheck? check = GetHealthCheck(healthCheck.Id);
            try
            {
                if (check != null)
                {
                    dbContext.HealthChecks.Remove(healthCheck);
                    dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public bool UpdateHealCheck(HealthCheck healthCheck)
        {
            bool result = false;
            HealthCheck? check = GetHealthCheck(healthCheck.Id);
            try
            {
                if (check == null)
                {
                    dbContext.HealthChecks.Update(healthCheck);
                    dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }


        }
}
