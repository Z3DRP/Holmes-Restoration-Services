using HolmesServices.Models.Grids;
using HolmesServices.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace HolmesServices.Models
{
    public class DeckingQueryOptions : QueryOptions<Decking>
    {
        public void SortFilter(DeckingGridBuilder builder)
        {
            // filter
            if (builder.IsFilterByType)
                Where = t => t.Type.Type == builder.CurrentRoute.DeckTypeFilter;
            if (builder.IsFilteredByPrice)
                foreach (KeyValuePair<string, double> prices in PriceFilters.Prices)
                    if (builder.CurrentRoute.DeckPriceFilter == prices.Key)
                        Where = p => p.Price_Per_SqFt < prices.Value;
            // sort
            if (builder.IsSortedByByType)
                OrderBy = t => t.Type;
            else if (builder.IsSortedByGroup)
                OrderBy = g => g.Group;
            else if (builder.IsSortedByPrice)
                OrderBy = p => p.Price_Per_SqFt;
            else
                OrderBy = i => i.Id;
        }
    }
}
