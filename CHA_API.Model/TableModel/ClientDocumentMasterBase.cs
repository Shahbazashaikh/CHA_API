using Dapper.Contrib.Extensions;

namespace CHA_API.Model.TableModel
{
    [Table("ClientDocumentMaster")]
    public class ClientDocumentMasterBase
    {
        public long ClientId { get; set; }

        public string DocumentName { get; set; }

        public string DocumentPath { get; set; }

        public int DocumentType { get; set; }
    }
}
