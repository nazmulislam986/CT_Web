using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;
using CT_Web.Repository_Layer;
using Microsoft.Extensions.Logging;

namespace CT_Web.Service_Layer
{
    public class SavingSL : ISavingSL
    {
        public readonly ISavingRL _savingRL;
        public readonly ILogger<SavingSL> _logger;
        public SavingSL(ISavingRL savingRL, ILogger<SavingSL> logger)
        {
            _savingRL = savingRL;
            _logger = logger;
        }
        public async Task<Saving> ICreateSavingRecordSL(Saving saving)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _savingRL.ICreateSavingRecordRL(saving);
        }
        public async Task<Saving> IReadSavingRecordSL()
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _savingRL.IReadSavingRecordRL();
        }
        public async Task<Saving> IReadSavingIDRecordSL(Saving saving)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _savingRL.IReadSavingIDRecordRL(saving);
        }
        public async Task<Saving> IUpdateSavingRecordSL(Saving saving)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _savingRL.IUpdateSavingRecordRL(saving);
        }
        public async Task<Saving> IDeleteSavingRecordSL(Saving saving)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _savingRL.IDeleteSavingRecordRL(saving);
        }
    }
}
