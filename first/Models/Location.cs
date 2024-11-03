using System;
using System.Collections.Generic;

namespace first.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? Divison { get; set; }

    public string? District { get; set; }

    public string? Upazila { get; set; }

    public string? Postoffice { get; set; }

    public string? PostalCode { get; set; }

    public string? ContactPerson { get; set; }

    public string? ContactPhone { get; set; }

    public virtual ICollection<Machine> Machines { get; set; } = new List<Machine>();
}
