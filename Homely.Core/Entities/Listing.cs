using System;
using System.Collections.Generic;
using System.Text;

namespace Homely.Core.Entities
{
    public class Listing
    {
        public int ListingId { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public int Postcode { get; set; }
        public int CategoryType { get; set; }

        public int StatusType { get; set; }
        public string DisplayPrice { get; set; }

        public string Title { get; set; }

    }
}
