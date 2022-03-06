using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CHA_API.Service;
using CHA_API.Model.RequestModel;

namespace CHA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientMasterController : ControllerBase
    {
        private readonly IClientMasterService _clientMasterService;

        public ClientMasterController(IClientMasterService clientMasterService)
        {
            _clientMasterService = clientMasterService;
        }

        [Route("GetClients")]
        [HttpPost]
        public async Task<IActionResult> GetClients(GetClientRequest clientRequest)
        {
            return Ok(await _clientMasterService.GetClients(clientRequest))
;
        }

        [Route("InsertClient")]
        [HttpPost]
        public async Task<IActionResult> InsertClient(ClientMasterRequest client)
        {
            return Ok(await _clientMasterService.InsertClient(client));
        }

        [Route("UpdateClient")]
        [HttpPut]
        public async Task<IActionResult> UpdateClient(ClientMasterRequest client)
        {
            return Ok(await _clientMasterService.UpdateClient(client));
        }

        [Route("DeleteClient/{clientId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteClient(long clientId)
        {
            return Ok(await _clientMasterService.DeleteClient(clientId));
        }
    }
}
