using System;
using Dapper.Contrib.Extensions;

namespace CHA_API.Model.TableModel
{
    [Table("ClientDocumentMaster")]
    public class InsertClientDocumentMaster : ClientDocumentMasterBase
    {
        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
