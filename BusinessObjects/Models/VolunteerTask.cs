using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class VolunteerTask
{
    public int Id { get; set; }

    public int? AssignedBy { get; set; }

    public int? AssignedTo { get; set; }

    public string? TaskDescription { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime? CompletedDate { get; set; }

    public string? Priority { get; set; }

    public string? Status { get; set; }

    public virtual User? AssignedByNavigation { get; set; }

    public virtual User? AssignedToNavigation { get; set; }
}
