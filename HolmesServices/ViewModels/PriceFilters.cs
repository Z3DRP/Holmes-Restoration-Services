using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.ViewModels
{
    public static class PriceFilters
    {
        public static readonly Dictionary<string, double> Prices = new Dictionary<string, double>
        {
            {"under5", 5 },
            {"under10", 10 },
            {"under15", 15 },
            {"under20", 20 },
        };
    }
}
