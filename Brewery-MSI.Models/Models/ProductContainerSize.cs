using System;
using System.Collections.Generic;

namespace Brewery_MSI.Models.Models;

public partial class ProductContainerSize
{
    public int ContainerSizeId { get; set; }

    public string Name { get; set; } = null!;

    public double Volume { get; set; }

    public int ItemQuantity { get; set; }

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; } = new List<InventoryTransaction>();

    public virtual ProductContainerInventory? ProductContainerInventory { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
