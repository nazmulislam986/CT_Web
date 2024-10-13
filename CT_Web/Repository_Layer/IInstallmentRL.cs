using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Repository_Layer
{
    public interface IInstallmentRL
    {
        public Task<Installment> ICreateInstallmentRecordRL(Installment installment);
        public Task<Installment> IReadInstallmentRecordRL();
        public Task<Installment> IReadInstallmentIDRecordRL(Installment installment);
        public Task<Installment> IUpdateInstallmentRecordRL(Installment installment);
        public Task<Installment> IDeleteInstallmentRecordRL(Installment installment);
    }
}
