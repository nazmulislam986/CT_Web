using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Repository_Layer
{
    public interface IDailyRL
    {
        public Task<Daily> ICreateDailyRecordRL(Daily daily);
        public Task<Daily> IReadDailyRecordRL();
        public Task<Daily> IReadDailyIDRecordRL(Daily daily);
        public Task<Daily> IUpdateDailyRecordRL(Daily daily);
        public Task<Daily> IDeleteDailyRecordRL(Daily daily);
        public Task<Daily> IDeleteResonDailyRecordRL(Daily daily);
    }
}
