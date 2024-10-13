using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Service_Layer
{
    public interface ITariffAmtSL
    {
        public Task<TariffAmt> ICreateTariffAmtRecordSL(TariffAmt tariffAmt);
        public Task<TariffAmt> IReadTariffAmtRecordSL();
        public Task<TariffAmt> IReadTariffAmtIDRecordSL(TariffAmt tariffAmt);
        public Task<TariffAmt> IUpdateTariffAmtRecordSL(TariffAmt tariffAmt);
        public Task<TariffAmt> IDeleteTariffAmtRecordSL(TariffAmt tariffAmt);
    }
}
