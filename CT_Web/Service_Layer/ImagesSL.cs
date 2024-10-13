using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;
using CT_Web.Repository_Layer;
using Microsoft.Extensions.Logging;

namespace CT_Web.Service_Layer
{
    public class ImagesSL : IImagesSL
    {
        public readonly IImagesRL _imagesRL;
        public readonly ILogger<ImagesSL> _logger;
        public ImagesSL(IImagesRL imagesRL, ILogger<ImagesSL> logger)
        {
            _imagesRL = imagesRL;
            _logger = logger;
        }
        public async Task<Images> ICreateImagesRecordSL(Images images)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _imagesRL.ICreateImagesRecordRL(images);
        }
        public async Task<Images> IReadImagesRecordSL()
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _imagesRL.IReadImagesRecordRL();
        }
        public async Task<Images> IReadImagesIDRecordSL(Images images)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _imagesRL.IReadImagesIDRecordRL(images);
        }
        public async Task<Images> IUpdateImagesRecordSL(Images images)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _imagesRL.IUpdateImagesRecordRL(images);
        }
        public async Task<Images> IDeleteImagesRecordSL(Images images)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _imagesRL.IDeleteImagesRecordRL(images);
        }
    }
}
