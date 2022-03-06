using System.Collections.Generic;
using System.Threading.Tasks;
using CHA_API.Model;
using CHA_API.Model.RequestModel;
using CHA_API.Model.ResponseModel;

namespace CHA_API.Service
{
    public interface IClientMasterService
    {
        Task<ResponseModel<List<ClientMasterResponse>>> GetClients(GetClientRequest clientRequest);

        Task<ResponseModel<object>> InsertClient(ClientMasterRequest client);

        Task<ResponseModel<object>> UpdateClient(ClientMasterRequest client);

        Task<ResponseModel<object>> DeleteClient(long clientId);
    }
}
