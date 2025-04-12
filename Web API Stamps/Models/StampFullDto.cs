using System.Text.Json.Serialization;

namespace API_upload.Models
{
    public class StampFullDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("fileName")]
        public string? FileName { get; set; }

        [JsonPropertyName("contentType")]
        public string? ContentType { get; set; }

        [JsonPropertyName("filePath")]
        public string? FilePath { get; set; }  // Optional: if you add a FilePath

        [JsonPropertyName("uploadedDateTime")]
        public DateTime? UploadedAt { get; set; }

        [JsonPropertyName("stampImageBase64Data")]
        public string? StampImageBase64Data { get; set; }

        [JsonPropertyName("stampName")]
        public string? StampName { get; set; }

        [JsonPropertyName("yearOfIssue")]
        public int? YearOfIssue { get; set; }
       
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("catalogNumber")]
        public string? CatalogNumber { get; set; }

        [JsonPropertyName("condition")]
        public string? Condition { get; set; }

        [JsonPropertyName("watermark")]
        public string? Watermark { get; set; }

        [JsonPropertyName("size")]
        public string? Size { get; set; }

        [JsonPropertyName("faceValue")]
        public string? FaceValue { get; set; }

        [JsonPropertyName("color")]
        public string? Color { get; set; }

        [JsonPropertyName("printMethod")]
        public string? PrintMethod { get; set; }

        [JsonPropertyName("rarity")]
        public string? Rarity { get; set; }

        [JsonPropertyName("specialFeatures")]
        public string? SpecialFeatures { get; set; }

        [JsonPropertyName("stampSeries")]
        public string? StampSeries { get; set; }

        [JsonPropertyName("historicalSignificance")]
        public string? HistoricalSignificance { get; set; }

        [JsonPropertyName("provenance")]
        public string? Provenance { get; set; }

        [JsonPropertyName("additionalNotes")]
        public string? AdditionalNotes { get; set; }
    }
}
