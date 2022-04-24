using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewProject.Application .Interfaces;
using InterviewProject.Domain.Entities;

namespace InterviewProject.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<Border> Borders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
                .HasKey(country => country.Code);

            modelBuilder.Entity<Border>()
                .HasKey(border => new { border.CountryId, border.NeighbourId });


            ApplicationDbContextSeed.SeedData(modelBuilder);
        }
    }
}
