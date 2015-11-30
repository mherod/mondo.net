namespace Mondo.Client.Messages
{
    public sealed class UploadAttachmentResponse
    {
        /// <summary>
        /// The URL of the file once it has been uploaded
        /// </summary>
        public string FileUrl { get; set; }

        /// <summary>
        /// The URL to POST the file to when uploading
        /// </summary>
        public string UploadUrl { get; set; }
    }
}