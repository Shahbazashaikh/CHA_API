using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CHA_API.Service;
using CHA_API.Model.RequestModel;

namespace CHA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientDocumentMasterController : ControllerBase
    {
        private readonly IClientDocumentMasterService _clientDocumentMasterService;

        public ClientDocumentMasterController(IClientDocumentMasterService clientDocumentMasterService)
        {
            _clientDocumentMasterService = clientDocumentMasterService;
        }

        [Route("GetClientDocuments/{clientId}")]
        [HttpGet]
        public async Task<IActionResult> GetClientDocuments(long clientId)
        {
            return Ok(await _clientDocumentMasterService.GetClientDocument(clientId))
;
        }

        [Route("InsertClientDocument")]
        [HttpPost]
        public async Task<IActionResult> InsertClientDocument(List<ClientDocumentMasterRequest> clientDocuments)
        {
            return Ok(await _clientDocumentMasterService.InsertClientDocument(clientDocuments));
        }

        [Route("UpdateClientDocument")]
        [HttpPut]
        public async Task<IActionResult> UpdateClientDocument(List<ClientDocumentMasterRequest> clientDocuments)
        {
            return Ok(await _clientDocumentMasterService.UpdateClientDocument(clientDocuments));
        }

        [Route("DeleteClientDocument/{clientId}/{documentId}")]
        [HttpDelete]
        public async Task<IActionResult> UpdateClientDocument(long clientId, long documentId)
        {
            return Ok(await _clientDocumentMasterService.DeleteClientDocument(clientId, documentId));
        }
    }
}
