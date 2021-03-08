using System;
using System.Collections.Generic;
using System.Text;

namespace Homely.Services.Models
{
    public class ListingModel
    {
        public List<ListingDetails> items { get; set; }
        public int total { get; set; }
    }

    public class ListingDetails
    {
        public int listingId { get; set; }
        public string address { get; set; }
        public string categoryType { get; set; }
        public string statusType { get; set; }

        public string displayPrice { get; set; }
        public string? ShortPrice { get; set; }
        public string title { get; set; }


    }
}
