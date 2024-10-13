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
    public class TekenController : ControllerBase
    {
        public readonly ITekenSL _tekenSL;
        public readonly ILogger<TekenController> _logger;
        public TekenController(ITekenSL tekenSL, ILogger<TekenController> logger)
        {
            _tekenSL = tekenSL;
            _logger = logger;
        }

        // GET: api/<TekenController>
        [HttpGet]
        [Route("GetTekenRecord")]
        public async Task<IActionResult> ReadTekenRecord()
        {
            Teken respose = new Teken();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _tekenSL.IReadTekenRecordSL();
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.TekenDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Teken Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.TekenDataList });
        }

        // GET api/<TekenController>/5
        [HttpPost]
        [Route("GetTekenIDRecord")]
        public async Task<IActionResult> ReadTekenIDRecord(Teken teken)
        {
            Teken respose = new Teken();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _tekenSL.IReadTekenIDRecordSL(teken);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.TekenDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Teken ID Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.TekenDataList });
        }

        // POST api/<TekenController>
        [HttpPost]
        [Route("CreateTekenRecord")]
        public async Task<IActionResult> CreateTekenRecord(Teken teken)
        {
            Teken respose = new Teken();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(teken)}");
            try
            {
                respose = await _tekenSL.ICreateTekenRecordSL(teken);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Create Teken Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<TekenController>/5
        [HttpPut]
        [Route("UpdateTekenRecord")]
        public async Task<IActionResult> UpdateTekenRecord(Teken teken)
        {
            Teken respose = new Teken();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(teken)}");
            try
            {
                respose = await _tekenSL.IUpdateTekenRecordSL(teken);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Update Teken Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // DELETE api/<TekenController>/5
        [HttpDelete]
        [Route("DeleteTekenRecord")]
        public async Task<IActionResult> DeleteTekenRecord(Teken teken)
        {
            Teken respose = new Teken();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(teken)}");
            try
            {
                respose = await _tekenSL.IDeleteTekenRecordSL(teken);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete Teken Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }
    }
}
