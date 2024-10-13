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
    public class DailyController : ControllerBase
    {
        public readonly IDailySL _dailySL;
        public readonly ILogger<DailyController> _logger;

        public DailyController(IDailySL dailySL, ILogger<DailyController> logger)
        {
            _dailySL = dailySL;
            _logger = logger;
        }
        // GET: api/<DailyController>
        [HttpGet]
        [Route("GetDailyInfo")]
        public async Task<IActionResult> ReadDailyRecord()
        {
            Daily respose = new Daily();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _dailySL.IReadDailyRecordSL();
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailyDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Daily Info Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailyDataList });
        }

        // GET api/<DailyController>/5
        [HttpPost]
        [Route("GetDailyIDRecord")]
        public async Task<IActionResult> ReadDailyIDRecord(Daily daily)
        {
            Daily respose = new Daily();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _dailySL.IReadDailyIDRecordSL(daily);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailyDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Daily ID Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailyDataList });
        }

        // POST api/<DailyController>
        [HttpPost]
        [Route("CreateDailyInfo")]
        public async Task<IActionResult> CreateBikeRecord(Daily daily)
        {
            Daily respose = new Daily();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(daily)}");
            try
            {
                respose = await _dailySL.ICreateDailyRecordSL(daily);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Create Daily Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<DailyController>/5
        [HttpPut]
        [Route("UpdateDailyRecord")]
        public async Task<IActionResult> UpdateDailyRecord(Daily daily)
        {
            Daily respose = new Daily();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(daily)}");
            try
            {
                respose = await _dailySL.IUpdateDailyRecordSL(daily);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Update Daily Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<DailyController>/5
        [HttpPut]
        [Route("DeleteResonDailyRecord")]
        public async Task<IActionResult> DeleteResonDailyRecord(Daily daily)
        {
            Daily respose = new Daily();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(daily)}");
            try
            {
                respose = await _dailySL.IDeleteResonDailyRecordSL(daily);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete Reson Daily Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // DELETE api/<DailyController>/5
        [HttpDelete]
        [Route("DeleteDailyRecord")]
        public async Task<IActionResult> DeleteBikeRecord(Daily daily)
        {
            Daily respose = new Daily();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(daily)}");
            try
            {
                respose = await _dailySL.IDeleteDailyRecordSL(daily);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete Daily Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }
    }
}
