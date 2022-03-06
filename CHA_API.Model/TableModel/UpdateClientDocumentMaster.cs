using System;
using Dapper.Contrib.Extensions;

namespace CHA_API.Model.TableModel
{
    [Table("ClientDocumentMaster")]
    public class UpdateClientDocumentMaster : ClientDocumentMasterBase
    {
        public long DocumentID { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
