﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IHealthCheckService
    {
        HealthCheck GetHealthCheckById(int id);
        List<HealthCheck> GetHealthChecks();
        bool AddHealthCheck(HealthCheck healthCheck);
        bool UpdateHealthCheck(HealthCheck healthCheck);
        bool RemoveHealthCheck(HealthCheck healthCheck);
    }
}
