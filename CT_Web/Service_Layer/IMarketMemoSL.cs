using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Service_Layer
{
    public interface IMarketMemoSL
    {
        public Task<Market> ICreateMarketRecordSL(Market market);
        public Task<Market> IReadMarketRecordSL();
        public Task<Market> IReadMarketIDRecordSL(Market market);
        public Task<Market> IUpdateMarketRecordSL(Market market);
        public Task<Market> IDeleteMarketRecordSL(Market market);





    }
}
