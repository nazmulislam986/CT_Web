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
    public class TariffAmtController : ControllerBase
    {
        public readonly ITariffAmtSL _tariffAmtSL;
        public readonly ILogger<TariffAmtController> _logger;
        public TariffAmtController(ITariffAmtSL tariffAmtSL, ILogger<TariffAmtController> logger)
        {
            _tariffAmtSL = tariffAmtSL;
            _logger = logger;
        }

        // GET: api/<TariffAmtController>
        [HttpGet]
        [Route("GetTariffAmtRecord")]
        public async Task<IActionResult> ReadTariffAmtRecord()
        {
            TariffAmt respose = new TariffAmt();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _tariffAmtSL.IReadTariffAmtRecordSL();
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.TariffAmtDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get TariffAmt Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.TariffAmtDataList });
        }

        // GET api/<TariffAmtController>/5
        [HttpPost]
        [Route("GetTariffAmtIDRecord")]
        public async Task<IActionResult> ReadTariffAmtIDRecord(TariffAmt tariffAmt)
        {
            TariffAmt respose = new TariffAmt();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _tariffAmtSL.IReadTariffAmtIDRecordSL(tariffAmt);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.TariffAmtDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get TariffAmt ID Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.TariffAmtDataList });
        }

        // POST api/<TariffAmtController>
        [HttpPost]
        [Route("CreateTariffAmtRecord")]
        public async Task<IActionResult> CreateTariffAmtRecord(TariffAmt tariffAmt)
        {
            TariffAmt respose = new TariffAmt();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(tariffAmt)}");
            try
            {
                respose = await _tariffAmtSL.ICreateTariffAmtRecordSL(tariffAmt);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Create TariffAmt Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<TariffAmtController>/5
        [HttpPut]
        [Route("UpdateTariffAmtRecord")]
        public async Task<IActionResult> UpdateTariffAmtRecord(TariffAmt tariffAmt)
        {
            TariffAmt respose = new TariffAmt();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(tariffAmt)}");
            try
            {
                respose = await _tariffAmtSL.IUpdateTariffAmtRecordSL(tariffAmt);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Update TariffAmt Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // DELETE api/<TariffAmtController>/5
        [HttpDelete]
        [Route("DeleteTariffAmtRecord")]
        public async Task<IActionResult> DeleteTariffAmtRecord(TariffAmt tariffAmt)
        {
            TariffAmt respose = new TariffAmt();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(tariffAmt)}");
            try
            {
                respose = await _tariffAmtSL.IDeleteTariffAmtRecordSL(tariffAmt);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete TariffAmt Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }
    }
}
