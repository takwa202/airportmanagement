using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Am.Infrastructure.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => new
            {
                x.PassengerFk,x.FlightFk
            });
            builder.HasOne(t => t.passenger)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t=>t.PassengerFk);
            builder.HasOne(t => t.flight)
                .WithMany(f => f.Tickets)
                .HasForeignKey(t => t.FlightFk);
        }
    }
}
