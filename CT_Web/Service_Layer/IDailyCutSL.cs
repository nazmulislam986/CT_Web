using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Service_Layer
{
    public interface IDailyCutSL
    {
        public Task<DailyCut> ICreateDailyCutRecordSL(DailyCut dailyCut);
        public Task<DailyCut> IReadDailyCutRecordSL();
        public Task<DailyCut> IReadDailyCutIDRecordSL(DailyCut dailyCut);
        public Task<DailyCut> IUpdateDailyCutRecordSL(DailyCut dailyCut);
        public Task<DailyCut> IDeleteDailyCutRecordSL(DailyCut dailyCut);
    }
}
