using HolmesServices.Models.Grids;
using HolmesServices.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace HolmesServices.Models
{
    public class RailingQueryOptions : QueryOptions<Railing>
    {
        public void SortFilter(RailingGridBuilder builder)
        {
            // filter
            if (builder.IsFilteredByType)
            {
                Where = t => t.Rail_Type == builder.CurrentRoute.TypeFilter;
            }
            if (builder.IsFilteredByPrice)
            {
                // loop thru each price in pricesFilter dictionary
                foreach (KeyValuePair<string, double> prices in PriceFilters.Prices)
                {
                    // if the current route equals the current key in interation filter records
                    // with the current iteration price
                    if (builder.CurrentRoute.PriceFilter == prices.Key)
                        Where = p => p.Price_Per_SqFt < prices.Value;
                }
            }
            // sort
            if (builder.IsSortedByType)
                OrderBy = t => t.Rail_Type;

            else if (builder.IsSortedByPrice)
                OrderBy = p => p.Price_Per_SqFt;
            else
                OrderBy = i => i.Id;
        }
    }
}
