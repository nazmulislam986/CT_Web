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
    public class MarketController : ControllerBase
    {
        public readonly IMarketSL _marketSL;
        public readonly ILogger<MarketController> _logger;
        public MarketController(IMarketSL marketSL, ILogger<MarketController> logger)
        {
            _marketSL = marketSL;
            _logger = logger;
        }

        // GET: api/<MarketMemoController>
        [HttpGet]
        [Route("GetMarketRecord")]
        public async Task<IActionResult> ReadMarketRecord()
        {
            Market respose = new Market();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _marketSL.IReadMarketRecordSL();
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.MarketDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Market Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.MarketDataList });
        }

        // GET api/<MarketMemoController>/5
        [HttpPost]
        [Route("GetMarketIDRecord")]
        public async Task<IActionResult> ReadMarketIDRecord(Market market)
        {
            Market respose = new Market();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _marketSL.IReadMarketIDRecordSL(market);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.MarketDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Market Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.MarketDataList });
        }

        // POST api/<MarketMemoController>
        [HttpPost]
        [Route("CreateMarketRecord")]
        public async Task<IActionResult> CreateMarketRecord(Market market)
        {
            Market respose = new Market();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(market)}");
            try
            {
                respose = await _marketSL.ICreateMarketRecordSL(market);
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

        // PUT api/<MarketMemoController>/5
        [HttpPut]
        [Route("UpdateMarketRecord")]
        public async Task<IActionResult> UpdateMarketRecord(Market market)
        {
            Market respose = new Market();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(market)}");
            try
            {
                respose = await _marketSL.IUpdateMarketRecordSL(market);
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

        // DELETE api/<MarketMemoController>/5
        [HttpDelete]
        [Route("DeleteMarketRecord")]
        public async Task<IActionResult> DeleteMarketRecord(Market market)
        {
            Market respose = new Market();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(market)}");
            try
            {
                respose = await _marketSL.IDeleteMarketRecordSL(market);
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
    }
}
