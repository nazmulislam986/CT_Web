using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Repository_Layer
{
    public interface IMarketRL
    {
        public Task<Market> ICreateMarketRecordRL(Market market);
        public Task<Market> IReadMarketRecordRL();
        public Task<Market> IReadMarketIDRecordRL(Market market);
        public Task<Market> IUpdateMarketRecordRL(Market market);
        public Task<Market> IDeleteMarketRecordRL(Market market);
    }
}
