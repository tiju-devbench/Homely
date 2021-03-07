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
        public async Task<IActionResult> GetListings()
        {
            var listing = await _listingService.GetPagedListing();

            return Ok(listing);
        }


    }
}
