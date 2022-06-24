using HolmesServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.ViewModels
{
    public class CustomerDesignViewModel : Customer
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public DateTime StartDate { get; set; }
    }
}
