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
    public class PlaneConfiguration : IEntityTypeConfiguration<plane>
    {
        public void Configure(EntityTypeBuilder<plane> builder)
        {
        builder.HasKey(x => x.planeID);
        builder.ToTable("MyPlanes");
            builder.Property(x => x.Capacity).HasColumnName("PlaneCapacity");

        }
    }
}
