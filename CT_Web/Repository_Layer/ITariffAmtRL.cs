using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Repository_Layer
{
    public interface ITariffAmtRL
    {
        public Task<TariffAmt> ICreateTariffAmtRecordRL(TariffAmt tariffAmt);
        public Task<TariffAmt> IReadTariffAmtRecordRL();
        public Task<TariffAmt> IReadTariffAmtIDRecordRL(TariffAmt tariffAmt);
        public Task<TariffAmt> IUpdateTariffAmtRecordRL(TariffAmt tariffAmt);
        public Task<TariffAmt> IDeleteTariffAmtRecordRL(TariffAmt tariffAmt);
    }
}
