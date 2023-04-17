using System;
using System.Collections.Generic;

namespace Safari_Wave.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public string? Review1 { get; set; }

    public int Rating { get; set; }

    public int PackageId { get; set; }

    public string UserName { get; set; } = null!;

    public virtual Package Package { get; set; } = null!;

    public virtual UserDatum UserNameNavigation { get; set; } = null!;
}
