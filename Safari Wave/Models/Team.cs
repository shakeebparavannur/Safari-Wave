using System;
using System.Collections.Generic;

namespace Safari_Wave.Models;

public partial class Team
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string? EmployeeDescription { get; set; }

    public string? EmployeeImgUrl { get; set; }

    public int PackageId { get; set; }

    public virtual Package Package { get; set; } = null!;
}
