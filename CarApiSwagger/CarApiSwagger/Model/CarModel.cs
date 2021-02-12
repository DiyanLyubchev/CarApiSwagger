using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarApiSwagger.Model
{
    public class CarModel
    {
        [JsonProperty("Brand")]
        public string Brand { get; set; }

        [JsonProperty("Models")]
        public List<string> Models { get; set; }
    }
}
