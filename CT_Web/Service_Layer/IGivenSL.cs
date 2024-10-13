using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Service_Layer
{
    public interface IGivenSL
    {
        public Task<Given> ICreateGivenRecordSL(Given given);
        public Task<Given> IReadGivenRecordSL();
        public Task<Given> IReadGivenIDRecordSL(Given given);
        public Task<Given> IUpdateGivenRecordSL(Given given);
        public Task<Given> IDeleteGivenRecordSL(Given given);
        public Task<Given> IDeleteResonGivenRecordSL(Given given);
    }
}
