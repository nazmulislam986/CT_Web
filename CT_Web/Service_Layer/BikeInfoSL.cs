using CT_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_Web.Repository_Layer;
using Microsoft.Extensions.Logging;

namespace CT_Web.Service_Layer
{
    public class BikeInfoSL : IBikeInfoSL
    {
        public readonly IBikeInfoRL _bikeInfoRL;
        public readonly ILogger<BikeInfoSL> _logger;
        public BikeInfoSL(IBikeInfoRL bikeInfoRL, ILogger<BikeInfoSL> logger)
        {
            _bikeInfoRL = bikeInfoRL;
            _logger = logger;
        }
        public async Task<BikeInfo> ICreateBikeInfoRecordSL(BikeInfo bikeInfo)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _bikeInfoRL.ICreateBikeInfoRecordRL(bikeInfo);
        }
        public async Task<BikeInfo> IReadBikeInfoRecordSL()
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _bikeInfoRL.IReadBikeInfoRecordRL();
        }
        public async Task<BikeInfo> IReadBikeInfoIDRecordSL(BikeInfo bikeInfo)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _bikeInfoRL.IReadBikeInfoIDRecordRL(bikeInfo);
        }
        public async Task<BikeInfo> IUpdateBikeInfoRecordSL(BikeInfo bikeInfo)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _bikeInfoRL.IUpdateBikeInfoRecordRL(bikeInfo);
        }
        public async Task<BikeInfo> IDeleteBikeInfoRecordSL(BikeInfo bikeInfo)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _bikeInfoRL.IDeleteBikeInfoRecordRL(bikeInfo);
        }
    }
}
