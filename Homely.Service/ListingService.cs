using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Homely.Core.Repository;
using Homely.Services.Interfaces;
using Homely.Services.Models;
using Homely.Services.Enums;
using Homely.Services.Mapper;

namespace Homely.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepo;

        public ListingService(IListingRepository listingRepository)
        {
            _listingRepo = listingRepository ?? throw new ArgumentNullException(nameof(listingRepository));
        }
        public async Task<ListingModel> GetPagedListing(string suburb, string categoryType, string statusType, int skip, int take)
        {
            CategoryTypes category;
            StatusTypes status;
            Enum.TryParse<CategoryTypes>(categoryType, out category);
            Enum.TryParse<StatusTypes>(statusType, out status);

            if (!string.IsNullOrEmpty(categoryType) && category <= 0)
            {
                throw new ArgumentException("Invalid input Parameter: CategoryType");
            }
            if (!string.IsNullOrEmpty(statusType) &&  status <=0)
            {
                throw new ArgumentException("Invalid input Parameter: StatusType");
            }
           
            var listing = await _listingRepo.GetPagedListingAsync(suburb,(int)category,(int)status,skip,take);
            var listingModel = ObjectMapper.Mapper.Map<ListingModel>(listing);
            listingModel.total = _listingRepo.CountTask;
            return listingModel;
        }
    }
}
