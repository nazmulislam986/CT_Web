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
    [Route("api/[controller]")]
    [ApiController]
    public class SavingController : ControllerBase
    {
        public readonly ISavingSL _savingSL;
        public readonly ILogger<SavingController> _logger;
        public SavingController(ISavingSL savingSL, ILogger<SavingController> logger)
        {
            _savingSL = savingSL;
            _logger = logger;
        }

        // GET: api/<SavingController>
        [HttpGet]
        [Route("GetSavingRecord")]
        public async Task<IActionResult> ReadSavingRecord()
        {
            Saving respose = new Saving();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _savingSL.IReadSavingRecordSL();
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.SavingDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Saving Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.SavingDataList });
        }

        // GET api/<SavingController>/5
        [HttpPost]
        [Route("GetSavingIDRecord")]
        public async Task<IActionResult> ReadSavingIDRecord(Saving saving)
        {
            Saving respose = new Saving();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _savingSL.IReadSavingIDRecordSL(saving);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.SavingDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Saving ID Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.SavingDataList });
        }

        // POST api/<SavingController>
        [HttpPost]
        [Route("CreateSavingRecord")]
        public async Task<IActionResult> CreateSavingRecord(Saving saving)
        {
            Saving respose = new Saving();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(saving)}");
            try
            {
                respose = await _savingSL.ICreateSavingRecordSL(saving);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Create Saving Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<SavingController>/5
        [HttpPut]
        [Route("UpdateSavingRecord")]
        public async Task<IActionResult> UpdateSavingRecord(Saving saving)
        {
            Saving respose = new Saving();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(saving)}");
            try
            {
                respose = await _savingSL.IUpdateSavingRecordSL(saving);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Update Saving Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // DELETE api/<SavingController>/5
        [HttpDelete]
        [Route("DeleteSavingRecord")]
        public async Task<IActionResult> DeleteSavingRecord(Saving saving)
        {
            Saving respose = new Saving();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(saving)}");
            try
            {
                respose = await _savingSL.IDeleteSavingRecordSL(saving);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete Saving Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }
    }
}
