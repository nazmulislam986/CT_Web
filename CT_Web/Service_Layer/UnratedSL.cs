using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;
using CT_Web.Repository_Layer;
using Microsoft.Extensions.Logging;

namespace CT_Web.Service_Layer
{
    public class UnratedSL : IUnratedSL
    {
        public readonly IUnratedRL _unratedRL;
        public readonly ILogger<UnratedSL> _logger;
        public UnratedSL(IUnratedRL unratedRL, ILogger<UnratedSL> logger)
        {
            _unratedRL = unratedRL;
            _logger = logger;
        }
        public async Task<Unrated> ICreateUnratedRecordSL(Unrated unrated)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _unratedRL.ICreateUnratedRecordRL(unrated);
        }
        public async Task<Unrated> IReadUnratedRecordSL()
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _unratedRL.IReadUnratedRecordRL();
        }
        public async Task<Unrated> IReadUnratedIDRecordSL(Unrated unrated)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _unratedRL.IReadUnratedIDRecordRL(unrated);
        }
        public async Task<Unrated> IUpdateUnratedRecordSL(Unrated unrated)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _unratedRL.IUpdateUnratedRecordRL(unrated);
        }
        public async Task<Unrated> IDeleteUnratedRecordSL(Unrated unrated)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _unratedRL.IDeleteUnratedRecordRL(unrated);
        }
    }
}
