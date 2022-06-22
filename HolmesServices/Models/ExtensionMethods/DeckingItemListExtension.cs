using HolmesServices.Models.DomainModels;
using HolmesServices.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.Models.ExtensionMethods
{
    public static class DeckingItemListExtension
    {
        public static List<DeckItemDTO> ToDTO(this List<DeckItem> list) =>
            list.Select(d => new DeckItemDTO
            {
                DeckId = d.Deck.DeckId,
                Price = d.Deck.Price
            }).ToList();
    }
}
