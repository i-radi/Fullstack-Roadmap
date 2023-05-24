using System;
using System.Linq;
using Factory.Entities;
using Factory.Entities.Joins;
using Microsoft.EntityFrameworkCore;

namespace Factory
{
    public class FactoryDbContext : DbContext
    {
        public FactoryDbContext(DbContextOptions<FactoryDbContext> options)
            : base(options)
        {
        }

        #region DBSets
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<MachinePart> MachineParts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }

        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<Sensor> Sensor { get; set; }
        public DbSet<SensorDataLog> SensorDataLogs { get; set; }
        public DbSet<Shift> Shifts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Apply All Configuration classes written in Fluent API after Every Entity
            var typesToRegister = GetType().Assembly
                .GetTypes()
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType &&
                              i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
            foreach (Type type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                if (configurationInstance != null)
                    modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}