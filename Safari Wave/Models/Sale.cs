using System;
using System.Collections.Generic;

namespace Safari_Wave.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public int PackageId { get; set; }

    public string UserName { get; set; } = null!;

    public DateTime Date { get; set; }

    public decimal Amount { get; set; }

    public virtual Package Package { get; set; } = null!;

    public virtual UserDatum UserNameNavigation { get; set; } = null!;
}
