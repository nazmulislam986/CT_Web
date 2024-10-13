using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Repository_Layer
{
    public interface IMonthlyTakeRL
    {
        public Task<MonthlyTake> ICreateMonthlyTakeRecordRL(MonthlyTake monthlyTake);
        public Task<MonthlyTake> IReadMonthlyTakeRecordRL();
        public Task<MonthlyTake> IReadMonthlyTakeIDRecordRL(MonthlyTake monthlyTake);
        public Task<MonthlyTake> IUpdateMonthlyTakeRecordRL(MonthlyTake monthlyTake);
        public Task<MonthlyTake> IDeleteMonthlyTakeRecordRL(MonthlyTake monthlyTake);
    }
}
