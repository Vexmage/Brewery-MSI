using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brewery_MSI.Models.Models;

public partial class Supplier
{
    [Key]
    [Column("supplier_id")]
    public int SupplierId { get; set; }
    [Column("name")]
    public string Name { get; set; } = null!;
    [Column("phone")]
    public string? Phone { get; set; }
    [Column("email")]
    public string? Email { get; set; }
    [Column("website")]
    public string? Website { get; set; }
    [Column("contact_first_name")]
    public string? ContactFirstName { get; set; }
    [Column("contact_last_name")]
    public string? ContactLastName { get; set; }
    [Column("contact_phone")]
    public string? ContactPhone { get; set; }
    [Column("contact_email")]
    public string? ContactEmail { get; set; }
    [Column("note")]
    public string? Note { get; set; }

    public virtual ICollection<IngredientInventoryAddition> IngredientInventoryAdditions { get; } = new List<IngredientInventoryAddition>();

    public virtual ICollection<SupplierAddress> SupplierAddresses { get; } = new List<SupplierAddress>();
}
