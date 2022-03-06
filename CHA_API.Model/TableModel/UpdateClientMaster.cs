using System;
using Dapper.Contrib.Extensions;

namespace CHA_API.Model.TableModel
{
    [Table("ClientMaster")]
    public class UpdateClientMaster : ClientMasterBase
    {
        public long ClientId { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
