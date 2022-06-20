using Newtonsoft.Json;

namespace HolmesServices.Models.DTOs
{
    public class RailingDTO
    {
        public int RailId { get; set; }
        public string Product_Code { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public void Load(Railing rail)
        {
            RailId = rail.Id;
            Product_Code = rail.Product_Code;
            Price = rail.Price_Per_SqFt;
            Type = rail.Type.Type;
        }
    }
}
