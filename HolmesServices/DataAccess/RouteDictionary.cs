using System;
using System.Collections.Generic;
using System.Linq;
using HolmesServices.Models.DTOs;
using HolmesServices.Models.ExtensionMethods;

namespace HolmesServices.DataAccess
{
    public static class FilterPrefix
    {
        public const string Type = "type-";
        public const string Price = "price-";
    }
    public class RouteDictionary : Dictionary<string,string>
    {
        public int PageNumber
        {
            get => Get(nameof(GridDTO.PageSize)).ToInt();
            set => this[nameof(GridDTO.PageSize)] = value.ToString();
        }

        public string SortField
        {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }

        public string SortDirection
        {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }

        public void SetSortAndDirection(string fieldName, RouteDictionary current)
        {
            // set sort direction base on comparison of new and current sort field
            // if sort field is same as current, toggle between ascending and desc
            // if its different should always be asc
            if (current.SortField.EqualsNoCase(fieldName) && current.SortDirection == "asc")
                this[nameof(GridDTO.SortDirection)] = "desc";
            else
                this[nameof(GridDTO.SortDirection)] = "asc";
        }

        public string TypeFilter
        {
            get => Get(nameof(MaterialDTO.Type))?.Replace(FilterPrefix.Type, "");
            set => this[nameof(MaterialDTO.Type)] = value;
        }
        public string PriceFilter
        {
            get => Get(nameof(MaterialDTO.Price))?.Replace(FilterPrefix.Price, "");
            set => this[nameof(MaterialDTO.Price)] = value;
        }
        // maybe add comapny filter if company column added to table
        public void ClearFilters() =>
            TypeFilter = PriceFilter = MaterialDTO.DefaultFilter;

        private string Get(string key) => Keys.Contains(key) ? this[key] : null;
        public RouteDictionary Clone()
        {
            var clone = new RouteDictionary();
            foreach (var key in Keys)
            {
                clone.Add(key, this[key]);
            }
            return clone;
        }
    }
}
