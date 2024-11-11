using BusinessObjects.Models;
using Repository.IRepository;
using Repository.Repository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class HealthCheckService : IHealthCheckService
    {
        private IHealthCheckRepo _repoHealCheck;
        public HealthCheckService()
        {
            _repoHealCheck = new HealthCheckRepo();
        }
        public bool AddHealthCheck(HealthCheck healthCheck)
        {
            return _repoHealCheck.AddHealthCheck(healthCheck);
        }

        public HealthCheck GetHealthCheckById(int id)
        {
            return _repoHealCheck.GetHealthCheckById(id);
        }

        public List<HealthCheck> GetHealthChecks()
        {
            return _repoHealCheck.GetHealthChecks();
        }

        public bool RemoveHealthCheck(HealthCheck healthCheck)
        {
            return _repoHealCheck.RemoveHealthCheck(healthCheck);
        }

        public bool UpdateHealthCheck(HealthCheck healthCheck)
        {
           return _repoHealCheck.UpdateHealthCheck(healthCheck);
        }
    }
}
