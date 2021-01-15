using Microsoft.EntityFrameworkCore;
using PortfolioSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioSite.App
{
    public interface IApplicationDbContext
    {
        DbSet<Record> Records { get; }
        void Save();
    }
}
