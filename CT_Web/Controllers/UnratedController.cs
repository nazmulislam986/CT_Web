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
    public class UnratedController : ControllerBase
    {
        public readonly IUnratedSL _unratedSL;
        public readonly ILogger<UnratedController> _logger;
        public UnratedController(IUnratedSL unratedSL, ILogger<UnratedController> logger)
        {
            _unratedSL = unratedSL;
            _logger = logger;
        }

        // GET: api/<UnratedController>
        [HttpGet]
        [Route("GetUnratedRecord")]
        public async Task<IActionResult> ReadUnratedRecord()
        {
            Unrated respose = new Unrated();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _unratedSL.IReadUnratedRecordSL();
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.UnratedDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Unrated Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.UnratedDataList });
        }

        // GET api/<UnratedController>/5
        [HttpPost]
        [Route("GetUnratedIDRecord")]
        public async Task<IActionResult> ReadUnratedIDRecord(Unrated unrated)
        {
            Unrated respose = new Unrated();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _unratedSL.IReadUnratedIDRecordSL(unrated);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.UnratedDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Unrated ID Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.UnratedDataList });
        }

        // POST api/<UnratedController>
        [HttpPost]
        [Route("CreateUnratedRecord")]
        public async Task<IActionResult> CreateUnratedRecord(Unrated unrated)
        {
            Unrated respose = new Unrated();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(unrated)}");
            try
            {
                respose = await _unratedSL.ICreateUnratedRecordSL(unrated);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Create Unrated Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<UnratedController>/5
        [HttpPut]
        [Route("UpdateUnratedRecord")]
        public async Task<IActionResult> UpdateUnratedRecord(Unrated unrated)
        {
            Unrated respose = new Unrated();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(unrated)}");
            try
            {
                respose = await _unratedSL.IUpdateUnratedRecordSL(unrated);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Update Unrated Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // DELETE api/<UnratedController>/5
        [HttpDelete]
        [Route("DeleteUnratedRecord")]
        public async Task<IActionResult> DeleteUnratedRecord(Unrated unrated)
        {
            Unrated respose = new Unrated();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(unrated)}");
            try
            {
                respose = await _unratedSL.IDeleteUnratedRecordSL(unrated);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete Unrated Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }
    }
}
