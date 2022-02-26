using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHA_API.Model.TableModel;
using CHA_API.Model.RequestModel;
using CHA_API.Model.ResponseModel;

namespace CHA_API.Repository
{
    public interface IConsigneeRepository
    {
        Task<IEnumerable<ConsigneeMasterResponse>> GetConsigneeMaster(GetConsigneeMasterRequest getConsigneeMasterRequest);

        Task<int> InsertConsigneeMaster(InsertConsigneeMaster ConsigneeMaster);

    }
}
