using System;
using System.Collections.Generic;

namespace Brewery_MSI.Models.Models;

public partial class AdjunctType
{
    public int AdjunctTypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Adjunct> Adjuncts { get; } = new List<Adjunct>();
}
