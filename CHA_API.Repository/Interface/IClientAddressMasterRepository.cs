using System.Collections.Generic;
using System.Threading.Tasks;
using CHA_API.Model.TableModel;
using CHA_API.Model.ResponseModel;

namespace CHA_API.Repository
{
    public interface IClientAddressMasterRepository
    {
        Task<IEnumerable<ClientAddressMasterResponse>> GetClientAddress(long clientId);

        Task<int> InsertClientAddress(List<InsertClientAddressMaster> addresses);

        Task<bool> UpdateClientAddress(List<UpdateClientAddressMaster> addresses);

        Task<bool> DeleteClientAddress(long clientId, long addressId = 0);
    }
}
