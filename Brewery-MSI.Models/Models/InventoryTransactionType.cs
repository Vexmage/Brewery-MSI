﻿using System;
using System.Collections.Generic;

namespace Brewery_MSI.Models.Models;

public partial class InventoryTransactionType
{
    public int InventoryTransactionTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; } = new List<InventoryTransaction>();
}
