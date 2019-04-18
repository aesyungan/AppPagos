using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCobros.Models
{
    public class PaymentDetailContext:DbContext
    {
        public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options):base(options)
        {
                    
        }
        public DbSet<User> users { get; set; }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentDetail>()
              .HasOne(p => p.Usuario)
            .WithMany(c => c.paymentDetails)
            .HasForeignKey(p => p.UsuarioId);
        }
    }
}
