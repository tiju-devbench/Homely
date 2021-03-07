using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Homely.Services.Models;

namespace Homely.Services.Interfaces
{
    public interface IListingService
    {
        Task<ListingModel> GetPagedListing(string suburb, string categoryType, string statusType, int skip, int take);
    }
}
