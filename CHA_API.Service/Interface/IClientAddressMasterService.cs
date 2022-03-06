using System.Collections.Generic;
using System.Threading.Tasks;
using CHA_API.Model;
using CHA_API.Model.RequestModel;
using CHA_API.Model.ResponseModel;

namespace CHA_API.Service
{
    public interface IClientAddressMasterService
    {
        Task<ResponseModel<List<ClientAddressMasterResponse>>> GetClientAddress(long clientId);

        Task<ResponseModel<object>> InsertClientAddress(List<ClientAddressMasterRequest> addresses);

        Task<ResponseModel<object>> UpdateClientAddress(List<ClientAddressMasterRequest> addresses);

        Task<ResponseModel<object>> DeleteClientAddress(long clientId, long addressId);
    }
}
