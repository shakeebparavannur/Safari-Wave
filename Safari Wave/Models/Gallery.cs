using System;
using System.Collections.Generic;

namespace Safari_Wave.Models;

public partial class Gallery
{
    public int ImageId { get; set; }

    public int PackageId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual Package Package { get; set; } = null!;
}
