using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHA_API.Model.ResponseModel
{
    public class ClientAddressMasterResponse
    {
        public long AddressID { get; set; }

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
