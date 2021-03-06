using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHA_API.Model.ResponseModel
{
    public class ConsigneeMasterResponse
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string BranchNo { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string CountryCode { get; set; }

        public int ZipCode { get; set; }

        public string Remarks { get; set; }

        public string Type { get; set; }
    }
}
