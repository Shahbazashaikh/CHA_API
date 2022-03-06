using System;
using Dapper.Contrib.Extensions;

namespace CHA_API.Model.TableModel
{
    [Table("ClientAddressMaster")]
    public class UpdateClientAddressMaster : ClientAddressMasterBase
    {
        public long AddressID { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
