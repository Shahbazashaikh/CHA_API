using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHA_API.Model.RequestModel
{
    public class ConsigneeMasterRequest
    {
        public string Name { get; set; }

        public string BranchSlno { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public int CountryName { get; set; }

        public string CountryCode { get; set; }

        public int PINCode { get; set; }

        public string Remarks { get; set; }

        public int UserId { get; set; }
    }
}
