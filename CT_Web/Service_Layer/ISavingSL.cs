using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Service_Layer
{
    public interface ISavingSL
    {
        public Task<Saving> ICreateSavingRecordSL(Saving saving);
        public Task<Saving> IReadSavingRecordSL();
        public Task<Saving> IReadSavingIDRecordSL(Saving saving);
        public Task<Saving> IUpdateSavingRecordSL(Saving saving);
        public Task<Saving> IDeleteSavingRecordSL(Saving saving);
    }
}
