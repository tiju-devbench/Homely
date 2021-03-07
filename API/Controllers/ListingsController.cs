using System;
using System.Threading.Tasks;
using Homely.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListingsController : ControllerBase
    {
        private readonly ILogger<ListingsController> _logger;
        private readonly IListingService _listingService;

        public ListingsController(ILogger<ListingsController> logger, IListingService listingService)
        {
            _logger = logger;
            _listingService = listingService;
        }

        [HttpGet]
        [Route("")]
        [Route("listings")]
        public async Task<IActionResult> GetListings(string suburb,string categoryType,string statusType,int skip = 0 ,int take =10)
        {
            try
            {
                var listing = await _listingService.GetPagedListing(suburb, categoryType, statusType, skip, take);
                _logger.LogInformation("Listing fetched successfully");
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
