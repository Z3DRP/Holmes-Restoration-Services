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
                Where = t => t.Deck_Type == builder.CurrentRoute.TypeFilter;
            if (builder.IsFilteredByPrice)
                foreach (KeyValuePair<string, double> prices in PriceFilters.Prices)
                    if (builder.CurrentRoute.PriceFilter == prices.Key)
                        Where = p => p.Price_Per_SqFt < prices.Value;
            // sort
            if (builder.IsSortedByByType)
                OrderBy = t => t.Deck_Type;
            else if (builder.IsSortedByPrice)
                OrderBy = p => p.Price_Per_SqFt;
            else
                OrderBy = i => i.Id;
        }
    }
}
