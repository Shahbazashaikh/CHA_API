using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace CHA_API.Model.TableModel
{
    [Table("BuyerMaster")]
    public class BuyerMasterBase
    {
        public string Name { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string CountryName { get; set; }
    }
}
