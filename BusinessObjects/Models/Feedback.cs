using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PetId { get; set; }

    public string? Description { get; set; }

    public int? Rating { get; set; }

    public DateTime? FeedbackAt { get; set; }

    public virtual Pet? Pet { get; set; }

    public virtual User? User { get; set; }
}
