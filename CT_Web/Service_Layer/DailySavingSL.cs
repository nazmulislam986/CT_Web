using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;
using CT_Web.Repository_Layer;
using Microsoft.Extensions.Logging;

namespace CT_Web.Service_Layer
{
    public class DailySavingSL : IDailySavingSL
    {
        public readonly IDailySavingRL _dailySavingRL;
        public readonly ILogger<DailySavingSL> _logger;
        public DailySavingSL(IDailySavingRL dailySavingRL, ILogger<DailySavingSL> logger)
        {
            _dailySavingRL = dailySavingRL;
            _logger = logger;
        }
        public async Task<DailySaving> ICreateDailySavingRecordSL(DailySaving dailySaving)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailySavingRL.ICreateDailySavingRecordRL(dailySaving);
        }
        public async Task<DailySaving> IReadDailySavingRecordSL()
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailySavingRL.IReadDailySavingRecordRL();
        }
        public async Task<DailySaving> IReadDailySavingIDRecordSL(DailySaving dailySaving)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailySavingRL.IReadDailySavingIDRecordRL(dailySaving);
        }
        public async Task<DailySaving> IUpdateDailySavingRecordSL(DailySaving dailySaving)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailySavingRL.IUpdateDailySavingRecordRL(dailySaving);
        }
        public async Task<DailySaving> IDeleteDailySavingRecordSL(DailySaving dailySaving)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailySavingRL.IDeleteDailySavingRecordRL(dailySaving);
        }
        public async Task<DailySaving> IDeleteResonDailySavingRecordSL(DailySaving dailySaving)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailySavingRL.IDeleteResonDailySavingRecordRL(dailySaving);
        }
    }
}
