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
    public class GivenController : ControllerBase
    {
        public readonly IGivenSL _givenSL;
        public readonly ILogger<GivenController> _logger;
        public GivenController(IGivenSL givenSL, ILogger<GivenController> logger)
        {
            _givenSL = givenSL;
            _logger = logger;
        }

        // GET: api/<GivenController>
        [HttpGet]
        [Route("GetGivenRecord")]
        public async Task<IActionResult> ReadGivenRecord()
        {
            Given respose = new Given();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _givenSL.IReadGivenRecordSL();
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.GivenDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Market Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.GivenDataList });
        }

        // GET api/<GivenController>/5
        [HttpPost]
        [Route("GetGivenIDRecord")]
        public async Task<IActionResult> ReadGivenIDRecord(Given given)
        {
            Given respose = new Given();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _givenSL.IReadGivenIDRecordSL(given);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.GivenDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Market ID Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.GivenDataList });
        }

        // POST api/<GivenController>
        [HttpPost]
        [Route("CreateGivenRecord")]
        public async Task<IActionResult> CreateGivenRecord(Given given)
        {
            Given respose = new Given();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(given)}");
            try
            {
                respose = await _givenSL.ICreateGivenRecordSL(given);
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

        // PUT api/<GivenController>/5
        [HttpPut]
        [Route("UpdateGivenRecord")]
        public async Task<IActionResult> UpdateGivenRecord(Given given)
        {
            Given respose = new Given();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(given)}");
            try
            {
                respose = await _givenSL.IUpdateGivenRecordSL(given);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Update Market Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<GivenController>/5
        [HttpPut]
        [Route("DeleteResonGivenRecord")]
        public async Task<IActionResult> DeleteResonGivenRecord(Given given)
        {
            Given respose = new Given();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(given)}");
            try
            {
                respose = await _givenSL.IDeleteResonGivenRecordSL(given);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Update Market Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // DELETE api/<GivenController>/5
        [HttpDelete]
        [Route("DeleteGivenRecord")]
        public async Task<IActionResult> DeleteGivenRecord(Given given)
        {
            Given respose = new Given();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(given)}");
            try
            {
                respose = await _givenSL.IDeleteGivenRecordSL(given);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete Market Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }
    }
}
