using InterviewProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewProject.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<Border> Borders { get; set; }
    }
}
