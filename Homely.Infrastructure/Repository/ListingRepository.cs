using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Homely.Core.Entities;
using Homely.Core.Repository;
using Homely.Infrastructure.Data;


using Microsoft.EntityFrameworkCore;


namespace Homely.Infrastructure.Repository
{
    public class ListingRepository : IListingRepository
    {
        private readonly HomelyContext _dbcontext;

        public ListingRepository( HomelyContext dbContext) 
        {
            _dbcontext = dbContext;
        }
        public async Task<IEnumerable<Listing>> GetPagedListingAsync()
        {
            return await _dbcontext.Listings.ToListAsync();
            ;
            
        }
    }
}
