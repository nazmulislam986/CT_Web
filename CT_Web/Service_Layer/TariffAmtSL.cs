using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;
using CT_Web.Repository_Layer;
using Microsoft.Extensions.Logging;

namespace CT_Web.Service_Layer
{
    public class TariffAmtSL : ITariffAmtSL
    {
        public readonly ITariffAmtRL _tariffAmtRL;
        public readonly ILogger<TariffAmtSL> _logger;
        public TariffAmtSL(ITariffAmtRL tariffAmtRL, ILogger<TariffAmtSL> logger)
        {
            _tariffAmtRL = tariffAmtRL;
            _logger = logger;
        }
        public async Task<TariffAmt> ICreateTariffAmtRecordSL(TariffAmt tariffAmt)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _tariffAmtRL.ICreateTariffAmtRecordRL(tariffAmt);
        }
        public async Task<TariffAmt> IReadTariffAmtRecordSL()
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _tariffAmtRL.IReadTariffAmtRecordRL();
        }
        public async Task<TariffAmt> IReadTariffAmtIDRecordSL(TariffAmt tariffAmt)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _tariffAmtRL.IReadTariffAmtIDRecordRL(tariffAmt);
        }
        public async Task<TariffAmt> IUpdateTariffAmtRecordSL(TariffAmt tariffAmt)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _tariffAmtRL.IUpdateTariffAmtRecordRL(tariffAmt);
        }
        public async Task<TariffAmt> IDeleteTariffAmtRecordSL(TariffAmt tariffAmt)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _tariffAmtRL.IDeleteTariffAmtRecordRL(tariffAmt);
        }
    }
}
