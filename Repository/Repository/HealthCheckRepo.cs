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
    public class HealthCheckRepo : IHealthCheckRepo
    {
        public bool AddHealthCheck(HealthCheck healthCheck)=> HealthCheckDAO.Instance.AddHealthCheck(healthCheck);
        public HealthCheck GetHealthCheckById(int id)=> HealthCheckDAO.Instance.GetHealthCheck(id);
        public List<HealthCheck> GetHealthChecks()=> HealthCheckDAO.Instance.GetHealthChecks();

        public bool RemoveHealthCheck(HealthCheck healthCheck)=> HealthCheckDAO.Instance.RemoveHealthCheck(healthCheck);
        public bool UpdateHealthCheck(HealthCheck healthCheck)=> HealthCheckDAO.Instance.UpdateHealCheck(healthCheck);
    }
}
