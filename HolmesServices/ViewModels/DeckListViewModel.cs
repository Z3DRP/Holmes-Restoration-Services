using System;
using System.Collections.Generic;
using HolmesServices.Models;
using HolmesServices.Models.RouteDictionaries;
using HolmesServices.ViewModels;

namespace HolmesServices.ViewModels
{
    public class DeckListViewModel
    {
        public IEnumerable<Decking> Decks { get; set; }
        public DeckRouteDictionary CurrentRoute { get; set; }
        public IEnumerable<DeckType> Type { get; set; }
        // might not need total pages
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
