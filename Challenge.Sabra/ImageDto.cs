using Newtonsoft.Json;

namespace Challenge.Sabra
{
    public class ImageDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("src")]
        public string Src { get; set; }
    }
}
