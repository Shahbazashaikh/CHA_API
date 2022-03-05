using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;


namespace CHA_API.Model.TableModel
{
    [Table("ConsigneeMaster")]
    public class ConsigneeMasterBase
    {
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
