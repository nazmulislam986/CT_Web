using CT_Web.Service_Layer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CT_Web.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DailyCutController : ControllerBase
    {
        public readonly IDailyCutSL _dailyCutSL;
        public readonly ILogger<DailyCutController> _logger;
        public DailyCutController(IDailyCutSL dailyCutSL, ILogger<DailyCutController> logger)
        {
            _dailyCutSL = dailyCutSL;
            _logger = logger;
        }

        // GET: api/<DailyCutController>
        [HttpGet]
        [Route("GetDailyCutRecord")]
        public async Task<IActionResult> ReadDailyCutRecord()
        {
            DailyCut respose = new DailyCut();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _dailyCutSL.IReadDailyCutRecordSL();
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailyCutDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get DailyCut Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailyCutDataList });
        }

        // GET api/<DailyCutController>/5
        [HttpPost]
        [Route("GetDailyCutIDRecord")]
        public async Task<IActionResult> ReadDailyCutIDRecord(DailyCut dailyCut)
        {
            DailyCut respose = new DailyCut();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _dailyCutSL.IReadDailyCutIDRecordSL(dailyCut);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailyCutDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get DailyCut ID Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailyCutDataList });
        }

        // POST api/<DailyCutController>
        [HttpPost]
        [Route("CreateDailyCutRecord")]
        public async Task<IActionResult> CreateDailyCutRecord(DailyCut dailyCut)
        {
            DailyCut respose = new DailyCut();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(dailyCut)}");
            try
            {
                respose = await _dailyCutSL.ICreateDailyCutRecordSL(dailyCut);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Create DailyCut Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<DailyCutController>/5
        [HttpPut]
        [Route("UpdateDailyCuttRecord")]
        public async Task<IActionResult> UpdateDailyCutRecord(DailyCut dailyCut)
        {
            DailyCut respose = new DailyCut();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(dailyCut)}");
            try
            {
                respose = await _dailyCutSL.IUpdateDailyCutRecordSL(dailyCut);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Update DailyCut Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // DELETE api/<DailyCutController>/5
        [HttpDelete]
        [Route("DeleteDailyCutRecord")]
        public async Task<IActionResult> DeleteDailyCutRecord(DailyCut dailyCut)
        {
            DailyCut respose = new DailyCut();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(dailyCut)}");
            try
            {
                respose = await _dailyCutSL.IDeleteDailyCutRecordSL(dailyCut);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete DailyCut Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }
    }
}
