using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Repository_Layer
{
    public interface IDailySavingRL
    {
        public Task<DailySaving> ICreateDailySavingRecordRL(DailySaving dailySaving);
        public Task<DailySaving> IReadDailySavingRecordRL();
        public Task<DailySaving> IReadDailySavingIDRecordRL(DailySaving dailySaving);
        public Task<DailySaving> IUpdateDailySavingRecordRL(DailySaving dailySaving);
        public Task<DailySaving> IDeleteDailySavingRecordRL(DailySaving dailySaving);
        public Task<DailySaving> IDeleteResonDailySavingRecordRL(DailySaving dailySaving);
    }
}
