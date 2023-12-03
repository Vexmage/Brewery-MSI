using System;
using System.Collections.Generic;

namespace Brewery_MSI.Models.Models;

public partial class ContainerType
{
    public int ContainerTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BrewContainer> BrewContainers { get; } = new List<BrewContainer>();
}
