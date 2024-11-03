using System;
using System.Collections.Generic;

namespace first.Models;

public partial class MaintenanceLog
{
    public int MaintenanceId { get; set; }

    public int MachineId { get; set; }

    public int TechnicianId { get; set; }

    public DateTime ServiceDate { get; set; }

    public string? Description { get; set; }

    public decimal? Cost { get; set; }

    public DateOnly? NextServiceDate { get; set; }

    public virtual Machine Machine { get; set; } = null!;
}
