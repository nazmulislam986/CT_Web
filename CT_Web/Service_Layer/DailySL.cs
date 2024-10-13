using CT_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_Web.Repository_Layer;
using Microsoft.Extensions.Logging;

namespace CT_Web.Service_Layer
{
    public class DailySL : IDailySL
    {
        public readonly IDailyRL _dailyRL;
        public readonly ILogger<DailySL> _logger;
        public DailySL(IDailyRL dailyRL, ILogger<DailySL> logger)
        {
            _dailyRL = dailyRL;
            _logger = logger;
        }
        public async Task<Daily> ICreateDailyRecordSL(Daily daily)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyRL.ICreateDailyRecordRL(daily);
        }
        public async Task<Daily> IReadDailyRecordSL()
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyRL.IReadDailyRecordRL();
        }
        public async Task<Daily> IReadDailyIDRecordSL(Daily daily)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyRL.IReadDailyIDRecordRL(daily);
        }
        public async Task<Daily> IUpdateDailyRecordSL(Daily daily)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyRL.IUpdateDailyRecordRL(daily);
        }
        public async Task<Daily> IDeleteDailyRecordSL(Daily daily)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyRL.IDeleteDailyRecordRL(daily);
        }
        public async Task<Daily> IDeleteResonDailyRecordSL(Daily daily)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyRL.IDeleteResonDailyRecordRL(daily);
        }
    }
}
