using Microsoft.AspNetCore.Http;
using HolmesServices.Models.DTOs;
using static HolmesServices.Models.RouteDictionaries.DeckRouteDictionary;
using HolmesServices.Models.ExtensionMethods;

namespace HolmesServices.Models.Grids
{
    public class DeckingGridBuilder : GridBuilder
    {
        // constructor get current route data from session
        public DeckingGridBuilder(ISession sesh) : base(sesh) { }
        //constructor stores filetering route segments and
        // paging and sortin route segments stored by the base constructor
        public DeckingGridBuilder(ISession sesh, DeckingGridDTO values,
            string defaultSortField) : base(sesh, values, defaultSortField)
        {
            // store filter route segments - add filter prefixes if this is initial load
            // of page with defaul values rather than route values (route values have prefix)
            bool isInitial = values.Type.IndexOf(FilterPrefix.Type) == -1;
            routes.TypeFilter = (isInitial) ? FilterPrefix.Type + values.Type : values.Type;
            routes.PriceFilter = (isInitial) ? FilterPrefix.Price + values.Price : values.Price;

            SaveRouteSegments();
        }
        // load new filter route segments contained in a string array - add filter prefix
        // to each one 
        public void LoadFilterSegments(string[] filter)
        {
            routes.TypeFilter = FilterPrefix.Type + filter[0];
            routes.PriceFilter = FilterPrefix.Price + filter[1];
        }
        public void ClearFilterSegments() => routes.ClearFilters();

        // filter flags
        string def = DeckingGridDTO.DefaultFilter; // get default filter value from static DTO property
        public bool IsFilterByType => routes.TypeFilter != def;
        public bool IsFilteredByPrice => routes.PriceFilter != def;
        // sort flags
        public bool IsSortedByByType => routes.SortField.EqualsNoCase(nameof(Decking.Deck_Type));
        public bool IsSortedByPrice => routes.SortField.EqualsNoCase(nameof(Decking.Price_Per_SqFt));
    }
}
