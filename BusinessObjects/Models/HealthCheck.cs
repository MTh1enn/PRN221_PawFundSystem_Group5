using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class HealthCheck
{
    public int Id { get; set; }

    public int? PetId { get; set; }

    public string? HealthStatus { get; set; }

    public string? HealthStatusDescription { get; set; }

    public string? Note { get; set; }

    public double? Weight { get; set; }

    public double? Temperature { get; set; }

    public DateTime? CheckDate { get; set; }

    public int? CheckedBy { get; set; }

    public string? CheckType { get; set; }

    public virtual User? CheckedByNavigation { get; set; }

    public virtual Pet? Pet { get; set; }
}
