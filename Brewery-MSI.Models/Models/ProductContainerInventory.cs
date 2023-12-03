using System;
using System.Collections.Generic;

namespace Brewery_MSI.Models.Models;

public partial class ProductContainerInventory
{
    public int ContainerSizeId { get; set; }

    public int QuantityDirty { get; set; }

    public int QuantityClean { get; set; }

    public virtual ProductContainerSize ContainerSize { get; set; } = null!;
}
