using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Repository_Layer
{
    public interface IDailyAntRL
    {
        public Task<DailyAnt> ICreateDailyAntRecordRL(DailyAnt dailyAnt);
        public Task<DailyAnt> IReadDailyAntRecordRL();
        public Task<DailyAnt> IReadDailyAntIDRecordRL(DailyAnt dailyAnt);
        public Task<DailyAnt> IUpdateDailyAntRecordRL(DailyAnt dailyAnt);
        public Task<DailyAnt> IDeleteDailyAntRecordRL(DailyAnt dailyAnt);
        public Task<DailyAnt> IDeleteResonDailyAntRecordRL(DailyAnt dailyAnt);
    }
}
