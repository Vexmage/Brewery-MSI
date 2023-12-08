using Microsoft.EntityFrameworkCore;
using Brewery_MSI.Models;
using System.Linq;
using Brewery_MSI.Models.Models;

namespace Brewery_MSI.Models
{
    public class BitsContext : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }

        public BitsContext(DbContextOptions<BitsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the primary key for Supplier to match the database column name
            modelBuilder.Entity<Supplier>()
                .ToTable("supplier")
                .HasKey(s => s.SupplierId);
            modelBuilder.Entity<Supplier>()
                .Property(s => s.SupplierId)
                .HasColumnName("supplier_id");

            // Configure the composite key for SupplierAddress
            modelBuilder.Entity<SupplierAddress>()
                .HasKey(sa => new { sa.SupplierId, sa.AddressId });
            modelBuilder.Entity<SupplierAddress>()
                .Property(sa => sa.SupplierId)
                .HasColumnName("supplier_id");

            // Define the relationship between Supplier and SupplierAddress
            modelBuilder.Entity<SupplierAddress>()
                .HasOne(sa => sa.Supplier)
                .WithMany(s => s.SupplierAddresses)
                .HasForeignKey(sa => sa.SupplierId);

            // Assuming Address has a primary key named AddressId
            modelBuilder.Entity<SupplierAddress>()
                .HasOne(sa => sa.Address)
                .WithMany() // If Address has a collection of SupplierAddresses, add it here
                .HasForeignKey(sa => sa.AddressId);

            modelBuilder.Entity<Ingredient>().HasKey(i => i.IngredientId);
            modelBuilder.Entity<Adjunct>().HasKey(a => new { a.IngredientId, a.AdjunctTypeId });
            modelBuilder.Entity<BatchContainer>().HasKey(bc => new { bc.BatchId, bc.BrewContainerId });
            modelBuilder.Entity<Barrel>().HasKey(b => b.BrewContainerId);
            modelBuilder.Entity<Fermentable>().HasKey(f => f.IngredientId);
            modelBuilder.Entity<IngredientInventoryAddition>().HasKey(iia => iia.IngredientInventoryAdditionId);
            modelBuilder.Entity<IngredientInventorySubtraction>().HasKey(iis => iis.IngredientInventorySubtractionId);
            modelBuilder.Entity<IngredientType>().HasKey(it => it.IngredientTypeId);
            modelBuilder.Entity<FermentableType>().HasKey(ft => ft.FermentableTypeId);
            modelBuilder.Entity<Hop>().HasKey(h => h.IngredientId);
            modelBuilder.Entity<Product>().HasKey(p => new { p.BatchId, p.ProductContainerSizeId });
            modelBuilder.Entity<ProductContainerInventory>().HasKey(pci => pci.ContainerSizeId);
            modelBuilder.Entity<ProductContainerSize>().HasKey(pcs => pcs.ContainerSizeId);
            modelBuilder.Entity<Ingredient>().HasOne(i => i.Fermentable).WithOne(f => f.Ingredient).HasForeignKey<Fermentable>(f => f.IngredientId);
            modelBuilder.Entity<Ingredient>().HasOne(i => i.Hop).WithOne(h => h.Ingredient).HasForeignKey<Hop>(h => h.IngredientId);
            modelBuilder.Entity<ProductContainerSize>().HasOne(pcs => pcs.ProductContainerInventory).WithOne(pci => pci.ContainerSize).HasForeignKey<ProductContainerInventory>(pci => pci.ContainerSizeId);
            // Configure the primary key for Yeast
            modelBuilder.Entity<Yeast>()
                .HasKey(y => y.IngredientId);

            // Configure the one-to-one relationship between Ingredient and Yeast
            modelBuilder.Entity<Ingredient>()
                .HasOne(i => i.Yeast)
                .WithOne(y => y.Ingredient)
                .HasForeignKey<Yeast>(y => y.IngredientId);

            // Configure the primary key for Mash
            modelBuilder.Entity<Mash>()
                .HasKey(m => m.MashId);

            // Assuming MashStep has a MashId foreign key and its own primary key, configure it accordingly
            modelBuilder.Entity<MashStep>()
                .HasKey(ms => ms.MashStepId); // Replace MashStepId with the actual primary key of MashStep

            modelBuilder.Entity<MashStep>()
                .HasOne(ms => ms.Mash)
                .WithMany(m => m.MashSteps)
                .HasForeignKey(ms => ms.MashId);

        }


    }
}
