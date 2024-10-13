using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;
using CT_Web.Repository_Layer;
using Microsoft.Extensions.Logging;

namespace CT_Web.Service_Layer
{
    public class TekenSL : ITekenSL
    {
        public readonly ITekenRL _tekenRL;
        public readonly ILogger<TekenSL> _logger;
        public TekenSL(ITekenRL tekenRL, ILogger<TekenSL> logger)
        {
            _tekenRL = tekenRL;
            _logger = logger;
        }
        public async Task<Teken> ICreateTekenRecordSL(Teken teken)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _tekenRL.ICreateTekenRecordRL(teken);
        }
        public async Task<Teken> IReadTekenRecordSL()
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _tekenRL.IReadTekenRecordRL();
        }
        public async Task<Teken> IReadTekenIDRecordSL(Teken teken)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _tekenRL.IReadTekenIDRecordRL(teken);
        }
        public async Task<Teken> IUpdateTekenRecordSL(Teken teken)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _tekenRL.IUpdateTekenRecordRL(teken);
        }
        public async Task<Teken> IDeleteTekenRecordSL(Teken teken)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _tekenRL.IDeleteTekenRecordRL(teken);
        }
    }
}
