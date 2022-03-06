using System;
using Dapper.Contrib.Extensions;

namespace CHA_API.Model.TableModel
{
    [Table("ClientMaster")]
    public class InsertClientMaster : ClientMasterBase
    {
        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
