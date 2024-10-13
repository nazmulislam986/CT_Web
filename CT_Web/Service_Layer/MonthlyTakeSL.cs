using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;
using CT_Web.Repository_Layer;
using Microsoft.Extensions.Logging;

namespace CT_Web.Service_Layer
{
    public class MonthlyTakeSL : IMonthlyTakeSL
    {
        public readonly IMonthlyTakeRL _monthlyTakeRL;
        public readonly ILogger<MonthlyTakeSL> _logger;
        public MonthlyTakeSL(IMonthlyTakeRL monthlyTakeRL, ILogger<MonthlyTakeSL> logger)
        {
            _monthlyTakeRL = monthlyTakeRL;
            _logger = logger;
        }
        public async Task<MonthlyTake> ICreateMonthlyTakeRecordSL(MonthlyTake monthlyTake)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _monthlyTakeRL.ICreateMonthlyTakeRecordRL(monthlyTake);
        }
        public async Task<MonthlyTake> IReadMonthlyTakeRecordSL()
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _monthlyTakeRL.IReadMonthlyTakeRecordRL();
        }
        public async Task<MonthlyTake> IReadMonthlyTakeIDRecordSL(MonthlyTake monthlyTake)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _monthlyTakeRL.IReadMonthlyTakeIDRecordRL(monthlyTake);
        }
        public async Task<MonthlyTake> IUpdateMonthlyTaketRecordSL(MonthlyTake monthlyTake)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _monthlyTakeRL.IUpdateMonthlyTakeRecordRL(monthlyTake);
        }
        public async Task<MonthlyTake> IDeleteMonthlyTakeRecordSL(MonthlyTake monthlyTake)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _monthlyTakeRL.IDeleteMonthlyTakeRecordRL(monthlyTake);
        }
    }
}
