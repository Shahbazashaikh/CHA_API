using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHA_API.Model.RequestModel;
using CHA_API.Model.ResponseModel;

namespace CHA_API.Service
{
    public interface IConsigneeMasterService
    {
        Task<List<ConsigneeMasterResponse>> GetConsigneeMaster(GetConsigneeMasterRequest getConsigneeMasterRequest);

        Task<string> InsertConsigneeMaster(ConsigneeMasterRequest consigneeMaster);
    }
}
