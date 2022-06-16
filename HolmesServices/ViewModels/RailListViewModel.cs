using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolmesServices.Models;
using HolmesServices.Models.RouteDictionaries;

namespace HolmesServices.ViewModels
{
    public class RailListViewModel
    {
        public IEnumerable<Railing> Rails { get; set; }
        public RailRouteDictionary CurrentRoute { get; set; }
        // data for filter drop-downs
        public IEnumerable<Rail_Type> Type { get; set; }
        public int TotalPages { get; set; }
        public Dictionary<string, string> Prices =>
            new Dictionary<string, string>
            {
                {"under5",  "Under $5"},
                {"under10", "Under $10"},
                {"under15", "Under $15" },
                {"under20", "Under $20"},
            };
    }
}
