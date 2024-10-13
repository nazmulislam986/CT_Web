using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Service_Layer
{
    public interface IDailySL
    {
        public Task<Daily> ICreateDailyRecordSL(Daily daily);
        public Task<Daily> IReadDailyRecordSL();
        public Task<Daily> IReadDailyIDRecordSL(Daily daily);
        public Task<Daily> IUpdateDailyRecordSL(Daily daily);
        public Task<Daily> IDeleteDailyRecordSL(Daily daily);
        public Task<Daily> IDeleteResonDailyRecordSL(Daily daily);
    }
}
