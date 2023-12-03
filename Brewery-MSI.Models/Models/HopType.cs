using System;
using System.Collections.Generic;

namespace Brewery_MSI.Models.Models;

public partial class HopType
{
    public int HopTypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Hop> Hops { get; } = new List<Hop>();
}
