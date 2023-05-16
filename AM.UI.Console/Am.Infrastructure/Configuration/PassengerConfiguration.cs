using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Am.Infrastructure.Configuration
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>

    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.FullName, f =>
            {
                f.Property(n => n.FirstName).HasColumnName("PassFirstName")
                .HasMaxLength(30);
                f.Property(n => n.LastName).HasColumnName("PassLastName")
                .IsRequired();
            });
        //builder.HasDiscriminator<string>("IsTraveller")
        //        .HasValue<Staff>("2")
        //        .HasValue<Traveller>("1")
        //        .HasValue<Passenger>("0");
        }
    }
}
