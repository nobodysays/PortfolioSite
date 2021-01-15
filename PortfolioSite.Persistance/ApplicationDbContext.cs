using Microsoft.EntityFrameworkCore;
using PortfolioSite.App;
using PortfolioSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioSite.Persistance.Postgres
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Record> Records { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
