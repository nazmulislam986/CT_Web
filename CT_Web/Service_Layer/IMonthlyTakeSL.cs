using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Service_Layer
{
    public interface IMonthlyTakeSL
    {
        public Task<MonthlyTake> ICreateMonthlyTakeRecordSL(MonthlyTake monthlyTake);
        public Task<MonthlyTake> IReadMonthlyTakeRecordSL();
        public Task<MonthlyTake> IReadMonthlyTakeIDRecordSL(MonthlyTake monthlyTake);
        public Task<MonthlyTake> IUpdateMonthlyTaketRecordSL(MonthlyTake monthlyTake);
        public Task<MonthlyTake> IDeleteMonthlyTakeRecordSL(MonthlyTake monthlyTake);
    }
}
