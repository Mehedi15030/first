using System;
using System.Collections.Generic;

namespace first.Models;

public partial class ErrorLog
{
    public int ErrorId { get; set; }

    public int MachineId { get; set; }

    public string ErrorCode { get; set; } = null!;

    public string? ErrorDescription { get; set; }

    public DateTime OccurrenceDate { get; set; }

    public DateTime? ResolutionDate { get; set; }

    public string? ResolutionDescription { get; set; }

    public virtual Machine Machine { get; set; } = null!;
}
