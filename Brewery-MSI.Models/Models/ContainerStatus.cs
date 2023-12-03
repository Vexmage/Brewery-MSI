using System;
using System.Collections.Generic;

namespace Brewery_MSI.Models.Models;

public partial class ContainerStatus
{
    public int ContainerStatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BrewContainer> BrewContainers { get; } = new List<BrewContainer>();
}
