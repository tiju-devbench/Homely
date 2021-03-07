using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Homely.Core.Entities;

namespace Homely.Core.Repository
{
    public interface IListingRepository 
    {
        Task<IEnumerable<Listing>> GetPagedListingAsync();
    }
}
