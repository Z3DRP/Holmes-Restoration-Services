using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.Models
{
    public class RailType
    {
        public enum Rail_Type { Aluminum, Wood, Traditional}
        public int Id { get; set; }
        public Rail_Type Type { get; set; }
    }
}
