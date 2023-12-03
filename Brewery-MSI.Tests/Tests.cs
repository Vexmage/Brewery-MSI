using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Brewery_MSI.Models;
using Brewery_MSI.Models.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Brewery_MSI.Tests
{
    [TestFixture]
    public class SupplierTests
    {
        private BitsContext _context;

        [SetUp]
        public void Setup()
        {
            _context?.Dispose();  // Dispose the previous context if exists
            var options = new DbContextOptionsBuilder<BitsContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())  // Use a new database for each test
                .Options;
            _context = new BitsContext(options);


            // Seed the database with a bogus Supplier
            var supplier = new Supplier
            {
                SupplierId = 1,
                Name = "Test Supplier",
                Phone = "123-456-7890",
                Email = "supplier@example.com",
                Website = "http://www.testsupplier.com",
                ContactFirstName = "John",
                ContactLastName = "Doe",
                ContactPhone = "987-654-3210",
                ContactEmail = "johndoe@example.com",
                Note = "Primary supplier for hops"
            };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }
        [Test]
        public async Task GetAllSuppliers_ShouldReturnAllSuppliers()
        {
            var suppliers = await _context.Suppliers.ToListAsync();
            
            Assert.That(suppliers, Is.Not.Empty, "Suppliers list should not be empty.");

        }

        [Test]
        public async Task GetSupplierById_ShouldReturnSupplierDetails()
        {
            var supplierId = 1;
            var supplier = await _context.Suppliers.FindAsync(supplierId);

            // Debug output
            if (supplier == null)
                System.Diagnostics.Debug.WriteLine("Supplier not found with ID: " + supplierId);
            else
                System.Diagnostics.Debug.WriteLine("Found supplier: " + supplier.Name);

           
            Assert.That(supplier, Is.Not.Null);
        }
    }
}
