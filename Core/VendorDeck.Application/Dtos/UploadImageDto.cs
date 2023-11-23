namespace VendorDeck.Application.Dtos
{
    public class UploadImageDto
    {
        public bool IsSuccess { get; set; }
        public Uri Url { get; set; }
        public string Error { get; set; }
    }
}
