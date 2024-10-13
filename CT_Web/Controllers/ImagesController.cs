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
    public class ImagesController : ControllerBase
    {
        public readonly IImagesSL _imagesSL;
        public readonly ILogger<ImagesController> _logger;
        public ImagesController(IImagesSL imagesSL, ILogger<ImagesController> logger)
        {
            _imagesSL = imagesSL;
            _logger = logger;
        }

        // GET: api/<ImagesController>
        [HttpGet]
        [Route("GetImagesRecord")]
        public async Task<IActionResult> ReadImagesRecord()
        {
            Images respose = new Images();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _imagesSL.IReadImagesRecordSL();
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.ImagesDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Images Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.ImagesDataList });
        }

        // GET api/<ImagesController>/5
        [HttpPost]
        [Route("GetImagesIDRecord")]
        public async Task<IActionResult> ReadImagesIDRecord(Images images)
        {
            Images respose = new Images();
            _logger.LogInformation($"Calling Read Controller");
            try
            {
                respose = await _imagesSL.IReadImagesIDRecordSL(images);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.ImagesDataList });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Get Images ID Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message, Data = respose.ImagesDataList });
        }

        // POST api/<ImagesController>
        [HttpPost]
        [Route("CreateMarketRecord")]
        public async Task<IActionResult> CreateMarketRecord(Images images)
        {
            Images respose = new Images();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(images)}");
            try
            {
                respose = await _imagesSL.ICreateImagesRecordSL(images);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Create Images Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // PUT api/<ImagesController>/5
        [HttpPut]
        [Route("UpdateMarketRecord")]
        public async Task<IActionResult> UpdateMarketRecord(Images images)
        {
            Images respose = new Images();
            _logger.LogInformation($"Calling Update Controller {JsonConvert.SerializeObject(images)}");
            try
            {
                respose = await _imagesSL.IUpdateImagesRecordSL(images);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Update Images Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }

        // DELETE api/<ImagesController>/5
        [HttpDelete]
        [Route("DeleteMarketRecord")]
        public async Task<IActionResult> DeleteMarketRecord(Images images)
        {
            Images respose = new Images();
            _logger.LogInformation($"Calling Create Controller {JsonConvert.SerializeObject(images)}");
            try
            {
                respose = await _imagesSL.IDeleteImagesRecordSL(images);
                if (!respose.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
                }
            }
            catch (Exception ex)
            {
                respose.IsSuccess = false;
                respose.Message = ex.Message;
                _logger.LogError($"Delete Images Record Error Message : {ex.Message}");
                return BadRequest(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
            }
            return Ok(new { IsSuccess = respose.IsSuccess, Message = respose.Message });
        }
    }
}
