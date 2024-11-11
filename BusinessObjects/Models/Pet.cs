using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Pet
{
    public int Id { get; set; }

    public int? ShelterId { get; set; }

    public string? Image { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Color { get; set; }

    public string? Breed { get; set; }

    public bool? IsVaccinated { get; set; }

    public bool? IsNeutered { get; set; }

    public string? Gender { get; set; }

    public string? DeliveryStatus { get; set; }

    public string? Notes { get; set; }

    public DateTime? RescueDate { get; set; }

    public string? RescueLocation { get; set; }

    public int? RescuedBy { get; set; }

    public double? Height { get; set; }

    public double? Weight { get; set; }

    public string? HealStatus { get; set; }

    public bool? IsAdopted { get; set; }

    public int? OwnerId { get; set; }

    public string? PetStatus { get; set; }

    public virtual ICollection<AdoptionRequest> AdoptionRequests { get; set; } = new List<AdoptionRequest>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<HealthCheck> HealthChecks { get; set; } = new List<HealthCheck>();

    public virtual User? Owner { get; set; }

    public virtual Shelter? Shelter { get; set; }
    public string? HealthStatus
    {
        get; set;
    }
}
