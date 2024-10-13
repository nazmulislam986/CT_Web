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
    public class DailyAntController : ControllerBase
    {
        public readonly IDailyAntSL _dailyAntSL;
        public readonly ILogger<DailyAntController> _logger;
        public DailyAntController(IDailyAntSL dailyAntSL, ILogger<DailyAntController> logger)
        {
            _dailyAntSL = dailyAntSL;
            _logger = logger;
        }

        // GET: api/<DailyAntController>
        [HttpGet]
        [Route("GetDailyAntRecord")]
        public async Task<IActionResult> ReadDailyAntRecord()
        {
            DailyAnt respose = new DailyAnt();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _dailyAntSL.IReadDailyAntRecordSL();
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailyAntDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get DailyAnt Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailyAntDataList });
        }

        // GET api/<DailyAntController>/5
        [HttpPost]
        [Route("GetMarketIDRecord")]
        public async Task<IActionResult> ReadDailyAntIDRecord(DailyAnt dailyAnt)
        {
            DailyAnt respose = new DailyAnt();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _dailyAntSL.IReadDailyAntIDRecordSL(dailyAnt);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailyAntDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get DailyAnt ID Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailyAntDataList });
        }

        // POST api/<DailyAntController>
        [HttpPost]
        [Route("CreateDailyAntRecord")]
        public async Task<IActionResult> CreateDailyAntRecord(DailyAnt dailyAnt)
        {
            DailyAnt respose = new DailyAnt();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(dailyAnt)}");
            try
            {
                respose = await _dailyAntSL.ICreateDailyAntRecordSL(dailyAnt);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Create DailyAnt Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<DailyAntController>/5
        [HttpPut]
        [Route("UpdateDailyAntRecord")]
        public async Task<IActionResult> UpdateDailyAntRecord(DailyAnt dailyAnt)
        {
            DailyAnt respose = new DailyAnt();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(dailyAnt)}");
            try
            {
                respose = await _dailyAntSL.IUpdateDailyAntRecordSL(dailyAnt);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Update DailyAnt Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<DailyAntController>/5
        [HttpPut]
        [Route("DeleteResonDailyAntRecord")]
        public async Task<IActionResult> DeleteResonDailyAntRecord(DailyAnt dailyAnt)
        {
            DailyAnt respose = new DailyAnt();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(dailyAnt)}");
            try
            {
                respose = await _dailyAntSL.IDeleteResonDailyAntRecordSL(dailyAnt);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete Reson DailyAnt Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // DELETE api/<DailyAntController>/5
        [HttpDelete]
        [Route("DeleteDailyAntRecord")]
        public async Task<IActionResult> DeleteDailyAntRecord(DailyAnt dailyAnt)
        {
            DailyAnt respose = new DailyAnt();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(dailyAnt)}");
            try
            {
                respose = await _dailyAntSL.IDeleteDailyAntRecordSL(dailyAnt);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete DailyAnt Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }
    }
}
