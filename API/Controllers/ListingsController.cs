using System;
using System.Threading.Tasks;
using Homely.Services.Interfaces;
using Homely.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListingsController : ControllerBase
    {
        private readonly ILogger<ListingsController> _logger;
        private readonly IListingService _listingService;
        private readonly IMemoryCache _cache;

        public ListingsController(ILogger<ListingsController> logger, IListingService listingService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _listingService = listingService;
            _cache = memoryCache;
        }

        [HttpGet]
        [Route("")]
        [Route("listings")]
        public async Task<IActionResult> GetListings(string suburb,string categoryType,string statusType,int skip = 0 ,int take =10)
        {
            try
            {
                //ListingModel listing = new ListingModel();
                 bool isCached = _cache.TryGetValue("listings_" + suburb + "_" + categoryType + "_" + skip, out ListingModel listing);

                if (!isCached || listing.items.Count < take)
                {
                    listing = await _listingService.GetPagedListing(suburb, categoryType, statusType, skip, take);
                    _logger.LogInformation("Successfully fetched listings from DB");
                    _cache.Set("listings_" + suburb + "_" + categoryType + "_" + skip, listing);
                    return Ok(listing);
                }
                _logger.LogInformation("Successfully fetched listings from Cache");
                return Ok(listing);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return BadRequest();
        }


    }
}
