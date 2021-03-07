using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homely.Services.Enums
{
    public enum StatusTypes
    {
        Current = 1,
        Withdrawn = 2,
        Sold = 3,
        Leased = 4,
        [Display(Name = "Off Market")]
        OffMarket = 5,
        Deleted = 6
    }
}
