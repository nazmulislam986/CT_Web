using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;
using CT_Web.Repository_Layer;
using Microsoft.Extensions.Logging;

namespace CT_Web.Service_Layer
{
    public class DailyCutSL : IDailyCutSL
    {
        public readonly IDailyCutRL _dailyCutRL;
        public readonly ILogger<DailyCutSL> _logger;
        public DailyCutSL(IDailyCutRL dailyCutRL, ILogger<DailyCutSL> logger)
        {
            _dailyCutRL = dailyCutRL;
            _logger = logger;
        }

        public async Task<DailyCut> ICreateDailyCutRecordSL(DailyCut dailyCut)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyCutRL.ICreateDailyCutRecordRL(dailyCut);
        }
        public async Task<DailyCut> IReadDailyCutRecordSL()
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyCutRL.IReadDailyCutRecordRL();
        }
        public async Task<DailyCut> IReadDailyCutIDRecordSL(DailyCut dailyCut)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyCutRL.IReadDailyCutIDRecordRL(dailyCut);
        }
        public async Task<DailyCut> IUpdateDailyCutRecordSL(DailyCut dailyCut)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyCutRL.IUpdateDailyCutRecordRL(dailyCut);
        }
        public async Task<DailyCut> IDeleteDailyCutRecordSL(DailyCut dailyCut)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _dailyCutRL.IDeleteDailyCutRecordRL(dailyCut);
        }
    }
}
