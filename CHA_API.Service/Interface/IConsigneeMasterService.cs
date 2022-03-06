using System.Collections.Generic;
using System.Threading.Tasks;
using CHA_API.Model;
using CHA_API.Model.RequestModel;
using CHA_API.Model.ResponseModel;

namespace CHA_API.Service
{
    public interface IConsigneeMasterService
    {
        Task<ResponseModel<List<ConsigneeMasterResponse>>> GetConsigneeMaster(GetConsigneeMasterRequest getConsigneeMasterRequest);

        Task<ResponseModel<object>> InsertConsigneeMaster(ConsigneeMasterRequest consigneeMaster);

        Task<ResponseModel<object>> UpdateConsigneeMaster(ConsigneeMasterRequest consigneeMaster);

        Task<ResponseModel<object>> DeleteConsigneeMaster(int id);

    }
}
