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
    public class MarketMemoController : ControllerBase
    {
        public readonly IMarketMemoSL _marketMemoSL;
        public readonly ILogger<MarketMemoController> _logger;
        public MarketMemoController(IMarketMemoSL marketMemoSL, ILogger<MarketMemoController> logger)
        {
            _marketMemoSL = marketMemoSL;
            _logger = logger;
        }

        // GET: api/<MarketMemoController>
        [HttpGet]
        [Route("GetMarketMemosRecord")]
        public async Task<IActionResult> ReadMarketMemoRecord()
        {
            MarketMemos respose = new MarketMemos();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _marketMemoSL.IReadMarketMemoRecordSL();
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.MarketMemosDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get MarketMemo Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.MarketMemosDataList });
        }

        // GET api/<MarketMemoController>/5
        [HttpPost]
        [Route("GetMarketMemosIDRecord")]
        public async Task<IActionResult> ReadMarketIDRecord(MarketMemos marketMemos)
        {
            MarketMemos respose = new MarketMemos();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _marketMemoSL.IReadMarketMemoIDRecordSL(marketMemos);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.MarketMemosDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get MarketMemo ID Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.MarketMemosDataList });
        }

        // POST api/<MarketMemoController>
        [HttpPost]
        [Route("CreateMarketMemosRecord")]
        public async Task<IActionResult> CreateMarketRecord(MarketMemos marketMemos)
        {
            MarketMemos respose = new MarketMemos();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(marketMemos)}");
            try
            {
                respose = await _marketMemoSL.ICreateMarketMemoRecordSL(marketMemos);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Create MarketMemo Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<MarketMemoController>/5
        [HttpPut]
        [Route("UpdateMarketMemosRecord")]
        public async Task<IActionResult> UpdateMarketRecord(MarketMemos marketMemos)
        {
            MarketMemos respose = new MarketMemos();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(marketMemos)}");
            try
            {
                respose = await _marketMemoSL.IUpdateMarketMemoRecordSL(marketMemos);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Update MarketMemo Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // DELETE api/<MarketMemoController>/5
        [HttpDelete]
        [Route("DeleteMarketMemosRecord")]
        public async Task<IActionResult> DeleteMarketRecord(MarketMemos marketMemos)
        {
            MarketMemos respose = new MarketMemos();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(marketMemos)}");
            try
            {
                respose = await _marketMemoSL.IDeleteMarketMemoRecordSL(marketMemos);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete MarketMemo Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }
    }
}
