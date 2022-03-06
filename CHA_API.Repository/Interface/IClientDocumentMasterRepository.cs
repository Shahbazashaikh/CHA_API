using System.Collections.Generic;
using System.Threading.Tasks;
using CHA_API.Model.TableModel;
using CHA_API.Model.ResponseModel;

namespace CHA_API.Repository
{
    public interface IClientDocumentMasterRepository
    {
        Task<IEnumerable<ClientDocumentMasterResponse>> GetClientDocument(long clientId);

        Task<int> InserClientDocument(List<InsertClientDocumentMaster> documents);

        Task<bool> UpdateClientDocument(List<UpdateClientDocumentMaster> documents);

        Task<bool> DeleteClientDocument(long clientId, long documentId = 0);
    }
}
