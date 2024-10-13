using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Service_Layer
{
    public interface IInstallmentSL
    {
        public Task<Installment> ICreateInstallmentRecordSL(Installment installment);
        public Task<Installment> IReadInstallmentRecordSL();
        public Task<Installment> IReadInstallmentIDRecordSL(Installment installment);
        public Task<Installment> IUpdateInstallmentRecordSL(Installment installment);
        public Task<Installment> IDeleteInstallmentRecordSL(Installment installment);
    }
}
