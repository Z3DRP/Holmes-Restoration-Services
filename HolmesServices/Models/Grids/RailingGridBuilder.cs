using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using HolmesServices.Models.DTOs;
using static HolmesServices.Models.RouteDictionaries.RailRouteDictionary;
using HolmesServices.Models.ExtensionMethods;

namespace HolmesServices.Models.Grids
{
    public class RailingGridBuilder : GridBuilder
    {
        // this gets current route data from session
        public RailingGridBuilder(ISession sesh) : base(sesh) { }

        // this stores filtering route segments and the
        // paging and sorting route segments stored by the base constructor
        public RailingGridBuilder(ISession sesh, RailingGridDTO values,
            string defaultSortField) : base(sesh, values, defaultSortField)
        {
            // store filter route segments - add fileter prefixed if this is initial load
            // of page with default values ratheer than route values (route values have prefix)
            bool isInitial = values.Type.IndexOf(FilterPrefix.Type) == 1;
            routes.TypeFilter = (isInitial) ? FilterPrefix.Type + values.Type : values.Type;
            routes.PriceFilter = (isInitial) ? FilterPrefix.Price + values.Price : values.Price;

            SaveRouteSegments();
        }
        public void LoadFilterSegments(string[] filter)
        {
            routes.TypeFilter = FilterPrefix.Type + filter[0];
            routes.PriceFilter = FilterPrefix.Price + filter[1];
        }
        public void ClearFilterSegments() => routes.ClearFilters();

        // filter flags
        string def = RailingGridDTO.DefaultFilter;
        public bool IsFilteredByType => routes.TypeFilter != default;
        public bool IsFilteredByPrice => routes.PriceFilter != default;
        // sort flags
        public bool IsSortedByType => routes.SortField.EqualsNoCase(nameof(Railing.Rail_Type));
        public bool IsSortedByPrice => routes.SortField.EqualsNoCase(nameof(Railing.Price_Per_SqFt));

    }
}
