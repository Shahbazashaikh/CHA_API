using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CHA_API.Service;
using CHA_API.Model.RequestModel;

namespace CHA_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ConsigneeMasterController : ControllerBase
    {

        private readonly IConsigneeMasterService _consigneeMasterService;

        public ConsigneeMasterController(IConsigneeMasterService consigneeMasterService)
        {
            _consigneeMasterService = consigneeMasterService;
        }

        [Route("GetConsigneeMaster")]
        [HttpPost]
        public async Task<IActionResult> GetConsigneeMaster(GetConsigneeMasterRequest getConsigneeMasterRequest)
        {
            return Ok(await _consigneeMasterService.GetConsigneeMaster(getConsigneeMasterRequest));
        }

        [Route("InsertConsigneeMaster")]
        [HttpPost]
        public async Task<IActionResult> InsertConsigneeMaster(ConsigneeMasterRequest consigneeMaster)
        {

            return Ok(await _consigneeMasterService.InsertConsigneeMaster(consigneeMaster));
        }
    }
}
