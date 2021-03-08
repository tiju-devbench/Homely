using System;
using System.Collections.Generic;
using System.Text;
using Homely.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homely.Infrastructure.Data
{
    public class HomelyContext: DbContext
    {
        public HomelyContext(DbContextOptions<HomelyContext> options):base(options)
        {
        }

        public DbSet<Listing> Listings { get; set; }
    }
}
