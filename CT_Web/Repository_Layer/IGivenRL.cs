using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Repository_Layer
{
    public interface IGivenRL
    {
        public Task<Given> ICreateGivenRecordRL(Given given);
        public Task<Given> IReadGivenRecordRL();
        public Task<Given> IReadGivenIDRecordRL(Given given);
        public Task<Given> IUpdateGivenRecordRL(Given given);
        public Task<Given> IDeleteGivenRecordRL(Given given);
        public Task<Given> IDeleteResonGivenRecordRL(Given given);
    }
}
