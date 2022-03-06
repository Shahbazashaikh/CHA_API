using Dapper.Contrib.Extensions;

namespace CHA_API.Model.TableModel
{
    [Table("ClientAddressMaster")]
    public class ClientAddressMasterBase
    {
        public long ClientId { get; set; }

        public string BranchNo { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string StateName { get; set; }

        public string StateCode { get; set; }

        public string District { get; set; }

        public string PINCode { get; set; }
    }
}
