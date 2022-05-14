using Microsoft.AspNetCore.Http;

namespace CHA_API.Model.RequestModel
{
    public class ClientDocumentMasterRequest
    {
        public long DocumentID { get; set; }

        public long ClientId { get; set; }

        public string ClientName { get; set; }

        public string DocumentName { get; set; }

        public string DocumentPath { get; set; }

        public int DocumentType { get; set; }

        public IFormFile File { get; set; }

        public int UserId { get; set; }
    }
}
