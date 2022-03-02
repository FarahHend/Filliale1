using FillialeDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FillialeData.Context
{
    public class FillialeContext : DbContext
    {
        public FillialeContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Filliale> Filliale { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //PrimaryKey
            modelBuilder.Entity<Filliale>().HasKey(a => a.FillialeId);

            //UniqueValues
            modelBuilder.Entity<Filliale>().HasIndex(a => a.FillialeId).IsUnique();
            modelBuilder.Entity<Filliale>().HasIndex(g => g.FillialeCode).IsUnique();

        }
    }
}
