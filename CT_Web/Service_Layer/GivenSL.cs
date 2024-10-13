using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;
using CT_Web.Repository_Layer;
using Microsoft.Extensions.Logging;

namespace CT_Web.Service_Layer
{
    public class GivenSL : IGivenSL
    {
        public readonly IGivenRL _givenRL;
        public readonly ILogger<GivenSL> _logger;
        public GivenSL(IGivenRL givenRL, ILogger<GivenSL> logger)
        {
            _givenRL = givenRL;
            _logger = logger;
        }
        public async Task<Given> ICreateGivenRecordSL(Given given)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _givenRL.ICreateGivenRecordRL(given);
        }
        public async Task<Given> IReadGivenRecordSL()
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _givenRL.IReadGivenRecordRL();
        }
        public async Task<Given> IReadGivenIDRecordSL(Given given)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _givenRL.IReadGivenIDRecordRL(given);
        }
        public async Task<Given> IUpdateGivenRecordSL(Given given)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _givenRL.IUpdateGivenRecordRL(given);
        }
        public async Task<Given> IDeleteGivenRecordSL(Given given)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _givenRL.IDeleteGivenRecordRL(given);
        }
        public async Task<Given> IDeleteResonGivenRecordSL(Given given)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _givenRL.IDeleteResonGivenRecordRL(given);
        }
    }
}
