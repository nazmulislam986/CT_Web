using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Service_Layer
{
    public interface IMarketMemoSL
    {
        public Task<MarketMemos> ICreateMarketMemoRecordSL(MarketMemos marketMemos);
        public Task<MarketMemos> IReadMarketMemoRecordSL();
        public Task<MarketMemos> IReadMarketMemoIDRecordSL(MarketMemos marketMemos);
        public Task<MarketMemos> IUpdateMarketMemoRecordSL(MarketMemos marketMemos);
        public Task<MarketMemos> IDeleteMarketMemoRecordSL(MarketMemos marketMemos);
    }
}
