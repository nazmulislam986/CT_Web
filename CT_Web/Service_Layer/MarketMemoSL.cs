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
        public readonly IMarketMemoRL _marketMemoRL;
        public readonly ILogger<MarketMemoSL> _logger;
        public MarketMemoSL(IMarketMemoRL marketMemoRL, ILogger<MarketMemoSL> logger)
        {
            _marketMemoRL = marketMemoRL;
            _logger = logger;
        }
        public async Task<MarketMemos> ICreateMarketMemoRecordSL(MarketMemos marketMemos)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _marketMemoRL.ICreateMarketMemoRecordRL(marketMemos);
        }
        public async Task<MarketMemos> IReadMarketMemoRecordSL()
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _marketMemoRL.IReadMarketMemoRecordRL();
        }
        public async Task<MarketMemos> IReadMarketMemoIDRecordSL(MarketMemos marketMemos)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _marketMemoRL.IReadMarketMemoIDRecordRL(marketMemos);
        }
        public async Task<MarketMemos> IUpdateMarketMemoRecordSL(MarketMemos marketMemos)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _marketMemoRL.IUpdateMarketMemoRecordRL(marketMemos);
        }
        public async Task<MarketMemos> IDeleteMarketMemoRecordSL(MarketMemos marketMemos)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _marketMemoRL.IDeleteMarketMemoRecordRL(marketMemos);
        }
    }
}
