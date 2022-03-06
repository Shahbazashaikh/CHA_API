using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CHA_API.Service;
using CHA_API.Model.RequestModel;

namespace CHA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientAddressMasterController : ControllerBase
    {
        private readonly IClientAddressMasterService _clientAddressMasterService;

        public ClientAddressMasterController(IClientAddressMasterService clientAddressMasterService)
        {
            _clientAddressMasterService = clientAddressMasterService;
        }

        [Route("GetClientAddress/{clientId}")]
        [HttpGet]
        public async Task<IActionResult> GetClientAddress(long clientId)
        {
            return Ok(await _clientAddressMasterService.GetClientAddress(clientId))
;
        }

        [Route("InsertClientAddress")]
        [HttpPost]
        public async Task<IActionResult> InsertClientAddress(List<ClientAddressMasterRequest> clientAddresses)
        {
            return Ok(await _clientAddressMasterService.InsertClientAddress(clientAddresses));
        }

        [Route("UpdateClientAddress")]
        [HttpPut]
        public async Task<IActionResult> UpdateClientAddress(List<ClientAddressMasterRequest> clientAddresses)
        {
            return Ok(await _clientAddressMasterService.UpdateClientAddress(clientAddresses));
        }

        [Route("DeleteClientAddress/{clientId}/{documentId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteClientAddress(long clientId, long addressId)
        {
            return Ok(await _clientAddressMasterService.DeleteClientAddress(clientId, addressId));
        }
    }
}
