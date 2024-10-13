using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Service_Layer
{
    public interface IDailyAntSL
    {
        public Task<DailyAnt> ICreateDailyAntRecordSL(DailyAnt dailyAnt);
        public Task<DailyAnt> IReadDailyAntRecordSL();
        public Task<DailyAnt> IReadDailyAntIDRecordSL(DailyAnt dailyAnt);
        public Task<DailyAnt> IUpdateDailyAntRecordSL(DailyAnt dailyAnt);
        public Task<DailyAnt> IDeleteDailyAntRecordSL(DailyAnt dailyAnt);
        public Task<DailyAnt> IDeleteResonDailyAntRecordSL(DailyAnt dailyAnt);
    }
}
