using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace CHA_API.Model.TableModel
{
    [Table("ConsigneeMaster")]
    public class UpdateConsigneeMaster : ConsigneeMasterBase
    {
        public int Id { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
