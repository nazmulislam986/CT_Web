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
    public class DailySavingController : ControllerBase
    {
        public readonly IDailySavingSL _dailySavingSL;
        public readonly ILogger<DailySavingController> _logger;
        public DailySavingController(IDailySavingSL dailySavingSL, ILogger<DailySavingController> logger)
        {
            _dailySavingSL = dailySavingSL;
            _logger = logger;
        }

        // GET: api/<DailySavingController>
        [HttpGet]
        [Route("GetDailySavingRecord")]
        public async Task<IActionResult> ReadDailySavingRecord()
        {
            DailySaving respose = new DailySaving();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _dailySavingSL.IReadDailySavingRecordSL();
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailySavingDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get DailySaving Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailySavingDataList });
        }

        // GET api/<DailySavingController>/5
        [HttpPost]
        [Route("GetDailySavingIDRecord")]
        public async Task<IActionResult> ReadDailySavingIDRecord(DailySaving dailySaving)
        {
            DailySaving respose = new DailySaving();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _dailySavingSL.IReadDailySavingIDRecordSL(dailySaving);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailySavingDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get DailySaving ID Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.DailySavingDataList });
        }

        // POST api/<DailySavingController>
        [HttpPost]
        [Route("CreateDailySavingRecord")]
        public async Task<IActionResult> CreateDailySavingRecord(DailySaving dailySaving)
        {
            DailySaving respose = new DailySaving();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(dailySaving)}");
            try
            {
                respose = await _dailySavingSL.ICreateDailySavingRecordSL(dailySaving);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Create DailySaving Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<DailySavingController>/5
        [HttpPut]
        [Route("UpdateDailySavingRecord")]
        public async Task<IActionResult> UpdateDailySavingRecord(DailySaving dailySaving)
        {
            DailySaving respose = new DailySaving();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(dailySaving)}");
            try
            {
                respose = await _dailySavingSL.IUpdateDailySavingRecordSL(dailySaving);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Update DailySaving Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<DailySavingController>/5
        [HttpPut]
        [Route("DeleteResonDailySavingRecord")]
        public async Task<IActionResult> DeleteResonDailySavingRecord(DailySaving dailySaving)
        {
            DailySaving respose = new DailySaving();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(dailySaving)}");
            try
            {
                respose = await _dailySavingSL.IDeleteResonDailySavingRecordSL(dailySaving);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete Reson DailySaving Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // DELETE api/<DailySavingController>/5
        [HttpDelete]
        [Route("DeleteDailySavingRecord")]
        public async Task<IActionResult> DeleteDailySavingRecord(DailySaving dailySaving)
        {
            DailySaving respose = new DailySaving();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(dailySaving)}");
            try
            {
                respose = await _dailySavingSL.IDeleteDailySavingRecordSL(dailySaving);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete DailySaving Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }
    }
}
