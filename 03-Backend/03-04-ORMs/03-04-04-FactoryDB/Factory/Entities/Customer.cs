using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class Customer
    {
        public string GeoLocation { get; set; }
        public int Id { get; set; }
        public string Phone { get; set; }

        public ICollection<Order> Orders { get; set; }


    }
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //Table Level
            builder.ToTable("Customers", "Factory");

        }
    }
}
