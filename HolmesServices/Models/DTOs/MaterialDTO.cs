using HolmesServices.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.Models.DTOs
{
    public class MaterialDTO
    {
        public int Id { get; set; }
        public string Product_Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string Material { get; set; }

        public void Load(Material material)
        {
            Id = Id;
            Product_Code = material.Product_Code;
            Name = material.Name;
            Type = material.Type;
            Price = material.Price;
            Material = material.MaterialType;
        }

    }
}
