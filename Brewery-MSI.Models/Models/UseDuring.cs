using System;
using System.Collections.Generic;

namespace Brewery_MSI.Models.Models;

public partial class UseDuring
{
    public int UseDuringId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Adjunct> Adjuncts { get; } = new List<Adjunct>();

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; } = new List<RecipeIngredient>();
}
