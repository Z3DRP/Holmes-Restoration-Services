using HolmesServices.Models.DomainModels;
using HolmesServices.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.Models.ExtensionMethods
{
    public static class RailItemListExtension
    {
        public static List<RailItemDTO> ToDTO(this List<RailItem> list) =>
            list.Select(r => new RailItemDTO
            {
                RailId = r.Rail.RailId,
                Price = r.Rail.Price
            }).ToList();
    }
}
