using System.Text.Json.Serialization;
using Web_API_Stamps.Models;

namespace API_upload.Models
{
    public class StampLightDto
    {
        public int Id { get; set; }

        [JsonPropertyName("thumbnailDataBase64")]
        public string? ThumbnailDataBase64 { get; set; }

        [JsonPropertyName("yearOfIssue")]
        public int? YearOfIssue { get; set; }

        [JsonPropertyName("stampName")]
        public string StampName { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("catalogNumber")]
        public string CatalogNumber { get; set; }

        [JsonPropertyName("stampCategory")]
        public StampCategory StampCategory { get; set; }

    }
}
