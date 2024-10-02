using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;
using CT_Web.Repository_Layer;
using Microsoft.Extensions.Logging;

namespace CT_Web.Service_Layer
{
    public class MarketMemoSL : IMarketMemoSL
    {
        public readonly IMarketMemoRL _marketRL;
        public readonly ILogger<MarketMemoSL> _logger;
        public MarketMemoSL(IMarketMemoRL marketRL, ILogger<MarketMemoSL> logger)
        {
            _marketRL = marketRL;
            _logger = logger;
        }
        public async Task<Market> ICreateMarketRecordSL(Market market)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _marketRL.ICreateMarketRecordRL(market);
        }
        public async Task<Market> IReadMarketRecordSL()
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _marketRL.IReadMarketRecordRL();
        }
        public async Task<Market> IReadMarketIDRecordSL(Market market)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _marketRL.IReadMarketIDRecordRL(market);
        }
        public async Task<Market> IUpdateMarketRecordSL(Market market)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _marketRL.IUpdateMarketRecordRL(market);
        }
        public async Task<Market> IDeleteMarketRecordSL(Market market)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _marketRL.IDeleteMarketRecordRL(market);
        }
    }
}
