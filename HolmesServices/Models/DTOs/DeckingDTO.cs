using Newtonsoft.Json;

namespace HolmesServices.Models.DTOs
{
    public class DeckingDTO
    {
        public int DeckId { get; set; }
        public string Product_Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }

        public void Load(Decking deck)
        {
            DeckId = deck.Id;
            Product_Code = deck.Product_Code;
            Name = deck.Name;
            Type = deck.Type.Type;
            Price = deck.Price_Per_SqFt;
        }

    }
}
