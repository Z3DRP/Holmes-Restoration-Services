using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.Models.DTOs
{
    public class DesignItemDTO
    {
        public int MaterialId { get; set; }
        public string MaterialType { get; set; }
        public double Price { get; set; }
    }
}
