using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolmesServices.Models;
using HolmesServices.Models.DomainModels;
using HolmesServices.Models.RouteDictionaries;

namespace HolmesServices.ViewModels
{
    public class RailListViewModel
    {
        public IEnumerable<Railing> Rails { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        // data for filter drop-downs
        public IEnumerable<Rail_Type> Types { get; set; }
        public IEnumerable<Price_Groups> Groups { get; set; }
        public int TotalPages { get; set; }
        public Dictionary<string, string> Prices =>
            new Dictionary<string, string>
            {
                {"under5",  "Under $5"},
                {"under10", "Under $10"},
                {"under15", "Under $15" },
                {"under20", "Under $20"},
            };
        // pagesizes will be changed to do default size of 5 or show all
        public int[] PageSizes => new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }
}
