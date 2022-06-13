using Newtonsoft.Json;

namespace HolmesServices.Models.DTOs
{
    public class RailingGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";

        public string Type { get; set; } = DefaultFilter;
        public string Price { get; set; } = DefaultFilter;
    }
}
