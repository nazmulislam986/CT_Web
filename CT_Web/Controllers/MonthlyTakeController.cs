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
    public class MonthlyTakeController : ControllerBase
    {
        public readonly IMonthlyTakeSL _monthlyTakeSL;
        public readonly ILogger<MonthlyTakeController> _logger;
        public MonthlyTakeController(IMonthlyTakeSL monthlyTakeSL, ILogger<MonthlyTakeController> logger)
        {
            _monthlyTakeSL = monthlyTakeSL;
            _logger = logger;
        }

        // GET: api/<MonthlyTakeController>
        [HttpGet]
        [Route("GetMonthlyTakeRecord")]
        public async Task<IActionResult> ReadMonthlyTakeRecord()
        {
            MonthlyTake respose = new MonthlyTake();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _monthlyTakeSL.IReadMonthlyTakeRecordSL();
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.MonthlyTakeDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get MonthlyTake Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.MonthlyTakeDataList });
        }

        // GET api/<MonthlyTakeController>/5
        [HttpPost]
        [Route("GetMonthlyTakeIDRecord")]
        public async Task<IActionResult> ReadMonthlyTakeIDRecord(MonthlyTake monthlyTake)
        {
            MonthlyTake respose = new MonthlyTake();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _monthlyTakeSL.IReadMonthlyTakeIDRecordSL(monthlyTake);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.MonthlyTakeDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get MonthlyTake ID Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.MonthlyTakeDataList });
        }

        // POST api/<MonthlyTakeController>
        [HttpPost]
        [Route("CreateMonthlyTakeRecord")]
        public async Task<IActionResult> CreateMonthlyTakeRecord(MonthlyTake monthlyTake)
        {
            MonthlyTake respose = new MonthlyTake();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(monthlyTake)}");
            try
            {
                respose = await _monthlyTakeSL.ICreateMonthlyTakeRecordSL(monthlyTake);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Create MonthlyTake Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<MonthlyTakeController>/5
        [HttpPut]
        [Route("UpdateMonthlyTakeRecord")]
        public async Task<IActionResult> UpdateMonthlyTakeRecord(MonthlyTake monthlyTake)
        {
            MonthlyTake respose = new MonthlyTake();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(monthlyTake)}");
            try
            {
                respose = await _monthlyTakeSL.IUpdateMonthlyTaketRecordSL(monthlyTake);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Update MonthlyTake Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // DELETE api/<MonthlyTakeController>/5
        [HttpDelete]
        [Route("DeleteMonthlyTakeRecord")]
        public async Task<IActionResult> DeleteMonthlyTakeRecord(MonthlyTake monthlyTake)
        {
            MonthlyTake respose = new MonthlyTake();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(monthlyTake)}");
            try
            {
                respose = await _monthlyTakeSL.IDeleteMonthlyTakeRecordSL(monthlyTake);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete MonthlyTake Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }
    }
}
