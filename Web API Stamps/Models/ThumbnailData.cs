namespace API_upload.Models
{
    public class ThumbnailData
    {
        public int Id { get; set; }
        public byte[] FileData { get; set; }  // Binary data column (VARBINARY)
        public int StampId { get; set; }
        //public Stamp StampImage { get; set; }
    }
}
