using HolmesServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.ViewModels
{
    public class MyDesignViewModel
    {
        public int CustomerId { get; set; }
        public int DesignId { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Design> Designs { get; set; }
    }
}
