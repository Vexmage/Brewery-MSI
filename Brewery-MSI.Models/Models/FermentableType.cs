using System;
using System.Collections.Generic;

namespace Brewery_MSI.Models.Models;

public partial class FermentableType
{
    public int FermentableTypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Fermentable> Fermentables { get; } = new List<Fermentable>();
}
