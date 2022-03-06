using System.Collections.Generic;
using System.Threading.Tasks;
using CHA_API.Model.TableModel;
using CHA_API.Model.RequestModel;
using CHA_API.Model.ResponseModel;

namespace CHA_API.Repository
{
    public interface IClientMasterRepository
    {
        Task<IEnumerable<ClientMasterResponse>> GetClients(GetClientRequest clientRequest);

        Task<int> InsertClient(InsertClientMaster client);

        Task<bool> UpdateClient(UpdateClientMaster client);

        Task<bool> DeleteClient(long clientId);
    }
}
