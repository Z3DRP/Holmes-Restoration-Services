using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolmesServices.Models;
using HolmesServices.Models.RouteDictionaries;

namespace HolmesServices.ViewModels
{
    public class DesignListViewModel
    {
        public IEnumerable<Design> Designs { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
        // data for filter drop-downs 
        public Customer Customer { get; set; }

    }
}
