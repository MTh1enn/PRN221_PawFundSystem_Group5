using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class AdoptionRequest
{
    public int Id { get; set; }

    public int? PetId { get; set; }

    public int? UserId { get; set; }

    public DateTime? RequestDate { get; set; }

    public DateTime? ReviewDate { get; set; }

    public int? ReviewedBy { get; set; }

    public string? Notes { get; set; }

    public string? Comment { get; set; }

    public DateTime? AdoptionDate { get; set; }

    public string? Status { get; set; }

    public virtual Pet? Pet { get; set; }

    public virtual User? ReviewedByNavigation { get; set; }

    public virtual User? User { get; set; }
}
