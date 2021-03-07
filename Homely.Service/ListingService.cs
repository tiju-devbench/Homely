using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Homely.Core.Repository;
using Homely.Services.Interfaces;
using Homely.Services.Models;

namespace Homely.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepo;

        public ListingService(IListingRepository listingRepository)
        {
            _listingRepo = listingRepository ?? throw new ArgumentNullException(nameof(listingRepository));
        }
        public async Task<IEnumerable<ListingModel>> GetPagedListing()
        {
            var listing = await _listingRepo.GetPagedListingAsync();
            var lm = new ListingModel();
            var listingModel = new List<ListingModel>();
            listingModel.Add(lm);
            return listingModel;
           
        }
    }
}
