using System;
using Dapper.Contrib.Extensions;

namespace CHA_API.Model.TableModel
{
    [Table("ClientAddressMaster")]
    public class InsertClientAddressMaster : ClientAddressMasterBase
    {
        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
