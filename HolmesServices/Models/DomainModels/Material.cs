using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.Models.DomainModels
{
    public class Material
    {
        public int Id { get; set; }
        public string Product_Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string MaterialType { get; set; }
    }
}
