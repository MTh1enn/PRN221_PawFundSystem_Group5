using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Event
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? Location { get; set; }

    public string? Status { get; set; }

    public virtual User? User { get; set; }
}
