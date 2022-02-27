using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHA_API.Model.RequestModel;
using CHA_API.Model.ResponseModel;
using CHA_API.Model;

namespace CHA_API.Service
{
    public interface IConsigneeMasterService
    {
        Task<ResponseModel<List<ConsigneeMasterResponse>>> GetConsigneeMaster(GetConsigneeMasterRequest getConsigneeMasterRequest);

        Task<ResponseModel<string>> InsertConsigneeMaster(ConsigneeMasterRequest consigneeMaster);
    }
}
