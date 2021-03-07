using System;
using System.Collections.Generic;
using System.Linq;
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
        public int CountTask { get; set; }

        public async Task<IEnumerable<Listing>> GetPagedListingAsync(string suburb, int categoryType, int statusType, int skip, int take)
        {
            IQueryable<Listing> query = _dbcontext.Listings;
            if (!string.IsNullOrEmpty(suburb))
            {
                query = query.Where(x => x.Suburb == suburb);
            }
            if (categoryType> 0)
            {
                query = query.Where(x => x.CategoryType == categoryType);
            }
            if (statusType > 0)
            {
                query = query.Where(x => x.StatusType == statusType);
            }
            this.CountTask = await query.CountAsync();
            return await query
                .OrderBy(q=> q.ListingId)
                .Skip(skip).Take(take)                
                .AsNoTracking()?.ToListAsync();
            ;
            
        }

    }
}
