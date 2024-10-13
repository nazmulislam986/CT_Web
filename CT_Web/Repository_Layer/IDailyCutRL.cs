using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Repository_Layer
{
    public interface IDailyCutRL
    {
        public Task<DailyCut> ICreateDailyCutRecordRL(DailyCut dailyCut);
        public Task<DailyCut> IReadDailyCutRecordRL();
        public Task<DailyCut> IReadDailyCutIDRecordRL(DailyCut dailyCut);
        public Task<DailyCut> IUpdateDailyCutRecordRL(DailyCut dailyCut);
        public Task<DailyCut> IDeleteDailyCutRecordRL(DailyCut dailyCut);
    }
}
