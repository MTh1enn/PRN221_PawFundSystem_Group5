using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Shelter
{
    public int Id { get; set; }

    public string? ShelterCode { get; set; }

    public string? Location { get; set; }

    public int? ManagedBy { get; set; }

    public string? Phone { get; set; }

    public int? Capacity { get; set; }

    public int? Available { get; set; }

    public virtual User? ManagedByNavigation { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
