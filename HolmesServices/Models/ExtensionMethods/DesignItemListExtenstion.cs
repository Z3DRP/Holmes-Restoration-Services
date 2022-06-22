using HolmesServices.Models.DomainModels;
using HolmesServices.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.Models.ExtensionMethods
{
    public static class DesignItemListExtenstion
    {
        public static List<DesignItemDTO> ToDTO(this List<DesignItem> list) =>
            list.Select(d => new DesignItemDTO
            {
                DesignID = d.Design.DesignId,
                DeckId = d.Design.DeckId,
                RailId = d.Design.RailId,
                Estimate = d.Design.Estimate
            }).ToList();
    }
}
