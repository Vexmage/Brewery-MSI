using System;
using System.Collections.Generic;

namespace Brewery_MSI.Models.Models;

public partial class ContainerSize
{
    public int ContainerSizeId { get; set; }

    public string Name { get; set; } = null!;

    public double? MaxVolume { get; set; }

    public double? WorkingVolume { get; set; }

    public virtual ICollection<BrewContainer> BrewContainers { get; } = new List<BrewContainer>();
}
