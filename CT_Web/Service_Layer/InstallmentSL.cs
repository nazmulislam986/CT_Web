using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;
using CT_Web.Repository_Layer;
using Microsoft.Extensions.Logging;

namespace CT_Web.Service_Layer
{
    public class InstallmentSL : IInstallmentSL
    {
        public readonly IInstallmentRL _installmentRL;
        public readonly ILogger<InstallmentSL> _logger;
        public InstallmentSL(IInstallmentRL installmentRL, ILogger<InstallmentSL> logger)
        {
            _installmentRL = installmentRL;
            _logger = logger;
        }
        public async Task<Installment> ICreateInstallmentRecordSL(Installment installment)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _installmentRL.ICreateInstallmentRecordRL(installment);
        }
        public async Task<Installment> IReadInstallmentRecordSL()
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _installmentRL.IReadInstallmentRecordRL();
        }
        public async Task<Installment> IReadInstallmentIDRecordSL(Installment installment)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _installmentRL.IReadInstallmentIDRecordRL(installment);
        }
        public async Task<Installment> IUpdateInstallmentRecordSL(Installment installment)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _installmentRL.IUpdateInstallmentRecordRL(installment);
        }
        public async Task<Installment> IDeleteInstallmentRecordSL(Installment installment)
        {
            _logger.LogInformation($"Calling Service Layer");
            return await _installmentRL.IDeleteInstallmentRecordRL(installment);
        }
    }
}
