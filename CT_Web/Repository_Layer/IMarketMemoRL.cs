using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Repository_Layer
{
    public interface IMarketMemoRL
    {
        public Task<MarketMemos> ICreateMarketMemoRecordRL(MarketMemos marketMemos);
        public Task<MarketMemos> IReadMarketMemoRecordRL();
        public Task<MarketMemos> IReadMarketMemoIDRecordRL(MarketMemos marketMemos);
        public Task<MarketMemos> IUpdateMarketMemoRecordRL(MarketMemos marketMemos);
        public Task<MarketMemos> IDeleteMarketMemoRecordRL(MarketMemos marketMemos);
    }
}
