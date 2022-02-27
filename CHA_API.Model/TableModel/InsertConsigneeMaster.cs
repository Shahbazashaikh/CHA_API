using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace CHA_API.Model.TableModel
{
    [Table("ConsigneeMaster")]
    public class InsertConsigneeMaster : ConsigneeMasterBase
    {
        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
