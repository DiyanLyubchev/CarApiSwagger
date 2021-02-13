using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarApiSwagger.Model
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class CarModel
    {
        [JsonProperty("Brand")]
        public string Brand { get; set; }

        [JsonProperty("Models")]
        public List<string> Models { get; set; } = new List<string>();
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
