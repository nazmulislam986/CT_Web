using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;
using CT_Web.Service_Layer;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CT_Web.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BikeInfoController : ControllerBase
    {
        public readonly IBikeInfoSL _bikeInfoSL;
        public readonly ILogger<BikeInfoController> _logger;
        public BikeInfoController(IBikeInfoSL bikeInfoSL, ILogger<BikeInfoController> logger)
        {
            _bikeInfoSL = bikeInfoSL;
            _logger = logger;
        }
        
        // GET: api/<BikeInfoController>    //All Details from DB
        [HttpGet]
        [Route("GetBikeInfo")]
        public async Task<IActionResult> ReadMarketRecord()
        {
            BikeInfo respose = new BikeInfo();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _bikeInfoSL.IReadBikeInfoRecordSL();
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.BikeInfoList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Bike Info Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.BikeInfoList });
        }

        // GET api/<BikeInfoController>/5   //All Details By ID From DB [HttpGet("{id}")]


        // POST api/<BikeInfoController>    //Insert Details into DB
        [HttpPost]
        [Route("CreateBikeInfo")]
        public async Task<IActionResult> CreateMarketRecord(BikeInfo bikeinfo)
        {
            BikeInfo respose = new BikeInfo();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(bikeinfo)}");
            try
            {
                respose = await _bikeInfoSL.ICreateBikeInfoRecordSL(bikeinfo);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Create Market Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<BikeInfoController>/5   //Update Details By ID [HttpPut("{id}")]


        // DELETE api/<BikeInfoController>/5    //Delete Details By ID [HttpDelete("{id}")]

    }
}
