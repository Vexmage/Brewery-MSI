using System;
using System.Collections.Generic;

namespace Brewery_MSI.Models.Models;

public partial class UnitType
{
    public int UnitTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; } = new List<Ingredient>();
}
