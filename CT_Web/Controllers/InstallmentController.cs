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
    public class InstallmentController : ControllerBase
    {
        public readonly IInstallmentSL _installmentSL;
        public readonly ILogger<InstallmentController> _logger;
        public InstallmentController(IInstallmentSL installmentSL, ILogger<InstallmentController> logger)
        {
            _installmentSL = installmentSL;
            _logger = logger;
        }

        // GET: api/<InstallmentController>
        [HttpGet]
        [Route("GetInstallmentRecord")]
        public async Task<IActionResult> ReadInstallmentRecord()
        {
            Installment respose = new Installment();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _installmentSL.IReadInstallmentRecordSL();
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.InstallmentDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Installment Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.InstallmentDataList });
        }

        // GET api/<InstallmentController>/5
        [HttpPost]
        [Route("GetInstallmentIDRecord")]
        public async Task<IActionResult> ReadInstallmentIDRecord(Installment installment)
        {
            Installment respose = new Installment();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _installmentSL.IReadInstallmentIDRecordSL(installment);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.InstallmentDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Installment ID Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.InstallmentDataList });
        }

        // POST api/<InstallmentController>
        [HttpPost]
        [Route("CreateInstallmentRecord")]
        public async Task<IActionResult> CreateInstallmentRecord(Installment installment)
        {
            Installment respose = new Installment();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(installment)}");
            try
            {
                respose = await _installmentSL.ICreateInstallmentRecordSL(installment);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Create Installment Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<InstallmentController>/5
        [HttpPut]
        [Route("UpdateInstallmentRecord")]
        public async Task<IActionResult> UpdateInstallmentRecord(Installment installment)
        {
            Installment respose = new Installment();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(installment)}");
            try
            {
                respose = await _installmentSL.IUpdateInstallmentRecordSL(installment);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Update Installment Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // DELETE api/<InstallmentController>/5
        [HttpDelete]
        [Route("DeleteInstallmentRecord")]
        public async Task<IActionResult> DeleteInstallmentRecord(Installment installment)
        {
            Installment respose = new Installment();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(installment)}");
            try
            {
                respose = await _installmentSL.IDeleteInstallmentRecordSL(installment);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete Installment Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }
    }
}
