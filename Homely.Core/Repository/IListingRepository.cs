using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Homely.Core.Entities;

namespace Homely.Core.Repository
{
    public interface IListingRepository 
    {
        public int CountTask { get; set; }
        Task<IEnumerable<Listing>> GetPagedListingAsync(string suburb, int categoryType, int statusType, int skip, int take);
    }
}
