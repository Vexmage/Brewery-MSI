using System;
using System.Collections.Generic;

namespace Brewery_MSI.Models.Models;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public string Name { get; set; } = null!;

    public int? Version { get; set; }

    public int IngredientTypeId { get; set; }

    public double OnHandQuantity { get; set; }

    public int UnitTypeId { get; set; }

    public decimal UnitCost { get; set; }

    public double ReorderPoint { get; set; }

    public string? Notes { get; set; }

    public virtual Adjunct? Adjunct { get; set; }

    public virtual Fermentable? Fermentable { get; set; }

    public virtual Hop? Hop { get; set; }

    public virtual ICollection<IngredientInventoryAddition> IngredientInventoryAdditions { get; } = new List<IngredientInventoryAddition>();

    public virtual ICollection<IngredientInventorySubtraction> IngredientInventorySubtractions { get; } = new List<IngredientInventorySubtraction>();

    public virtual IngredientType IngredientType { get; set; } = null!;

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; } = new List<RecipeIngredient>();

    public virtual UnitType UnitType { get; set; } = null!;

    public virtual Yeast? Yeast { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; } = new List<Ingredient>();

    public virtual ICollection<Style> Styles { get; } = new List<Style>();

    public virtual ICollection<Ingredient> SubstituteIngredients { get; } = new List<Ingredient>();
}
