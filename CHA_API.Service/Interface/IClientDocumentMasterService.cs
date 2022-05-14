using System.Collections.Generic;
using System.Threading.Tasks;
using CHA_API.Model;
using CHA_API.Model.RequestModel;
using CHA_API.Model.ResponseModel;
using Microsoft.AspNetCore.Http;

namespace CHA_API.Service
{
    public interface IClientDocumentMasterService
    {
        Task<ResponseModel<List<ClientDocumentMasterResponse>>> GetClientDocument(long clientId);

        Task<ResponseModel<object>> InsertClientDocument(List<ClientDocumentMasterRequest> documents);

        Task<ResponseModel<object>> UpdateClientDocument(List<ClientDocumentMasterRequest> documents);

        Task<ResponseModel<object>> DeleteClientDocument(long clientId, long documentId);
    }
}
