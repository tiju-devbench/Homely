using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Homely.Services.Models;

namespace Homely.Services.Interfaces
{
    public interface IListingService
    {
        Task<IEnumerable<ListingModel>> GetPagedListing();
    }
}
