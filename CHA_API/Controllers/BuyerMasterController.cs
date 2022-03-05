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
    public class BuyerMasterController : ControllerBase
    {

        private readonly IBuyerMasterServices _buyerMasterServices;

        public BuyerMasterController(IBuyerMasterServices buyerMasterServices)
        {
            _buyerMasterServices = buyerMasterServices;
        }

        [Route("GetBuyerMaster/{buyerName}")]
        [HttpGet]
        public async Task<IActionResult> GetBuyerMaster(string buyerName)
        {
            return Ok(await _buyerMasterServices.GetBuyerMaster(buyerName));
        }

        [Route("InsertBuyerMaster")]
        [HttpPost]
        public async Task<IActionResult> InsertBuyerMaster(BuyerMasterRequest buyerMaster)
        {
            return Ok(await _buyerMasterServices.InsertBuyerMaster(buyerMaster));
        }

    }
}
