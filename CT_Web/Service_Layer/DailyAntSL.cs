using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;
using CT_Web.Repository_Layer;
using Microsoft.Extensions.Logging;

namespace CT_Web.Service_Layer
{
    public class DailyAntSL : IDailyAntSL
    {
        public readonly IDailyAntRL _dailyAntRL;
        public readonly ILogger<DailyAntSL> _logger;
        public DailyAntSL(IDailyAntRL dailyAntRL, ILogger<DailyAntSL> logger)
        {
            _dailyAntRL = dailyAntRL;
            _logger = logger;
        }
        public async Task<DailyAnt> ICreateDailyAntRecordSL(DailyAnt dailyAnt)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyAntRL.ICreateDailyAntRecordRL(dailyAnt);
        }
        public async Task<DailyAnt> IReadDailyAntRecordSL()
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyAntRL.IReadDailyAntRecordRL();
        }
        public async Task<DailyAnt> IReadDailyAntIDRecordSL(DailyAnt dailyAnt)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyAntRL.IReadDailyAntIDRecordRL(dailyAnt);
        }
        public async Task<DailyAnt> IUpdateDailyAntRecordSL(DailyAnt dailyAnt)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyAntRL.IUpdateDailyAntRecordRL(dailyAnt);
        }
        public async Task<DailyAnt> IDeleteDailyAntRecordSL(DailyAnt dailyAnt)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyAntRL.IDeleteDailyAntRecordRL(dailyAnt);
        }
        public async Task<DailyAnt> IDeleteResonDailyAntRecordSL(DailyAnt dailyAnt)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyAntRL.IDeleteResonDailyAntRecordRL(dailyAnt);
        }
    }
}
