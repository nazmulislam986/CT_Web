using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Service_Layer
{
    public interface IDailySavingSL
    {
        public Task<DailySaving> ICreateDailySavingRecordSL(DailySaving dailySaving);
        public Task<DailySaving> IReadDailySavingRecordSL();
        public Task<DailySaving> IReadDailySavingIDRecordSL(DailySaving dailySaving);
        public Task<DailySaving> IUpdateDailySavingRecordSL(DailySaving dailySaving);
        public Task<DailySaving> IDeleteDailySavingRecordSL(DailySaving dailySaving);
        public Task<DailySaving> IDeleteResonDailySavingRecordSL(DailySaving dailySaving);
    }
}
