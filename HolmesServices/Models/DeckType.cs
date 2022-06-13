using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.Models
{
    public enum Deck_Type { Hardwood, Compostie, Wood, Treated };
    public class DeckType
    {
        public int Id { get; set; }
        public Deck_Type Type {get;set;}
    }
}
