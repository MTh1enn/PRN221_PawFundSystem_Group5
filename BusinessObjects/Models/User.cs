using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Avatar { get; set; }

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Position { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? Role { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<AdoptionRequest> AdoptionRequestReviewedByNavigations { get; set; } = new List<AdoptionRequest>();

    public virtual ICollection<AdoptionRequest> AdoptionRequestUsers { get; set; } = new List<AdoptionRequest>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<HealthCheck> HealthChecks { get; set; } = new List<HealthCheck>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Shelter> Shelters { get; set; } = new List<Shelter>();

    public virtual ICollection<VolunteerTask> VolunteerTaskAssignedByNavigations { get; set; } = new List<VolunteerTask>();

    public virtual ICollection<VolunteerTask> VolunteerTaskAssignedToNavigations { get; set; } = new List<VolunteerTask>();
}
