using DutiesApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutiesApp.Data
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Database=DutiesDB;persist security info=True; Integrated Security=SSPI;");
            }
        }

        public DbSet<Duty> Duties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Duty>(duty =>
            {
                duty.HasKey(x=>x.Id);

                duty.Property(x=>x.Title)
                .IsRequired()
                .HasMaxLength(50);
            });
        }

    }
}
